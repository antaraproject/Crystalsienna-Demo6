using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.BAL.Master;
using App.BAL.Utility;
using System.Data;
using System.Configuration;
using App.CORE.Domain.Master;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.IO;

namespace ProjectSix
{
    public partial class Site : System.Web.UI.MasterPage
    {
        DataTable dt;
        DataTable dt1;
        String errMsg = String.Empty, vString = String.Empty;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
            {
                dt1 = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
            }
            using (BAHomeSettings oBME = new BAHomeSettings())
            {
                EntityHomeSetting oBHEAD = new EntityHomeSetting();
                oBHEAD.COMPANY_KEY = 6;
                dt = oBME.Get<Int32>("GET", Convert.ToInt32(oBHEAD.COMPANY_KEY), "", ref errMsg, "2020", 1);
                //dt = oBME.GetData("GET", "", ref errMsg, "2020", 1);
            }
            if (dt1.Rows.Count > 0)
                {
                    logo_header.Src = ConfigurationManager.AppSettings["HOME"] + dt1.Rows[0]["LOGO_NAME"];
                    logo_header1.Src = ConfigurationManager.AppSettings["HOME"] + dt1.Rows[0]["LOGO_NAME"];
                    back_image.Style.Add("background-image", ConfigurationManager.AppSettings["HOME"] + dt1.Rows[0]["FOOTER_IMG"]);
                }

                if (dt.Rows.Count > 0)
                {
                    side_logo.Style.Add("background-image", ConfigurationManager.AppSettings["BANNER"].ToString() + dt.Rows[0]["ABOUT_IMG"]);
                }

            HttpCookie cookie = Request.Cookies["__asd"];


            if (cookie != null && Session["ID"] != null)
            {
                vString += "<a href='" + Page.ResolveClientUrl("~/user/logout.aspx/") +  "'>Logout</a>";
                login_section.InnerHtml = vString;
            }
            else
            {
                vString += "<a class='dropdown-toggle' data-toggle='dropdown' href='javascript:void(0);'>User</a>";
                vString += "<ul class='dropdown-menu'>";
                vString+= "<li><a href='" + Page.ResolveClientUrl("~/user/login.aspx/") + "'>Login</a></li>";
                vString += "<li><a href='" + Page.ResolveClientUrl("~/user/registration.aspx/") + "'>Registration</a></li>";
                vString += "</ul>";
                login_section.InnerHtml = vString;
            }

        }
        protected void btn_Submit_click(object sender, EventArgs e)
        {
           
            try
            {
                string to_username = ConfigurationManager.AppSettings["to_username"].ToString();
                string form_username = ConfigurationManager.AppSettings["form_username"].ToString();
                string form_password = ConfigurationManager.AppSettings["form_password"].ToString();
                string smtpAddress = "smtp.gmail.com"; //103.21.58.247
                int portNumber = 587;
                bool enableSSL = true; //false


                using (MailMessage mail = new MailMessage())
                {
                    string template = File.ReadAllText(Server.MapPath("~/main-assets/contactmail.html"));
                    template = template.Replace("FULLNAME", txt_Name.Value);
                    template = template.Replace("PHONE", txt_Phone.Value);
                    template = template.Replace("EMAILID", txt_Email.Value);

                    template = template.Replace("MESSAGE", txt_Message.Value);

                    mail.From = new MailAddress(form_username);
                    mail.To.Add(to_username);
                    mail.Subject = "New appointment query from " + txt_Name.Value + " for Crystal Sienna";
                    mail.Body = template.ToString();
                    mail.IsBodyHtml = true;


                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(form_username, Encrypt.Decryptdata(form_password));
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }

                    //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Your enquiry is submitted. Thank you for contacting us. ');", true);
                    Page.ClientScript.RegisterStartupScript(GetType(), "popup", "popup();", true);
                    using (MailMessage mail1 = new MailMessage())
                    {

                        string template1 = File.ReadAllText(Server.MapPath("~/main-assets/contactreply.html"));
                        template = template.Replace("FULLNAME", txt_Name.Value);


                        mail.From = new MailAddress(form_username);
                        mail.To.Add(txt_Email.Value);
                        mail.Subject = "Thank you for contacting on Crystal Sienna";
                        mail.Body = template1.ToString();
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(form_username, Encrypt.Decryptdata(form_password));
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }
                    txt_Name.Value = "";
                    txt_Phone.Value = "";
                    txt_Email.Value = "";
                    txt_Message.Value = "";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popupservererror", "popupservererror(); console.log('" + ex.Message + "');", true);
            }
        }

    }
}