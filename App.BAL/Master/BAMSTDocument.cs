using App.CORE.Domain.Master;
using App.CORE.Repositories.Master;
using App.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace App.BAL.Master
{
    public class BAMSTDocument : IHeadQuestionPaper
    {
        Int16 vCount = 0;
        DataTable dt = null;
        SqlParameter[] para = null;

        public void BindDdl(ref DropDownList ddl, Int32 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[1];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = "DDL";

                using (CommonOp oCommonOp = new CommonOp())
                {
                    oCommonOp.BindDropDownList("SP_GET_MAST_TOUR", ref ddl, "MAST_TOUR_KEY", "SPOT_NAME", ref pMsg, pAccYr, pCompany_key, para);
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
                para = new SqlParameter[3];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@SEARCH_KEY", SqlDbType.Int);
                para[vCount++].Value = pKey;
                para[vCount] = new SqlParameter("@SEARCH_TEXT", SqlDbType.VarChar, 50);
                para[vCount++].Value = pSEARCH_TEXT;

                using (DBContext oDBC = new DBContext("SP_GET_HEAD_DOCUMENT", CommandType.StoredProcedure))
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

        public DataTable GetDtls<T>(String pMode, T pKey, String pSEARCH_TEXT, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[3];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@SEARCH_KEY", SqlDbType.Int);
                para[vCount++].Value = pKey;
                para[vCount] = new SqlParameter("@SEARCH_TEXT", SqlDbType.VarChar, 50);
                para[vCount++].Value = pSEARCH_TEXT;

                //para[vCount] = new SqlParameter("@SEARCH_KEY2", SqlDbType.Int);
                //para[vCount++].Value = 0;

                using (DBContext oDBC = new DBContext("SP_GET_DTLS_DOCUMENTS", CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, para, ref pMsg);
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return dt;

            throw new NotImplementedException();
        }

        public Byte SaveDtlsChanges<T1, T2>(String pMode, EntityDocuents oEntity, T1 pValue, ref T2 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            Byte vRef = 0;
            try
            {
                vCount = 0;
                para = new SqlParameter[12];
                para[vCount] = new SqlParameter("@SELECT_ACTION", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@RETURN_KEY", SqlDbType.TinyInt);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = 0;
                para[vCount] = new SqlParameter("@DTLS_DOCUMENTS_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = oEntity.DTLS_DOCUMENTS_KEY;
                para[vCount] = new SqlParameter("@HEAD_DOCUMENT_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.HEAD_DOCUMENT_KEY;

                para[vCount] = new SqlParameter("@DOCUMENT_NAME", SqlDbType.VarChar, 500);
                para[vCount++].Value = oEntity.DOCUMENT_NAME;
                para[vCount] = new SqlParameter("@DOCUMENT_PATH", SqlDbType.VarChar, 500);
                para[vCount++].Value = oEntity.DOCUMENT_PATH;
                para[vCount] = new SqlParameter("@DETAILS", SqlDbType.VarChar, 500);
                para[vCount++].Value = oEntity.DETAILS;

                para[vCount] = new SqlParameter("@ENT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.ENT_USER_KEY;
                para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.EDIT_USER_KEY;
                para[vCount] = new SqlParameter("@TAG_ACTIVE", SqlDbType.TinyInt);
                para[vCount++].Value = oEntity.TAG_ACTIVE;
                para[vCount] = new SqlParameter("@TAG_DELETE", SqlDbType.TinyInt);
                para[vCount++].Value = oEntity.TAG_DELETE;
                para[vCount] = new SqlParameter("@COMPANY_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.COMPANY_KEY;
                using (DBContext oDBC = new DBContext("SP_SAVE_DTLS_DOCUMENTS", CommandType.StoredProcedure))
                {
                    oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
                    vRef = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
                    pKey = (T2)Convert.ChangeType(oDBC.GetParameterValue("@DTLS_DOCUMENTS_KEY", ref pMsg), typeof(T2));
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
            try
            {
                vCount = 0;
                para = new SqlParameter[4];
                para[vCount] = new SqlParameter("@SELECT_ACTION", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@RETURN_KEY", SqlDbType.TinyInt);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = 0;
                para[vCount] = new SqlParameter("@HEAD_DOCUMENT_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = pValue;

                para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = pUser;

                using (DBContext oDBC = new DBContext("SP_DELETE_HEAD_DOCUMENT", CommandType.StoredProcedure))
                {
                    oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
                    retKey = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return retKey;
        }

        public byte GridDtlsDelete<T>(String pMode, T pValue, ref T pKey, ref String pMsg, Int32 pUser, String pAccYr, Int16? pCompany_key)
        {
            byte retKey = 0;
            try
            {
                vCount = 0;
                para = new SqlParameter[4];
                para[vCount] = new SqlParameter("@SELECT_ACTION", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@RETURN_KEY", SqlDbType.TinyInt);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = 0;
                para[vCount] = new SqlParameter("@DTLS_DOCUMENTS_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = pValue;

                para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = pUser;

                using (DBContext oDBC = new DBContext("SP_DELETE_DTLS_DOCUMENTS", CommandType.StoredProcedure))
                {
                    oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
                    retKey = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return retKey;
        }

        public Byte SaveChanges<T1, T2>(String pMode, EntityDocuents oEntity, T1 pValue, ref T2 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            Byte vRef = 0;
            try
            {
                vCount = 0;
                para = new SqlParameter[11];
                para[vCount] = new SqlParameter("@SELECT_ACTION", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@RETURN_KEY", SqlDbType.TinyInt);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = 0;
                para[vCount] = new SqlParameter("@HEAD_DOCUMENT_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = oEntity.HEAD_DOCUMENT_KEY;
                para[vCount] = new SqlParameter("@MAST_CATEGORY_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_CATEGORY_KEY;
                para[vCount] = new SqlParameter("@MAST_SUB_CATEGORY_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_SUB_CATEGORY_KEY;
                para[vCount] = new SqlParameter("@REMARKS", SqlDbType.VarChar, 250);
                para[vCount++].Value = oEntity.REMARKS;

                para[vCount] = new SqlParameter("@ENT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.ENT_USER_KEY;
                para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.EDIT_USER_KEY;
                para[vCount] = new SqlParameter("@TAG_ACTIVE", SqlDbType.TinyInt);
                para[vCount++].Value = oEntity.TAG_ACTIVE;
                para[vCount] = new SqlParameter("@TAG_DELETE", SqlDbType.TinyInt);
                para[vCount++].Value = oEntity.TAG_DELETE;
                para[vCount] = new SqlParameter("@COMPANY_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.COMPANY_KEY;

                using (DBContext oDBC = new DBContext("SP_SAVE_HEAD_DOCUMENT", CommandType.StoredProcedure))
                {
                    oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
                    vRef = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
                    pKey = (T2)Convert.ChangeType(oDBC.GetParameterValue("@HEAD_DOCUMENT_KEY", ref pMsg), typeof(T2));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return vRef;
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
