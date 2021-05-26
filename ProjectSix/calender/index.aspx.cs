using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App.BAL;
using App.BAL.Master;
using App.BAL.Setup;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using App.CORE.Domain.Setup;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Services;


namespace ProjectSix.calender
{
    public partial class index : System.Web.UI.Page
    {
        String errMsg = String.Empty, vString = String.Empty;
        Int32 count = 0;
        DataTable dt = null;
        DataTable dt1 = null;
        DataTable dt3 = null;
        public static String errMsg1 = String.Empty;
        //private DataTable socialEvents;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                //Sidebar Content
                dt = new DataTable();
                dt1 = new DataTable();

                using (BADtlsVoting oBME = new BADtlsVoting())// voting
                {
                    dt = oBME.Get("GET", 6, "", ref errMsg, "2020", 1);
                }

                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt1 = oBME.GetPageSetting("SRH_HEAD_KEY", 66, "", ref errMsg, "2020", 1);
                }
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt3 = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
                }


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('" + ex.Message + "');", true);
            }
        }

        //protected void MyCalender_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
        //{
        //    DataRow[] rows = socialEvents.Select(
        //          String.Format(
        //             "Date >= #{0}# AND Date < #{1}#",
        //             e.Day.Date.ToShortDateString(),
        //             e.Day.Date.AddDays(1).ToShortDateString()
        //          )
        //       );

        //    foreach (DataRow row in rows)
        //    {
        //        System.Web.UI.WebControls.Image image;
        //        image = new System.Web.UI.WebControls.Image();
        //        image.ToolTip = row["Description"].ToString();
        //        e.Cell.BackColor = Color.Wheat;
        //    }
        //}

        //private void BuildSocialEventTable()
        //{

        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da=new SqlDataAdapter();
        //    da.Fill(ds);
        //    socialEvents = ds.Tables[0];
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    vString = String.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        vString += "<div class='grid-item col-md-4 col-sm-6 col-xs-12 margin-30px-bottom xs-text-center wow fadeInUp'><div class='blog-post bg-white inner-match-height'>";
                        vString += "<div class='blog-post-images overflow-hidden position-relative'><a href='#'><img src='" + ResolveClientUrl(".." + ConfigurationManager.AppSettings["VOTING"].ToString() + dt.Rows[i]["VOTING_IMG"]) + "' alt='crystal sienna'>";
                        vString += "<div class='blog-hover-icon'><span class='text-extra-large font-weight-300'>+</span></div></a></div><div class='post-details padding-40px-all sm-padding-20px-all'>";
                        vString += "<span class='text-medium-gray text-uppercase text-extra-small display-inline-block sm-display-block sm-margin-10px-top'>" + dt.Rows[i]["VOTING_DATE"] + "<span>";
                        vString += "<a href='' class='alt-font post-title text-medium text-extra-dark-gray width-100 display-block md-width-100 margin-15px-bottom'>" + dt.Rows[i]["VOTING_HEADING"] + "</a>";
                        vString += "<p>" + dt.Rows[i]["VOTING_DESC"] + "</p><div class='separator-line-horrizontal-full bg-medium-gray margin-20px-tb'></div><div class='author'>";
                        vString += "<a href='" + Page.ResolveClientUrl("~/voting/") + "' class='btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one'>";
                        vString += "Vote Now<i class='fas fa-arrow-right icon-very-small' area-hidden='true'></i></a></div></div></div></div>";
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

                if (dt3.Rows.Count > 0)
                {
                    header_img.Style.Add("background-image", ConfigurationManager.AppSettings["HOME"] + dt3.Rows[0]["HEADER_IMG"]);
                }

                //Page.ClientScript.RegisterStartupScript(GetType(), "err", "my_fun();", true);
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


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            EntityDtlsAppointment oBMAST = null;
            HttpCookie cookie = HttpContext.Current.Request.Cookies["__asd"];

            try
            {
                if (cookie != null && HttpContext.Current.Session["ID"] != null)
                {
                    errMsg = String.Empty;

                    oBMAST = new EntityDtlsAppointment();


                    oBMAST.TIME_SPAN = hf_checkbox.Value;
                    oBMAST.PRICE = Convert.ToDouble(hf_price.Value);
                    oBMAST.EVENT_DATE = hf_date.Value;
                    oBMAST.EVENT_DAY = hf_day.Value;
                    oBMAST.DESCRIPTION = txt_desc.Value;
                    oBMAST.TAG_STATUS = "0";
                    oBMAST.TAG_DELETE = 0;
                    oBMAST.COMPANY_KEY = 6;
                    oBMAST.ENT_USER_KEY = Convert.ToInt32(Session["USERID"]);
                    oBMAST.USER_EMAIL = Convert.ToString(Session["useremail"]);

                    using (BADtlsAppointment oBMC = new BADtlsAppointment())
                    {
                        vRef = oBMC.SaveChanges<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 1);

                        if (vRef == 1)
                        {
                            //MessageBox(2, Message.msgSaveNew, "");
                            ClientScript.RegisterStartupScript(GetType(), "popup", "popup();", true);
                            //Response.Redirect("/index.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();

                        }
                        else if (vRef == 2)
                            //MessageBox(2, Message.msgSaveDuplicate, errMsg);
                            ClientScript.RegisterStartupScript(GetType(), "popupduplicatedata", "popupduplicatedata();", true);
                        else
                            // MessageBox(2, Message.msgSaveErr, errMsg);
                            //Response.Write("<script>alert('Data Already Exits')</script>");
                            ClientScript.RegisterStartupScript(GetType(), "popupduplicatedata", "popupduplicatedata();", true);
                    }
                }
                else
                {
                    Response.Redirect("/user/login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                //MessageBox(2, Message.msgErrCommon, ex.Message);
            }
            finally
            {
                if (oBMAST != null)
                    oBMAST = null;
            }
        }

        [System.Web.Services.WebMethod]

        public static string GetEvent(string date1)
        {

            DataTable getevent1 = new DataTable();
            DataTable getprice = new DataTable();
            int datenum = Convert.ToInt32(date1);
            String errMsg1 = String.Empty;
            List<EntityBookingTime> entbook = new List<EntityBookingTime>();
            EntityBookingTime eBKT = new EntityBookingTime();

            string json = "";
            if (date1 == "Date")
            {
                date1 = DateTime.UtcNow.ToLongDateString();
            }
            else
            {
                using (BABookingTime oBME = new BABookingTime())
                {
                    getevent1 = oBME.GetDay("GET_BY_DAY", 6, datenum, ref errMsg1, "2020", 9);
                    if (getevent1.Rows.Count > 0)
                    {
                        foreach (DataRow row in getevent1.Rows)//or similar
                        {
                            EntityBookingTime book = new EntityBookingTime();
                            book.DTLS_TIMETABLE_KEY = Convert.ToInt32(row["DTLS_TIMETABLE_KEY"]);
                            book.START_TIME = Convert.ToString(row["START_TIME"]);
                            book.END_TIME = Convert.ToString(row["END_TIME"]);
                            book.PRICE = Convert.ToDouble(row["PRICE"]);
                            entbook.Add(book);
                        }
                        json = JsonConvert.SerializeObject(entbook);
                    }

                }

            }
            return json;
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