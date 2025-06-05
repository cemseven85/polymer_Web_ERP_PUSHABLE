using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class reportsSubMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void euCertButton_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("euCertReports-ERP.aspx");
        }

        protected void productivityButton_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("productivityReports-ERP.aspx");
        }
    }
}