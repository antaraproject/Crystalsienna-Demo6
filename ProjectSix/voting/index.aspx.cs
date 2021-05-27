using App.BAL.Master;
using App.CORE.Domain.Master;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Services;

namespace ProjectSix.voting
{
    public partial class index : System.Web.UI.Page
    {

        String errMsg = String.Empty, vString = String.Empty;
        Int32 count = 0;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt4 = null;
        DataTable dt5 = null;
        DataTable dt6 = null;
        String user_key;
        String COUNT_VOTE;
        public static String errMsg1 = String.Empty;
      
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
              
                //Sidebar Content
                dt = new DataTable();
                dt1 = new DataTable();

                using (BADtlsVoting oBME = new BADtlsVoting())
                {
                    dt = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 68, "", ref errMsg, "2020", 1);
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

                        dt5 = new DataTable();
                        dt6 = new DataTable();

                        using (BADtlsVoting oBMG = new BADtlsVoting())
                        {
                            dt5 = oBMG.Get_COUNT("GET", "", dt.Rows[i]["DTLS_VOTING_KEY"].ToString(), ref errMsg, "2019", 1);
                        }

                        if (dt5 != null && dt5.Rows.Count > 0)
                        {
                            COUNT_VOTE = dt5.Rows[0]["VOTE_COUNT"].ToString();

                        }
                        else
                        {
                            COUNT_VOTE = "0";
                        }
                        ViewState["VOTE_COUNT"] = COUNT_VOTE;
                        HttpCookie cookie = Request.Cookies["__asd"];

                        if (cookie != null && HttpContext.Current.Session["ID"] != null)
                        {
                            user_key = Session["USERID"].ToString();
                          
                        }
                        else
                        {
                            user_key = "0";
                        }


                        using (BADtlsVoting oBMG = new BADtlsVoting())
                        {
                            dt6 = oBMG.Get_COUNT("GET_USER", user_key, dt.Rows[i]["DTLS_VOTING_KEY"].ToString(), ref errMsg, "2019", 1);
                        }

                        vString += "<div class='grid-item col-md-4 col-sm-6 col-xs-12 margin-30px-bottom xs-text-center wow fadeInUp'><div class='blog-post bg-white inner-match-height'>";
                        vString += "<div class='blog-post-images overflow-hidden position-relative'><a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["VOTING"].ToString() + dt.Rows[i]["VOTING_IMG"]) + "' alt='crystal sienna'>";
                        vString += "<div class='blog-hover-icon'><span class='text-extra-large font-weight-300'>+</span></div></a></div><div class='post-details padding-40px-all sm-padding-20px-all'>";
                        vString += "<span class='text-medium-gray text-uppercase text-extra-small display-inline-block sm-display-block sm-margin-10px-top'>" + dt.Rows[i]["VOTING_DATE"] + "<span>";
                        vString += "<a href='' class='alt-font post-title text-medium text-extra-dark-gray width-100 display-block md-width-100 margin-15px-bottom'>" + dt.Rows[i]["VOTING_HEADING"] + "</a>";
                        vString += "<p>" + dt.Rows[i]["VOTING_DESC"] + "</p><div class='separator-line-horrizontal-full bg-medium-gray margin-20px-tb'></div><div class='author'>";

                        if (dt6 != null && dt6.Rows.Count > 0)
                        {
                            if(dt6.Rows[0]["VOTE_COUNT"].ToString() == "0")
                            {

                                vString += "<a href='' id='btn" + i + "' onclick='useranswer(this.id)' data-='" + dt.Rows[i]["DTLS_VOTING_KEY"] + "' class='btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one'>";
                                vString += "Vote " + COUNT_VOTE + "</a></div></div></div></div>";
                            }

                            else
                            {

                                vString += "<a disabled='disabled' class='btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one'>";
                                vString += "Vote " + COUNT_VOTE + "</a></div></div></div></div>";
                            }
                        }
                        else 
                        {
                            vString += "<a href='' id='btn" + i + "' onclick='useranswer(this.id)' data-='" + dt.Rows[i]["DTLS_VOTING_KEY"] + "' class='btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one'>";
                            vString += "Vote " + COUNT_VOTE + "</a></div></div></div></div>";
                        }

                      
                       
                    }
                    if (vString != null)
                    {

                        voting_list.InnerHtml = vString;
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
        

        [System.Web.Services.WebMethod]
        public static string GetEvent(string date1)
        {
            String errMsg;
            EntityDtlsVoting oBMAST = null; byte vKey = 0;
            HttpCookie cookie = HttpContext.Current.Request.Cookies["__asd"];


            if (cookie != null && HttpContext.Current.Session["ID"] != null)
            {
                oBMAST = new EntityDtlsVoting();
                string s = HttpContext.Current.Session["USERID"].ToString();

                oBMAST.USER_KEY = s;
                oBMAST.IMAGE_KEY = date1;
                oBMAST.COMPANY_KEY = 6;
                using (BADtlsVoting oBME = new BADtlsVoting())
                {
                    
                    vKey = oBME.SaveChanges_count("INSERT", oBMAST, errMsg1, "2019", 1);

                }
                return vKey.ToString();
            }

            else
            {
                
                return "0";
            }

        }


    }
}