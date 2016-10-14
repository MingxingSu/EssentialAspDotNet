using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsePageOutCache
{
    public partial class NoPageCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToString();

        }
    }
}