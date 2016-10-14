using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseHttpContextItems
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Write(this.Context.Items["msg"] as string);
        }

        protected override void OnInit(EventArgs e)
        {
            this.Context.Items.Add("msg", "I am the message from OnInit method");
            base.OnInit(e);
        }
    }
}