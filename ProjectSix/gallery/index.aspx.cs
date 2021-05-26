using App.BAL.Master;
using App.CORE.Domain.Setup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectSix.gallery
{
    public partial class index : System.Web.UI.Page
    {
        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty, vString2 = String.Empty, vString3 = String.Empty, vString4 = String.Empty, vString5 = String.Empty, vString7 = String.Empty, vString8 = String.Empty, vString9 = String.Empty, vString10 = String.Empty, vString11 = String.Empty, vString12 = String.Empty, vString14 = String.Empty, vString15 = String.Empty, vString16 = String.Empty, vString17 = String.Empty, vString18 = String.Empty, vString20 = String.Empty, li = String.Empty;
        int count = 0;
        DataTable dt = null;
        DataTable dt4 = null;
        DataTable dt1 = null;

        EntitySysUser oSysUser = null;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                
                
            
                using (BADtlsGallery oBMC = new BADtlsGallery())
                {
                    dt = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt4 = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
                }
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 63, "", ref errMsg, "2020", 1);
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
                    vString3 += "<li class='grid-sizer'></li>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vString3 += "<li class='grid-item wow fadeInUp'>";
                        vString3 += "<a href='" + ResolveClientUrl(ConfigurationManager.AppSettings["GALLERY"].ToString() + dt.Rows[i]["GALLERY_IMG"]) + "' title='Lightbox gallery image title...' data-group='four-columns-masonry' class='lightbox-group-gallery-item'>";
                        vString3 += "<figure><div class='portfolio-img bg-extra-dark-gray'><img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["GALLERY"].ToString() + dt.Rows[i]["GALLERY_IMG"]) + "' alt='crystal sienna' class='project-img-gallery'/></div>";
                        vString3 += "<figcaption><div class='portfolio-hover-main text-center'><div class='portfolio-hover-box vertical-align-middle'>";
                        vString3 += "<div class='portfolio-hover-content position-relative'><i class='ti-zoom-in text-white fa-2x'></i></div></div></div></figcaption></figure></a></li>";
                    }
                    galler_list.InnerHtml = vString3;
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
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('" + ex.Message + "');", true);
            }
            finally
            {
                dt = null;
                //dt1 = null;
                vString7 = String.Empty;
                vString1 = String.Empty;
                vString = String.Empty;
                vString = String.Empty;

            }
        }
    }
}