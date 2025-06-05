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
    public partial class listProgressPayment_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataKeyCheckBox.Visible = false;
                DetailCheckBox.Visible = false;

                ExcelButton.Visible = false;
            }


        }



        private void jQueryRelated_Month_Progress_Payment_GridViewBind()
        {

            string earnedMonth = Related_Progress_MonthTextBox.Text;


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_monthlyProgressPayment '{earnedMonth}'", con))   //Note we add the Invoice Detail Row In This Procedure !!!
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryRelated_Month_Progress_Payment_GridView.DataSource = dt;
                        jQueryRelated_Month_Progress_Payment_GridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryRelated_Month_Progress_Payment_GridView.UseAccessibleHeader = true;
            jQueryRelated_Month_Progress_Payment_GridView.HeaderRow.TableSection = TableRowSection.TableHeader;







        }



        protected void Show_Progress_Payment_Button_Click(object sender, EventArgs e)
        {

            // For making the total txn Calculations and want to use the grid View data rather than a data table or Server side DataBase serverside calsulations. 
            // Make Visible all columns and to be sure selec the right cell. 

            DataKeyCheckBox.Checked = true;
            DetailCheckBox.Checked = true;


            jQueryRelated_Month_Progress_Payment_GridViewBind();


            double totalTxn4PNum = 0;
            double totalTxn4RNum = 0;
            double totalTxnNum = 0;
            double totalOverTNum = 0;

            string totaTxn4PStr;
            string totalTxn4RStr;
            string totalOverTStr;

            foreach (GridViewRow row in jQueryRelated_Month_Progress_Payment_GridView.Rows)
            {
                totaTxn4PStr = row.Cells[18].Text;
                totalTxn4PNum += Convert.ToDouble(totaTxn4PStr);

                totalTxn4RStr = row.Cells[19].Text;
                totalTxn4RNum += Convert.ToDouble(totalTxn4RStr);

                totalOverTStr = row.Cells[16].Text;
                totalOverTNum = Convert.ToDouble(totalOverTStr);

            }


            DataKeyCheckBox.Checked = false;
            DetailCheckBox.Checked = false;



            ToggleFourthColumnVisibility();

            DetailColumnsVisibility();

            DataKeyCheckBox.Visible = true;
            DetailCheckBox.Visible = true;

            txn_4PNumLabel.Text = totalTxn4PNum.ToString("N2") + "\nLeva";
            txn_4RNumLabel.Text = totalTxn4RNum.ToString("N2") + "\nLeva";

            totalTxnNum = totalTxn4PNum + totalTxn4RNum;

            txn_TotaNumLabel.Text = totalTxnNum.ToString("N2") + "\nLeva";

            OverTNum_TotalLabel.Text = totalOverTNum.ToString("N2") + "\nLeva";

            ExcelButton.Visible = true;

        }

        private void ToggleFourthColumnVisibility()
        {
            /// Change the visibility of the 4th column based on the CheckBox state

            bool control = DataKeyCheckBox.Checked;

            jQueryRelated_Month_Progress_Payment_GridView.Columns[0].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[2].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[3].Visible = control;
            
            jQueryRelated_Month_Progress_Payment_GridView.Columns[20].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[21].Visible = control;

        }


        private void DetailColumnsVisibility()
        {
            /// Change the visibility of the 4th column based on the CheckBox state

            bool control = DetailCheckBox.Checked;

            jQueryRelated_Month_Progress_Payment_GridView.Columns[6].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[7].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[12].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[13].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[14].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[15].Visible = control;

        }



        protected void DataKeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleFourthColumnVisibility();
            jQueryRelated_Month_Progress_Payment_GridViewBind();
        }


        protected void DetailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DetailColumnsVisibility();
            jQueryRelated_Month_Progress_Payment_GridViewBind();
        }


        //protected void ExcelButton_Click(object sender, EventArgs e)
        //{


        //    DataKeyCheckBox.Checked = true;
        //    DetailCheckBox.Checked = true;

            
          
        //    ToggleFourthColumnVisibility();

        //    DetailColumnsVisibility();


        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;


        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;

        //    int numRows = jQueryRelated_Month_Progress_Payment_GridView.Rows.Count; // Pulls number of Rows.

        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryRelated_Month_Progress_Payment_GridView.Rows[0].Cells.Count; // Pulls number of Columns.


        //        for (int i = 0; i < numColumns; i++)   // For Header Color and Column Width
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 10;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "Progress List";

        //        // Create a header row



        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryRelated_Month_Progress_Payment_GridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }


        //        // Add data to the worksheet

        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = jQueryRelated_Month_Progress_Payment_GridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //            }
        //        }

        //        // Change columns text to number which you need to

        //        int ColumnIndex = 7;

        //        for (int i = ColumnIndex; i <= 20; i++)
        //        {
        //            worksheet.Columns[i].TextToColumns();
        //            worksheet.Columns[i].NumberFormat = "0,00";
        //        }


        //        worksheet.Range["1:1"].AutoFilter(16, ">0");


        //        DataKeyCheckBox.Checked = false;
        //        DetailCheckBox.Checked = false;



        //        ToggleFourthColumnVisibility();

        //        DetailColumnsVisibility();


        //    }
        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Progress for EXCEL');</script>");

        //        DataKeyCheckBox.Checked = false;
        //        DetailCheckBox.Checked = false;



        //        ToggleFourthColumnVisibility();

        //        DetailColumnsVisibility();

        //    }


        //}

        protected void ExcelButton_Click(object sender, EventArgs e)
        {

            DataKeyCheckBox.Checked = true;
            DetailCheckBox.Checked = true;



            ToggleFourthColumnVisibility();

            DetailColumnsVisibility();


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("ProgressPaymentList");

                int numRows = jQueryRelated_Month_Progress_Payment_GridView.Rows.Count;   // Pulls number of Rows.
                if (numRows > 0)
                {
                    int numColumns = jQueryRelated_Month_Progress_Payment_GridView.Rows[0].Cells.Count;   // Pulls number of Columns. 

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 1).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryRelated_Month_Progress_Payment_GridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryRelated_Month_Progress_Payment_GridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;

                            // Apply date format to the 5th column (assuming it's column index 4)
                            if (j == 4) // Adjust the column index as needed                          
                            {
                                DateTime date;
                                if (DateTime.TryParse(cellValue, out date))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = date;
                                }

                            }
                            if (j == 5) // Adjust the column index as needed                          
                            {
                                DateTime date;
                                if (DateTime.TryParse(cellValue, out date))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = date;
                                }

                            }
                            else if (j == 0 || j == 2 || j==3 || j == 20 || j == 21)
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                }
                            }

                            else if (j>=6 && j<=19 )
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
                    Response.AddHeader("content-disposition", "attachment; filename=ProgressPaymentList.xlsx");
                    Response.BinaryWrite(package.GetAsByteArray());
                    Response.End();
                }
            }
        }
    }
}