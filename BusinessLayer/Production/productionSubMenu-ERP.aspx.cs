using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class productionSubMenu_ERP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void forklitftButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("washingSubMenu-ERP.aspx");
        }

        protected void sortButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("washingSubMenu-ERP.aspx");
        }

        protected void shreddingButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("washingSubMenu-ERP.aspx");
        }

        protected void washingButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("washingSubMenu-ERP.aspx");
        }

        protected void extrusionButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("granuleSubMenu-ERP.aspx");
        }
    }
}