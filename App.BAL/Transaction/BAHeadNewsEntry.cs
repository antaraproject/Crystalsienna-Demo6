using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using App.CORE.Domain;
using App.CORE.Domain.Transaction;
using App.CORE.Repositories;
using App.CORE.Repositories.Transaction;
using App.DAL;
using System.Data.SqlTypes;

namespace App.BAL.Transaction
{
     public class BAHeadNewsEntry : IHeadNewsEntry
    {
        Int16 vCount = 0;
        DataTable dt = null;
        SqlParameter[] para = null;

        public void BindDdl(String pMode, ref DropDownList ddl, String pKey, ref String pMsg, string pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[2];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@SEARCH_TEXT", SqlDbType.VarChar, 50);
                para[vCount++].Value = pKey;

                using (CommonOp oCommonOp = new CommonOp())
                {
                    oCommonOp.BindDropDownList("SP_GET_HEAD_NEWS_ENTRY", ref ddl, "HEAD_NEWS_ENTRY_KEY", "HEAD_NEWS_CODE", ref pMsg, pAccYr, pCompany_key, para);
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }

        public DataTable Get<T>(String pMode, T pKey, String pSEARCH_TEXT, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[4];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@SEARCH_KEY", SqlDbType.Int);
                para[vCount++].Value = pKey;
                para[vCount] = new SqlParameter("@SEARCH_KEY2", SqlDbType.Int);
                para[vCount++].Value = 0;
                para[vCount] = new SqlParameter("@SEARCH_TEXT", SqlDbType.VarChar, 50);
                para[vCount++].Value = pSEARCH_TEXT;

                using (DBContext oDBC = new DBContext("SP_GET_HEAD_NEWS_ENTRY", CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, para, ref pMsg);
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return dt;
        }

        public DataTable GetGrid<T>(String pMode, EntityHeadNewsEntry oHeadNewsEntry, T pKey,String pSectionKey, String pSEARCH_TEXT, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[6];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@SEARCH_KEY", SqlDbType.Int);
                para[vCount++].Value = pKey;

                para[vCount] = new SqlParameter("@SECTION_SEARCH_TEXT", SqlDbType.VarChar, 50);
                para[vCount++].Value = pSectionKey;

                para[vCount] = new SqlParameter("@SEARCH_TEXT", SqlDbType.VarChar, 50);
                para[vCount++].Value = pSEARCH_TEXT;

                para[vCount] = new SqlParameter("@FROM_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oHeadNewsEntry.ENT_DATE;
                para[vCount] = new SqlParameter("@TO_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oHeadNewsEntry.EDIT_DATE;

                using (DBContext oDBC = new DBContext("SP_GET_HEAD_NEWS_ENTRY", CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, para, ref pMsg);
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return dt;
        }

        public DataTable Get<T, T2>(String pMode, T pKey, T2 pkey2, String pSEARCH_TEXT, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[5];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@SEARCH_KEY", SqlDbType.Int);
                para[vCount++].Value = pKey;
                para[vCount] = new SqlParameter("@SEARCH_KEY2", SqlDbType.Int);
                para[vCount++].Value = pkey2;
                para[vCount] = new SqlParameter("@SEARCH_TEXT", SqlDbType.VarChar, 50);
                para[vCount++].Value = pSEARCH_TEXT;
                para[vCount] = new SqlParameter("@FROM_DATE", SqlDbType.DateTime);
                para[vCount++].Value = SqlDateTime.Null;

                using (DBContext oDBC = new DBContext("SP_GET_HEAD_NEWS_ENTRY", CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, para, ref pMsg);
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return dt;
        }

        public Byte SaveChanges<T1, T2>(String pMode, EntityHeadNewsEntry oEntity, T1 pValue, ref T2 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            Byte vRef = 0;
            try
            {
                vCount = 0;
                para = new SqlParameter[19];
                para[vCount] = new SqlParameter("@SELECT_ACTION", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@RETURN_KEY", SqlDbType.TinyInt);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = 0;
                para[vCount] = new SqlParameter("@HEAD_NEWS_ENTRY_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = oEntity.HEAD_NEWS_ENTRY_KEY;
                para[vCount] = new SqlParameter("@HEAD_NEWS_CODE", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.HEAD_NEWS_CODE;
                para[vCount] = new SqlParameter("@NEWS_DATE", SqlDbType.SmallDateTime);
                para[vCount++].Value = oEntity.NEWS_DATE;
                para[vCount] = new SqlParameter("@NEWS_REGION_KEY", SqlDbType.VarChar, 100);
                para[vCount++].Value = oEntity.NEWS_REGION_KEY;
                para[vCount] = new SqlParameter("@NEWS_REGION", SqlDbType.VarChar,200);
                para[vCount++].Value = oEntity.NEWS_REGION;
                para[vCount] = new SqlParameter("@NEWS_CATEGORY_KEY", SqlDbType.VarChar, 100);
                para[vCount++].Value = oEntity.NEWS_CATEGORY_KEY;
                para[vCount] = new SqlParameter("@NEWS_CATEGORY", SqlDbType.VarChar, 200);
                para[vCount++].Value = oEntity.NEWS_CATEGORY;
                para[vCount] = new SqlParameter("@NEWS_SECTION_KEY", SqlDbType.VarChar, 100);
                para[vCount++].Value = oEntity.NEWS_SECTION_KEY;
                para[vCount] = new SqlParameter("@NEWS_SECTION", SqlDbType.VarChar, 200);
                para[vCount++].Value = oEntity.NEWS_SECTION;
                para[vCount] = new SqlParameter("@BLOG_HEADING", SqlDbType.NVarChar, 300);
                para[vCount++].Value = oEntity.BLOG_HEADING;
                para[vCount] = new SqlParameter("@BLOG_DETAIL", SqlDbType.NVarChar);
                para[vCount++].Value = oEntity.BLOG_DETAIL;
                para[vCount] = new SqlParameter("@BLOGGER_NAME", SqlDbType.NVarChar, 200);
                para[vCount++].Value = oEntity.BLOGGER_NAME;

                para[vCount] = new SqlParameter("@PIC_FILE_NAME", SqlDbType.VarChar,100);
                para[vCount++].Value = oEntity.PIC_FILE_NAME;

                para[vCount] = new SqlParameter("@ENT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.ENT_USER_KEY;
                para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.EDIT_USER_KEY;
                para[vCount] = new SqlParameter("@TAG_DELETE", SqlDbType.TinyInt);
                para[vCount++].Value = oEntity.TAG_DELETE;
                para[vCount] = new SqlParameter("@SYS_COMPANY_KEY", SqlDbType.SmallInt);
                para[vCount++].Value = oEntity.SYS_COMPANY_KEY;

                using (DBContext oDBC = new DBContext("SP_SAVE_HEAD_NEWS_ENTRY", CommandType.StoredProcedure))
                {
                    oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
                    vRef = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
                    pKey = (T2)Convert.ChangeType(oDBC.GetParameterValue("@HEAD_NEWS_ENTRY_KEY", ref pMsg), typeof(T2));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return vRef;
        }

        public byte GridDelete<T>(String pMode, T pValue, ref T pKey, ref String pMsg, Int32 pUser, String pAccYr, Int16? pCompany_key)
        {
            byte retKey = 0;
            //try
            //{
            //    vCount = 0;
            //    para = new SqlParameter[4];
            //    para[vCount] = new SqlParameter("@SELECT_ACTION", SqlDbType.VarChar, 20);
            //    para[vCount++].Value = pMode;
            //    para[vCount] = new SqlParameter("@RETURN_KEY", SqlDbType.TinyInt);
            //    para[vCount].Direction = ParameterDirection.InputOutput;
            //    para[vCount++].Value = 0;
            //    para[vCount] = new SqlParameter("@HEAD_ADMIN_PANEL_KEY", SqlDbType.Int);
            //    para[vCount].Direction = ParameterDirection.InputOutput;
            //    para[vCount++].Value = pValue;

            //    para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.Int);
            //    para[vCount++].Value = pUser;

            //    using (DBContext oDBC = new DBContext("SP_DELETE_HEAD_ADMIN_PANEL", CommandType.StoredProcedure))
            //    {
            //        oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
            //        retKey = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    pMsg = ex.Message;
            //}
            return retKey;
        }
        
        public void Dispose()
        {
            if (dt != null)
            {
                dt.Dispose(); dt = null;
            }
            if (para != null)
                para = null;
        }

    }
}
