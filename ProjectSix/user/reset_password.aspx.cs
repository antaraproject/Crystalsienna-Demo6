using App.BAL.Setup;
using App.BAL.Utility;
using App.CORE.Domain.Setup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectSix.user
{
    public partial class reset_password : System.Web.UI.Page
    {
        String errMsg = String.Empty;
        String vString2 = String.Empty;
        String vString3 = String.Empty;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt2 = null;
        DataTable dt10 = null;
        EntitySysUser oSysUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send_email(object sender, EventArgs e)
        {
            try
            {
                EntitySysUser oBMST = new EntitySysUser();
                String to_username = txt_email.Value;
                DataTable dt = new DataTable();
                using (BASysUser BASU = new BASysUser())
                {
                    dt = BASU.Get("TYPE_3", 6, to_username, ref errMsg, "2021", 6);
                    oBMST.USER_NAME = dt.Rows[0]["USER_NAME"].ToString();
                    oBMST.USER_EMAIL = dt.Rows[0]["USER_EMAIL"].ToString();
                }
                String txt_User_Name = oBMST.USER_NAME;
                Session["Email"] = oBMST.USER_EMAIL;
                //String emailId = txt_User_Email.Text;
                String EmailAddress = Encrypt.Encryptdata(txt_email.Value);
                if (SendPhoneVerification(txt_email.Value))
                {

                    Response.Redirect("/user/forgot_password.aspx");


                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "popuperror", "popuperror();", true);
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popuperror", "popuperror();", true);
            }
        }

        private bool SendPhoneVerification(String user_email)
        {
            String errMsg = String.Empty;
            DataTable dt = new DataTable();
            EntitySysUser oBMAST = new EntitySysUser();
            bool rt = false;

            using (BASysUser oBMC = new BASysUser())
            {
                if (txt_email.Value != oBMAST.USER_EMAIL)
                {
                    dt = oBMC.Get<Int16>("TYPE_3", 0, txt_email.Value, 6, ref errMsg, null, null);


                    if (dt.Rows.Count > 0)
                    {
                        rt = true;
                    }


                }
            }
            return rt;
        }

    }
}