using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FormsAuthenticationModel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Retrieve cookie from the request
            var context = HttpContext.Current;

            var cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];

            string userName = string.Empty;

            if (cookie != null) 
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                userName = ticket.Name;
            }

            context.Response.Write(String.Format("Hi,{0}, Welcome, you already logged in !",userName));


        }
    }
}