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
using Excel = Microsoft.Office.Interop.Excel;  //Before  Excel =   Data Tables And Exels Send Error. 
using OfficeOpenXml;

namespace polymer_Web_ERP_V4
{
    public partial class listShipment_ERP : System.Web.UI.Page
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

                AllShipDetailPanel.Visible = false;
                AllShipItemsPanel.Visible = false;
                
                SelectedShipDetailPanel.Visible=false;
                SelectedShipItemsPanel.Visible = false;

            }

        }

        private void jQueryShipGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listLShipments '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}'", con))
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
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_shippingLSumDetail '{ItemDateMin_TextBox.Text}' ,'{ItemDateMax_TextBox.Text}'", con))
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
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listLSumShippingItems '{ItemDateMin_TextBox.Text}' ,'{ItemDateMax_TextBox.Text}'", con))
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





        protected void ShowShippmentButton_Click(object sender, EventArgs e)
        {
            AllShipDetailPanel.Visible = false;
            AllShipItemsPanel.Visible = false;

            SelectedShipDetailPanel.Visible = false;
            SelectedShipItemsPanel.Visible = false;
            jQueryShipGridViewBind();
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

        //protected void ExcelButtonLSh_Click(object sender, EventArgs e)
        //{
        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;

        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;


        //    int numRows = jQueryShipGridView.Rows.Count;   // Pulls number of Rows.
        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryShipGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 21;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "Shipment List";





        //        // Create a header row

        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryShipGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }

        //        // Add data to the worksheet

        //        String tempValue = "";
        //        DateTime dateValue;
        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {  
        //                if(j == 1)    // Column That Has To Changed to Date Format  
        //                {
        //                  tempValue= jQueryShipGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                  tempValue = tempValue.Substring(0,10);
        //                  dateValue = DateTime.ParseExact(tempValue, "yyyy/MM/dd", null);
        //                  worksheet.Cells[i + 2, j + 1] = dateValue;
        //                }
        //                else
        //                {
        //                  worksheet.Cells[i + 2, j + 1] = jQueryShipGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                }
                        
        //            }

        //        }


        //        // Change columns text to number which you need to 

        //        int ColumnIndex = 5;


        //        worksheet.Columns[ColumnIndex].TextToColumns();
        //        worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


        //        //Change columns text to Date which you need to 
        //        // I solved it in this part Add data to the worksheet  





        //        // Add filter to data  

        //        worksheet.Range["1:1"].AutoFilter(5, ">0");



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


        protected void ExcelButtonLSh_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("ShipmentList");

                int numRows = jQueryShipGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryShipGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryShipGridView.HeaderRow.Cells[i].Text;
                    }


                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryShipGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            // Apply date format to the second column (assuming it's column index 1)
                            if (j == 1) // Adjust the column index as needed
                            {
                                DateTime dateTime;
                                if (DateTime.TryParse(cellValue, out dateTime))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = dateTime;
                                }
                            }


                            // Apply numeric format to the sixth column (assuming it's column index 6)
                            if (j == 4) // Adjust the column index as needed
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
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
                Response.AddHeader("content-disposition", "attachment; filename=ShipmentList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();


            }
        }


        //protected void ExcelButtonLShD_Click(object sender, EventArgs e)
        //{
        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;

        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;


        //    int numRows = jQueryShipDetailGridView.Rows.Count;   // Pulls number of Rows.
        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryShipDetailGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 21;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "Selected Ship Summary";





        //        // Create a header row

        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryShipDetailGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }

        //        // Add data to the worksheet

        //        String tempValue = "";
        //        DateTime dateValue;
        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                if (j == 1)    // Column That Has To Changed to Date Format  
        //                {
        //                    tempValue = jQueryShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                    tempValue = tempValue.Substring(0, 10);
        //                    dateValue = DateTime.ParseExact(tempValue, "dd.MM.yyyy", null);
        //                    worksheet.Cells[i + 2, j + 1] = dateValue;
        //                }
        //                else
        //                {
        //                    worksheet.Cells[i + 2, j + 1] = jQueryShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                }

        //            }

        //        }


        //        // Change columns text to number which you need to 

        //        int ColumnIndex = 5;


        //        worksheet.Columns[ColumnIndex].TextToColumns();
        //        worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


        //        //Change columns text to Date which you need to 
        //        // I solved it in this part Add data to the worksheet  





        //        // Add filter to data  

        //        worksheet.Range["1:1"].AutoFilter(5, ">0");



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


        protected void ExcelButtonLShD_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("ShipmentDetailList");

                int numRows = jQueryShipDetailGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryShipDetailGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryShipDetailGridView.HeaderRow.Cells[i].Text;
                    }


                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            // Apply date format to the second column (assuming it's column index 1)
                            if (j == 1) // Adjust the column index as needed
                            {
                                DateTime dateTime;
                                if (DateTime.TryParse(cellValue, out dateTime))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = dateTime;
                                }
                            }


                            // Apply numeric format to the sixth column (assuming it's column index 6)
                            if (j == 4) // Adjust the column index as needed
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
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
                Response.AddHeader("content-disposition", "attachment; filename=ShipmentDetailList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();


            }
        }



        //protected void ExcelButtonLAllShD_Click(object sender, EventArgs e)
        //{
        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;

        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;


        //    int numRows = jQueryAllShipDetailGridView.Rows.Count;   // Pulls number of Rows.
        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryAllShipDetailGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 21;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "All Ship Summary";





        //        // Create a header row

        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryAllShipDetailGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }

        //        // Add data to the worksheet

        //        String tempValue = "";
        //        DateTime dateValue;
        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                if (j == 1)    // Column That Has To Changed to Date Format  
        //                {
        //                    tempValue = jQueryAllShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                    tempValue = tempValue.Substring(0, 10);
        //                    dateValue = DateTime.ParseExact(tempValue, "dd.MM.yyyy", null);
        //                    worksheet.Cells[i + 2, j + 1] = dateValue;
        //                }
        //                else
        //                {
        //                    worksheet.Cells[i + 2, j + 1] = jQueryAllShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                }

        //            }

        //        }


        //        // Change columns text to number which you need to 

        //        int ColumnIndex = 5;


        //        worksheet.Columns[ColumnIndex].TextToColumns();
        //        worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


        //        //Change columns text to Date which you need to 
        //        // I solved it in this part Add data to the worksheet  





        //        // Add filter to data  

        //        worksheet.Range["1:1"].AutoFilter(5, ">0");



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


        protected void ExcelButtonLAllShD_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("AllShipmentDetailList");

                int numRows = jQueryAllShipDetailGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryAllShipDetailGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryAllShipDetailGridView.HeaderRow.Cells[i].Text;
                    }


                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryAllShipDetailGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            // Apply date format to the second column (assuming it's column index 1)
                            if (j == 1) // Adjust the column index as needed
                            {
                                DateTime dateTime;
                                if (DateTime.TryParse(cellValue, out dateTime))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = dateTime;
                                }
                            }


                            // Apply numeric format to the sixth column (assuming it's column index 6)
                            if (j == 4) // Adjust the column index as needed
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
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
                Response.AddHeader("content-disposition", "attachment; filename=AllShipmentDetailList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();


            }

        }


        //protected void ExcelButtonLShI_Click(object sender, EventArgs e)
        //{
        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;

        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;


        //    int numRows = jQueryShipItemListGridView.Rows.Count;   // Pulls number of Rows.
        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryShipItemListGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 21;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "Selected Ship Item List";





        //        // Create a header row

        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryShipItemListGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }

        //        // Add data to the worksheet

        //        String tempValue = "";
        //        DateTime dateValue;
        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                if (j == 1)    // Column That Has To Changed to Date Format  
        //                {
        //                    tempValue = jQueryShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                    tempValue = tempValue.Substring(0, 10);
        //                    dateValue = DateTime.ParseExact(tempValue, "dd.MM.yyyy", null);
        //                    worksheet.Cells[i + 2, j + 1] = dateValue;
        //                }
        //                else
        //                {
        //                    worksheet.Cells[i + 2, j + 1] = jQueryShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                }

        //            }

        //        }


        //        // Change columns text to number which you need to 

        //        int ColumnIndex = 7;


        //        worksheet.Columns[ColumnIndex].TextToColumns();
        //        worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


        //        //Change columns text to Date which you need to 
        //        // I solved it in this part Add data to the worksheet  





        //        // Add filter to data  

        //        worksheet.Range["1:1"].AutoFilter(5, ">0");



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

        protected void ExcelButtonLShI_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("ShipmentItemlList");

                int numRows = jQueryShipItemListGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryShipItemListGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryShipItemListGridView.HeaderRow.Cells[i].Text;
                    }


                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            // Apply date format to the second column (assuming it's column index 1)
                            if (j == 1) // Adjust the column index as needed
                            {
                                DateTime dateTime;
                                if (DateTime.TryParse(cellValue, out dateTime))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = dateTime;
                                }
                            }


                            // Apply numeric format to the sixth column (assuming it's column index 6)
                            if (j == 7) // Adjust the column index as needed
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                }
                            }


                            // Apply numeric format to  (assuming it's column index 1 and 3 )
                            if (j == 2 || j==3 || j==4) // Adjust the column index as needed
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
                Response.AddHeader("content-disposition", "attachment; filename=ShipmentItemlList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();


            }

        }

        //protected void ExcelButtonLAllShI_Click(object sender, EventArgs e)
        //{
        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;

        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;


        //    int numRows = jQueryAllShipItemListGridView.Rows.Count;   // Pulls number of Rows.
        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryAllShipItemListGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 21;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "All Ship Item List";





        //        // Create a header row

        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryAllShipItemListGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }

        //        // Add data to the worksheet

        //        String tempValue = "";
        //        DateTime dateValue;
        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                if (j == 1)    // Column That Has To Changed to Date Format  
        //                {
        //                    tempValue = jQueryAllShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                    tempValue = tempValue.Substring(0, 10);
        //                    dateValue = DateTime.ParseExact(tempValue, "dd.MM.yyyy", null);
        //                    worksheet.Cells[i + 2, j + 1] = dateValue;
        //                }
        //                else
        //                {
        //                    worksheet.Cells[i + 2, j + 1] = jQueryAllShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //                }

        //            }

        //        }


        //        // Change columns text to number which you need to 

        //        int ColumnIndex = 7;


        //        worksheet.Columns[ColumnIndex].TextToColumns();
        //        worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


        //        //Change columns text to Date which you need to 
        //        // I solved it in this part Add data to the worksheet  





        //        // Add filter to data  

        //        worksheet.Range["1:1"].AutoFilter(5, ">0");



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

        protected void ExcelButtonLAllShI_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("AllShipmentItemlList");

                int numRows = jQueryAllShipItemListGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryAllShipItemListGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryAllShipItemListGridView.HeaderRow.Cells[i].Text;
                    }


                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryAllShipItemListGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            // Apply date format to the second column (assuming it's column index 1)
                            if (j == 1) // Adjust the column index as needed
                            {
                                DateTime dateTime;
                                if (DateTime.TryParse(cellValue, out dateTime))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = dateTime;
                                }
                            }


                            // Apply numeric format to the sixth column (assuming it's column index 6)
                            if (j == 7) // Adjust the column index as needed
                            {
                                double numericValue;
                                if (double.TryParse(cellValue, out numericValue))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                    worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                }
                            }


                            // Apply numeric format to  (assuming it's column index 1 and 3 )
                            if (j == 2 || j == 3 || j == 4) // Adjust the column index as needed
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
                Response.AddHeader("content-disposition", "attachment; filename=AllShipmentItemlList.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();


            }

        }

    }
}