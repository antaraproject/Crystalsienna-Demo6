using App.BAL;
using App.BAL.Master;
using App.BAL.Utility;
using App.CORE.Domain.Master;
using App.CORE.Domain.Setup;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProjectSix.admin.master
{
    public partial class calender : System.Web.UI.Page
    {
        String errMsg = String.Empty;
        DataTable dt = null;
        EntitySysUser oSysUser = null;


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
                        FillPageSettingGrid();
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

        #endregion

        #region Page Settings
        private void ClearPageSetting()
        {
            txt_DAY_NAME.Text = "";
            txt_END_TIME.Text = "";
            txt_START_TIME.Text = "";
            hf_DTLS_CALENDER_KEY.Value = "0";

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            EntityCalendar oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityCalendar();
                    oBMAST.DTLS_CALENDER_KEY = Convert.ToInt32(hf_DTLS_CALENDER_KEY.Value);
                    oBMAST.DAY_NAME = String.IsNullOrEmpty(txt_DAY_NAME.Text) ? null : txt_DAY_NAME.Text.ToString();
                    oBMAST.START_TIME = String.IsNullOrEmpty(txt_START_TIME.Text) ? null : txt_START_TIME.Text.ToString();
                    oBMAST.END_TIME = String.IsNullOrEmpty(txt_END_TIME.Text) ? null : txt_END_TIME.Text.ToString();
                    oBMAST.COMPANY_KEY = 6;

                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 0;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BACalendar oBMC = new BACalendar())
                    {
                        if (oBMAST.DTLS_CALENDER_KEY == 0)
                        {
                            vRef = oBMC.SaveChanges<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                            if (vRef == 1)
                            {
                                MessageBox(2, Message.msgSaveNew, "");
                                FillPageSettingGrid();
                                ClearPageSetting();
                            }
                            else if (vRef == 2)
                                MessageBox(2, Message.msgSaveDuplicate, errMsg);
                            else
                                MessageBox(2, Message.msgSaveErr, errMsg);
                        }
                        else
                        {
                            
                                vRef = oBMC.SaveChanges<Object, Int32>("UPDATE", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                            
                            if (vRef == 1)
                            {
                                FillPageSettingGrid();
                                ClearPageSetting();
                                MessageBox(1, Message.msgSaveEdit, "");
                            }
                            else if (vRef == 2)
                                MessageBox(1, Message.msgSaveDuplicate, errMsg);
                            else
                                MessageBox(1, Message.msgSaveErr, errMsg);
                        }
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

        private String FillPageSettingGrid()
        {
            try
            {
                errMsg = String.Empty;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                dt = new DataTable();
                using (BACalendar oBMC = new BACalendar())
                {
                    dt = oBMC.Get<Int32>("SRH_KEY",6, "", ref errMsg, "2019", 1);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }
                gvClendar.DataSource = dt;
                gvClendar.DataBind();
                return errMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected void btn_Page_Setting_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                errMsg = String.Empty;
                GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                hf_DTLS_CALENDER_KEY.Value = gvClendar.DataKeys[gvr.RowIndex].Value.ToString();
                errMsg = FillCalendarEdit(Convert.ToInt32(hf_DTLS_CALENDER_KEY.Value));
                if (String.IsNullOrEmpty(errMsg))
                {
                    //aPageName.InnerText = Message.modName21 + "(Edit)";
                    MessageBox(1, "", "");
                }
                else
                    MessageBox(1, Message.msgErrEditPop, errMsg);
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }

        private String FillCalendarEdit(Int32 pDTLS_CALENDER_KEY)
        {
            try
            {
                errMsg = String.Empty;
                dt = new DataTable();
                EntityCalendar oBMAST = new EntityCalendar();
                oBMAST.COMPANY_KEY = 6;
                using (BACalendar oBMG = new BACalendar())
                {
                    dt = oBMG.Get<Int32>("SRH_DTLS", pDTLS_CALENDER_KEY, "", ref errMsg, "2019", 1);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_DAY_NAME.Text = Convert.ToString(dt.Rows[0]["DAY_NAME"]);
                    txt_START_TIME.Text = Convert.ToString(dt.Rows[0]["START_TIME"]);
                    txt_END_TIME.Text = Convert.ToString(dt.Rows[0]["END_TIME"]);

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
        #endregion
    }
}