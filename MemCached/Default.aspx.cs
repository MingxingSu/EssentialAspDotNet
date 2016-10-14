using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemcachedProviders.Cache;
namespace MemCached
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MemcachedProviders.Cache.DistCache.Add("user", this.TextBox1.Text);
            MemcachedProviders.Cache.DistCache.Add("email", this.TextBox2.Text);
            this.TextBox1.Text = String.Empty;
            this.TextBox2.Text = string.Empty;

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            this.Label1.Text = "Hello, " + DistCache.Get("user").ToString() + ", your email is :" + DistCache.Get("email").ToString();
        }
    }
}