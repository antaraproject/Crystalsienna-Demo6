using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App.BAL;
using App.BAL.Master;
using App.BAL.Setup;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using App.CORE.Domain.Setup;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProjectSix.user
{
    public partial class registration : System.Web.UI.Page
    {
        String errMsg = String.Empty;
        DataTable dt = null;
        EntitySysUser oSysUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DDLCountry();
                    if (HttpContext.Current.Session["oSysUser"] != null)
                    {
                        oSysUser = (EntitySysUser)Session["oSysUser"];
                        oSysUser.TAG_PAGE_REFRESH = Server.UrlEncode(System.DateTime.Now.ToString());
                        errMsg = String.Empty;

                    }
                    else
                    {
                        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "1")
                        {
                            Response.Write("<script>window.close();</" + "script>");
                            Response.End();
                        }
                        else
                        {
                            // Response.Redirect("../index.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox(1, Message.msgErrCommon, ex.Message);
                }
            }
        }

        private void MessageBox(Int16 pTabid, String strMsg, String exMsg)
        {
            string pType = strMsg == "print" ? "1" : "0";
            if (!(String.IsNullOrEmpty(exMsg)))
                exMsg = CommonOp.ModifyExceptionMessage(exMsg);
            if (pTabid == 1)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenTab1", "OpenTab1('" + strMsg + "')", true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenTab2", "OpenTab2('" + strMsg + "')", true);
        }
        private void DDLCountry()
        {
            DataTable dt4 = new DataTable();
            String country = String.Empty;
            using (BACountry oBMC = new BACountry())
            {
                dt4 = oBMC.GetData("GET", "", ref errMsg, null, null);
            }
            if (dt4.Rows.Count > 0)
            {
                ddlcountry.DataSource = dt4;

                ddlcountry.DataTextField = "COUNTRYCODE";
                ddlcountry.DataValueField = "PHONECODE";
                ddlcountry.DataBind();
            }
            country = Convert.ToString(dt4.Rows[12]["PHONECODE"]);
            ListItem listItem = ddlcountry.Items.FindByValue(country);

            if (listItem != null)
            {

                listItem.Selected = true;
            }
        }

        private void ClearControl()
        {
            txt_NAME.Value = "";
            txt_Phone.Value = "";
            txt_PASS.Value = "";
        }

        protected void btn_signup_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            EntitySysUser oBMAST = null;
            EntitySysUser oSysUser = new EntitySysUser();
            DataTable dt2 = new DataTable();
            try
            {
                if (Page.IsValid)
                {
                    Random r = new Random();
                    string OTP = r.Next(100000, 999999).ToString();

                    errMsg = String.Empty;
                    oBMAST = new EntitySysUser();
                    //oBMAST.USER_KEY = Convert.ToInt32(hf_USER_KEY.Value);
                    oBMAST.USER_NAME = txt_NAME.Value;
                    oBMAST.PHONE_CODE = Convert.ToString(ddlcountry.SelectedValue);
                    oBMAST.USER_EMAIL = txt_Phone.Value;
                    oBMAST.USER_PASSWORD = Encrypt.Encryptdata(txt_PASS.Value);

                    oBMAST.ACTIVATION_CODE = OTP;
                    oBMAST.TAG_DELETE = 0;
                    oBMAST.COMPANY_KEY = 6;

                    string phonenumber = Convert.ToString(oBMAST.PHONE_CODE+ oBMAST.USER_EMAIL);
                    Session["OTP"] = OTP;

                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BASysUser oBMC = new BASysUser())
                    {
                        if (oBMAST.USER_KEY == 0)
                        {
                            if (txt_PASS.Value != null && System.Text.RegularExpressions.Regex.IsMatch(txt_Phone.Value, "^[0-9 ()+-]+$"))
                            {
                                if (SendPhoneVerification(txt_Phone.Value))
                                {
                                    vRef = oBMC.SaveChanges<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                                    using (BASysUser oBME = new BASysUser())
                                    {
                                        dt2 = oBME.Get("GET_USER_KEY", 6, oBMAST.ACTIVATION_CODE, ref errMsg, "2020", 6);
                                    }
                                    Session["User_Key"] = dt2.Rows[0]["USER_KEY"];


                                    if (vRef == 1)
                                    {

                                        sendsms(phonenumber, oBMAST.ACTIVATION_CODE);
                                        ClearControl();

                                        MessageBox(2, Message.msgSaveNew, "");
                                        Response.Redirect("/user/useractivation.aspx", false);
                                        Context.ApplicationInstance.CompleteRequest();

                                    }
                                    else if (vRef == 2)
                                        //MessageBox(2, Message.msgSaveDuplicate, errMsg);
                                        Page.ClientScript.RegisterStartupScript(GetType(), "popupduplicatedata", "popupduplicatedata();", true);

                                }
                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(GetType(), "popupduplicatedata", "popupduplicatedata();", true);
                                }


                            }
                            else
                            {
                               
                                Page.ClientScript.RegisterStartupScript(GetType(), "popuppasswordmatch", "popuppasswordmatch();", true);

                            }
                        }
                        oSysUser.TAG_PAGE_REFRESH = Server.UrlEncode(System.DateTime.Now.ToString());




                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox(2, Message.msgErrCommon, ex.Message);
            }
            finally
            {
                if (oBMAST != null)
                    oBMAST = null;
            }
        }

        private bool SendPhoneVerification(String user_email)
        {

            DataTable dt = new DataTable();
            EntitySysUser oBMAST = new EntitySysUser();
            bool rt = true;

            using (BASysUser oBMC = new BASysUser())
            {
                if (txt_Phone.Value != oBMAST.USER_EMAIL)
                {
                    dt = oBMC.Get<Int16>("TYPE_3", 0, txt_Phone.Value, 6, ref errMsg, null, null);


                    if (dt.Rows.Count > 0)
                    {
                        rt = false;
                        Page.ClientScript.RegisterStartupScript(GetType(), "popupduplicatedata", "popupduplicatedata();", true);
                        MessageBox(2, "Data Already Exist", errMsg);
                    }


                }
            }
            return rt;
        }

        private String sendsms(String to_username, string code)
        {
            EntitySysUser oBMST = new EntitySysUser();

            try
            {
                string tophone, msg;
                String api_key = ConfigurationManager.AppSettings["api_key"].ToString();
                String api_id = ConfigurationManager.AppSettings["api_id"].ToString();


                WebClient client = new WebClient();

                tophone = to_username;
                msg = "OTP is " + code;
                //string baseUrl = "https://platform.clickatell.com/messages/http/send?apiKey=" + api_key + "&to=" + to + "&content=" + msg + "";
                var request = HttpContext.Current.Request;
                var appUrl = ConfigurationManager.AppSettings["appUrl"].ToString();
                //StringBuilder sb = new StringBuilder(appUrl);
                if (appUrl != null)
                {
                    StringBuilder sb = new StringBuilder(appUrl);

                    sb.Replace("{unique}", api_key);
                    sb.Replace("{phone}", tophone);
                    sb.Replace("{activationcode}", msg);

                    string CURL = sb.ToString();
                    var baseUrl = CURL;
                    string url = new WebClient().DownloadString(baseUrl);
                }
                return "success";
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "popupservererror", "popupservererror(); console.log('" + ex.Message + "');", true);
                return "fail";
            }
        }

    }
}