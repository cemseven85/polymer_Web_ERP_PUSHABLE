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

namespace polymer_Web_ERP_V4.BusinessLayer.Maintenance
{
    public partial class ListMachineGroup : System.Web.UI.Page
    {

        //add Data Access object with name conn

        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //add gridView bind method for gvMachineGroup my table name is tbl_machineGroup and fileds are machineGroup_ID and machineGroup_Name and machineGroup_Description with using statements for data bas connection an sql command
        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select machineGroup_ID,machineGroup_Name,machineGroup_Description from tbl_machineGroup", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvMachineGroup.DataSource = dt;
                        gvMachineGroup.DataBind();
                    }
                }
            }
        }

        //code prerender event for gridview with using statements for data base connection and sql command
        protected void gvMachineGroup_PreRender(object sender, EventArgs e)
        {
            this.BindGrid();

            // Configure GridView structure
            if (gvMachineGroup.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvMachineGroup.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                gvMachineGroup.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                gvMachineGroup.FooterRow.TableSection = TableRowSection.TableFooter;



            }

        }

        //code for export to excel button click event
        


        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("MachineGroupList");

                int numRows = gvMachineGroup.Rows.Count;   // Pulls number of Rows.
                if (numRows > 0)
                {
                    int numColumns = gvMachineGroup.Rows[0].Cells.Count;   // Pulls number of Columns. 

                    // Set header row formatting
                    for (int i = 0; i < numColumns; i++)
                    {
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        worksheet.Column(i + 1).Width = 21;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[1, i + 1].Value = gvMachineGroup.HeaderRow.Cells[i].Text;
                    }

                    // Add data to the worksheet
                    for (int i = 0; i < numRows; i++)
                    {
                        for (int j = 0; j < numColumns; j++)
                        {
                            string cellValue = gvMachineGroup.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;

                            // Apply date format to the 5th column (assuming it's column index 4)

                        }
                    }

                    // Apply AutoFilter to all columns (including the header row)
                    worksheet.Cells[1, 1, numRows + 1, numColumns].AutoFilter = true;

                    // Save the workbook
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=MachineGroupList.xlsx");
                    Response.BinaryWrite(package.GetAsByteArray());
                    Response.End();
                }
            }
        }


    }
}