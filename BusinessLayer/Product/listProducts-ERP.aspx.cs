using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Drawing;
using System.Windows.Forms;
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
    public partial class listProducts_ERP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductGridViewBind();
            

        }


        private void ProductGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listProducts", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryProductGridView.DataSource = dt;
                        jQueryProductGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryProductGridView.UseAccessibleHeader = true;
            jQueryProductGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryProductGridView_PreRender(object sender, EventArgs e)
        {
            this.ProductGridViewBind();

            if (jQueryProductGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryProductGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryProductGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryProductGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        //  hide GridView columns  WE NEED TO MAKE ORGANIZATON FOR Authorised PERSONEL 

        protected void jQueryProductGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)  // WE NEED TO MAKE ORGANIZATON FOR Authorised PERSONEL 
            {
                e.Row.Cells[7].Visible = false;             // WE NEED TO MAKE ORGANIZATON FOR Authorised PERSONEL
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[7].Visible = false;
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


        //    int numRows = jQueryProductGridView.Rows.Count;   // Pulls number of Rows.
        //    int numColumns = jQueryProductGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


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
        //        worksheet.Cells[1, i + 1] = jQueryProductGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //    }

        //    // Add data to the worksheet


        //    for (int i = 0; i < numRows; i++)
        //    {
        //        for (int j = 0; j < numColumns; j++)
        //        {
        //            worksheet.Cells[i + 2, j + 1] = jQueryProductGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
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
                var worksheet = package.Workbook.Worksheets.Add("ProductList");

                int numRows = jQueryProductGridView.Rows.Count;   // Pulls number of Rows.
                if (numRows > 0)
                {
                    int numColumns = jQueryProductGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 1).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryProductGridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryProductGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;

                            // Apply date format to the 5th column (assuming it's column index 4)
                            

                            if (j == 6)
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;
                                }

                            }
                            else if (j == 0)
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

                    // Save the workbook
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=ProductList.xlsx");
                    Response.BinaryWrite(package.GetAsByteArray());
                    Response.End();
                }
            }
        }

    }
}