using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyHttpHandlers
{
    public partial class UploadProgress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.DiskFileUpload_GUID.SaveAs(Path.Combine(Request.AppRelativeCurrentExecutionFilePath, Guid.NewGuid().ToString()));

        }
  

    }
}
