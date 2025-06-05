using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class prdGroupSubMenu_ERP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addItemButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("addPrdGroup-ERP.aspx");
        }

        protected void editItemButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("edditPrdGroup-ERP.aspx");
        }

        protected void deleteItemButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("deletePrdGroup-ERP.aspx");
            
        }

        protected void listItemButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("listPrdGroup-ERP.aspx");
        }
    }
}