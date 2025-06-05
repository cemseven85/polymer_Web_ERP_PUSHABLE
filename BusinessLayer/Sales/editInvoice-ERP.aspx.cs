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
    public partial class editInvoice_ERP : System.Web.UI.Page
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

        protected void editInvoiceButton_Click(object sender, EventArgs e)
        {
            Search_Panel.Visible = false;
            InvoiceDetailPanel.Visible = true;

            GridViewRow row = jQueryInvoiceListGridView.SelectedRow;
            string invoiceId = row.Cells[1].Text;
            string invoiceDate=row.Cells[2].Text;
            string invoiceCustomer=row.Cells[3].Text;
            string invoiceConsultant=row.Cells[4].Text;

            InvIdLabel.Text = invoiceId;
            DateLabel.Text = invoiceDate;
            CustomerLabel.Text = invoiceCustomer;
            ConsultantLabel.Text=invoiceConsultant;
            
            

            jQueryInvoiceDetailEditedGridViewBind(invoiceId);
            InvoiceDetailTotalAmountLabelBind();

            

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

        protected void jQueryInvoiceDetailGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            jQueryInvoiceDetailGridView.EditIndex = e.NewEditIndex;

            string InvoiceID = InvIdLabel.Text;

            jQueryInvoiceDetailEditedGridViewBind(InvoiceID);   // Trying to solve the binding prolem of Edititble TextBox


        }




        protected void jQueryInvoiceDetailGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            jQueryInvoiceDetailGridView.EditIndex = -1;

            string InvoiceID = InvIdLabel.Text;

            jQueryInvoiceDetailEditedGridViewBind(InvoiceID);   // Trying to solve the binding prolem of Edititble TextBox
        }


        //protected void jQueryInvoiceDetailGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    // Get the updated values from the edited row.
        //    GridViewRow row = jQueryInvoiceDetailGridView.Rows[e.RowIndex];
        //    TextBox txtInvQuantity = (TextBox)row.FindControl("txtInvoiceQuantity");
        //    TextBox txtUnitPrice = (TextBox)row.FindControl("txtUnitPrice");




        //    string txtUnitPriceDot = txtUnitPrice.Text;
        //    string txtInvQuantityDot = txtInvQuantity.Text;

        //    txtUnitPriceDot = txtUnitPriceDot.Replace(".", ",");  // We neet to make all doubles with ","
        //    txtInvQuantityDot = txtInvQuantityDot.Replace(".", ",");  // We neet to make all doubles with ",")

        //    // Assuming you have a way to identify the specific row, like "InvDetID"
        //    int invDetID = Convert.ToInt32(jQueryInvoiceDetailGridView.DataKeys[e.RowIndex].Values["InvDetID"]);
        //    int invID = Convert.ToInt32(jQueryInvoiceDetailGridView.DataKeys[e.RowIndex].Values["InvID"]);
        //    string invIDS = invID.ToString();
        //    // Get the updated values
        //    double updatedInvQuantity = Convert.ToDouble(txtInvQuantityDot);
        //    double updatedUnitPrice = Convert.ToDouble(txtUnitPriceDot);

        //    // First Invoice Detail 

        //    SqlCommand editItem = new SqlCommand($"update [tbl_invoiceDetail] set [invD_Quantity]=@updatedInvQuantity ,[invD_UnitPrice]=@updatedUnitPrice where [invD_ID]= '{invDetID}' ", conn.Connection());
        //    editItem.Parameters.Add("@updatedUnitPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(updatedUnitPrice, CultureInfo.CurrentCulture);
        //    editItem.Parameters.Add("@updatedInvQuantity", SqlDbType.Decimal).Value = Convert.ToDecimal(updatedInvQuantity, CultureInfo.CurrentCulture);


        //    editItem.ExecuteNonQuery();

        //    jQueryInvoiceDetailGridView.EditIndex = -1;
        //    jQueryInvoiceDetailEditedGridViewBind(invIDS);
        //    InvoiceDetailTotalAmountLabelBind();

        //}


        protected void jQueryInvoiceDetailGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get the updated values from the edited row.
            GridViewRow row = jQueryInvoiceDetailGridView.Rows[e.RowIndex];
            TextBox txtInvQuantity = (TextBox)row.FindControl("txtInvoiceQuantity");
            TextBox txtUnitPrice = (TextBox)row.FindControl("txtUnitPrice");

            string txtUnitPriceDot = txtUnitPrice.Text.Replace(".", ",");
            string txtInvQuantityDot = txtInvQuantity.Text.Replace(".", ",");

            // Assuming you have a way to identify the specific row, like "InvDetID"
            int invDetID = Convert.ToInt32(jQueryInvoiceDetailGridView.DataKeys[e.RowIndex].Values["InvDetID"]);
            int invID = Convert.ToInt32(jQueryInvoiceDetailGridView.DataKeys[e.RowIndex].Values["InvID"]);
            string invIDS = invID.ToString();

            // Get the updated values
            decimal updatedInvQuantity = Convert.ToDecimal(txtInvQuantityDot, CultureInfo.CurrentCulture);
            decimal updatedUnitPrice = Convert.ToDecimal(txtUnitPriceDot, CultureInfo.CurrentCulture);

            // Execute the update query using a using statement to handle connection properly
            using (SqlConnection connection = conn.Connection())
            {
                using (SqlCommand editItem = new SqlCommand($"UPDATE [tbl_invoiceDetail] SET [invD_Quantity]=@updatedInvQuantity, [invD_UnitPrice]=@updatedUnitPrice WHERE [invD_ID]=@invDetID", connection))
                {
                    editItem.Parameters.AddWithValue("@updatedUnitPrice", updatedUnitPrice);
                    editItem.Parameters.AddWithValue("@updatedInvQuantity", updatedInvQuantity);
                    editItem.Parameters.AddWithValue("@invDetID", invDetID);

                    editItem.ExecuteNonQuery();
                }
            }

            jQueryInvoiceDetailGridView.EditIndex = -1;
            jQueryInvoiceDetailEditedGridViewBind(invIDS);
            InvoiceDetailTotalAmountLabelBind();
        }


        private void InvoiceDetailTotalAmountLabelBind()
        {
            double totalAmount = 0;
            string totalAmountStrEuro="";
            string totalAmountStr = "";

            double VATAmount = 0;
            string VATAmountStrEuro = "";
            string VATAmountStr = "";

            double VATIncludeAmount = 0;
            string VATIncludeAmountStrEuro = "";
            string VATIncludeAmountStr = "";


            foreach (GridViewRow row in jQueryInvoiceDetailGridView.Rows)
            {
                totalAmountStrEuro = row.Cells[8].Text;
                totalAmountStr = totalAmountStrEuro.Remove(totalAmountStrEuro.Length - 1, 1);
                totalAmount = totalAmount + Convert.ToDouble(totalAmountStr);
                VATAmountStrEuro = row.Cells[9].Text;
                VATAmountStr = VATAmountStrEuro.Remove(VATAmountStrEuro.Length - 1, 1);
                VATAmount = VATAmount + Convert.ToDouble(VATAmountStr);
                VATIncludeAmountStrEuro = row.Cells[10].Text;
                VATIncludeAmountStr = VATIncludeAmountStrEuro.Remove(VATIncludeAmountStrEuro.Length - 1, 1);
                VATIncludeAmount = VATIncludeAmount + Convert.ToDouble(VATIncludeAmountStr);

            }



            TotalAmountLabel.Text = totalAmount.ToString("N2") + " Leva";
            VATAmountLabel.Text = VATAmount.ToString("N2") + " Leva";
            VATIncludedAmountLabel.Text = VATIncludeAmount.ToString("N2") + " Leva";

        }

        //protected void CloseInvoiceButton_Click(object sender, EventArgs e)
        //{


        //    // We start to Edit TXN We start to Edit TXN  We start to Edit TXN We start to Edit TXN
        //    // In this module we can just eddit the unit Price and Quantitiy. 
        //    // This will change the amount ouf TXN and nothing else. 

        //    // First we need the txnID for UdDating that from this Invoice. 
        //    // Need to pull purID  for the TxnId

        //    GridViewRow row = jQueryInvoiceListGridView.SelectedRow;
        //    string invoiceId = row.Cells[1].Text;


        //    // Pull txnID

        //    string pullTxnID = $"SELECT [txn_Id] FROM [tbl_invoice]\r\nWHERE [inv_ID] = '{invoiceId}'";
        //    SqlDataAdapter adpt10 = new SqlDataAdapter(pullTxnID, conn.Connection());
        //    DataTable dt10 = new DataTable();
        //    adpt10.Fill(dt10);
        //    string txnID = dt10.Rows[0][0].ToString();


        //    string txnAmount = VATIncludedAmountLabel.Text;  // need to trim the currency symbol form string. 
        //    txnAmount = txnAmount.Remove(txnAmount.Length - 1, 1);


        //    /// Edit the TXN 

        //    SqlCommand editTXN = new SqlCommand($"update [tbl_transactions] set [txn_Debit]=@txnAmount where [txn_ID]= '{txnID}' ", conn.Connection());
        //    editTXN.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmount, CultureInfo.CurrentCulture);
        //    editTXN.ExecuteNonQuery();



        //    Response.Redirect("~/BusinessLayer/main-ERP.aspx");
        //}


        protected void CloseInvoiceButton_Click(object sender, EventArgs e)
        {
            // Retrieve the invoice ID from the selected row
            GridViewRow row = jQueryInvoiceListGridView.SelectedRow;
            string invoiceId = row.Cells[1].Text;

            // Pull txnID from the invoice
            string pullTxnID = $"SELECT [txn_Id] FROM [tbl_invoice] WHERE [inv_ID] = '{invoiceId}'";
            string txnID;

            // Execute the query to get the txnID using a using statement to handle connection properly
            using (SqlConnection connection = conn.Connection())
            {
                using (SqlDataAdapter adpt10 = new SqlDataAdapter(pullTxnID, connection))
                {
                    DataTable dt10 = new DataTable();
                    adpt10.Fill(dt10);
                    txnID = dt10.Rows[0][0].ToString();
                }
            }

            // Retrieve the txn amount from the VATIncludedAmountLabel and remove the currency symbol
            string txnAmount = VATIncludedAmountLabel.Text;
            txnAmount = txnAmount.Remove(txnAmount.Length - 4, 4);

            // Edit the txn amount
            using (SqlConnection connection = conn.Connection())
            {
                using (SqlCommand editTXN = new SqlCommand($"UPDATE [tbl_transactions] SET [txn_Debit]=@txnAmount WHERE [txn_ID]=@txnID", connection))
                {
                    editTXN.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmount, CultureInfo.CurrentCulture);
                    editTXN.Parameters.AddWithValue("@txnID", txnID);
                    editTXN.ExecuteNonQuery();
                }
            }

            // Redirect to the main ERP page after closing the invoice
            Response.Redirect("~/BusinessLayer/main-ERP.aspx");
        }






    }
}