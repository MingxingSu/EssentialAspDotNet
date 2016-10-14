using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FormsAuthenticationModel
{
    public partial class AspDotNetUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = this.User.Identity.Name;
            bool IsInrole = this.User.IsInRole("Administrator");

            Response.Write("Name:" + userName + ", IsInAdmin:" + IsInrole.ToString());

        }
    }
}