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

namespace ProjectFive.admin.settings
{
    public partial class bgimgsetting : System.Web.UI.Page
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
                        FillBackgroundImageSettingEdit();
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

        private String ProcessAbout(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        if (attachment.ContentLength < 20097134)
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

        private String ProcessTour(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-B" + Path.GetExtension(attachment.FileName);
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

        private String ProcessQuickFact(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-C" + Path.GetExtension(attachment.FileName);
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

        private String ProcessPrefer(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-D" + Path.GetExtension(attachment.FileName);
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

                        hf_PREFER_IMG.Value = Doc_Name;
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

        private String ProcessGallery(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[4];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-E" + Path.GetExtension(attachment.FileName);
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

        private String ProcessOffer(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[5];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-F" + Path.GetExtension(attachment.FileName);
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

        private String ProcessDiary(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[6];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-G" + Path.GetExtension(attachment.FileName);
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

                        hf_DIARY_IMG.Value = Doc_Name;
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

        private String ProcessTestimonials(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[7];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-H" + Path.GetExtension(attachment.FileName);
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

                        hf_TESTIMONIALS_IMG.Value = Doc_Name;
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

        private String ProcessSelfie(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[8];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-I" + Path.GetExtension(attachment.FileName);
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

                        hf_SELFIE_IMG.Value = Doc_Name;
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

        private String ProcessNews(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[9];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-J" + Path.GetExtension(attachment.FileName);
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

                        hf_NEWS_IMG.Value = Doc_Name;
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

        private String ProcessRates(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[10];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-K" + Path.GetExtension(attachment.FileName);
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

                        hf_RATES_IMG.Value = Doc_Name;
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

        private String ProcessAvailability(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[11];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-L" + Path.GetExtension(attachment.FileName);
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

                        hf_AVAILABILITY_IMG.Value = Doc_Name;
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

        private String ProcessCalender(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[12];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-M" + Path.GetExtension(attachment.FileName);
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

                        hf_CALENDER_IMG.Value = Doc_Name;
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

        private String ProcessVoting(ref String Doc_Name, FileUpload fu_Control)
        {
            String[] ImageAcceptedExtensions = null;
            String DOC_PATH = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString();
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
                        HttpPostedFile attachment = attachments[13];
                        if (attachment.ContentLength < 20097134)
                        {
                            Doc_Name = System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + "-N" + Path.GetExtension(attachment.FileName);
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

                        hf_VOTING_IMG.Value = Doc_Name;
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
            String ABOUT_IMG = String.Empty, TOUR_IMG = String.Empty, QUICK_FACT_IMG = String.Empty, PREFER_IMG = String.Empty, GALLERY_IMG = String.Empty,
            OFFER_IMG = String.Empty, DIARY_IMG = String.Empty, TESTIMONIALS_IMG = String.Empty, SELFIE_IMG = String.Empty, NEWS_IMG = String.Empty, RATES_IMG = String.Empty,
            AVAILABILITY_IMG = String.Empty, CALENDER_IMG = String.Empty, VOTING_IMG = String.Empty;
            EntityHeadHomeBgSetting oBMAST = null;
            try
            {
                if (Page.IsValid)
                {


                    errMsg = ProcessAbout(ref ABOUT_IMG, fu_About);
                    if (String.IsNullOrEmpty(errMsg))
                    {
                        errMsg = ProcessTour(ref TOUR_IMG, fu_Tour);
                        if (String.IsNullOrEmpty(errMsg))
                        {
                            errMsg = ProcessQuickFact(ref QUICK_FACT_IMG, fu_Quick_Fact);
                            if (String.IsNullOrEmpty(errMsg))
                            {
                                errMsg = ProcessPrefer(ref PREFER_IMG, fu_Prefer);
                                if (String.IsNullOrEmpty(errMsg))
                                {
                                    errMsg = ProcessGallery(ref GALLERY_IMG, fu_Gallery);
                                    if (String.IsNullOrEmpty(errMsg))
                                    {
                                        errMsg = ProcessOffer(ref OFFER_IMG, fu_Offer);
                                        if (String.IsNullOrEmpty(errMsg))
                                        {
                                            errMsg = ProcessDiary(ref DIARY_IMG, fu_Diary);
                                            if (String.IsNullOrEmpty(errMsg))
                                            {
                                                errMsg = ProcessTestimonials(ref TESTIMONIALS_IMG, fu_Testimonials);
                                                if (String.IsNullOrEmpty(errMsg))
                                                {
                                                    errMsg = ProcessSelfie(ref SELFIE_IMG, fu_Selfie);
                                                    if (String.IsNullOrEmpty(errMsg))
                                                    {
                                                        errMsg = ProcessNews(ref NEWS_IMG, fu_News);
                                                        if (String.IsNullOrEmpty(errMsg))
                                                        {
                                                            errMsg = ProcessRates(ref RATES_IMG, fu_Rates);
                                                            if (String.IsNullOrEmpty(errMsg))
                                                            {
                                                                errMsg = ProcessAvailability(ref AVAILABILITY_IMG, fu_Availability);
                                                                if (String.IsNullOrEmpty(errMsg))
                                                                {
                                                                    errMsg = ProcessCalender(ref CALENDER_IMG, fu_Calender);
                                                                    if (String.IsNullOrEmpty(errMsg))
                                                                    {
                                                                        errMsg = ProcessVoting(ref VOTING_IMG, fu_Img_Voting);
                                                                        if (!String.IsNullOrEmpty(errMsg))
                                                                        {
                                                                            MessageBox(1, errMsg, "");
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
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
                    oBMAST = new EntityHeadHomeBgSetting();
                    oBMAST.BG_ABOUT_ME_IMAGE = hf_ABOUT_IMG.Value;
                    oBMAST.BG_TOUR_IMAGE = hf_TOUR_IMG.Value;
                    oBMAST.BG_QUICK_FACTS_IMAGE = hf_QUICK_FACT_IMG.Value;
                    oBMAST.BG_PREFER_IMAGE = hf_PREFER_IMG.Value;
                    oBMAST.BG_GALLERY_IMAGE = hf_GALLERY_IMG.Value;
                    oBMAST.BG_EXCITING_OFFER_IMAGE = hf_OFFER_IMG.Value;
                    oBMAST.BG_DAIRY_IMAGE = hf_DIARY_IMG.Value;
                    oBMAST.BG_CLIENT_IMAGE = hf_TESTIMONIALS_IMG.Value;
                    oBMAST.BG_SELFIE_IMAGE = hf_SELFIE_IMG.Value;
                    oBMAST.BG_NEWS_IMAGE = hf_NEWS_IMG.Value;
                    oBMAST.BG_RATE_IMAGE = hf_RATES_IMG.Value;
                    oBMAST.BG_AVAILABILITY_IMAGE = hf_AVAILABILITY_IMG.Value;
                    oBMAST.BG_CALENDER_IMAGE = hf_CALENDER_IMG.Value;
                    oBMAST.BG_VOTING_IMAGE = hf_VOTING_IMG.Value;

                    oBMAST.ENT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.EDIT_USER_KEY = oSysUser.USER_KEY;
                    oBMAST.TAG_ACTIVE = 1;
                    oBMAST.TAG_DELETE = 0;
                    oBMAST.COMPANY_KEY = 6;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BAHeadHomeBgSetting oBMC = new BAHeadHomeBgSetting())
                    {
                        vRef = oBMC.SaveChanges<Object, Int32>("", oBMAST, null, ref vKey, ref errMsg, "2019", 5);
                        if (vRef == 1)
                        {
                            MessageBox(2, "Data stored successfully", "");
                            // FillHomeSettingEdit();
                            FillBackgroundImageSettingEdit();
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


        private String FillBackgroundImageSettingEdit()
        {
            try
            {
                String vCOMPANY_ACCESS = String.Empty;
                errMsg = String.Empty;

                dt = new DataTable();
                using (BAHeadHomeBgSetting oBME = new BAHeadHomeBgSetting())
                {
                    dt = oBME.Get("GET", 6, "", ref errMsg, null, 1);
                }
                if (dt != null && dt.Rows.Count > 0)
                {



                    hf_ABOUT_IMG.Value = Convert.ToString(dt.Rows[0]["BG_ABOUT_ME_IMAGE"]);
                    if (hf_ABOUT_IMG.Value == "")
                    {
                        img_About.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_About.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_ABOUT_ME_IMAGE"]);
                    }
                    hf_TOUR_IMG.Value = Convert.ToString(dt.Rows[0]["BG_TOUR_IMAGE"]);
                    if (hf_TOUR_IMG.Value == "")
                    {
                        img_Tour.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Tour.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_TOUR_IMAGE"]);
                    }
                    //img_Tour.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_TOUR_IMAGE"]);

                    hf_QUICK_FACT_IMG.Value = Convert.ToString(dt.Rows[0]["BG_QUICK_FACTS_IMAGE"]);

                    if (hf_QUICK_FACT_IMG.Value == "")
                    {
                        img_Quick_Facts.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Quick_Facts.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_QUICK_FACTS_IMAGE"]);
                    }


                    //img_Quick_Facts.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_QUICK_FACTS_IMAGE"]);

                    hf_PREFER_IMG.Value = Convert.ToString(dt.Rows[0]["BG_PREFER_IMAGE"]);

                    if (hf_PREFER_IMG.Value == "")
                    {
                        img_Prefer.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Prefer.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_PREFER_IMAGE"]);
                    }

                   // img_Prefer.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_PREFER_IMAGE"]);

                    hf_GALLERY_IMG.Value = Convert.ToString(dt.Rows[0]["BG_GALLERY_IMAGE"]);

                    if (hf_GALLERY_IMG.Value == "")
                    {
                        img_Gallery.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Gallery.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_GALLERY_IMAGE"]);
                    }


                   // img_Gallery.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_GALLERY_IMAGE"]);

                    hf_OFFER_IMG.Value = Convert.ToString(dt.Rows[0]["BG_EXCITING_OFFER_IMAGE"]);

                    if (hf_OFFER_IMG.Value == "")
                    {
                        img_Offer.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Offer.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_EXCITING_OFFER_IMAGE"]);
                    }

                   // img_Offer.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_EXCITING_OFFER_IMAGE"]);

                    hf_DIARY_IMG.Value = Convert.ToString(dt.Rows[0]["BG_DAIRY_IMAGE"]);


                    if (hf_DIARY_IMG.Value == "")
                    {
                        img_Diary.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Diary.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_DAIRY_IMAGE"]);
                    }

                  //  img_Diary.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_DAIRY_IMAGE"]);

                    hf_TESTIMONIALS_IMG.Value = Convert.ToString(dt.Rows[0]["BG_CLIENT_IMAGE"]);


                    if (hf_TESTIMONIALS_IMG.Value == "")
                    {
                        img_Testimonials.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Testimonials.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_CLIENT_IMAGE"]);
                    }

                   // img_Testimonials.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_CLIENT_IMAGE"]);

                    hf_SELFIE_IMG.Value = Convert.ToString(dt.Rows[0]["BG_SELFIE_IMAGE"]);

                    if (hf_SELFIE_IMG.Value == "")
                    {
                        img_Selfie.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Selfie.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_SELFIE_IMAGE"]);
                    }

                   // img_Selfie.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_SELFIE_IMAGE"]);

                    hf_NEWS_IMG.Value = Convert.ToString(dt.Rows[0]["BG_NEWS_IMAGE"]);


                    if (hf_NEWS_IMG.Value == "")
                    {
                        img_News.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_News.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_NEWS_IMAGE"]);
                    }

                   // img_News.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_NEWS_IMAGE"]);

                    hf_RATES_IMG.Value = Convert.ToString(dt.Rows[0]["BG_RATE_IMAGE"]);

                    if (hf_RATES_IMG.Value == "")
                    {
                        img_Rates.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Rates.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_RATE_IMAGE"]);
                    }

                  //  img_Rates.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_RATE_IMAGE"]);

                    hf_AVAILABILITY_IMG.Value = Convert.ToString(dt.Rows[0]["BG_AVAILABILITY_IMAGE"]);

                    if (hf_AVAILABILITY_IMG.Value == "")
                    {
                        img_Availability.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Availability.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_AVAILABILITY_IMAGE"]);
                    }

                  //  img_Availability.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_AVAILABILITY_IMAGE"]);

                    hf_CALENDER_IMG.Value = Convert.ToString(dt.Rows[0]["BG_CALENDER_IMAGE"]);


                    if (hf_CALENDER_IMG.Value == "")
                    {
                        img_Calender.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Calender.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_CALENDER_IMAGE"]);
                    }

                  //  img_Calender.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_CALENDER_IMAGE"]);

                    hf_VOTING_IMG.Value = Convert.ToString(dt.Rows[0]["BG_VOTING_IMAGE"]);

                    if (hf_VOTING_IMG.Value == "")
                    {
                        img_Voting.Src = "../assets/images/no_image.jpg";
                    }
                    else
                    {
                        img_Voting.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_VOTING_IMAGE"]);
                    }

                  //  img_Voting.Src = "~" + ConfigurationManager.AppSettings["BACKGROUND"].ToString() + Convert.ToString(dt.Rows[0]["BG_VOTING_IMAGE"]);


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
    }
}


