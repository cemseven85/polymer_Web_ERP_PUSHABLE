using polymer_Web_ERP_V4.Productivity;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

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
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using OfficeOpenXml.Drawing.Controls;

namespace polymer_Web_ERP_V4.BusinessLayer.Reports
{
    public partial class dailyGranuleProduction : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {


                btnExportToExcel.Visible = false;

                ChartPanel.Visible = false;
                DataPanel.Visible = false;
            }


        }

        private void jQueryListDailyGranuleProductionGridviewBind()
        {

            string monthOfYear = txtMonth.Text;
            string workingMonth = monthOfYear.Substring(5, 2);

            string workingYear = monthOfYear.Substring(0, 4);


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_pReportDailyGranuleProductionAllDays {workingYear},'{workingMonth}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryListDailyGranuleProductionGridview.DataSource = dt;
                        jQueryListDailyGranuleProductionGridview.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryListDailyGranuleProductionGridview.UseAccessibleHeader = true;
            jQueryListDailyGranuleProductionGridview.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ChartPanel.Visible = false;
            DataPanel.Visible = true;
            btnExportToExcel.Visible = true;
            jQueryListDailyGranuleProductionGridviewBind();
            
        }



        


        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("DailyGranuleProduction");

                int numRows = jQueryListDailyGranuleProductionGridview.Rows.Count;   // Pulls number of Rows.
                if (numRows > 0)
                {
                    int numColumns = jQueryListDailyGranuleProductionGridview.Rows[0].Cells.Count;   // Pulls number of Columns. 

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 1).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = jQueryListDailyGranuleProductionGridview.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = jQueryListDailyGranuleProductionGridview.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;

                            // Apply date format to the 5th column (assuming it's column index 4)

                            if (j == 0)
                            {
                                DateTime date;
                                if (DateTime.TryParse(cellValue, out date))
                                {
                                    worksheet.Cells[i + 2, j + 1].Style.Numberformat.Format = "dd.MM.yyyy";
                                    worksheet.Cells[i + 2, j + 1].Value = date;
                                }

                            }
                            

                            else if (j == 1 )
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
                    Response.AddHeader("content-disposition", "attachment; filename=DailyGranuleProduction.xlsx");
                    Response.BinaryWrite(package.GetAsByteArray());
                    Response.End();
                }
            }
        }




        protected void drowChart()
        {
            ChartPanel.Visible = true;

            string monthOfYear = txtMonth.Text;
            string workingMonth = monthOfYear.Substring(5, 2);

            string workingYear = monthOfYear.Substring(0, 4);

            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_pReportDailyGranuleProductionAllDays {workingYear},'{workingMonth}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);

                        //wire if clause for the dt second column sum is 0 or null then show a message box and return
                        if (dt.AsEnumerable().Sum(row => row.Field<Double>("TotalProduction")) == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no production data for the selected month.')", true);
                            return;
                        }
                        else
                        {


                            //data tabele dt first column date have to be x axis and second column have to be y axis.
                            Chart1.Series["Series1"].XValueMember = "Date";
                            Chart1.Series["Series1"].YValueMembers = "TotalProduction";
                            //Series1 lagent viseble
                            Chart1.Series["Series1"].IsVisibleInLegend = true;
                            Chart1.DataSource = dt;

                            //x axis min is dt min date and max is dt max date
                            Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = DateTime.Parse(dt.Compute("MIN(Date)", "").ToString()).ToOADate();
                            //x axis has to have all dates in the month by the format of dd
                            Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "dd";
                            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                            //y axis min is 0 and max is dt max 12000
                            Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
                            Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 14000;
                            //y axis has to have 0 to 12000 by 500
                            Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 500;

                            //y axis has to have a avaege line for the month
                            Chart1.Series["Series2"].Points.AddXY(DateTime.Parse(dt.Compute("MIN(Date)", "").ToString()).ToOADate(), dt.Compute("AVG(TotalProduction)", ""));
                            Chart1.Series["Series2"].Points.AddXY(DateTime.Parse(dt.Compute("MAX(Date)", "").ToString()).ToOADate(), dt.Compute("AVG(TotalProduction)", ""));
                            Chart1.Series["Series2"].Color = Color.MediumVioletRed;
                            Chart1.Series["Series2"].BorderWidth = 2;
                            Chart1.Series["Series2"].ChartType = SeriesChartType.Line;
                            Chart1.Series["Series2"].IsVisibleInLegend = true;

                            //column thichness
                            Chart1.Series["Series1"]["PointWidth"] = "0.6";

                            //x axis title with font size
                            Chart1.ChartAreas["ChartArea1"].AxisX.Title = $"{monthOfYear}";
                            Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12);


                            //y axis title
                            Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Daily Production KG / Day";
                            //title font size
                            Chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12);


                            //grid line color
                            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
                            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;

                            //chart title with font size
                            Chart1.Titles.Add($"{monthOfYear} Daily Granule Production");
                            Chart1.Titles[0].Font = new Font("Arial", 14);

                            //chart back color
                            Chart1.BackColor = Color.White;

                            //chart border color
                            Chart1.BorderColor = Color.DarkGreen;
                            Chart1.BorderWidth = 2;


                            //count the dt second column rows where values are biger than 0
                            int count = dt.AsEnumerable().Count(row => row.Field<Double>("TotalProduction") > 0);

                            //write the count to the chart
                            Chart1.Titles.Add($"Total Production Days  : {count}");
                            Chart1.Titles[1].Font = new Font("Arial", 12);
                            Chart1.Titles[1].ForeColor = Color.Red;


                            //sum all the dt second column rows
                            double monthlyProduction = dt.AsEnumerable().Sum(row => row.Field<Double>("TotalProduction"));
                            //convert monthlyProduction to string with 2 decimal and thousand seperator

                            //calculate how many sunday in working month
                            int sundays = Enumerable.Range(1, DateTime.DaysInMonth(int.Parse(workingYear), int.Parse(workingMonth)))
                                .Select(day => new DateTime(int.Parse(workingYear), int.Parse(workingMonth), day))
                                .Count(date => date.DayOfWeek == DayOfWeek.Sunday);

                            //calculate how many saturday in working month
                            int saturdays = Enumerable.Range(1, DateTime.DaysInMonth(int.Parse(workingYear), int.Parse(workingMonth)))
                                .Select(day => new DateTime(int.Parse(workingYear), int.Parse(workingMonth), day))
                                .Count(date => date.DayOfWeek == DayOfWeek.Saturday);

                            //calculate how many working days in the month
                            int workingDays = DateTime.DaysInMonth(int.Parse(workingYear), int.Parse(workingMonth)) - sundays;
                           

                           
                            //calculate persantage of total production divide to working days
                            double dailyAverage = monthlyProduction / workingDays;
                            

                            double targetReaching = (monthlyProduction / (10000*workingDays)) * 100;
                            //convert targetReaching to string with 0 decimal and thousand seperator
                            targetReaching = Math.Round(targetReaching, 0);

                            double capacity = 14000 * workingDays;
                            double capasityUsage = (monthlyProduction / capacity) * 100;
                            //convert capasityUsage to string with 0 decimal and thousand seperator
                            capasityUsage = Math.Round(capasityUsage, 0);

                            

                            // write the monthlyProduction to the chart

                            Chart1.Titles.Add($"Total Production  : {monthlyProduction.ToString("N0")} Kg  ( Target = {targetReaching}%  --  Capasity Usage = {capasityUsage}% )");
                            Chart1.Titles[2].Font = new Font("Arial", 12);
                            Chart1.Titles[2].ForeColor = Color.Red;


                            //add y axis new cosntatnt series at Totaproduction is 10000 with line color green and line width 2

                            Chart1.Series["Series3"].Points.AddXY(DateTime.Parse(dt.Compute("MIN(Date)", "").ToString()).ToOADate(), 10000);
                            Chart1.Series["Series3"].Points.AddXY(DateTime.Parse(dt.Compute("MAX(Date)", "").ToString()).ToOADate(), 10000);
                            Chart1.Series["Series3"].Color = Color.Green;
                            Chart1.Series["Series3"].BorderWidth = 2;
                            Chart1.Series["Series3"].ChartType = SeriesChartType.Line;
                            Chart1.Series["Series3"].IsVisibleInLegend = true;

                            //add y axis new series that has averege of total production for the month with just values more than 0
                            Chart1.Series["Series4"].Points.AddXY(DateTime.Parse(dt.Compute("MIN(Date)", "").ToString()).ToOADate(), dt.AsEnumerable().Where(row => row.Field<Double>("TotalProduction") > 0).Average(row => row.Field<Double>("TotalProduction")));
                            Chart1.Series["Series4"].Points.AddXY(DateTime.Parse(dt.Compute("MAX(Date)", "").ToString()).ToOADate(), dt.AsEnumerable().Where(row => row.Field<Double>("TotalProduction") > 0).Average(row => row.Field<Double>("TotalProduction")));
                            Chart1.Series["Series4"].Color = Color.Blue;
                            Chart1.Series["Series4"].BorderWidth = 2;
                            Chart1.Series["Series4"].ChartType = SeriesChartType.Line;
                            Chart1.Series["Series4"].IsVisibleInLegend = true;


                            //add y axis new series that has averege of total production for the month with all values with dailyAverage Series name is Series5 
                            Chart1.Series["Series5"].Points.AddXY(DateTime.Parse(dt.Compute("MIN(Date)", "").ToString()).ToOADate(), dailyAverage);
                            Chart1.Series["Series5"].Points.AddXY(DateTime.Parse(dt.Compute("MAX(Date)", "").ToString()).ToOADate(), dailyAverage);
                            Chart1.Series["Series5"].Color = Color.Orange;
                            Chart1.Series["Series5"].BorderWidth = 2;
                            Chart1.Series["Series5"].ChartType = SeriesChartType.Line;
                            Chart1.Series["Series5"].IsVisibleInLegend = true;



                            //Lagent text for the series 3 is Target Production
                            Chart1.Series["Series3"].LegendText = "Target Production";
                            //Lagent text for the series 2 is Average Production
                            Chart1.Series["Series2"].LegendText = "Average Production (AllDays)";
                            //Lagent text for the series 1 is Daily Production
                            Chart1.Series["Series1"].LegendText = "Daily Production";
                            //Lagent text for the series 4 is Average Production (Days>0)
                            Chart1.Series["Series4"].LegendText = "Average Production (ProductionDays)";
                            //Lagent text for the series 5 is Daily Average Production
                            Chart1.Series["Series5"].LegendText = "Average Production (WorkingDays)";

                            //Lagent text size
                            Chart1.Legends[0].Font = new Font("Arial", 10);


                            Chart1.DataBind();
                        }

                    }

                }
            }
        }

        protected void btnShowChart_Click(object sender, EventArgs e)
        {
            DataPanel.Visible = false;
            ChartPanel.Visible = true;
            drowChart();
        }
    }
}