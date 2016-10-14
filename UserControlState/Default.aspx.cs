using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControlState
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomWebControls.ControlStateControl control = new CustomWebControls.ControlStateControl();
            control.ControlStateText = "hello";
        }
    }
}