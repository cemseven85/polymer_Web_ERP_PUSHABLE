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

namespace polymer_Web_ERP_V4
{
    public partial class addWProduction_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        public float IntStock { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {


                Production_DateTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Production_TimeTextBox.Text = DateTime.Now.ToString("HH:mm");
                DropDownProductBind();
                UnitTextBoxBind();
                DropDownSellerBind();
                DropDownEmployeeBind();


                //Test for Error V4_1


                Product_Panel_4.Visible = false;
                Product_Panel_4a.Visible = false;

            }



        }

        //private void DropDownProductBind()
        //{
        //    string com = $"Select * from [tbl_product] where [prod_Group_Id]='1' or [prod_Group_Id]='6' ";     // Test    or [prod_Group_Id]='6'
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ProductIdDropDownList.DataSource = dt2;
        //    ProductIdDropDownList.DataBind();
        //    ProductIdDropDownList.DataTextField = "prod_Name";
        //    ProductIdDropDownList.DataValueField = "prod_Id";
        //    ProductIdDropDownList.DataBind();
        //}


        private void DropDownProductBind()
        {
            string com = $"Select * from [tbl_product] where [prod_Group_Id]='1' or [prod_Group_Id]='6'"; // Test or [prod_Group_Id]='6'
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
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


        protected void ProductIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pulling the Unit of product to Text Box.  

            UnitTextBoxBind();
            DropDownSellerBind();

            Product_Panel_4.Visible = false;
            Product_Panel_4a.Visible = false;

        }

