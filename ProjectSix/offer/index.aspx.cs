using App.BAL.Master;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace ProjectSix.offer
{
    public partial class index : System.Web.UI.Page
    {

        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty;
        Int32 count = 0;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt4 = null;
        DataTable back_ground = null;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                //Sidebar Content
                dt = new DataTable();
                dt1 = new DataTable();

                using (BAHomeSettings oBME = new BAHomeSettings())
                {

                    //dt = oBME.GetData("GET", "", ref errMsg, "2020", 1);
                }

                using (BADtlsOffer oBME = new BADtlsOffer())
                {
                    dt = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 62, "", ref errMsg, "2020", 1);
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
                    vString += "<li class='grid-sizer'></li>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        vString += "<li class='grid-item web branding design wow fadeInUp'><a href='#'><figure><div class='portfolio-img'>";
                        vString += "<img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["OFFER"].ToString() + dt.Rows[i]["OFFER_IMG"]) + "' alt='crystal sienna' /></div><figcaption>";
                        vString += "<div class='portfolio-hover-main text-center last-paragraph-no-margin'><div class='portfolio-hover-box vertical-align-middle'>";
                        vString += "<div class='portfolio-hover-content position-relative'><span class='font-weight-600 alt-font text-uppercase margin-one-bottom display-block text-extra-dark-gray'>" + dt.Rows[i]["OFFER_NOTE"] + "</span>";
                        vString += "<p class='font-weight-600 alt-font text-uppercase margin-one-bottom display-block text-extra-dark-gray discount-tag'>" + dt.Rows[i]["OFFER_PER"] + "%" + " Discount" + "</p></div></div></div></figcaption></figure></a></li>";
                    }

                    offer_dtl.InnerHtml = vString;
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
                if (back_ground.Rows.Count > 0)
                {
                    offer_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_EXCITING_OFFER_IMAGE"].ToString()));
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
            }
        }
    }
}