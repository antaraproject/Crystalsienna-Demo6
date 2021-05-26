using App.BAL.Master;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using System.Net.Mail;
using System.Net;

namespace ProjectSix.tour
{
    public partial class index : System.Web.UI.Page
    {

        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty, vString2 = String.Empty;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt2 = null;
        DataTable dt3 = null;
        DataTable dt4 = null;
        DataTable back_ground = null;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                //Sidebar Content
                dt = new DataTable();
                dt1 = new DataTable();
                dt2 = new DataTable();
                dt3 = new DataTable();

                using (BADtlsPrefer oBME = new BADtlsPrefer())
                {
                    dt = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BADtlsTour oBME = new BADtlsTour())
                {
                    dt1 = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BADtlsVoting oBME = new BADtlsVoting())
                {
                    dt2 = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt3 = oBME.GetPageSetting("SRH_HEAD_KEY", 50, "", ref errMsg, "2020", 1);
                }
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt4 = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
                }
                using (BAHeadHomeBgSetting oBME = new BAHeadHomeBgSetting())
                {
                    back_ground = oBME.Get("GET", 6, "", ref errMsg, null, 1);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('" + ex.Message + "');", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    vString += "<div class='col-md-12 col-sm-12 col-xs-12 display-table wow slideInRight last-paragraph-no-margin sm-text-center'><div class='xs-text-center'>";
                    vString += "<h4 class='alt-font text-extra-dark-gray text-center'>Things I Prefer In Private</h4></div></div>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vString += "<div class='col-sm-12 col-lg-4 margin-30px-top'><a href='#' class='btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one'>";
                        vString += "" + dt.Rows[i]["PREFER_NAME"] + "<i class='fas fa-arrow-right icon-very-small' aria-hidden='true'></i></a></div>";
                    }
                    if (vString != null)
                    {
                        prefer_list.InnerHtml = vString;
                    }
                }

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    vString1 += "<table class='table table-hover'><thead><tr><th scope ='col'>To</th><th scope='col'>From</th><th scope ='col'>Untill</th></tr></thead><tbody>";
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        vString1 += "<tr><td>" + dt1.Rows[j]["TOUR_PLACE"] + "</td><td>" + dt1.Rows[j]["FROM_DATE"] + "</td><td>" + dt1.Rows[j]["TO_DATE"] + "</td></tr>";
                    }
                    if (vString1 != null)
                    {
                        vString1 += "<tbody></table><h5 class='text-light-gray font-weight-600 text-left margin-30px-top margin-30px-bottom'>SUBSCRIBE TO MY TOURS IN YOUR CITY</h5>";
                        vString1 += "<a class='btn btn-white btn-very-small' onclick='show_modal();' href='#'>Subscribe to my tours</a>";
                        tour_list.InnerHtml = vString1;
                    }
                }

                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    for (int k = 0; k < dt2.Rows.Count; k++)
                    {
                        vString2 += "<div class='grid-item col-md-4 col-sm-6 col-xs-12 margin-30px-bottom xs-text-center wow fadeInUp'><div class='blog-post bg-white inner-match-height'>";
                        vString2 += "<div class='blog-post-images overflow-hidden position-relative'><a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["VOTING"].ToString() + dt2.Rows[k]["VOTING_IMG"]) + "' alt='crystal sienna'>";
                        vString2 += "<div class='blog-hover-icon'><span class='text-extra-large font-weight-300'>+</span></div></a></div><div class='post-details padding-40px-all sm-padding-20px-all'>";
                        vString2 += "<span class='text-medium-gray text-uppercase text-extra-small display-inline-block sm-display-block sm-margin-10px-top'>" + dt2.Rows[k]["VOTING_DATE"] + "<span>";
                        vString2 += "<a href='' class='alt-font post-title text-medium text-extra-dark-gray width-100 display-block md-width-100 margin-15px-bottom'></a>";
                        vString2 += "<p>" + dt2.Rows[k]["VOTING_DESC"] + "</p><div class='author'><a href='" + Page.ResolveClientUrl("~/voting/") + "' class='btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one'>";
                        vString2 += "Vote Now<i class='fas fa-arrow-right icon-very-small' area-hidden='true'></i></a></div></div></div></div>";
                    }
                    if (vString2 != null)
                    {
                        voting_list.InnerHtml = vString2;
                    }
                }

                if (dt3 != null && dt3.Rows.Count > 0)
                {
                    Page.Title = dt3.Rows[0]["PAGE_TITLE"].ToString();
                    Page.MetaDescription = dt3.Rows[0]["META_DESCRIPTION"].ToString();
                    Page.MetaKeywords = dt3.Rows[0]["META_KEYWORD"].ToString();
                }
                if (dt4.Rows.Count > 0)
                {
                    header_img.Style.Add("background-image", ConfigurationManager.AppSettings["HOME"] + dt4.Rows[0]["HEADER_IMG"]);
                }
                if (back_ground.Rows.Count > 0)
                {
                    tour_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_TOUR_IMAGE"].ToString()));
                }

                FillDdlMenu();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('" + ex.Message + "');", true);
            }
            finally
            {
                dt = null;
                dt1 = null;
                dt2 = null;
                dt3 = null;

                vString = String.Empty;
                vString1 = String.Empty;
                vString2 = String.Empty;
            }
        }



        private String FillDdlMenu()
        {
            try
            {
                errMsg = String.Empty;
                //hf_HEAD_MENU_KEY.Value = ddl_HEAD_MENU_KEY.SelectedValue;
                using (BAMastCity oBMC = new BAMastCity())
                {
                    oBMC.BindDdl(ref ddl_CITY, 1, ref errMsg, null, 0);
                    return errMsg;
                }

                //hf_HEAD_MENU_KEY.Value = ddl_HEAD_MENU_KEY.SelectedValue;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected void btn_Save_Menu_ServerClick(object sender, EventArgs e)
        {
            int vref;
            // int check = ddl_CITY.SelectedIndex;
            EntitySubscribe oBMAST = null;
            oBMAST = new EntitySubscribe();
            string code = Convert.ToString(Guid.NewGuid());
            oBMAST.ACTIVATION_CODE = code;
            oBMAST.MAST_CITY_KEY = Convert.ToInt32(ViewState["SELECTED_VALUE"]);
            oBMAST.EMAIL_ID = txt_EMAIL.Text;
            oBMAST.ENT_USER_KEY = 1;



            using (BASubscribe oBMC = new BASubscribe())
            {

                dt = oBMC.Get<Int32>("GET_COUNT", 6, txt_EMAIL.Text, ref errMsg, "2019", 1);

                if (dt != null && dt.Rows.Count > 0)

                {
                    if (dt.Rows[0]["COUNT_TOUR"].ToString() != "0")
                    {
                        Response.Write("<script>alert('You have already subscribe')</script>");
                    }
                    else
                    {
                        vref = oBMC.SaveChanges("INSERT", oBMAST, "", ref errMsg, ref errMsg, Convert.ToString(DateTime.Now), 1);



                        if (vref == 1)
                        {
                            sendemail(code);
                            Response.Write("<script>alert('Please check your inbox')</script>");
                        }
                    }
                }
                else
                {
                    vref = oBMC.SaveChanges("INSERT", oBMAST, "", ref errMsg, ref errMsg, Convert.ToString(DateTime.Now), 1);



                    if (vref == 1)
                    {
                        sendemail(code);
                        Response.Write("<script>alert('Please check your inbox')</script>");
                    }
                }
            }

        }

        public int sendemail(string code)
        {
            int errMsg = 0;
            try
            {


                string form_username = ConfigurationManager.AppSettings["form_username"].ToString();
                string form_password = ConfigurationManager.AppSettings["form_password"].ToString();



                //string messages = otp + " is your OTP for Web4Escort registration.";

                using (MailMessage mm = new MailMessage(form_username, txt_EMAIL.Text))
                {
                    mm.Subject = "Web4Escort subscribe my tour";
                    string strBody = string.Empty;
                    strBody += "<html><head></head><body>";
                    strBody += Environment.NewLine;
                    strBody += "<a href='" + Request.Url.AbsoluteUri.Replace("index.aspx", "index.aspx?ActivationCode=" + code.ToString()) + "'>Click the following link to subscribe the tour.</a>";
                    strBody += "<br/>Thanks.</body></html>";

                    mm.Body = strBody.ToString();
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(form_username, Encrypt.Decryptdata(form_password)); //Encrypt.Decryptdata()
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }

                errMsg = 1;

                return errMsg;
            }
            catch (Exception ex)
            {
                return errMsg;
                ex.Message.ToString();
            }
        }


    }
}