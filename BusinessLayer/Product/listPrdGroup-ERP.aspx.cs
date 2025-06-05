using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Drawing;
//using System.Windows.Forms;
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


namespace polymer_Web_ERP_V4
{
    public partial class listPrdGroup_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

            


            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }


        private void BindGrid()
        {

            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {     // I change the full query to store Procedure "Select prod_Grp_Id as Id,prod_Type_Id as 'Type Id' ,prod_Grp_Name as 'Name', prod_Grp_Name_BG as 'Name BG',prod_Grp_Name_TR as 'Name TR',prod_Grp_Description as 'Description' from tbl_productGroup"
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listProductGroup", con))  
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryProductGroupGridView.DataSource = dt;
                        jQueryProductGroupGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryProductGroupGridView.UseAccessibleHeader = true;
            jQueryProductGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;


            //  !!!!!!      Error when selected index change not working . !!!!!!!!

            //Drop Doown List Code  


        }

        protected void ProductGroupIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void jQueryProductGroupGridView_PreRender(object sender, EventArgs e)
        {
            this.BindGrid();

            if (jQueryProductGroupGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryProductGroupGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryProductGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryProductGroupGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        protected void ExcelButton_Click(object sender, EventArgs e)
        {
            // Create a new Excel application object

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Create a new workbook
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            int numRows = jQueryProductGroupGridView.Rows.Count;   // Pulls number of Rows.
            int numColumns = jQueryProductGroupGridView.Rows[0].Cells.Count;   // Pulls number of Columns. 


            for (int i = 0; i < numColumns; i++)
            {
                worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

                worksheet.Columns[i + 2].ColumnWidth = 21;

            }

            worksheet.Cells[1, 1].EntireRow.Font.Bold = true;

            worksheet.Name = "Products List";





            // Create a header row

            for (int i = 0; i < numColumns; i++)
            {
                worksheet.Cells[1, i + 1] = jQueryProductGroupGridView.HeaderRow.Cells[i].Text;   // By This Code We pull the Column Names
            }

            // Add data to the worksheet


            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = jQueryProductGroupGridView.Rows[i].Cells[j].Text.Replace("&nbsp;", " ");
                }

            }


            // Change columns text to number which you need to 
            /*
            int ColumnIndex = 8;
            worksheet.Columns[ColumnIndex].TextToColumns();
            worksheet.Columns[ColumnIndex].NumberFormat = "0,00";

            ColumnIndex = 9;
            worksheet.Columns[ColumnIndex].TextToColumns();
            worksheet.Columns[ColumnIndex].NumberFormat = "0,00";
            */

            worksheet.Range["1:1"].AutoFilter(1, ">0");



            /*
            // Save the workbook and close the Excel application
            workbook.SaveAs("MyData.xlsx");
            workbook.Close();
            excelApp.Quit();
            */



        }




    }
}