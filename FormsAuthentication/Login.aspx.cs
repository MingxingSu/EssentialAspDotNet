using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

namespace FormsAuthenticationModel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Write("Hello, welcome, this is a FormsAuthentication");

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //compare credentials, true
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                this.textbookUsername.Text.Trim(),
                DateTime.Now,
                DateTime.Now.AddDays(3),
                true,
                string.Empty
                );

            //serialize tickets 
            string  cookiString = System.Web.Security.FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName);
            cookie.Value = cookiString;
            cookie.Expires = DateTime.Now.AddDays(3);

            this.Response.Cookies.Add(cookie);

            this.btnLogin.Text = "Cookies created,You has Logged In";
            //Cookies被我导出保存在：C:\Users\Max\Documents\cookies.txt                 
        }

        protected void btnLoginRedirect_Click(object sender, EventArgs e) 
        {
            FormsAuthentication.RedirectFromLoginPage(this.textbookUsername.Text.Trim(), true, "~/Default.aspx");
        }
    }
}