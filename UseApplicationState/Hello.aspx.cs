using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseApplicationState
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = this.Application["userName"] == null ? string.Empty :  this.Application["userName"] ;
            this.Response.Write("Hello, " + userName);
        }
    }
}