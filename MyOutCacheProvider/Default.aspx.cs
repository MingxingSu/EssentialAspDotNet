using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyOutCacheProvider
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            this.Cache.Add("msg", "Hello" + this.TextBox1.Text + ",Your email is : " + this.TextBox2.Text,
                null,
                DateTime.Now.AddDays(1),//2 hours
                TimeSpan.Zero,
                System.Web.Caching.CacheItemPriority.Normal,
                null);

            this.TextBox1.Text = string.Empty;
            this.TextBox2.Text = string.Empty;

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            this.Label1.Text = this.Cache["msg"] as string;
        }
    }
}