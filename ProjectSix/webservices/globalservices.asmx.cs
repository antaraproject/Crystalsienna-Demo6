using App.BAL.Setup;
using App.BAL.Utility;
using App.BAL.Master;
using App.CORE.Domain;
using App.CORE.Domain.Setup;
using App.CORE.Domain.Master;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using App.BAL;

namespace EscortProject.webservices
{
    /// <summary>
    /// Summary description for globalservices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class globalservices : System.Web.Services.WebService
    {
        Int32 vKey = 0;

        [WebMethod(EnableSession = true)]
        public int GenerateOTP(string toemail)
        {
            int errMsg = 0;
            try
            {
                Random ran = new Random();
                int otp = ran.Next(1000, 9999);
                Session["userotp"] = otp;

                string form_username = ConfigurationManager.AppSettings["form_username"].ToString();
                string form_password = ConfigurationManager.AppSettings["form_password"].ToString();
                string messages = otp + " is your OTP for Web4Escort registration.";

                using (MailMessage mm = new MailMessage(form_username, toemail))
                {
                    mm.Subject = "Web4Escort registration OTP";
                    mm.Body = messages;

                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(form_username, Encrypt.Decryptdata(form_password)); //Encrypt.Decryptdata()
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }

                errMsg = 1;

                return errMsg;
            }
            catch (Exception ex)
            {
                return errMsg;
                ex.Message.ToString();
            }
        }

        [WebMethod(EnableSession = true)]
        //public Int16 VerifyOTP(EntityRegistration data)
        //{
        //    Int16 save_tag = 0;
        //    String errMsg = String.Empty;
        //    EntityRegistration oEntity = null;
        //    try
        //    {
        //        oEntity = new EntityRegistration();
        //        oEntity.name = data.name;
        //        oEntity.email = data.email;
        //        oEntity.password = Encrypt.Encryptdata(data.password);

        //        if (data.otp == Session["userotp"].ToString())
        //        {
        //            // TODO Save data to database
        //            using (BASysUser ba = new BASysUser())
        //            {
        //                if (ba.SaveUser<Object, Int32>("INSERT", oEntity, null, ref vKey, ref errMsg) > 0)
        //                {
        //                    if (vKey > 0)
        //                        save_tag = 1;
        //                    else
        //                        save_tag = 0;
        //                }
        //            }
        //            return save_tag;
        //        }
        //        else
        //        {
        //            return save_tag;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return save_tag;
        //    }
        //}

        //[WebMethod(EnableSession = true)]
        //public IList<Dictionary<String, object>> GePackageDetails(String txtType, String val)
        //{
        //    EntitySysUser oSysUser = null;
        //    String errMsg = String.Empty;
        //    DataTable dt = null;
        //    Dictionary<String, object> row = null;
        //    IList<Dictionary<String, object>> rows = new List<Dictionary<String, object>>();
        //    try
        //    {
        //        dt = new DataTable();
        //        using (BAPackageDetails oBME = new BAPackageDetails())
        //        {
        //            dt = oBME.GetData<Int32>(txtType, Convert.ToInt32(val), "", ref errMsg, "2019", 1);
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow rs in dt.Rows)
        //                {
        //                    row = new Dictionary<String, object>();
        //                    foreach (DataColumn col in dt.Columns)
        //                    {
        //                        row.Add(col.ColumnName, rs[col]);
        //                    }
        //                    row.Add("IMG_PATH", ".." + ConfigurationManager.AppSettings["TEMPLATE"].ToString());
        //                    rows.Add(row);
        //                }

        //            }
        //            else if (String.IsNullOrEmpty(errMsg))
        //                rows.Add(new Dictionary<String, object> { { "Error", Message.msgNotFound } });
        //            else
        //                rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(errMsg) } });
        //        }
        //        return rows;
        //    }
        //    catch (Exception ex)
        //    {
        //        rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(ex.Message) } });
        //        return rows;
        //    }
        //    finally
        //    {
        //        dt = null;
        //        oSysUser = null;
        //        row = null;
        //        rows = null;
        //    }
        //}

