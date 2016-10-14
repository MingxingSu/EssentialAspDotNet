using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseHiddenField
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //the first request
        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.StateContainer.Value = this.textUsername.Text.Trim();
            this.textUsername.Text = "";
        }

        //the second request: we can get the value of hidden, as  Form action POST will send the hidden value to webserver
        protected void btnGet_Click(object sender, EventArgs e)
        {
            this.lblResult.Text = this.StateContainer.Value;
        }
    }
}