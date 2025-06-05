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
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace polymer_Web_ERP_V4
{
    public partial class addCustomer_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DropDownCustomerGroupBind();
                CustomerGridViewBind();
            }
        }

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



        private void DropDownCustomerGroupBind()
        {
            string com = "SELECT * FROM [tbl_customerGroup]";
            DataTable dt2 = new DataTable();

            using (SqlConnection connection = conn.Connection())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(com, connection))
                {
                    adapter.Fill(dt2);
                }
            }

            CustomerGroupIdDropDownList.DataSource = dt2;
            CustomerGroupIdDropDownList.DataTextField = "cust_Grp_Name";
            CustomerGroupIdDropDownList.DataValueField = "cust_Grp_Id";
            CustomerGroupIdDropDownList.DataBind();
        }



        private void CustomerGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listCustomer", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryCustomerGridView.DataSource = dt;
                        jQueryCustomerGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryCustomerGridView.UseAccessibleHeader = true;
            jQueryCustomerGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }




        //protected void AddButton_Click(object sender, EventArgs e)
        //{
        //    string customerName;
        //    string customerNameBG;
        //    string customerNameTR;
        //    string customerGroupID;
        //    string customerAddress;
        //    string customerContactName;
        //    string customerContactNameBG;
        //    string customerContactNameTR;
        //    string customerTel;
        //    string customerGSM;
        //    string customerTaxId;
        //    string customerTaxOffice;
        //    string customerKeyAccount;
        //    string customerNotes;


        //    customerName = Customer_Name_TextBox.Text;
        //    customerNameBG = Customer_Name_BG_TextBox.Text;
        //    customerNameTR = Customer_Name_TR_TextBox.Text;
        //    customerGroupID = CustomerGroupIdDropDownList.SelectedValue;
        //    customerAddress = Customer_Address_TextBox.Text;
        //    customerContactName = Customer_Contact_Name_TextBox.Text;
        //    customerContactNameBG = Customer_Contact_Name_BG_TextBox.Text;
        //    customerContactNameTR = Customer_Contact_Name_TR_TextBox.Text;
        //    customerTel = Customer_Tel_TextBox.Text;
        //    customerGSM = Customer_GSM_TextBox.Text;
        //    customerTaxId = Customer_Tax_Id_TextBox.Text;
        //    customerTaxOffice = Customer_Tax_Office_TextBox.Text;
        //    customerKeyAccount = Customer_Key_Account_TextBox.Text;
        //    customerNotes = Customer_Note_TextBox.Text;

        //    // We can Create acct and pull the acctID and when we are creating the Customer enrolle the acctID. 

        //    // Create new acct

        //    DateTime dateTxn = DateTime.Now;

        //    string acctCreateDate = dateTxn.ToString("yyyy-MM-dd");
        //    string acctType = "2"; // All customers account type is 2. 

        //    SqlCommand addNewAcount =new SqlCommand ($"insert into [tbl_account] ([acct_Name],[acct_Create_Date],[acct_Type_ID],[acct_Notes]) values ('{customerName}','{acctCreateDate}','{acctType}','{customerNotes}') ", conn.Connection());
        //    addNewAcount.ExecuteNonQuery();

        //    // Pull the last accunt ID 



        //    string pullLastAcctID = $"SELECT [acct_ID] FROM [tbl_account]\r\n WHERE [acct_ID] = (\r\n SELECT MAX([acct_ID]) FROM [tbl_account])";
        //    SqlDataAdapter adpt20 = new SqlDataAdapter(pullLastAcctID, conn.Connection());
        //    DataTable dt20 = new DataTable();
        //    adpt20.Fill(dt20);
        //    string acctId = dt20.Rows[0][0].ToString();   // Last acct ID


        //    SqlCommand addNewCustomer = new SqlCommand($"insert into [tbl_customer] ([cust_Name],[cust_Name_BG],[cust_Name_TR],[cust_Group_Id],[cust_Adress],[cust_Contact_Name],[cust_Contact_Name_BG],[cust_Contact_Name_TR],[cust_Tel],[cust_GSM],[cust_Tax_Number],[cust_Tax_Office],[cust_Key_Account],[cust_Note], [acct_ID]) " +
        //        $"values ('{customerName}',@bgName , '{customerNameTR}','{customerGroupID}' ,'{customerAddress}','{customerContactName}',@bgContactName,'{customerContactNameTR}','{customerTel}','{customerGSM}','{customerTaxId}','{customerTaxOffice}','{customerKeyAccount}', '{customerNotes}','{acctId}')", conn.Connection());
        //    addNewCustomer.Parameters.AddWithValue("@bgName", customerNameBG);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
        //    addNewCustomer.Parameters.AddWithValue("@bgContactName", customerContactNameBG);
        //    addNewCustomer.ExecuteNonQuery();







        //    Response.Redirect("addCustomer-ERP.aspx");


        //}


        protected void AddButton_Click(object sender, EventArgs e)
        {
            string customerName = Customer_Name_TextBox.Text;
            string customerNameBG = Customer_Name_BG_TextBox.Text;
            string customerNameTR = Customer_Name_TR_TextBox.Text;
            string customerGroupID = CustomerGroupIdDropDownList.SelectedValue;
            string customerAddress = Customer_Address_TextBox.Text;
            string customerContactName = Customer_Contact_Name_TextBox.Text;
            string customerContactNameBG = Customer_Contact_Name_BG_TextBox.Text;
            string customerContactNameTR = Customer_Contact_Name_TR_TextBox.Text;
            string customerTel = Customer_Tel_TextBox.Text;
            string customerGSM = Customer_GSM_TextBox.Text;
            string customerTaxId = Customer_Tax_Id_TextBox.Text;
            string customerTaxOffice = Customer_Tax_Office_TextBox.Text;
            string customerKeyAccount = Customer_Key_Account_TextBox.Text;
            string customerNotes = Customer_Note_TextBox.Text;

            using (SqlConnection connection = conn.Connection())
            {
                

                // Create new account
                DateTime dateTxn = DateTime.Now;
                string acctCreateDate = dateTxn.ToString("yyyy-MM-dd");
                string acctType = "2"; // All customers account type is 2.

                using (SqlCommand addNewAccount = new SqlCommand($"INSERT INTO [tbl_account] ([acct_Name],[acct_Create_Date],[acct_Type_ID],[acct_Notes]) VALUES ('{customerName}','{acctCreateDate}','{acctType}','{customerNotes}')", connection))
                {
                    addNewAccount.ExecuteNonQuery();
                }

                // Pull the last account ID
                string pullLastAcctID = "SELECT TOP 1 [acct_ID] FROM [tbl_account] ORDER BY [acct_ID] DESC";
                using (SqlDataAdapter adpt20 = new SqlDataAdapter(pullLastAcctID, connection))
                {
                    DataTable dt20 = new DataTable();
                    adpt20.Fill(dt20);
                    string acctId = dt20.Rows[0][0].ToString(); // Last account ID

                    using (SqlCommand addNewCustomer = new SqlCommand($"INSERT INTO [tbl_customer] ([cust_Name],[cust_Name_BG],[cust_Name_TR],[cust_Group_Id],[cust_Adress],[cust_Contact_Name],[cust_Contact_Name_BG],[cust_Contact_Name_TR],[cust_Tel],[cust_GSM],[cust_Tax_Number],[cust_Tax_Office],[cust_Key_Account],[cust_Note],[acct_ID]) " +
                        $"VALUES ('{customerName}',@bgName,'{customerNameTR}','{customerGroupID}','{customerAddress}','{customerContactName}',@bgContactName,'{customerContactNameTR}','{customerTel}','{customerGSM}','{customerTaxId}','{customerTaxOffice}','{customerKeyAccount}','{customerNotes}','{acctId}')", connection))
                    {
                        addNewCustomer.Parameters.AddWithValue("@bgName", customerNameBG);
                        addNewCustomer.Parameters.AddWithValue("@bgContactName", customerContactNameBG);
                        addNewCustomer.ExecuteNonQuery();
                    }
                }
            }

            Response.Redirect("addCustomer-ERP.aspx");
        }

    }
}