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
    public partial class tour : System.Web.UI.Page
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
                        errMsg = FillTourGrid();
                        if (!String.IsNullOrEmpty(errMsg))
                            MessageBox(1, "Tour " + Message.msgErrDdlPop, errMsg);

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
                errMsg = FillTourGrid();
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
                hf_DTLS_TOUR_KEY.Value = "0";
                ClearControl();
                MessageBox(2, "", "");
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }

        private String FillTourGrid()
        {
            try
            {
                errMsg = String.Empty;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                dt = new DataTable();
                using (BADtlsTour oBMC = new BADtlsTour())
                {
                    dt = oBMC.Get<Int32>("SRH_KEY", 6, "", ref errMsg, "2019", 1);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }
                gvDtlsTour.DataSource = dt;
                gvDtlsTour.DataBind();
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
                hf_DTLS_TOUR_KEY.Value = gvDtlsTour.DataKeys[gvr.RowIndex].Value.ToString();
                errMsg = FillTourEdit(Convert.ToInt32(hf_DTLS_TOUR_KEY.Value));

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
            EntityDtlsTour oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityDtlsTour();
                    GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                    oBMAST.DTLS_TOUR_KEY = Convert.ToInt32(gvDtlsTour.DataKeys[gvr.RowIndex].Values[0].ToString());
                    oBMAST.ENT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.EDIT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.TAG_DELETE = 0;

                    using (BADtlsTour oBMC = new BADtlsTour())
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
                                FillTourGrid();
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
            txt_TOUR_PLACE.Text = "";
            txt_START_DATE.Text = "";
            txt_END_DATE.Text = "";
            hf_TOUR_IMG.Value = "";
            img_Tour.Src = "~/admin/assets/images/no_image.jpg";

        }

        private String ProcessImage(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["TOUR"].ToString();
            try
            {
                if (fu_Control.HasFile)
                {
                    ImageAcceptedExtensions = new String[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" };
                    Int32 filecount = Request.Files.Count;
                    Int32 height, width;
                    String DocNames = String.Empty;
                    if (ImageAcceptedExtensions.Contains(Path.GetExtension(fu_Control.PostedFile.FileName).ToLower()))
                    {
                        HttpFileCollection attachments = Request.Files;
                        HttpPostedFile attachment = attachments[0];
                        if (attachment.ContentLength < 2713400)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + Path.GetExtension(attachment.FileName);
                            var image = System.Drawing.Image.FromStream(attachment.InputStream);
                            height = image.Height; width = image.Width;

                            using (var fileStream = File.Create(Server.MapPath(DOC_PATH + Doc_Name)))
                            {
                                attachment.InputStream.Seek(0, SeekOrigin.Begin);
                                attachment.InputStream.CopyTo(fileStream);
                            }
                        }
                        else
                            return "Please maintain allowed document size (100MB maximum).";

                        hf_TOUR_IMG.Value = Doc_Name;
                    }
                    else
                        return "Please maintain allowed document format(.jpg, .jpeg, .png, .bmp, .gif, .webp).";
                }
                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                ImageAcceptedExtensions = null;
            }
        }

        protected void btn_Head_Save_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            String LABELS = String.Empty;
            EntityDtlsTour oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = ProcessImage(ref LABELS, fu_Tour);
                    if (!String.IsNullOrEmpty(errMsg))
                    {
                        MessageBox(3, errMsg, "");
                        return;
                    }
                    errMsg = String.Empty;
                    oBMAST = new EntityDtlsTour();
                    oBMAST.DTLS_TOUR_KEY = Convert.ToInt32(hf_DTLS_TOUR_KEY.Value);

                    oBMAST.TOUR_PLACE = txt_TOUR_PLACE.Text;
                    DateTime dtStart_Date = Convert.ToDateTime(Request[txt_START_DATE.UniqueID].Trim());
                    DateTime dtEnd_Date = Convert.ToDateTime(Request[txt_END_DATE.UniqueID].Trim());
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    oBMAST.START_DATE = Convert.ToDateTime(dtStart_Date);
                    oBMAST.END_DATE = Convert.ToDateTime(dtEnd_Date);
                    oBMAST.TOUR_IMG = hf_TOUR_IMG.Value;
                    oBMAST.COMPANY_KEY = 6;

                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 0;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BADtlsTour oBMC = new BADtlsTour())
                    {
                        if (oBMAST.DTLS_TOUR_KEY == 0)
                        {
                            vRef = oBMC.SaveChanges<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                            if (vRef == 1)
                            {
                                MessageBox(2, Message.msgSaveNew, "");
                                ClearControl();
                                //errMsg = FillTourGrid();
                                //hf_DTLS_TOUR_KEY.Value = Convert.ToString(vKey);
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
                                hf_DTLS_TOUR_KEY.Value = Convert.ToString(vKey);
                                FillTourEdit(Convert.ToInt32(hf_DTLS_TOUR_KEY.Value));
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

        private String FillTourEdit(Int32 pDTLS_TOUR_KEY)
        {
            try
            {
                errMsg = String.Empty;
                EntityDtlsTour oEDT = new EntityDtlsTour();
                oEDT.COMPANY_KEY = 6;
                dt = new DataTable();

                using (BADtlsTour oBMG = new BADtlsTour())
                {
                    dt = oBMG.Get<Int32>("SRH_DTLS", pDTLS_TOUR_KEY, "", ref errMsg, "2019", 1);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_TOUR_PLACE.Text = Convert.ToString(dt.Rows[0]["TOUR_PLACE"]);
                    txt_START_DATE.Text = Convert.ToDateTime(dt.Rows[0]["START_DATE"]).ToString("d");
                    txt_END_DATE.Text = Convert.ToDateTime(dt.Rows[0]["END_DATE"]).ToString("d");
                   // img_Tour.Src = "~" + ConfigurationManager.AppSettings["TOUR"].ToString() + Convert.ToString(dt.Rows[0]["TOUR_IMG"]);
                    hf_TOUR_IMG.Value = Convert.ToString(dt.Rows[0]["TOUR_IMG"]);


                    if (hf_TOUR_IMG.Value == "")
                    {
                        img_Tour.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Tour.Src = "~" + ConfigurationManager.AppSettings["TOUR"].ToString() + Convert.ToString(dt.Rows[0]["TOUR_IMG"]);
                    }
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
                hf_DTLS_TOUR_KEY.Value = "0";
                aPageName.InnerText = Message.modName24;
                ClearControl();
                errMsg = FillTourGrid();
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