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
    public partial class addInvoice_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateMax = DateTime.Now;
            DateTime dateMin = dateMax.AddDays(-30);


            if (!this.IsPostBack)
            {

                ItemDateMin_TextBox.Text = dateMin.ToString("yyyy-MM-dd");
                ItemDateMax_TextBox.Text = dateMax.ToString("yyyy-MM-dd");

                MinDateUnBilledShipmentTextBox.Text = dateMin.ToString("yyyy-MM-dd");
                MaxDateUnBilledShipmentTextBox.Text = dateMax.ToString("yyyy-MM-dd");

                AllShipDetailPanel.Visible = false;
                AllShipItemsPanel.Visible = false;

                SelectedShipDetailPanel.Visible = false;
                SelectedShipItemsPanel.Visible = false;

                Search_Panel.Visible = false;
                InvoiceDetailPanel.Visible = false;
                DropDownConsultantBind();
                DropDownVATBind();

                InvoiceDateTextBox.Text = dateMax.ToString("yyyy-MM-dd");

                
            }

        }

        private void jQueryShipGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listUnBilledShipments '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}'", con))
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
                    using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_shippingLDetail '{shipID}'", con))
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

        // We decide not to PreRander chiled GridViews.

        private void jQueryAllShipDetailGridViewBind()
        {


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_shippingUnBilledSumDetail '{ItemDateMin_TextBox.Text}' , '{ItemDateMax_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryAllShipDetailGridView.DataSource = dt;
                        jQueryAllShipDetailGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryAllShipDetailGridView.UseAccessibleHeader = true;
            jQueryAllShipDetailGridView.HeaderRow.TableSection = TableRowSection.TableHeader;



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
                    using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listLShippingItems '{shipID}'", con))
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



        private void jQueryAllShipItemListGridViewBind()
        {


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listUnBilledSumShippingItems '{ItemDateMin_TextBox.Text}' ,'{ItemDateMax_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryAllShipItemListGridView.DataSource = dt;
                        jQueryAllShipItemListGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryAllShipItemListGridView.UseAccessibleHeader = true;
            jQueryAllShipItemListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        private void jQueryUnBilledShipmentsGridViewBind()
        {


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_shippingUnBilledSumDetail '{MinDateUnBilledShipmentTextBox.Text}','{MaxDateUnBilledShipmentTextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryUnBilledShipmentsGridView.DataSource = dt;
                        jQueryUnBilledShipmentsGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryUnBilledShipmentsGridView.UseAccessibleHeader = true;
            jQueryUnBilledShipmentsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;



        }



        //private void DropDownConsultantBind()
        //{
        //    string com = $"Select * from [tbl_consultant]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);

        //    // Add a default data  "Select Consultatnt" to data table  


        //    DataRow defaultRow = dt2.NewRow();
        //    defaultRow["cnslt_Id"]=DBNull.Value;
        //    defaultRow["cnslt_Name"] = "Select";
        //    dt2.Rows.InsertAt(defaultRow, 0);


        //    ConsultantDropDownList.DataSource = dt2;
        //    ConsultantDropDownList.DataBind();
        //    ConsultantDropDownList.DataTextField = "cnslt_Name";
        //    ConsultantDropDownList.DataValueField = "cnslt_Id";
        //    ConsultantDropDownList.DataBind();
        //}

        //private void DropDownVATBind()
        //{
        //    string com = $"Select * from tbl_VAT";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    VATDropDownList.DataSource = dt2;
        //    VATDropDownList.DataBind();
        //    VATDropDownList.DataTextField = "vat_Name";
        //    VATDropDownList.DataValueField = "vat_Id";
        //    VATDropDownList.DataBind();
        //}



        private void DropDownConsultantBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = "SELECT * FROM [tbl_consultant]";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);

                    // Add a default data "Select Consultant" to data table  
                    DataRow defaultRow = dt2.NewRow();
                    defaultRow["cnslt_Id"] = DBNull.Value;
                    defaultRow["cnslt_Name"] = "Select";
                    dt2.Rows.InsertAt(defaultRow, 0);

                    ConsultantDropDownList.DataSource = dt2;
                    ConsultantDropDownList.DataTextField = "cnslt_Name";
                    ConsultantDropDownList.DataValueField = "cnslt_Id";
                    ConsultantDropDownList.DataBind();
                }
            }
        }

        private void DropDownVATBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = "SELECT * FROM tbl_VAT";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    VATDropDownList.DataSource = dt2;
                    VATDropDownList.DataTextField = "vat_Name";
                    VATDropDownList.DataValueField = "vat_Id";
                    VATDropDownList.DataBind();
                }
            }
        }


        private void jQueryInvoiceDetailGridViewBind(string invID)
        {

            string vatId;

            vatId = VATDropDownList.SelectedItem.Value;


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listInvoiceDetailList '{invID}' ,'{vatId}'", con))   //Note we add the Invoice Detail Row In This Procedure !!!
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



        protected void ShowShippmentButton_Click(object sender, EventArgs e)
        {
            AllShipDetailPanel.Visible = false;
            AllShipItemsPanel.Visible = false;

            SelectedShipDetailPanel.Visible = false;
            SelectedShipItemsPanel.Visible = false;
            jQueryShipGridViewBind();


            MinDateUnBilledShipmentTextBox.Text = ItemDateMin_TextBox.Text;
            MaxDateUnBilledShipmentTextBox.Text = ItemDateMax_TextBox.Text;


        }

        protected void ShipSummeryButton_Click(object sender, EventArgs e)
        {
            SelectedShipDetailPanel.Visible = true;
            AllShipDetailPanel.Visible = false;
            jQueryShipDetailGridViewBind();


        }

        protected void AllShipSummeryButton_Click(object sender, EventArgs e)
        {
            AllShipDetailPanel.Visible = true;
            SelectedShipDetailPanel.Visible = false;
            jQueryAllShipDetailGridViewBind();


        }

        protected void ShipItemsButton_Click(object sender, EventArgs e)
        {
            SelectedShipItemsPanel.Visible = true;
            AllShipItemsPanel.Visible = false;
            jQueryShipItemListGridViewBind();

        }

        protected void AllShipItemsButton_Click(object sender, EventArgs e)
        {
            AllShipItemsPanel.Visible = true;
            SelectedShipItemsPanel.Visible = false;
            jQueryAllShipItemListGridViewBind();

        }

        protected void ShowUnBilledShippmentButton_Click(object sender, EventArgs e)
        {
            jQueryUnBilledShipmentsGridViewBind();

            ClosePanelButton_Click(sender, e);   // How can I call SubGraphButton_Click(object sender, RoutedEventArgs args) from another method?


        }

/*
        protected void jQueryUnBilledShipmentsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            jQueryUnBilledShipmentsGridView.EditIndex = e.NewEditIndex;

        }
        protected void jQueryUnBilledShipmentsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            jQueryUnBilledShipmentsGridView.EditIndex = -1;

        }


        protected void jQueryUnBilledShipmentsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            jQueryUnBilledShipmentsGridView.EditIndex = -1;

        }

*/

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

            string txtUnitPriceDot = txtUnitPrice.Text;
            string txtInvQuantityDot = txtInvQuantity.Text;

            txtUnitPriceDot = txtUnitPriceDot.Replace(".", ",");
            txtInvQuantityDot = txtInvQuantityDot.Replace(".", ",");

            // Assuming you have a way to identify the specific row, like "InvDetID"
            int invDetID = Convert.ToInt32(jQueryInvoiceDetailGridView.DataKeys[e.RowIndex].Values["InvDetID"]);
            int invID = Convert.ToInt32(jQueryInvoiceDetailGridView.DataKeys[e.RowIndex].Values["InvID"]);
            string invIDS = invID.ToString();

            // Get the updated values
            double updatedInvQuantity = Convert.ToDouble(txtInvQuantityDot);
            double updatedUnitPrice = Convert.ToDouble(txtUnitPriceDot);

            using (SqlConnection connection = conn.Connection())
            {
                

                using (SqlCommand editItem = new SqlCommand($"UPDATE [tbl_invoiceDetail] SET [invD_Quantity]=@updatedInvQuantity ,[invD_UnitPrice]=@updatedUnitPrice WHERE [invD_ID]= '{invDetID}'", connection))
                {
                    editItem.Parameters.Add("@updatedUnitPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(updatedUnitPrice, CultureInfo.CurrentCulture);
                    editItem.Parameters.Add("@updatedInvQuantity", SqlDbType.Decimal).Value = Convert.ToDecimal(updatedInvQuantity, CultureInfo.CurrentCulture);
                    editItem.ExecuteNonQuery();
                }
            }

            jQueryInvoiceDetailGridView.EditIndex = -1;
            jQueryInvoiceDetailEditedGridViewBind(invIDS);
            InvoiceDetailTotalAmountLabelBind();
        }




        //private void InvoiceDetailTotalAmountLabelBind()
        //{
        //    double totalAmount = 0;
        //    string totalAmountStrEuro = "";
        //    string totalAmountStr = "";

        //    double VATAmount = 0;
        //    string VATAmountStrEuro = "";
        //    string VATAmountStr = "";

        //    double VATIncludeAmount = 0;
        //    string VATIncludeAmountStrEuro = "";
        //    string VATIncludeAmountStr = "";


        //    foreach (GridViewRow row in jQueryInvoiceDetailGridView.Rows)
        //    {
        //        totalAmountStrEuro = row.Cells[8].Text;
        //        totalAmountStr = totalAmountStrEuro.Remove(totalAmountStrEuro.Length - 1, 1);
        //        totalAmount = totalAmount + Convert.ToDouble(totalAmountStr);
        //        VATAmountStrEuro = row.Cells[9].Text;
        //        VATAmountStr = VATAmountStrEuro.Remove(VATAmountStrEuro.Length - 1, 1);
        //        VATAmount = VATAmount + Convert.ToDouble(VATAmountStr);
        //        VATIncludeAmountStrEuro = row.Cells[10].Text;
        //        VATIncludeAmountStr = VATIncludeAmountStrEuro.Remove(VATIncludeAmountStrEuro.Length - 1, 1);
        //        VATIncludeAmount = VATIncludeAmount + Convert.ToDouble(VATIncludeAmountStr);

        //    }



        //    TotalAmountLabel.Text = totalAmount.ToString("N2") + " Leva";
        //    VATAmountLabel.Text = VATAmount.ToString("N2") + " Leva";
        //    VATIncludedAmountLabel.Text = VATIncludeAmount.ToString("N2") + " Leva";

        //}


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

            using (SqlConnection connection = conn.Connection())
            {
               

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
            }

            TotalAmountLabel.Text = totalAmount.ToString("N2") + " Leva";
            VATAmountLabel.Text = VATAmount.ToString("N2") + " Leva";
            VATIncludedAmountLabel.Text = VATIncludeAmount.ToString("N2") + " Leva";
        }



        protected void ExcelButtonLSh_Click(object sender, EventArgs e)
        {
            // Create a new Excel application object

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Create a new workbook
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            int numRows = jQueryShipGridView.Rows.Count;   // Pulls number of Rows.
            if (numRows > 0)
            {
                int numColumns = jQueryShipGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

                    worksheet.Columns[i + 2].ColumnWidth = 21;

                }

                worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

                worksheet.Name = "Shipment List";





                // Create a header row

                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1] = jQueryShipGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
                }

                // Add data to the worksheet

                String tempValue = "";
                DateTime dateValue;
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numColumns; j++)
                    {
                        if (j == 1)    // Column That Has To Changed to Date Format  
                        {
                            tempValue = jQueryShipGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                           // tempValue = tempValue.Substring(0, 10);
                            dateValue = DateTime.ParseExact(tempValue, "yyyy/MM/dd", null);
                            worksheet.Cells[i + 2, j + 1] = dateValue;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = jQueryShipGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                        }

                    }

                }


                // Change columns text to number which you need to 

                int ColumnIndex = 5;


                worksheet.Columns[ColumnIndex].TextToColumns();
                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


                //Change columns text to Date which you need to 
                // I solved it in this part Add data to the worksheet  





                // Add filter to data  

                worksheet.Range["1:1"].AutoFilter(5, ">=0");



                /*
                // Save the workbook and close the Excel application
                workbook.SaveAs("MyData.xlsx");
                workbook.Close();
                excelApp.Quit();
                */

            }
            else
            {

            }

        }


        protected void ExcelButtonLShD_Click(object sender, EventArgs e)
        {
            // Create a new Excel application object

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Create a new workbook
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            int numRows = jQueryShipDetailGridView.Rows.Count;   // Pulls number of Rows.
            if (numRows > 0)
            {
                int numColumns = jQueryShipDetailGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

                    worksheet.Columns[i + 2].ColumnWidth = 21;

                }

                worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

                worksheet.Name = "Selected Ship Summary";





                // Create a header row

                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1] = jQueryShipDetailGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
                }

                // Add data to the worksheet

                String tempValue = "";
                DateTime dateValue;
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numColumns; j++)
                    {
                        if (j == 1)    // Column That Has To Changed to Date Format  
                        {
                            tempValue = jQueryShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            tempValue = tempValue.Substring(0, 10);
                            dateValue = DateTime.ParseExact(tempValue, "yyyy/MM/dd", null);
                            worksheet.Cells[i + 2, j + 1] = dateValue;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = jQueryShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                        }

                    }

                }


                // Change columns text to number which you need to 

                int ColumnIndex = 5;


                worksheet.Columns[ColumnIndex].TextToColumns();
                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


                //Change columns text to Date which you need to 
                // I solved it in this part Add data to the worksheet  





                // Add filter to data  

                worksheet.Range["1:1"].AutoFilter(5, ">0");



                /*
                // Save the workbook and close the Excel application
                workbook.SaveAs("MyData.xlsx");
                workbook.Close();
                excelApp.Quit();
                */

            }
            else
            {

            }

        }


        protected void ExcelButtonLAllShD_Click(object sender, EventArgs e)
        {
            // Create a new Excel application object

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Create a new workbook
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            int numRows = jQueryAllShipDetailGridView.Rows.Count;   // Pulls number of Rows.
            if (numRows > 0)
            {
                int numColumns = jQueryAllShipDetailGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

                    worksheet.Columns[i + 2].ColumnWidth = 21;

                }

                worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

                worksheet.Name = "All Ship Summary";





                // Create a header row

                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1] = jQueryAllShipDetailGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
                }

                // Add data to the worksheet

                String tempValue = "";
                DateTime dateValue;
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numColumns; j++)
                    {
                        if (j == 1)    // Column That Has To Changed to Date Format  
                        {
                            tempValue = jQueryAllShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            tempValue = tempValue.Substring(0, 10);
                            dateValue = DateTime.ParseExact(tempValue, "yyyy/MM/dd", null);
                            worksheet.Cells[i + 2, j + 1] = dateValue;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = jQueryAllShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                        }

                    }

                }


                // Change columns text to number which you need to 

                int ColumnIndex = 5;


                worksheet.Columns[ColumnIndex].TextToColumns();
                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


                //Change columns text to Date which you need to 
                // I solved it in this part Add data to the worksheet  





                // Add filter to data  

                worksheet.Range["1:1"].AutoFilter(5, ">0");



                /*
                // Save the workbook and close the Excel application
                workbook.SaveAs("MyData.xlsx");
                workbook.Close();
                excelApp.Quit();
                */

            }
            else
            {

            }

        }



        protected void ExcelButtonLShI_Click(object sender, EventArgs e)
        {
            // Create a new Excel application object

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Create a new workbook
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            int numRows = jQueryShipItemListGridView.Rows.Count;   // Pulls number of Rows.
            if (numRows > 0)
            {
                int numColumns = jQueryShipItemListGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

                    worksheet.Columns[i + 2].ColumnWidth = 21;

                }

                worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

                worksheet.Name = "Selected Ship Item List";





                // Create a header row

                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1] = jQueryShipItemListGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
                }

                // Add data to the worksheet

                String tempValue = "";
                DateTime dateValue;
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numColumns; j++)
                    {
                        if (j == 1)    // Column That Has To Changed to Date Format  
                        {
                            tempValue = jQueryShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            tempValue = tempValue.Substring(0, 10);
                            dateValue = DateTime.ParseExact(tempValue, "yyyy/MM/dd", null);
                            worksheet.Cells[i + 2, j + 1] = dateValue;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = jQueryShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                        }

                    }

                }


                // Change columns text to number which you need to 

                int ColumnIndex = 8;   // Exel Column Index Start one Rather than Zero 


                worksheet.Columns[ColumnIndex].TextToColumns();
                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


                //Change columns text to Date which you need to 
                // I solved it in this part Add data to the worksheet  





                // Add filter to data  

                worksheet.Range["1:1"].AutoFilter(8, ">=0");



                /*
                // Save the workbook and close the Excel application
                workbook.SaveAs("MyData.xlsx");
                workbook.Close();
                excelApp.Quit();
                */

            }
            else
            {

            }

        }



        protected void ExcelButtonLAllShI_Click(object sender, EventArgs e)
        {
            // Create a new Excel application object

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Create a new workbook
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            int numRows = jQueryAllShipItemListGridView.Rows.Count;   // Pulls number of Rows.
            if (numRows > 0)
            {
                int numColumns = jQueryAllShipItemListGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

                    worksheet.Columns[i + 2].ColumnWidth = 21;

                }

                worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

                worksheet.Name = "All Ship Item List";





                // Create a header row

                for (int i = 0; i < numColumns; i++)
                {
                    worksheet.Cells[1, i + 1] = jQueryAllShipItemListGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
                }

                // Add data to the worksheet

                String tempValue = "";
                DateTime dateValue;
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numColumns; j++)
                    {
                        if (j == 1)    // Column That Has To Changed to Date Format  
                        {
                            tempValue = jQueryAllShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            tempValue = tempValue.Substring(0, 10);
                            dateValue = DateTime.ParseExact(tempValue, "yyyy/MM/dd", null);
                            worksheet.Cells[i + 2, j + 1] = dateValue;
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = jQueryAllShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                        }

                    }

                }


                // Change columns text to number which you need to 

                int ColumnIndex = 8;


                worksheet.Columns[ColumnIndex].TextToColumns();
                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


                //Change columns text to Date which you need to 
                // I solved it in this part Add data to the worksheet  





                // Add filter to data  

                worksheet.Range["1:1"].AutoFilter(8, ">=0");



                /*
                // Save the workbook and close the Excel application
                workbook.SaveAs("MyData.xlsx");
                workbook.Close();
                excelApp.Quit();
                */

            }
            else
            {

            }

        }

        //protected void CreateInvoiceButton_Click(object sender, EventArgs e)
        //{



        //    Search_Panel.Visible = false;

        //    // En öncesinde seçili shipmentların Aynı customer a ait olduğunu kontrol et.!!! UNUTMA YAP

        //    //First Create New Row for the Invoice table.

        //    string date;
        //    string consultantID;
        //    string paymentStatus;
        //    string notes;

        //    string invoiceId;
        //    string shipmentId;
        //    string controlShipmentId = "0";

        //    bool isAtLeastOneCheckboxChecked = false;

        //    string customerName = "............";
        //    string customerNameControl = "............";
        //    int i = 0;
        //    bool nameControl = false;

        //    // We need to Control if all shipments are for same customer. BEFORE EVERYTHİNG
        //    foreach (GridViewRow row in jQueryUnBilledShipmentsGridView.Rows)
        //    {
        //        // Check if the current row is selected
        //        CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
        //        if (cbSelect.Checked)
        //        {
        //            i++;
        //            nameControl = true;
        //            customerName = string.Format(row.Cells[1].Text);    // We need to Controll if all shipments are for same customer.
        //                                                                // But we need to control before everthing.

        //            if (i == 1)
        //            {
        //                customerNameControl = customerName;
        //            }
        //            else
        //            {

        //            }

        //            if (customerNameControl == customerName)
        //            {

        //            }
        //            else
        //            {
        //                nameControl = false;
        //                Response.Write("<script>alert('You need to choose same Customer  shipments for invoicing')</script>");
        //                break;
        //            }


        //        }
        //    }




        //    if (nameControl == true)
        //    {





        //        date = InvoiceDateTextBox.Text;
        //        consultantID = ConsultantDropDownList.SelectedValue;
        //        paymentStatus = PaymentStatusDropDownList.SelectedItem.Text;
        //        notes = InvoiceNotesTextBox.Text;

        //        SqlCommand addInvoice = new SqlCommand($"insert into [tbl_invoice] ([inv_Date],[consultant_ID],[inv_Status],[inv_Notes]) " +
        //            $"values ('{date}','{consultantID}','{paymentStatus}','{notes}')", conn.Connection());

        //        addInvoice.ExecuteNonQuery();

        //        // Pulling the last ID from Invoice Table 

        //        string lastInvoiceID = $"SELECT [inv_ID] FROM [tbl_invoice]\r\nWHERE [inv_ID] = (\r\n    SELECT MAX([inv_ID]) FROM[tbl_invoice])";
        //        SqlDataAdapter adpt = new SqlDataAdapter(lastInvoiceID, conn.Connection());
        //        DataTable dt1 = new DataTable();
        //        adpt.Fill(dt1);
        //        invoiceId = dt1.Rows[0][0].ToString();   // This is our InvoiceID for 


        //        // Create newRows for invoiceShip table. By useng selected GridView and Last Invoice Id by foreachloop


        //        // Iterate through each row in the GridView
        //        foreach (GridViewRow row in jQueryUnBilledShipmentsGridView.Rows)
        //        {
        //            // Check if the current row is selected
        //            CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
        //            if (cbSelect.Checked)
        //            {
        //                //If at least one checked control Alternative  RequiredFieldValidator
        //                isAtLeastOneCheckboxChecked = true;


        //                // Get the data from the selected row

        //                shipmentId = string.Format(row.Cells[3].Text);
        //                customerName = string.Format(row.Cells[1].Text);    // We need to Controll if all shipments are for same customer.
        //                                                                    // But we need to control before everthing. 





        //                if (shipmentId != controlShipmentId)  // By this control avoid to have same shipment two times. 
        //                {
        //                    //Add shipment ID tı Last Id on InvoiceShip table

        //                    SqlCommand addinvoiceShip = new SqlCommand($"insert into [tbl_invoiceShip] ([inv_ID],[ship_ID])" +
        //                    $"values ('{invoiceId}','{shipmentId}')", conn.Connection());
        //                    addinvoiceShip.ExecuteNonQuery();
        //                }
        //                controlShipmentId = shipmentId;

        //            }
        //        }
        //        if (isAtLeastOneCheckboxChecked == true)
        //        {
        //            jQueryUnBilledShipmentsGridViewBind();
        //            jQueryInvoiceDetailGridViewBind(invoiceId);   //Note we add the Invoice Detail Row In This  GridViewBind  inside Store  Procedure !!!
        //            InvoiceDetailTotalAmountLabelBind();
        //            CreateInvoicePanel.Visible = false;
        //            InvoiceDetailPanel.Visible = true;
        //            CustomerLabel.Text = customerName;
        //            InvIdLabel.Text = invoiceId;
        //            DateLabel.Text=InvoiceDateTextBox.Text;
        //            ConsultantLabel.Text = ConsultantDropDownList.SelectedItem.ToString();
        //            Response.Write("<script>alert('If you choose one product group of shipment, that shipments all products ( All of that Shipment ) will be Invoiced.')</script>");
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('You need to choose at least one shipment for invoicing')</script>");
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('You need to choose at least one shipment for invoicing')</script>");
        //    }

        //}


        protected void CreateInvoiceButton_Click(object sender, EventArgs e)
        {
            Search_Panel.Visible = false;

            // En öncesinde seçili shipmentların Aynı customer a ait olduğunu kontrol et.!!! UNUTMA YAP

            //First Create New Row for the Invoice table.

            string date;
            string consultantID;
            string paymentStatus;
            string notes;

            string invoiceId;
            string shipmentId;
            string controlShipmentId = "0";

            bool isAtLeastOneCheckboxChecked = false;

            string customerName = "............";
            string customerNameControl = "............";
            int i = 0;
            bool nameControl = false;

            // We need to Control if all shipments are for same customer. BEFORE EVERYTHİNG
            foreach (GridViewRow row in jQueryUnBilledShipmentsGridView.Rows)
            {
                // Check if the current row is selected
                CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
                if (cbSelect.Checked)
                {
                    i++;
                    nameControl = true;
                    customerName = string.Format(row.Cells[1].Text);

                    if (i == 1)
                    {
                        customerNameControl = customerName;
                    }
                    else
                    {

                    }

                    if (customerNameControl != customerName)
                    {
                        nameControl = false;
                        Response.Write("<script>alert('You need to choose shipments for the same customer for invoicing')</script>");
                        break;
                    }
                }
            }

            if (nameControl)
            {
                date = InvoiceDateTextBox.Text;
                consultantID = ConsultantDropDownList.SelectedValue;
                paymentStatus = PaymentStatusDropDownList.SelectedItem.Text;
                notes = InvoiceNotesTextBox.Text;

                using (SqlConnection connection = conn.Connection())
                {
                    

                    // Inserting new invoice
                    SqlCommand addInvoice = new SqlCommand($"insert into [tbl_invoice] ([inv_Date],[consultant_ID],[inv_Status],[inv_Notes]) " +
                        $"values ('{date}','{consultantID}','{paymentStatus}','{notes}')", connection);
                    addInvoice.ExecuteNonQuery();

                    // Pulling the last ID from Invoice Table 
                    string lastInvoiceID = $"SELECT [inv_ID] FROM [tbl_invoice]\r\nWHERE [inv_ID] = (\r\n    SELECT MAX([inv_ID]) FROM[tbl_invoice])";
                    SqlDataAdapter adpt = new SqlDataAdapter(lastInvoiceID, connection);
                    DataTable dt1 = new DataTable();
                    adpt.Fill(dt1);
                    invoiceId = dt1.Rows[0][0].ToString();

                    // Create newRows for invoiceShip table. By useng selected GridView and Last Invoice Id by foreachloop
                    foreach (GridViewRow row in jQueryUnBilledShipmentsGridView.Rows)
                    {
                        // Check if the current row is selected
                        CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
                        if (cbSelect.Checked)
                        {
                            isAtLeastOneCheckboxChecked = true;
                            shipmentId = string.Format(row.Cells[3].Text);
                            customerName = string.Format(row.Cells[1].Text);

                            if (shipmentId != controlShipmentId)
                            {
                                // Add shipment ID to Last Id on InvoiceShip table
                                SqlCommand addinvoiceShip = new SqlCommand($"insert into [tbl_invoiceShip] ([inv_ID],[ship_ID])" +
                                $"values ('{invoiceId}','{shipmentId}')", connection);
                                addinvoiceShip.ExecuteNonQuery();
                            }
                            controlShipmentId = shipmentId;
                        }
                    }
                }

                if (isAtLeastOneCheckboxChecked)
                {
                    jQueryUnBilledShipmentsGridViewBind();
                    jQueryInvoiceDetailGridViewBind(invoiceId);
                    InvoiceDetailTotalAmountLabelBind();
                    CreateInvoicePanel.Visible = false;
                    InvoiceDetailPanel.Visible = true;
                    CustomerLabel.Text = customerName;
                    InvIdLabel.Text = invoiceId;
                    DateLabel.Text = InvoiceDateTextBox.Text;
                    ConsultantLabel.Text = ConsultantDropDownList.SelectedItem.ToString();
                    Response.Write("<script>alert('If you choose one product group of shipment, that shipments all products ( All of that Shipment ) will be Invoiced.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('You need to choose at least one shipment for invoicing')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You need to choose at least one shipment for invoicing')</script>");
            }
        }


        protected void OpenPanelButton_Click(object sender, EventArgs e)
        {
            Search_Panel.Visible = true;
        }

        protected void ClosePanelButton_Click(object sender, EventArgs e)
        {
            Search_Panel.Visible = false;
        }

        //protected void CloseInvoiceButton_Click(object sender, EventArgs e)
        //{

        //    string txnDate=DateLabel.Text;

        //    string acctID;  // pull from tbl_account by using CustomerLabel.Text
        //    string acctName = CustomerLabel.Text;
        //    // First find AcctId of this customer
        //    string pullAcctID = $"SELECT [acct_ID] FROM [tbl_account]\r\nWHERE [acct_Name] ='{acctName}' ";
        //    SqlDataAdapter adpt4 = new SqlDataAdapter(pullAcctID, conn.Connection());
        //    DataTable dt4 = new DataTable();
        //    adpt4.Fill(dt4);
        //    acctID = dt4.Rows[0][0].ToString();

        //    string txnTypeID = "2";    // All Invoicess are sales and sales is txnType is always 2.
        //    string txnDetailID="18" ;    // Can be two type sales invoice product sale and sale we need to make control for them and choose 18 or 19. But  before this we need Invoice Interface for service sales 

        //    string consultantID;   // pull from tbl_consultant by using ConsultantLabel.text. 
        //    string consultantName=ConsultantLabel.Text;
        //    string pullConsultantID = $"SELECT [cnslt_Id] FROM [tbl_consultant] WHERE [cnslt_Name]='{consultantName}'";
        //    SqlDataAdapter adpt5 =new SqlDataAdapter(pullConsultantID, conn.Connection());
        //    DataTable dt5 = new DataTable();
        //    adpt5.Fill(dt5);
        //    consultantID=dt5.Rows[0][0].ToString();

        //    string txnNull = "0";
        //    string txnAmount = VATIncludedAmountLabel.Text;  // need to trim the currency symbol form string. 
        //    txnAmount=txnAmount.Remove(txnAmount.Length-1,1) ;

        //    string txnNotes = "txn From Sales";
        //    // We need to add code for transaction movments. Like purchase, for adding txn of this sale.

        //    SqlCommand addTxn = new SqlCommand($"insert into [tbl_transactions] ([txn_Date]\r\n,[acct_ID]\r\n,[txn_Type_ID]\r\n,[txn_Detail_ID]\r\n,[consultant_ID]\r\n,[txn_Debit],[txn_Credit]\r\n,[txn_Notes] )" +
        //                $"values ('{txnDate}',{acctID},{txnTypeID},{txnDetailID},{consultantID},@txnAmount,@txnNull,'{txnNotes}')", conn.Connection());
        //    addTxn.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmount, CultureInfo.CurrentCulture);

        //    addTxn.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
        //    addTxn.ExecuteNonQuery();


        //    // Find Last txID from tbl_transactions


        //    string txnID;
        //    string lastTxnID = $"SELECT [txn_Id] FROM [tbl_transactions]\r\nWHERE [txn_Id] = (\r\n    SELECT MAX([txn_Id]) FROM [tbl_transactions])";
        //    SqlDataAdapter adpt10 = new SqlDataAdapter(lastTxnID, conn.Connection());
        //    DataTable dt10 = new DataTable();
        //    adpt10.Fill(dt10);
        //    txnID = dt10.Rows[0][0].ToString();


        //    // UpDate the lastInvoice ID Row by Adding the txnID

        //    string invoiceID = InvIdLabel.Text;

        //    SqlCommand addTxnID = new SqlCommand($"update [tbl_invoice] set txn_Id='{txnID}'  where [inv_ID]= '{invoiceID}' ", conn.Connection());

        //    addTxnID.ExecuteNonQuery();

        //    Response.Redirect("~/BusinessLayer/main-ERP.aspx");
        //}

        protected void CloseInvoiceButton_Click(object sender, EventArgs e)
        {
            string txnDate = DateLabel.Text;

            string acctID;
            string acctName = CustomerLabel.Text;
            // First find AcctId of this customer
            string pullAcctID = $"SELECT [acct_ID] FROM [tbl_account]\r\nWHERE [acct_Name] ='{acctName}' ";
            using (SqlDataAdapter adpt4 = new SqlDataAdapter(pullAcctID, conn.Connection()))
            {
                DataTable dt4 = new DataTable();
                adpt4.Fill(dt4);
                acctID = dt4.Rows[0][0].ToString();
            }

            string txnTypeID = "2";
            string txnDetailID = "18";

            string consultantID;
            string consultantName = ConsultantLabel.Text;
            string pullConsultantID = $"SELECT [cnslt_Id] FROM [tbl_consultant] WHERE [cnslt_Name]='{consultantName}'";
            using (SqlDataAdapter adpt5 = new SqlDataAdapter(pullConsultantID, conn.Connection()))
            {
                DataTable dt5 = new DataTable();
                adpt5.Fill(dt5);
                consultantID = dt5.Rows[0][0].ToString();
            }

            string txnNull = "0";
            string txnAmount = VATIncludedAmountLabel.Text;
            txnAmount = txnAmount.Remove(txnAmount.Length - 4, 4);

            string txnNotes = "txn From Sales";

            using (SqlCommand addTxn = new SqlCommand($"insert into [tbl_transactions] ([txn_Date]\r\n,[acct_ID]\r\n,[txn_Type_ID]\r\n,[txn_Detail_ID]\r\n,[consultant_ID]\r\n,[txn_Debit],[txn_Credit]\r\n,[txn_Notes] )" +
                            $"values ('{txnDate}',{acctID},{txnTypeID},{txnDetailID},{consultantID},@txnAmount,@txnNull,'{txnNotes}')", conn.Connection()))
            {
                addTxn.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmount, CultureInfo.CurrentCulture);
                addTxn.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
                addTxn.ExecuteNonQuery();
            }

            // Find Last txID from tbl_transactions
            string txnID;
            string lastTxnID = $"SELECT [txn_Id] FROM [tbl_transactions]\r\nWHERE [txn_Id] = (\r\n    SELECT MAX([txn_Id]) FROM [tbl_transactions])";
            using (SqlDataAdapter adpt10 = new SqlDataAdapter(lastTxnID, conn.Connection()))
            {
                DataTable dt10 = new DataTable();
                adpt10.Fill(dt10);
                txnID = dt10.Rows[0][0].ToString();
            }

            // UpDate the lastInvoice ID Row by Adding the txnID
            string invoiceID = InvIdLabel.Text;
            using (SqlCommand addTxnID = new SqlCommand($"update [tbl_invoice] set txn_Id='{txnID}'  where [inv_ID]= '{invoiceID}' ", conn.Connection()))
            {
                addTxnID.ExecuteNonQuery();
            }

            Response.Redirect("~/BusinessLayer/main-ERP.aspx");
        }

    }
}