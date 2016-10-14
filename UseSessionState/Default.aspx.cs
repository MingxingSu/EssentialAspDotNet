using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseSessionState
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Session.Add("userName", this.TextBox1.Text);
            this.TextBox1.Text = string.Empty;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            this.Server.TransferRequest("~/Hello.aspx");
        }
    }
}