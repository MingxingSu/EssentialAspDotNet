using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseApplicationState
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Application.Add("userName", this.TextBox1.Text);
            
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            Server.TransferRequest("~/Hello.aspx");
        }
    }
}