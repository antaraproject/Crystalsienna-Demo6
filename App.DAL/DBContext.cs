using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.DAL
{
    public sealed class DBContext : IDisposable
    {
        //private bool pDisposed = false;
        private String vSrvName = ConfigurationManager.AppSettings["SrvName"];
        //private String vDBMast = ConfigurationManager.AppSettings["DBMast"];
        //private String vDBTrans = ConfigurationManager.AppSettings["DBTrans"];
        private String vDBName = String.Empty;
        private String vDBUser = ConfigurationManager.AppSettings["DBUser"];
        private String vPassPW = ConfigurationManager.AppSettings["PassPW"];
        private String vConTimeOut = ConfigurationManager.AppSettings["ConTimeOut"];

        private String conStr = String.Empty;
        private SqlCommand oCmd = null;
        private SqlDataAdapter da = null;

        DataTable dt = null;

        // Get parameter from Sqlcommand by id
        public SqlParameter this[Int32 id]
        {
            get
            {
                return oCmd.Parameters[id];
            }
        }

        // Get parameter from Sqlcommand by name
        public SqlParameter this[String name]
        {
            get
            {
                return oCmd.Parameters[name];
            }
        }

        public DBContext()
        {
            oCmd = new SqlCommand();
            oCmd.CommandTimeout = Convert.ToInt32(vConTimeOut);
        }

        public DBContext(String pSqlString, CommandType pCmdType)
        {
            oCmd = new SqlCommand();
            oCmd.CommandText = pSqlString;
            oCmd.CommandType = pCmdType;
            oCmd.CommandTimeout = Convert.ToInt32(vConTimeOut);
        }

        //private String DBCompanySuffix(Int16 pCompany_key)
        //{
        //    switch (pCompany_key)
        //    {
        //        case 1: return "SAFA";
        //        case 2: return "SAFA";
        //        default: return "";
        //    }
        //}

        /// <summary>
        /// Connection String Generation
        /// </summary>
        /// <returns></returns>
        private String GetConStr(String pAccYr, Int16? pCompany_key)
        {
            //Int16 vAccYr = 0;
            try
            {
                conStr = String.Empty;
                //if (String.IsNullOrEmpty(pAccYr) && pCompany_key != null && Convert.ToInt16(pCompany_key) > 0)
                //{
                //    vDBName = String.Format(ConfigurationManager.AppSettings["DBMast"], ConfigurationManager.AppSettings["Company" + pCompany_key.ToString()]);
                //    conStr = "Data Source=" + vSrvName + "; Initial Catalog=" + vDBName + "; User Id=" + vDBUser + "; ";
                //    conStr += "Password=" + vPassPW + "; Connect Timeout= " + vConTimeOut + "; pooling='true'; Max Pool Size=200;";
                //}
                //else if (!(String.IsNullOrEmpty(pAccYr)) && pCompany_key != null && Convert.ToInt16(pCompany_key) > 0)
                //{
                //    //vAccYr = Convert.ToInt16(pAccYr.Substring(2, 2));
                //    vDBName = String.Format(ConfigurationManager.AppSettings["DBTrans"], ConfigurationManager.AppSettings["Company" + pCompany_key.ToString()]);//, vAccYr.ToString() + "_" + (vAccYr + 1).ToString()
                //    conStr = "Data Source=" + vSrvName + "; Initial Catalog=" + vDBName + "; User Id=" + vDBUser + "; ";
                //    conStr += "Password=" + vPassPW + "; Connect Timeout= " + vConTimeOut + "; pooling='true'; Max Pool Size=200;";
                //}
                //else
                //{
                    conStr = ConfigurationManager.ConnectionStrings["CON_NAME"].ConnectionString;
                    conStr += ";Connect Timeout= " + vConTimeOut + "; pooling='true'; Max Pool Size=200;";
                //}
                return conStr;
            }
            catch
            {
                return String.Empty;
            }
        }

        public Object GetParameterValue(Int16 pId, ref String pMsg)
        {
            try
            {
                return (Object)this[pId].Value;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
        }

        public Object GetParameterValue(String pName, ref String pMsg)
        {
            try
            {
                return (Object)this[pName].Value;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
        }

        public DataTable GetDataTable(String pAccYr, Int16? pCompany_key, ref String pMsg)
        {
            try
            {
                dt = new DataTable();
                da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(GetConStr(pAccYr, pCompany_key)))
                {
                    oCmd.Connection = con;
                    da.SelectCommand = oCmd;
                    con.Open();
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
        }

        public DataTable GetDataTable(String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList, ref String pMsg)
        {
            try
            {
                dt = new DataTable();
                da = new SqlDataAdapter();
                foreach (SqlParameter vParam in pParamList)
                {
                    if (vParam != null)
                        oCmd.Parameters.Add(vParam);
                    else
                    {
                        pMsg = "Parameter list must not contain null.";
                        return null;
                    }
                }
                using (SqlConnection con = new SqlConnection(GetConStr(pAccYr, pCompany_key)))
                {
                    oCmd.Connection = con;
                    da.SelectCommand = oCmd;
                    con.Open();
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
        }

        public DataSet GetDataSet(String pAccYr, Int16? pCompany_key, ref String pMsg)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(GetConStr(pAccYr, pCompany_key)))
                {
                    oCmd.Connection = con;
                    da.SelectCommand = oCmd;
                    con.Open();
                    da.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose(); ds = null;
                }
            }
        }

        public DataSet GetDataSet(String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList, ref String pMsg)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                da = new SqlDataAdapter();
                foreach (SqlParameter vParam in pParamList)
                {
                    if (vParam != null)
                        oCmd.Parameters.Add(vParam);
                    else
                    {
                        pMsg = "Parameter list must not contain null.";
                        return null;
                    }
                }
                using (SqlConnection con = new SqlConnection(GetConStr(pAccYr, pCompany_key)))
                {
                    oCmd.Connection = con;
                    da.SelectCommand = oCmd;
                    con.Open();
                    da.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
                return null;
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose(); ds = null;
                }
            }
        }

        /// <summary>
        /// Command Execution
        /// </summary>
        /// <param name="p_Command"></param>
        public Object ExecuteScaler(String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList, ref String pMsg)
        {
            Object oRet = null;
            try
            {
                foreach (SqlParameter vParam in pParamList)
                {
                    if (vParam != null)
                        oCmd.Parameters.Add(vParam);
                    else
                    {
                        pMsg = "Parameter list must not contain null.";
                        return oRet;
                    }
                }
                using (SqlConnection con = new SqlConnection(GetConStr(pAccYr, pCompany_key)))
                {
                    oCmd.Connection = con;
                    con.Open();
                    oRet = oCmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
            return oRet;
        }

        public void ExecuteNonQuery(String pAccYr, Int16? pCompany_key, SqlParameter[] pParamList, ref String pMsg)
        {
            try
            {
                foreach (SqlParameter vParam in pParamList)
                {
                    if (vParam != null)
                        oCmd.Parameters.Add(vParam);
                    else
                    {
                        pMsg = "Parameter list must not contain null.";
                        return;
                    }
                }
                using (SqlConnection con = new SqlConnection(GetConStr(pAccYr, pCompany_key)))
                {
                    oCmd.Connection = con;
                    con.Open();
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.Message;
            }
        }

        /// <summary>
        /// Resource Management
        /// </summary>
        public void Dispose()
        {
            //Dispose(true);
            if (dt != null)
            {
                dt.Dispose(); dt = null;
            }
            if (da != null)
            {
                da.Dispose(); da = null;
            }
            if (oCmd != null)
            {
                oCmd.Dispose(); oCmd = null;
            }
            //GC.SuppressFinalize(this);
        }
    }
}
