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
//using Excel = Microsoft.Office.Interop.Excel;  //Before  Excel =   Data Tables And Exels Send Error.   // For Trying EPPlus I Comment This 
using OfficeOpenXml;


namespace polymer_Web_ERP_V4
{
    public partial class listGProduction_ERP : System.Web.UI.Page
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

                OutPutProductionGridViewBind();



            }

        }


        private void OutPutProductionGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_ListOutPutProduction '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}' ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryOutPutProductionGridView.DataSource = dt;
                        jQueryOutPutProductionGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryOutPutProductionGridView.UseAccessibleHeader = true;
            jQueryOutPutProductionGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryOutPutProductionGridView_PreRender(object sender, EventArgs e)
        {
            this.OutPutProductionGridViewBind();

            if (jQueryOutPutProductionGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryOutPutProductionGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryOutPutProductionGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryOutPutProductionGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        // For Trying EPPlus I command the  ExcelButton_Click Method 

        //protected void ExcelButton_Click(object sender, EventArgs e)
        //{
        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;

        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;


        //    int numRows = jQueryOutPutProductionGridView.Rows.Count;   // Pulls number of Rows.
        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryOutPutProductionGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 21;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "Granule Production List";





        //        // Create a header row

        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryOutPutProductionGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }

        //        // Add data to the worksheet


        //        String tempValue = "";
        //        DateTime dateValue;

        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                if (j == 500)    // Column That Has To Changed to Date Format  
        //                {
        //                    tempValue = jQueryOutPutProductionGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                    tempValue = tempValue.Substring(0, 10);
        //                    dateValue = DateTime.ParseExact(tempValue, "dd.MM.yyyy", null);
        //                    worksheet.Cells[i + 2, j + 1] = dateValue;
        //                }
        //                else
        //                {
        //                    worksheet.Cells[i + 2, j + 1] = jQueryOutPutProductionGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                }

        //            }

        //        }


        //        // Change columns text to number which you need to 

        //        int ColumnIndex = 6;


        //        worksheet.Columns[ColumnIndex].TextToColumns();
        //        worksheet.Columns[ColumnIndex].NumberFormat = "0,00";



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



        // EPPlus  Excel Model Usage Codes

        protected void ExcelButton_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Granule Production List");

                int numRows = jQueryOutPutProductionGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryOutPutProductionGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryOutPutProductionGridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryOutPutProductionGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            // Apply date format to the second column (assuming it's column index 1)
                            if (j == 1) // Adjust the column index as needed
                            {
                                DateTime dateTime;
                                if (DateTime.TryParse(cellValue, out dateTime))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy HH:mm:ss";
                                    worksheet.Cells[i + 2, j + 1].Value = dateTime;
                                }
                            }


                            // Apply numeric format to the sixth column (assuming it's column index 6)
                            if (j == 5) // Adjust the column index as needed
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;




                                }
                            }


                            // Apply numeric format to  (assuming it's column index 1 and 3 )
                            if (j == 0 || j==2) // Adjust the column index as needed
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
                Response.AddHeader("content-disposition", "attachment; filename=GranuleProductionList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();


            }
        }





        protected void ShowReportButton_Click(object sender, EventArgs e)
        {
            OutPutProductionGridViewBind();
        }
    }
}