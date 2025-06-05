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
using OfficeOpenXml;


namespace polymer_Web_ERP_V4.BusinessLayer.Sales
{
    public partial class invoiceShipTrace : System.Web.UI.Page
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

        private void jQueryShipInvoiceTraceListGridViewBind()
        {
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_invoiceShipTracing  '{ItemDateMin_TextBox.Text}' , '{ItemDateMax_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryShipInvoiceTraceListGridView.DataSource = dt;
                        jQueryShipInvoiceTraceListGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryShipInvoiceTraceListGridView.UseAccessibleHeader = true;
            jQueryShipInvoiceTraceListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }



        protected void jQueryShipInvoiceTraceListGridView_PreRender(object sender, EventArgs e)
        {
            jQueryShipInvoiceTraceListGridViewBind();


            if (jQueryShipInvoiceTraceListGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryShipInvoiceTraceListGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryShipInvoiceTraceListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryShipInvoiceTraceListGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }


        }


        
            protected void ShowShipInvoiceTraceListButton_Click(object sender, EventArgs e)
        {
            jQueryShipInvoiceTraceListGridViewBind();
        }





        protected void ExcelButton_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("InvoiceList");

                int numRows = jQueryShipInvoiceTraceListGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryShipInvoiceTraceListGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryShipInvoiceTraceListGridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryShipInvoiceTraceListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            // Apply date format to the second column (assuming it's column index 1)
                            if (j == 0) // Adjust the column index as needed
                            {
                                DateTime dateTime;
                                if (DateTime.TryParse(cellValue, out dateTime))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = dateTime;
                                }
                            }


                            // Apply numeric format to the sixth column (assuming it's column index 6)
                            if (j == 1) // Adjust the column index as needed
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;




                                }
                            }


                            // Apply numeric format to  (assuming it's column index 1 and 3 )
                            if (j == 2) // Adjust the column index as needed
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;


                                }
                            }



                        }
                    }

                    // Apply AutoFilter to all columns (including the header row)
                    worksheet.Cells[1, 1, numRows + 1, numColumns].AutoFilter = true;

                }

                // Save the workbook    "C:\Users\Public\Documents"
                //var datetime = DateTime.Now;
                //var filePath = @"C:\Users\Public\Documents\" + datetime.ToString("dd-MM-yyyy_hh-mm-ss") + ".xlsx";
                //package.SaveAs(new FileInfo(filePath));




                // Now you can work with the workbook in memory (e.g., send it as a response to the client).
                // You don't need to save it to a specific path.
                // For example, you can return the package as a download response:
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=InvoiceShipTraceList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();



            }
        }

    }
}