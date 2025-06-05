using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;   // From Here Name Spaces Are For Exel File Transfer 
//using Excel = Microsoft.Office.Interop.Excel;  //Before  Excel =   Data Tables And Exels Send Error. 
using OfficeOpenXml;


namespace polymer_Web_ERP_V4
{
    public partial class listCustomerGroup_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerGroupGridViewBind();
        }

        private void CustomerGroupGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listCustomerGroup", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryCustomerGroupGridView.DataSource = dt;
                        jQueryCustomerGroupGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryCustomerGroupGridView.UseAccessibleHeader = true;
            jQueryCustomerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void jQueryCustomerGroupGridView_PreRender(object sender, EventArgs e)
        {
            this.CustomerGroupGridViewBind();

            if (jQueryCustomerGroupGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryCustomerGroupGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryCustomerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryCustomerGroupGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        //protected void ExcelButton_Click(object sender, EventArgs e)
        //{
        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;

        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;


        //    int numRows = jQueryCustomerGroupGridView.Rows.Count;   // Pulls number of Rows.
        //    int numColumns = jQueryCustomerGroupGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //    for (int i = 0; i < numColumns; i++)
        //    {
        //        worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //        worksheet.Columns[i + 2].ColumnWidth = 21;

        //    }

        //    worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //    worksheet.Name = "Products List";





        //    // Create a header row

        //    for (int i = 0; i < numColumns; i++)
        //    {
        //        worksheet.Cells[1, i + 1] = jQueryCustomerGroupGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //    }

        //    // Add data to the worksheet


        //    for (int i = 0; i < numRows; i++)
        //    {
        //        for (int j = 0; j < numColumns; j++)
        //        {
        //            worksheet.Cells[i + 2, j + 1] = jQueryCustomerGroupGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //        }

        //    }


        //    // Change columns text to number which you need to 
        //    /*
        //    int ColumnIndex = 8;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //    ColumnIndex = 9;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";
        //    */

        //    worksheet.Range["1:1"].AutoFilter(1, ">0");



        //    /*
        //    // Save the workbook and close the Excel application
        //    workbook.SaveAs("MyData.xlsx");
        //    workbook.Close();
        //    excelApp.Quit();
        //    */



        //}

        protected void ExcelButton_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("CustomerGroupList");

                int numRows = jQueryCustomerGroupGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryCustomerGroupGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryCustomerGroupGridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryCustomerGroupGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            //// Apply date format to the second column (assuming it's column index 1)
                            //if (j == 1) // Adjust the column index as needed
                            //{
                            //    DateTime dateTime;
                            //    if (DateTime.TryParse(cellValue, out dateTime))
                            //    {
                            //        worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy HH:mm:ss";
                            //        worksheet.Cells[i + 2, j + 1].Value = dateTime;
                            //    }
                            //}


                            //// Apply numeric format to the sixth column (assuming it's column index 6)
                            //if (j == 5) // Adjust the column index as needed
                            //{
                            //    double numericValue;
                            //    if (double.TryParse(cellValue, out numericValue))
                            //    {
                            //        worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                            //        worksheet.Cells[i + 2, j + 1].Value = numericValue;




                            //    }
                            //}


                            // Apply numeric format to  (assuming it's column index 1 and 3 )
                            if (j == 0) // Adjust the column index as needed
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
                Response.AddHeader("content-disposition", "attachment; filename=CustomerGroupList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();


            }
        }

    }
}