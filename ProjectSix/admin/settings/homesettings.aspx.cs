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

namespace ProjectSix.admin.settings
{
    public partial class homesettings : System.Web.UI.Page
    {
        String errMsg = String.Empty;
        String DOCPATH = "~" + ConfigurationManager.AppSettings["BANNER"].ToString();
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
                        FillHomeSettingEdit();
                        FillQuickFactGrid();
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

        private String ProcessOffer(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BANNER"].ToString();
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
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-O" + Path.GetExtension(attachment.FileName);
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

                        hf_OFFER_IMG.Value = Doc_Name;
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

        private String ProcessAbout(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BANNER"].ToString();
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
                        HttpPostedFile attachment = attachments[1];
                        if (attachment.ContentLength < 2713400)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-A" + Path.GetExtension(attachment.FileName);
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

                        hf_ABOUT_IMG.Value = Doc_Name;
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

        private String ProcessQuickFact(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BANNER"].ToString();
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
                        HttpPostedFile attachment = attachments[2];
                        if (attachment.ContentLength < 2713400)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-Q" + Path.GetExtension(attachment.FileName);
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

                        hf_QUICK_FACT_IMG.Value = Doc_Name;
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

        private String ProcessBanner(ref String DOCUMENT_NAME, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            try
            {
                if (fu_Control.HasFile)
                {
                    ImageAcceptedExtensions = new String[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" };
                    String DOCUMENT_PATH = "~" + ConfigurationManager.AppSettings["BANNER"].ToString();
                    //Int32 filecount = Convert.ToInt32(fu_Model_Multi.FileContent); //Request.Files.Count;
                    String DocNames = String.Empty;
                    if (ImageAcceptedExtensions.Contains(Path.GetExtension(fu_Control.PostedFile.FileName).ToLower()))
                    {
                        if (!System.IO.Directory.Exists(Server.MapPath(DOCUMENT_PATH)))
                            System.IO.Directory.CreateDirectory(Server.MapPath(DOCUMENT_PATH));
                        HttpFileCollection attachments = Request.Files;
                        int no = attachments.Count;
                        for (int i = 3; i < attachments.Count; i++)
                        {
                            HttpPostedFile attachment = attachments[i];
                            if (attachment.ContentLength < 104857600 && attachment.ContentLength > 0)
                            {
                                DocNames = System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + "_" + (i + 1) + Path.GetExtension(attachment.FileName);

                                using (var fileStream = File.Create(Server.MapPath(DOCUMENT_PATH + DocNames)))
                                {
                                    attachment.InputStream.Seek(0, SeekOrigin.Begin);
                                    attachment.InputStream.CopyTo(fileStream);
                                }

                                DOCUMENT_NAME += DocNames + "|";
                            }
                            else if (attachment.ContentLength <= 0)
                            {
                                DOCUMENT_NAME = "";
                            }
                            else
                                return "Please maintain allowed document size (100MB maximum).";
                        }
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
            String BANNER_IMG = String.Empty, OFFER_IMG = String.Empty, ABOUT_IMG = String.Empty, QUICK_FACT_IMG = String.Empty;
            EntityHomeSetting oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = ProcessBanner(ref BANNER_IMG, fu_Banner);
                    hf_BANNER_IMG.Value += BANNER_IMG;
                    if (String.IsNullOrEmpty(errMsg))
                    {
                        errMsg = ProcessOffer(ref OFFER_IMG, fu_Offer);
                        if (String.IsNullOrEmpty(errMsg))
                        {
                            errMsg = ProcessAbout(ref ABOUT_IMG, fu_About);
                            if (String.IsNullOrEmpty(errMsg))
                            {
                                errMsg = ProcessQuickFact(ref QUICK_FACT_IMG, fu_Quick_Fact);
                                if (!String.IsNullOrEmpty(errMsg))
                                {
                                    MessageBox(1, errMsg, "");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox(1, errMsg, "");
                        return;
                    }
                    errMsg = String.Empty;
                    oBMAST = new EntityHomeSetting();
                    oBMAST.ABOUT_DESC = String.IsNullOrEmpty(txt_ABOUT_DESC.Text) ? null : txt_ABOUT_DESC.Text.ToString();
                    oBMAST.BANNER_IMG = hf_BANNER_IMG.Value;
                    oBMAST.OFFER_IMG = hf_OFFER_IMG.Value;
                    oBMAST.ABOUT_IMG = hf_ABOUT_IMG.Value;
                    oBMAST.QUICK_FACT_IMG = hf_QUICK_FACT_IMG.Value;
                    oBMAST.COMPANY_KEY = 6;

                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 0;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BAHomeSettings oBMC = new BAHomeSettings())
                    {
                        vRef = oBMC.SaveChanges<Object, Int32>("", oBMAST, null, ref vKey, ref errMsg, "2019", 6);
                        if (vRef == 1)
                        {
                            MessageBox(2, "Data stored successfully", "");
                            FillHomeSettingEdit();
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

        private String FillHomeSettingEdit()
        {
            try
            {
                String vCOMPANY_ACCESS = String.Empty;
                errMsg = String.Empty;
                EntityHomeSetting oEHS = new EntityHomeSetting();
                oEHS.COMPANY_KEY = 6;
                dt = new DataTable();
                using (BAHomeSettings oBME = new BAHomeSettings())
                {
                    dt = oBME.Get("ALL", oEHS.COMPANY_KEY, "", ref errMsg, null, 1);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_ABOUT_DESC.Text = Convert.ToString(dt.Rows[0]["ABOUT_DESC"]);
                    //img_Offer.Src = "~" + ConfigurationManager.AppSettings["BANNER"].ToString() + Convert.ToString(dt.Rows[0]["OFFER_IMG"]);
                    //img_About.Src = "~" + ConfigurationManager.AppSettings["BANNER"].ToString() + Convert.ToString(dt.Rows[0]["ABOUT_IMG"]);
                    //img_Quick_Facts.Src = "~" + ConfigurationManager.AppSettings["BANNER"].ToString() + Convert.ToString(dt.Rows[0]["QUICK_FACT_IMG"]);


                    hf_OFFER_IMG.Value = Convert.ToString(dt.Rows[0]["OFFER_IMG"]);


                    if (hf_OFFER_IMG.Value == "")
                    {
                        img_Offer.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Offer.Src = "~" + ConfigurationManager.AppSettings["BANNER"].ToString() + Convert.ToString(dt.Rows[0]["OFFER_IMG"]);
                    }


                    hf_ABOUT_IMG.Value = Convert.ToString(dt.Rows[0]["ABOUT_IMG"]);



                    if (hf_ABOUT_IMG.Value == "")
                    {
                        img_About.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_About.Src = "~" + ConfigurationManager.AppSettings["BANNER"].ToString() + Convert.ToString(dt.Rows[0]["ABOUT_IMG"]);
                    }

                    hf_QUICK_FACT_IMG.Value = Convert.ToString(dt.Rows[0]["QUICK_FACT_IMG"]);



                    if (hf_QUICK_FACT_IMG.Value == "")
                    {
                        img_Quick_Facts.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Quick_Facts.Src = "~" + ConfigurationManager.AppSettings["BANNER"].ToString() + Convert.ToString(dt.Rows[0]["QUICK_FACT_IMG"]);
                    }

                    String[] ImgPaths = Convert.ToString(dt.Rows[0]["BANNER_IMG"]).Split('|');
                    foreach (String Image in ImgPaths)
                    {
                        if (Image.Length > 0)
                        {
                            HtmlGenericControl img = new HtmlGenericControl("img");
                            img.Attributes.Add("class", "modal-content");
                            img.Attributes.Add("src", DOCPATH == "" ? "" : DOCPATH.Substring(1) + Image);
                            myModal.Controls.Add(img);

                        }
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
        #endregion

        #region Page Settings

        private void ClearPageSetting()
        {
            txt_QUICK_FACT_NAME.Text = "";
            txt_QUICK_FACT.Text = "";
            hf_DTLS_QUICK_FACT_KEY.Value = "0";

        }

        protected void btn_Quick_Save_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            EntityHomeSetting oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityHomeSetting();
                    oBMAST.DTLS_QUICK_FACT_KEY = Convert.ToInt32(hf_DTLS_QUICK_FACT_KEY.Value);
                    oBMAST.QUICK_FACT_NAME = String.IsNullOrEmpty(txt_QUICK_FACT_NAME.Text) ? null : txt_QUICK_FACT_NAME.Text.ToString();
                    oBMAST.COMPANY_KEY = 6;

                    oBMAST.QUICK_FACT = String.IsNullOrEmpty(txt_QUICK_FACT.Text) ? null : txt_QUICK_FACT.Text.ToString();
                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 0;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BAHomeSettings oBMC = new BAHomeSettings())
                    {
                        if (oBMAST.DTLS_QUICK_FACT_KEY == 0)
                        {
                            vRef = oBMC.SaveQuickFact<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 6);
                            if (vRef == 1)
                            {
                                MessageBox(2, Message.msgSaveNew, "");
                                FillQuickFactGrid();
                                ClearPageSetting();
                            }
                            else if (vRef == 2)
                                MessageBox(2, Message.msgSaveDuplicate, errMsg);
                            else
                                MessageBox(2, Message.msgSaveErr, errMsg);
                        }
                        else
                        {
                            string company_key = Convert.ToString(oBMAST.COMPANY_KEY);
                            dt = oBMC.GetQuickFact<Int32>("GET_FACT_COMPANY_KEY", Convert.ToInt32(company_key), "", ref errMsg, "2019", 6);
                            if (company_key == Convert.ToString(dt.Rows[0]["COMPANY_KEY"]))
                            {
                                vRef = oBMC.SaveQuickFact<Object, Int32>("UPDATE", oBMAST, null, ref vKey, ref errMsg, "2019", 6);
                            }
                            if (vRef == 1)
                            {
                                FillQuickFactGrid();
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

        private String FillQuickFactGrid()
        {
            try
            {
                errMsg = String.Empty;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                EntityHomeSetting oEHS = new EntityHomeSetting();
                oEHS.COMPANY_KEY = 6;
                dt = new DataTable();
                using (BAHomeSettings oBMC = new BAHomeSettings())
                {
                    dt = oBMC.GetQuickFact<Int32>("GET", oEHS.COMPANY_KEY, "", ref errMsg, "2019", 1);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }
                gvDtlsQuickFact.DataSource = dt;
                gvDtlsQuickFact.DataBind();
                return errMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected void btn_Quick_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                errMsg = String.Empty;
                GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                hf_DTLS_QUICK_FACT_KEY.Value = gvDtlsQuickFact.DataKeys[gvr.RowIndex].Value.ToString();
                errMsg = FillQuickEdit(Convert.ToInt32(hf_DTLS_QUICK_FACT_KEY.Value));
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

        private String FillQuickEdit(Int32 pDTLS_QUICK_FACT_KEY)
        {
            try
            {
                errMsg = String.Empty;
                EntityHomeSetting oEHS = new EntityHomeSetting();
                oEHS.COMPANY_KEY = 6;
                dt = new DataTable();
                using (BAHomeSettings oBMG = new BAHomeSettings())
                {
                    dt = oBMG.GetQuickFact<Int32>("SRH_KEY", oEHS.COMPANY_KEY, Convert.ToString(pDTLS_QUICK_FACT_KEY), ref errMsg, "2019", 6);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_QUICK_FACT_NAME.Text = Convert.ToString(dt.Rows[0]["QUICK_FACT_NAME"]);
                    txt_QUICK_FACT.Text = Convert.ToString(dt.Rows[0]["QUICK_FACT_DESC"]);
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

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            Int32 vKey = 0; Byte vRef = 0; String vDelMsg = String.Empty;
            EntityHomeSetting oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntityHomeSetting();
                    GridViewRow gvr = (GridViewRow)((HtmlAnchor)sender).NamingContainer;
                    oBMAST.DTLS_QUICK_FACT_KEY = Convert.ToInt32(gvDtlsQuickFact.DataKeys[gvr.RowIndex].Values[0].ToString());
                    oBMAST.ENT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.EDIT_USER_KEY = Convert.ToInt16(oSysUser.USER_KEY);
                    oBMAST.TAG_DELETE = 0;

                    using (BAHomeSettings oBMC = new BAHomeSettings())
                    {
                        vRef = oBMC.SaveDelete<Object, Int32>("DELETE", oBMAST, null, ref vKey, ref errMsg, ref vDelMsg, "2019", 6);
                        if (vRef > 0)
                        {
                            if (vRef == 2)
                            {
                                MessageBox(1, "Data exists  Master", errMsg);
                            }
                            else if (vRef == 1)
                            {
                                MessageBox(1, Message.msgSaveDelete, "");
                                FillQuickFactGrid();
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
    }
}