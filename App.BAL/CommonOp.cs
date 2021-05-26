using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using App.BAL.Utility;
using App.DAL;
using System.Web;
using System.Text;


namespace App.BAL
{
    public class CommonOp : IDisposable
    {
        DataTable dt = null;
        //DataSet ds = null;

        public CommonOp()
        { }

        public enum DocUploadType : int
        {
            Image = 1,
            Document = 2
        }

        public enum DocUpload : int
        {
            LotHead = 1,
            LotPartFront = 2,
            LotPartBack = 3
        }

        public enum TransType : int
        {
            Insert = 0,
            Update = 1
        }

        public static String ModifyExceptionMessage(String exMsg)
        {
            try
            {
                exMsg = exMsg.Replace("'", "");
                if (exMsg.IndexOf("\r\n") > 0)
                {
                    exMsg = exMsg.Remove(exMsg.IndexOf("\r\n"), 2);
                    exMsg = ModifyExceptionMessage(exMsg);
                }

                return exMsg;
            }
            catch
            {
                return Message.msgErrCommon;
            }
        }

        public String CheckUploadFile(DocUploadType pDocUploadType, FileUpload fu_Control)
        {
            String[] vPhotoAcceptedExtensions = null;
            String vErrMsg = String.Empty;
            Int32 vDocsize = 0;
            try
            {
                if (((Int32)pDocUploadType) == 1)
                {
                    vPhotoAcceptedExtensions = ConfigurationManager.AppSettings["ValidImageType"].Replace(" ", "").Split(',');
                    vDocsize = Convert.ToInt32(ConfigurationManager.AppSettings["ImageSize"]);
                }
                else
                {
                    vPhotoAcceptedExtensions = ConfigurationManager.AppSettings["ValidDocType"].Replace(" ", "").Split(',');
                    vDocsize = Convert.ToInt32(ConfigurationManager.AppSettings["DocSize"]);
                }
                if (vPhotoAcceptedExtensions.Contains(Path.GetExtension(fu_Control.PostedFile.FileName).ToLower()))
                {
                    if (fu_Control.PostedFile.ContentLength > vDocsize)
                        vErrMsg = "Please maintain allowed document size(" + ConfigurationManager.AppSettings[((Int32)pDocUploadType) == 1 ? "ImageSizeInWord" : "DocSizeInWord"] + ").";
                }
                else
                    vErrMsg = "Please maintain allowed document format(" + ConfigurationManager.AppSettings[((Int32)pDocUploadType) == 1 ? "ValidImageType" : "ValidDocType"] + ").";
                return vErrMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                vPhotoAcceptedExtensions = null;
            }
        }

        public String UploadFile(DocUploadType pDocUploadType,
                                 DocUpload pDocUpload,
                                 TransType pType,
                                 String pAccYrPart, FileUpload fu_Control, ref String pDocPath, ref String pDocName)
        {
            String vErrMsg = String.Empty;
            try
            {
                vErrMsg = CheckUploadFile(pDocUploadType, fu_Control);
                if (String.IsNullOrEmpty(vErrMsg))
                {
                    // Checking for new upload
                    if ((Int32)pType == 0)
                    {
                        switch (((Int32)pDocUpload))
                        {
                            case 1: pDocPath = String.Format(ConfigurationManager.AppSettings["LotFilePath"].ToString(), pAccYrPart) + pDocPath; break;
                            case 2: pDocPath = pDocPath + "Front/"; break;
                            case 3: pDocPath = pDocPath + "Back/"; break;
                            default: pDocPath = String.Empty; break;
                        }
                    }

                    // Checking for directory & file duplication
                    if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(pDocPath)))
                    {
                        if (!String.IsNullOrEmpty(pDocName) && pDocName != fu_Control.FileName)
                        {
                            FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(pDocPath + pDocName));
                            if (file.Exists)
                                file.Delete();
                        }
                    }
                    else
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(pDocPath));

