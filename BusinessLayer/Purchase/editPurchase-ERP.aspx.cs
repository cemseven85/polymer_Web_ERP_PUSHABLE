using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System.Globalization;



namespace polymer_Web_ERP_V4
{
    public partial class editPurchase_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();



        protected override void OnPreRender(EventArgs e)
        {
            
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateMax = DateTime.Now;
            DateTime dateMin = dateMax.AddDays(-90);

            if (!this.IsPostBack)
            {
                ItemDateMin_TextBox.Text = dateMin.ToString("yyyy-MM-dd");
                ItemDateMax_TextBox.Text = dateMax.ToString("yyyy-MM-dd");
                
                //PurchaseGridViewBind();

                DropDownSellerGroupBind();
                DropDownSellerBind();
                DropDownProductGroupBind();
                DropDownProductBind();
                UnitTextBoxBind();
                VATTextBind();
                DropDownStockZoneBind();
                DropDownOriginBind();
                DropDownEmployeeBind();
                DropDownConsultantBind();




            }




        }


        //private void DropDownSellerGroupBind()
        //{
        //    string com = "Select * from [tbl_sellerGroup]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    SellerGroupIdDropDownList.DataSource = dt2;
        //    SellerGroupIdDropDownList.DataBind();
        //    SellerGroupIdDropDownList.DataTextField = "sell_Grp_Name";
        //    SellerGroupIdDropDownList.DataValueField = "sell_Grp_Id";
        //    SellerGroupIdDropDownList.DataBind();

        //}


