using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using App.CORE.Domain;
using App.DAL;

namespace App.BAL
{
    public class BAReport : IDisposable
    {
        Int16 vCount = 0;
        DataTable dt = null;
        SqlParameter[] para = null;
        EntityReport oEntity = null;


        public DataTable FillRORegisterAll(string pRectype, EntityReport oEntity, ref String pMsg, string pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[10];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = "RO_RPT";
                para[vCount] = new SqlParameter("@START_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.START_DATE;
                para[vCount] = new SqlParameter("@END_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.END_DATE;
                para[vCount] = new SqlParameter("@MAST_BRANCH_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_BRANCH_KEY;
                para[vCount] = new SqlParameter("@MAST_EDITION_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_EDITION_KEY;
                para[vCount] = new SqlParameter("@MAST_PUBLICATION_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_PUBLICATION_KEY;
                para[vCount] = new SqlParameter("@PUBLISHER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.PUBLISHER_KEY;
                para[vCount] = new SqlParameter("@MAST_LEDGER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_LEDGER_KEY;
                para[vCount] = new SqlParameter("@INS_START_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.INS_START_DATE;
                para[vCount] = new SqlParameter("@INS_END_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.INS_END_DATE;

                using (DBContext oDBC = new DBContext("SP_GET_RPT_PRESS_MEDIA_RO", CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, para, ref pMsg);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
            finally
            {
                dt = null;
            }
        }

        public DataTable FillEMRORegisterAll(string pRectype, EntityReport oEntity, ref String pMsg, string pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[8];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = "RO_RPT";
                para[vCount] = new SqlParameter("@START_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.START_DATE;
                para[vCount] = new SqlParameter("@END_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.END_DATE;
                para[vCount] = new SqlParameter("@MAST_BRANCH_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_BRANCH_KEY;
                para[vCount] = new SqlParameter("@PUBLISHER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.PUBLISHER_KEY;
                para[vCount] = new SqlParameter("@MAST_CHANNEL_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_CHANNEL_KEY;
                para[vCount] = new SqlParameter("@MAST_LEDGER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_LEDGER_KEY;
                para[vCount] = new SqlParameter("@MAST_STAFF_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_STAFF_KEY;

                using (DBContext oDBC = new DBContext("SP_GET_RPT_ELECTRONIC_MEDIA_RO", CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, para, ref pMsg);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
            finally
            {
                dt = null;
            }
        }

        public DataTable FillEventRORegisterAll(string pRectype, EntityReport oEntity, ref String pMsg, string pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[7];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = "RO_RPT";
                para[vCount] = new SqlParameter("@START_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.START_DATE;
                para[vCount] = new SqlParameter("@END_DATE", SqlDbType.DateTime);
                para[vCount++].Value = oEntity.END_DATE;
                para[vCount] = new SqlParameter("@MAST_BRANCH_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_BRANCH_KEY;
                para[vCount] = new SqlParameter("@PUBLISHER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.PUBLISHER_KEY;
                para[vCount] = new SqlParameter("@MAST_LEDGER_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_LEDGER_KEY;
                para[vCount] = new SqlParameter("@MAST_STAFF_KEY", SqlDbType.Int);
                para[vCount++].Value = oEntity.MAST_STAFF_KEY;

                using (DBContext oDBC = new DBContext("SP_GET_RPT_RO_EVENT", CommandType.StoredProcedure))
                {
                    dt = oDBC.GetDataTable(pAccYr, pCompany_key, para, ref pMsg);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
            finally
            {
                dt = null;
            }
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
