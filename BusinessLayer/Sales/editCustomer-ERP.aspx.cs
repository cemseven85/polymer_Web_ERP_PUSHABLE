using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using polymer_Web_ERP_V4.Data_Access_Layer;
using static System.Net.Mime.MediaTypeNames;

namespace polymer_Web_ERP_V4
{
    public partial class editCustomer_ERP : System.Web.UI.Page
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


        protected void jQueryCustomerGridView_PreRender(object sender, EventArgs e)
        {
            this.CustomerGridViewBind();

            if (jQueryCustomerGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryCustomerGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryCustomerGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryCustomerGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        //protected void jQueryCustomerGridView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryCustomerGridView.SelectedRow;

        //    Customer_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
        //    Customer_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
        //    Customer_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);

        //    // CustomerGroup_Name to CustomerGroup_ID
        //    string customerGroupName = row.Cells[5].Text;
        //    string com = $"select [cust_Grp_Id] from [tbl_customerGroup] where [cust_Grp_Name]='{customerGroupName}'";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    string rid = dt2.Rows[0][0].ToString();
        //    CustomerGroupIdDropDownList.SelectedValue = rid;

        //    Customer_Address_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 6);
        //    Customer_Contact_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 7);
        //    Customer_Contact_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 8);
        //    Customer_Contact_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);
        //    Customer_Tel_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 10);
        //    Customer_GSM_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);
        //    Customer_Tax_Id_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 12);
        //    Customer_Tax_Office_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 13);
        //    Customer_Key_Account_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 14);
        //    Customer_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 15);
        //}


        protected void jQueryCustomerGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = jQueryCustomerGridView.SelectedRow;

            Customer_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
            Customer_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
            Customer_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);

            // CustomerGroup_Name to CustomerGroup_ID
            string customerGroupName = row.Cells[5].Text;
            string com = $"select [cust_Grp_Id] from [tbl_customerGroup] where [cust_Grp_Name]=@CustomerGroupName";
            using (SqlConnection connection = conn.Connection())
            {
                using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                {
                    adpt.SelectCommand.Parameters.AddWithValue("@CustomerGroupName", customerGroupName);
                    DataTable dt2 = new DataTable();
                    adpt.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        string rid = dt2.Rows[0][0].ToString();
                        CustomerGroupIdDropDownList.SelectedValue = rid;
                    }
                }
            }

