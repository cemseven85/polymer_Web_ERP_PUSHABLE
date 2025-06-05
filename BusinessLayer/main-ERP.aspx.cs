using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class main_ERP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        protected void productButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessLayer/Product/productSubMenu-ERP.aspx");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        protected void purchaseButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessLayer/Purchase/purchaseSubMenu-ERP.aspx");
        }


        protected void productionButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessLayer/Production/productionSubMenu-ERP.aspx");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        protected void stockButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("stockSubMenu-ERP.aspx");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        protected void employeeButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessLayer/Employee/employeeSubMenu-ERP.aspx");
        }

        
        protected void reportButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessLayer/Reports/reportsSubMenu-ERP.aspx");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        protected void saleseButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessLayer/Sales/salesSubMenu-ERP.aspx");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        protected void accounting_Button_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessLayer/Accounting/accountingSubMenu-ERP.aspx");
        }
    }
}