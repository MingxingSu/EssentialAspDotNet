using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cookies
{
    public partial class Cookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("WelcomeMessage", "Welcome," + this.textUsername.Text.Trim());
            cookie.Path = ".localhost";
            this.Response.Cookies.Add(cookie);
            
            this.textUsername.Text = string.Empty;
            this.textUsername.Visible = false;

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            var cookie = this.Request.Cookies["WelcomeMessage"];

            if (cookie != null)
            {

                this.lblResult.Text = cookie.Value;
            }
            else {
                this.lblResult.Text = "Cookie expired";
            }
            

        }
    }
}