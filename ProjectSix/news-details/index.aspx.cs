using App.BAL.Master;
using App.BAL.Utility;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;

namespace ProjectSix.news_details
{
    public partial class index : System.Web.UI.Page
    {
        String errMsg = String.Empty; String vString = String.Empty;
        DataTable dt;
        DataTable dt2;
        DataTable dt4 = null;
        DataTable dt1;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                dt1 = new DataTable();
                dt = new DataTable();
                dt2 = new DataTable();
                if (Request.QueryString["news"] != null)
                {
                    Session["news"] = Convert.ToInt32(Encrypt.DecryptASCII(Request.QueryString["news"]));
                    Int32 forumkey = Convert.ToInt32(Encrypt.DecryptASCII(Request.QueryString["news"]));
                    using (BADtlsNews oBMG = new BADtlsNews())
                    {
                        dt = oBMG.Get<Int32>("SRH_DTLS", forumkey, "", ref errMsg, "2019", 1);
                    }
                }
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 142, "", ref errMsg, "2020", 1);
                }
                using (BADtlsNews oBME = new BADtlsNews())
                {
                    dt2 = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
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
            if (dt.Rows.Count > 0)
            {
                DateTime date1;
                date1 = Convert.ToDateTime(dt.Rows[0]["NEWS_DATE"]);

                vString += "'<h2>" + dt.Rows[0]["NEWS_HEADING"].ToString() + "</h2>'<h4>Written on " + date1.ToLongDateString() + "</h4><div class='testiimg'>";
                vString += "<img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["NEWS"].ToString() + dt.Rows[0]["NEWS_IMG"]) + "' alt='crystal sienna' class='img-fluuid'></div><div class='share'><h4>Share this...</h4>";
                vString += "<div class='socl'><a href='#'><i class='fab fa-facebook-f'></i></a><a href ='#'><i class='fab fa-twitter'></i></a><a href = '#'><i class='fab fa-google-plus-g'></i></a><a href = '#'><i class='fab fa-pinterest'></i></a>";
                vString += "<a href = '#'><i class='fab fa-tumblr' aria-hidden='true'></i></a><a href = '#'><i class='fab fa-linkedin' aria-hidden='true'></i></a><a href = '#'><i class='fab fa-reddit' aria-hidden='true'></i></a><a href = '#'><i class='fab fa-reddit' aria-hidden='true'></i></a><a href = '#'><i class='fas fa-share'></i></a><a href = '#'><i class='fas fa-envelope'></i></a><a href = '#'><i class='fas fa-print'></i></a></div>";
                vString += dt.Rows[0]["NEWS_DESC"].ToString();

                diary_main.InnerHtml = vString;

            }
            vString = "";
            if (dt2.Rows.Count > 0)
            {
                int j;
                if (dt2.Rows.Count >= 3)
                {
                    j = 3;
                }
                else
                {
                    j = dt2.Rows.Count;
                }

                for (int i = 0; i < j; i++)
                {
                    vString += "<span><img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["NEWS"].ToString() + dt2.Rows[i]["NEWS_IMG"]) + "' alt='crystal sienna' class='img-fluuid'>";
                    vString += "<a href='" + ResolveClientUrl("~/news-details/") + Encrypt.EncryptASCII(dt2.Rows[i]["DTLS_NEWS_KEY"].ToString()) + "/" + dt2.Rows[i]["NEWS_HEADING"].ToString().Replace(' ', '-') + "'>" + dt2.Rows[i]["NEWS_HEADING"].ToString() + "</a></span>";
                }

                side_content.InnerHtml = vString;
            }

            if (dt4.Rows.Count > 0)
            {
                header_img.Style.Add("background-image", ConfigurationManager.AppSettings["HOME"] + dt4.Rows[0]["HEADER_IMG"]);
            }
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                Page.Title = dt1.Rows[0]["PAGE_TITLE"].ToString();
                Page.MetaDescription = dt1.Rows[0]["META_DESCRIPTION"].ToString();
                Page.MetaKeywords = dt1.Rows[0]["META_KEYWORD"].ToString();
            }
        }
    }
}