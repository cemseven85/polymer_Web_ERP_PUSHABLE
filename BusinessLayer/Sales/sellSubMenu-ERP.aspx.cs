using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class sellSubMenu_ERP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void shipmentButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("shipmentSubMenu-ERP.aspx");
        }

        protected void invoiceButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("invoiceSubMenu-ERP.aspx");
        }

        
    }
}