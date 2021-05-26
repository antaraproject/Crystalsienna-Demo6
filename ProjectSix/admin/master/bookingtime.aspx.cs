using App.BAL;
using App.BAL.Master;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using App.CORE.Domain.Setup;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProjectSix.admin.master
{
    public partial class bookingtime : System.Web.UI.Page
    {
        String errMsg = String.Empty;
        DataTable dt = null;
        EntitySysUser oSysUser = null;
        #region Main Grid
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["oSysUser"] != null)
                {
                    oSysUser = (EntitySysUser)Session["oSysUser"];
                    if (!IsPostBack)
                    {
                        oSysUser.TAG_PAGE_REFRESH = Server.UrlEncode(System.DateTime.Now.ToString());
                        errMsg = String.Empty;
                        if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "1")
                        {
                            // btn_Add_New_Click(null, null);
                        }
                        errMsg = FillBookingGrid();
                        if (!String.IsNullOrEmpty(errMsg))
                            MessageBox(1, "News " + Message.msgErrDdlPop, errMsg);

                    }
                }
                else
                {
                    if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "1")
                    {
                        Response.Write("<script>window.close();</" + "script>");
                        Response.End();
                    }
                    else
                    {
                        Response.Redirect("../index.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }

        private void MessageBox(Int16 pTabid, String strMsg, String exMsg)
        {
            string pType = strMsg == "print" ? "1" : "0";
            if (!(String.IsNullOrEmpty(exMsg)))
                exMsg = CommonOp.ModifyExceptionMessage(exMsg);
            if (pTabid == 1)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenTab1", "OpenTab1('" + strMsg + "')", true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenTab2", "OpenTab2('" + strMsg + "')", true);
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                errMsg = String.Empty;
                //errMsg = SearchData(txt_SEARCH_DATE.Text.Trim());
                if (!String.IsNullOrEmpty(errMsg))
                    MessageBox(1, Message.msgErrCommon, errMsg);
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }

        protected void btn_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                errMsg = String.Empty;
                errMsg = FillBookingGrid();
                if (!String.IsNullOrEmpty(errMsg))
                    MessageBox(1, Message.msgErrCommon, errMsg);
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                errMsg = String.Empty;
                hf_DTLS_TIMETABLE_KEY.Value = "0";
                //ClearControl();
                MessageBox(2, "", "");
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }

        private String FillBookingGrid()
        {
            try
            {
                errMsg = String.Empty;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                dt = new DataTable();
                using (BABookingTime oBMC = new BABookingTime())
                {
                    dt = oBMC.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }
                gvDtlsBooking.DataSource = dt;
                gvDtlsBooking.DataBind();
                MessageBox(1, "", "");
                return errMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                errMsg = String.Empty;
                GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                hf_DTLS_TIMETABLE_KEY.Value = gvDtlsBooking.DataKeys[gvr.RowIndex].Value.ToString();
                errMsg = FillBookingEdit(Convert.ToInt32(hf_DTLS_TIMETABLE_KEY.Value));

                if (String.IsNullOrEmpty(errMsg))
                {
                    aPageName.InnerText = Message.modName21 + "(Edit)";
                    MessageBox(2, "", "");
                }
                else
                    MessageBox(1, Message.msgErrEditPop, errMsg);
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            Int32 vKey = 0; Byte vRef = 0; String vDelMsg = String.Empty;
            EntityBookingTime oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityBookingTime();
                    GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                    oBMAST.DTLS_TIMETABLE_KEY = Convert.ToInt32(gvDtlsBooking.DataKeys[gvr.RowIndex].Values[0].ToString());
                    oBMAST.ENT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.EDIT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.TAG_DELETE = 0;

                    using (BABookingTime oBMC = new BABookingTime())
                    {
                        vRef = oBMC.SaveDelete<Object, Int32>("DELETE", oBMAST, null, ref vKey, ref errMsg, ref vDelMsg, "2019", 1);
                        if (vRef > 0)
                        {
                            if (vRef == 2)
                            {
                                MessageBox(1, "Data exists in Model Master", errMsg);
                            }
                            else if (vRef == 1)
                            {
                                MessageBox(1, Message.msgSaveDelete, "");
                                FillBookingGrid();
                            }
                            else
                                MessageBox(2, Message.msgSaveErr, errMsg);
                        }
                    }
                }
                else
                    MessageBox(2, Message.msgPageInvalid, "");
            }
            catch (Exception ex)
            {
                MessageBox(2, Message.msgErrCommon, ex.Message);
            }
            finally
            {
                if (oBMAST != null)
                    oBMAST = null;
            }
        }

        #endregion
        #region save
        public void ClearControl()
        {
            ddl_EVENT_DAY.Text = "";
            txt_START_TIME.Text = "";
            txt_END_TIME.Text = "";
            txt_PRICE.Text = "";

        }
        protected void btn_Head_Save_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            String LABELS = String.Empty;
            EntityBookingTime oBMAST = null;
            try
            {
                if (Page.IsValid)
                {

                    errMsg = String.Empty;
                    oBMAST = new EntityBookingTime();
                    oBMAST.DTLS_TIMETABLE_KEY = Convert.ToInt32(hf_DTLS_TIMETABLE_KEY.Value);

                    oBMAST.EVENT_DAY = ddl_EVENT_DAY.SelectedValue;
                    oBMAST.AVAILABLE_STATUS = "Available";

                    oBMAST.PRICE = Convert.ToDouble(txt_PRICE.Text);
                    //String dtStart_date = Convert.ToString(Request[txt_START_TIME.UniqueID].Trim());
                    //String dtEnd_date = Convert.ToString(Request[txt_END_TIME.UniqueID].Trim());
                    String dtStart_date = Convert.ToString(txt_START_TIME.Text);
                    String dtEnd_date = Convert.ToString(txt_END_TIME.Text);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    oBMAST.START_TIME = Convert.ToString(dtStart_date);
                    oBMAST.END_TIME = Convert.ToString(dtEnd_date);

                    oBMAST.COMPANY_KEY = 6;

                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 1;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BABookingTime oBMC = new BABookingTime())
                    {
                        if (oBMAST.DTLS_TIMETABLE_KEY == 0)
                        {
                            vRef = oBMC.SaveChanges<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                            if (vRef == 1)
                            {
                                MessageBox(2, Message.msgSaveNew, "");
                                ClearControl();
                                //errMsg = FillNewsGrid();
                                //hf_DTLS_TIMETABLE_KEY.Value = Convert.ToString(vKey);
                            }
                            else if (vRef == 2)
                                MessageBox(2, Message.msgValidation, errMsg);
                            else
                                MessageBox(2, Message.msgSaveErr, errMsg);
                        }
                        else
                        {

                            vRef = oBMC.SaveChanges<Object, Int32>("UPDATE", oBMAST, null, ref vKey, ref errMsg, "2019", 1);

                            if (vRef == 1)
                            {
                                //ClearControl();
                                //DisableControl();
                                MessageBox(2, Message.msgSaveEdit, "");
                                hf_DTLS_TIMETABLE_KEY.Value = Convert.ToString(vKey);
                                FillBookingEdit(Convert.ToInt32(hf_DTLS_TIMETABLE_KEY.Value));
                                //FillMastActivityGrid();
                            }
                            else if (vRef == 2)
                                MessageBox(2, Message.msgSaveDuplicate, errMsg);
                            else
                                MessageBox(2, Message.msgSaveErr, errMsg);
                        }
                    }
                    oSysUser.TAG_PAGE_REFRESH = Server.UrlEncode(System.DateTime.Now.ToString());
                }
                else
                    MessageBox(2, Message.msgPageInvalid, "");
            }
            catch (Exception ex)
            {
                MessageBox(2, Message.msgErrCommon, ex.Message);
            }
            finally
            {
                if (oBMAST != null)
                    oBMAST = null;
            }
        }

        private String FillBookingEdit(Int32 pMAST_PRODUCT_LABELS_KEY)
        {
            try
            {
                errMsg = String.Empty;
                dt = new DataTable();
                EntityBookingTime oBMAST = new EntityBookingTime();
                oBMAST.COMPANY_KEY = 6;
                using (BABookingTime oBMG = new BABookingTime())
                {
                    dt = oBMG.Get<Int32>("SRH_DTLS", pMAST_PRODUCT_LABELS_KEY, "", ref errMsg, "2019", 1);

                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_EVENT_DAY.Text = Convert.ToString(dt.Rows[0]["EVENT_DAY"]);
                    txt_START_TIME.Text = Convert.ToString(dt.Rows[0]["START_TIME"]);
                    txt_END_TIME.Text = Convert.ToString(dt.Rows[0]["END_TIME"]);
                    txt_PRICE.Text = Convert.ToString(dt.Rows[0]["PRICE"]);

                }
                return errMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                dt = null;
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            try
            {
                hf_DTLS_TIMETABLE_KEY.Value = "0";
                aPageName.InnerText = Message.modName24;
                ClearControl();
                errMsg = FillBookingGrid();
                MessageBox(1, "", "");
            }
            catch (Exception ex)
            {
                MessageBox(2, Message.msgErrCommon, ex.Message);
            }
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            String LABELS = String.Empty;
            EntityBookingTime oBMAST = null;

            //gridview datakey bind in checkbox id
            CheckBox chk = (CheckBox)sender;
            GridViewRow gvr = (GridViewRow)chk.NamingContainer;
            string id = gvDtlsBooking.DataKeys[gvr.RowIndex].Value.ToString();

            int key = Convert.ToInt32(id);

            try
            {
                DataTable dt10 = new DataTable();
                using (BABookingTime oBMC = new BABookingTime())
                {
                    dt10 = oBMC.GetDay("GET_BY_KEY",6, key, ref errMsg, "2021", 1);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }

                errMsg = String.Empty;
                oBMAST = new EntityBookingTime();
                oBMAST.DTLS_TIMETABLE_KEY = Convert.ToInt32(dt10.Rows[0]["DTLS_TIMETABLE_KEY"]);
                oBMAST.AVAILABLE_STATUS = Convert.ToString(dt10.Rows[0]["AVAILABLE_STATUS"]);
                oBMAST.EVENT_DAY = Convert.ToString(dt10.Rows[0]["EVENT_DAY"]);


                oBMAST.PRICE = Convert.ToDouble(dt10.Rows[0]["PRICE"]);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                oBMAST.START_TIME = Convert.ToString(dt10.Rows[0]["START_TIME"]);
                oBMAST.END_TIME = Convert.ToString(dt10.Rows[0]["END_TIME"]);

                oBMAST.COMPANY_KEY = 6;

                oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                oBMAST.TAG_ACTIVE = 1;
                oBMAST.TAG_DELETE = 0;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                using (BABookingTime oBMC = new BABookingTime())
                {
                    if (oBMAST.AVAILABLE_STATUS == "Available")
                    {
                        oBMAST.AVAILABLE_STATUS = "Not Available";
                        vRef = oBMC.SaveChanges<Object, Int32>("UPDATE_STATUS", oBMAST, null, ref vKey, ref errMsg, "2019", 1);

                        if (vRef == 1)
                        {
                            MessageBox(2, Message.msgSaveEdit, "");
                            FillBookingGrid();
                        }
                        else if (vRef == 2)
                            MessageBox(2, Message.msgSaveDuplicate, errMsg);
                        else
                            MessageBox(2, Message.msgSaveErr, errMsg);
                    }
                    else if (oBMAST.AVAILABLE_STATUS == "Not Available")
                    {
                        oBMAST.AVAILABLE_STATUS = "Available";
                        vRef = oBMC.SaveChanges<Object, Int32>("UPDATE_STATUS", oBMAST, null, ref vKey, ref errMsg, "2019", 1);

                        if (vRef == 1)
                        {
                            MessageBox(2, Message.msgSaveEdit, "");
                            FillBookingGrid();
                        }
                        else if (vRef == 2)
                            MessageBox(2, Message.msgSaveDuplicate, errMsg);
                        else
                            MessageBox(2, Message.msgSaveErr, errMsg);
                    }
                }
                oSysUser.TAG_PAGE_REFRESH = Server.UrlEncode(System.DateTime.Now.ToString());


            }
            catch (Exception ex)
            {
                MessageBox(2, Message.msgErrCommon, ex.Message);
            }
            finally
            {
                if (oBMAST != null)
                    oBMAST = null;
            }
        }
        #endregion
    }

}