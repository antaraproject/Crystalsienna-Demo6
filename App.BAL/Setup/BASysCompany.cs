using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using App.CORE.Domain.Setup;
using App.CORE.Repositories.Setup;
using App.DAL;

namespace App.BAL.Setup
{
    public class BASysCompany : ISysCompany
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
                para[vCount++].Value = "DDL_COM";

                using (CommonOp oCommonOp = new CommonOp())
                {
                    oCommonOp.BindDropDownList("SP_GET_SYS_COMPANY", ref ddl, "COMPANY_KEY", "COMPANY_NAME", ref pMsg, pAccYr, pCompany_key, para);
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }

        public void BindDdlCom(ref DropDownList ddl, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[1];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = "DDL";

                using (CommonOp oCommonOp = new CommonOp())
                {
                    oCommonOp.BindDropDownList("SP_GET_SYS_COMPANY", ref ddl, "COMPANY_KEY", "COMPANY_NAME", ref pMsg, pAccYr, pCompany_key, para);
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }

        public void BindChkBox(ref CheckBoxList chk, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            try
            {
                vCount = 0;
                para = new SqlParameter[1];
                para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
                para[vCount++].Value = "DDL";

                using (CommonOp oCommonOp = new CommonOp())
                {
                    oCommonOp.BindCheckBoxList("SP_GET_SYS_COMPANY", ref chk, "COMPANY_KEY", "COMPANY_NAME", ref pMsg, pAccYr, pCompany_key, para);
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
                para[vCount] = new SqlParameter("@COMPANY_KEY", SqlDbType.SmallInt);
                para[vCount++].Value = pKey;
                para[vCount] = new SqlParameter("@COMPANY_NAME", SqlDbType.VarChar, 100);
                para[vCount++].Value = pSEARCH_TEXT;

                using (DBContext oDBC = new DBContext("SP_GET_SYS_COMPANY", CommandType.StoredProcedure))
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

        public Byte SaveChanges<T1, T2>(String pMode, EntitySysCompany oEntity, T1 pValue, ref T2 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
        {
            throw new System.NotImplementedException();
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
