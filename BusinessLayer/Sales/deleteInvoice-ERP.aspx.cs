using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Drawing;

using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;   // From Here Name Spaces Are For Exel File Transfer 
using Excel = Microsoft.Office.Interop.Excel;  //Before  Excel =   Data Tables And Exels Send Error. 
using System.Globalization;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace polymer_Web_ERP_V4
{
    public partial class deleteInvoice_ERP : System.Web.UI.Page
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


                InvoiceDetailPanel.Visible = false;
            }

        }

        private void jQueryInvoiceListGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listInvoice '{ItemDateMin_TextBox.Text}' , '{ItemDateMax_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryInvoiceListGridView.DataSource = dt;
                        jQueryInvoiceListGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryInvoiceListGridView.UseAccessibleHeader = true;
            jQueryInvoiceListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryInvoiceListGridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryInvoiceListGridViewBind();

            if (jQueryInvoiceListGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryInvoiceListGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryInvoiceListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryInvoiceListGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        protected void ShowInvoiceListButton_Click(object sender, EventArgs e)
        {
            jQueryInvoiceListGridViewBind();
        }

        //protected void deleteInvoiceButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryInvoiceListGridView.SelectedRow;
        //    string invoiceID = row.Cells[1].Text;


        //    // Pull txnID after you delete the Invoice you can not pull the TXN ID 

        //    string pullTxnID = $"SELECT [txn_Id] FROM [tbl_invoice]\r\nWHERE [inv_ID] = '{invoiceID}'";
        //    SqlDataAdapter adpt10 = new SqlDataAdapter(pullTxnID, conn.Connection());
        //    DataTable dt10 = new DataTable();
        //    adpt10.Fill(dt10);
        //    string txnID = dt10.Rows[0][0].ToString();



        //    // Delete all invoiceDetail rows from tbl_invoiceDetail that has got the  same 'invoiceID'
        //    SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_invoiceDetail] WHERE [inv_ID] = '{invoiceID}'", conn.Connection());
        //    cmd.ExecuteNonQuery();

        //    // Delete shipping from tbl_shipping  that has got the  same 'shipID'
        //    SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_invoiceShip] WHERE [inv_ID] = '{invoiceID}'", conn.Connection());
        //    cmd2.ExecuteNonQuery();

        //    // Delete shipping from tbl_shipping  that has got the  same 'shipID'
        //    SqlCommand cmd3 = new SqlCommand($"DELETE FROM [tbl_invoice] WHERE [inv_ID] = '{invoiceID}'", conn.Connection());
        //    cmd3.ExecuteNonQuery();




        //    // DELETE The related TXN 



        //    // Delete shipping from tbl_shipping  that has got the  same 'shipID'
        //    SqlCommand cmd10 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txnID}'", conn.Connection());
        //    cmd10.ExecuteNonQuery();



        //    Response.Redirect("deleteInvoice-ERP.aspx");

        //}


        protected void deleteInvoiceButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryInvoiceListGridView.SelectedRow;
            string invoiceID = row.Cells[1].Text;

            // Pull txnID after you delete the Invoice you can not pull the TXN ID 
            string pullTxnID = $"SELECT [txn_Id] FROM [tbl_invoice]\r\nWHERE [inv_ID] = '{invoiceID}'";

            string txnID;

            using (SqlConnection connection = conn.Connection())
            {
                using (SqlDataAdapter adpt10 = new SqlDataAdapter(pullTxnID, connection))
                {
                    DataTable dt10 = new DataTable();
                    adpt10.Fill(dt10);
                    txnID = dt10.Rows[0][0].ToString();
                }

                // Delete all invoiceDetail rows from tbl_invoiceDetail that have the same 'invoiceID'
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_invoiceDetail] WHERE [inv_ID] = '{invoiceID}'", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // Delete invoiceShipment from tbl_invoiceShip that has the same 'invoiceID'
                using (SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_invoiceShip] WHERE [inv_ID] = '{invoiceID}'", connection))
                {
                    cmd2.ExecuteNonQuery();
                }

                // Delete invoice from tbl_invoice that has the same 'invoiceID'
                using (SqlCommand cmd3 = new SqlCommand($"DELETE FROM [tbl_invoice] WHERE [inv_ID] = '{invoiceID}'", connection))
                {
                    cmd3.ExecuteNonQuery();
                }

                // DELETE The related TXN 
                using (SqlCommand cmd10 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txnID}'", connection))
                {
                    cmd10.ExecuteNonQuery();
                }
            }

            Response.Redirect("deleteInvoice-ERP.aspx");
        }



        private void jQueryInvoiceDetailEditedGridViewBind(string invID)
        {



            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listInvoiceDetailEditedList '{invID}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryInvoiceDetailGridView.DataSource = dt;
                        jQueryInvoiceDetailGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryInvoiceDetailGridView.UseAccessibleHeader = true;
            jQueryInvoiceDetailGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        private void InvoiceDetailTotalAmountLabelBind()
        {
            double totalAmount = 0;
            string totalAmountStrEuro = "";
            string totalAmountStr = "";

            double VATAmount = 0;
            string VATAmountStrEuro = "";
            string VATAmountStr = "";

            double VATIncludeAmount = 0;
            string VATIncludeAmountStrEuro = "";
            string VATIncludeAmountStr = "";


            foreach (GridViewRow row in jQueryInvoiceDetailGridView.Rows)
            {
                totalAmountStrEuro = row.Cells[7].Text;
                totalAmountStr = totalAmountStrEuro.Remove(totalAmountStrEuro.Length - 1, 1);
                totalAmount = totalAmount + Convert.ToDouble(totalAmountStr);
                VATAmountStrEuro = row.Cells[8].Text;
                VATAmountStr = VATAmountStrEuro.Remove(VATAmountStrEuro.Length - 1, 1);
                VATAmount = VATAmount + Convert.ToDouble(VATAmountStr);
                VATIncludeAmountStrEuro = row.Cells[9].Text;
                VATIncludeAmountStr = VATIncludeAmountStrEuro.Remove(VATIncludeAmountStrEuro.Length - 1, 1);
                VATIncludeAmount = VATIncludeAmount + Convert.ToDouble(VATIncludeAmountStr);

            }



            TotalAmountLabel.Text = totalAmount.ToString("N2") + " Leva";
            VATAmountLabel.Text = VATAmount.ToString("N2") + " Leva";
            VATIncludedAmountLabel.Text = VATIncludeAmount.ToString("N2") + " Leva";

        }



        protected void showDetailButton_Click(object sender, EventArgs e)
        {
            InvoiceDetailPanel.Visible = true;

            GridViewRow row = jQueryInvoiceListGridView.SelectedRow;
            string invoiceId = row.Cells[1].Text;
            string invoiceDate = row.Cells[2].Text;
            string invoiceCustomer = row.Cells[3].Text;
            string invoiceConsultant = row.Cells[4].Text;

            InvIdLabel.Text = invoiceId;
            DateLabel.Text = invoiceDate;
            CustomerLabel.Text = invoiceCustomer;
            ConsultantLabel.Text = invoiceConsultant;

            jQueryInvoiceDetailEditedGridViewBind(invoiceId);
            InvoiceDetailTotalAmountLabelBind();
        }


       



    }
}