        private void DropDownSellerGroupBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = "Select * from [tbl_sellerGroup]";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    SellerGroupIdDropDownList.DataSource = dt2;
                    SellerGroupIdDropDownList.DataTextField = "sell_Grp_Name";
                    SellerGroupIdDropDownList.DataValueField = "sell_Grp_Id";
                    SellerGroupIdDropDownList.DataBind();
                }
            }
        }


        protected void SellerGroupIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSellerBind();
        }

        //private void DropDownSellerBind()
        //{
        //    string com = $"Select * from [tbl_seller] where [sell_Group_Id]='{SellerGroupIdDropDownList.SelectedValue}'";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    SellerIdDropDownList.DataSource = dt2;
        //    SellerIdDropDownList.DataBind();
        //    SellerIdDropDownList.DataTextField = "sell_Name";
        //    SellerIdDropDownList.DataValueField = "sell_Id";
        //    SellerIdDropDownList.DataBind();
        //}


        //private void DropDownProductGroupBind()
        //{
        //    string com = $"Select * from [tbl_productGroup]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    PurchaseProductGroupIDDropDownList.DataSource = dt2;
        //    PurchaseProductGroupIDDropDownList.DataBind();
        //    PurchaseProductGroupIDDropDownList.DataTextField = "prod_Grp_Name";
        //    PurchaseProductGroupIDDropDownList.DataValueField = "prod_Grp_Id";
        //    PurchaseProductGroupIDDropDownList.DataBind();
        //}



        private void DropDownSellerBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_seller] where [sell_Group_Id]='{SellerGroupIdDropDownList.SelectedValue}'";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    SellerIdDropDownList.DataSource = dt2;
                    SellerIdDropDownList.DataTextField = "sell_Name";
                    SellerIdDropDownList.DataValueField = "sell_Id";
                    SellerIdDropDownList.DataBind();
                }
            }
        }

        private void DropDownProductGroupBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_productGroup]";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    PurchaseProductGroupIDDropDownList.DataSource = dt2;
                    PurchaseProductGroupIDDropDownList.DataTextField = "prod_Grp_Name";
                    PurchaseProductGroupIDDropDownList.DataValueField = "prod_Grp_Id";
                    PurchaseProductGroupIDDropDownList.DataBind();
                }
            }
        }


        protected void PurchaseProductGroupIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownProductBind();

        }

        //private void DropDownProductBind()
        //{
        //    string com = $"Select * from [tbl_product] where [prod_Group_Id]='{PurchaseProductGroupIDDropDownList.SelectedValue}' ";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    PurchaseProductIDDropDownList.DataSource = dt2;
        //    PurchaseProductIDDropDownList.DataBind();
        //    PurchaseProductIDDropDownList.DataTextField = "prod_Name";
        //    PurchaseProductIDDropDownList.DataValueField = "prod_Id";
        //    PurchaseProductIDDropDownList.DataBind();
        //}


        private void DropDownProductBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_product] where [prod_Group_Id]='{PurchaseProductGroupIDDropDownList.SelectedValue}'";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    PurchaseProductIDDropDownList.DataSource = dt2;
                    PurchaseProductIDDropDownList.DataTextField = "prod_Name";
                    PurchaseProductIDDropDownList.DataValueField = "prod_Id";
                    PurchaseProductIDDropDownList.DataBind();
                }
            }
        }

        
        protected void PurchaseProductIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pulling the Unit of product to Text Box.  

            UnitTextBoxBind();
            VATTextBind();
        }


        //private void UnitTextBoxBind()
        //{
        //    //Pulling the Unit of product to Text Box.  
        //    string com = $"select tbl_unit.unt_Name\r\nfrom tbl_unit \r\njoin tbl_product\r\non tbl_product.prod_Unit_Id=tbl_unit.unt_Id\r\nwhere tbl_product.prod_Id='{PurchaseProductIDDropDownList.SelectedValue}';";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);

        //    Purchase_Unit_TextBox.Text = dt2.Rows[0][0].ToString();
        //}


        //private void VATTextBind()
        //{
        //    string com = $"select [tbl_VAT].[vat_Name]\r\nfrom [tbl_VAT] \r\njoin tbl_product\r\non tbl_product.prod_VAT_Id=[tbl_VAT].[vat_Id]\r\nwhere tbl_product.prod_Id='{PurchaseProductIDDropDownList.SelectedValue}';";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);

        //    VAT_TextBox.Text = dt2.Rows[0][0].ToString();
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

        //private void DropDownOriginBind()
        //{
        //    string com = $"Select * from [tbl_origin]";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    OriginIDDropDownList.DataSource = dt2;
        //    OriginIDDropDownList.DataBind();
        //    OriginIDDropDownList.DataTextField = "org_Name";
        //    OriginIDDropDownList.DataValueField = "org_ID";
        //    OriginIDDropDownList.DataBind();
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


        private void UnitTextBoxBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"select tbl_unit.unt_Name\r\nfrom tbl_unit \r\njoin tbl_product\r\non tbl_product.prod_Unit_Id=tbl_unit.unt_Id\r\nwhere tbl_product.prod_Id='{PurchaseProductIDDropDownList.SelectedValue}';";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);

                    Purchase_Unit_TextBox.Text = dt2.Rows[0][0].ToString();
                }
            }
        }

        private void VATTextBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"select [tbl_VAT].[vat_Name]\r\nfrom [tbl_VAT] \r\njoin tbl_product\r\non tbl_product.prod_VAT_Id=[tbl_VAT].[vat_Id]\r\nwhere tbl_product.prod_Id='{PurchaseProductIDDropDownList.SelectedValue}';";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);

                    VAT_TextBox.Text = dt2.Rows[0][0].ToString();
                }
            }
        }

        private void DropDownStockZoneBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_stockZone]";
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

        private void DropDownOriginBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_origin]";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);

                    OriginIDDropDownList.DataSource = dt2;
                    OriginIDDropDownList.DataTextField = "org_Name";
                    OriginIDDropDownList.DataValueField = "org_ID";
                    OriginIDDropDownList.DataBind();
                }
            }
        }

        private void DropDownEmployeeBind()
        {
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_employee]";
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
            using (SqlConnection connection = conn.Connection())
            {
                string com = $"Select * from [tbl_consultant]";
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


        private void PurchaseGridViewBind()
        {


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listPurchase '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryPurchaseGridView.DataSource = dt;
                        jQueryPurchaseGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryPurchaseGridView.UseAccessibleHeader = true;
            jQueryPurchaseGridView.HeaderRow.TableSection = TableRowSection.TableHeader;



        }





        protected void jQueryPurchaseGridView_PreRender(object sender, EventArgs e)
        {
            this.PurchaseGridViewBind();

            if (jQueryPurchaseGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryPurchaseGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryPurchaseGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryPurchaseGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        //protected void jQueryPurchaseGridView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryPurchaseGridView.SelectedRow;

        //    // Date time value From Grid to Text Box
        //    Purchase_DateTextBox.Text = Convert.ToDateTime(row.Cells[1].Text).ToString("yyyy-MM-dd");


        //    // Other Text box Setting Values
        //    Invoice_No_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);
        //    Weight_Brige_Code_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 5);
        //    Purchase_Quantity_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 13);
        //    Unit_Price_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 14);
        //    Item_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 10);
        //    Item_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);


        //    //Seler Group ID From Seller Name 
        //    // SellerID from Seller Name 
        //    string sellerName = row.Cells[3].Text;
        //    string com2 = $"select * from [tbl_seller] where [sell_Name]='{sellerName}'";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com2, conn.Connection());
        //    DataTable dt3 = new DataTable();
        //    adpt.Fill(dt3);
        //    string ridSeller = dt3.Rows[0][0].ToString();
        //    string ridSellerGroup = dt3.Rows[0][4].ToString();

        //    // SellerGroup and Seller  Pulling
        //    SellerGroupIdDropDownList.SelectedValue = ridSellerGroup;
        //    DropDownSellerBind();
        //    SellerIdDropDownList.SelectedValue = ridSeller;


        //    //Product GroupID from Product Name 
        //    //ProductID from Product Name 
        //    string productName = row.Cells[2].Text;
        //    string com3 = $"select * from [tbl_product] where [prod_Name]='{productName}'";
        //    SqlDataAdapter adpt2 = new SqlDataAdapter(com3, conn.Connection());
        //    DataTable dt4 = new DataTable();
        //    adpt2.Fill(dt4);
        //    string ridProduct = dt4.Rows[0][0].ToString();  //row ID of Product
        //    string ridProductGroup = dt4.Rows[0][4].ToString();
        //    string ridUnit = dt4.Rows[0][5].ToString();
        //    string ridVAT = dt4.Rows[0][6].ToString();


        //    //Product Group and Product Pulling
        //    PurchaseProductGroupIDDropDownList.SelectedValue = ridProductGroup;
        //    DropDownProductBind(); // Or we can call the method -->  PurchaseProductGroupIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        //    PurchaseProductIDDropDownList.SelectedValue = ridProduct;

        //    //Product Unit Pulling 
        //    string com7 = $"select [unt_Name] from [tbl_unit] where [unt_Id]='{ridUnit}'";
        //    SqlDataAdapter adpt6 = new SqlDataAdapter(com7, conn.Connection());
        //    DataTable dt8 = new DataTable();
        //    adpt6.Fill(dt8);
        //    string unitName = dt8.Rows[0][0].ToString();

        //    Purchase_Unit_TextBox.Text = unitName;

        //    //Product VAT Pulling 

        //    string com8 = $"select [vat_Name] from [tbl_VAT] where [vat_Id]='{ridVAT}'";
        //    SqlDataAdapter adpt7 = new SqlDataAdapter(com8, conn.Connection());
        //    DataTable dt9 = new DataTable();
        //    adpt7.Fill(dt9);
        //    string vatName = dt9.Rows[0][0].ToString();

        //    VAT_TextBox.Text = vatName;

        //    //Origin Name To ID
        //    string originName = row.Cells[8].Text;
        //    string com4 = $"select [org_ID] from [tbl_origin] where [org_Name]='{originName}'";
        //    SqlDataAdapter adpt3 = new SqlDataAdapter(com4, conn.Connection());
        //    DataTable dt5 = new DataTable();
        //    adpt3.Fill(dt5);
        //    string ridOrigin = dt5.Rows[0][0].ToString();

        //    //Origin Pulling
        //    OriginIDDropDownList.SelectedValue = ridOrigin;



        //    // Stock Zone Name To ID
        //    string stockZoneName = row.Cells[6].Text;
        //    string com5 = $"select [stk_Zn_Id] from [tbl_stockZone] where [stk_Zn_Name]='{stockZoneName}'";
        //    SqlDataAdapter adpt4 = new SqlDataAdapter(com5, conn.Connection());
        //    DataTable dt6 = new DataTable();
        //    adpt4.Fill(dt6);
        //    string ridstockZone = dt6.Rows[0][0].ToString();

        //    //Stock Zone Pulling
        //    StockZoneIDDropDownList.SelectedValue = ridstockZone;



        //    //Employee Name To ID
        //    string employeeName = row.Cells[7].Text;
        //    string com6 = $"select [empl_Id] from [tbl_employee] where [empl_Name_TR]='{employeeName}'";
        //    SqlDataAdapter adpt5 = new SqlDataAdapter(com6, conn.Connection());
        //    DataTable dt7 = new DataTable();
        //    adpt5.Fill(dt7);
        //    string ridEmployee = dt7.Rows[0][0].ToString();


        //    //Employee Name Pulling
        //    EmployeeIDDropDownList.SelectedValue = ridEmployee;


        //    //Consultant Name tTo ID 
        //    string consultantName = row.Cells[21].Text;
        //    string com10 = $"select [cnslt_Id] from [tbl_consultant] where [cnslt_Name]='{consultantName}'";
        //    SqlDataAdapter adpt10 = new SqlDataAdapter(com10, conn.Connection());
        //    DataTable dt10 = new DataTable();
        //    adpt10.Fill(dt10);
        //    string ridConsultant = dt10.Rows[0][0].ToString();

        //    //Consultant Name Pulling
        //    ConsultantDropDownList.SelectedValue = ridConsultant;


        //}



        protected void jQueryPurchaseGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = jQueryPurchaseGridView.SelectedRow;

            // Date time value From Grid to Text Box
            Purchase_DateTextBox.Text = Convert.ToDateTime(row.Cells[1].Text).ToString("yyyy-MM-dd");

            // Other Text box Setting Values
            Invoice_No_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);
            Weight_Brige_Code_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 5);
            Purchase_Quantity_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 13);
            Unit_Price_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 14);
            Item_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 10);
            Item_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);

            using (SqlConnection connection = conn.Connection())
            {
                //Seler Group ID From Seller Name 
                // SellerID from Seller Name 
                string sellerName = row.Cells[3].Text;
                string com2 = $"select * from [tbl_seller] where [sell_Name]='{sellerName}'";
                using (SqlDataAdapter adpt = new SqlDataAdapter(com2, connection))
                {
                    DataTable dt3 = new DataTable();
                    adpt.Fill(dt3);
                    string ridSeller = dt3.Rows[0][0].ToString();
                    string ridSellerGroup = dt3.Rows[0][4].ToString();

                    // SellerGroup and Seller  Pulling
                    SellerGroupIdDropDownList.SelectedValue = ridSellerGroup;
                    DropDownSellerBind();
                    SellerIdDropDownList.SelectedValue = ridSeller;
                }

                //Product GroupID from Product Name 
                //ProductID from Product Name 
                string productName = row.Cells[2].Text;
                string com3 = $"select * from [tbl_product] where [prod_Name]='{productName}'";
                using (SqlDataAdapter adpt2 = new SqlDataAdapter(com3, connection))
                {
                    DataTable dt4 = new DataTable();
                    adpt2.Fill(dt4);
                    string ridProduct = dt4.Rows[0][0].ToString();  //row ID of Product
                    string ridProductGroup = dt4.Rows[0][4].ToString();
                    string ridUnit = dt4.Rows[0][5].ToString();
                    string ridVAT = dt4.Rows[0][6].ToString();

                    //Product Group and Product Pulling
                    PurchaseProductGroupIDDropDownList.SelectedValue = ridProductGroup;
                    DropDownProductBind(); // Or we can call the method -->  PurchaseProductGroupIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
                    PurchaseProductIDDropDownList.SelectedValue = ridProduct;

                    //Product Unit Pulling 
                    string com7 = $"select [unt_Name] from [tbl_unit] where [unt_Id]='{ridUnit}'";
                    using (SqlDataAdapter adpt6 = new SqlDataAdapter(com7, connection))
                    {
                        DataTable dt8 = new DataTable();
                        adpt6.Fill(dt8);
                        string unitName = dt8.Rows[0][0].ToString();
                        Purchase_Unit_TextBox.Text = unitName;
                    }

                    //Product VAT Pulling 
                    string com8 = $"select [vat_Name] from [tbl_VAT] where [vat_Id]='{ridVAT}'";
                    using (SqlDataAdapter adpt7 = new SqlDataAdapter(com8, connection))
                    {
                        DataTable dt9 = new DataTable();
                        adpt7.Fill(dt9);
                        string vatName = dt9.Rows[0][0].ToString();
                        VAT_TextBox.Text = vatName;
                    }
                }

                //Origin Name To ID
                string originName = row.Cells[8].Text;
                string com4 = $"select [org_ID] from [tbl_origin] where [org_Name]='{originName}'";
                using (SqlDataAdapter adpt3 = new SqlDataAdapter(com4, connection))
                {
                    DataTable dt5 = new DataTable();
                    adpt3.Fill(dt5);
                    string ridOrigin = dt5.Rows[0][0].ToString();

                    //Origin Pulling
                    OriginIDDropDownList.SelectedValue = ridOrigin;
                }

                // Stock Zone Name To ID
                string stockZoneName = row.Cells[6].Text;
                string com5 = $"select [stk_Zn_Id] from [tbl_stockZone] where [stk_Zn_Name]='{stockZoneName}'";
                using (SqlDataAdapter adpt4 = new SqlDataAdapter(com5, connection))
                {
                    DataTable dt6 = new DataTable();
                    adpt4.Fill(dt6);
                    string ridstockZone = dt6.Rows[0][0].ToString();

                    //Stock Zone Pulling
                    StockZoneIDDropDownList.SelectedValue = ridstockZone;
                }

                //Employee Name To ID
                string employeeName = row.Cells[7].Text;
                string com6 = $"select [empl_Id] from [tbl_employee] where [empl_Name_TR]='{employeeName}'";
                using (SqlDataAdapter adpt5 = new SqlDataAdapter(com6, connection))
                {
                    DataTable dt7 = new DataTable();
                    adpt5.Fill(dt7);
                    string ridEmployee = dt7.Rows[0][0].ToString();

                    //Employee Name Pulling
                    EmployeeIDDropDownList.SelectedValue = ridEmployee;
                }

                //Consultant Name tTo ID 
                string consultantName = row.Cells[21].Text;
                string com10 = $"select [cnslt_Id] from [tbl_consultant] where [cnslt_Name]='{consultantName}'";
                using (SqlDataAdapter adpt10 = new SqlDataAdapter(com10, connection))
                {
                    DataTable dt10 = new DataTable();
                    adpt10.Fill(dt10);
                    string ridConsultant = dt10.Rows[0][0].ToString();

                    //Consultant Name Pulling
                    ConsultantDropDownList.SelectedValue = ridConsultant;
                }
            }
        }


        //protected void EditButton_Click(object sender, EventArgs e)
        //{

        //    if (Page.IsValid)
        //    {

        //        string invoiceNo;
        //        string sellerGroupID;
        //        string sellerID;
        //        string date;
        //        string productGroupID;
        //        string productID;
        //        string quantity;
        //        string quantityDot;
        //        string unit;
        //        string price;
        //        string priceDot;
        //        string stockZoneID;
        //        string originID;
        //        string weightBridgeCode;
        //        string employeeID;
        //        string itemName;
        //        string consultantID;
        //        string note;
        //        string itemID;


        //        invoiceNo = Invoice_No_TextBox.Text;
        //        sellerID = SellerIdDropDownList.SelectedValue;
        //        sellerGroupID = SellerGroupIdDropDownList.SelectedValue;
        //        date = Purchase_DateTextBox.Text;
        //        productGroupID = PurchaseProductGroupIDDropDownList.SelectedValue;
        //        productID = PurchaseProductIDDropDownList.SelectedValue;
        //        quantity = Purchase_Quantity_TextBox.Text;
        //        quantityDot = quantity.Replace(",", ".");
        //        unit = Purchase_Unit_TextBox.Text;
        //        price = Unit_Price_TextBox.Text;
        //        priceDot = price.Replace(",", ".");
        //        stockZoneID = StockZoneIDDropDownList.SelectedValue;
        //        originID = OriginIDDropDownList.SelectedValue;
        //        weightBridgeCode = Weight_Brige_Code_TextBox.Text;
        //        employeeID = EmployeeIDDropDownList.SelectedValue;
        //        consultantID = ConsultantDropDownList.SelectedValue;
        //        itemName = Item_Name_TextBox.Text;
        //        note = Item_Note_TextBox.Text;

        //        //We ned The ID of Item and ID of Purchase to Edit them 
        //        GridViewRow row = jQueryPurchaseGridView.SelectedRow;

        //        if (row != null)
        //        {



        //            itemID = row.Cells[20].Text;

        //            // Fist we eddit Item table

        //            SqlCommand editItem = new SqlCommand($"update [tbl_item] set item_Name='{itemName}' ,[item_Quantitiy]='{quantityDot}',[item_UnitPrice]='{priceDot}',[item_CreateDate]='{date}',[item_UpdateDate]='{date}',[stockZone_Id]='{stockZoneID}',[prod_Id]='{productID}',[origin_Id]='{originID}',[item_Note]='{note}',[item_Consultant_Id]='{consultantID}' where [item_Id]= '{itemID}' ", conn.Connection());
        //            // editItem.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(price, CultureInfo.CurrentCulture);
        //            // editItem.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);


        //            editItem.ExecuteNonQuery();

        //            // Second we eddit purchase table

        //            SqlCommand editPurchase = new SqlCommand($"update [tbl_purchase] set [pur_Date]='{date}',[pur_Sell_Id]='{sellerID}',[pur_Quantity]='{quantityDot}',[pur_Weigh_Bridge_Code]='{weightBridgeCode}',[pur_Supervisor_Employee_Id]='{employeeID}',[pur_Unit_Price]='{priceDot}',[pur_Invoice_No]='{invoiceNo}',[pur_Consultant_Id]='{consultantID}' where [item_Id]= '{itemID}' ", conn.Connection());

        //            //editPurchase.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(price, CultureInfo.CurrentCulture);
        //            //editPurchase.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

        //            editPurchase.ExecuteNonQuery();







        //            // We start to Edit TXN We start to Edit TXN  We start to Edit TXN We start to Edit TXN

        //            // Txn Variables start from here. // Txn Variables start from here.  // Txn Variables start from here.// Txn Variables start from here.
        //            string txnID;
        //            string txnDate;
        //            string acctID;
        //            string txnTypeID;
        //            string txnDetailID;

        //            string txnAmount;
        //            string txnNotes = note;
        //            string balanceBefore;

        //            //Before First assign updated date 

        //            txnDate = date;

        //            // First we need the txnID for UdDating that from this purchase. 
        //            string purID;  // Need to pull purID  for the TxnId

        //            string pullpurID = $"SELECT [pur_Id] FROM [tbl_purchase]\r\nWHERE [item_Id] = '{itemID}'";
        //            SqlDataAdapter adpt9 = new SqlDataAdapter(pullpurID, conn.Connection());
        //            DataTable dt9 = new DataTable();
        //            adpt9.Fill(dt9);
        //            purID = dt9.Rows[0][0].ToString();



        //            string pullTxnID = $"SELECT [txn_Id] FROM [tbl_purchase]\r\nWHERE [pur_Id] = '{purID}'";
        //            SqlDataAdapter adpt10 = new SqlDataAdapter(pullTxnID, conn.Connection());
        //            DataTable dt10 = new DataTable();
        //            adpt10.Fill(dt10);
        //            txnID = dt10.Rows[0][0].ToString();

        //            // Second we need the accountID of updated Purches From Seller ID of UpDated Purchse. 
        //            // Find AcctId of this seller

        //            string pullAcctID = $"SELECT [acct_ID] FROM [tbl_seller]\r\nWHERE [sell_Id] ='{sellerID}' ";
        //            SqlDataAdapter adpt11 = new SqlDataAdapter(pullAcctID, conn.Connection());
        //            DataTable dt11 = new DataTable();
        //            adpt11.Fill(dt11);
        //            acctID = dt11.Rows[0][0].ToString();

        //            // Third donot change txnType becasue all Ourchese Invoice Same. 
        //            txnTypeID = "1";   // Do not need to update. 

        //            //Four assign updated purches txnDetail.

        //            if (productGroupID == "1" || productGroupID == "2" || productGroupID == "3" || productGroupID == "5" || productGroupID == "6")
        //            {
        //                txnDetailID = "14";
        //            }
        //            else if (productGroupID == "7")
        //            {
        //                txnDetailID = "15";
        //            }
        //            else if (productGroupID == "8")
        //            {
        //                txnDetailID = "16";
        //            }
        //            else if (productGroupID == "4")
        //            {
        //                txnDetailID = "17";
        //            }
        //            else
        //            {
        //                txnDetailID = "15";
        //            }

        //            //Fifth  Not need to Assign Consultant we are gone a ue the same varible from Purchase ConsultantID

        //            //Six not Update the txn_Debit to null beceuse all Purcheses are Credit not debit. 

        //            //Seven assign the  the updated txnCredit mean  txnAmount Value   

        //            //Pull updated Purchase total Amount. 
        //            string totalTxnPur = $"execute prc_totalTxnPurchase '{purID}' ";
        //            SqlDataAdapter adpt12 = new SqlDataAdapter(totalTxnPur, conn.Connection());
        //            DataTable dt12 = new DataTable();
        //            adpt12.Fill(dt12);
        //            txnAmount = dt12.Rows[0][0].ToString();

        //            // Eight Find the balance amount  before this purchase. //     *******WE CANCEL THIS BECAUSE WE DELETE THE CURRENT (Acctual) BALANCE COLUMN * *******



        //            SqlCommand editTXN = new SqlCommand($"update [tbl_transactions] set [txn_Date]='{txnDate}',[acct_ID]='{acctID}',[txn_Type_ID]='{txnTypeID}',[txn_Detail_ID]='{txnDetailID}',[consultant_ID]='{consultantID}',[txn_Credit]=@txnAmount,[txn_Notes]='{txnNotes}' where [txn_ID]= '{txnID}' ", conn.Connection());
        //            editTXN.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmount, CultureInfo.CurrentCulture);
        //            editTXN.ExecuteNonQuery();



        //            Response.Redirect("editPurchase-ERP.aspx");

        //        }


        //        else
        //        {
        //            Response.Write($"<script type=\"text/javascript\">alert('You need to select Purchase for Edit');</script>");
        //        }
        //        // ********************************      //
        //        // Need to solve the Int convert Problem While editing. 


        //    }

        //    else
        //    {

        //        string message = "Wrong Format or Missing Field You Can Not Edit !!";
        //        string script = "if(confirm('" + message + "')){ window.location='editPurchase-ERP.aspx?'; }";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "EditConfirmation", script, true);
        //    }

        //}


        protected void EditButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection connection = conn.Connection())
                {
                    GridViewRow row = jQueryPurchaseGridView.SelectedRow;

                    if (row != null)
                    {
                        string itemID = row.Cells[20].Text;

                        string invoiceNo = Invoice_No_TextBox.Text;
                        string sellerID = SellerIdDropDownList.SelectedValue;
                        string sellerGroupID = SellerGroupIdDropDownList.SelectedValue;
                        string date = Purchase_DateTextBox.Text;
                        string productGroupID = PurchaseProductGroupIDDropDownList.SelectedValue;
                        string productID = PurchaseProductIDDropDownList.SelectedValue;
                        string quantity = Purchase_Quantity_TextBox.Text.Replace(",", ".");
                        string unit = Purchase_Unit_TextBox.Text;
                        string price = Unit_Price_TextBox.Text.Replace(",", ".");
                        string stockZoneID = StockZoneIDDropDownList.SelectedValue;
                        string originID = OriginIDDropDownList.SelectedValue;
                        string weightBridgeCode = Weight_Brige_Code_TextBox.Text;
                        string employeeID = EmployeeIDDropDownList.SelectedValue;
                        string consultantID = ConsultantDropDownList.SelectedValue;
                        string itemName = Item_Name_TextBox.Text;
                        string note = Item_Note_TextBox.Text;

                        SqlCommand editItem = new SqlCommand($"UPDATE [tbl_item] SET item_Name = @itemName, [item_Quantitiy] = @quantity, [item_UnitPrice] = @price, [item_CreateDate] = @date, [item_UpdateDate] = @date, [stockZone_Id] = @stockZoneID, [prod_Id] = @productID, [origin_Id] = @originID, [item_Note] = @note, [item_Consultant_Id] = @consultantID WHERE [item_Id] = @itemID", connection);
                        editItem.Parameters.AddWithValue("@itemName", itemName);
                        editItem.Parameters.AddWithValue("@quantity", quantity);
                        editItem.Parameters.AddWithValue("@price", price);
                        editItem.Parameters.AddWithValue("@date", date);
                        editItem.Parameters.AddWithValue("@stockZoneID", stockZoneID);
                        editItem.Parameters.AddWithValue("@productID", productID);
                        editItem.Parameters.AddWithValue("@originID", originID);
                        editItem.Parameters.AddWithValue("@note", note);
                        editItem.Parameters.AddWithValue("@consultantID", consultantID);
                        editItem.Parameters.AddWithValue("@itemID", itemID);
                        editItem.ExecuteNonQuery();

                        SqlCommand editPurchase = new SqlCommand($"UPDATE [tbl_purchase] SET [pur_Date] = @date, [pur_Sell_Id] = @sellerID, [pur_Quantity] = @quantity, [pur_Weigh_Bridge_Code] = @weightBridgeCode, [pur_Supervisor_Employee_Id] = @employeeID, [pur_Unit_Price] = @price, [pur_Invoice_No] = @invoiceNo, [pur_Consultant_Id] = @consultantID WHERE [item_Id] = @itemID", connection);
                        editPurchase.Parameters.AddWithValue("@date", date);
                        editPurchase.Parameters.AddWithValue("@sellerID", sellerID);
                        editPurchase.Parameters.AddWithValue("@quantity", quantity);
                        editPurchase.Parameters.AddWithValue("@weightBridgeCode", weightBridgeCode);
                        editPurchase.Parameters.AddWithValue("@employeeID", employeeID);
                        editPurchase.Parameters.AddWithValue("@price", price);
                        editPurchase.Parameters.AddWithValue("@invoiceNo", invoiceNo);
                        editPurchase.Parameters.AddWithValue("@consultantID", consultantID);
                        editPurchase.Parameters.AddWithValue("@itemID", itemID);
                        editPurchase.ExecuteNonQuery();

                        // Additional SQL commands for editing transactions go here

                        // We start to Edit TXN We start to Edit TXN  We start to Edit TXN We start to Edit TXN

                        // Txn Variables start from here. // Txn Variables start from here.  // Txn Variables start from here.// Txn Variables start from here.
                        string txnID;
                        string txnDate;
                        string acctID;
                        string txnTypeID;
                        string txnDetailID;

                        string txnAmount;
                        string txnNotes = note;
                        string balanceBefore;

                        //Before First assign updated date 

                        txnDate = date;

                        // First we need the txnID for UdDating that from this purchase. 
                        string purID;  // Need to pull purID  for the TxnId

                        string pullpurID = $"SELECT [pur_Id] FROM [tbl_purchase]\r\nWHERE [item_Id] = '{itemID}'";
                        SqlDataAdapter adpt9 = new SqlDataAdapter(pullpurID, connection);
                        DataTable dt9 = new DataTable();
                        adpt9.Fill(dt9);
                        purID = dt9.Rows[0][0].ToString();



                        string pullTxnID = $"SELECT [txn_Id] FROM [tbl_purchase]\r\nWHERE [pur_Id] = '{purID}'";
                        SqlDataAdapter adpt10 = new SqlDataAdapter(pullTxnID, connection);
                        DataTable dt10 = new DataTable();
                        adpt10.Fill(dt10);
                        txnID = dt10.Rows[0][0].ToString();

                        // Second we need the accountID of updated Purches From Seller ID of UpDated Purchse. 
                        // Find AcctId of this seller

                        string pullAcctID = $"SELECT [acct_ID] FROM [tbl_seller]\r\nWHERE [sell_Id] ='{sellerID}' ";
                        SqlDataAdapter adpt11 = new SqlDataAdapter(pullAcctID, connection);
                        DataTable dt11 = new DataTable();
                        adpt11.Fill(dt11);
                        acctID = dt11.Rows[0][0].ToString();

                        // Third donot change txnType becasue all Ourchese Invoice Same. 
                        txnTypeID = "1";   // Do not need to update. 

                        //Four assign updated purches txnDetail.

                        if (productGroupID == "1" || productGroupID == "2" || productGroupID == "3" || productGroupID == "5" || productGroupID == "6")
                        {
                            txnDetailID = "14";
                        }
                        else if (productGroupID == "7")
                        {
                            txnDetailID = "15";
                        }
                        else if (productGroupID == "8")
                        {
                            txnDetailID = "16";
                        }
                        else if (productGroupID == "4")
                        {
                            txnDetailID = "17";
                        }
                        else
                        {
                            txnDetailID = "15";
                        }

                        //Fifth  Not need to Assign Consultant we are gone a ue the same varible from Purchase ConsultantID

                        //Six not Update the txn_Debit to null beceuse all Purcheses are Credit not debit. 

                        //Seven assign the  the updated txnCredit mean  txnAmount Value   

                        //Pull updated Purchase total Amount. 
                        string totalTxnPur = $"execute prc_totalTxnPurchase '{purID}' ";
                        SqlDataAdapter adpt12 = new SqlDataAdapter(totalTxnPur, connection);
                        DataTable dt12 = new DataTable();
                        adpt12.Fill(dt12);
                        txnAmount = dt12.Rows[0][0].ToString();

                        // Eight Find the balance amount  before this purchase. //     *******WE CANCEL THIS BECAUSE WE DELETE THE CURRENT (Acctual) BALANCE COLUMN * *******



                        SqlCommand editTXN = new SqlCommand($"update [tbl_transactions] set [txn_Date]='{txnDate}',[acct_ID]='{acctID}',[txn_Type_ID]='{txnTypeID}',[txn_Detail_ID]='{txnDetailID}',[consultant_ID]='{consultantID}',[txn_Credit]=@txnAmount,[txn_Notes]='{txnNotes}' where [txn_ID]= '{txnID}' ", connection);
                        editTXN.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmount, CultureInfo.CurrentCulture);
                        editTXN.ExecuteNonQuery();

                        Response.Redirect("editPurchase-ERP.aspx");
                    }
                    else
                    {
                        Response.Write($"<script type=\"text/javascript\">alert('You need to select Purchase for Edit');</script>");
                    }
                }
            }
            else
            {
                string message = "Wrong Format or Missing Field You Can Not Edit !!";
                string script = "if(confirm('" + message + "')){ window.location='editPurchase-ERP.aspx?'; }";
                ScriptManager.RegisterStartupScript(this, GetType(), "EditConfirmation", script, true);
            }
        }


        protected void ShowReportButton_Click(object sender, EventArgs e)
        {
            PurchaseGridViewBind();
        }

        
    }
}