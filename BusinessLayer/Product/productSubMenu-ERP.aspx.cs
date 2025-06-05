using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class productSubMenu_ERP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void productTypeButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("productTypeSubMenu-ERP.aspx");
        }

        protected void productGroupButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("prdGroupSubMenu-ERP.aspx");
        }

        protected void productButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("prdSubMenu-ERP.aspx");
        }
    }
}