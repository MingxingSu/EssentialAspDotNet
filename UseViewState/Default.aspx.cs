using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseViewState
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User user = new User(this.TextBox1.Text);
            user.Email = this.TextBox2.Text;

            this.ViewState["User"] = user;

            this.TextBox2.Text = string.Empty;
            this.TextBox1.Text = string.Empty;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            var user = this.ViewState["User"] as User;
            this.Label1.Text = "Hi," + user.UserName + ",Your Email is :" + user.Email;
        }
    }
}