using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Globalization;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;


namespace polymer_Web_ERP_V4
{
    public partial class addShipment_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DateTime dateMax = DateTime.Now;
            DateTime dateMin = dateMax.AddDays(-90);

            if (!this.IsPostBack)
            {


                Production_DateTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                ItemDateMin_TextBox.Text = dateMin.ToString("yyyy-MM-dd");
                ItemDateMax_TextBox.Text = dateMax.ToString("yyyy-MM-dd");

                DropDownProductGroupBind();
                ProductGroupIdDropDownList.SelectedIndex = 1;
                DropDownProductBind();
                DropDownCustomerGroupBind();
                DropDownCustomerBind();

                DropDownEmployeeBind();

                // jQueryShipGridViewBind();

                btnUpdate.Click += btnUpdate_Click;

            }
        }


        //private void DropDownProductGroupBind()
        //{
        //    string com = $"Select * from [tbl_productGroup]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ProductGroupIdDropDownList.DataSource = dt2;
        //    ProductGroupIdDropDownList.DataBind();
        //    ProductGroupIdDropDownList.DataTextField = "prod_Grp_Name";
        //    ProductGroupIdDropDownList.DataValueField = "prod_Grp_Id";
        //    ProductGroupIdDropDownList.DataBind();
        //}



        private void DropDownProductGroupBind()
        {
            string com = $"Select * from [tbl_productGroup]";
            using (SqlConnection connection = conn.Connection())
            {
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
        }


        protected void ProductGroupIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
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
        //}



        //private void DropDownCustomerGroupBind()
        //{
        //    string com = "Select * from [tbl_customerGroup]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    CustomerGroupIdDropDownList.DataSource = dt2;
        //    CustomerGroupIdDropDownList.DataBind();
        //    CustomerGroupIdDropDownList.DataTextField = "cust_Grp_Name";
        //    CustomerGroupIdDropDownList.DataValueField = "cust_Grp_Id";
        //    CustomerGroupIdDropDownList.DataBind();

        //}



        private void DropDownProductBind()
        {
            string com = $"Select * from [tbl_product] where [prod_Group_Id]='{ProductGroupIdDropDownList.SelectedValue}' ";
            using (SqlConnection connection = conn.Connection())
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    ProductIdDropDownList.DataSource = dt2;
                    ProductIdDropDownList.DataBind();
                    ProductIdDropDownList.DataTextField = "prod_Name";
                    ProductIdDropDownList.DataValueField = "prod_Id";
                    ProductIdDropDownList.DataBind();
                }
            }
        }


        private void DropDownCustomerGroupBind()
        {
            string com = "Select * from [tbl_customerGroup]";
            using (SqlConnection connection = conn.Connection())
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    CustomerGroupIdDropDownList.DataSource = dt2;
                    CustomerGroupIdDropDownList.DataBind();
                    CustomerGroupIdDropDownList.DataTextField = "cust_Grp_Name";
                    CustomerGroupIdDropDownList.DataValueField = "cust_Grp_Id";
                    CustomerGroupIdDropDownList.DataBind();
                }
            }
        }



        protected void CustomerGroupIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownCustomerBind();
        }


        //private void DropDownCustomerBind()
        //{
        //    string com = $"Select * from [tbl_customer] where [cust_Group_ID]='{CustomerGroupIdDropDownList.SelectedValue}'";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    CustomerIdDropDownList.DataSource = dt2;
        //    CustomerIdDropDownList.DataBind();
        //    CustomerIdDropDownList.DataTextField = "cust_Name";
        //    CustomerIdDropDownList.DataValueField = "cust_Id";
        //    CustomerIdDropDownList.DataBind();
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


        private void DropDownCustomerBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_customer] where [cust_Group_ID]='{CustomerGroupIdDropDownList.SelectedValue}'";
                SqlDataAdapter adpt = new SqlDataAdapter(com, connection);
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                CustomerIdDropDownList.DataSource = dt2;
                CustomerIdDropDownList.DataBind();
                CustomerIdDropDownList.DataTextField = "cust_Name";
                CustomerIdDropDownList.DataValueField = "cust_Id";
                CustomerIdDropDownList.DataBind();
            }
        }

        private void DropDownEmployeeBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_employee]";
                SqlDataAdapter adpt = new SqlDataAdapter(com, connection);
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                EmployeeIDDropDownList.DataSource = dt2;
                EmployeeIDDropDownList.DataBind();
                EmployeeIDDropDownList.DataTextField = "empl_Name_TR";
                EmployeeIDDropDownList.DataValueField = "empl_Id";
                EmployeeIDDropDownList.DataBind();
            }
        }








        private void jQueryShipGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listInStockItem '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}','{ProductIdDropDownList.SelectedValue}'", con))
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



        private void jQueryLastShipGridViewBind()
        {



            try   // If there is no shippment will throw IndexOutOfRangeException  for this we wrote a error handling 
            { 
            
            string lastShipID = $"SELECT [ship_Id] FROM [tbl_shipping]\r\n WHERE [ship_Id] = (\r\n SELECT MAX([ship_Id]) FROM [tbl_shipping])";
            SqlDataAdapter adpt = new SqlDataAdapter(lastShipID, conn.Connection());
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            string shipId = dt2.Rows[0][0].ToString();

            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_shippingDetail '{shipId}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryLastShipGridView.DataSource = dt;
                        jQueryLastShipGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryLastShipGridView.UseAccessibleHeader = true;
            jQueryLastShipGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            catch (IndexOutOfRangeException ex)
            {

            }

        }


        protected void jQueryLastShippGridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryLastShipGridViewBind();

            if (jQueryLastShipGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryLastShipGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryLastShipGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryLastShipGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }









        //  protected void RunButton_Click(object sender, EventArgs e)
        //  {

        //      bool isAtLeastOneCheckboxChecked = false;

        //      foreach (GridViewRow row in jQueryShipGridView.Rows)
        //      {
        //          // Check if the current row is selected
        //          CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
        //          if (cbSelect.Checked)
        //          {
        //              isAtLeastOneCheckboxChecked = true;

        //          }

        //          else
        //          {

        //          }
        //      }







        //      if (isAtLeastOneCheckboxChecked == true) 

        //      { 

        //      string shipId;
        //      string date;
        //      double quantityShip=0;
        //      string customerId;
        //      string employeeID;
        //      string weightBridgeCode;
        //      string notes;
        //      string quantitiyItem;
        //      string itemID;

        //      // First create the shipment 

        //      /*

        // [ship_Id]
        //,[ship_Date]
        //,[ship_Quantity]
        //,[custumer_Id]
        //,[ship_Supervisor_Employee_Id]
        //,[ship_Weigh_Bridge_Code]
        //,[ship_Notes]

        //   */

        //      date=Production_DateTextBox.Text;
        //      customerId = CustomerIdDropDownList.SelectedValue;
        //      employeeID = EmployeeIDDropDownList.SelectedValue;
        //      weightBridgeCode=Weight_Brige_Code_TextBox.Text;
        //      notes = Shipment_Note_TextBox.Text;


        //      SqlCommand addShipment = new SqlCommand($"insert into [tbl_shipping] (ship_Date,[ship_Quantity],[custumer_Id],[ship_Supervisor_Employee_Id],[ship_Weigh_Bridge_Code],[ship_Notes]) " +
        //          $"values ('{date}',@quantity,'{customerId}' ,'{employeeID}','{weightBridgeCode}','{notes}')", conn.Connection());
        //      addShipment.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantityShip, CultureInfo.CurrentCulture);

        //      addShipment.ExecuteNonQuery();


        //      //Then pull the last ship ID for edditing sales Items

        //      string lastShipID = $"SELECT [ship_Id] FROM [tbl_shipping]\r\n WHERE [ship_Id] = (\r\n SELECT MAX([ship_Id]) FROM [tbl_shipping])";
        //      SqlDataAdapter adpt = new SqlDataAdapter(lastShipID, conn.Connection());
        //      DataTable dt2 = new DataTable();
        //      adpt.Fill(dt2);
        //      shipId = dt2.Rows[0][0].ToString();   // Last ship ID 

        //      // Then by using This ID create all  sales for all Items  by foreachloop

        //          // Iterate through each row in the GridView
        //      foreach (GridViewRow row in jQueryShipGridView.Rows)
        //      {
        //          // Check if the current row is selected
        //          CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
        //          if (cbSelect.Checked)
        //          {
        //              // Get the data from the selected row

        //              itemID = string.Format(row.Cells[1].Text);
        //              quantitiyItem = string.Format(row.Cells[4].Text); 

        //              //Add item sell items

        //              SqlCommand addItemSell = new SqlCommand($"insert into [tbl_sales] ([shipping_Id],[item_Id])" +
        //              $"values ('{shipId}','{itemID}')", conn.Connection());

        //              addItemSell.ExecuteNonQuery();



        //              quantityShip += double.Parse(quantitiyItem);

        //          }
        //      }


        //      // Edditing shipment Quantity with  Sum all quantityShip 


        //      SqlCommand editship = new SqlCommand($"update [tbl_shipping] set [ship_Quantity]=@quantity where [ship_Id]= '{shipId}' ", conn.Connection());

        //      editship.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantityShip, CultureInfo.CurrentCulture);

        //      editship.ExecuteNonQuery();

        //      Response.Redirect("addShipment-ERP.aspx");


        //      }

        //      else
        //      {
        //          Response.Write("<script>alert('You need to choose at least one Item for Shipment')</script>");

        //      }



        //  }


        //protected void RunButton_Click(object sender, EventArgs e)
        //{
        //    bool isAtLeastOneCheckboxChecked = false;

        //    using (SqlConnection connection = conn.Connection())
        //    {
        //        foreach (GridViewRow row in jQueryShipGridView.Rows)
        //        {
        //            // Check if the current row is selected
        //            CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
        //            if (cbSelect.Checked)
        //            {
        //                isAtLeastOneCheckboxChecked = true;
        //                break; // Exit the loop early since at least one checkbox is checked
        //            }
        //        }

        //        if (isAtLeastOneCheckboxChecked)
        //        {
        //            string shipId;
        //            string date;
        //            decimal quantityShip = 0; // Initialize as decimal for better precision
        //            string customerId;
        //            string employeeID;
        //            string weightBridgeCode;
        //            string notes;
        //            string quantitiyItem;
        //            string itemID;

        //            date = Production_DateTextBox.Text;
        //            customerId = CustomerIdDropDownList.SelectedValue;
        //            employeeID = EmployeeIDDropDownList.SelectedValue;
        //            weightBridgeCode = Weight_Brige_Code_TextBox.Text;
        //            notes = Shipment_Note_TextBox.Text;

        //            // First create the shipment 
        //            SqlCommand addShipment = new SqlCommand($"insert into [tbl_shipping] (ship_Date,[ship_Quantity],[custumer_Id],[ship_Supervisor_Employee_Id],[ship_Weigh_Bridge_Code],[ship_Notes]) " +
        //                $"values ('{date}',@quantity,'{customerId}' ,'{employeeID}','{weightBridgeCode}','{notes}')", connection);
        //            addShipment.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantityShip, CultureInfo.CurrentCulture);
        //            addShipment.ExecuteNonQuery();

        //            //Then pull the last ship ID for editing sales Items
        //            string lastShipID = $"SELECT [ship_Id] FROM [tbl_shipping]\r\n WHERE [ship_Id] = (\r\n SELECT MAX([ship_Id]) FROM [tbl_shipping])";
        //            SqlDataAdapter adpt = new SqlDataAdapter(lastShipID, connection);
        //            DataTable dt2 = new DataTable();
        //            adpt.Fill(dt2);
        //            shipId = dt2.Rows[0][0].ToString(); // Last ship ID 

        //            // Then by using This ID create all  sales for all Items  by foreach loop
        //            foreach (GridViewRow row in jQueryShipGridView.Rows)
        //            {
        //                // Check if the current row is selected
        //                CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
        //                if (cbSelect.Checked)
        //                {
        //                    // Get the data from the selected row
        //                    itemID = string.Format(row.Cells[1].Text);
        //                    quantitiyItem = string.Format(row.Cells[4].Text);

        //                    // Add item sell items
        //                    SqlCommand addItemSell = new SqlCommand($"insert into [tbl_sales] ([shipping_Id],[item_Id])" +
        //                        $"values ('{shipId}','{itemID}')", connection);
        //                    addItemSell.ExecuteNonQuery();

        //                    quantityShip += decimal.Parse(quantitiyItem);
        //                }
        //            }

        //            // Editing shipment Quantity with  Sum all quantityShip 
        //            SqlCommand editship = new SqlCommand($"update [tbl_shipping] set [ship_Quantity]=@quantity where [ship_Id]= '{shipId}' ", connection);
        //            editship.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantityShip, CultureInfo.CurrentCulture);
        //            editship.ExecuteNonQuery();

        //            Response.Redirect("addShipment-ERP.aspx");
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('You need to choose at least one Item for Shipment')</script>");
        //        }
        //    }
        //}

        protected void RunButton_Click(object sender, EventArgs e)
        {
            bool isAtLeastOneCheckboxChecked = false;

            using (SqlConnection connection = conn.Connection())
            {
                foreach (GridViewRow row in jQueryShipGridView.Rows)
                {
                    // Check if the current row is selected
                    CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
                    if (cbSelect.Checked)
                    {
                        isAtLeastOneCheckboxChecked = true;
                        break; // Exit the loop early since at least one checkbox is checked
                    }
                }

                if (isAtLeastOneCheckboxChecked)
                {
                    string shipId;
                    string date;
                    decimal quantityShip = 0; // Initialize as decimal for better precision
                    string customerId;
                    string employeeID;
                    string weightBridgeCode;
                    string notes;
                    string quantitiyItem;
                    string itemID;

                    date = Production_DateTextBox.Text;
                    customerId = CustomerIdDropDownList.SelectedValue;
                    employeeID = EmployeeIDDropDownList.SelectedValue;
                    weightBridgeCode = Weight_Brige_Code_TextBox.Text;
                    notes = Shipment_Note_TextBox.Text;

                    // First create the shipment 
                    using (SqlCommand addShipment = new SqlCommand($"insert into [tbl_shipping] (ship_Date,[ship_Quantity],[custumer_Id],[ship_Supervisor_Employee_Id],[ship_Weigh_Bridge_Code],[ship_Notes]) " +
                        $"values ('{date}',@quantity,'{customerId}' ,'{employeeID}','{weightBridgeCode}','{notes}')", connection))
                    {
                        addShipment.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantityShip, CultureInfo.CurrentCulture);
                        addShipment.ExecuteNonQuery();
                    }

                    //Then pull the last ship ID for editing sales Items
                    string lastShipID = $"SELECT [ship_Id] FROM [tbl_shipping]\r\n WHERE [ship_Id] = (\r\n SELECT MAX([ship_Id]) FROM [tbl_shipping])";
                    using (SqlDataAdapter adpt = new SqlDataAdapter(lastShipID, connection))
                    {
                        DataTable dt2 = new DataTable();
                        adpt.Fill(dt2);
                        shipId = dt2.Rows[0][0].ToString(); // Last ship ID 
                    }

                    // Then by using This ID create all  sales for all Items  by foreach loop
                    foreach (GridViewRow row in jQueryShipGridView.Rows)
                    {
                        // Check if the current row is selected
                        CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
                        if (cbSelect.Checked)
                        {
                            // Get the data from the selected row
                            itemID = string.Format(row.Cells[1].Text);
                            quantitiyItem = string.Format(row.Cells[4].Text);

                            // Add item sell items
                            using (SqlCommand addItemSell = new SqlCommand($"insert into [tbl_sales] ([shipping_Id],[item_Id])" +
                                $"values ('{shipId}','{itemID}')", connection))
                            {
                                addItemSell.ExecuteNonQuery();
                            }

                            quantityShip += decimal.Parse(quantitiyItem);
                        }
                    }

                    // Editing shipment Quantity with  Sum all quantityShip 
                    using (SqlCommand editship = new SqlCommand($"update [tbl_shipping] set [ship_Quantity]=@quantity where [ship_Id]= '{shipId}' ", connection))
                    {
                        editship.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantityShip, CultureInfo.CurrentCulture);
                        editship.ExecuteNonQuery();
                    }

                    Response.Redirect("addShipment-ERP.aspx");
                }
                else
                {
                    Response.Write("<script>alert('You need to choose at least one Item for Shipment')</script>");
                }
            }
        }



        //protected void AddToLastShip_Click(object sender, EventArgs e)
        //{
        //    string shipId;
        //    string quantitiyItem;
        //    string itemID;
        //    string quantitiyLast;
        //    double quantityShip;



        //    //Then pull the last ship ID for edditing sales Items
        //    string lastShipID = $"SELECT [ship_Id] FROM [tbl_shipping]\r\n WHERE [ship_Id] = (\r\n SELECT MAX([ship_Id]) FROM [tbl_shipping])";
        //    SqlDataAdapter adpt = new SqlDataAdapter(lastShipID, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    shipId = dt2.Rows[0][0].ToString();   // Last ship ID 

        //    //Then pull the last Shipments Quantitiy 

        //    string quantitiyLastShip = $"Select [ship_Quantity] from [tbl_shipping] where [ship_Id]='{shipId}'";
        //    SqlDataAdapter adpt2=new SqlDataAdapter(quantitiyLastShip,conn.Connection());
        //    DataTable dt3=new DataTable();
        //    adpt2.Fill(dt3);
        //    quantitiyLast=dt3.Rows[0][0].ToString();

        //    quantityShip = double.Parse(quantitiyLast);

        //    // Then by using This ID create all  sales for all Items  by foreachloop

        //    // Iterate through each row in the GridView
        //    foreach (GridViewRow row in jQueryShipGridView.Rows)
        //    {
        //        // Check if the current row is selected
        //        CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
        //        if (cbSelect.Checked)
        //        {
        //            // Get the data from the selected row

        //            itemID = string.Format(row.Cells[1].Text);
        //            quantitiyItem = string.Format(row.Cells[3].Text);

        //            //Add item sell items

        //            SqlCommand addItemSell = new SqlCommand($"insert into [tbl_sales] ([shipping_Id],[item_Id])" +
        //            $"values ('{shipId}','{itemID}')", conn.Connection());

        //            addItemSell.ExecuteNonQuery();



        //            quantityShip += double.Parse(quantitiyItem);

        //        }
        //    }


        //    // Edditing shipment Quantity with  Sum all quantityShip 


        //    SqlCommand editship = new SqlCommand($"update [tbl_shipping] set [ship_Quantity]=@quantity where [ship_Id]= '{shipId}' ", conn.Connection());

        //    editship.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantityShip, CultureInfo.CurrentCulture);

        //    editship.ExecuteNonQuery();

        //}



        protected void AddToLastShip_Click(object sender, EventArgs e)
        {
            string shipId;
            string quantitiyItem;
            string itemID;
            string quantitiyLast;
            double quantityShip;

            // Pull the last ship ID for editing sales items
            using (SqlConnection connection = conn.Connection())
            {
                string lastShipID = $"SELECT [ship_Id] FROM [tbl_shipping] WHERE [ship_Id] = (SELECT MAX([ship_Id]) FROM [tbl_shipping])";
                SqlDataAdapter adpt = new SqlDataAdapter(lastShipID, connection);
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                shipId = dt2.Rows[0][0].ToString();   // Last ship ID 

                // Pull the last Shipments Quantity 
                string quantitiyLastShip = $"Select [ship_Quantity] from [tbl_shipping] where [ship_Id]='{shipId}'";
                SqlDataAdapter adpt2 = new SqlDataAdapter(quantitiyLastShip, connection);
                DataTable dt3 = new DataTable();
                adpt2.Fill(dt3);
                quantitiyLast = dt3.Rows[0][0].ToString();

                quantityShip = double.Parse(quantitiyLast);

                // Create sales for all items using the last ship ID
                foreach (GridViewRow row in jQueryShipGridView.Rows)
                {
                    // Check if the current row is selected
                    CheckBox cbSelect = (CheckBox)row.FindControl("cbSelect");
                    if (cbSelect.Checked)
                    {
                        // Get the data from the selected row
                        itemID = string.Format(row.Cells[1].Text);
                        quantitiyItem = string.Format(row.Cells[4].Text);    // Adjust the column index according to your GridView's structure 3 to 4 Because I Add the Item ID to the GridView as update

                        // Add item sell items
                        using (SqlCommand addItemSell = new SqlCommand($"insert into [tbl_sales] ([shipping_Id],[item_Id])" +
                            $"values ('{shipId}','{itemID}')", connection))
                        {
                            addItemSell.ExecuteNonQuery();
                        }

                        quantityShip += double.Parse(quantitiyItem);
                    }
                }

                // Edit shipment Quantity with sum of all quantityShip 
                using (SqlCommand editship = new SqlCommand($"update [tbl_shipping] set [ship_Quantity]=@quantity where [ship_Id]= '{shipId}' ", connection))
                {
                    editship.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantityShip, CultureInfo.CurrentCulture);
                    editship.ExecuteNonQuery();
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {/*
            Label1.Text = TextBox1.Text;
            TextBox1.Text = string.Empty;
            
            double sum = 0;

            foreach (GridViewRow row in jQueryShipGridView.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("cbSelect");

                if (checkBox != null && checkBox.Checked)
                {
                    // Assuming the sum is stored in a column named "Amount"
                    double amount = double.Parse(row.Cells[3].Text); // Adjust the column index according to your GridView's structure
                    sum += amount;
                }
            }

            // Display the sum in a label or any other control
            TextBox1.Text = sum.ToString();

           */ 
        }


        
      
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*
            
            double sum = 0;

            foreach (GridViewRow row in jQueryShipGridView.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("cbSelect");

                if (checkBox != null && checkBox.Checked)
                {
                    // Assuming the sum is stored in a column named "Amount"
                    double amount = double.Parse(row.Cells[3].Text); // Adjust the column index according to your GridView's structure
                    sum += amount;
                }
            }

            // Display the sum in a label or any other control
            lblResult2.Text = sum.ToString();
            
            */

            

        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            double sum = 0;

            foreach (GridViewRow row in jQueryShipGridView.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("cbSelect");

                if (checkBox != null && checkBox.Checked)
                {
                    // Assuming the sum is stored in a column named "Amount"
                    double amount = double.Parse(row.Cells[4].Text); // Adjust the column index according to your GridView's structure
                    sum += amount;
                }
            }

            // Display the sum in a label or any other control
            lblResult.Text = sum.ToString();



            
        }
         
        protected void ShowItemsButton_Click(object sender, EventArgs e)
        {
            jQueryShipGridViewBind();
        }




    }
}