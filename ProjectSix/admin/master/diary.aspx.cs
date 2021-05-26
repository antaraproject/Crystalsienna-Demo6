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
    public partial class diary : System.Web.UI.Page
    {
        String errMsg = String.Empty;
        DataTable dt = null;
        EntitySysUser oSysUser = null;

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
                        errMsg = DiaryGrid();
                        if (!String.IsNullOrEmpty(errMsg))
                            MessageBox(1, "Diary" + Message.msgErrDdlPop, errMsg);

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
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                errMsg = String.Empty;
                hf_DTLS_DIARY_KEY.Value = "0";
                ClearControl();
                MessageBox(2, "", "");
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
                errMsg = DiaryGrid();
                if (!String.IsNullOrEmpty(errMsg))
                    MessageBox(1, Message.msgErrCommon, errMsg);
            }
            catch (Exception ex)
            {
                MessageBox(1, Message.msgErrCommon, ex.Message);
            }
        }


        private String DiaryGrid()
        {
            try
            {
                errMsg = String.Empty;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                dt = new DataTable();
                using (BADtlsDiary oBMC = new BADtlsDiary())
                {
                    dt = oBMC.Get<Int32>("SRH_KEY", 6, "", ref errMsg, "2019", 1);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }
                gvDtlsDiary.DataSource = dt;
                gvDtlsDiary.DataBind();
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
                hf_DTLS_DIARY_KEY.Value = gvDtlsDiary.DataKeys[gvr.RowIndex].Value.ToString();
                errMsg = FillDiaryEdit(Convert.ToInt32(hf_DTLS_DIARY_KEY.Value));

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
            EntityDtlsDiary oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityDtlsDiary();
                    GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                    oBMAST.DTLS_DIARY_KEY = Convert.ToInt32(gvDtlsDiary.DataKeys[gvr.RowIndex].Values[0].ToString());
                    oBMAST.ENT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.EDIT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.TAG_DELETE = 0;

                    using (BADtlsDiary oBMC = new BADtlsDiary())
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
                                DiaryGrid();
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

        private void ClearControl()
        {
            txt_DIARY_HEADING.Text = "";
            txt_SHORT_DESC.Text = "";
            txt_LONG_DESC.Text = "";
            txt_DIARY_DATE.Text = "";
            img_Gallery.Src = "~/admin/assets/images/no_image.jpg";
            hf_GALLERY_IMG.Value = "";

        }



        private String ProcessImage(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["DIARY"].ToString();
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

                        hf_GALLERY_IMG.Value = Doc_Name;
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

        private String FillDiaryEdit(Int32 pDTLS_DIARY_KEY)
        {
            try
            {
                errMsg = String.Empty;
                dt = new DataTable();
                EntityDtlsDiary oBMAST = new EntityDtlsDiary();
                oBMAST.COMPANY_KEY = 6;
                using (BADtlsDiary oBMG = new BADtlsDiary())
                {
                    dt = oBMG.Get<Int32>("SRH_DTLS", pDTLS_DIARY_KEY, "", ref errMsg, "2019", 1);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_DIARY_HEADING.Text = Convert.ToString(dt.Rows[0]["DIARY_HEADING"]);
                    txt_DIARY_DATE.Text = Convert.ToString(dt.Rows[0]["DIARY_DATE"]);
                    txt_LONG_DESC.Text = Convert.ToString(dt.Rows[0]["LONG_DESC"]);
                   // img_Gallery.Src = "~" + ConfigurationManager.AppSettings["DIARY"].ToString() + Convert.ToString(dt.Rows[0]["DIARY_IMG"]);




                    hf_GALLERY_IMG.Value = Convert.ToString(dt.Rows[0]["DIARY_IMG"]);


                    if (hf_GALLERY_IMG.Value == "")
                    {
                        img_Gallery.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Gallery.Src = "~" + ConfigurationManager.AppSettings["DIARY"].ToString() + Convert.ToString(dt.Rows[0]["DIARY_IMG"]);
                    }


                    txt_SHORT_DESC.Text = Convert.ToString(dt.Rows[0]["SHORT_DESC"]);
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

        protected void btn_Head_Save_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            String LABELS = String.Empty;
            EntityDtlsDiary oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = ProcessImage(ref LABELS, fu_Gallery);
                    if (!String.IsNullOrEmpty(errMsg))
                    {
                        MessageBox(3, errMsg, "");
                        return;
                    }

                    errMsg = String.Empty;
                    oBMAST = new EntityDtlsDiary();
                    oBMAST.DTLS_DIARY_KEY = Convert.ToInt32(hf_DTLS_DIARY_KEY.Value);
                    oBMAST.DIARY_IMG = hf_GALLERY_IMG.Value;
                    oBMAST.DIARY_HEADING = txt_DIARY_HEADING.Text;
                    DateTime dtDiary_Date = Convert.ToDateTime(Request[txt_DIARY_DATE.UniqueID].Trim());
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    oBMAST.DIARY_DATE = Convert.ToDateTime(dtDiary_Date);
                    oBMAST.SHORT_DESC = txt_SHORT_DESC.Text;
                    oBMAST.LONG_DESC = txt_LONG_DESC.Text;
                    oBMAST.COMPANY_KEY = 6;

                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 1;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BADtlsDiary oBMC = new BADtlsDiary())
                    {
                        if (oBMAST.DTLS_DIARY_KEY == 0)
                        {
                            vRef = oBMC.SaveChanges<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                            if (vRef == 1)
                            {
                                ClearControl();
                                MessageBox(2, Message.msgSaveNew, "");
                                //errMsg = DiaryGrid();
                                //hf_DTLS_DIARY_KEY.Value = Convert.ToString(vKey);
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
                                hf_DTLS_DIARY_KEY.Value = Convert.ToString(vKey);
                                FillDiaryEdit(Convert.ToInt32(hf_DTLS_DIARY_KEY.Value));
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

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            try
            {
                hf_DTLS_DIARY_KEY.Value = "0";
                aPageName.InnerText = Message.modName24;
                ClearControl();
                errMsg = DiaryGrid();
                MessageBox(1, "", "");
            }
            catch (Exception ex)
            {
                MessageBox(2, Message.msgErrCommon, ex.Message);
            }
        }


    }
}