using App.BAL.Setup;
using App.CORE.Domain.Setup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectSix.user
{
    public partial class useractivation : System.Web.UI.Page
    {
        Byte vRef = 0; Int32 vKey = 0;
        String errMsg = String.Empty;
        String vString2 = String.Empty;
        String vString3 = String.Empty;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt2 = null;
        DataTable dt10 = null;
        EntitySysUser oBMAST = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            div_Activation_Msg.Visible = false;
            btn_login.Visible = false;

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("/user/login.aspx");
        }

        protected void btn_verify_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            oBMAST = new EntitySysUser();
            oBMAST.USER_KEY = Convert.ToInt32(Session["User_Key"]);
            //oBMAST.USER_EMAIL = hf_USER_EMAIL.Value;
            oBMAST.COMPANY_KEY = 7;
            oBMAST.ACTIVATION_CODE = Convert.ToString(Session["OTP"]);


            using (BASysUser BASU = new BASysUser())
            {
                dt2 = BASU.Get("CHECK_OTP", oBMAST.USER_KEY, "", ref errMsg, "", 6);
            }
            oBMAST.ACTIVATION_CODE = Convert.ToString(dt2.Rows[0]["ACTIVATION_CODE"]);
            if (oBMAST.ACTIVATION_CODE == txt_OTP.Value)
            {
                using (BASysUser oBMC = new BASysUser())
                {
                    vRef = oBMC.SaveChanges<Object, Int32>("UPDATE_TAG", oBMAST, null, ref vKey, ref errMsg, "2019", 8);
                }
                div_Activation_Msg.Visible = true;
                div_Activation_Msg.InnerText = "Activation successful.";
                btn_login.Visible = true;
                otp_div.Visible = false;
            }
            else
            {
                div_Activation_Msg.InnerText = "Please Enter Correct OTP.";
                div_Activation_Msg.Visible = true;
                btn_login.Visible = false;
                otp_div.Visible = true;
                txt_OTP.Value = "";
                // ClientScript.RegisterStartupScript(GetType(), "popuperror", "popuperror();", true);
                //div_Activation_Msg.InnerText = "Invalid Activation code.";
            }
        }

        protected void btn_resend_Click(object sender, EventArgs e)
        {
            oBMAST = new EntitySysUser();
            oBMAST.USER_KEY = Convert.ToInt32(Session["User_Key"]);
            //oBMAST.USER_EMAIL = hf_USER_EMAIL.Value;
            oBMAST.COMPANY_KEY = 1;
            oBMAST.ACTIVATION_CODE = Convert.ToString(Session["OTP"]);
            

            using (BASysUser BASU = new BASysUser())
            {
                dt2 = BASU.Get("CHECK_OTP", oBMAST.USER_KEY, "", 1, ref errMsg, "", 1);
            }
            string activationcode = Convert.ToString(dt2.Rows[0]["ACTIVATION_CODE"]);
            oBMAST.USER_EMAIL = Convert.ToString(Convert.ToString(dt2.Rows[0]["PHONE_CODE"]) + Convert.ToString(dt2.Rows[0]["USER_EMAIL"]));
            Session["phone"] = oBMAST.USER_EMAIL;
            if (oBMAST.ACTIVATION_CODE == activationcode)
            {
                sendsms(oBMAST.USER_EMAIL, oBMAST.ACTIVATION_CODE);
                div_Activation_Msg.InnerHtml = "OTP Resend Successfully.";
                div_Activation_Msg.Visible = true;
                otp_div.Visible = true;
                txt_OTP.Value = "";
            }

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