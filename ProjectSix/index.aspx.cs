using App.BAL.Master;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using App.CORE.Domain.Setup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;

using System.Web.UI;

namespace ProjectSix
{
    public partial class index : System.Web.UI.Page
    {
        String errMsg = String.Empty, vString = String.Empty, vString1 = String.Empty, vString2 = String.Empty, vString3 = String.Empty,
        vString4 = String.Empty, vString5 = String.Empty, vString7 = String.Empty, vString8 = String.Empty, vString9 = String.Empty, vString10 = String.Empty,
        vString11 = String.Empty, vString12 = String.Empty, vString14 = String.Empty, vString15 = String.Empty, vString16 = String.Empty, vString17 = String.Empty,
        vString18 = String.Empty, vString19 = String.Empty, vString20 = String.Empty, li = String.Empty;
        Int32 count = 0;
        DataTable images = null;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt2 = null;



        DataTable dt3 = null;
        DataTable dt4 = null;
        DataTable dt5 = null;
        DataTable dt7 = null;
        DataTable dt8 = null;
        DataTable dt9 = null;
        DataTable dt10 = null;
        DataTable dt11 = null;
        DataTable dt12 = null;
        DataTable dt13 = null;
        DataTable back_ground = null;

        EntitySysUser oSysUser = null;

        public static String errMsg1 = String.Empty;
        string str;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                images = new DataTable();
                dt = new DataTable();
                dt1 = new DataTable();
                dt2 = new DataTable();
                dt3 = new DataTable();
                dt4 = new DataTable();
                dt5 = new DataTable();
                dt7 = new DataTable();
                dt8 = new DataTable();
                dt9 = new DataTable();
                dt10 = new DataTable();
                dt11 = new DataTable();
                dt12 = new DataTable();
                dt13 = new DataTable();
                back_ground = new DataTable();

                using (BAHomeSettings oBMC = new BAHomeSettings())
                {
                    dt = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }

                using (BADtlsTour oBMC = new BADtlsTour())
                {
                    dt1 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }

                using (BADtlsPrefer oBMC = new BADtlsPrefer())
                {
                    dt2 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }

                using (BADtlsGallery oBMC = new BADtlsGallery())
                {
                    dt3 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }

