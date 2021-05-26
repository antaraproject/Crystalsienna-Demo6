using App.BAL.Master;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace ProjectSix.testimonial
{
    public partial class index : System.Web.UI.Page
    {

        String errMsg = String.Empty, vString = String.Empty;
        Int32 count = 0;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt4 = null;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                //Sidebar Content
                dt = new DataTable();
                dt1 = new DataTable();

                using (BADtlsClient oBME = new BADtlsClient())
                {
                    dt = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 2, "", ref errMsg, "2020", 1);
                }
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt4 = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
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
                    vString = String.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (count == 0)
                        {
                            vString += "<div class='col-md-6 sm-margin-two-bottom wow fadeIn last-paragraph-no-margin testimonial-style3'><div class='testimonial-content-box padding-twelve-all bg-white border-radius-6 box-shadow arrow-bottom sm-padding-eight-all'>";
                            vString += "" + dt.Rows[i]["CLIENT_DESC"] + "</div><div class='testimonial-box padding-25px-all xs-padding-20px-all'><div class='image-box width-20'>";
                            vString += "<img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["CLIENT"].ToString() + dt.Rows[i]["CLIENT_IMG"]) + "' class='border-radius-100' alt='crystal sienna'>";
                            vString += "</div><div class='name-box padding-20px-left'><div class='alt-font font-weight-600 text-small text-uppercase text-extra-dark-gray'>" + dt.Rows[i]["CLIENT_NAME"] + "</div>";
                            vString += "<p class='text-extra-small text-uppercase text-medium-gray'>" + dt.Rows[i]["CLIENT_TYPE"] + "</p></div></div></div>";
                        }
                        else if (count == 1)
                        {
                            vString += "<div class='col-md-6 sm-margin-two-bottom wow fadeIn last-paragraph-no-margin testimonial-style3' data-wow-delay='0.2s'><div class='testimonial-content-box padding-twelve-all bg-white border-radius-6 box-shadow arrow-bottom sm-padding-eight-all'>";
                            vString += "" + dt.Rows[i]["CLIENT_DESC"] + "</div><div class='testimonial-box padding-25px-all xs-padding-20px-all'><div class='image-box width-20'>";
                            vString += "<img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["CLIENT"].ToString() + dt.Rows[i]["CLIENT_IMG"]) + "' class='border-radius-100' alt='crystal sienna'>";
                            vString += "</div><div class='name-box padding-20px-left'><div class='alt-font font-weight-600 text-small text-uppercase text-extra-dark-gray'>" + dt.Rows[i]["CLIENT_NAME"] + "</div>";
                            vString += "<p class='text-extra-small text-uppercase text-medium-gray'>" + dt.Rows[i]["CLIENT_TYPE"] + "</p></div></div></div>";
                        }
                        else
                        {
                            vString += "<div class='col-md-6 wow fadeIn last-paragraph-no-margin testimonial-style3' data-wow-delay='0.4s'><div class='testimonial-content-box padding-twelve-all bg-white border-radius-6 box-shadow arrow-bottom sm-padding-eight-all'>";
                            vString += "" + dt.Rows[i]["CLIENT_DESC"] + "</div><div class='testimonial-box padding-25px-all xs-padding-20px-all'><div class='image-box width-20'>";
                            vString += "<img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["CLIENT"].ToString() + dt.Rows[i]["CLIENT_IMG"]) + "' class='border-radius-100' alt='crystal sienna'>";
                            vString += "</div><div class='name-box padding-20px-left'><div class='alt-font font-weight-600 text-small text-uppercase text-extra-dark-gray'>" + dt.Rows[i]["CLIENT_NAME"] + "</div>";
                            vString += "<p class='text-extra-small text-uppercase text-medium-gray'>" + dt.Rows[i]["CLIENT_TYPE"] + "</p></div></div></div>";
                        }
                        count++;
                    }
                    if (vString != null)
                    {
                        client_list.InnerHtml = vString;
                    }
                }

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    Page.Title = dt1.Rows[0]["PAGE_TITLE"].ToString();
                    Page.MetaDescription = dt1.Rows[0]["META_DESCRIPTION"].ToString();
                    Page.MetaKeywords = dt1.Rows[0]["META_KEYWORD"].ToString();
                }
                if (dt4.Rows.Count > 0)
                {
                    header_img.Style.Add("background-image", ConfigurationManager.AppSettings["HOME"] + dt4.Rows[0]["HEADER_IMG"]);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('" + ex.Message + "');", true);
            }
            finally
            {
                dt = null;
                dt1 = null;

                vString = String.Empty;
            }
        }
    }
}