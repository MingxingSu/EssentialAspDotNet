using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseViewState
{
    public partial class UseIStateManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User user = new User(this.TextBox1.Text);
            user.Email = this.TextBox2.Text;

            //SavePageStateToPersisenceMedium->PageStatePersister->IStateFormatter: LosFormatter->ObjectStateFormatter
            ObjectStateFormatter formatter = new ObjectStateFormatter();

            string base64 = formatter.Serialize(user);

            //ViewStatement of Page disabled
            this.HiddenField1.Value = base64;

            this.TextBox2.Text = string.Empty;
            this.TextBox1.Text = string.Empty;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            ObjectStateFormatter formatter = new ObjectStateFormatter();
            var user = formatter.Deserialize(this.HiddenField1.Value) as User;

            this.Label1.Text = "Hi," + user.UserName + ",Your Email is :" + user.Email;
        }
    }
}