                using (BADtlsClient oBMC = new BADtlsClient())
                {
                    dt4 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }
                using (BADtlsDiary oBMC = new BADtlsDiary())
                {
                    dt5 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }
                using (BADtlsRate oBMC = new BADtlsRate())
                {
                    dt7 = oBMC.Get("GET", 6, "0", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }
                using (BADtlsRate oBMC = new BADtlsRate())
                {
                    dt12 = oBMC.Get("GET", 6, "1", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }
                using (BACalendar oBMC = new BACalendar())
                {
                    dt8 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }
                using (BADtlsVoting oBMC = new BADtlsVoting())
                {
                    dt9 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }

                using (BADtlsNews oBMC = new BADtlsNews())
                {
                    dt10 = oBMC.Get("GET_TOP4", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }
                using (BADtlsSelfie oBMC = new BADtlsSelfie())
                {
                    dt11 = oBMC.Get("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }

                using (BAHomeSettings oBMC = new BAHomeSettings())
                {
                    dt13 = oBMC.GetQuickFact("GET", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }

                using (BAHomeSettings oBMC = new BAHomeSettings())
                {
                    //image = oBMC.Get("GET", ref errMsg, Convert.ToString(DateTime.Now), 1);
                    images = oBMC.Get("Get", 6, "", ref errMsg, Convert.ToString(DateTime.Now), 1);
                }

                using (BAHeadHomeBgSetting oBME = new BAHeadHomeBgSetting())
                {
                    back_ground = oBME.Get("GET", 6, "", ref errMsg, null, 1);
                }

                //Page.ClientScript.RegisterStartupScript(GetType(), "err", "my_fun();", true);

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
                ViewState["SELECTED_VALUE"] = ddl_CITY.SelectedValue;
                if (!IsPostBack)
                {
                    if (Request.QueryString["ActivationCode"] != null)
                    {
                        EntitySubscribe oBMAST = null;
                        string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
                        errMsg = String.Empty;
                        oBMAST = new EntitySubscribe();
                        //oBMAST.USER_KEY = Convert.ToInt32(hf_USER_KEY.Value);

                        oBMAST.ACTIVATION_CODE = activationCode;
                        using (BASubscribe oBMC = new BASubscribe())
                        {
                            int vRef;
                            Int32 vKey = 0;
                            vRef = oBMC.SaveChanges<Object, Int32>("UPDATE_TAG", oBMAST, null, ref vKey, ref errMsg, "2019", 1);

                            if (vRef == 1)
                            {
                                //div_Activation_Msg.InnerHtml = "Activation successful.";
                                // ViewState["activation"] = "Activation successful.";
                                Response.Write("<script>alert('Activation successful')</script>");
                            }

                            else
                                //ViewState["activation"] = "Invalid Activation code.";
                                Response.Write("<script>alert('Invalid Activation code.')</script>");
                        }
                    }
                }



                if (dt != null && dt.Rows.Count > 0)
                {
                    about_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BANNER"].ToString() + dt.Rows[0]["ABOUT_IMG"]));
                    about_desc.InnerHtml = dt.Rows[0]["ABOUT_DESC"].ToString();

                }


                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    vString += "<table class='table table-hover'><thead><tr><th scope='col'>To</th><th scope='col'>From</th><th scope='col'>Untill</th></tr></thead>";

                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        vString += "<tbody><tr><td>Brisbane</td><td>" + dt1.Rows[i]["START_DATE"] + "</td><td>" + dt1.Rows[i]["END_DATE"] + "</td></tr></tbody>";
                    }
                    vString += "</table>";
                    vString += "<h5 class='text-light-gray font-weight-600 text-left margin-30px-top margin-30px-bottom'>SUBSCRIBE TO MY TOURS IN YOUR CITY</h5>";
                    vString += "<input type='button' id='btn_Add_Menu' class='btn btn-white btn-very-small' onclick='show_modal();' value ='Subscribe to my tours' />";

                    table_list.InnerHtml = vString;
                }

                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    vString2 += "<div class='col-md-12 col-sm-12 col-xs-12 display-table wow slideInRight last-paragraph-no-margin sm-text-center'><div class='xs-text-center'>";
                    vString2 += "<h4 class='alt-font text-extra-dark-gray text-center'>Things I Prefer In Private</h4></div></div>";
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {

                        vString2 += "<div class='col-sm-12 col-lg-4 margin-30px-top'><a class='btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one'>";
                        vString2 += "" + dt2.Rows[i]["PREFER_NAME"] + "<i class='fas fa-arrow-right icon-very-small' aria-hidden='true'></i></a></div>";
                    }
                    if (vString2 != null)
                    {
                        prefer_list.InnerHtml = vString2;
                    }
                }



                if (dt3 != null && dt3.Rows.Count > 0)
                {
                    vString3 += "<ul class='portfolio-grid work-4col hover-option2'>";
                    vString3 += "<li class='grid-sizer'></li>";
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        vString3 += "<li class='grid-item wow fadeInUp'>";
                        vString3 += "<a href='" + ResolveClientUrl(ConfigurationManager.AppSettings["GALLERY"].ToString() + dt3.Rows[i]["GALLERY_IMG"]) + "' alt='gallery' title = 'Lightbox gallery image title...' data-group = 'four-columns-masonry' class='lightbox-group-gallery-item'>";
                        vString3 += "<figure><div class='portfolio-img bg-extra-dark-gray'>";
                        vString3 += "<img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["GALLERY"].ToString() + dt3.Rows[i]["GALLERY_IMG"]) + "' alt='gallery' class='project-img-gallery'/></div>";
                        vString3 += "<figcaption><div class='portfolio-hover-main text-center'><div class='portfolio-hover-box vertical-align-middle'>";
                        vString3 += "<div class='portfolio-hover-content position-relative'><i class='ti-zoom-in text-white fa-2x'></i></div></div></div></figcaption></figure></a></li>";
                    }
                    vString3 += "</ul>";
                    galleryy_list.InnerHtml = vString3;
                }




                if (dt4 != null && dt4.Rows.Count > 0)
                {

                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        vString4 += "<div class='col-md-4 sm-margin-two-bottom wow fadeIn last-paragraph-no-margin testimonial-style3'>";
                        vString4 += "<div class='testimonial-content-box padding-twelve-all bg-white border-radius- 6 box-shadow arrow-bottom sm-padding-eight-all'>" + dt4.Rows[i]["CLIENT_DESC"] + "</div>";
                        vString4 += "<div class='testimonial-box padding-25px-all xs-padding-20px-all'><div class='image-box width-20'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["CLIENT"].ToString() + dt4.Rows[i]["CLIENT_IMG"]) + "' class='border-radius-100' alt='crystal sienna' title='crystal sienna'></div><div class='name-box padding-20px-left'>";
                        vString4 += "<div class='alt-font font-weight-600 text-small text-uppercase text-extra-dark-gray'>" + dt4.Rows[i]["CLIENT_NAME"] + "</div>";
                        vString4 += "<p class='text-extra-small text-uppercase text-medium-gray'>" + dt4.Rows[i]["CLIENT_TYPE"] + "</p></div></div></div>";
                    }

                    testi_list.InnerHtml = vString4;
                }

                if (dt5 != null && dt5.Rows.Count > 0)
                {
                    Int32 count1 = 0;
                   
                    for (int i = 0; i < dt5.Rows.Count; i++)
                    {
                        if (count1 == 0)
                        {
                            vString5 += "<div class='panel-group' id='accordionGroupOpen' role='tablist' aria-multiselectable='true'>";
                            vString5 += "<div class='panel panel-default'><div class='panel-heading' role='tab' id='heading" + i + "'><h4 class='panel-title'>";
                            vString5 += "<a role='button' data-toggle='collapse' data-parent='#accordionGroupOpen' href='#collapseOpen" + i + "' aria-expanded='true' aria-controls='collapseOpen" + i + "'>" + dt5.Rows[i]["DIARY_HEADING"] + "</a>";
                            vString5 += "</h4></div><div id='collapseOpen" + i + "' class='panel-collapse collapse in' role='tabpanel' aria-labelledby='heading" + i + "'>";
                            vString5 += "<div class='panel-body'><p>";
                            vString5 += "" + dt5.Rows[i]["SHORT_DESC"] + "</p> <a href='" + ResolveClientUrl("~/diary_details/") + Encrypt.EncryptASCII(dt5.Rows[i]["DTLS_DIARY_KEY"].ToString()) + "/" + dt5.Rows[i]["DIARY_HEADING"].ToString().Replace(' ', '-') + "' class='btn btn-large btn-transparent-white text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto margin-20px-top'>Read More</a>";
                            vString5 += "</div></div></div>";
                            vString5 += "</div>";
                        }
                        else
                        {
                            vString5 += "<div class='panel-group' id='accordionGroupOpen' role='tablist' aria-multiselectable='true'>";
                            vString5 += "<div class='panel panel-default'><div class='panel-heading' role='tab' id='heading" + i + "'><h4 class='panel-title'>";
                            vString5 += "<a class='collapsed' role='button' data-toggle='collapse' data-parent='#accordionGroupOpen' href='#collapseOpen" + i + "' aria-expanded='false' aria-controls='collapse" + i + "'>" + dt5.Rows[i]["DIARY_HEADING"] + "</a>";
                            vString5 += "</h4></div><div id='collapseOpen" + i + "' class='panel-collapse collapse' role='tabpanel' aria-labelledby='heading" + i + "'><div class='panel-body'><p>";
                            vString5 += "" + dt5.Rows[i]["SHORT_DESC"] + "</p><a href='" + ResolveClientUrl("~/diary_details/") + Encrypt.EncryptASCII(dt5.Rows[i]["DTLS_DIARY_KEY"].ToString()) + "/" + dt5.Rows[i]["DIARY_HEADING"].ToString().Replace(' ', '-') + "' class='btn btn-large btn-transparent-white text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto margin-20px-top'>Read More</a>";
                            vString5 += "</div></div></div>";
                            vString5 += "</div>";
                        }
                        count1++;
                    }
                    if (vString5 != null)
                    {
                        
                        dairy_list.InnerHtml = vString5;

                    }
                }

                if (dt7 != null && dt7.Rows.Count > 0)
                {
                    vString7 += "<h4>In-call</h4><table class='table table-hover'><thead><tr><th scope ='col' > Hours </th><th scope='col'>Rate</th><th scope='col'>Additional Hours</th></tr></thead>";

                    for (int i = 0; i < dt7.Rows.Count; i++)
                    {
                        vString7 += "<tbody><tr><td>" + dt7.Rows[i]["HOURS"] + "</td><td>" + "$" + dt7.Rows[i]["PRICE"] + "</td><td>" + "Overnight booking: $" + dt7.Rows[i]["ADD_HOURS"] + "</td></tr></tbody>";
                    }

                    vString7 += "</table>";
                    rate_list.InnerHtml = vString7;
                }
                if (dt12 != null && dt12.Rows.Count > 0)
                {
                    vString8 += "<h4>Out-call</h4><table class='table table-hover'><thead><tr><th scope ='col' > Hours </th><th scope='col'>Rate</th>";
                    vString8 += "<th scope='col'>Additional Hours</th></tr></thead>";



                    for (int i = 0; i < dt12.Rows.Count; i++)
                    {
                        vString8 += "<tbody><tr><td>" + dt12.Rows[i]["HOURS"] + "</td><td>" + "$" + dt12.Rows[i]["PRICE"] + "</td>";
                        vString8 += "<td>" + "Overnight booking: $" + dt12.Rows[i]["ADD_HOURS"] + "</td></tr></tbody>";
                    }

                    vString8 += "</table>";
                    rat_list.InnerHtml = vString8;
                }


                if (dt8 != null && dt8.Rows.Count > 0)
                {
                    vString9 += "<table class='table table-hover'><thead><tr><th scope='col'>Weekday</th><th scope='col'>From</th><th scope='col'>Untill</th></tr></thead>";

                    for (int i = 0; i < dt8.Rows.Count; i++)
                    {

                        vString9 += "<tbody><tr><td>" + dt8.Rows[i]["DAY_NAME"] + "</td><td>" + dt8.Rows[i]["START_TIME"] + "</td><td>" + dt8.Rows[i]["END_TIME"] + "</td></tr></tbody>";
                    }
                    vString9 += "</table>";
                    avail_list.InnerHtml = vString9;
                }

                if (dt9 != null && dt9.Rows.Count > 0)
                {
                    for (int k = 0; k < dt9.Rows.Count; k++)
                    {
                        vString10 += "<div class='grid-item col-md-4 col-sm-6 col-xs-12 margin-30px-bottom xs-text-center wow fadeInUp'><div class='blog-post bg-white inner-match-height'>";
                        vString10 += "<div class='blog-post-images overflow-hidden position-relative'><a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["VOTING"].ToString() + dt9.Rows[k]["VOTING_IMG"]) + "' alt='crystal sienna'>";
                        vString10 += "<div class='blog-hover-icon'><span class='text-extra-large font-weight-300'>+</span></div></a></div><div class='post-details padding-40px-all sm-padding-20px-all'>";
                        vString10 += "<span class='text-medium-gray text-uppercase text-extra-small display-inline-block sm-display-block sm-margin-10px-top'>" + dt9.Rows[k]["VOTING_DATE"] + "<span>";
                        vString10 += "<a href='' class='alt-font post-title text-medium text-extra-dark-gray width-100 display-block md-width-100 margin-15px-bottom'></a>";
                        vString10 += "<p>" + dt9.Rows[k]["VOTING_DESC"] + "</p><div class='author'><a href='" + Page.ResolveClientUrl("~/voting/") + "' class='btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one'>";
                        vString10 += "Vote Now<i class='fas fa-arrow-right icon-very-small' area-hidden='true'></i></a></div></div></div></div>";
                    }
                    if (vString10 != null)
                    {
                        voting_list.InnerHtml = vString10;
                    }
                }

                if (dt10 != null && dt10.Rows.Count > 0)
                {
                    vString14 += "<ul class='blog-grid blog-3col gutter-large blog-post-style5'><li class='grid-sizer'></li>";
                    for (int p = 0; p < dt10.Rows.Count; p++)
                    {
                        vString14 += "<li class='grid-item wow fadeInUp last-paragraph-no-margin'><div class='blog-post bg-white'><div class='blog-post-images overflow-hidden'><a href='#'>";
                        vString14 += "<img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["NEWS"].ToString() + dt10.Rows[p]["NEWS_IMG"]) + "' alt='crystal sienna'></a><div class='blog-categories bg-white text-uppercase text-extra-small alt-font'><a href='#'>" + dt10.Rows[p]["NEWS_DATE"] + "</a></div></div>";
                        vString14 += "<div class='post-details inner-match-height padding-40px-all sm-padding-20px-all xs-padding-30px-tb'><div class='blog-hover-color'></div>";
                        vString14 += "<a href='" + ResolveClientUrl("~/news-details/") + Encrypt.EncryptASCII(dt10.Rows[p]["DTLS_NEWS_KEY"].ToString()) + "/" + dt10.Rows[p]["NEWS_HEADING"].ToString().Replace(' ', '-') + "' class='alt-font post-title text-medium text-extra-dark-gray display-block md-width-100 margin-5px-bottom'>" + dt10.Rows[p]["NEWS_HEADING"] + "</a>";
                        vString14 += "<div class='author'></div><div class='separator-line-horrizontal-full bg-medium-gray margin-20px-tb'></div>";
                        vString14 += "<p>" + dt10.Rows[p]["SHORT_DESC"] + "</p></div></div></li>";

                    }
                    vString14 += "</ul>";
                    news_list.InnerHtml = vString14;
                }


                if (dt11 != null && dt11.Rows.Count > 0)
                {
                    vString17 += "<li class='grid-sizer'></li>";
                    for (int i = 0; i < dt11.Rows.Count; i++)
                    {
                        vString17 += "<li class='grid-item wow fadeInUp'>";
                        vString17 += "<a href='" + ResolveClientUrl(ConfigurationManager.AppSettings["SELFIE"].ToString() + dt11.Rows[i]["SELFIE_IMG"]) + "' title = 'Lightbox gallery image title...' data-group = 'three-columns-zoom-animation' class='lightbox-group-gallery-item'>";
                        vString17 += "<figure><div class='portfolio-img bg-extra-dark-gray'>";
                        vString17 += "<img src='" + ResolveClientUrl(ConfigurationManager.AppSettings["SELFIE"].ToString() + dt11.Rows[i]["SELFIE_IMG"]) + "' alt='crystal sienna' class='project-img-gallery'/></div>";
                        vString17 += "<figcaption><div class='portfolio-hover-main text-center'><div class='portfolio-hover-box vertical-align-middle'>";
                        vString17 += "<div class='portfolio-hover-content position-relative'><i class='ti-zoom-in text-white fa-2x'></i></div></div></div></figcaption></figure></a></li>";
                    }
                    selfi_list.InnerHtml = vString17;
                }

                if (dt13 != null && dt13.Rows.Count > 0)
                {

                    vString19 += "<h5 class='alt-font text-light-gray font-weight-600 text-center'>Quick Facts</h5><div class='bg_one padding-20px-all width-600px'><table class='table table-hover'>";
                    for (int i = 0; i < dt13.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            vString19 += "<thead><tr><th scope='col'>" + dt13.Rows[i]["QUICK_FACT_NAME"] + "</th><th scope='col'>" + dt13.Rows[i]["QUICK_FACT_DESC"] + "</th></tr></thead><tbody>";
                        }
                        else
                        {
                            vString19 += "<tr><td>" + dt13.Rows[i]["QUICK_FACT_NAME"] + "</td><td>" + dt13.Rows[i]["QUICK_FACT_DESC"] + "</td></tr>";
                        }

                    }
                    vString19 += "</tbody></table></div>";
                    quick_list.InnerHtml = vString19;
                }

