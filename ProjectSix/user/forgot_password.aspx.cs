using App.BAL.Setup;
using App.BAL.Utility;
using App.CORE.Domain.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectSix.user
{
    public partial class forgot_password : System.Web.UI.Page
    {
        String errMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void reset_password(object sender, EventArgs e)
        {
            Byte vRef = 0; Int32 vKey = 0;
            EntitySysUser oBMAST = null;
            EntitySysUser oSysUser = new EntitySysUser();

           

            try
            {
                if (Page.IsValid)
                {
                    errMsg = String.Empty;
                    oBMAST = new EntitySysUser();
                    if (Session["Email"] != null)
                    {
                        hf_USER_EMAIL.Value = Session["Email"].ToString();
                    }

                    oBMAST.USER_KEY = Convert.ToInt32(hf_USER_KEY.Value);
                    oBMAST.USER_EMAIL = hf_USER_EMAIL.Value;
                    oBMAST.USER_PASSWORD = Encrypt.Encryptdata(txt_PASS.Value);
                    oBMAST.USER_PASSWORD = Encrypt.Encryptdata(txt_CNFRM_PASS.Value);
                    oBMAST.COMPANY_KEY = 6;

                    oBMAST.TAG_DELETE = 0;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

                    using (BASysUser oBMC = new BASysUser())
                    {
                        if (txt_PASS.Value != null && txt_CNFRM_PASS.Value == txt_PASS.Value)
                        {
                            vRef = oBMC.SaveChanges<Object, Int32>("UPDATE_PASS", oBMAST, null, ref vKey, ref errMsg, "2019", 1);
                            if (vRef == 1)
                            {
                                ClearControl();
                                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "popup();", true);

                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "popupservererror", "popupservererror();", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "popuperror", "popuperror();", true);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Server error ! Try again later.'); console.log('" + ex.Message + "');", true);

            }
        }

        private void ClearControl()
        {
            txt_PASS.Value = "";
            txt_CNFRM_PASS.Value = "";
        }

    }
}