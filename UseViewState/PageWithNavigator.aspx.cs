using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseViewState
{
    public partial class PageWithNavigator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected PathNavigator Navigator 
        {
            set { this.ViewState["navi"] = value; }
            get 
            {
                var nav = this.ViewState["navi"] as PathNavigator;

                if(nav == null)
                {
                    nav = new PathNavigator();
                    this.ViewState["navi"] = nav;
                }
                return nav;

            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            this.Navigator.Prev();
            this.Label1.Text = this.Navigator.Path;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            this.Navigator.Next();
            this.Label1.Text = this.Navigator.Path;
        }

        protected void btnNavi_Click(object sender, EventArgs e)
        {
            this.Navigator.Enter(this.textUrl.Text);

            this.Label1.Text = this.textUrl.Text;
            this.textUrl.Text= string.Empty;
        }
    }
}