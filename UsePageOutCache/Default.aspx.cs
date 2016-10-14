using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsePageOutCache
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label2.Text = "5";
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            this.Label1.Text = System.DateTime.Now.ToString();
        }
    }
}