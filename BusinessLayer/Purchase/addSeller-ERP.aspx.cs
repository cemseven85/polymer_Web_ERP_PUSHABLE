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

namespace polymer_Web_ERP_V4
{
    public partial class addSeller_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DropDownSellerGroupBind();
                SellerGridViewBind();
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
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("Select * from [tbl_sellerGroup]", connection))
                {
                    DataTable dt2 = new DataTable();
                    adapter.Fill(dt2);
                    SellerGroupIdDropDownList.DataSource = dt2;
                    SellerGroupIdDropDownList.DataTextField = "sell_Grp_Name";
                    SellerGroupIdDropDownList.DataValueField = "sell_Grp_Id";
                    SellerGroupIdDropDownList.DataBind();
                }
            }
        }


        private void SellerGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listSeller", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQuerySellerGridView.DataSource = dt;
                        jQuerySellerGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQuerySellerGridView.UseAccessibleHeader = true;
            jQuerySellerGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }




        //protected void AddButton_Click(object sender, EventArgs e)
        //{
        //    string sellerName;
        //    string sellerNameBG;
        //    string sellerNameTR;
        //    string sellerGroupID;
        //    string sellerAddress;
        //    string sellerContactName;
        //    string sellerContactNameBG;
        //    string sellerContactNameTR;
        //    string sellerTel;
        //    string sellerGSM;
        //    string sellerTaxId;
        //    string sellerTaxOffice;
        //    string sellerKeyAccount;
        //    string sellerNotes;


        //    sellerName = Seller_Name_TextBox.Text;
        //    sellerNameBG = Seller_Name_BG_TextBox.Text;
        //    sellerNameTR = Seller_Name_TR_TextBox.Text;
        //    sellerGroupID = SellerGroupIdDropDownList.SelectedValue;
        //    sellerAddress = Seller_Address_TextBox.Text;
        //    sellerContactName = Seller_Contact_Name_TextBox.Text;
        //    sellerContactNameBG = Seller_Contact_Name_BG_TextBox.Text;
        //    sellerContactNameTR = Seller_Contact_Name_TR_TextBox.Text;
        //    sellerTel = Seller_Tel_TextBox.Text;
        //    sellerGSM = Seller_GSM_TextBox.Text;
        //    sellerTaxId = Seller_Tax_Id_TextBox.Text;
        //    sellerTaxOffice = Seller_Tax_Office_TextBox.Text;
        //    sellerKeyAccount = Seller_Key_Account_TextBox.Text;
        //    sellerNotes = Seller_Note_TextBox.Text;



        //    // We can Create acct and pull the acctID and when we are creating the Seller enrolle the acctID.

        //    // Create new acct

        //    DateTime dateTxn = DateTime.Now;

        //    string acctCreateDate = dateTxn.ToString("yyyy-MM-dd");
        //    string acctType = "1"; // All seller account type is 1. 

        //    SqlCommand addNewAcount = new SqlCommand($"insert into [tbl_account] ([acct_Name],[acct_Create_Date],[acct_Type_ID],[acct_Notes]) values ('{sellerName}','{acctCreateDate}','{acctType}','{sellerNotes}') ", conn.Connection());
        //    addNewAcount.ExecuteNonQuery();

        //    // Pull the last accunt ID 



        //    string pullLastAcctID = $"SELECT [acct_ID] FROM [tbl_account]\r\n WHERE [acct_ID] = (\r\n SELECT MAX([acct_ID]) FROM [tbl_account])";
        //    SqlDataAdapter adpt20 = new SqlDataAdapter(pullLastAcctID, conn.Connection());
        //    DataTable dt20 = new DataTable();
        //    adpt20.Fill(dt20);
        //    string acctId = dt20.Rows[0][0].ToString();   // Last acct ID



        //    SqlCommand addNewSeller = new SqlCommand($"insert into [tbl_seller] ([sell_Name],[sell_Name_BG],[sell_Name_TR],[sell_Group_Id],[sell_Address],[sell_Contact_Name],[sell_Contact_Name_BG],[sell_Contact_Name_TR],[sell_Tel],[sell_GSM],[sell_Tax_Number],[sell_Tax_Office],[sell_Key_Account],[sell_Note], [acct_ID]) " +
        //        $"values ('{sellerName}',@bgName , '{sellerNameTR}','{sellerGroupID}' ,'{sellerAddress}','{sellerContactName}',@bgContactName,'{sellerContactNameTR}','{sellerTel}','{sellerGSM}','{sellerTaxId}','{sellerTaxOffice}','{sellerKeyAccount}', '{sellerNotes}','{acctId}')", conn.Connection());
        //    addNewSeller.Parameters.AddWithValue("@bgName", sellerNameBG);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
        //    addNewSeller.Parameters.AddWithValue("@bgContactName", sellerContactNameBG);
        //    addNewSeller.ExecuteNonQuery();


        //    //We need to add code for create a new account and use this new created acounts Id to add selleers acctID column.  

        //    Response.Redirect("addSeller-ERP.aspx");


        //}


        protected void AddButton_Click(object sender, EventArgs e)
        {
            string sellerName = Seller_Name_TextBox.Text;
            string sellerNameBG = Seller_Name_BG_TextBox.Text;
            string sellerNameTR = Seller_Name_TR_TextBox.Text;
            string sellerGroupID = SellerGroupIdDropDownList.SelectedValue;
            string sellerAddress = Seller_Address_TextBox.Text;
            string sellerContactName = Seller_Contact_Name_TextBox.Text;
            string sellerContactNameBG = Seller_Contact_Name_BG_TextBox.Text;
            string sellerContactNameTR = Seller_Contact_Name_TR_TextBox.Text;
            string sellerTel = Seller_Tel_TextBox.Text;
            string sellerGSM = Seller_GSM_TextBox.Text;
            string sellerTaxId = Seller_Tax_Id_TextBox.Text;
            string sellerTaxOffice = Seller_Tax_Office_TextBox.Text;
            string sellerKeyAccount = Seller_Key_Account_TextBox.Text;
            string sellerNotes = Seller_Note_TextBox.Text;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                connection.Open();

                // Create new account
                DateTime dateTxn = DateTime.Now;
                string acctCreateDate = dateTxn.ToString("yyyy-MM-dd");
                string acctType = "1"; // All seller account types are 1

                using (SqlCommand addNewAccount = new SqlCommand("INSERT INTO [tbl_account] ([acct_Name],[acct_Create_Date],[acct_Type_ID],[acct_Notes]) VALUES (@AcctName, @CreateDate, @TypeID, @Notes)", connection))
                {
                    addNewAccount.Parameters.AddWithValue("@AcctName", sellerName);
                    addNewAccount.Parameters.AddWithValue("@CreateDate", acctCreateDate);
                    addNewAccount.Parameters.AddWithValue("@TypeID", acctType);
                    addNewAccount.Parameters.AddWithValue("@Notes", sellerNotes);
                    addNewAccount.ExecuteNonQuery();
                }

                // Retrieve the last account ID
                string pullLastAcctID = "SELECT MAX([acct_ID]) FROM [tbl_account]";
                int acctId;
                using (SqlCommand getLastAcctID = new SqlCommand(pullLastAcctID, connection))
                {
                    acctId = (int)getLastAcctID.ExecuteScalar();
                }

                // Insert new seller record
                using (SqlCommand addNewSeller = new SqlCommand("INSERT INTO [tbl_seller] ([sell_Name],[sell_Name_BG],[sell_Name_TR],[sell_Group_Id],[sell_Address],[sell_Contact_Name],[sell_Contact_Name_BG],[sell_Contact_Name_TR],[sell_Tel],[sell_GSM],[sell_Tax_Number],[sell_Tax_Office],[sell_Key_Account],[sell_Note], [acct_ID]) " +
                    "VALUES (@Name, @NameBG, @NameTR, @GroupID, @Address, @ContactName, @ContactNameBG, @ContactNameTR, @Tel, @GSM, @TaxId, @TaxOffice, @KeyAccount, @Notes, @AcctID)", connection))
                {
                    addNewSeller.Parameters.AddWithValue("@Name", sellerName);
                    addNewSeller.Parameters.AddWithValue("@NameBG", sellerNameBG);
                    addNewSeller.Parameters.AddWithValue("@NameTR", sellerNameTR);
                    addNewSeller.Parameters.AddWithValue("@GroupID", sellerGroupID);
                    addNewSeller.Parameters.AddWithValue("@Address", sellerAddress);
                    addNewSeller.Parameters.AddWithValue("@ContactName", sellerContactName);
                    addNewSeller.Parameters.AddWithValue("@ContactNameBG", sellerContactNameBG);
                    addNewSeller.Parameters.AddWithValue("@ContactNameTR", sellerContactNameTR);
                    addNewSeller.Parameters.AddWithValue("@Tel", sellerTel);
                    addNewSeller.Parameters.AddWithValue("@GSM", sellerGSM);
                    addNewSeller.Parameters.AddWithValue("@TaxId", sellerTaxId);
                    addNewSeller.Parameters.AddWithValue("@TaxOffice", sellerTaxOffice);
                    addNewSeller.Parameters.AddWithValue("@KeyAccount", sellerKeyAccount);
                    addNewSeller.Parameters.AddWithValue("@Notes", sellerNotes);
                    addNewSeller.Parameters.AddWithValue("@AcctID", acctId);
                    addNewSeller.ExecuteNonQuery();
                }
            }

            Response.Redirect("addSeller-ERP.aspx");
        }

    }
}