            Customer_Address_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 6);
            Customer_Contact_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 7);
            Customer_Contact_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 8);
            Customer_Contact_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);
            Customer_Tel_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 10);
            Customer_GSM_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);
            Customer_Tax_Id_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 12);
            Customer_Tax_Office_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 13);
            Customer_Key_Account_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 14);
            Customer_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 15);
        }


        //protected void EditButton_Click(object sender, EventArgs e)
        //{
        //    string customerID;

        //    GridViewRow row = jQueryCustomerGridView.SelectedRow;

        //    if (row != null) { 

        //    customerID = row.Cells[1].Text;
        //    string customerName = Customer_Name_TextBox.Text;
        //    string customerName_BG = Customer_Name_BG_TextBox.Text;
        //    string customerName_TR = Customer_Name_TR_TextBox.Text;
        //    string customerGroupId = CustomerGroupIdDropDownList.SelectedValue;
        //    string customerAddress = Customer_Address_TextBox.Text;
        //    string customerContactName = Customer_Contact_Name_TextBox.Text;
        //    string customerContactNameBG = Customer_Contact_Name_BG_TextBox.Text;
        //    string customerContactNameTR = Customer_Contact_Name_TR_TextBox.Text;
        //    string customerTell = Customer_Tel_TextBox.Text;
        //    string customerGSM = Customer_GSM_TextBox.Text;
        //    string customerTaxId = Customer_Tax_Id_TextBox.Text;
        //    string customerTaxOffice = Customer_Tax_Office_TextBox.Text;
        //    string customerKeyAccount = Customer_Key_Account_TextBox.Text;
        //    string customerNote = Customer_Note_TextBox.Text;

        //    SqlCommand editCustomer = new SqlCommand($"update [tbl_customer] set [cust_Name]='{customerName}' , [cust_Name_BG]=@bgName, [cust_Name_TR]='{customerName_TR}',[cust_Group_Id]='{customerGroupId}'" +
        //        $",[cust_Adress]='{customerAddress}',[cust_Contact_Name]='{customerContactName}',[cust_Contact_Name_BG]=@bgNameContact,[cust_Contact_Name_TR]='{customerContactNameTR}'" +
        //        $",[cust_Tel]='{customerTell}',[cust_GSM]='{customerGSM}',[cust_Tax_Number]='{customerTaxId}',[cust_Tax_Office]='{customerTaxOffice}',[cust_Key_Account]='{customerKeyAccount}', [cust_Note]='{customerNote}'" +
        //        $" where [cust_Id] = '{customerID}'", conn.Connection());
        //    editCustomer.Parameters.AddWithValue("@bgName", customerName_BG);
        //    editCustomer.Parameters.AddWithValue("@bgNameContact", customerContactNameBG);
        //    editCustomer.ExecuteNonQuery();


        //        string acctID;  // pull from tbl_account by using CustomerLabel.Text
        //        string acctName = customerName;
        //        // First find AcctId of this customer
        //        string pullAcctID = $"SELECT [acct_ID] FROM [tbl_customer]\r\nWHERE [cust_Id] ='{customerID}' ";
        //        SqlDataAdapter adpt20 = new SqlDataAdapter(pullAcctID, conn.Connection());
        //        DataTable dt20 = new DataTable();
        //        adpt20.Fill(dt20);
        //        acctID = dt20.Rows[0][0].ToString();


        //        SqlCommand editAccount = new SqlCommand($"update [tbl_account] set [acct_Name]='{acctName}',[acct_Notes]='{customerNote}' WHERE [acct_ID]='{acctID}'", conn.Connection());
        //        editAccount.ExecuteNonQuery();


        //        Response.Redirect("editCustomer-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Customer for Edit');</script>");
        //    }

        //}



        protected void EditButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryCustomerGridView.SelectedRow;

            if (row != null)
            {
                string customerID = row.Cells[1].Text;
                string customerName = Customer_Name_TextBox.Text;
                string customerName_BG = Customer_Name_BG_TextBox.Text;
                string customerName_TR = Customer_Name_TR_TextBox.Text;
                string customerGroupId = CustomerGroupIdDropDownList.SelectedValue;
                string customerAddress = Customer_Address_TextBox.Text;
                string customerContactName = Customer_Contact_Name_TextBox.Text;
                string customerContactNameBG = Customer_Contact_Name_BG_TextBox.Text;
                string customerContactNameTR = Customer_Contact_Name_TR_TextBox.Text;
                string customerTell = Customer_Tel_TextBox.Text;
                string customerGSM = Customer_GSM_TextBox.Text;
                string customerTaxId = Customer_Tax_Id_TextBox.Text;
                string customerTaxOffice = Customer_Tax_Office_TextBox.Text;
                string customerKeyAccount = Customer_Key_Account_TextBox.Text;
                string customerNote = Customer_Note_TextBox.Text;

                using (SqlConnection connection = conn.Connection())
                {
                    // Update customer details
                    using (SqlCommand editCustomer = new SqlCommand($"UPDATE [tbl_customer] SET [cust_Name]=@customerName, [cust_Name_BG]=@bgName, [cust_Name_TR]=@customerNameTR, [cust_Group_Id]=@customerGroupId," +
                        $"[cust_Adress]=@customerAddress, [cust_Contact_Name]=@customerContactName, [cust_Contact_Name_BG]=@bgNameContact, [cust_Contact_Name_TR]=@customerContactNameTR," +
                        $"[cust_Tel]=@customerTell, [cust_GSM]=@customerGSM, [cust_Tax_Number]=@customerTaxId, [cust_Tax_Office]=@customerTaxOffice, [cust_Key_Account]=@customerKeyAccount, [cust_Note]=@customerNote" +
                        $" WHERE [cust_Id]=@customerID", connection))
                    {
                        editCustomer.Parameters.AddWithValue("@customerName", customerName);
                        editCustomer.Parameters.AddWithValue("@bgName", customerName_BG);
                        editCustomer.Parameters.AddWithValue("@customerNameTR", customerName_TR);
                        editCustomer.Parameters.AddWithValue("@customerGroupId", customerGroupId);
                        editCustomer.Parameters.AddWithValue("@customerAddress", customerAddress);
                        editCustomer.Parameters.AddWithValue("@customerContactName", customerContactName);
                        editCustomer.Parameters.AddWithValue("@bgNameContact", customerContactNameBG);
                        editCustomer.Parameters.AddWithValue("@customerContactNameTR", customerContactNameTR);
                        editCustomer.Parameters.AddWithValue("@customerTell", customerTell);
                        editCustomer.Parameters.AddWithValue("@customerGSM", customerGSM);
                        editCustomer.Parameters.AddWithValue("@customerTaxId", customerTaxId);
                        editCustomer.Parameters.AddWithValue("@customerTaxOffice", customerTaxOffice);
                        editCustomer.Parameters.AddWithValue("@customerKeyAccount", customerKeyAccount);
                        editCustomer.Parameters.AddWithValue("@customerNote", customerNote);
                        editCustomer.Parameters.AddWithValue("@customerID", customerID);
                        editCustomer.ExecuteNonQuery();
                    }

                    // Update account details
                    using (SqlCommand editAccount = new SqlCommand($"UPDATE [tbl_account] SET [acct_Name]=@acctName, [acct_Notes]=@customerNote WHERE [acct_ID]=@acctID", connection))
                    {
                        editAccount.Parameters.AddWithValue("@acctName", customerName);
                        editAccount.Parameters.AddWithValue("@customerNote", customerNote);
                        editAccount.Parameters.AddWithValue("@acctID", customerID);
                        editAccount.ExecuteNonQuery();
                    }
                }

                Response.Redirect("editCustomer-ERP.aspx");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('You need to select Customer for Edit');</script>");
            }
        }

    }
}