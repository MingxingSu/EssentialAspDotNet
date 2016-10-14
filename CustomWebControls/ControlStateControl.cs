using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomWebControls
{
    public class ControlStateControl : WebControl
    {
        private string _controlStateText;

        public string ControlStateText
        {
            get { return _controlStateText; }
            set { _controlStateText = value; }
        }

        public string ViewStateText
        {
            get
            {
                if (ViewState["ViewStateText"].Equals(null))
                {
                    return string.Empty;
                }
                else
                {
                    return ViewState["ViewStateText"].ToString();
                }
            }
            set
            {
                ViewState["ViewStateText"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            Page.RegisterRequiresControlState(this);
            base.OnInit(e);
        }

        protected override object SaveControlState()
        {
            return _controlStateText;
        }

        protected override void LoadControlState(object savedState)
        {
            _controlStateText = savedState.ToString();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("ViewStateText:" + ViewStateText);
            writer.WriteBreak();
            writer.Write("ControlStateText:" + ControlStateText);
            writer.WriteBreak();
        }
    }
}
