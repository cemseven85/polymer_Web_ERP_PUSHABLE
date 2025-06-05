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

namespace polymer_Web_ERP_V4
{
    public partial class deleteShipment_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateMax = DateTime.Now;
            DateTime dateMin = dateMax.AddDays(-90);


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
            GridViewRow row = jQueryShipGridView.SelectedRow;

            if (row != null)
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
        //    GridViewRow row = jQueryShipGridView.SelectedRow;

        //    if (row != null)
        //    {

        //        string shipID = row.Cells[2].Text;

        //        // Delete all sales rows from tbl_sales that has got the  same 'shipID'
        //        SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_sales] WHERE [shipping_Id] = '{shipID}'", conn.Connection());
        //        cmd.ExecuteNonQuery();

        //        // Delete shipping from tbl_shipping  that has got the  same 'shipID'
        //        SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_shipping] WHERE [ship_Id] = '{shipID}'", conn.Connection());
        //        cmd2.ExecuteNonQuery();


        //        Response.Redirect("deleteShipment-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Shippment');</script>");
        //    }


        //}


        protected void RunButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryShipGridView.SelectedRow;

            if (row != null)
            {
                string shipID = row.Cells[2].Text;

                using (SqlConnection connection = conn.Connection())
                {
                    // Delete all sales rows from tbl_sales that have the same 'shipID'
                    using (SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_sales] WHERE [shipping_Id] = '{shipID}'", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Delete shipping from tbl_shipping that has the same 'shipID'
                    using (SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_shipping] WHERE [ship_Id] = '{shipID}'", connection))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                }

                Response.Redirect("deleteShipment-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Shipment');</script>");
            }
        }


    }
}