        protected void SellerIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product_Panel_4.Visible = false;
            Product_Panel_4a.Visible = false;
        }


        //private void UnitTextBoxBind()
        //{
        //    //Pulling the Unit of product to Text Box.  
        //    string com = $"select tbl_unit.unt_Name\r\nfrom tbl_unit \r\njoin tbl_product\r\non tbl_product.prod_Unit_Id=tbl_unit.unt_Id\r\nwhere tbl_product.prod_Id='{ProductIdDropDownList.SelectedValue}';";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);

        //    Purchase_Unit_TextBox.Text = dt2.Rows[0][0].ToString();
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






        //private void DropDownSellerBind()
        //{
        //    string com = $"execute  prc_sellerDropDownListProdInPut '{ProductIdDropDownList.SelectedValue}' ";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    SellerIdDropDownList.DataSource = dt2;
        //    SellerIdDropDownList.DataBind();
        //    SellerIdDropDownList.DataTextField = "sell_Name";
        //    SellerIdDropDownList.DataValueField = "sell_Id";
        //    SellerIdDropDownList.DataBind();
        //}



        private void UnitTextBoxBind()
        {
            //Pulling the Unit of product to Text Box.  
            string com = $"select tbl_unit.unt_Name from tbl_unit join tbl_product on tbl_product.prod_Unit_Id=tbl_unit.unt_Id where tbl_product.prod_Id='{ProductIdDropDownList.SelectedValue}'";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                Purchase_Unit_TextBox.Text = dt2.Rows[0][0].ToString();
            }
        }

        private void DropDownEmployeeBind()
        {
            string com = $"Select * from [tbl_employee]";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
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

        private void DropDownSellerBind()
        {
            string com = $"execute prc_sellerDropDownListProdInPut '{ProductIdDropDownList.SelectedValue}'";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                SellerIdDropDownList.DataSource = dt2;
                SellerIdDropDownList.DataBind();
                SellerIdDropDownList.DataTextField = "sell_Name";
                SellerIdDropDownList.DataValueField = "sell_Id";
                SellerIdDropDownList.DataBind();
            }
        }



        private void AllScrapGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listInPutScrap '{ProductIdDropDownList.SelectedValue}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryScrapGridView.DataSource = dt;
                        jQueryScrapGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryScrapGridView.UseAccessibleHeader = true;
            jQueryScrapGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryScrapGridView_PreRender(object sender, EventArgs e)
        {
            this.AllScrapGridViewBind();

            if (jQueryScrapGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryScrapGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryScrapGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryScrapGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }





        private void SellerScrapGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listInPutScrap '{ProductIdDropDownList.SelectedValue}','{SellerIdDropDownList.SelectedValue}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQuerySellerScrapGridView.DataSource = dt;
                        jQuerySellerScrapGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQuerySellerScrapGridView.UseAccessibleHeader = true;
            jQuerySellerScrapGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void jQuerySellerScrapGridView_PreRender(object sender, EventArgs e)
        {
            this.SellerScrapGridViewBind();

            if (jQuerySellerScrapGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQuerySellerScrapGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQuerySellerScrapGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQuerySellerScrapGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }




        protected void AllButton_Click(object sender, EventArgs e)
        {
            AllScrapGridViewBind();
            Product_Panel_4.Visible = true;
            Product_Panel_4a.Visible = false;
        }

        protected void BySellerButton_Click(object sender, EventArgs e)
        {
            SellerScrapGridViewBind();
            Product_Panel_4a.Visible = true;
            Product_Panel_4.Visible = false;
        }

        //protected void RunButton_Click(object sender, EventArgs e)
        //{
        //    string date;
        //    string time;
        //    string dateTime;
        //    string itemID = "";
        //    string quantity;
        //    string weightBridgeCode;
        //    string employeeID;
        //    string numBales;
        //    string notes;
        //    string stock = "";

        //    bool isScrapSelected = false;   // For control is selected.

        //    date = Production_DateTextBox.Text;
        //    time = Production_TimeTextBox.Text;
        //    dateTime = date + " " + time;

        //    if (Product_Panel_4.Visible == true)
        //    {
        //        GridViewRow row = jQueryScrapGridView.SelectedRow;

        //        if (row != null)
        //        {
        //            itemID = row.Cells[8].Text;
        //            stock = row.Cells[7].Text;
        //            isScrapSelected = true;
        //        }
        //        else
        //        {

        //        }

        //    }
        //    else if (Product_Panel_4a.Visible == true)
        //    {
        //        GridViewRow row = jQuerySellerScrapGridView.SelectedRow;

        //        if (row != null)
        //        {
        //            itemID = row.Cells[8].Text;
        //            stock = row.Cells[7].Text;
        //            isScrapSelected = true;
        //        }
        //        else
        //        {

        //        }


        //    }

        //    if (isScrapSelected == true)
        //    {



        //        quantity = Purchase_Quantity_TextBox.Text;
        //        weightBridgeCode = Weight_Brige_Code_TextBox.Text;
        //        employeeID = EmployeeIDDropDownList.SelectedValue;
        //        numBales = Num_Bales_TextBox.Text;
        //        notes = Production_Note_TextBox.Text;



        //        float intQuantity = float.Parse(quantity);

        //        // I will try to make this by Property  /* */ are Alternatif Trying   
        //        /*
        //        float intStock = float.Parse(stock);
        //        */

        //        IntStock = float.Parse(stock);   // I use property for Variable Auto Genereted Property



        //        //   if (intQuantity <= intStock)

        //        if (intQuantity <= IntStock)
        //        {
        //            SqlCommand addproductionInPut = new SqlCommand($"insert into [tbl_productionInput] ([prodI_DateTime],[item_Id],[prodI_Quantity],[prodI_Weigh_Bridge_Code],[prodI_Supervisor_Employee_Id],[prodI_NumBales],[prodI_Notes]) " +
        //            $"values ('{dateTime}',{itemID},@quantity,'{weightBridgeCode}' ,'{employeeID}','{numBales}','{notes}')", conn.Connection());

        //            addproductionInPut.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

        //            addproductionInPut.ExecuteNonQuery();
        //        }
        //        else
        //        {
        //            Response.Write($"<script type=\"text/javascript\">alert('You can not produce more than Stock {stock} ');</script>");
        //        }

        //    }
        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Scrap for Production InPut');</script>");
        //    }

        //    //Response.Redirect("addWProduction-ERP.aspx");

        //    Purchase_Quantity_TextBox.Text = String.Empty;
        //    Num_Bales_TextBox.Text = String.Empty;
        //    jQueryScrapGridView.SelectedIndex = -1;

        //}


        protected void RunButton_Click(object sender, EventArgs e)
        {
            string date;
            string time;
            string dateTime;
            string itemID = "";
            string quantity;
            string weightBridgeCode;
            string employeeID;
            string numBales;
            string notes;
            string stock = "";

            bool isScrapSelected = false;   // For control is selected.

            date = Production_DateTextBox.Text;
            time = Production_TimeTextBox.Text;
            dateTime = date + " " + time;

            if (Product_Panel_4.Visible == true)
            {
                GridViewRow row = jQueryScrapGridView.SelectedRow;

                if (row != null)
                {
                    itemID = row.Cells[8].Text;
                    stock = row.Cells[7].Text;
                    isScrapSelected = true;
                }
                else
                {

                }

            }
            else if (Product_Panel_4a.Visible == true)
            {
                GridViewRow row = jQuerySellerScrapGridView.SelectedRow;

                if (row != null)
                {
                    itemID = row.Cells[8].Text;
                    stock = row.Cells[7].Text;
                    isScrapSelected = true;
                }
                else
                {

                }


            }

            if (isScrapSelected == true)
            {



                quantity = Purchase_Quantity_TextBox.Text;
                weightBridgeCode = Weight_Brige_Code_TextBox.Text;
                employeeID = EmployeeIDDropDownList.SelectedValue;
                numBales = Num_Bales_TextBox.Text;
                notes = Production_Note_TextBox.Text;



                float intQuantity = float.Parse(quantity);

                // I will try to make this by Property  /* */ are Alternatif Trying   
                /*
                float intStock = float.Parse(stock);
                */

                IntStock = float.Parse(stock);   // I use property for Variable Auto Genereted Property





                string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(constr))
                {


                    connection.Open();

                    //   if (intQuantity <= intStock)
                    if (intQuantity <= IntStock)
                    {
                        using (SqlCommand addproductionInPut = new SqlCommand($"insert into [tbl_productionInput] ([prodI_DateTime],[item_Id],[prodI_Quantity],[prodI_Weigh_Bridge_Code],[prodI_Supervisor_Employee_Id],[prodI_NumBales],[prodI_Notes]) " +
                            $"values ('{dateTime}',{itemID},@quantity,'{weightBridgeCode}' ,'{employeeID}','{numBales}','{notes}')", connection))
                        {
                            addproductionInPut.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);
                            addproductionInPut.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Response.Write($"<script type=\"text/javascript\">alert('You can not produce more than Stock {stock} ');</script>");
                    }
                }
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Scrap for Production InPut');</script>");
            }

            //Response.Redirect("addWProduction-ERP.aspx");

            Purchase_Quantity_TextBox.Text = String.Empty;
            Num_Bales_TextBox.Text = String.Empty;
            jQueryScrapGridView.SelectedIndex = -1;

        }



    }
}





// Take last itemID from Production In Put and execute proper procedure by itemID Condition. 