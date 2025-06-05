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
    public partial class listPurchase_ERP : System.Web.UI.Page
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

                PurchaseGridViewBind();
            }
        }


        private void PurchaseGridViewBind()
        {               
            
            
            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listPurchase '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryPurchaseGridView.DataSource = dt;
                        jQueryPurchaseGridView.DataBind();
                    }

                }
            }
            
            
            //Required for jQuery DataTables to work.
            jQueryPurchaseGridView.UseAccessibleHeader = true;
            jQueryPurchaseGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryPurchaseGridView_PreRender(object sender, EventArgs e)
        {
            this.PurchaseGridViewBind();

            if (jQueryPurchaseGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryPurchaseGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryPurchaseGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryPurchaseGridView.FooterRow.TableSection = TableRowSection.TableFooter;
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


        //    int numRows = jQueryPurchaseGridView.Rows.Count;   // Pulls number of Rows.
        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryPurchaseGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 21;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "Products List";





        //        // Create a header row

        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryPurchaseGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }

        //        // Add data to the worksheet


        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = jQueryPurchaseGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //            }

        //        }


        //        // Change columns text to number which you need to 

        //        int ColumnIndex = 13;

        //        for(int i = ColumnIndex; i<=17 ; i++)
        //        {
        //            worksheet.Columns[i].TextToColumns();
        //            worksheet.Columns[i].NumberFormat = "0,00";
        //        }


        //        worksheet.Range["1:1"].AutoFilter(1, ">0");



        //        /*
        //        // Save the workbook and close the Excel application
        //        workbook.SaveAs("MyData.xlsx");
        //        workbook.Close();
        //        excelApp.Quit();
        //        */

        //    }
        //    else
        //    {

        //    }

        //}


        protected void ExcelButton_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("PurchaseList");

                int numRows = jQueryPurchaseGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryPurchaseGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryPurchaseGridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryPurchaseGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;

                            // Apply specific formats
                            if (j == 0) // Date format to the second column
                            {
                                DateTime dateTime;
                                if (DateTime.TryParse(cellValue, out dateTime))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = dateTime;
                                }
                            }
                            else if (j == 12) // Numeric format to the sixth column
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;
                                }
                            }

                            else if(j == 14 || j == 15 || j == 16)
                            {
                                //cellValue = cellValue.Replace(",", "");

                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;
                                }

                            }

                            else if (j == 8)
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00%";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;
                                }
                            }

                            else if (j == 13 ) // Numeric format to the sixth column
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.000";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;
                                }
                            }

                            else if (j == 3 || j == 4 ||j==17 ||j==19) // Numeric format to columns 1 and 3
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

                // Return the Excel package as a download response
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=PurchaseList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();
            }
        }



        protected void ShowReportButton_Click(object sender, EventArgs e)
        {
            PurchaseGridViewBind();
        }
    }
}