                    // Upload document
                    //if ((Int32)pType > 0)                    
                    //pDocName = fu_Control.FileName;
                    if ((Int32)pDocUploadType == 1)
                    {
                        //vErrMsg = GenerateThumbnails(Convert.ToInt32(String.IsNullOrEmpty(ConfigurationManager.AppSettings["ImageWidth"]) ? "350" : ConfigurationManager.AppSettings["ImageWidth"]),
                        //                             Convert.ToInt32(String.IsNullOrEmpty(ConfigurationManager.AppSettings["ImageHeight"]) ? "512" : ConfigurationManager.AppSettings["ImageHeight"]),
                        //                             fu_Control.PostedFile.InputStream, HttpContext.Current.Server.MapPath(pDocPath + pDocName));
                    }
                    else
                    {
                        fu_Control.SaveAs(HttpContext.Current.Server.MapPath(pDocPath + pDocName));
                    }
                }
                return vErrMsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String DeleteUploadedFile(String pDocPath, String pDocName)
        {
            try
            {
                FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(pDocPath + pDocName));
                if (file.Exists)
                    file.Delete();
                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <returns></returns>
        public String GenerateThumbnails(Int32 newWidth, Int32 newHeight, Stream sourcePath, String targetPath)//double scaleFactor,
        {
            try
            {
                using (var image1 = System.Drawing.Image.FromStream(sourcePath))
                {
                    var thumbnailImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbnailImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image1, imageRectangle);
                    thumbnailImg.Save(targetPath, image1.RawFormat);
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objList"></param>
        /// <returns></returns>
        //public DataTable ListToDataTable<T>(IList<T> objList)
        //{
        //    PropertyInfo[] Props = null;
        //    T obj = default(T);
        //    try
        //    {
        //        dt = new DataTable();
        //        Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //        for (int i = 0; i < objList.Count; i++)
        //        {
        //            obj = objList[i];
        //            if (dt.Rows.Count == 0)
        //            {
        //                foreach (PropertyInfo prop in Props)
        //                    dt.Columns.Add(prop.Name);
        //            }
        //            var values = new object[Props.Length];
        //            for (int j = 0; j < Props.Length; j++)
        //            {
        //                values[j] = Props[j].GetValue(obj, null);
        //            }
        //            dt.Rows.Add(values);
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        Props = null;
        //        dt.Dispose();
        //        obj = default(T);
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSqlString"></param>
        /// <param name="ddl"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        /// <param name="pAccYr"></param>
        /// <param name="pCompany_key"></param>
        public void BindDropDownList(String pSpName, ref DropDownList ddl, String valueField, String textField, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                dt = new DataTable();
                using (DBContext oDBC = new DBContext(pSpName, CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, ref pMsg);
                    ddl.Items.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddl.DataSource = dt;
                        ddl.DataTextField = textField;
                        ddl.DataValueField = valueField;
                        ddl.DataBind();
                    }
                    ddl.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSqlString"></param>
        /// <param name="ddl"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        /// <param name="pAccYr"></param>
        /// <param name="pCompany_key"></param>
        /// <param name="pParamList"></param>
        public void BindDropDownList(String pSpName, ref DropDownList ddl, String valueField, String textField, ref String pMsg, String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList)
        {
            try
            {
                dt = new DataTable();
                using (DBContext oDBC = new DBContext(pSpName, CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, pParamList, ref pMsg);
                    ddl.Items.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddl.DataSource = dt;
                        ddl.DataTextField = textField;
                        ddl.DataValueField = valueField;
                        ddl.DataBind();
                    }
                    ddl.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }

        public void BindDropDownListNew(String pSpName, ref DropDownList ddl, String valueField, String textField, ref String pMsg, String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList)
        {
            try
            {
                dt = new DataTable();
                using (DBContext oDBC = new DBContext(pSpName, CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, pParamList, ref pMsg);
                    ddl.Items.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddl.DataSource = dt;
                        ddl.DataTextField = textField;
                        ddl.DataValueField = valueField;
                        ddl.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }
        
        public void BindListBox(String pSpName, ref ListBox ddl, String valueField, String textField, ref String pMsg, String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList)
        {
            try
            {
                dt = new DataTable();
                using (DBContext oDBC = new DBContext(pSpName, CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, pParamList, ref pMsg);
                    ddl.Items.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddl.DataSource = dt;
                        ddl.DataTextField = textField;
                        ddl.DataValueField = valueField;
                        ddl.DataBind();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSpName"></param>
        /// <param name="chk"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        /// <param name="pAccYr"></param>
        /// <param name="pCompany_key"></param>
        public void BindCheckBoxList(String pSpName, ref CheckBoxList chk, String valueField, String textField, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                dt = new DataTable();
                using (DBContext oDBC = new DBContext(pSpName, CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, ref pMsg);
                    chk.Items.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        chk.DataSource = dt;
                        chk.DataTextField = textField;
                        chk.DataValueField = valueField;
                        chk.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }

        public void BindCategoryDropDownList(String pSpName, ref DropDownList ddl, String valueField, String textField, ref String pMsg, String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList)
        {
            try
            {
                dt = new DataTable();
                using (DBContext oDBC = new DBContext(pSpName, CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, pParamList, ref pMsg);
                    ddl.Items.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddl.DataSource = dt;
                        ddl.DataTextField = textField;
                        ddl.DataValueField = valueField;
                        ddl.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSpName"></param>
        /// <param name="chk"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        /// <param name="pAccYr"></param>
        /// <param name="pCompany_key"></param>
        /// <param name="pParamList"></param>
        public void BindCheckBoxList(String pSpName, ref CheckBoxList chk, String valueField, String textField, ref String pMsg, String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList)
        {
            try
            {
                dt = new DataTable();
                using (DBContext oDBC = new DBContext(pSpName, CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, pParamList, ref pMsg);
                    chk.Items.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        chk.DataSource = dt;
                        chk.DataTextField = textField;
                        chk.DataValueField = valueField;
                        chk.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }


        public static String Encryptdata(String strText)
        {
            byte[] EncodeAsBytes = Encoding.UTF8.GetBytes(strText);
            String returnValue = System.Convert.ToBase64String(EncodeAsBytes);
            return returnValue;
        }

        public static String Decryptdata(String strText)
        {
            byte[] DecodeAsBytes = System.Convert.FromBase64String(strText);
            String returnValue = Encoding.UTF8.GetString(DecodeAsBytes);
            return returnValue;
        }


        /// <summary>
        /// Resource Management
        /// </summary>
        public void Dispose()
        {
            if (dt != null)
            {
                dt.Dispose(); dt = null;
            }
        }
    }
}
