
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

namespace ProjectSix.selfie
{
    public partial class index : System.Web.UI.Page
    {
        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty, vString2 = String.Empty, vString3 = String.Empty, vString4 = String.Empty, vString5 = String.Empty, vString7 = String.Empty, vString8 = String.Empty, vString9 = String.Empty, vString10 = String.Empty, vString11 = String.Empty, vString12 = String.Empty, vString14 = String.Empty, vString15 = String.Empty, vString16 = String.Empty, vString17 = String.Empty, vString18 = String.Empty, vString20 = String.Empty, li = String.Empty;
        int count = 0;
        DataTable dt = null;
        DataTable dt8 = null;
        DataTable dt1 = null;
        EntitySysUser oSysUser = null;
        DataTable dt4 = null;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt8 = new DataTable();


                //using (BATestimonial oBMC = new BATestimonial())
                //{
                //    dt1 = oBMC.Get("GET", 0, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                //}



                //using (BADtlsGallery oBMC = new BADtlsGallery())
                //{
                //    dt3 = oBMC.Get("GET", 0, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                //}


                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 65, "", ref errMsg, "2020", 1);
                }

                using (BACalendar oBMC = new BACalendar())
                {
                    dt8 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }



                using (BADtlsSelfie oBMC = new BADtlsSelfie())
                {
                    dt = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
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
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    vString18 += "<li class='grid-sizer'></li>";
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        vString18 += "<li class='grid-item wow fadeInUp'>";
                //        vString18 += "<a href='" + ResolveClientUrl(ConfigurationManager.AppSettings["SELFIE"].ToString() + dt.Rows[i]["SELFIE_IMG"]) + "' title = 'Lightbox gallery image title...' data-group = 'three-columns-zoom-animation' class='lightbox-group-gallery-item'>";
                //        vString18 += "<figure><div class='portfolio-img bg-extra-dark-gray'>";
                //        vString18 += "<img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["SELFIE"].ToString() + dt.Rows[i]["SELFIE_IMG"]) + "' alt='crystal sienna' class='project-img-gallery'/></div>";
                //        vString18 += "<figcaption><div class='portfolio-hover-main text-center'><div class='portfolio-hover-box vertical-align-middle'>";
                //        vString18 += "<div class='portfolio-hover-content position-relative'><i class='ti-zoom-in text-white fa-2x'></i></div></div></div></figcaption></figure></a></li>";
                //    }
                //    selfi_list.InnerHtml = vString18;
                //}

                if (dt != null && dt.Rows.Count > 0)
                {
                    vString2 += "<li class='grid-sizer'></li>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vString2 += "<li class='grid-item wow fadeInUp'>";
                        vString2 += "<a href='" + ResolveClientUrl(ConfigurationManager.AppSettings["SELFIE"].ToString() + dt.Rows[i]["SELFIE_IMG"]) + "' title = 'Lightbox gallery image title...' data-group = 'three-columns-zoom-animation' class='lightbox-group-gallery-item'>";
                        vString2 += "<figure><div class='portfolio-img bg-extra-dark-gray'>";
                        vString2 += "<img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["SELFIE"].ToString() + dt.Rows[i]["SELFIE_IMG"]) + "' alt='crystal sienna' class='project-img-gallery'/></div>";
                        vString2 += "<figcaption><div class='portfolio-hover-main text-center'><div class='portfolio-hover-box vertical-align-middle'>";
                        vString2 += "<div class='portfolio-hover-content position-relative'><i class='ti-zoom-in text-white fa-2x'></i></div></div></div></figcaption></figure></a></li>";
                    }
                    sel_list.InnerHtml = vString2;
                }
                if (dt8 != null && dt8.Rows.Count > 0)
                {

                    //vString += "<div class='shopHeadBottomSec clearfix'><div class='shortByHigh'></div></div><div class='row'>";
                    //vString1 += "<div class='col-lg-6 col-md-6 col-sm-12 col-xs-12 col-lg-offset-3 col-md-offset-3'><div class='gm_heading'>";
                    //vString1 += "<h1>Testimonials</h1><p>Delighted Customers and what they say</p></div></div>";
                    //vString1 += "<div class='col-lg-6 col-md-6 col-sm-12 col-xs-12 col-lg-offset-3 col-md-offset-3 col-sm-offset-0 col-xs-offset-0'>";
                    //vString1 += "< div class='gm_testimonial_box'>< div class='owl-carousel owl-theme'>";
                    vString9 += "<table class='table table-hover'>";
                    vString9 += "<thead><tr><th scope='col'>Weekday</th>";
                    vString9 += "<th scope='col'>From</th>";
                    vString9 += "<th scope='col'>Untill</th></tr></thead>";

                    for (int i = 0; i < dt8.Rows.Count; i++)
                    {

                        //vString1 += "<div class='col-md-6 col-sm-12 col-xs-12 position-relative sm-height-500px xs-height-350px cover-background wow slideInLeft'>" + dt.Rows[i]["ABOUT_IMG"] + "</div>";
                        ////vString1 += "<div class='item'><h4>" + dt1.Rows[i]["TESTIMONIAL_NAME"] + "</h4><p>" + dt1.Rows[i]["TEST_COMMENTS"] + "</p></div>";
                        //vString1 += "<div class='col-md-6 col-sm-12 col-xs-12 display-table wow slideInRight last-paragraph- no-margin sm-text-center'>";
                        //vString1 += "<div class='display-table-cell vertical-align-middle padding-fifteen-all sm-padding-ten-all xs-no-padding-lr xs-text-center'>";
                        //vString1 += "<span class='text-medium margin-20px-bottom display-block alt-font'>Crystal Sienna</span>";
                        //vString1 += "<h4 class='alt-font text-extra-dark-gray '>About</h4>";
                        //vString1 += "<p class='width-80 md-width-100 xs-width-100'>" + dt.Rows[i]["ABOUT_DESC"] + "</p>";
                        //vString1 += "<a href='#' class='btn btn-small btn-white btn-rounded margin-35px-top xs-margin-25px-top'>Read More</a></div></div>";
                        vString9 += "<tbody><tr>";
                        vString9 += "<td>" + dt8.Rows[i]["DAY_NAME"] + "</td>";
                        vString9 += "<td>" + dt8.Rows[i]["START_TIME"] + "</td>";
                        vString9 += "<td>" + dt8.Rows[i]["END_TIME"] + "</td></tr></tbody>";
                    }
                    vString9 += "</table>";
                    //vString += "<h5 class='text-light-gray font-weight-600 text-left margin-30px-top margin-30px-bottom'>SUBSCRIBE TO MY TOURS IN YOUR CITY</h5>";
                    //vString += "<a class='btn btn-white btn-very-small' href='#'>Subscribe to my tours</a>";

                    //vString1 += "</div></div></div>";
                    //bl_list.InnerHtml = vString;
                    avai_list.InnerHtml = vString9;
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
