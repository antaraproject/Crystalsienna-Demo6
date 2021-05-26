using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectOne.user
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            if (Session["oSysUser"] != null)
                Session["oSysUser"] = null;

            HttpCookie cookie = Request.Cookies["__asd"];
            if (cookie != null)
            {
                cookie.Value = "";
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);

                Response.Cookies.Clear();

            }
            HttpContext.Current.Request.Cookies.Clear();
            // Server.Transfer("/index.aspx");

            // HttpCookie __asd = new HttpCookie("__asd", "");

            // Response.Cookies.Set(__asd);

            Response.Redirect("~/index.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}