                StringBuilder bannerhtml = new StringBuilder();


                string banner, bannerimage;
                int count;
                banner = images.Rows[0]["BANNER_IMG"].ToString();

                for (int i = 0; i < 3; i++)
                {
                    if (banner != "")
                    {

                        bannerimage = banner.IndexOf("|").ToString();
                        count = Convert.ToInt32(bannerimage) + 1;
                        bannerimage = banner.Substring(0, Convert.ToInt32(bannerimage));
                        bannerhtml.Append("<div class='swiper-slide cover-background' style='background-image: url(../documents/banner/" + bannerimage + ");'><div class='opacity-extra-medium bg-black'></div><div class='container position-relative full-screen'><div class='col-md-12 slider-typography text-left xs-text-center'><div class='slider-text-middle-main'><div class='slider-text-middle '><h1 class='b-text alt-font text-white font-weight-700 letter-spacing-minus-1 line-height-60 width-55 margin-35px-bottom md-width-65 sm-width-75 md-line-height-auto xs-width-100 xs-margin-15px-bottom'>NO FAKE PICS GUARANTEED</h1><p class='text-white text-large margin-four-bottom width-40 md-width-50 sm-width-60 xs-width-100 xs-margin-15px-bottom'>Sexy Crystal Sienna will leave you breathless.I'm a sexy, stunning high class Brisbane escort.</p></div></div></div></div></div>");
                        banner = banner.Remove(0, Convert.ToInt32(count));
                    }
                }

