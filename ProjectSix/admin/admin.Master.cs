using System;
using System.Web;

namespace ProjectSix.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["oSysUser"] == null)
                {
                    Response.Redirect("~/admin/index.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}