using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Globalization;
using System.Configuration;

namespace polymer_Web_ERP_V4
{
    public partial class addGProduction : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!this.IsPostBack) 
        //    { 
        //        Production_DateTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        //        Production_TimeTextBox.Text = DateTime.Now.ToString("HH:mm");

        //        DropDownPrdGroupBind();
        //        ProductGroupIdDropDownList.SelectedValue = "2";
        //        DropDownProductBind();
        //        DropDownStockZoneBind();
        //        DropDownEmployeeBind();
        //        DropDownConsultantBind();

        //        DailyGranuleGridViewBind();

        //    }

        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Production_DateTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Production_TimeTextBox.Text = DateTime.Now.ToString("HH:mm");

                using (SqlConnection connection = conn.Connection())
                {
                    DropDownPrdGroupBind(connection);
                    ProductGroupIdDropDownList.SelectedValue = "2";
                    DropDownProductBind(connection);
                    DropDownStockZoneBind(connection);
                    DropDownEmployeeBind(connection);
                    DropDownConsultantBind(connection);
                    DailyGranuleGridViewBind();
                }
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


        private void DropDownPrdGroupBind(SqlConnection connection)
        {
            string com = "Select * from tbl_productGroup";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                ProductGroupIdDropDownList.DataSource = dt2;
                ProductGroupIdDropDownList.DataBind();
                ProductGroupIdDropDownList.DataTextField = "prod_Grp_Name";
                ProductGroupIdDropDownList.DataValueField = "prod_Grp_Id";
                ProductGroupIdDropDownList.DataBind();
            }
        }



        protected void ProductGroupIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = conn.Connection())
            {
                DropDownProductBind(connection);
            }

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


        private void DropDownProductBind(SqlConnection connection)
        {
            string com = $"Select * from [tbl_product] where [prod_Group_Id]='{ProductGroupIdDropDownList.SelectedValue}' ";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                ProductIdDropDownList.DataSource = dt2;
                ProductIdDropDownList.DataBind();
                ProductIdDropDownList.DataTextField = "prod_Name";
                ProductIdDropDownList.DataValueField = "prod_Id";
                ProductIdDropDownList.DataBind();

                Purchase_Unit_TextBox.Text = "KG";
            }
        }

        private void DropDownStockZoneBind(SqlConnection connection)
        {
            string com = $"Select * from [tbl_stockZone]";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                StockZoneIDDropDownList.DataSource = dt2;
                StockZoneIDDropDownList.DataBind();
                StockZoneIDDropDownList.DataTextField = "stk_Zn_Name";
                StockZoneIDDropDownList.DataValueField = "stk_Zn_Id";
                StockZoneIDDropDownList.DataBind();
            }
        }

        private void DropDownEmployeeBind(SqlConnection connection)
        {
            string com = $"Select * from [tbl_employee]";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                EmployeeIDDropDownList.DataSource = dt2;
                EmployeeIDDropDownList.DataBind();
                EmployeeIDDropDownList.DataTextField = "empl_Name_TR";
                EmployeeIDDropDownList.DataValueField = "empl_Id";
                EmployeeIDDropDownList.DataBind();
            }
        }

        private void DropDownConsultantBind(SqlConnection connection)
        {
            string com = $"Select * from [tbl_consultant]";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                ConsultantDropDownList.DataSource = dt2;
                ConsultantDropDownList.DataBind();
                ConsultantDropDownList.DataTextField = "cnslt_Name";
                ConsultantDropDownList.DataValueField = "cnslt_Id";
                ConsultantDropDownList.DataBind();
            }
        }


        private void DailyGranuleGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listOutPutGranuleProductionDaily", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryProductOutPutGridView.DataSource = dt;
                        jQueryProductOutPutGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryProductOutPutGridView.UseAccessibleHeader = true;
            jQueryProductOutPutGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void jQueryDailyGranuleGridViewBind_PreRender(object sender, EventArgs e)
        {
            this.DailyGranuleGridViewBind();

            if (jQueryProductOutPutGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryProductOutPutGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryProductOutPutGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryProductOutPutGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }








        //protected void RunButton_Click(object sender, EventArgs e)
        //{
        //    string date;
        //    string time;
        //    string dateTime;
        //    string itemName;
        //    string itemID;
        //    string productID = " ";
        //    string quantity;
        //    string weightBridgeCode;
        //    string employeeID;
        //    string consultantID;
        //    string stockZone;
        //    string notes;
        //    string originID;
        //    string unitPrice;

        //    date = Production_DateTextBox.Text; 
        //    time = Production_TimeTextBox.Text;
        //    dateTime = date + " " + time;
        //    itemName = Item_Name_TextBox.Text;
        //    quantity = Purchase_Quantity_TextBox.Text;
        //    weightBridgeCode = Weight_Brige_Code_TextBox.Text;            
        //    stockZone=StockZoneIDDropDownList.SelectedValue;
        //    notes = Production_Note_TextBox.Text;
        //    productID = ProductIdDropDownList.SelectedValue;
        //    employeeID = EmployeeIDDropDownList.SelectedValue;
        //    consultantID = ConsultantDropDownList.SelectedValue;
        //    originID = "1";    // ID one is Bulgaria All Production Made In Bulgaria
        //    unitPrice = "0";   // In this version Production outPut İtem Unit Price is not Calculatet.

        //    // First create the item 

        //    SqlCommand addItem = new SqlCommand($"insert into [tbl_item] (item_Name,[item_Quantitiy],[item_UnitPrice],[item_CreateDate],[item_UpdateDate],[stockZone_Id],[prod_Id],[origin_Id],[item_Note],[item_Consultant_Id]) " +
        //        $"values ('{itemName}',@quantity, @price,'{dateTime}' ,'{dateTime}','{stockZone}','{productID}','{originID}','{notes}','{consultantID}')", conn.Connection());

        //    addItem.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(unitPrice, CultureInfo.CurrentCulture);
        //    addItem.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

        //    addItem.ExecuteNonQuery();

        //    // Pulling the last ID for editing Purchase 

        //    string lastItemID = $"SELECT [item_Id] FROM [tbl_item]\r\nWHERE [item_Id] = (\r\n    SELECT MAX([item_Id]) FROM [tbl_item])";
        //    SqlDataAdapter adpt = new SqlDataAdapter(lastItemID, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    itemID = dt2.Rows[0][0].ToString();


        //    // Then by using this item ID Create the Production Out Put row  

        //    SqlCommand addOutPutProduction = new SqlCommand($"insert into [tbl_productionOutput] ([purdO_OutPut_DateTime],[item_Id],[purdO_Quantity],[purdO_Weigh_Bridge_Code],[purdO_Supervisor_Employee_Id],[purdO_stock_Zone_Id],[purdO_Notes],[purdO_Consultant_Id]) " +
        //       $"values ('{dateTime}' ,'{itemID}',@quantity,'{weightBridgeCode}','{employeeID}','{stockZone}','{notes}','{consultantID}')", conn.Connection());

        //    addOutPutProduction.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

        //    addOutPutProduction.ExecuteNonQuery();



        //    Response.Redirect("addGProduction-ERP.aspx");


        //}


        protected void RunButton_Click(object sender, EventArgs e)
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
            originID = "1";    // ID one is Bulgaria All Production Made In Bulgaria
            unitPrice = "0";   // In this version Production outPut İtem Unit Price is not Calculatet.

            using (SqlCommand addItem = new SqlCommand($"insert into [tbl_item] (item_Name,[item_Quantitiy],[item_UnitPrice],[item_CreateDate],[item_UpdateDate],[stockZone_Id],[prod_Id],[origin_Id],[item_Note],[item_Consultant_Id]) " +
                    $"values ('{itemName}',@quantity, @price,'{dateTime}' ,'{dateTime}','{stockZone}','{productID}','{originID}','{notes}','{consultantID}')", conn.Connection()))
            {
                addItem.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(unitPrice, CultureInfo.CurrentCulture);
                addItem.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

                addItem.ExecuteNonQuery();
            }

            // Pulling the last ID for editing Purchase 

            string lastItemID = $"SELECT [item_Id] FROM [tbl_item]\r\nWHERE [item_Id] = (\r\n    SELECT MAX([item_Id]) FROM [tbl_item])";
            using (SqlDataAdapter adpt = new SqlDataAdapter(lastItemID, conn.Connection()))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                itemID = dt2.Rows[0][0].ToString();
            }

            // Then by using this item ID Create the Production Out Put row  

            using (SqlCommand addOutPutProduction = new SqlCommand($"insert into [tbl_productionOutput] ([purdO_OutPut_DateTime],[item_Id],[purdO_Quantity],[purdO_Weigh_Bridge_Code],[purdO_Supervisor_Employee_Id],[purdO_stock_Zone_Id],[purdO_Notes],[purdO_Consultant_Id]) " +
                   $"values ('{dateTime}' ,'{itemID}',@quantity,'{weightBridgeCode}','{employeeID}','{stockZone}','{notes}','{consultantID}')", conn.Connection()))
            {
                addOutPutProduction.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

                addOutPutProduction.ExecuteNonQuery();
            }

            Response.Redirect("addGProduction-ERP.aspx");
        }



    }
}