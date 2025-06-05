using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Permissions;
using System.Web.Security;

namespace polymer_Web_ERP_V4
{
    public partial class polymer_ERPV2__0 : System.Web.UI.MasterPage
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            DailyProduction();
            MonthlyProduction();

            CheckOpenConnections();
        }

        protected void HomeImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/BusinessLayer/main-ERP.aspx");
        }

        protected void PreviousImageButton_Click(object sender, ImageClickEventArgs e)
        {
            string pageName = Path.GetFileName(Request.Url.AbsolutePath);  // We pul the page Name html by this code. 

            //prdSubMenu-ERP.aspx  Start code to redirect this page.   
            //AndSub of Subs
            //Child
            if (pageName == "productType-ERP.aspx" || pageName == "productTypeModify-ERP.aspx" || pageName == "productTypeDelete-ERP.aspx") // From ProducTypes to ProductType Sub Menu
            {
                Response.Redirect("productTypeSubMenu-ERP.aspx");
            }
            else if (pageName == "addPrdGroup-ERP.aspx" || pageName == "edditPrdGroup-ERP.aspx" || pageName == "deletePrdGroup-ERP.aspx" || pageName == "listPrdGroup-ERP.aspx")  // From ProducGroups to ProductGroups Sub Menu
            {
                Response.Redirect("prdGroupSubMenu-ERP.aspx");
            }

            else if (pageName == "addProduct-ERP.aspx" || pageName == "editProduct-ERP.aspx" || pageName == "deleteProduct-ERP.aspx" || pageName == "listProducts-ERP.aspx")
            {
                Response.Redirect("prdSubMenu-ERP.aspx");
            }


            //Mother
            else if (pageName == "productTypeSubMenu-ERP.aspx" || pageName == "prdGroupSubMenu-ERP.aspx" || pageName == "prdSubMenu-ERP.aspx")
            {
                Response.Redirect("productSubMenu-ERP.aspx");

            }




            //purchaseSubMenu_ERP  Start Code redirect to this page.
            //And Sub of Subs

            //Child
            else if (pageName == "addSellerGroup-ERP.aspx" || pageName == "editSellerGroup-ERP.aspx" || pageName == "deleteSellerGroup-ERP.aspx" || pageName == "listSellerGroup-ERP.aspx")
            {
                Response.Redirect("sellerGrpSubMenu-ERP.aspx");
            }

            else if (pageName == "addSeller-ERP.aspx" || pageName == "editSeller-ERP.aspx" || pageName == "deleteSeller-ERP.aspx" || pageName == "listSeller-ERP.aspx")
            {
                Response.Redirect("sellerSubMenu-ERP.aspx");
            }

            else if (pageName == "addPurchase-ERP.aspx" || pageName == "editPurchase-ERP.aspx" || pageName == "deletePurchase-ERP.aspx" || pageName == "listPurchase-ERP.aspx")
            {
                Response.Redirect("purchaseItemSubMenu-ERP.aspx");
            }


            //Mother
            else if (pageName == "sellerGrpSubMenu-ERP.aspx" || pageName == "sellerSubMenu-ERP.aspx" || pageName == "purchaseItemSubMenu-ERP.aspx")
            {
                Response.Redirect("purchaseSubMenu-ERP.aspx");
            }


            //washingSubMenu_ERP  Start Code redirect to this page.
            //And Sub of Subs

            //Child
            else if (pageName == "addWProduction-ERP.aspx" || pageName == "editWProduction-ERP.aspx" || pageName == "deleteWProduction-ERP.aspx" || pageName == "listWProduction-ERP.aspx")
            {
                Response.Redirect("washingSubMenu-ERP.aspx");
            }

            else if (pageName == "addGProduction-ERP.aspx" || pageName == "editGProduction-ERP.aspx" || pageName == "deleteGProduction-ERP.aspx" || pageName == "listGProduction-ERP.aspx")
            {
                Response.Redirect("granuleSubMenu-ERP.aspx");
            }

            //Mother
            else if (pageName == "washingSubMenu-ERP.aspx" || pageName == "granuleSubMenu-ERP.aspx")
            {
                Response.Redirect("productionSubMenu-ERP.aspx");
            }


            //Stock Start Code to this page  

            //Child

            else if (pageName == "addStockZone-ERP.aspx" || pageName == "edditStockZone-ERP.aspx" || pageName == "deleteStockZone-ERP.aspx" || pageName == "listStockZone-ERP.aspx")
            {
                Response.Redirect("stockZoneSubMenu-ERP.aspx");
            }

            // Mother

            else if (pageName == "stockZoneSubMenu-ERP.aspx")
            {
                Response.Redirect("stockSubMenu-ERP.aspx");
            }


            //Employee Code 

            else if (pageName == "addEmployee-ERP.aspx" || pageName == "editEmployee-ERP.aspx" || pageName == "deleteEmployee-ERP.aspx" || pageName == "listEmployee-ERP.aspx")
            {
                Response.Redirect("employeeSubMenu-ERP.aspx");
            }




            // Report Code 

            // Mother 


            else if (pageName == "reportsSubMenu-ERP.aspx")
            {
                Response.Redirect("~/BusinessLayer/main-ERP.aspx");
            }

            // Child

            else if (pageName == "euCertReports-ERP.aspx" || pageName == "productivityReports-ERP.aspx" )
            {
                Response.Redirect("reportsSubMenu-ERP.aspx");
            }

            else if (pageName == "currentAccountStatement.aspx" || pageName == "dailyGranuleProduction.aspx")
            {
                Response.Redirect("productivityReports-ERP.aspx");
            }

            // Sell Code 

            // Mother
            else if (pageName == "salesSubMenu-ERP.aspx")
            {
                Response.Redirect("~/BusinessLayer/main-ERP.aspx");
            }

            else if (pageName == "customerGrpSubMenu-ERP.aspx" || pageName == "customerSubMenu-ERP.aspx" || pageName== "sellSubMenu-ERP.aspx")
            {
                Response.Redirect("salesSubMenu-ERP.aspx");
            }


            // Child

            else if (pageName == "addCustomerGroup-ERP.aspx" || pageName == "editCustomerGroup-ERP.aspx" || pageName == "deleteCustomerGroup-ERP.aspx" || pageName == "listCustomerGroup-ERP.aspx")
            {
                Response.Redirect("customerGrpSubMenu-ERP.aspx");
            }

            else if (pageName == "addCustomer-ERP.aspx" || pageName == "editCustomer-ERP.aspx" || pageName == "deleteCustomer-ERP.aspx" || pageName == "listCustomer-ERP.aspx")
            {
                Response.Redirect("customerSubMenu-ERP.aspx");
            }

            else if (pageName == "shipmentSubMenu-ERP.aspx" || pageName == "invoiceSubMenu-ERP.aspx")
            {
                Response.Redirect("sellSubMenu-ERP.aspx");
            }

            else if (pageName == "addShipment-ERP.aspx" || pageName == "editShippment-ERP.aspx" || pageName == "deleteShipment-ERP.aspx" || pageName == "listShipment-ERP.aspx")
            {
                Response.Redirect("shipmentSubMenu-ERP.aspx");
            }

            else if (pageName == "addInvoice-ERP.aspx" || pageName == "editInvoice-ERP.aspx" || pageName == "deleteInvoice-ERP.aspx" || pageName == "listInvoice-ERP.aspx" || pageName == "invoiceShipTrace-ERP.aspx")
            {
                Response.Redirect("invoiceSubMenu-ERP.aspx");
            }



            //main-ERP.aspx Start Code redirect to this page.

            else if (pageName == "productSubMenu-ERP.aspx" || pageName == "purchaseSubMenu-ERP.aspx" || pageName == "stockSubMenu-ERP.aspx" || pageName == "productionSubMenu-ERP.aspx" || pageName == "employeeSubMenu-ERP.aspx")
            {
                Response.Redirect("~/BusinessLayer/main-ERP.aspx");
            }



            // Transaction Module 

            else if (pageName == "editTxnDetail-ERP.aspx" || pageName == "addTxnDetail-ERP.aspx" || pageName == "deleteTxnDetail-ERP.aspx" || pageName == "listTxnDetail-ERP.aspx")
            {
                Response.Redirect("txnDetailSubMenu-ERP.aspx");
            }





            //Accounting 

            //Mother Sub Menu 

            else if (pageName == "accountingSubMenu-ERP.aspx")
            {
                Response.Redirect("~/BusinessLayer/main-ERP.aspx");
            }

            //Child 

            else if (pageName == "txnSubMenu-ERP.aspx" || pageName == "progressSubMenu-ERP.aspx")
            {
                Response.Redirect("accountingSubMenu-ERP.aspx");
            }


            //Sub Child 

            else if (pageName == "addTxn-ERP.aspx" || pageName == "editTxn-ERP.aspx" || pageName == "deleteTxn-ERP.aspx" || pageName == "listTxn-ERP.aspx")
            {
                Response.Redirect("txnSubMenu-ERP.aspx");
            }

            else if (pageName == "addProgressPayment-ERP.aspx" || pageName == "editProgressPayment-ERP.aspx" || pageName == "deleteProgressPayment-ERP.aspx" || pageName == "listProgressPayment-ERP.aspx")
            {
                Response.Redirect("progressSubMenu-ERP.aspx");
            }




        }

        protected void DailyProduction()
        {


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_SumOutPutGranuleProductionDaily ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DailyQuantity_Label.Text = dt.Rows[0][0].ToString();
                    }

                }
            }

            /*
            string com = "execute prc_SumOutPutGranuleProductionDaily";
            SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);

            

            DailyQuantity_Label.Text = dt2.Rows[0][0].ToString(); 
            */
        }


        protected void MonthlyProduction()
        {

            MonthlyQuantity_Labe.Text = "120";

            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_SumOutPutGranuleProductionMonthly ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        MonthlyQuantity_Labe.Text = dt.Rows[0][0].ToString();
                    }

                }
            }

            /*
            string com = "execute prc_SumOutPutGranuleProductionMonthly";
            SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);



            MonthlyQuantity_Labe.Text = dt2.Rows[0][0].ToString();
            */
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        protected void SettingsImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void LogOutButton_Click(object sender, ImageClickEventArgs e)
        {
            // Assuming you are using Forms Authentication
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();

            Response.Redirect("~/Login.aspx");

        }


        private void CheckOpenConnections()
        {
            using (SqlConnection sqlConnection = conn.Connection())
            {
                // Execute the query to get the total number of connections
                SqlCommand cmd = new SqlCommand("SELECT COUNT(dbid) FROM sys.sysprocesses WHERE dbid > 0", sqlConnection);
                int totalConnections = (int)cmd.ExecuteScalar();

                // Log or display the total number of connections
                System.Diagnostics.Debug.WriteLine("total number of connections: " + totalConnections);
            }
        }

    }
}