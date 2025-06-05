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
//*using Excel = Microsoft.Office.Interop.Excel;  //Before  Excel =   Data Tables And Exels Send Error*/. 
using System.CodeDom.Compiler;
//using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace polymer_Web_ERP_V4
{
    public partial class euCertReports : System.Web.UI.Page
    {

        DataAccess conn = new DataAccess();

        string storedPrc= " ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
            }
        }


        private void EuReportGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;

            string procedure= $"execute {storedPrc} '{StartDate_TextBox.Text}','{FinishDate_TextBox.Text}'";


            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"{procedure}", con))
                {
                    using (System.Data.DataTable dt = new System.Data.DataTable())
                    {
                        sda.Fill(dt);
                        jQueryeuCertReportsGridView.DataSource = dt;   ///////
                        jQueryeuCertReportsGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryeuCertReportsGridView.UseAccessibleHeader = true;
            jQueryeuCertReportsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }




        protected void jQueryeuCertReportsGridViewGridView_PreRender(object sender, EventArgs e)
        {
            this.EuReportGridViewBind();

            if (jQueryeuCertReportsGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryeuCertReportsGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryeuCertReportsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryeuCertReportsGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        protected void report_Click(object sender, EventArgs e)
        {
            string selectedReport;
            

            selectedReport = EUCertReportsRadioButtonList.SelectedItem.Text;

            switch (selectedReport)
            {
                case "Purchased Scrap Detailed":
                    storedPrc = "prc_euCertPlastPurchaseList";
                    Description_TextBox.Text = "Purchased scrap list in the selected time period";
                    break;

                case "Purchased Scrap Summary":
                    storedPrc = "prc_euCertPlastPurchaseSummary";
                    Description_TextBox.Text = "Purchased scrap summary in the selected time period";
                    break;

                case "Production InPut Detailed":
                    storedPrc = "prc_euCertPlastProductionInPutList";
                    Description_TextBox.Text = "List of scrap used in input production in the selected time period";
                    break;

                case "Production InPut Purchased Summary":
                    storedPrc = "prc_euCertPlastProductionInPutListSummeryWout4PolyScrp";
                    Description_TextBox.Text = "Summary of purchased scrap (Not 4 Polymer separated scraps included) used in input production  in the selected time period";
                    break;

                case "Production InPut Purchased and 4Polymer Separated Total Summary":
                    storedPrc = "prc_euCertPlastProductionInPutListSummeryWitht4PolyScrp";
                    Description_TextBox.Text = "Summary of all scraps (4 Polymer separated scraps included) used in input production  in the selected time period";
                    break;

                case "Granule Production Detailed":
                    storedPrc = "prc_euCertPlastGranuleProductionList";
                    Description_TextBox.Text = "List of granule output production in the selected time period";
                    break;

                case "Semi Product Detailed (Separated Scrap/ Plastic Lump /etc.)":
                    storedPrc = "prc_euCertPlastSemiProdProductionList";
                    Description_TextBox.Text = "List of Semi Product (Separated Scrap/ Plastic Lump /etc.) output production in the selected time period";
                    break;

                case "Waste Detailed (Paper/Iron Scrap/ Pet Bottle etc.)":
                    storedPrc = "prc_euCertPlastWasteProductionList";
                    Description_TextBox.Text = "List of waste (Mix Plastic Burrs/Paper/Iron Scrap/ Pet Bottle etc.) output production in the selected time period";
                    break;

                case "Production OutPut Detailed":
                    storedPrc = "prc_euCertPlastProductionOutPutList";
                    Description_TextBox.Text = "List of all output production in the selected time period";
                    break;

                case "Production OutPut Total Summary":
                    storedPrc = "prc_euCertPlastProductionOutPutSummary";
                    Description_TextBox.Text = "Summary of all output production in the selected time period";
                    break;

                case "Purchase Scrap Stock":
                    storedPrc = "prc_euCertPlastStockOfPurchaseScrap";
                    Description_TextBox.Text = "Stock of purchased scrap 4 Polymer separated scraps Not included ";
                    break;

                case "4Polymer Separated Scrap Stock":
                    storedPrc = "prc_euCertPlastStockOf4PolyScrap";
                    Description_TextBox.Text = "Stock of 4 Polymer separated scraps";
                    break;

                case "4Polymer Mass Balance Grand":
                    storedPrc = "prc_euCertMassBalanceGrand";
                    Description_TextBox.Text = " Mass Balance Grand =[All input scraps sum (purchased and 4 polymer separated scraps )]  --- minus ---  [all output productions sum ( Grannule / Lump /  4 polymer separated scraps / Waste )] ";
                    break;

                case "4Polymer Mass Balance Grand Ratio":
                    storedPrc = "prc_euCertMassBalanceGrandRatio";
                    Description_TextBox.Text = " Mass Balance Grand Ratio = [All output productions sum ( Grannule / Lump /  4 polymer separated scraps / Waste )]  Ratio Of    [All input scraps sum (purchased and 4 polymer separated scraps )] ";

                    break;

                case "4Polymer Mass Balance Total":
                    storedPrc = "prc_euCertMassBalanceTotal";
                    Description_TextBox.Text = " Mass Balance Total =[Just Purchased InPut scraps sum (Not Inculude 4 polymer separated scraps )]  --- minus ---  [ Output productions sum ( Grannule / Lump  / Waste )]  --- minus ---  [4 polymer separated scraps which has got Positive Stock Value] ";
                    break;

                case "4Polymer Mass Balance Total Ratio":
                    storedPrc = "prc_euCertMassBalanceTotalRatio";
                    Description_TextBox.Text = " Mass Balance Grand Ratio = [ Output productions sum ( Grannule / Lump  / Waste )] and [4 polymer separated scraps which has got Positive Stock Value]  Ratio Of  [Just Purchased InPut scraps sum (Not Inculude 4 polymer separated scraps )] ";
                    break;

                default:

                    break;
            }

            EuReportGridViewBind();


            
        }

        //protected void ExcelButton_Click(object sender, EventArgs e)
        //{
        //    // Create a new Excel application object

        //    Excel.Application excelApp = new Excel.Application();
        //    excelApp.Visible = true;

        //    // Create a new workbook
        //    Excel.Workbook workbook = excelApp.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.ActiveSheet;


        //    int numRows = jQueryeuCertReportsGridView.Rows.Count;   // Pulls number of Rows.
        //    if (numRows > 0)
        //    {
        //        int numColumns = jQueryeuCertReportsGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

        //            worksheet.Columns[i + 2].ColumnWidth = 21;

        //        }

        //        worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

        //        worksheet.Name = "euCert_Report";





        //        // Create a header row

        //        for (int i = 0; i < numColumns; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = jQueryeuCertReportsGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
        //        }

        //        // Add data to the worksheet


        //        for (int i = 0; i < numRows; i++)
        //        {
        //            for (int j = 0; j < numColumns; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = jQueryeuCertReportsGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
        //            }

        //        }


        //        // Change columns text to number which you need to 

        //        string selectedReport;
        //        selectedReport = EUCertReportsRadioButtonList.SelectedItem.Text;

        //        int ColumnIndex;

        //        switch (selectedReport)
        //        {
        //            case "Purchased Scrap Detailed":
        //                 ColumnIndex = 11;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Purchased Scrap Summary":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Production InPut Detailed":
        //                ColumnIndex = 6;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Production InPut Purchased Summary":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Production InPut Purchased and 4Polymer Separated Total Summary":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Granule Production Detailed":
        //                ColumnIndex = 6;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";
        //                break;

        //            case "Semi Product Detailed (Separated Scrap/ Plastic Lump /etc.)":
        //                ColumnIndex = 6;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Waste Detailed (Paper/Iron Scrap/ Pet Bottle etc.)":
        //                ColumnIndex = 6;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Production OutPut Detailed":
        //                ColumnIndex = 6;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Production OutPut Total Summary":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "Purchase Scrap Stock":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "4Polymer Separated Scrap Stock":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";


        //                break;

        //            case "4Polymer Mass Balance Grand":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "4Polymer Mass Balance Grand Ratio":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                ColumnIndex = 3;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0.00%";

        //                break;

        //            case "4Polymer Mass Balance Total":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                break;

        //            case "4Polymer Mass Balance Total Ratio":
        //                ColumnIndex = 2;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

        //                ColumnIndex = 3;

        //                worksheet.Columns[ColumnIndex].TextToColumns();
        //                worksheet.Columns[ColumnIndex].NumberFormat = "0.00%";

        //                break;

        //            default:

        //                break;

        //        }



        //        /*
        //        // To Filter any column from table  

        //       worksheet.Range["1:1"].AutoFilter(1, ">0");

        //       */

        //        // Get the range of your data (adjust the range according to your actual data)
        //        Microsoft.Office.Interop.Excel.Range dataRange = worksheet.UsedRange;

        //        // Sort the data based on the values in the first column (Assuming your data starts from the second row, adjust as needed)
        //        dataRange.Sort(dataRange.Columns[1], Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
        //            Header: Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes,
        //            MatchCase: false,
        //            Orientation: Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns);



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

           
             
        //  /*
        //    StartDate_TextBox.Text = null;
        //    FinishDate_TextBox.Text = null;
        //    Description_TextBox.Text = null;
        //    EUCertReportsRadioButtonList.SelectedIndex = -1;
        //  */

        //}


        protected void ExcelButton_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("EuCertReport");

                string selectedReport;
                selectedReport = EUCertReportsRadioButtonList.SelectedItem.Text;

                int numRows = jQueryeuCertReportsGridView.Rows.Count;     // Pull Num Of Rows
                if (numRows > 0)
                {
                    int numColumns = jQueryeuCertReportsGridView.Rows[0].Cells.Count;  //  Pull Num of Columns

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 2).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryeuCertReportsGridView.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryeuCertReportsGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;


                            // Change columns text to number which you need to 

                            

                            int ColumnIndex;

                            switch (selectedReport)
                            {
                                case "Purchased Scrap Detailed":
                                    

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

                                    // Apply numeric format to  (assuming it's column index 1 and 3 )
                                    if (j == 1 || j == 2 || j==5 || j==6 || j==12) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }

                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 10) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }

                                    break;

                                case "Purchased Scrap Summary":
                                    ColumnIndex = 2;

                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }


                                    break;

                                case "Production InPut Detailed":
                                    ColumnIndex = 6;


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

                                    // Apply numeric format to  (assuming it's column index 1 and 3 )
                                    if (j == 1 || j == 2 ) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

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


                                    break;

                                case "Production InPut Purchased Summary":
                                    ColumnIndex = 2;

                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }


                                    break;

                                case "Production InPut Purchased and 4Polymer Separated Total Summary":
                                    ColumnIndex = 2;
                                    
                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }



                                    break;

                                case "Granule Production Detailed":
                                    ColumnIndex = 6;


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

                                    // Apply numeric format to  (assuming it's column index 1 and 3 )
                                    if (j == 1 || j == 2) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

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





                                    break;

                                case "Semi Product Detailed (Separated Scrap/ Plastic Lump /etc.)":
                                    ColumnIndex = 6;

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

                                    // Apply numeric format to  (assuming it's column index 1 and 3 )
                                    if (j == 1 || j == 2) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

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


                                    break;

                                case "Waste Detailed (Paper/Iron Scrap/ Pet Bottle etc.)":
                                    ColumnIndex = 6;

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

                                    // Apply numeric format to  (assuming it's column index 1 and 3 )
                                    if (j == 1 || j == 2) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

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


                                    break;

                                case "Production OutPut Detailed":
                                    ColumnIndex = 6;

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

                                    // Apply numeric format to  (assuming it's column index 1 and 3 )
                                    if (j == 1 || j == 2) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

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



                                    break;

                                case "Production OutPut Total Summary":
                                    ColumnIndex = 2;


                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }


                                    break;

                                case "Purchase Scrap Stock":
                                    ColumnIndex = 2;


                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }


                                    break;

                                case "4Polymer Separated Scrap Stock":
                                    ColumnIndex = 2;


                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }



                                    break;

                                case "4Polymer Mass Balance Grand":
                                    ColumnIndex = 2;


                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }



                                    break;

                                case "4Polymer Mass Balance Grand Ratio":
                                    ColumnIndex = 2;


                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }


                                    ColumnIndex = 3;

                                   
                                   

                                    break;

                                case "4Polymer Mass Balance Total":
                                    ColumnIndex = 2;


                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }


                                    break;

                                case "4Polymer Mass Balance Total Ratio":
                                    ColumnIndex = 2;


                                    // Apply numeric format to the sixth column (assuming it's column index 6)
                                    if (j == 1) // Adjust the column index as needed
                                    {
                                        double numericValue;
                                        if (double.TryParse(cellValue, out numericValue))
                                        {
                                            worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0.00";
                                            worksheet.Cells[i + 2, j + 1].Value = numericValue;

                                        }
                                    }


                                    ColumnIndex = 3;

                                   
                                   

                                    break;

                                default:

                                    break;

                            }


                            //// Apply date format to the second column (assuming it's column index 1)
                            //if (j ==0 ) // Adjust the column index as needed
                            //{
                            //    DateTime dateTime;
                            //    if (DateTime.TryParse(cellValue, out dateTime))
                            //    {
                            //        worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
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

                            //// Apply numeric format to  (assuming it's column index 1 and 3 )
                            //if (j == 0 || j == 2) // Adjust the column index as needed
                            //{
                            //    double numericValue;
                            //    if (double.TryParse(cellValue, out numericValue))
                            //    {
                            //        worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "0";
                            //        worksheet.Cells[i + 2, j + 1].Value = numericValue;

                            //    }
                            //}



                        }
                    }

                    // Apply AutoFilter to all columns (including the header row)
                    worksheet.Cells[1, 1, numRows + 1, numColumns].AutoFilter = true;

                }

                // Save the workbook    "C:\Users\Public\Documents"
                //var datetime = DateTime.Now;
                //var filePath = @"C:\Users\Public\Documents\" + datetime.ToString("dd-MM-yyyy_hh-mm-ss") + ".xlsx";
                //package.SaveAs(new FileInfo(filePath));


                string fileName = selectedReport+".xlsx"; // Set your desired filename here

                // Now you can work with the workbook in memory (e.g., send it as a response to the client).
                // You don't need to save it to a specific path.
                // For example, you can return the package as a download response:
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();


            }
        }


    }
}


