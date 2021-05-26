using App.BAL.Master;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using System;
using System.Configuration;
using System.Data;

namespace ProjectSix.forum
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

                using (BADtlsForum oBME = new BADtlsForum())
                {
                    dt = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 67, "", ref errMsg, "2020", 1);
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
                        vString +="<a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["FORUM"].ToString() + dt.Rows[i]["FORUM_IMG"]) + "' alt='crystal sienna'></a></div></div>";
                        vString += "<div class='blog-text col-md-6 display-table no-padding'><div class='display-table-cell vertical-align-middle'><div class='content margin-20px-bottom sm-no-padding-left'>";
                        vString += "<a href='" + ResolveClientUrl("~/forum_details/") + Encrypt.EncryptASCII(dt.Rows[i]["DTLS_FORUM_KEY"].ToString()) + "/" + dt.Rows[i]["FORUM_HEADING"].ToString().Replace(' ', '-') + "' class='text-extra-dark-gray margin-5px-bottom alt-font text-extra-large font-weight-600 display-inline-block'>" + dt.Rows[i]["FORUM_HEADING"] + "</a><p class='no-margin width-95'>" + dt.Rows[i]["FORUM_DESC"] + "</p>";
                        vString += "<br><br><div class='text-medium-gray text-extra-small margin-15px-bottom text-uppercase alt-font'><span>" + dt.Rows[i]["FORUM_DATE"] + "</span></div>";
                        vString += "</div></div></div></div>";

                        vString1 += "<li><a href='#'>" + dt.Rows[i]["FORUM_HEADING"] + "</a><span></span></li>";
                    }
                    if (vString != null)
                    {
                        forum_list.InnerHtml = vString;
                    }
                    if (vString1 != null)
                    {
                        forum_cat_list.InnerHtml = vString1;
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
                vString1 = String.Empty;
            }
        }

        protected void btn_Search_click(object sender, EventArgs e)
        {
            String vString2 = String.Empty, vString3 = String.Empty;
            String search = Convert.ToString(txt_search.Value);
            DataTable dt2 = new DataTable();
            EntityDtlsForum obmst = new EntityDtlsForum();
            obmst.COMPANY_KEY = 6;
            using (BADtlsForum oBME = new BADtlsForum())
            {
                dt2 = oBME.Get("GET_SEARCH",6 , search, ref errMsg, Convert.ToString(DateTime.Now), 1);
            }
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    vString2 += "<div class='equalize sm-equalize-auto blog-post-content margin-60px-bottom padding-60px-bottom display-inline-block border-bottom border-color-extra-light-gray sm-margin-30px-bottom sm-padding-30px-bottom xs-text-center sm-no-border'>";
                    vString2 += "<div class='blog-image col-md-5 no-padding sm-margin-30px-bottom xs-margin-20px-bottom margin-45px-right sm-no-margin-right display-table'><div class='display-table-cell vertical-align-middle>";
                    vString2 += "<a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["FORUM"].ToString() + dt2.Rows[i]["FORUM_IMG"]) + "' alt='crystal sienna'></a></div></div>";
                    vString2 += "<div class='blog-text col-md-6 display-table no-padding'><div class='display-table-cell vertical-align-middle'><div class='content margin-20px-bottom sm-no-padding-left'>";
                    vString2 += "<a href='" + ResolveClientUrl("~/forum_details/") + Encrypt.EncryptASCII(dt2.Rows[i]["DTLS_FORUM_KEY"].ToString()) + "/" + dt2.Rows[i]["FORUM_HEADING"].ToString().Replace(' ', '-') + "' class='text-extra-dark-gray margin-5px-bottom alt-font text-extra-large font-weight-600 display-inline-block'>" + dt2.Rows[i]["FORUM_HEADING"] + "</a><p class='no-margin width-95'>" + dt2.Rows[i]["FORUM_DESC"] + "</p>";
                    vString2 += "<br><br><div class='text-medium-gray text-extra-small margin-15px-bottom text-uppercase alt-font'><span>" + dt2.Rows[i]["FORUM_DATE"] + "</span></div>";
                    vString2 += "</div></div></div></div>";

                    vString3 += "<li><a href='#'>" + dt2.Rows[i]["FORUM_HEADING"] + "</a><span></span></li>";
                }
                forum_list.InnerHtml = vString2;
                forum_cat_list.InnerHtml = vString3;
                txt_search.Value = "";
            }
            else
            {
                
                forum_list.Visible = false;
                forum_cat_list.Visible = false;
            }
        }
    }
}