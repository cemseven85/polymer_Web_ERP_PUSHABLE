using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class accountingSubMenu_ERP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void progressPaymentsButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("progressSubMenu-ERP.aspx");
        }

        protected void transactionsButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("txnSubMenu-ERP.aspx");
        }
    }
}