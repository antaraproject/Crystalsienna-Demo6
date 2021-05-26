using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.CORE.Domain.Setup;
using App.BAL;
using App.BAL.Master;
using App.BAL.Setup;
using App.BAL.Utility;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Configuration;

namespace ProjectSix.user
{
    public partial class login : System.Web.UI.Page
    {
        string user_key;
        String errMsg = String.Empty;
        EntitySysUser oSysUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                if(Request.QueryString["ActivationCode"] != null) { 
                EntitySysUser oBMAST = null;
                    Byte vRef = 0; Int32 vKey = 0;
                    string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
                errMsg = String.Empty;
                oBMAST = new EntitySysUser();
                //oBMAST.USER_KEY = Convert.ToInt32(hf_USER_KEY.Value);
                oBMAST.COMPANY_KEY = 6;
                oBMAST.ACTIVATION_CODE = activationCode;
                oBMAST.TAG_ACTIVATION = 1;
                using (BASysUser oBMC = new BASysUser())
                {


                    vRef = oBMC.SaveChanges<Object, Int32>("UPDATE_TAG", oBMAST, null, ref vKey, ref errMsg, "2019", 1);

                    if (vRef == 1)
                    {
                            Response.Write("<script>alert('Activation successful');</script>");
                        //div_Activation_Msg.InnerText = "Activation successful.";
                    }
                    else if (vRef == 2)
                    {
                            Response.Write("<script>alert('Account is already activated. Please login!!!!');</script>");
                          //  div_Activation_Msg.InnerText = "Account is already activated. Please login!!!!";
                    }
                    else
                            Response.Write("<script>alert('Invalid Activation code');</script>");
                        //div_Activation_Msg.InnerText = "Invalid Activation code.";
                }
                }






                HttpCookie cookie = Request.Cookies["__asd"];
                if (cookie != null)
                {
                    string username = cookie["a"];
                    string password = cookie["p"];

                    DataTable dt = null;
                    Int32 vRef = 0;
                    using (BASysUser oBSU = new BASysUser())
                    {
                        dt = oBSU.Get<Int16>("TYPE_1", 0, Encrypt.Decryptdata(username), 6, ref errMsg, null, null);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (password == Encrypt.EncryptASCII(Encrypt.Decryptdata(Convert.ToString(dr["USER_PASSWORD"]))))
                            {
                                setUserSession(dr);
                                vRef = 1;
                            }
                        }

                        if (vRef == 1)
                            Response.Redirect("~/index.aspx");
                    }
                }
            }
        }

        private void MessageBox(String strMsg, String exMsg)
        {
            if (!(String.IsNullOrEmpty(exMsg)))
                exMsg = CommonOp.ModifyExceptionMessage(exMsg);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "OpenPopup('" + strMsg + "', '" + exMsg + "')", true);
        }

        private void setUserSession(DataRow dr)
        {
            oSysUser = new EntitySysUser();
            oSysUser.USER_KEY = Convert.ToInt16(dr["USER_KEY"]);
            oSysUser.USER_NAME = Convert.ToString(dr["USER_NAME"]);
            oSysUser.USER_TYPE_KEY = Convert.ToInt32(dr["USER_TYPE_KEY"]);
            oSysUser.USER_TYPE = Convert.ToString(dr["USER_TYPE"]);
            oSysUser.MAST_HRD_PERSONNEL_KEY = Convert.ToInt32(dr["MAST_HRD_PERSONNEL_KEY"]);
            oSysUser.USER_EMAIL = Convert.ToString(dr["USER_EMAIL"]);
            oSysUser.COMPANY_KEY = 6;

            Session["oSysUser"] = oSysUser;
            Session["ID"] = oSysUser.USER_NAME;
            Session["USERID"] = oSysUser.USER_KEY;
            Session["useremail"] = oSysUser.USER_EMAIL;
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataTable dt = null;
                try
                {
                    Int32 vRef = 0;
                    using (BASysUser oBSU = new BASysUser())
                    {
                        dt = oBSU.Get<Int16>("TYPE_3", 0, txt_USER.Value, 6, ref errMsg, null, 1);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (Encrypt.Encryptdata(txt_PASS.Value) == Convert.ToString(dr["USER_PASSWORD"]))
                            {
                                setUserSession(dr);

                                user_key = Convert.ToString(dr["USER_KEY"]);

                                string hash = "f0xle@rn";

                                byte[] data = UTF8Encoding.UTF8.GetBytes(user_key);
                                using (System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
                                {
                                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                                    using (System.Security.Cryptography.TripleDESCryptoServiceProvider tripDes = new System.Security.Cryptography.TripleDESCryptoServiceProvider() { Key = keys, Mode = System.Security.Cryptography.CipherMode.ECB, Padding = System.Security.Cryptography.PaddingMode.PKCS7 })
                                    {
                                        System.Security.Cryptography.ICryptoTransform transform = tripDes.CreateEncryptor();
                                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                                        user_key = Convert.ToBase64String(results, 0, results.Length);
                                        Session["user"] = user_key;
                                    }

                                }

                                HttpCookie objCookie = new HttpCookie("__asd");
                                objCookie["a"] = Encrypt.Encryptdata(txt_USER.Value).ToString();
                                objCookie["p"] = Encrypt.EncryptASCII(txt_PASS.Value).ToString();
                                objCookie.Expires = DateTime.Now.AddDays(60);
                                Response.Cookies.Add(objCookie);
                                vRef = 1;
                            }

                        }




                        if (vRef == 1)
                        {


                            Response.Redirect("~/index.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();


                        }



                        else
                            Page.ClientScript.RegisterStartupScript(GetType(), "popupservererror", "popupservererror();", true);
                       // MessageBox(Message.msgErr401, errMsg);
                    }
                    else
                        Page.ClientScript.RegisterStartupScript(GetType(), "popuperror", "popuperror();", true);
                    //MessageBox(Message.msgErrPage, errMsg);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "popupservererror", "popupservererror();", true);
                    //MessageBox(Message.msgErrCommon, ex.Message);
                }
                finally
                {
                    if (oSysUser != null)
                        oSysUser = null;
                    if (dt != null)
                    {
                        dt.Dispose(); dt = null;
                    }
                }
            }

        }
    }
}