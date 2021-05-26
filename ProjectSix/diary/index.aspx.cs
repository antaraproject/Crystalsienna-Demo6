using App.BAL.Master;
using App.BAL.Utility;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace ProjectSix.diary
{
    public partial class index : System.Web.UI.Page
    {

        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty, vString2 = String.Empty;
        Int32 count = 0, count1 = 0;
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

                using (BADtlsDiary oBME = new BADtlsDiary())
                {
                    dt = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BADtlsClient oBME = new BADtlsClient())//client
                {
                    dt1 = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BADtlsNews oBME = new BADtlsNews())//news
                {
                    dt2 = oBME.Get("GET_TOP4", 6, "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt3 = oBME.GetPageSetting("SRH_HEAD_KEY", 64, "", ref errMsg, "2020", 1);
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
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (count == 0)
                        {
                            vString += "<div class='panel-group' id='accordionGroupOpen' role='tablist' aria-multiselectable='true'>";
                            vString += "<div class='panel panel-default'><div class='panel-heading' role='tab' id='heading" + i + "'><h4 class='panel-title'>";
                            vString += "<a role='button' data-toggle='collapse' data-parent='#accordionGroupOpen' href='#collapseOpen" + i + "' aria-expanded='true' aria-controls='collapseOpenOne'>" + dt.Rows[i]["DIARY_HEADING"] + "</a>";
                            vString += "</h4></div><div id='collapseOpen" + i + "' class='panel-collapse collapse in' role='tabpanel' aria-labelledby='heading" + i + "'><div class='panel-body'><p>";
                            vString += "" + dt.Rows[i]["SHORT_DESC"] + "</p><a href='" + ResolveClientUrl("~/diary_details/") + Encrypt.EncryptASCII(dt.Rows[i]["DTLS_DIARY_KEY"].ToString()) + "/" + dt.Rows[i]["DIARY_HEADING"].ToString().Replace(' ', '-') + "' class='btn btn-large btn-transparent-white text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto margin-20px-top'>Read More</a>";
                            vString += "</div></div></div>";
                            vString += "</div>";
                        }
                        else
                        {
                            vString += "<div class='panel-group' id='accordionGroupOpen' role='tablist' aria-multiselectable='true'>";
                            vString += "<div class='panel panel-default'><div class='panel-heading' role='tab' id='heading" + i + "'><h4 class='panel-title'>";
                            vString += "<a class='collapsed' role='button' data-toggle='collapse' data-parent='#accordionGroupOpen' href='#collapseOpen" + i + "' aria-expanded='false' aria-controls='collapse" + i + "'>" + dt.Rows[i]["DIARY_HEADING"] + "</a>";
                            vString += "</h4></div><div id='collapseOpen" + i + "' class='panel-collapse collapse' role='tabpanel' aria-labelledby='heading" + i + "'><div class='panel-body'><p>";
                            vString += "" + dt.Rows[i]["SHORT_DESC"] + " </p><a href='" + ResolveClientUrl("~/diary_details/") + Encrypt.EncryptASCII(dt.Rows[i]["DTLS_DIARY_KEY"].ToString()) + "/" + dt.Rows[i]["DIARY_HEADING"].ToString().Replace(' ', '-') + "' class='btn btn-large btn-transparent-white text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto margin-20px-top'>Read More</a>";
                            vString += "</div></div></div>";
                            vString += "</div>";
                        }
                        count++;
                    }
                    if (vString != null)
                    {
                        
                        diary_list.InnerHtml = vString;

                    }
                }

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        if (count1 == 0)
                        {
                            vString1 += "<div class='col-md-4 sm-margin-two-bottom wow fadeIn last-paragraph-no-margin testimonial-style3'><div class='testimonial-content-box padding-twelve-all bg-white border-radius-6 box-shadow arrow-bottom sm-padding-eight-all'>";
                            vString1 += "" + dt1.Rows[j]["CLIENT_DESC"] + "</div><div class='testimonial-box padding-25px-all xs-padding-20px-all'><div class='image-box width-20'>";
                            vString1 += "<img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["CLIENT"].ToString() + dt1.Rows[j]["CLIENT_IMG"]) + "' class='border-radius-100' alt='crystal sienna'>";
                            vString1 += "</div><div class='name-box padding-20px-left'><div class='alt-font font-weight-600 text-small text-uppercase text-extra-dark-gray'>" + dt1.Rows[j]["CLIENT_NAME"] + "</div>";
                            vString1 += "<p class='text-extra-small text-uppercase text-medium-gray'>" + dt1.Rows[j]["CLIENT_TYPE"] + "</p></div></div></div>";
                        }
                        else if (count == 1)
                        {
                            vString1 += "<div class='col-md-4 sm-margin-two-bottom wow fadeIn last-paragraph-no-margin testimonial-style3' data-wow-delay='0.2s'><div class='testimonial-content-box padding-twelve-all bg-white border-radius-6 box-shadow arrow-bottom sm-padding-eight-all'>";
                            vString1 += "" + dt1.Rows[j]["CLIENT_DESC"] + "</div><div class='testimonial-box padding-25px-all xs-padding-20px-all'><div class='image-box width-20'>";
                            vString1 += "<img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["CLIENT"].ToString() + dt1.Rows[j]["CLIENT_IMG"]) + "' class='border-radius-100' alt='crystal sienna'>";
                            vString1 += "</div><div class='name-box padding-20px-left'><div class='alt-font font-weight-600 text-small text-uppercase text-extra-dark-gray'>" + dt1.Rows[j]["CLIENT_NAME"] + "</div>";
                            vString1 += "<p class='text-extra-small text-uppercase text-medium-gray'>" + dt1.Rows[j]["CLIENT_TYPE"] + "</p></div></div></div>";
                        }
                        else
                        {
                            vString1 += "<div class='col-md-4 wow fadeIn last-paragraph-no-margin testimonial-style3' data-wow-delay='0.4s'><div class='testimonial-content-box padding-twelve-all bg-white border-radius-6 box-shadow arrow-bottom sm-padding-eight-all'>";
                            vString1 += "" + dt1.Rows[j]["CLIENT_DESC"] + "</div><div class='testimonial-box padding-25px-all xs-padding-20px-all'><div class='image-box width-20'>";
                            vString1 += "<img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["CLIENT"].ToString() + dt1.Rows[j]["CLIENT_IMG"]) + "' class='border-radius-100' alt='crystal sienna'>";
                            vString1 += "</div><div class='name-box padding-20px-left'><div class='alt-font font-weight-600 text-small text-uppercase text-extra-dark-gray'>" + dt1.Rows[j]["CLIENT_NAME"] + "</div>";
                            vString1 += "<p class='text-extra-small text-uppercase text-medium-gray'>" + dt1.Rows[j]["CLIENT_TYPE"] + "</p></div></div></div>";
                        }
                        count1++;
                    }
                    if (vString1 != null)
                    {
                        client_list.InnerHtml = vString1;
                    }
                }

                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    vString2 += "<ul class='blog-grid blog-3col gutter-large blog-post-style5'><li class='grid-sizer'></li>";
                    for (int k = 0; k < dt2.Rows.Count; k++)
                    {
                        //vString2 += "<li class='grid-item wow fadeInUp last-paragraph-no-margin'><div class='blog-post bg-white'><div class='blog-post-images overflow-hidden'>";
                        //vString2 += "<a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["NEWS"].ToString() + dt2.Rows[k]["NEWS_IMG"]) + "' alt='crystal sienna'></a>";
                        //vString2 += "<div class='blog-categories bg-white text-uppercase text-extra-small alt-font'><a href='#'>" + dt2.Rows[k]["NEWS_DATE"]+"</a></div></div>";
                        //vString2 += "<div class='post-details inner-match-height padding-40px-all sm-padding-20px-all xs-padding-30px-tb'>";
                        //vString2 += "<div class='blog-hover-color'></div>";
                        //vString2 += " <a href='#' class='alt-font post-title text-medium text-extra-dark-gray display-block md-width-100 margin-5px-bottom'>" + dt2.Rows[k]["NEWS_HEADING"]+"</a>";
                        //vString2 += "<div class='author'></div><div class='separator-line-horrizontal-full bg-medium-gray margin-20px-tb'></div>";
                        //vString2 += " <p>" + dt2.Rows[k]["SHORT_DESC"] + "</p>";
                        //vString2 += "</div></div></li>";

                        vString2 += "<li class='grid-item wow fadeInUp last-paragraph-no-margin'><div class='blog-post bg-white'><div class='blog-post-images overflow-hidden'><a href='#'>";
                        vString2 += "<img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["NEWS"].ToString() + dt2.Rows[k]["NEWS_IMG"]) + "' alt='crystal sienna'></a><div class='blog-categories bg-white text-uppercase text-extra-small alt-font'><a href='#'>" + dt2.Rows[k]["NEWS_DATE"] + "</a></div></div>";
                        vString2 += "<div class='post-details inner-match-height padding-40px-all sm-padding-20px-all xs-padding-30px-tb'><div class='blog-hover-color'></div>";
                        vString2 += "<a href='" + ResolveClientUrl("~/news-details/") + Encrypt.EncryptASCII(dt2.Rows[k]["DTLS_NEWS_KEY"].ToString()) + "/" + dt2.Rows[k]["NEWS_HEADING"].ToString().Replace(' ', '-') + "' class='alt-font post-title text-medium text-extra-dark-gray display-block md-width-100 margin-5px-bottom'>" + dt2.Rows[k]["NEWS_HEADING"] + "</a>";
                        vString2 += "<div class='author'></div><div class='separator-line-horrizontal-full bg-medium-gray margin-20px-tb'></div>";
                        vString2 += "<p>" + dt2.Rows[k]["SHORT_DESC"] + "</p></div></div></li>";

                    }
                    vString2 += "</ul>";
                }
                
                
                
                if (vString2 != null)
                {
                    news_list.InnerHtml = vString2;
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
                    diary_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_DAIRY_IMAGE"].ToString()));
                    news_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_NEWS_IMAGE"].ToString()));
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
                dt2 = null;
                dt3 = null;

                vString = String.Empty;
                vString1 = String.Empty;
                vString2 = String.Empty;
            }
        }
    }
}