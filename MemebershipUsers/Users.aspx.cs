using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemebershipUsers
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipCreateStatus status;
            System.Web.Security.Membership.CreateUser("Mingxing", "P@ssWord1!", "max210119851@hotmail.com", "are you Max?", "sure", true, out status);
            System.Web.Security.Membership.CreateUser("Mingxing1", "P@ssWord2!", "max210119852@hotmail.com", "are you Max?", "sure", true, out status);
            System.Web.Security.Membership.CreateUser("Mingxing2", "P@ssWord3!", "max210119853@hotmail.com", "are you Max?", "sure", true, out status);
            System.Web.Security.Membership.CreateUser("Mingxing3", "P@ssWord4!", "max210119854@hotmail.com", "are you Max?", "sure", true, out status);

            var userList = System.Web.Security.Membership.GetAllUsers();

            foreach (MembershipUser user in userList)
            {
                this.Response.Write(user.UserName);
            }

        }
    }
}