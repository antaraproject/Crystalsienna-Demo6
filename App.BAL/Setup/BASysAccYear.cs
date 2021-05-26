using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;
using App.CORE.Domain.Setup;
using App.CORE.Repositories.Setup;
using App.DAL;

namespace App.BAL.Setup
{
   public class BASysAccYear : ISysAccYear
   {
       Int16 vCount = 0;
       DataTable dt = null;
       SqlParameter[] para = null;

       public void BindDdl(ref DropDownList ddl, Int16 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
       {
           try
           {
               vCount = 0;
               para = new SqlParameter[2];
               para[vCount] = new SqlParameter("@GET_REC_TYPE", SqlDbType.VarChar, 20);
               para[vCount++].Value = "DDL";
               para[vCount] = new SqlParameter("@COMPANY_KEY", SqlDbType.SmallInt);
               para[vCount++].Value = pKey == 0 ? SqlInt16.Null : pKey;

               using (CommonOp oCommonOp = new CommonOp())
               {
                   oCommonOp.BindDropDownList("SP_GET_SYS_ACC_YEAR", ref ddl, "ACCOUNTING_YEAR_KEY", "ACCOUNTING_YEAR", ref pMsg, pAccYr, pCompany_key, para);
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
               para[vCount] = new SqlParameter("@COMPANY_KEY", SqlDbType.Int);
               para[vCount++].Value = pKey;
               para[vCount] = new SqlParameter("@ACCOUNTING_YEAR", SqlDbType.VarChar, 9);
               para[vCount++].Value = pSEARCH_TEXT;

               using (DBContext oDBC = new DBContext("SP_GET_SYS_ACC_YEAR", CommandType.StoredProcedure))
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

       public Byte SaveChanges<T1, T2>(String pMode, EntitySysAccYear oEntity, T1 pValue, ref T2 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key)
       {
           throw new NotImplementedException();
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
