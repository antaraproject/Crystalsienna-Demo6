using App.BAL;
using App.BAL.Setup;
using App.BAL.Utility;
using App.CORE.Domain.Setup;
using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace ProjectSix.admin
{
    public partial class index : System.Web.UI.Page
    {
        String errMsg = String.Empty;
        EntitySysUser oSysUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                HttpCookie cookie = Request.Cookies["__ubc"];
                if (cookie != null)
                {
                    string username = cookie["a"];
                    string password = cookie["p"];

                    DataTable dt = null;
                    Int32 vRef = 0;
                    using (BASysUser oBSU = new BASysUser())
                    {
                        dt = oBSU.Get<Int16>("TYPE_1", 0, Encrypt.Decryptdata(username), 1, ref errMsg, null, null);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (password == Encrypt.EncryptASCII(Encrypt.Decryptdata(Convert.ToString(dr["USER_PASSWORD"]))))
                            {
                                setUserSession(dr);
                                vRef = 1;
                            }
                        }

                        if (vRef == 1)
                            Response.Redirect("~/admin/dashboard.aspx");
                    }
                }
            }
        }



        private void MessageBox(String strMsg, String exMsg)
        {
            if (!(String.IsNullOrEmpty(exMsg)))
                exMsg = CommonOp.ModifyExceptionMessage(exMsg);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "OpenPopup('" + strMsg + "', '" + exMsg + "')", true);
        }

        private void setUserSession(DataRow dr)
        {
            oSysUser = new EntitySysUser();
            oSysUser.USER_KEY = Convert.ToInt16(dr["USER_KEY"]);
            oSysUser.USER_NAME = Convert.ToString(dr["USER_NAME"]);
            oSysUser.USER_TYPE_KEY = Convert.ToInt32(dr["USER_TYPE_KEY"]);
            oSysUser.USER_TYPE = Convert.ToString(dr["USER_TYPE"]);
            oSysUser.MAST_HRD_PERSONNEL_KEY = Convert.ToInt32(dr["MAST_HRD_PERSONNEL_KEY"]);

            Session["oSysUser"] = oSysUser;
        }

        protected void btn_sign_in_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DataTable dt = null;
                try
                {
                    Int32 vRef = 0;
                    using (BASysUser oBSU = new BASysUser())
                    {
                        dt = oBSU.Get<Int16>("TYPE_1", 0, txt_User_Id.Text, 1, ref errMsg, null, null);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (Encrypt.Encryptdata(txt_Password.Text) == Convert.ToString(dr["USER_PASSWORD"]))
                            {
                                setUserSession(dr);

                                HttpCookie objCookie = new HttpCookie("__ubc");
                                objCookie["a"] = Encrypt.Encryptdata(txt_User_Id.Text).ToString();
                                objCookie["p"] = Encrypt.EncryptASCII(txt_Password.Text).ToString();
                                objCookie.Expires = DateTime.Now.AddDays(60);
                                Response.Cookies.Add(objCookie);
                                vRef = 1;
                            }
                        }
                        if (vRef == 1)
                            Response.Redirect("~/admin/dashboard.aspx");
                        else
                            MessageBox(Message.msgErr401, errMsg);
                    }
                    else
                        MessageBox(Message.msgErrPage, errMsg);
                }
                catch (Exception ex)
                {
                    MessageBox(Message.msgErrCommon, ex.Message);
                }
                finally
                {
                    if (oSysUser != null)
                        oSysUser = null;
                    if (dt != null)
                    {
                        dt.Dispose(); dt = null;
                    }
                }
            }
        }
    }
}