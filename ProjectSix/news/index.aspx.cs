using App.BAL.Master;
using App.BAL.Utility;
using System;
using System.Configuration;
using System.Data;

namespace ProjectSix.news
{
    public partial class index : System.Web.UI.Page
    {

        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty;
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

                using (BADtlsNews oBME = new BADtlsNews())
                {
                    dt = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 6, "", ref errMsg, "2020", 1);
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
                        vString += "<div class='equalize sm-equalize-auto blog-post-content margin-60px-bottom padding-60px-bottom display-inline-block border-bottom border-color-extra-light-gray sm-margin-30px-bottom sm-padding-30px-bottom xs-text-center sm-no-border'>";
                        vString += "<div class='blog-image col-md-5 no-padding sm-margin-30px-bottom xs-margin-20px-bottom margin-45px-right sm-no-margin-right display-table'><div class='display-table-cell vertical-align-middle>";
                        vString += "<a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["NEWS"].ToString() + dt.Rows[i]["NEWS_IMG"]) + "' alt='crystal sienna'></a></div></div>";
                        vString += "<div class='blog-text col-md-6 display-table no-padding'><div class='display-table-cell vertical-align-middle'><div class='content margin-20px-bottom sm-no-padding-left'>";
                        vString += "<a href='" + ResolveClientUrl("~/news-details/") + Encrypt.EncryptASCII(dt.Rows[i]["DTLS_NEWS_KEY"].ToString()) + "/" + dt.Rows[i]["NEWS_HEADING"].ToString().Replace(' ', '-') + "' class='text-extra-dark-gray margin-5px-bottom alt-font text-extra-large font-weight-600 display-inline-block'>" + dt.Rows[i]["NEWS_HEADING"] + "</a><div class='text-medium-gray text-extra-small margin-15px-bottom text-uppercase alt-font'>";
                        vString += "<span>" + dt.Rows[i]["NEWS_DATE"] + "</span></div><p class='no-margin width-95'>" + dt.Rows[i]["SHORT_DESC"] + "</p></div></div></div></div>";

                        vString1 += "<div class='margin-45px-bottom xs-margin-25px-bottom'><a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["NEWS"].ToString() + dt.Rows[i]["NEWS_IMG"]) + "' alt='crystal sienna' class='margin-25px-bottom'></a>";
                        vString1 += "<p class='margin-20px-bottom text-small'>" + dt.Rows[i]["SHORT_DESC"] + "</p></div>";
                    }
                    if (vString != null)
                    {
                        news_list.InnerHtml = vString;
                    }
                    if (vString1 != null)
                    {
                        news_cat_list.InnerHtml = vString1;
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