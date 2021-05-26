using System;
using System.Web;

namespace ProjectSix.admin
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            if (Session["oSysUser"] != null)
                Session["oSysUser"] = null;

            HttpCookie cookie = Request.Cookies["__ubc"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }


            Server.Transfer("index.aspx");
        }
    }
}