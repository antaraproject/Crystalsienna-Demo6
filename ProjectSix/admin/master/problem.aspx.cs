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

namespace Supplychain_cms.admin.master
{
    public partial class problem : System.Web.UI.Page
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
                        errMsg = FillProblemGrid();
                        if (!String.IsNullOrEmpty(errMsg))
                            MessageBox(1, "Mdel " + Message.msgErrDdlPop, errMsg);

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
                errMsg = FillProblemGrid();
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
                hf_DTLS_PROBLEM_KEY.Value = "0";
                ClearControl();
                MessageBox(2, "", "");
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }

        private String FillProblemGrid()
        {
            try
            {
                errMsg = String.Empty;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                dt = new DataTable();
                using (BAProblem oBMC = new BAProblem())
                {
                    dt = oBMC.Get<Int32>("ALL", oSysUser.USER_KEY, "", ref errMsg, "2019", 1);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }
                gvMstProblem.DataSource = dt;
                gvMstProblem.DataBind();
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
                hf_DTLS_PROBLEM_KEY.Value = gvMstProblem.DataKeys[gvr.RowIndex].Value.ToString();
                errMsg = FillProblemEdit(Convert.ToInt32(hf_DTLS_PROBLEM_KEY.Value));
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
            EntityProblem oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityProblem();
                    GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                    oBMAST.DTLS_PROBLEM_KEY = Convert.ToInt32(gvMstProblem.DataKeys[gvr.RowIndex].Values[0].ToString());
                    oBMAST.ENT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.EDIT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.TAG_DELETE = 0;

                    using (BAProblem oBMC = new BAProblem())
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
                                FillProblemGrid();
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

        #region Save
        private void ClearControl()
        {
            txt_PROBLEM_DESC.Text = "";
            txt_PROBLEM_NAME.Text = "";
            hf_DTLS_PROBLEM_KEY.Value = "0";

        }

        protected void btn_Head_Save_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            String MODEL = String.Empty;
            EntityProblem oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityProblem();
                    oBMAST.DTLS_PROBLEM_KEY = Convert.ToInt32(hf_DTLS_PROBLEM_KEY.Value);
                    oBMAST.PROBLEM_NAME = txt_PROBLEM_NAME.Text;
                    oBMAST.PROBLEM_DESC = txt_PROBLEM_DESC.Text;

                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 0;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BAProblem oBMC = new BAProblem())
                    {
                        if (oBMAST.DTLS_PROBLEM_KEY == 0)
                        {
                            vRef = oBMC.SaveChanges<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                            if (vRef == 1)
                            {
                                MessageBox(2, Message.msgSaveNew, "");
                                errMsg = FillProblemGrid();
                                hf_DTLS_PROBLEM_KEY.Value = Convert.ToString(vKey);
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
                                //FillMastCategoryGrid();
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

        private String FillProblemEdit(Int32 pDTLS_PROBLEM_KEY)
        {
            try
            {
                errMsg = String.Empty;
                dt = new DataTable();
                using (BAProblem oBMG = new BAProblem())
                {
                    dt = oBMG.Get<Int32>("SRH_KEY", pDTLS_PROBLEM_KEY, "", ref errMsg, "2019", 1);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_PROBLEM_NAME.Text = Convert.ToString(dt.Rows[0]["PROBLEM_NAME"]);
                    txt_PROBLEM_DESC.Text = Convert.ToString(dt.Rows[0]["PROBLEM_DESC"]);
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
                hf_DTLS_PROBLEM_KEY.Value = "0";
                aPageName.InnerText = Message.modName24;
                ClearControl();
                errMsg = FillProblemGrid();
                MessageBox(1, "", "");
            }
            catch (Exception ex)
            {
                MessageBox(2, Message.msgErrCommon, ex.Message);
            }
        }
        #endregion
    }
}