        //[WebMethod(EnableSession = true)]
        //public IList<Dictionary<String, object>> GeTemplateDetails(String txtType)
        //{
        //    EntitySysUser oSysUser = null;
        //    String errMsg = String.Empty;
        //    DataTable dt = null;
        //    Dictionary<String, object> row = null;
        //    IList<Dictionary<String, object>> rows = new List<Dictionary<String, object>>();
        //    try
        //    {
        //        dt = new DataTable();
        //        using (BAPackageDetails oBME = new BAPackageDetails())
        //        {
        //            dt = oBME.Get<Int32>(txtType, 0, "", ref errMsg, "2019", 1);
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow rs in dt.Rows)
        //                {
        //                    row = new Dictionary<String, object>();
        //                    foreach (DataColumn col in dt.Columns)
        //                    {
        //                        row.Add(col.ColumnName, rs[col]);
        //                    }
        //                    row.Add("IMG_PATH", ".." + ConfigurationManager.AppSettings["TEMPLATE"].ToString());
        //                    rows.Add(row);
        //                }

        //            }
        //            else if (String.IsNullOrEmpty(errMsg))
        //                rows.Add(new Dictionary<String, object> { { "Error", Message.msgNotFound } });
        //            else
        //                rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(errMsg) } });
        //        }
        //        return rows;
        //    }
        //    catch (Exception ex)
        //    {
        //        rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(ex.Message) } });
        //        return rows;
        //    }
        //    finally
        //    {
        //        dt = null;
        //        oSysUser = null;
        //        row = null;
        //        rows = null;
        //    }
        //}

        //[WebMethod(EnableSession = true)]
        public IList<Dictionary<String, object>> GetHeaderFooterDetails(String txtType)
        {
            EntitySysUser oSysUser = null;
            String errMsg = String.Empty;
            DataTable dt = null;
            Dictionary<String, object> row = null;
            IList<Dictionary<String, object>> rows = new List<Dictionary<String, object>>();
            try
            {
                dt = new DataTable();
                using (BAHomeSettings oBME = new BAHomeSettings())
                {
                    dt = oBME.GetData(txtType, "", ref errMsg, null, 1);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow rs in dt.Rows)
                        {
                            row = new Dictionary<String, object>();
                            foreach (DataColumn col in dt.Columns)
                            {
                                row.Add(col.ColumnName, rs[col]);
                            }
                            row.Add("BANNER_IMG_PATH", ".." + ConfigurationManager.AppSettings["BANNER"].ToString());
                            row.Add("SLIDER_IMG_PATH", ".." + ConfigurationManager.AppSettings["SLIDER"].ToString());
                            row.Add("UTILITY_IMG_PATH", ".." + ConfigurationManager.AppSettings["UTILITY"].ToString());
                            rows.Add(row);
                        }

                    }
                    else if (String.IsNullOrEmpty(errMsg))
                        rows.Add(new Dictionary<String, object> { { "Error", Message.msgNotFound } });
                    else
                        rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(errMsg) } });
                }
                return rows;
            }
            catch (Exception ex)
            {
                rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(ex.Message) } });
                return rows;
            }
            finally
            {
                dt = null;
                oSysUser = null;
                row = null;
                rows = null;
            }
        }

        //[WebMethod(EnableSession = true)]
        //public IList<Dictionary<String, object>> GePackage(String txtType)
        //{
        //    EntitySysUser oSysUser = null;
        //    String errMsg = String.Empty;
        //    DataTable dt = null;
        //    Dictionary<String, object> row = null;
        //    IList<Dictionary<String, object>> rows = new List<Dictionary<String, object>>();
        //    try
        //    {
        //        dt = new DataTable();
        //        using (BAPackage oBME = new BAPackage())
        //        {
        //            dt = oBME.Get<Int32>(txtType, 0, "", ref errMsg, "2019", 1);
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow rs in dt.Rows)
        //                {
        //                    row = new Dictionary<String, object>();
        //                    foreach (DataColumn col in dt.Columns)
        //                    {
        //                        row.Add(col.ColumnName, rs[col]);
        //                    }
        //                    rows.Add(row);
        //                }

        //            }
        //            else if (String.IsNullOrEmpty(errMsg))
        //                rows.Add(new Dictionary<String, object> { { "Error", Message.msgNotFound } });
        //            else
        //                rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(errMsg) } });
        //        }
        //        return rows;
        //    }
        //    catch (Exception ex)
        //    {
        //        rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(ex.Message) } });
        //        return rows;
        //    }
        //    finally
        //    {
        //        dt = null;
        //        oSysUser = null;
        //        row = null;
        //        rows = null;
        //    }
        //}

        //[WebMethod(EnableSession = true)]
        //public IList<Dictionary<String, object>> GePackageCategory(String txtType)
        //{
        //    EntitySysUser oSysUser = null;
        //    String errMsg = String.Empty;
        //    DataTable dt = null;
        //    Dictionary<String, object> row = null;
        //    IList<Dictionary<String, object>> rows = new List<Dictionary<String, object>>();
        //    try
        //    {
        //        dt = new DataTable();
        //        using (BAPackageCategory oBME = new BAPackageCategory())
        //        {
        //            dt = oBME.Get<Int32>(txtType, 0, "", ref errMsg, "2019", 1);
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow rs in dt.Rows)
        //                {
        //                    row = new Dictionary<String, object>();
        //                    foreach (DataColumn col in dt.Columns)
        //                    {
        //                        row.Add(col.ColumnName, rs[col]);
        //                    }
        //                    rows.Add(row);
        //                }

        //            }
        //            else if (String.IsNullOrEmpty(errMsg))
        //                rows.Add(new Dictionary<String, object> { { "Error", Message.msgNotFound } });
        //            else
        //                rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(errMsg) } });
        //        }
        //        return rows;
        //    }
        //    catch (Exception ex)
        //    {
        //        rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(ex.Message) } });
        //        return rows;
        //    }
        //    finally
        //    {
        //        dt = null;
        //        oSysUser = null;
        //        row = null;
        //        rows = null;
        //    }
        //}

        //[WebMethod(EnableSession = true)]
        //public IList<Dictionary<String, object>> GeDetailsPackage(String txtType)
        //{
        //    EntitySysUser oSysUser = null;
        //    String errMsg = String.Empty;
        //    DataTable dt = null;
        //    Dictionary<String, object> row = null;
        //    IList<Dictionary<String, object>> rows = new List<Dictionary<String, object>>();
        //    try
        //    {
        //        dt = new DataTable();
        //        using (BADetailsPackage oBME = new BADetailsPackage())
        //        {
        //            dt = oBME.Get<Int32>(txtType, 0, "", ref errMsg, "2019", 1);
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow rs in dt.Rows)
        //                {
        //                    row = new Dictionary<String, object>();
        //                    foreach (DataColumn col in dt.Columns)
        //                    {
        //                        row.Add(col.ColumnName, rs[col]);
        //                    }
        //                    rows.Add(row);
        //                }

        //            }
        //            else if (String.IsNullOrEmpty(errMsg))
        //                rows.Add(new Dictionary<String, object> { { "Error", Message.msgNotFound } });
        //            else
        //                rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(errMsg) } });
        //        }
        //        return rows;
        //    }
        //    catch (Exception ex)
        //    {
        //        rows.Add(new Dictionary<String, object> { { "Error", CommonOp.ModifyExceptionMessage(ex.Message) } });
        //        return rows;
        //    }
        //    finally
        //    {
        //        dt = null;
        //        oSysUser = null;
        //        row = null;
        //        rows = null;
        //    }
        //}

        //[WebMethod(EnableSession = true)]
        //public Int16 Saveuseractivity(EntityUserActivity data)
        //{
        //    Int16 save_tag = 0;
        //    Byte vRef = 0;
        //    String errMsg = String.Empty;
        //    EntityUserActivity oEntity = null;
        //    try
        //    {
        //        oEntity = new EntityUserActivity();
        //        oEntity.MAST_PACKAGE_KEY = data.MAST_PACKAGE_KEY;
        //        oEntity.USER_KEY = data.USER_KEY;
        //        oEntity.HEAD_PACKAGE_DETAILS_KEY = data.HEAD_PACKAGE_DETAILS_KEY;
        //        oEntity.ENT_USER_KEY = data.USER_KEY;
        //        oEntity.EDIT_USER_KEY = data.USER_KEY;
        //        oEntity.TAG_ACTIVE = 0;
        //        oEntity.TAG_DELETE = 0;
        //        // TODO Save data to database
        //        using (BAUserActivity ba = new BAUserActivity())
        //        {
        //            vRef = ba.SaveChanges<Object, Int32>("INSERT", oEntity, null, ref vKey, ref errMsg);
        //            if (vRef == 1)
        //                save_tag = 1;
        //            else
        //                save_tag = 0;
        //        }
        //        return save_tag;
        //    }
        //    catch (Exception ex)
        //    {
        //        return save_tag;
        //    }
        //}
        [WebMethod(EnableSession = true)]
        public Int16 SaveEvents(EntityDtlsEvent data)
        {
            Int16 save_tag = 0;
            Byte vRef = 0;
            String errMsg = String.Empty;
            EntityDtlsEvent oEntity = null;
            try
            {
                oEntity = new EntityDtlsEvent();
                oEntity.DTLS_EVENTS_KEY= data.DTLS_EVENTS_KEY;
                oEntity.EVENTS_TITLE= data.EVENTS_TITLE;
                oEntity.EVENTS_DESC = data.EVENTS_DESC;
                oEntity.EVENT_DATE = data.EVENT_DATE;
                oEntity.COMPANY_KEY = data.COMPANY_KEY;
                oEntity.ENT_USER_KEY = data.ENT_USER_KEY;
                oEntity.EDIT_USER_KEY = data.EDIT_USER_KEY;
                oEntity.TAG_ACTIVE = 0;
                oEntity.TAG_DELETE = 0;
                // TODO Save data to database
                using (BADtlsEvent ba = new BADtlsEvent())
                {
                    vRef = ba.SaveChanges<Object, Int32>("INSERT", oEntity, null, ref vKey, ref errMsg, "2019", 1);
                    
                    if (vRef == 1)
                        save_tag = 1;
                    else
                        save_tag = 0;
                }
                return save_tag;
            }
            catch (Exception ex)
            {
                return save_tag;
            }
        }

        public void CancelEvents(EntityDtlsEvent val)
        {
            Server.Transfer("~/calender/");
        }

    }
}
