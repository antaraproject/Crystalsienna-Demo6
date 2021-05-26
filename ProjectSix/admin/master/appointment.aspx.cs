using App.BAL;
using App.BAL.Master;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using App.CORE.Domain.Setup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProjectSix.admin.master
{
    public partial class appointment : System.Web.UI.Page
    {
        String errMsg = String.Empty;
        DataTable dt = null;
        EntitySysUser oSysUser = null;
        public string UNmae = "";

        #region Main page
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
                        FillAppointmentGrid();
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenTab1", "OpenTab1('" + strMsg + "','" + pTabid + "')", true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenTab2", "OpenTab2('" + strMsg + "','" + pTabid + "')", true);

        }

        #endregion

        #region Page Settings

        private String FillAppointmentGrid()
        {
            try
            {
                errMsg = String.Empty;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                dt = new DataTable();
                using (BADtlsAppointment oBMC = new BADtlsAppointment())
                {
                    dt = oBMC.Get<Int32>("GET_APPOINTMENT", 6, "", ref errMsg, "2019", 1);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }
                gvAppointment.DataSource = dt;
                gvAppointment.DataBind();
                return errMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected void btn_Reject_Click(object sender, EventArgs e)
        {
            Int32 vKey = 0; Byte vRef = 0; String vDelMsg = String.Empty;
            EntityDtlsAppointment oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityDtlsAppointment();
                    GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                    oBMAST.DTLS_APPOINTMENT_KEY = Convert.ToInt32(gvAppointment.DataKeys[gvr.RowIndex].Values[0].ToString());
                    oBMAST.ENT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.EDIT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.TAG_DELETE = 0;
                    oBMAST.COMPANY_KEY = 6;
                    oBMAST.TAG_STATUS = "Rejected";
                    using (BADtlsAppointment oBMC = new BADtlsAppointment())
                    {
                        vRef = oBMC.SaveChanges<Object, Int32>("UPDATE_TAG", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                        if (vRef == 1)
                        {
                            //ClearControl();
                            //DisableControl();
                            MessageBox(2, Message.msgSaveEdit, "");
                            FillAppointmentGrid();
                        }
                        else if (vRef == 2)
                            MessageBox(1, Message.msgSaveDuplicate, errMsg);
                        else
                            MessageBox(1, Message.msgSaveErr, errMsg);
                    }
                }
                else
                    MessageBox(1, Message.msgPageInvalid, "");
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
            finally
            {
                if (oBMAST != null)
                    oBMAST = null;
            }
        }

        protected void btn_Approve_Click(object sender, EventArgs e)
        {
            Int32 vKey = 0; Byte vRef = 0; String vDelMsg = String.Empty;
            EntityDtlsAppointment oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityDtlsAppointment();
                    GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                    oBMAST.DTLS_APPOINTMENT_KEY = Convert.ToInt32(gvAppointment.DataKeys[gvr.RowIndex].Values[0].ToString());
                    oBMAST.ENT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.EDIT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.TAG_DELETE = 0;
                    oBMAST.COMPANY_KEY = 6;
                    oBMAST.TAG_STATUS = "Approved";
                    using (BADtlsAppointment oBMC = new BADtlsAppointment())
                    {
                        vRef = oBMC.SaveChanges<Object, Int32>("UPDATE_TAG", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                        if (vRef == 1)
                        {
                            //ClearControl();
                            //DisableControl();
                            MessageBox(2, Message.msgSaveEdit, "");
                            FillAppointmentGrid();
                        }
                        else if (vRef == 2)
                            MessageBox(1, Message.msgSaveDuplicate, errMsg);
                        else
                            MessageBox(1, Message.msgSaveErr, errMsg);
                    }
                }
                else
                    MessageBox(1, Message.msgPageInvalid, "");
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
            finally
            {
                if (oBMAST != null)
                    oBMAST = null;
            }
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            Int32 vKey = 0; Byte vRef = 0; String vDelMsg = String.Empty, timespan = String.Empty;
            DataTable dt1 = new DataTable();
            EntityDtlsAppointment oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityDtlsAppointment();
                    GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                    oBMAST.DTLS_APPOINTMENT_KEY = Convert.ToInt32(gvAppointment.DataKeys[gvr.RowIndex].Values[0].ToString());
                    string dtlsid = Convert.ToString(oBMAST.DTLS_APPOINTMENT_KEY);
                    errMsg = String.Empty;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    dt = new DataTable();
                    using (BADtlsAppointment oBMC = new BADtlsAppointment())
                    {
                        dt = oBMC.GetData<Int32>("GET_APPOINTMENT_ID", 6, oBMAST.DTLS_APPOINTMENT_KEY, ref errMsg, "2019", 1);
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                        timespan = Convert.ToString(dt.Rows[0]["TIME_SPAN"]);
                    }
                    if (timespan != "")
                    {
                        using (BADtlsAppointment oBMC = new BADtlsAppointment())
                        {
                            dt1 = oBMC.GetSlots<Int32>("GET_TIMESLOT", 6, timespan, ref errMsg, "2019", 1);
                            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                            string JSONresult;
                            JSONresult = JsonConvert.SerializeObject(dt1);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "popup", "popup(" + JSONresult + ")", true);
                        }

                    }
                }
                else
                    MessageBox(1, Message.msgPageInvalid, "");
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
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