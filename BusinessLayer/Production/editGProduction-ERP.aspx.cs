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
using System.Globalization;
using System.Diagnostics;

namespace polymer_Web_ERP_V4
{
    public partial class editGProduction_ERP : System.Web.UI.Page
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
                DropDownPrdGroupBind();
                
                DropDownProductBind();
                DropDownStockZoneBind();
                DropDownEmployeeBind();
                DropDownConsultantBind();



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


        //private void DropDownPrdGroupBind()
        //{
        //    string com = "Select * from tbl_productGroup";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ProductGroupIdDropDownList.DataSource = dt2;
        //    ProductGroupIdDropDownList.DataBind();
        //    ProductGroupIdDropDownList.DataTextField = "prod_Grp_Name";
        //    ProductGroupIdDropDownList.DataValueField = "prod_Grp_Id";
        //    ProductGroupIdDropDownList.DataBind();
        //}


        private void DropDownPrdGroupBind()
        {
            string com = "Select * from tbl_productGroup";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    ProductGroupIdDropDownList.DataSource = dt2;
                    ProductGroupIdDropDownList.DataTextField = "prod_Grp_Name";
                    ProductGroupIdDropDownList.DataValueField = "prod_Grp_Id";
                    ProductGroupIdDropDownList.DataBind();
                }
            }
        }


        protected void ProductGroupIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownProductBind();

        }


        //private void DropDownProductBind()
        //{
        //    string com = $"Select * from [tbl_product] where [prod_Group_Id]='{ProductGroupIdDropDownList.SelectedValue}' ";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ProductIdDropDownList.DataSource = dt2;
        //    ProductIdDropDownList.DataBind();
        //    ProductIdDropDownList.DataTextField = "prod_Name";
        //    ProductIdDropDownList.DataValueField = "prod_Id";
        //    ProductIdDropDownList.DataBind();

        //    Purchase_Unit_TextBox.Text = "KG";
        //}

        //private void DropDownStockZoneBind()
        //{
        //    string com = $"Select * from [tbl_stockZone]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    StockZoneIDDropDownList.DataSource = dt2;
        //    StockZoneIDDropDownList.DataBind();
        //    StockZoneIDDropDownList.DataTextField = "stk_Zn_Name";
        //    StockZoneIDDropDownList.DataValueField = "stk_Zn_Id";
        //    StockZoneIDDropDownList.DataBind();
        //}


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


        //private void DropDownConsultantBind()
        //{
        //    string com = $"Select * from [tbl_consultant]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ConsultantDropDownList.DataSource = dt2;
        //    ConsultantDropDownList.DataBind();
        //    ConsultantDropDownList.DataTextField = "cnslt_Name";
        //    ConsultantDropDownList.DataValueField = "cnslt_Id";
        //    ConsultantDropDownList.DataBind();
        //}




        private void DropDownProductBind()
        {
            string com = $"Select * from [tbl_product] where [prod_Group_Id]='{ProductGroupIdDropDownList.SelectedValue}' ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    ProductIdDropDownList.DataSource = dt2;
                    ProductIdDropDownList.DataTextField = "prod_Name";
                    ProductIdDropDownList.DataValueField = "prod_Id";
                    ProductIdDropDownList.DataBind();
                }
            }

            Purchase_Unit_TextBox.Text = "KG";
        }

        private void DropDownStockZoneBind()
        {
            string com = $"Select * from [tbl_stockZone]";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    StockZoneIDDropDownList.DataSource = dt2;
                    StockZoneIDDropDownList.DataTextField = "stk_Zn_Name";
                    StockZoneIDDropDownList.DataValueField = "stk_Zn_Id";
                    StockZoneIDDropDownList.DataBind();
                }
            }
        }

        private void DropDownEmployeeBind()
        {
            string com = $"Select * from [tbl_employee]";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    EmployeeIDDropDownList.DataSource = dt2;
                    EmployeeIDDropDownList.DataTextField = "empl_Name_TR";
                    EmployeeIDDropDownList.DataValueField = "empl_Id";
                    EmployeeIDDropDownList.DataBind();
                }
            }
        }

        private void DropDownConsultantBind()
        {
            string com = $"Select * from [tbl_consultant]";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    ConsultantDropDownList.DataSource = dt2;
                    ConsultantDropDownList.DataTextField = "cnslt_Name";
                    ConsultantDropDownList.DataValueField = "cnslt_Id";
                    ConsultantDropDownList.DataBind();
                }
            }
        }


        //protected void jQueryOutPutProductionGridView_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    GridViewRow row = jQueryOutPutProductionGridView.SelectedRow;

        //    // First  Date and Time SQL to ASPX Text 

        //    // I use the data from gridview Row because of that I need to now the lenght
        //    //
        //    string dateTime = row.Cells[2].Text; ;
        //    int dateLength=dateTime.Length;
        //    // Need to change format for Date.            
        //    string day;
        //    string month; 
        //    string year;
        //    string date;


        //    if (dateLength == 19)
        //    {
        //        Production_TimeTextBox.Text = row.Cells[2].Text.Substring(11, 8);
        //        year = dateTime.Substring(0, 4);
        //        month = dateTime.Substring(5, 2);
        //        day = dateTime.Substring(8, 2);
        //        date = year + "-" + month + "-" + day  ;
        //    }
        //    else    // UpSide is Working but not sure that part did not test not need  
        //    {
        //        Production_TimeTextBox.Text = row.Cells[2].Text.Substring(10, 8);
        //        day = dateTime.Substring(8, 1); ;
        //        month = dateTime.Substring(5, 2);
        //        year = dateTime.Substring(0, 4);
        //        date = year + "-" + month + "-0" + day; ;

        //    }

        //    Production_DateTextBox.Text =date;


        //    // Second Product And Product Group DropBox Index. 

        //    // Need Product ID we Know The itemID 
        //    string itemID=row.Cells[3].Text;
        //    string com6 = $"select [prod_Id] from [tbl_item] where [item_Id]='{itemID}'";
        //    SqlDataAdapter adpt5 = new SqlDataAdapter(com6, conn.Connection());
        //    DataTable dt7 = new DataTable();
        //    adpt5.Fill(dt7);
        //    string ridProduct = dt7.Rows[0][0].ToString();


        //    string com7 = $"select [prod_Group_Id] from [tbl_product] where [prod_Id]='{ridProduct}'";
        //    SqlDataAdapter adpt6 = new SqlDataAdapter(com7, conn.Connection());
        //    DataTable dt8 = new DataTable();
        //    adpt6.Fill(dt8);
        //    string ridProductGroup = dt8.Rows[0][0].ToString();


        //    ProductGroupIdDropDownList.SelectedValue = ridProductGroup;

        //    // We need to bind the DopDownProduct after selecting the Product Group.

        //    DropDownProductBind();

        //    ProductIdDropDownList.SelectedValue = ridProduct;

        //    Item_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 5);
        //    Purchase_Quantity_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 6);


        //    // Emplyee Name to ID 
        //    string emplName=row.Cells[7].Text;

        //    string com8 = $"select [empl_Id] from [tbl_employee] where [empl_Name_TR]='{emplName}'";
        //    SqlDataAdapter adpt7 = new SqlDataAdapter(com8, conn.Connection());
        //    DataTable dt9 = new DataTable();
        //    adpt7.Fill(dt9);
        //    string ridEmployee = dt9.Rows[0][0].ToString();

        //    EmployeeIDDropDownList.SelectedValue = ridEmployee;

        //    //Consultant Name tTo ID 
        //    string consultantName = row.Cells[10].Text;
        //    string com12 = $"select [cnslt_Id] from [tbl_consultant] where [cnslt_Name]='{consultantName}'";
        //    SqlDataAdapter adpt12= new SqlDataAdapter(com12, conn.Connection());
        //    DataTable dt12 = new DataTable();
        //    adpt12.Fill(dt12);
        //    string ridConsultant = dt12.Rows[0][0].ToString();

        //    //Consultant Name Pulling
        //    ConsultantDropDownList.SelectedValue = ridConsultant;





        //    // StockZone Name to ID 
        //    string stockZoneName =row.Cells[8].Text;

        //    string com9 = $"select [stk_Zn_Id] from [tbl_stockZone] where [stk_Zn_Name]='{stockZoneName}'";
        //    SqlDataAdapter adpt8 =new SqlDataAdapter(com9, conn.Connection());
        //    DataTable dt10 = new DataTable();
        //    adpt8.Fill(dt10);
        //    string ridStockZone = dt10.Rows[0][0].ToString();

        //    StockZoneIDDropDownList.SelectedValue = ridStockZone;


        //    Production_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);


        //    string outPutProductionID;
        //    outPutProductionID=row.Cells[1].Text;

        //    string com10 = $"select [purdO_Weigh_Bridge_Code] from [tbl_productionOutput] where [prodO_Id]='{outPutProductionID}'";
        //    SqlDataAdapter adpt9 = new SqlDataAdapter(com10, conn.Connection());
        //    DataTable dt11 = new DataTable();
        //    adpt9.Fill(dt11);
        //    string weighBridgeCode = dt11.Rows[0][0].ToString();

        //    Weight_Brige_Code_TextBox.Text = weighBridgeCode;




        //}




        protected void jQueryOutPutProductionGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = jQueryOutPutProductionGridView.SelectedRow;

            string dateTime = row.Cells[2].Text;
            int dateLength = dateTime.Length;
            string day;
            string month;
            string year;
            string date;

            if (dateLength == 19)
            {
                Production_TimeTextBox.Text = row.Cells[2].Text.Substring(11, 8);
                year = dateTime.Substring(0, 4);
                month = dateTime.Substring(5, 2);
                day = dateTime.Substring(8, 2);
                date = year + "-" + month + "-" + day;
            }
            else
            {
                Production_TimeTextBox.Text = row.Cells[2].Text.Substring(10, 8);
                day = dateTime.Substring(8, 1);
                month = dateTime.Substring(5, 2);
                year = dateTime.Substring(0, 4);
                date = year + "-" + month + "-0" + day;
            }

            Production_DateTextBox.Text = date;

            string itemID = row.Cells[3].Text;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                connection.Open();

                string com6 = $"select [prod_Id] from [tbl_item] where [item_Id]='{itemID}'";
                using (SqlDataAdapter adpt5 = new SqlDataAdapter(com6, connection))
                {
                    DataTable dt7 = new DataTable();
                    adpt5.Fill(dt7);
                    string ridProduct = dt7.Rows[0][0].ToString();

                    string com7 = $"select [prod_Group_Id] from [tbl_product] where [prod_Id]='{ridProduct}'";
                    using (SqlDataAdapter adpt6 = new SqlDataAdapter(com7, connection))
                    {
                        DataTable dt8 = new DataTable();
                        adpt6.Fill(dt8);
                        string ridProductGroup = dt8.Rows[0][0].ToString();

                        ProductGroupIdDropDownList.SelectedValue = ridProductGroup;
                        DropDownProductBind();
                        ProductIdDropDownList.SelectedValue = ridProduct;
                    }
                }

                Item_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 5);
                Purchase_Quantity_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 6);

                string emplName = row.Cells[7].Text;
                string com8 = $"select [empl_Id] from [tbl_employee] where [empl_Name_TR]='{emplName}'";
                using (SqlDataAdapter adpt7 = new SqlDataAdapter(com8, connection))
                {
                    DataTable dt9 = new DataTable();
                    adpt7.Fill(dt9);
                    string ridEmployee = dt9.Rows[0][0].ToString();
                    EmployeeIDDropDownList.SelectedValue = ridEmployee;
                }

                string consultantName = row.Cells[10].Text;
                string com12 = $"select [cnslt_Id] from [tbl_consultant] where [cnslt_Name]='{consultantName}'";
                using (SqlDataAdapter adpt12 = new SqlDataAdapter(com12, connection))
                {
                    DataTable dt12 = new DataTable();
                    adpt12.Fill(dt12);
                    string ridConsultant = dt12.Rows[0][0].ToString();
                    ConsultantDropDownList.SelectedValue = ridConsultant;
                }

                string stockZoneName = row.Cells[8].Text;
                string com9 = $"select [stk_Zn_Id] from [tbl_stockZone] where [stk_Zn_Name]='{stockZoneName}'";
                using (SqlDataAdapter adpt8 = new SqlDataAdapter(com9, connection))
                {
                    DataTable dt10 = new DataTable();
                    adpt8.Fill(dt10);
                    string ridStockZone = dt10.Rows[0][0].ToString();
                    StockZoneIDDropDownList.SelectedValue = ridStockZone;
                }

                Production_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);

                string outPutProductionID = row.Cells[1].Text;
                string com10 = $"select [purdO_Weigh_Bridge_Code] from [tbl_productionOutput] where [prodO_Id]='{outPutProductionID}'";
                using (SqlDataAdapter adpt9 = new SqlDataAdapter(com10, connection))
                {
                    DataTable dt11 = new DataTable();
                    adpt9.Fill(dt11);
                    string weighBridgeCode = dt11.Rows[0][0].ToString();
                    Weight_Brige_Code_TextBox.Text = weighBridgeCode;
                }
            }
        }


        //protected void EditButton_Click(object sender, EventArgs e)
        //{

        //    GridViewRow row = jQueryOutPutProductionGridView.SelectedRow;

        //    if (row != null)
        //    {

        //        string date;
        //        string time;
        //        string dateTime;
        //        string itemName;
        //        string itemID;
        //        string productID = " ";
        //        string quantity;
        //        string weightBridgeCode;
        //        string employeeID;
        //        string consultantID;
        //        string stockZone;
        //        string notes;
        //        string originID;
        //        string unitPrice;
        //        string outPutProductionID;

        //        date = Production_DateTextBox.Text;
        //        time = Production_TimeTextBox.Text;
        //        dateTime = date + " " + time;
        //        itemName = Item_Name_TextBox.Text;
        //        quantity = Purchase_Quantity_TextBox.Text;
        //        weightBridgeCode = Weight_Brige_Code_TextBox.Text;
        //        stockZone = StockZoneIDDropDownList.SelectedValue;
        //        notes = Production_Note_TextBox.Text;
        //        productID = ProductIdDropDownList.SelectedValue;
        //        employeeID = EmployeeIDDropDownList.SelectedValue;
        //        consultantID = ConsultantDropDownList.SelectedValue;
        //        originID = "1";    // ID one is Bulgaria All Production Made In Bulgaria
        //        unitPrice = "0";   // In this version Production outPut İtem Unit Price is not Calculatet.
        //        itemID = row.Cells[3].Text;
        //        outPutProductionID = row.Cells[1].Text;
        //        // First Edit the item 

        //        SqlCommand editItem = new SqlCommand($"update [tbl_item] set item_Name='{itemName}' ,[item_Quantitiy]=@quantity,[item_CreateDate]='{date}',[stockZone_Id]='{stockZone}',[prod_Id]='{productID}',[origin_Id]='{originID}',[item_Note]='{notes}',[item_Consultant_Id]='{consultantID}' where [item_Id]= '{itemID}' ", conn.Connection());

        //        editItem.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

        //        editItem.ExecuteNonQuery();

        //        // Second Edit OutPut Production 

        //        SqlCommand editOutPutProduction = new SqlCommand($"update [tbl_productionOutput] set [purdO_Quantity]=@quantity,[purdO_OutPut_DateTime]='{dateTime}',[purdO_Weigh_Bridge_Code]='{weightBridgeCode}' , [purdO_Supervisor_Employee_Id]='{employeeID}'  ,[purdO_stock_Zone_Id]='{stockZone}',[purdO_Notes]='{notes}',[purdO_Consultant_Id]='{consultantID}' where [prodO_Id]= '{outPutProductionID}' ", conn.Connection());

        //        editOutPutProduction.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

        //        editOutPutProduction.ExecuteNonQuery();




        //        Response.Redirect("editGProduction-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Production OutPut for Edit');</script>");
        //    }


        //}




        protected void EditButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryOutPutProductionGridView.SelectedRow;

            if (row != null)
            {
                string date;
                string time;
                string dateTime;
                string itemName;
                string itemID;
                string productID = " ";
                string quantity;
                string weightBridgeCode;
                string employeeID;
                string consultantID;
                string stockZone;
                string notes;
                string originID;
                string unitPrice;
                string outPutProductionID;

                date = Production_DateTextBox.Text;
                time = Production_TimeTextBox.Text;
                dateTime = date + " " + time;
                itemName = Item_Name_TextBox.Text;
                quantity = Purchase_Quantity_TextBox.Text;
                weightBridgeCode = Weight_Brige_Code_TextBox.Text;
                stockZone = StockZoneIDDropDownList.SelectedValue;
                notes = Production_Note_TextBox.Text;
                productID = ProductIdDropDownList.SelectedValue;
                employeeID = EmployeeIDDropDownList.SelectedValue;
                consultantID = ConsultantDropDownList.SelectedValue;
                originID = "1";
                unitPrice = "0";
                itemID = row.Cells[3].Text;
                outPutProductionID = row.Cells[1].Text;

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
                {
                    connection.Open();

                    SqlCommand editItem = new SqlCommand($"update [tbl_item] set item_Name=@itemName ,[item_Quantitiy]=@quantity,[item_CreateDate]=@date,[stockZone_Id]=@stockZone,[prod_Id]=@productID,[origin_Id]=@originID,[item_Note]=@notes,[item_Consultant_Id]=@consultantID where [item_Id]= @itemID ", connection);
                    editItem.Parameters.AddWithValue("@itemName", itemName);
                    editItem.Parameters.AddWithValue("@quantity", Convert.ToDecimal(quantity, CultureInfo.CurrentCulture));
                    editItem.Parameters.AddWithValue("@date", date);
                    editItem.Parameters.AddWithValue("@stockZone", stockZone);
                    editItem.Parameters.AddWithValue("@productID", productID);
                    editItem.Parameters.AddWithValue("@originID", originID);
                    editItem.Parameters.AddWithValue("@notes", notes);
                    editItem.Parameters.AddWithValue("@consultantID", consultantID);
                    editItem.Parameters.AddWithValue("@itemID", itemID);
                    editItem.ExecuteNonQuery();

                    SqlCommand editOutPutProduction = new SqlCommand($"update [tbl_productionOutput] set [purdO_Quantity]=@quantity,[purdO_OutPut_DateTime]=@dateTime,[purdO_Weigh_Bridge_Code]=@weightBridgeCode ,[purdO_Supervisor_Employee_Id]=@employeeID  ,[purdO_stock_Zone_Id]=@stockZone,[purdO_Notes]=@notes,[purdO_Consultant_Id]=@consultantID where [prodO_Id]= @outPutProductionID ", connection);
                    editOutPutProduction.Parameters.AddWithValue("@quantity", Convert.ToDecimal(quantity, CultureInfo.CurrentCulture));
                    editOutPutProduction.Parameters.AddWithValue("@dateTime", dateTime);
                    editOutPutProduction.Parameters.AddWithValue("@weightBridgeCode", weightBridgeCode);
                    editOutPutProduction.Parameters.AddWithValue("@employeeID", employeeID);
                    editOutPutProduction.Parameters.AddWithValue("@stockZone", stockZone);
                    editOutPutProduction.Parameters.AddWithValue("@notes", notes);
                    editOutPutProduction.Parameters.AddWithValue("@consultantID", consultantID);
                    editOutPutProduction.Parameters.AddWithValue("@outPutProductionID", outPutProductionID);
                    editOutPutProduction.ExecuteNonQuery();
                }

                Response.Redirect("editGProduction-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Production OutPut for Edit');</script>");
            }
        }


        protected void ShowReportButton_Click(object sender, EventArgs e)
        {
            OutPutProductionGridViewBind();
        }
    }
}