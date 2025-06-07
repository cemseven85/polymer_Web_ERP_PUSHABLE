using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Globalization;
using System.Data.Common;
using System.Windows.Forms;


namespace polymer_Web_ERP_V4
{
    public partial class addPurchase_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime datePurchase = DateTime.Now;

            if (!this.IsPostBack)
            {

                Purchase_DateTextBox.Text = datePurchase.ToString("yyyy-MM-dd");

                DropDownSellerGroupBind();
                DropDownSellerBind();
                DropDownProductGroupBind();
                DropDownProductBind();
                UnitTextBoxBind();
                //VATTextBind();
                VATDropDownBind(); // We add Added DropDownList for VAT selection after the tbl_Purchase-add-taxId Branch and this is the bind of it
                DropDownStockZoneBind();
                DropDownOriginBind();
                DropDownEmployeeBind();
                DropDownConsultantBind();
                PurchaseGridViewBind();



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
            string com = "Select * from [tbl_sellerGroup]";
            string connectionString = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    SellerGroupIdDropDownList.DataSource = dt2;
                    SellerGroupIdDropDownList.DataBind();
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
        //    PurchaseProductGroupIDDropDownList.DataTextField ="prod_Grp_Name";
        //    PurchaseProductGroupIDDropDownList.DataValueField ="prod_Grp_Id";
        //    PurchaseProductGroupIDDropDownList.DataBind();
        //}




        private void DropDownSellerBind()
        {
            string com = $"Select * from [tbl_seller] where [sell_Group_Id]='{SellerGroupIdDropDownList.SelectedValue}'";
            string connectionString = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
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
        }

        private void DropDownProductGroupBind()
        {
            string com = $"Select * from [tbl_productGroup]";
            string connectionString = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    PurchaseProductGroupIDDropDownList.DataSource = dt2;
                    PurchaseProductGroupIDDropDownList.DataBind();
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
            string com = $"Select * from [tbl_product] where [prod_Group_Id]='{PurchaseProductGroupIDDropDownList.SelectedValue}'";
            string connectionString = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    PurchaseProductIDDropDownList.DataSource = dt2;
                    PurchaseProductIDDropDownList.DataBind();
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
            //VATTextBind();
            VATDropDownBind(); // We add Added DropDownList for VAT selection after the tbl_Purchase-add-taxId Branch and this is the bind of it
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
            string com = $"select tbl_unit.unt_Name\r\nfrom tbl_unit \r\njoin tbl_product\r\non tbl_product.prod_Unit_Id=tbl_unit.unt_Id\r\nwhere tbl_product.prod_Id='{PurchaseProductIDDropDownList.SelectedValue}';";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);

                    Purchase_Unit_TextBox.Text = dt2.Rows[0][0].ToString();
                }
            }
        }

        //private void VATTextBind()
        //{
        //    string com = $"select [tbl_VAT].[vat_Name]\r\nfrom [tbl_VAT] \r\njoin tbl_product\r\non tbl_product.prod_VAT_Id=[tbl_VAT].[vat_Id]\r\nwhere tbl_product.prod_Id='{PurchaseProductIDDropDownList.SelectedValue}';";

        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
        //    {
        //        using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
        //        {
        //            DataTable dt2 = new DataTable();
        //            adpt.Fill(dt2);

        //            VAT_TextBox.Text = dt2.Rows[0][0].ToString();
        //        }
        //    }
        //}

        // We add Added DropDownList for VAT selection after the tbl_Purchase-add-taxId Branch and this is the bind of it   

        private void VATDropDownBind()
        {
            string com = "SELECT vat_Id, vat_Name FROM tbl_VAT";
            string connectionString = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    VATDropDownList.DataSource = dt;
                    VATDropDownList.DataTextField = "vat_Name";
                    VATDropDownList.DataValueField = "vat_Id";
                    VATDropDownList.DataBind();
                }
            }
        }



        private void DropDownStockZoneBind()
        {
            string com = $"Select * from [tbl_stockZone];";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
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
        }

        private void DropDownOriginBind()
        {
            string com = $"Select * from [tbl_origin];";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);

                    OriginIDDropDownList.DataSource = dt2;
                    OriginIDDropDownList.DataBind();
                    OriginIDDropDownList.DataTextField = "org_Name";
                    OriginIDDropDownList.DataValueField = "org_ID";
                    OriginIDDropDownList.DataBind();
                }
            }
        }

        private void DropDownEmployeeBind()
        {
            string com = $"Select * from [tbl_employee];";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
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
        }

        private void DropDownConsultantBind()
        {
            string com = $"Select * from [tbl_consultant];";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
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
        }



        //protected void AddButton_Click(object sender, EventArgs e)
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
        //        string consultantID;
        //        string itemName;
        //        string note;
        //        string itemID;
        //        // Txn Variables start from here. // Txn Variables start from here.  // Txn Variables start from here.// Txn Variables start from here.

        //        //string txnPayColl;

        //        string txnDate;
        //        string acctID;
        //        string txnTypeID;
        //        string txnDetailID;

        //        string txnAmount;
        //        string txnNotes;




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
        //        consultantID= ConsultantDropDownList.SelectedValue;
        //        itemName = Item_Name_TextBox.Text;
        //        note = Item_Note_TextBox.Text;

        //        // Fist we add Item table

        //        SqlCommand addItem = new SqlCommand($"insert into [tbl_item] (item_Name,[item_Quantitiy],[item_UnitPrice],[item_CreateDate],[item_UpdateDate],[stockZone_Id],[prod_Id],[origin_Id],[item_Note],[item_Consultant_Id]) " +
        //            $"values ('{itemName}',{quantityDot}, {priceDot},'{date}' ,'{date}','{stockZoneID}','{productID}','{originID}','{note}','{consultantID}')", conn.Connection());

        //        //addItem.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(price, CultureInfo.CurrentCulture);       WE CHANGE THE USAGE WITH REPLACE "," to "." 
        //        //addItem.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

        //        addItem.ExecuteNonQuery();

        //        // Pulling the last ID for editing Purchase 

        //        string lastItemID = $"SELECT [item_Id] FROM [tbl_item]\r\nWHERE [item_Id] = (\r\n    SELECT MAX([item_Id]) FROM [tbl_item])";
        //        SqlDataAdapter adpt = new SqlDataAdapter(lastItemID, conn.Connection());
        //        DataTable dt2 = new DataTable();
        //        adpt.Fill(dt2);
        //        itemID = dt2.Rows[0][0].ToString();


        //        // Then add Purchase table

        //        SqlCommand addPurchase = new SqlCommand($"insert into [tbl_purchase] ([pur_Date],[item_Id],[pur_Sell_Id],[pur_Quantity],[pur_Weigh_Bridge_Code],[pur_Supervisor_Employee_Id],[pur_Unit_Price],[pur_Invoice_No],[pur_Consultant_Id]) " +
        //            $"values ('{date}' ,'{itemID}','{sellerID}',{quantityDot},'{weightBridgeCode}','{employeeID}',{priceDot}, '{invoiceNo}','{consultantID}')", conn.Connection());

        //        // addPurchase.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToDecimal(price, CultureInfo.CurrentCulture);    WE CHANGE THE USAGE WITH REPLACE "," to "." 
        //        // addPurchase.Parameters.Add("@quantity", SqlDbType.Decimal).Value = Convert.ToDecimal(quantity, CultureInfo.CurrentCulture);

        //        addPurchase.ExecuteNonQuery();



        //        // We START  to add this purchse to Transaction Table.   // We START  to add this purchse to Transaction Table.  // We START  to add this purchse to Transaction Table.

        //        // First find AcctId of this seller
        //        string pullAcctID = $"SELECT [acct_ID] FROM [tbl_seller]\r\nWHERE [sell_Id] ='{sellerID}' ";
        //        SqlDataAdapter adpt4 = new SqlDataAdapter(pullAcctID, conn.Connection());
        //        DataTable dt4 = new DataTable();
        //        adpt4.Fill(dt4);
        //        acctID = dt4.Rows[0][0].ToString();

        //        //Then add new row to Transaction tables. 

        //        txnTypeID = "1";     // Purchase Invoice;


        //        if(productGroupID=="1"|| productGroupID == "2" || productGroupID == "3" || productGroupID == "5" || productGroupID == "6" )
        //        {
        //            txnDetailID = "14";
        //        }
        //        else if (productGroupID == "7" )
        //        {
        //            txnDetailID = "15";
        //        }
        //        else if (productGroupID == "8")
        //        {
        //            txnDetailID = "16";
        //        }
        //        else if (productGroupID == "4")
        //        {
        //            txnDetailID = "17";
        //        }
        //        else
        //        {
        //            txnDetailID = "15";
        //        }

        //        // First pull the current balance before this Transaction.    *******WE CANCEL THIS BECAUSE WE DELETE THE CURRENT (Acctual) BALANCE COLUMN********



        //        //string com = $"execute prc_acctBalance '{acctID}' ";
        //        //SqlDataAdapter adpt5 = new SqlDataAdapter(com, conn.Connection());
        //        //DataTable dt5 = new DataTable();
        //        //adpt5.Fill(dt5);
        //        //string balanceBefore = dt5.Rows[0][0].ToString();

        //        //// If we want to cancel this query we can pull data from acctBalance Lable  

        //        //double balanceBeforeNum;
        //        //double addToBalanceNum;


        //        //Assign Varibles for Transaction Query

        //        txnDate = date;
        //        string txnNull = "0";
        //        // acctID txnTypeID txnDetailID  consultantID  ready by query up. 
        //        txnNotes = note;

        //        // Find last PurchaseID for pulling the purchse Amount 
        //        string purID;
        //        string lastPurID = $"SELECT [pur_Id] FROM [tbl_purchase]\r\nWHERE [pur_Id] = (\r\n    SELECT MAX([pur_Id]) FROM [tbl_purchase])";
        //        SqlDataAdapter adpt6 = new SqlDataAdapter(lastPurID, conn.Connection());
        //        DataTable dt6 = new DataTable();
        //        adpt6.Fill(dt6);
        //        purID = dt6.Rows[0][0].ToString();


        //        //Pull last Purchase total Amount. 
        //        string totalTxnPur = $"execute prc_totalTxnPurchase '{purID}' ";
        //        SqlDataAdapter adpt7 = new SqlDataAdapter(totalTxnPur, conn.Connection());
        //        DataTable dt7 = new DataTable();
        //        adpt7.Fill(dt7);
        //        txnAmount = dt7.Rows[0][0].ToString();



        //        //                   *******WE CANCEL THIS BECAUSE WE DELETE THE CURRENT (Acctual) BALANCE COLUMN * *******
        //        //if (balanceBefore.Length > 0)

        //        //{

        //        //    balanceBeforeNum = Convert.ToDouble(balanceBefore);
        //        //    addToBalanceNum = Convert.ToDouble(txnAmount);
        //        //}
        //        //else
        //        //{
        //        //    balanceBeforeNum = 0;
        //        //    addToBalanceNum = Convert.ToDouble(txnAmount);
        //        //}
        //        //double acctBalanceNum;
        //        //string acctBalance;

        //        //acctBalanceNum = balanceBeforeNum + addToBalanceNum;

        //        //acctBalance = acctBalanceNum.ToString();


        //        SqlCommand addTxn = new SqlCommand($"insert into [tbl_transactions] ([txn_Date]\r\n,[acct_ID]\r\n,[txn_Type_ID]\r\n,[txn_Detail_ID]\r\n,[consultant_ID]\r\n,[txn_Debit],[txn_Credit]\r\n,[txn_Notes] )" +
        //                $"values ('{txnDate}',{acctID},{txnTypeID},{txnDetailID},{consultantID},@txnNull,@txnAmount,'{txnNotes}')", conn.Connection());
        //        addTxn.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmount, CultureInfo.CurrentCulture);

        //        addTxn.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
        //        addTxn.ExecuteNonQuery();

        //        // And last add the txnID to Purchse table 

        //        // Find Last txID from tbl_transactions


        //        string txnID;
        //        string lastTxnID = $"SELECT [txn_Id] FROM [tbl_transactions]\r\nWHERE [txn_Id] = (\r\n    SELECT MAX([txn_Id]) FROM [tbl_transactions])";
        //        SqlDataAdapter adpt10 = new SqlDataAdapter(lastTxnID, conn.Connection());
        //        DataTable dt10 = new DataTable();
        //        adpt10.Fill(dt10);
        //        txnID = dt10.Rows[0][0].ToString();


        //        // UpDate the lastPurchse ID Row by Adding the txnID

        //        SqlCommand addTxnID = new SqlCommand($"update [tbl_purchase] set txn_Id='{txnID}'  where [pur_Id]= '{purID}' ", conn.Connection()); 


        //       addTxnID.ExecuteNonQuery();




        //        Response.Redirect("addPurchase-ERP.aspx");

        //    }

        //    else
        //    {

        //        string message = "Wrong Format or Missing Field You Can Not Add !!";
        //        string script = "if(confirm('" + message + "')){ window.location='addPurchase-ERP.aspx?'; }";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "AddConfirmation", script, true);
        //    }





        //}



        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string invoiceNo;
                string sellerGroupID;
                string sellerID;
                string date;
                string productGroupID;
                string productID;
                string quantity;
                string quantityDot;
                string unit;
                string price;
                string priceDot;
                string stockZoneID;
                string originID;
                string weightBridgeCode;
                string employeeID;
                string consultantID;
                string itemName;
                string note;
                string itemID;

                // Txn Variables start from here.
                string txnDate;
                string acctID;
                string txnTypeID;
                string txnDetailID;
                string txnAmount;
                string txnNotes;

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
                {
                    connection.Open();

                    invoiceNo = Invoice_No_TextBox.Text;
                    sellerID = SellerIdDropDownList.SelectedValue;
                    sellerGroupID = SellerGroupIdDropDownList.SelectedValue;
                    date = Purchase_DateTextBox.Text;
                    productGroupID = PurchaseProductGroupIDDropDownList.SelectedValue;
                    productID = PurchaseProductIDDropDownList.SelectedValue;
                    quantity = Purchase_Quantity_TextBox.Text;
                    quantityDot = quantity.Replace(",", ".");
                    unit = Purchase_Unit_TextBox.Text;
                    price = Unit_Price_TextBox.Text;
                    priceDot = price.Replace(",", ".");
                    stockZoneID = StockZoneIDDropDownList.SelectedValue;
                    originID = OriginIDDropDownList.SelectedValue;
                    weightBridgeCode = Weight_Brige_Code_TextBox.Text;
                    employeeID = EmployeeIDDropDownList.SelectedValue;
                    consultantID = ConsultantDropDownList.SelectedValue;
                    itemName = Item_Name_TextBox.Text;
                    note = Item_Note_TextBox.Text;

                    string vatID = VATDropDownList.SelectedValue; // We add Added DropDownList for VAT selection after the tbl_Purchase-add-taxId Branch and this is the bind of it

                    // First we add Item table
                    SqlCommand addItem = new SqlCommand($"insert into [tbl_item] (item_Name,[item_Quantitiy],[item_UnitPrice],[item_CreateDate],[item_UpdateDate],[stockZone_Id],[prod_Id],[origin_Id],[item_Note],[item_Consultant_Id]) " +
                        $"values ('{itemName}',{quantityDot}, {priceDot},'{date}' ,'{date}','{stockZoneID}','{productID}','{originID}','{note}','{consultantID}')", connection);
                    addItem.ExecuteNonQuery();

                    // Pulling the last ID for editing Purchase 
                    string lastItemID = $"SELECT [item_Id] FROM [tbl_item] WHERE [item_Id] = (SELECT MAX([item_Id]) FROM [tbl_item])";
                    SqlDataAdapter adpt = new SqlDataAdapter(lastItemID, connection);
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    itemID = dt2.Rows[0][0].ToString();

                    // Then add Purchase table

                    //SqlCommand addPurchase = new SqlCommand($"insert into [tbl_purchase] ([pur_Date],[item_Id],[pur_Sell_Id],[pur_Quantity],[pur_Weigh_Bridge_Code],[pur_Supervisor_Employee_Id],[pur_Unit_Price],[pur_Invoice_No],[pur_Consultant_Id]) " +
                    //    $"values ('{date}' ,'{itemID}','{sellerID}',{quantityDot},'{weightBridgeCode}','{employeeID}',{priceDot}, '{invoiceNo}','{consultantID}')", connection);

                                                    // We add VAT_Id to Purchase Table
                    SqlCommand addPurchase = new SqlCommand($"insert into [tbl_purchase] ([pur_Date],[item_Id],[pur_Sell_Id],[pur_Quantity],[pur_Weigh_Bridge_Code],[pur_Supervisor_Employee_Id],[pur_Unit_Price],[pur_Invoice_No],[pur_Consultant_Id],[pur_VAT_Id]) " +
                    $"values ('{date}' ,'{itemID}','{sellerID}',{quantityDot},'{weightBridgeCode}','{employeeID}',{priceDot}, '{invoiceNo}','{consultantID}', '{vatID}')", connection);

                    addPurchase.ExecuteNonQuery();

                    // We START to add this purchase to Transaction Table.
                    string pullAcctID = $"SELECT [acct_ID] FROM [tbl_seller] WHERE [sell_Id] ='{sellerID}' ";
                    SqlDataAdapter adpt4 = new SqlDataAdapter(pullAcctID, connection);
                    DataTable dt4 = new DataTable();
                    adpt4.Fill(dt4);
                    acctID = dt4.Rows[0][0].ToString();

                    txnTypeID = "1"; // Purchase Invoice;

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

                    txnDate = date;
                    string txnNull = "0";
                    txnNotes = note;

                    string purID;
                    string lastPurID = $"SELECT [pur_Id] FROM [tbl_purchase] WHERE [pur_Id] = (SELECT MAX([pur_Id]) FROM [tbl_purchase])";
                    SqlDataAdapter adpt6 = new SqlDataAdapter(lastPurID, connection);
                    DataTable dt6 = new DataTable();
                    adpt6.Fill(dt6);
                    purID = dt6.Rows[0][0].ToString();

                    string totalTxnPur = $"execute prc_totalTxnPurchase '{purID}' ";
                    SqlDataAdapter adpt7 = new SqlDataAdapter(totalTxnPur, connection);
                    DataTable dt7 = new DataTable();
                    adpt7.Fill(dt7);
                    txnAmount = dt7.Rows[0][0].ToString();

                    SqlCommand addTxn = new SqlCommand($"insert into [tbl_transactions] ([txn_Date],[acct_ID],[txn_Type_ID],[txn_Detail_ID],[consultant_ID],[txn_Debit],[txn_Credit],[txn_Notes] )" +
                        $"values ('{txnDate}',{acctID},{txnTypeID},{txnDetailID},{consultantID},@txnNull,@txnAmount,'{txnNotes}')", connection);
                    addTxn.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmount, CultureInfo.CurrentCulture);
                    addTxn.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
                    addTxn.ExecuteNonQuery();

                    string txnID;
                    string lastTxnID = $"SELECT [txn_Id] FROM [tbl_transactions] WHERE [txn_Id] = (SELECT MAX([txn_Id]) FROM [tbl_transactions])";
                    SqlDataAdapter adpt10 = new SqlDataAdapter(lastTxnID, connection);
                    DataTable dt10 = new DataTable();
                    adpt10.Fill(dt10);
                    txnID = dt10.Rows[0][0].ToString();

                    SqlCommand addTxnID = new SqlCommand($"update [tbl_purchase] set txn_Id='{txnID}'  where [pur_Id]= '{purID}' ", connection);
                    addTxnID.ExecuteNonQuery();
                }

                Response.Redirect("addPurchase-ERP.aspx");
            }
            else
            {
                string message = "Wrong Format or Missing Field You Can Not Add !!";
                string script = "if(confirm('" + message + "')){ window.location='addPurchase-ERP.aspx?'; }";
                ScriptManager.RegisterStartupScript(this, GetType(), "AddConfirmation", script, true);
            }
        }



        private void PurchaseGridViewBind()
        {
            DateTime dateMax = DateTime.Now;
            DateTime dateMin = dateMax.AddDays(-90);

            string dateMinText = dateMin.ToString("yyyy-MM-dd");
            string dateMaxText = dateMax.ToString("yyyy-MM-dd");


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listPurchase '{dateMaxText}', '{dateMinText}'", con))
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

        // This method is used to set the default VAT for the selected product in the PurchaseProductIDDropDownList.
        private void SetDefaultVATForProduct()
        {
            string productId = PurchaseProductIDDropDownList.SelectedValue;
            string connectionString = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            string query = "SELECT prod_VAT_Id FROM tbl_product WHERE prod_Id = @prodId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@prodId", productId);
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        VATDropDownList.SelectedValue = result.ToString();
                    }
                }
            }
        }

    }
}