using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class purchaseSubMenu_ERP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sellerGroupButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("sellerGrpSubMenu-ERP.aspx");
        }

        protected void sellerButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("sellerSubMenu-ERP.aspx");
        }

        protected void purchaseButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("purchaseItemSubMenu-ERP.aspx");
        }
    }
}