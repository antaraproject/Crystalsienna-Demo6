using App.BAL.Master;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI;

namespace ProjectSix.contact
{
    public partial class index : System.Web.UI.Page
    {
        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty, vString2 = String.Empty;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt2 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dt1 = new DataTable();
                dt = new DataTable();
                dt2 = new DataTable();
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt = oBME.GetPageSetting("SRH_HEAD_KEY", 98, "", ref errMsg, "2020", 1);
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    Page.Title = dt.Rows[0]["PAGE_TITLE"].ToString();
                    Page.MetaDescription = dt.Rows[0]["META_DESCRIPTION"].ToString();
                    Page.MetaKeywords = dt.Rows[0]["META_KEYWORD"].ToString();
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
                }
                using (BAHomeSettings oBME = new BAHomeSettings())
                {
                    EntityHomeSetting oBHEAD = new EntityHomeSetting();
                    oBHEAD.COMPANY_KEY = 6;
                    dt2 = oBME.Get<Int32>("GET", Convert.ToInt32(oBHEAD.COMPANY_KEY), "", ref errMsg, "2020", 1);
                    //dt = oBME.GetData("GET", "", ref errMsg, "2020", 1);
                }
                if (dt1.Rows.Count > 0)
                {
                    vString += "<p class='width-60 md-width-80 center-col text-medium'>"+ dt1.Rows[0]["ADDRESS"].ToString() +"</p>";
                    address.InnerHtml = vString;
                    vString = "";
                    vString += "<p class='center-col text-medium no-margin'>Phone: " + dt1.Rows[0]["CONTACT_NO"].ToString() + "</p>";
                    contact.InnerHtml = vString;
                    vString = "";
                    vString += "<p class='center-col text-medium no-margin'><a href='mailto:" + dt1.Rows[0]["MAIL"].ToString() + "'>" + dt1.Rows[0]["MAIL"].ToString() + "</a></p>";
                    mail.InnerHtml = vString;
                    vString = "";
                    vString += " <li><a class='facebook' href='"+ dt1.Rows[0]["FACEBOOK_LINK"].ToString() + "' target='_blank'><i class='fab fa-facebook-f'></i><span></span></a></li>";
                    vString += " <li><a class='twitter' href='" + dt1.Rows[0]["TWITTER_LINK"].ToString() + "' target='_blank'><i class='fab fa-twitter'></i><span></span></a></li>";
                    vString += "<li><a class='linkedin' href='" + dt1.Rows[0]["LINKEDIN_LINK"].ToString() + "' target='_blank'><i class='fab fa-linkedin-in'></i><span></span></a></li>";
                    //vString += "";
                    //vString += "";
                    //vString += "";
                    //vString += "";
                    social_content.InnerHtml = vString;
                    logo_header.Src = ConfigurationManager.AppSettings["HOME"] + dt1.Rows[0]["LOGO_NAME"];
                  logo_header1.Src = ConfigurationManager.AppSettings["HOME"] + dt1.Rows[0]["LOGO_NAME"];
                  back_image.Style.Add("background-image", ConfigurationManager.AppSettings["HOME"] + dt1.Rows[0]["FOOTER_IMG"]);
                    header_img.Style.Add("background-image", ConfigurationManager.AppSettings["HOME"] + dt1.Rows[0]["HEADER_IMG"]);


                }

                if (dt2.Rows.Count > 0)
                {
                    side_logo.Style.Add("background-image", ConfigurationManager.AppSettings["BANNER"].ToString() + dt2.Rows[0]["ABOUT_IMG"]);
                }

                System.Web.HttpCookie cookie = Request.Cookies["__asd"];


                if (cookie != null && Session["ID"] != null)
                {
                    vString2 += "<a href='" + Page.ResolveClientUrl("~/user/logout.aspx/") + "'>Logout</a>";
                    login_section.InnerHtml = vString2;
                }
                else
                {
                    vString2 += "<a class='dropdown-toggle' data-toggle='dropdown' href='javascript:void(0);'>User</a>";
                    vString2 += "<ul class='dropdown-menu'>";
                    vString2 += "<li><a href='" + Page.ResolveClientUrl("~/user/login.aspx/") + "'>Login</a></li>";
                    vString2 += "<li><a href='" + Page.ResolveClientUrl("~/user/registration.aspx/") + "'>Registration</a></li>";
                    vString2 += "</ul>";
                    login_section.InnerHtml = vString2;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('" + ex.Message + "');", true);
            }
            finally
            {
                dt = null;

                vString = String.Empty;
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