                bannerfrontend.InnerHtml = bannerhtml.ToString();

                if (back_ground != null && back_ground.Rows.Count > 0)
                {

                    tour_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_TOUR_IMAGE"].ToString()));
                    quick_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_QUICK_FACTS_IMAGE"].ToString()));
                    gallery_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_GALLERY_IMAGE"].ToString()));
                    offer_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_EXCITING_OFFER_IMAGE"].ToString()));
                    diary_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_DAIRY_IMAGE"].ToString()));
                    news_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_NEWS_IMAGE"].ToString()));
                    rate_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_RATE_IMAGE"].ToString()));
                    cal_img.Style.Add("background-image", ResolveClientUrl(".." + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + back_ground.Rows[0]["BG_CALENDER_IMAGE"].ToString()));
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
                dt4 = null;
                dt5 = null;
                dt7 = null;
                dt8 = null;
                dt9 = null;
                dt10 = null;
                dt11 = null;
                images = null;
                back_ground = null;
                //dt1 = null;
                vString7 = String.Empty;
                vString1 = String.Empty;
                vString = String.Empty;
                vString = String.Empty;

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

        [System.Web.Services.WebMethod]
        public static string GetAllEvent()
        {

            DataTable getall = new DataTable();
            DataTable getcal = new DataTable();

            String errMsg1 = String.Empty;
            List<EntityDtlsAppointment> entbook = new List<EntityDtlsAppointment>();
            string json = "";
            using (BADtlsAppointment oBME = new BADtlsAppointment())
            {
                getall = oBME.GetAllEvent("GET_APPROVED", 6, "Approved", ref errMsg1, "2020", 8);

                //string[] userArr = new string[getall.Rows.Count];
                //for (int i = 0; i < getall.Rows.Count; i++)
                //{
                //    userArr[i] = getall.Rows[i]["TIME_SPAN"].ToString();
                //}
                //StringBuilder builder = new StringBuilder();
                //foreach (string value in userArr)
                //{
                //    builder.Append(value);
                //    //builder.Append('.');
                //}
                //string result = builder.ToString();

                if (getall.Rows.Count > 0)
                {
                    foreach (DataRow row in getall.Rows)//or similar
                    {
                        EntityDtlsAppointment eNDA = new EntityDtlsAppointment();
                        eNDA.title = Convert.ToString(row["title"]);
                        eNDA.start = Convert.ToString(row["start"]);
                        eNDA.end = Convert.ToString(row["end"]);
                        entbook.Add(eNDA);
                    }
                    json = JsonConvert.SerializeObject(entbook);
                }

                else
                {
                    getcal = oBME.Get("GET_CALENDER", 6, "", ref errMsg1, "2020", 1);
                    if (getcal.Rows.Count > 0)
                    {
                        foreach (DataRow row1 in getcal.Rows)//or similar
                        {
                            EntityDtlsAppointment eNDAc = new EntityDtlsAppointment();
                            eNDAc.title = Convert.ToString(row1["title"]);
                            eNDAc.start = Convert.ToString(row1["start"]);
                            eNDAc.end = Convert.ToString(row1["end"]);
                            entbook.Add(eNDAc);
                        }
                        json = JsonConvert.SerializeObject(entbook);
                    }
                }

            }
            return json;
        }
    }
}