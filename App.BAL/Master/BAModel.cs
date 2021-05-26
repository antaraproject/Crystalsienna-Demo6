using App.CORE.Domain.Master;
using App.CORE.Repositories.Master;
using App.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace App.BAL.Master
{
    public class BAModel : IModel
    {
        Int16 vCount = 0;
        DataTable dt = null;
        SqlParameter[] para = null;

        public void BindDdl(ref DropDownList ddl, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[1];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = "DDL";

                using (CommonOp oCommonOp = new CommonOp())
                {
                    oCommonOp.BindDropDownList("SP_GET_MAST_MODEL", ref ddl, "MAST_MODEL_KEY", "MODEL_NAME", ref pMsg, pAccYr, pCompany_key, para);
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

                using (DBContext oDBC = new DBContext("SP_GET_MAST_MODEL", CommandType.StoredProcedure))
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

        public byte SaveChanges<T1, T2>(String pMode, EntityModel oEntity, T1 pValue, ref T2 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            Byte vRef = 0;
            try
            {
                vCount = 0;
                para = new SqlParameter[28];
                para[vCount] = new SqlParameter("@SELECT_ACTION", SqlDbType.VarChar, 20);
                para[vCount++].Value = pMode;
                para[vCount] = new SqlParameter("@RETURN_KEY", SqlDbType.TinyInt);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = 0;
                para[vCount] = new SqlParameter("@MAST_MODEL_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = oEntity.MAST_MODEL_KEY;
                para[vCount] = new SqlParameter("@USER_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = oEntity.USER_KEY;
                para[vCount] = new SqlParameter("@MODEL_CODE", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.MODEL_CODE;
                para[vCount] = new SqlParameter("@MAST_MODEL_CATEGORY_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_MODEL_CATEGORY_KEY;
                para[vCount] = new SqlParameter("@MODEL_NAME", SqlDbType.VarChar, 250);
                para[vCount++].Value = oEntity.MODEL_NAME;
                para[vCount] = new SqlParameter("@MODEL_DESC", SqlDbType.VarChar, 5000);
                para[vCount++].Value = oEntity.MODEL_DESC;
                para[vCount] = new SqlParameter("@AGE", SqlDbType.Int);
                para[vCount++].Value = oEntity.AGE;
                para[vCount] = new SqlParameter("@BUST", SqlDbType.VarChar, 250);
                para[vCount++].Value = oEntity.BUST;
                para[vCount] = new SqlParameter("@EYE_COLOUR", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.EYE_COLOUR;
                para[vCount] = new SqlParameter("@SKIN_COLOUR", SqlDbType.VarChar, 250);
                para[vCount++].Value = oEntity.SKIN_COLOUR;
                para[vCount] = new SqlParameter("@HEIGHT", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.HEIGHT;
                para[vCount] = new SqlParameter("@DRESS", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.DRESS;
                para[vCount] = new SqlParameter("@HAIR_COLOUR", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.HAIR_COLOUR;
                para[vCount] = new SqlParameter("@HERITAGE", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.HERITAGE;
                para[vCount] = new SqlParameter("@IMG_FILE_NAME", SqlDbType.VarChar, 200);
                para[vCount++].Value = oEntity.IMG_FILE_NAME;
                para[vCount] = new SqlParameter("@MULTI_IMAGE_NAME", SqlDbType.VarChar, 200);
                para[vCount++].Value = oEntity.MULTI_IMAGE_NAME;
                para[vCount] = new SqlParameter("@MODEL_TYPE", SqlDbType.VarChar, 100);
                para[vCount++].Value = oEntity.MODEL_TYPE;
                para[vCount] = new SqlParameter("@MAST_MODEL_ACTIVITY_KEY", SqlDbType.VarChar, 500);
                para[vCount++].Value = oEntity.MAST_MODEL_ACTIVITY_KEY;
                para[vCount] = new SqlParameter("@MODEL_SHORT_DESC", SqlDbType.VarChar, 100);
                para[vCount++].Value = oEntity.MODEL_SHORT_DESC;
                para[vCount] = new SqlParameter("@NICK_NAME", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.NICK_NAME;
                para[vCount] = new SqlParameter("@USER_PASSWORD", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.USER_PASSWORD;

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

                using (DBContext oDBC = new DBContext("SP_SAVE_MAST_MODEL", CommandType.StoredProcedure))
                {
                    oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
                    vRef = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
                    pKey = (T2)Convert.ChangeType(oDBC.GetParameterValue("@MAST_MODEL_KEY", ref pMsg), typeof(T2));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return vRef;
        }

        public Byte SaveDelete<T1, T2>(String pMode, EntityModel oEntity, T1 pValue, ref T2 pKey, ref String pMsg, ref String pDelMsg, String pAccYr, Int16? pCompany_key)
        {
            Byte vRef = 0;
            try
            {
                vCount = 0;
                para = new SqlParameter[4];
                para[vCount] = new SqlParameter("@SELECT_ACTION", SqlDbType.VarChar, 30);
                para[vCount++].Value = "DELETE";
                para[vCount] = new SqlParameter("@RETURN_KEY", SqlDbType.TinyInt);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = 0;
                para[vCount] = new SqlParameter("@MAST_MODEL_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = oEntity.MAST_MODEL_KEY;

                para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.SmallInt);
                para[vCount++].Value = oEntity.ENT_USER_KEY;

                using (DBContext oDBC = new DBContext("SP_DELETE_MAST_MODEL", CommandType.StoredProcedure))
                {
                    oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
                    vRef = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
                    pKey = (T2)Convert.ChangeType(oDBC.GetParameterValue("@MAST_MODEL_KEY", ref pMsg), typeof(T2));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return vRef;
        }

        public Byte SaveSchedule<T1, T2>(String pMode, EntityModel oEntity, T1 pValue, ref T2 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
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
                para[vCount] = new SqlParameter("@MAST_SCHEDULE_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = oEntity.MAST_SCHEDULE_KEY;
                para[vCount] = new SqlParameter("@MAST_MODEL_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_MODEL_KEY;
                para[vCount] = new SqlParameter("@SCHEDULE_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.SCHEDULE_DATE;
                para[vCount] = new SqlParameter("@FORM_TIME", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.FORM_TIME;
                para[vCount] = new SqlParameter("@TO_TIME", SqlDbType.VarChar, 50);
                para[vCount++].Value = oEntity.TO_TIME;

                para[vCount] = new SqlParameter("@ENT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.ENT_USER_KEY;
                para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.EDIT_USER_KEY;
                para[vCount] = new SqlParameter("@TAG_ACTIVE", SqlDbType.TinyInt);
                para[vCount++].Value = oEntity.TAG_ACTIVE;
                para[vCount] = new SqlParameter("@TAG_DELETE", SqlDbType.TinyInt);
                para[vCount++].Value = oEntity.TAG_DELETE;

                using (DBContext oDBC = new DBContext("SP_SAVE_MAST_SCHEDULE", CommandType.StoredProcedure))
                {
                    oDBC.ExecuteNonQuery(pAccYr, pCompany_key, para, ref pMsg);
                    vRef = Convert.ToByte(oDBC.GetParameterValue("@RETURN_KEY", ref pMsg));
                    pKey = (T2)Convert.ChangeType(oDBC.GetParameterValue("@MAST_SCHEDULE_KEY", ref pMsg), typeof(T2));
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return vRef;
        }

        public DataTable GetSchedule<T>(String pMode, T pKey, String pSEARCH_TEXT, ref String pMsg, String pAccYr, Int16? pCompany_key)
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

                using (DBContext oDBC = new DBContext("SP_GET_MAST_ROSTER", CommandType.StoredProcedure))
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

        public byte Delete<T>(String pMode, T pValue, ref T pKey, ref String pMsg, Int32 pUser, String pAccYr, Int16? pCompany_key)
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
                para[vCount] = new SqlParameter("@MAST_SCHEDULE_KEY", SqlDbType.Int);
                para[vCount].Direction = ParameterDirection.InputOutput;
                para[vCount++].Value = pValue;
                para[vCount] = new SqlParameter("@EDIT_USER_KEY", SqlDbType.Int);
                para[vCount++].Value = pUser;

                using (DBContext oDBC = new DBContext("SP_DELETE_MAST_SCHEDULE", CommandType.StoredProcedure))
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
