using App.BAL.Master;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using App.CORE.Domain.Master;


namespace ProjectSix.about_me
{
    public partial class index : System.Web.UI.Page
    {

        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty, vString2 = String.Empty;
        Int32 count = 0;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt2 = null;
        DataTable dt3 = null;
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
                using (BAHomeSettings oBME = new BAHomeSettings())
                {
                    EntityHomeSetting oBHEAD = new EntityHomeSetting();
                    oBHEAD.COMPANY_KEY = 6;
                    dt = oBME.Get<Int32>("GET", Convert.ToInt32(oBHEAD.COMPANY_KEY), "", ref errMsg, "2020", 1);
                    //dt = oBME.GetData("GET", "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 5, "", ref errMsg, "2020", 1);
                }
                using (BAHomeSettings oBMC = new BAHomeSettings())
                {
                    dt2 = oBMC.GetQuickFact("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt3 = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
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
                    div_about_us.InnerHtml = "<h5 class='alt-font font-weight-700 text-extra-dark-gray text-uppercase width-80md-width-100'>About</h5>" +
                                           "<div class='separator-line-verticle-extra-small bg-extra-dark-gray width-50 sm-width-70 sm-center-col margin-30px-bottom sm-margin-20px-bottom'></div>" +
                                           "<p class='width-95 md-width-100'> " + dt.Rows[0]["ABOUT_DESC"] + "</p>";

                    
                    img_about.Src = ResolveClientUrl(".." + ConfigurationManager.AppSettings["BANNER"].ToString() + dt.Rows[0]["ABOUT_IMG"]);
                }

                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    Page.Title = dt1.Rows[0]["PAGE_TITLE"].ToString();
                    Page.MetaDescription = dt1.Rows[0]["META_DESCRIPTION"].ToString();
                    Page.MetaKeywords = dt1.Rows[0]["META_KEYWORD"].ToString();
                }
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                   
                        vString2 += "<h5 class='alt-font text-light-gray font-weight-600 text-center'>Quick Facts</h5><div class='bg_one padding-20px-all width-600px'><table class='table table-hover'>";
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                vString2 += "<thead><tr><th scope='col'>" + dt2.Rows[i]["QUICK_FACT_NAME"] + "</th><th scope='col'>" + dt2.Rows[i]["QUICK_FACT_DESC"] + "</th></tr></thead><tbody>";
                            }
                            else
                            {
                                vString2 += "<tr><td>" + dt2.Rows[i]["QUICK_FACT_NAME"] + "</td><td>" + dt2.Rows[i]["QUICK_FACT_DESC"] + "</td></tr>";
                            }

                        }
                        vString2 += "</tbody></table></div>";
                    quick_list.InnerHtml = vString2;
                }

                if (back_ground.Rows.Count > 0)
                {
                    offer_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_EXCITING_OFFER_IMAGE"].ToString()));
                }

                if (dt3.Rows.Count > 0)
                {
                    header_img.Style.Add("background-image", ConfigurationManager.AppSettings["HOME"] + dt3.Rows[0]["HEADER_IMG"]);
                }
                quick_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_QUICK_FACTS_IMAGE"].ToString()));
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
            }
        }
    }
}