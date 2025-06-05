using polymer_Web_ERP_V4.Productivity;
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

namespace polymer_Web_ERP_V4
{
    public partial class listTxn_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateMax = DateTime.Now;
            DateTime dateMin = dateMax.AddDays(-390);

            if (!this.IsPostBack)
            {
                ItemDateMin_TextBox.Text = dateMin.ToString("yyyy-MM-dd");
                ItemDateMax_TextBox.Text = dateMax.ToString("yyyy-MM-dd");

                jQueryList_Txn_GridViewBind();
            }


        }




        private void jQueryList_Txn_GridViewBind()
        {

            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listTxn '{ItemDateMin_TextBox.Text}', '{ItemDateMax_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryList_Txn_GridView.DataSource = dt;
                        jQueryList_Txn_GridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryList_Txn_GridView.UseAccessibleHeader = true;
            jQueryList_Txn_GridView.HeaderRow.TableSection = TableRowSection.TableHeader;




        }


        protected void jQueryList_Txn_GridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryList_Txn_GridViewBind();

            // Configure GridView structure
            if (jQueryList_Txn_GridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryList_Txn_GridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryList_Txn_GridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryList_Txn_GridView.FooterRow.TableSection = TableRowSection.TableFooter;

                
                
            }

        }





        protected void Show_Txn_List_Button_Click(object sender, EventArgs e)
        {
            jQueryList_Txn_GridViewBind();
        }




        //protected void ExcelButton_Click(object sender, EventArgs e)
        //{


         

        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;


        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;

        //    int numRows = jQueryList_Txn_GridView.Rows.Count; // Pulls number of Rows.

        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryList_Txn_GridView.Rows[0].Cells.Count; // Pulls number of Columns.


        //        for (int i = 0; i < numColumns; i++)   // For Header Color and Column Width
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 10;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "Txn List";

        //        // Create a header row



        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryList_Txn_GridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }


        //        // Add data to the worksheet

        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = HttpUtility.HtmlDecode(jQueryList_Txn_GridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " "));
                         
        //            }
        //        }

        //        // Change columns text to number which you need to

        //        int ColumnIndex = 8;

        //        for (int i = ColumnIndex; i <= 9; i++)
        //        {
        //            worksheet.Columns[i].TextToColumns();
        //            worksheet.Columns[i].NumberFormat = "0,00";
        //        }


        //        worksheet.Range["1:1"].AutoFilter(1, ">0");




        //    }
        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Progress for EXCEL');</script>");

                

        //    }


        //}

        protected void ExcelButton_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("TransactionList");

                int numRows = jQueryList_Txn_GridView.Rows.Count;   // Pulls number of Rows.
                if (numRows > 0)
                {
                    int numColumns = jQueryList_Txn_GridView.Rows[0].Cells.Count;   // Pulls number of Columns. 

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 1).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryList_Txn_GridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryList_Txn_GridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;

                            // Apply date format to the 5th column (assuming it's column index 4)
                           
                            if (j == 1)
                            {
                                DateTime date;
                                if (DateTime.TryParse(cellValue, out date))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = date;
                                }

                            }
                            else if (j == 0 )
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                }
                            }

                            else if (j == 7 || j == 8)
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
                    Response.AddHeader("content-disposition", "attachment; filename=TransactionList.xlsx");
                    Response.BinaryWrite(package.GetAsByteArray());
                    Response.End();
                }
            }
        }


    }
}