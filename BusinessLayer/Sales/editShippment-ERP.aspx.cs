using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Globalization;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.IO;

namespace polymer_Web_ERP_V4
{
    public partial class editShippment_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateMax = DateTime.Now;
            DateTime dateMin = DateTime.Now;

            if (!this.IsPostBack)
            {

                ItemDateMin_TextBox.Text = dateMin.ToString("yyyy-MM-dd");
                ItemDateMax_TextBox.Text = dateMax.ToString("yyyy-MM-dd");

              
            }

        }


        private void jQueryShipGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listShipments '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryShipGridView.DataSource = dt;
                        jQueryShipGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryShipGridView.UseAccessibleHeader = true;
            jQueryShipGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryShippGridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryShipGridViewBind();

            if (jQueryShipGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryShipGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryShipGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryShipGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }




        private void jQueryShipDetailGridViewBind()
        {
            // Write a try   catch  Exception Handling  !!!!

            GridViewRow row = jQueryShipGridView.SelectedRow;

            if (row != null)
            {
                string shipID = row.Cells[2].Text;

            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_shippingDetail '{shipID}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryShipDetailGridView.DataSource = dt;
                        jQueryShipDetailGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryShipDetailGridView.UseAccessibleHeader = true;
            jQueryShipDetailGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            
            }

            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Shippment');</script>");

            }
        }

            
        protected void jQueryShipDetailGridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryShipDetailGridViewBind();

            if (jQueryShipDetailGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryShipDetailGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryShipDetailGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryShipDetailGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        private void jQueryShipItemListGridViewBind()
        {

            // Write a try   catch  Exception Handling  !!!!
             
            
            
            GridViewRow row = jQueryShipGridView.SelectedRow;
            
            if(row != null) 
            {
                string shipID = row.Cells[2].Text;


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listShippingItems '{shipID}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryShipItemListGridView.DataSource = dt;
                        jQueryShipItemListGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryShipItemListGridView.UseAccessibleHeader = true;
            jQueryShipItemListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            
            
            
            }
            
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Shippment');</script>");
            }
             
            

            
        }


        protected void jQueryShipItemListGridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryShipItemListGridViewBind();

            if (jQueryShipItemListGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryShipItemListGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryShipItemListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryShipItemListGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        protected void ShowShippmentButton_Click(object sender, EventArgs e)
        {
            jQueryShipGridViewBind();
        }

        protected void ShipSummeryButton_Click(object sender, EventArgs e)
        {

            jQueryShipDetailGridViewBind();

        }

        protected void ShipItemsButton_Click(object sender, EventArgs e)
        {
            jQueryShipItemListGridViewBind();

        }

        //protected void RunButton_Click(object sender, EventArgs e)
        //{
        //    string shipId=" ";
        //    string salesID;
        //    string quantitiyItem;
        //    double quantityUnLoad=0;

        //    bool isAtLeastOneCheckboxChecked = false;


        //    foreach (GridViewRow row in jQueryShipItemListGridView.Rows)
        //    {
        //        // Check if the current row is selected
        //        CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
        //        if (cbSelect.Checked)
        //        {

        //            isAtLeastOneCheckboxChecked = true;     // Control If at least one Item Checked for Unload

        //            // Get the data from the selected row

        //            salesID = string.Format(row.Cells[1].Text);
        //            quantitiyItem = string.Format(row.Cells[5].Text);
        //            shipId = string.Format(row.Cells[2].Text);

        //            //Add item sell items

        //            SqlCommand unLoadItemSell = new SqlCommand($"delete from tbl_sales where [sales_Id]='{salesID}' ", conn.Connection());

        //            unLoadItemSell.ExecuteNonQuery();



        //            quantityUnLoad += double.Parse(quantitiyItem);

        //        }
        //    }

        //    if (isAtLeastOneCheckboxChecked == true)
        //    {
        //        // Edditing shipment Quantity with  Sum all quantityShip 

        //        SqlCommand editship = new SqlCommand($"update[tbl_shipping] set[ship_Quantity] = ([ship_Quantity] - '{quantityUnLoad}') where[ship_Id]= '{shipId}' ", conn.Connection());

        //        editship.ExecuteNonQuery();

        //        // Eddit shipment Table if the Quantity of Shipment Not More Than 1 Then Delete the Shipment.

        //        SqlCommand deleteship = new SqlCommand($"delete from tbl_shipping where ship_Quantity<'1' ", conn.Connection());

        //        deleteship.ExecuteNonQuery();



        //        Response.Redirect("editShippment-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write("<script>alert('You need to choose at least one item for UnLoad')</script>");
        //    }


        //}

        protected void RunButton_Click(object sender, EventArgs e)
        {
            string shipId = " ";
            string salesID;
            string quantitiyItem;
            double quantityUnLoad = 0;

            bool isAtLeastOneCheckboxChecked = false;

            foreach (GridViewRow row in jQueryShipItemListGridView.Rows)
            {
                // Check if the current row is selected
                CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
                if (cbSelect.Checked)
                {
                    isAtLeastOneCheckboxChecked = true; // Control If at least one Item Checked for Unload

                    // Get the data from the selected row
                    salesID = string.Format(row.Cells[1].Text);
                    quantitiyItem = string.Format(row.Cells[5].Text);
                    shipId = string.Format(row.Cells[2].Text);

                    // Add item sell items
                    using (SqlConnection connection = conn.Connection())
                    {
                        SqlCommand unLoadItemSell = new SqlCommand($"DELETE FROM tbl_sales WHERE [sales_Id]=@salesID", connection);
                        unLoadItemSell.Parameters.AddWithValue("@salesID", salesID);
                        unLoadItemSell.ExecuteNonQuery();
                    }

                    quantityUnLoad += double.Parse(quantitiyItem);
                }
            }

            if (isAtLeastOneCheckboxChecked)
            {
                // Editing shipment Quantity with Sum all quantityShip 
                using (SqlConnection connection = conn.Connection())
                {
                    SqlCommand editship = new SqlCommand($"UPDATE [tbl_shipping] SET [ship_Quantity] = ([ship_Quantity] - @quantityUnLoad) WHERE [ship_Id]=@shipId", connection);
                    editship.Parameters.AddWithValue("@quantityUnLoad", quantityUnLoad);
                    editship.Parameters.AddWithValue("@shipId", shipId);
                    editship.ExecuteNonQuery();

                    // Edit shipment Table if the Quantity of Shipment Not More Than 1 Then Delete the Shipment.
                    SqlCommand deleteship = new SqlCommand($"DELETE FROM tbl_shipping WHERE ship_Quantity < '1'", connection);
                    deleteship.ExecuteNonQuery();
                }

                Response.Redirect("editShippment-ERP.aspx");
            }
            else
            {
                Response.Write("<script>alert('You need to choose at least one item for UnLoad')</script>");
            }
        }

    }
}