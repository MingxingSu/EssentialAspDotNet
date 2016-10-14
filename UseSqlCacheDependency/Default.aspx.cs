using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseSqlCacheDependency
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //ALTER DATABASE TestSqlDependency SET ENABLE_BROKER;
            this.GridView1.DataSource = CacheManager.Users;

            this.GridView1.DataBind();
        }
    }
}