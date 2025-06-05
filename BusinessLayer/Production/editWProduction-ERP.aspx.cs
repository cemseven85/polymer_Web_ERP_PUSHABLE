using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;
using System.Collections;

namespace polymer_Web_ERP_V4
{
    public partial class editProduction_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        addWProduction_ERP wProductionData = new addWProduction_ERP();

        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime dateMax = DateTime.Now;
            DateTime dateMin = dateMax.AddDays(-90);

            if (!this.IsPostBack)
            {
                ItemDateMin_TextBox.Text = dateMin.ToString("yyyy-MM-dd");
                ItemDateMax_TextBox.Text = dateMax.ToString("yyyy-MM-dd");

                InPutProductionGridViewBind();
                DropDownEmployeeBind();

                Purchase_Unit_TextBox.Text = "Kg";
            }

        }


        private void InPutProductionGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listInPutProduction '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}' ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryInPutProductionGridView.DataSource = dt;
                        jQueryInPutProductionGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryInPutProductionGridView.UseAccessibleHeader = true;
            jQueryInPutProductionGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryScrapGridView_PreRender(object sender, EventArgs e)
        {
            this.InPutProductionGridViewBind();

            if (jQueryInPutProductionGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryInPutProductionGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryInPutProductionGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryInPutProductionGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        //private void DropDownEmployeeBind()
        //{
        //    string com = $"Select * from [tbl_employee]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    EmployeeIDDropDownList.DataSource = dt2;
        //    EmployeeIDDropDownList.DataBind();
        //    EmployeeIDDropDownList.DataTextField = "empl_Name_TR";
        //    EmployeeIDDropDownList.DataValueField = "empl_Id";
        //    EmployeeIDDropDownList.DataBind();
        //}



        private void DropDownEmployeeBind()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                string com = "SELECT * FROM [tbl_employee]";
                SqlDataAdapter adpt = new SqlDataAdapter(com, connection);
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                EmployeeIDDropDownList.DataSource = dt2;
                EmployeeIDDropDownList.DataTextField = "empl_Name_TR";
                EmployeeIDDropDownList.DataValueField = "empl_Id";
                EmployeeIDDropDownList.DataBind();
            }
        }


        //protected void jQueryInPutProductionGridView_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    GridViewRow row = jQueryInPutProductionGridView.SelectedRow;


        //    Purchase_Quantity_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);


        //    //Employee Name To ID
        //    string employeeName = row.Cells[9].Text;
        //    string com6 = $"select [empl_Id] from [tbl_employee] where [empl_Name_TR]='{employeeName}'";
        //    SqlDataAdapter adpt5 = new SqlDataAdapter(com6, conn.Connection());
        //    DataTable dt7 = new DataTable();
        //    adpt5.Fill(dt7);
        //    string ridEmployee = dt7.Rows[0][0].ToString();


        //    //Employee Name Pulling
        //    EmployeeIDDropDownList.SelectedValue = ridEmployee;

        //    Weight_Brige_Code_TextBox.Text= EncodeDecodeModule.EncodeDecode(row, 8);
        //    Num_Bales_TextBox.Text= EncodeDecodeModule.EncodeDecode(row, 10);
        //    Production_Note_TextBox.Text= EncodeDecodeModule.EncodeDecode(row, 11);


        //    // wProductionData.IntStock   We can reach the stock by  this code But which stock ?? 
        //    // Lets tyr ??  I try But Not work Right
        //    // Lets tyr ??  I try But Not work Right



        //}




        protected void jQueryInPutProductionGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                GridViewRow row = jQueryInPutProductionGridView.SelectedRow;

                Purchase_Quantity_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);

                // Employee Name To ID
                string employeeName = row.Cells[9].Text;
                string com6 = $"select [empl_Id] from [tbl_employee] where [empl_Name_TR]='{employeeName}'";
                using (SqlDataAdapter adpt5 = new SqlDataAdapter(com6, connection))
                {
                    DataTable dt7 = new DataTable();
                    adpt5.Fill(dt7);
                    string ridEmployee = dt7.Rows[0][0].ToString();

                    // Employee Name Pulling
                    EmployeeIDDropDownList.SelectedValue = ridEmployee;
                }

                Weight_Brige_Code_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 8);
                Num_Bales_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 10);
                Production_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);
            }
        }



        //protected void EditButton_Click(object sender, EventArgs e)
        //{

        //    GridViewRow row = jQueryInPutProductionGridView.SelectedRow;


        //    if (row != null)
        //    {

        //        string prodI_Id = "";
        //        string item_Id = " ";
        //        string quantity;
        //        string stock;
        //        string subStock;
        //        string employeeID;
        //        string weightBridgeCode;
        //        string numBales;
        //        string notes;

        //        quantity = Purchase_Quantity_TextBox.Text;
        //        prodI_Id = row.Cells[1].Text;
        //        item_Id = row.Cells[7].Text;
        //        employeeID = EmployeeIDDropDownList.SelectedValue;
        //        numBales = Num_Bales_TextBox.Text;
        //        notes = Production_Note_TextBox.Text;
        //        weightBridgeCode = Weight_Brige_Code_TextBox.Text;

        //        subStock = row.Cells[4].Text;

        //        float subNumStock = float.Parse(subStock);

        //        float intQuantity = float.Parse(quantity);


        //        // Trying Trying Trying
        //        //We need the take the dynamic stock before this last production for limmiting the edit Quantitiy. 
        //        string com = $"execute  prc_stockControlInPutScrap '{item_Id}' ";
        //        SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //        DataTable dt2 = new DataTable();
        //        adpt.Fill(dt2);

        //        stock = dt2.Rows[0][6].ToString();

        //        float IntStock = float.Parse(stock);

        //        IntStock += subNumStock;

        //        // Trying Trying Trying



        //        if (intQuantity <= IntStock)
        //        {
        //            SqlCommand editItem = new SqlCommand($"update [tbl_productionInput] set [prodI_Quantity]=@quantity ,[prodI_Supervisor_Employee_Id]='{employeeID}',[prodI_NumBales]='{numBales}',[prodI_Weigh_Bridge_Code]='{weightBridgeCode}',[prodI_Notes]='{notes}' where [prodI_Id]= '{prodI_Id}' ", conn.Connection());
        //            editItem.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);


        //            editItem.ExecuteNonQuery();
        //        }

        //        else
        //        {
        //            Response.Write($"<script type=\"text/javascript\">alert('You can not produce more than Stock {IntStock} ');</script>");
        //        }


        //        // Edit Button Control have to code !!!!!

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Production Input for Edit');</script>");
        //    }



        //}



        protected void EditButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryInPutProductionGridView.SelectedRow;

            if (row != null)
            {
                string prodI_Id = "";
                string item_Id = " ";
                string quantity;
                string stock;
                string subStock;
                string employeeID;
                string weightBridgeCode;
                string numBales;
                string notes;

                quantity = Purchase_Quantity_TextBox.Text;
                prodI_Id = row.Cells[1].Text;
                item_Id = row.Cells[7].Text;
                employeeID = EmployeeIDDropDownList.SelectedValue;
                numBales = Num_Bales_TextBox.Text;
                notes = Production_Note_TextBox.Text;
                weightBridgeCode = Weight_Brige_Code_TextBox.Text;

                subStock = row.Cells[4].Text;
                float subNumStock = float.Parse(subStock);
                float intQuantity = float.Parse(quantity);

                string connectionString = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Retrieve dynamic stock before the last production for limiting the edited quantity
                    string com = $"execute prc_stockControlInPutScrap '{item_Id}' ";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, connection);
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    stock = dt2.Rows[0][6].ToString();
                    float IntStock = float.Parse(stock);
                    IntStock += subNumStock;

                    if (intQuantity <= IntStock)
                    {
                        SqlCommand editItem = new SqlCommand($"update [tbl_productionInput] set [prodI_Quantity]=@quantity ,[prodI_Supervisor_Employee_Id]='{employeeID}',[prodI_NumBales]='{numBales}',[prodI_Weigh_Bridge_Code]='{weightBridgeCode}',[prodI_Notes]='{notes}' where [prodI_Id]= '{prodI_Id}' ", connection);
                        editItem.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);
                        editItem.ExecuteNonQuery();
                    }
                    else
                    {
                        Response.Write($"<script type=\"text/javascript\">alert('You can not produce more than Stock {IntStock} ');</script>");
                    }
                }
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Production Input for Edit');</script>");
            }
        }
    


        protected void ShowReportButton_Click(object sender, EventArgs e)
        {
            InPutProductionGridViewBind();
        }
    }
}