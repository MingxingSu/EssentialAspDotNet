using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace URL
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var useMessage = this.TextBox1.Text.Trim();

            string applicationPath = this.Request.ApplicationPath;

            string prefix = string.Format("/{{X{{{0}}}}}", useMessage);

            string newPath = this.AppRelativeVirtualPath.Replace("~", prefix);

            //配置Application_BeginRequest

            this.Response.Redirect(newPath);

            this.TextBox1.Text = string.Empty;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            this.Label1.Text = this.Context.Items["message"] as string;
        }
    }
}