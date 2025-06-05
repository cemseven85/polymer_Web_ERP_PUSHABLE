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
    public partial class listEmployee_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                    
                jQueryEmployeeGridViewBind();



            }

        }


        private void jQueryEmployeeGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listEmployee ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryEmployeeGridView.DataSource = dt;
                        jQueryEmployeeGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryEmployeeGridView.UseAccessibleHeader = true;
            jQueryEmployeeGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryEmployeeGridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryEmployeeGridViewBind();

            if (jQueryEmployeeGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryEmployeeGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryEmployeeGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryEmployeeGridView.FooterRow.TableSection = TableRowSection.TableFooter;
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

        //    int numRows = jQueryEmployeeGridView.Rows.Count;   // Pulls number of Rows.
        //    int numColumns = jQueryEmployeeGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 

        //    // Create a header row

        //    for (int i = 0; i < numColumns; i++)
        //    {
        //        worksheet.Cells[1, i + 1] = jQueryEmployeeGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //    }
          
        //    // Add data to the worksheet


        //    for (int i = 0; i < numRows; i++) 
        //    { 
        //        for(int j = 0; j < numColumns; j++)
        //        {
        //            worksheet.Cells[i+2,j+1] = jQueryEmployeeGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //        }
            
        //    }
           

        //    // Change columns text to number which you need to 

        //    int ColumnIndex = 8;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //    ColumnIndex = 9;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //    ColumnIndex = 16;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //    ColumnIndex = 17;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //    ColumnIndex = 18;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //    ColumnIndex = 21;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //    ColumnIndex = 22;
        //    worksheet.Columns[ColumnIndex].TextToColumns();
        //    worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


        //    worksheet.Range["1:1"].AutoFilter(1, ">0");

            
        //    for(int i = 0; i < numColumns; i++)
        //    {
        //        worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //        worksheet.Columns[i+2].ColumnWidth =10;

        //    }

        //    worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //    worksheet.Name= "Employee List";



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
                var worksheet = package.Workbook.Worksheets.Add("EmployeeList");

                int numRows = jQueryEmployeeGridView.Rows.Count;   // Pulls number of Rows.
                if (numRows > 0)
                {
                    int numColumns = jQueryEmployeeGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 1).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryEmployeeGridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryEmployeeGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;

                            // Apply date format to the 5th column (assuming it's column index 4)
                            
                            if (j == 11 || j==12)
                            {
                                DateTime date;
                                if (DateTime.TryParse(cellValue, out date))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = date;
                                }

                            }
                            else if (j == 0 || j == 14 || j == 18 || j == 19 )
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                }
                            }

                            else if (j == 7 || j==8 || j == 15 || j == 16 || j == 17 || j == 20 || j == 21)
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
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
                    Response.AddHeader("content-disposition", "attachment; filename=EmployeeList.xlsx");
                    Response.BinaryWrite(package.GetAsByteArray());
                    Response.End();
                }
            }
        }

    }
}