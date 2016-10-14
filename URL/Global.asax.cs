using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace URL
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //parse Url
            Regex regex = new Regex(@"\{X\{(.*)\}\}/"); // "/{X{Max}}/Default.aspx", Match:"{Max}}/"

            var match = regex.Match(this.Request.Path);

            if (match.Success) 
            {
                this.Context.Items["message"] = match.Groups[1].Value;//Save to single request cache
                string path2 = regex.Replace(this.Request.Path, string.Empty);
                this.Context.RewritePath(path2);
            }


        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}