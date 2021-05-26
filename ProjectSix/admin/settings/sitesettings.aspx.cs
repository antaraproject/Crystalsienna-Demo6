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
    public partial class sitesettings : System.Web.UI.Page
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
                        FillSiteSettingEdit();
                        FillPageSettingGrid();
                        errMsg = FillDdPageName();
                        if (!String.IsNullOrEmpty(errMsg))
                            MessageBox(1, "Page Name" + Message.msgErrDdlPop, errMsg);
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

        private String ProcessLogo(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["HOME"].ToString();
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

                        hf_LOGO_NAME.Value = Doc_Name;
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

        private String ProcessIcon(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["HOME"].ToString();
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

                        hf_ICON_IMG.Value = Doc_Name;
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

        private String ProcessHeaderIMG(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["HOME"].ToString();
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

                        hf_HEADER_IMG.Value = Doc_Name;
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

        private String ProcessFooterIMG(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["HOME"].ToString();
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
                        HttpPostedFile attachment = attachments[3];
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

                        hf_FOOTER_IMG.Value = Doc_Name;
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
            String LOGO_NAME = String.Empty, ICON_IMG = String.Empty, HEADER_IMG = String.Empty, FOOTER_IMG = String.Empty;
            EntitySiteSetting oBMAST = null;
            try
            {
                if (Page.IsValid)
                {

                    errMsg = ProcessLogo(ref LOGO_NAME, fu_Logo);
                    if (String.IsNullOrEmpty(errMsg))
                    {

                        errMsg = ProcessHeaderIMG(ref HEADER_IMG, fu_header);
                        if (String.IsNullOrEmpty(errMsg))
                        {
                            errMsg = ProcessFooterIMG(ref FOOTER_IMG, fu_footer);
                            if (String.IsNullOrEmpty(errMsg))
                            {
                                errMsg = ProcessIcon(ref ICON_IMG, fu_Icon);
                                if (!String.IsNullOrEmpty(errMsg))
                                {

                                    MessageBox(3, errMsg, "");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox(3, errMsg, "");
                        return;
                    }

                    errMsg = String.Empty;
                    oBMAST = new EntitySiteSetting();
                    oBMAST.CONTACT_NO = String.IsNullOrEmpty(txt_CONTACT_NO.Text) ? null : txt_CONTACT_NO.Text.ToString();
                    oBMAST.MAIL = String.IsNullOrEmpty(txt_MAIL.Text) ? null : txt_MAIL.Text.ToString();
                    oBMAST.FACEBOOK_LINK = String.IsNullOrEmpty(txt_FACEBOOK_LINK.Text) ? null : txt_FACEBOOK_LINK.Text.ToString();
                    oBMAST.TWITTER_LINK = String.IsNullOrEmpty(txt_TWITTER_LINK.Text) ? null : txt_TWITTER_LINK.Text.ToString();
                    oBMAST.LINKEDIN_LINK = String.IsNullOrEmpty(txt_LINKEDIN_LINK.Text) ? null : txt_LINKEDIN_LINK.Text.ToString();
                    oBMAST.ADDRESS = txt_ADDRESS.Text;
                    oBMAST.LOGO_NAME = hf_LOGO_NAME.Value;
                    oBMAST.ICON_IMG = hf_ICON_IMG.Value;
                    oBMAST.HEADER_IMG = hf_HEADER_IMG.Value;
                    oBMAST.FOOTER_IMG = hf_FOOTER_IMG.Value;
                    oBMAST.COMPANY_KEY = 6;

                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 0;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BAHeadSiteSetting oBMC = new BAHeadSiteSetting())
                    {
                        vRef = oBMC.SaveChanges<Object, Int32>("", oBMAST, null, ref vKey, ref errMsg, "2019", 6);
                        if (vRef == 1)
                        {
                            MessageBox(2, "Data stored successfully", "");
                            FillSiteSettingEdit();
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

        private String FillSiteSettingEdit()
        {
            try
            {
                String vCOMPANY_ACCESS = String.Empty;
                errMsg = String.Empty;
                dt = new DataTable();
                EntitySiteSetting oESS = new EntitySiteSetting();
                oESS.COMPANY_KEY = 6;
                string companykey = Convert.ToString(oESS.COMPANY_KEY);
                using (BAHeadSiteSetting oBME = new BAHeadSiteSetting())
                {
                    dt = oBME.Get<Int32>("GET", 6, "", ref errMsg, "2019", 1);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_CONTACT_NO.Text = Convert.ToString(dt.Rows[0]["CONTACT_NO"]);
                    txt_MAIL.Text = Convert.ToString(dt.Rows[0]["MAIL"]);
                    txt_ADDRESS.Text = Convert.ToString(dt.Rows[0]["ADDRESS"]);

                    //img_Logo.Src = "~" + ConfigurationManager.AppSettings["HOME"].ToString() + Convert.ToString(dt.Rows[0]["LOGO_NAME"]);



                    hf_LOGO_NAME.Value = Convert.ToString(dt.Rows[0]["LOGO_NAME"]);


                    if (hf_LOGO_NAME.Value == "")
                    {
                        img_Logo.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Logo.Src = "~" + ConfigurationManager.AppSettings["HOME"].ToString() + Convert.ToString(dt.Rows[0]["LOGO_NAME"]);
                    }


                  //  img_Icon.Src = "~" + ConfigurationManager.AppSettings["HOME"].ToString() + Convert.ToString(dt.Rows[0]["ICON_IMG"]);
                    hf_ICON_IMG.Value = Convert.ToString(dt.Rows[0]["ICON_IMG"]);


                    if (hf_ICON_IMG.Value == "")
                    {
                        img_Icon.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Icon.Src = "~" + ConfigurationManager.AppSettings["HOME"].ToString() + Convert.ToString(dt.Rows[0]["ICON_IMG"]);
                    }


                   // img1.Src = "~" + ConfigurationManager.AppSettings["HOME"].ToString() + Convert.ToString(dt.Rows[0]["HEADER_IMG"]);
                    hf_HEADER_IMG.Value = Convert.ToString(dt.Rows[0]["HEADER_IMG"]);



                    if (hf_HEADER_IMG.Value == "")
                    {
                        img1.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img1.Src = "~" + ConfigurationManager.AppSettings["HOME"].ToString() + Convert.ToString(dt.Rows[0]["HEADER_IMG"]);
                    }


                  //  img2.Src = "~" + ConfigurationManager.AppSettings["HOME"].ToString() + Convert.ToString(dt.Rows[0]["FOOTER_IMG"]);
                    hf_FOOTER_IMG.Value = Convert.ToString(dt.Rows[0]["FOOTER_IMG"]);


                    if (hf_FOOTER_IMG.Value == "")
                    {
                        img2.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img2.Src = "~" + ConfigurationManager.AppSettings["HOME"].ToString() + Convert.ToString(dt.Rows[0]["FOOTER_IMG"]);
                    }


                    txt_FACEBOOK_LINK.Text = Convert.ToString(dt.Rows[0]["FACEBOOK_LINK"]);
                    txt_TWITTER_LINK.Text = Convert.ToString(dt.Rows[0]["TWITTER_LINK"]);
                    txt_LINKEDIN_LINK.Text = Convert.ToString(dt.Rows[0]["LINKEDIN_LINK"]);

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
        private String FillDdPageName()
        {
            try
            {
                errMsg = String.Empty;
                using (BAHeadSiteSetting oBMC = new BAHeadSiteSetting())
                {
                    oBMC.BindDdl(ref ddl_MAST_PAGE_KEY, 0, ref errMsg, null, 0);
                    return errMsg;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void ClearPageSetting()
        {
            ddl_MAST_PAGE_KEY.ClearSelection();
            txt_PAGE_TITLE.Text = "";
            txt_META_DESCRIPTION.Text = "";
            txt_META_KEYWORD.Text = "";
            hf_DTLS_PAGE_SETTING_KEY.Value = "0";

        }

        protected void btn_Page_Settings_Save_Click(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            EntitySiteSetting oBMAST = null;
            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntitySiteSetting();
                    oBMAST.DTLS_PAGE_SETTING_KEY = Convert.ToInt32(hf_DTLS_PAGE_SETTING_KEY.Value);
                    oBMAST.MAST_PAGE_KEY = String.IsNullOrEmpty(ddl_MAST_PAGE_KEY.SelectedValue) ? 0 : Convert.ToInt32(ddl_MAST_PAGE_KEY.SelectedValue);
                    oBMAST.PAGE_TITLE = String.IsNullOrEmpty(txt_PAGE_TITLE.Text) ? null : txt_PAGE_TITLE.Text.ToString();
                    oBMAST.META_DESCRIPTION = String.IsNullOrEmpty(txt_META_DESCRIPTION.Text) ? null : txt_META_DESCRIPTION.Text.ToString();
                    oBMAST.META_KEYWORD = String.IsNullOrEmpty(txt_META_KEYWORD.Text) ? null : txt_META_KEYWORD.Text.ToString();

                    oBMAST.COMPANY_KEY = 6;
                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 0;
                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BAHeadSiteSetting oBMC = new BAHeadSiteSetting())
                    {
                        if (oBMAST.DTLS_PAGE_SETTING_KEY == 0)
                        {
                            vRef = oBMC.SavePageSetting<Object, Int32>("INSERT", oBMAST, null, ref vKey, ref errMsg, "2019", 6);
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
                            string company_key = Convert.ToString(oBMAST.COMPANY_KEY);

                            dt = oBMC.GetPageSetting<Int32>("GET_COMPANY_KEY", Convert.ToInt32(company_key), "", ref errMsg, "2019", 1);
                            if (company_key == Convert.ToString(dt.Rows[0]["COMPANY_KEY"]))
                            {
                                vRef = oBMC.SavePageSetting<Object, Int32>("UPDATE", oBMAST, null, ref vKey, ref errMsg, "2019", 6);
                            }
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
                EntitySiteSetting oESS = new EntitySiteSetting();
                oESS.COMPANY_KEY = 6;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                dt = new DataTable();
                using (BAHeadSiteSetting oBMC = new BAHeadSiteSetting())
                {
                    dt = oBMC.GetPageSetting<Int32>("GET", oESS.COMPANY_KEY, "", ref errMsg, "2019", 6);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
                }
                gvPageSetting.DataSource = dt;
                gvPageSetting.DataBind();
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
                hf_DTLS_PAGE_SETTING_KEY.Value = gvPageSetting.DataKeys[gvr.RowIndex].Value.ToString();
                errMsg = FillPageSettingEdit(Convert.ToInt32(hf_DTLS_PAGE_SETTING_KEY.Value));
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

        private String FillPageSettingEdit(Int32 pDTLS_PAGE_SETTING_KEY)
        {
            try
            {
                errMsg = String.Empty;
                EntitySiteSetting oESS = new EntitySiteSetting();
                oESS.COMPANY_KEY = 6;

                dt = new DataTable();
                using (BAHeadSiteSetting oBMG = new BAHeadSiteSetting())
                {
                    dt = oBMG.GetPageSetting<Int32>("SRH_KEY", pDTLS_PAGE_SETTING_KEY, "", ref errMsg, "2019", 6);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_MAST_PAGE_KEY.SelectedIndex = ddl_MAST_PAGE_KEY.Items.IndexOf(ddl_MAST_PAGE_KEY.Items.FindByValue(Convert.ToString(dt.Rows[0]["MAST_PAGE_KEY"])));
                    txt_PAGE_TITLE.Text = Convert.ToString(dt.Rows[0]["PAGE_TITLE"]);
                    txt_META_DESCRIPTION.Text = Convert.ToString(dt.Rows[0]["META_DESCRIPTION"]);
                    txt_META_KEYWORD.Text = Convert.ToString(dt.Rows[0]["META_KEYWORD"]);

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