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
    public partial class editSeller_ERP : System.Web.UI.Page
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
            using (SqlConnection connection = conn.Connection())
            {
                string query = "SELECT * FROM [tbl_sellerGroup]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                SellerGroupIdDropDownList.DataSource = dt;
                SellerGroupIdDropDownList.DataTextField = "sell_Grp_Name";
                SellerGroupIdDropDownList.DataValueField = "sell_Grp_Id";
                SellerGroupIdDropDownList.DataBind();
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


        protected void jQuerySellerGridView_PreRender(object sender, EventArgs e)
        {
            this.SellerGridViewBind();

            if (jQuerySellerGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQuerySellerGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQuerySellerGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQuerySellerGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        //protected void jQuerySellerGridView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQuerySellerGridView.SelectedRow;

        //    Seller_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
        //    Seller_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
        //    Seller_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);

        //    // SellerGroup_Name to SellerGroup_ID
        //    string sellerGroupName = row.Cells[5].Text;
        //    string com = $"select [sell_Grp_Id] from [tbl_sellerGroup] where [sell_Grp_Name]='{sellerGroupName}'";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    string rid = dt2.Rows[0][0].ToString();
        //    SellerGroupIdDropDownList.SelectedValue = rid;

        //    Seller_Address_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 6);
        //    Seller_Contact_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 7);
        //    Seller_Contact_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 8);
        //    Seller_Contact_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);
        //    Seller_Tel_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 10);
        //    Seller_GSM_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);
        //    Seller_Tax_Id_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 12);
        //    Seller_Tax_Office_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 13);
        //    Seller_Key_Account_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 14);
        //    Seller_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 15);
        //}

        protected void jQuerySellerGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = jQuerySellerGridView.SelectedRow;

            Seller_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
            Seller_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
            Seller_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);

            // SellerGroup_Name to SellerGroup_ID
            string sellerGroupName = row.Cells[5].Text;
            string query = $"SELECT [sell_Grp_Id] FROM [tbl_sellerGroup] WHERE [sell_Grp_Name]=@sellerGroupName";

            using (SqlConnection connection = conn.Connection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sellerGroupName", sellerGroupName);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string rid = dt.Rows[0][0].ToString();
                        SellerGroupIdDropDownList.SelectedValue = rid;
                    }
                }
            }

            Seller_Address_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 6);
            Seller_Contact_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 7);
            Seller_Contact_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 8);
            Seller_Contact_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);
            Seller_Tel_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 10);
            Seller_GSM_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);
            Seller_Tax_Id_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 12);
            Seller_Tax_Office_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 13);
            Seller_Key_Account_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 14);
            Seller_Note_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 15);
        }


        //protected void EditButton_Click(object sender, EventArgs e)
        //{
        //    string sellerID;
        //    GridViewRow row = jQuerySellerGridView.SelectedRow;

        //    if (row != null)
        //    {


        //        sellerID = row.Cells[1].Text;
        //        string sellerName = Seller_Name_TextBox.Text;
        //        string sellerName_BG = Seller_Name_BG_TextBox.Text;
        //        string sellerName_TR = Seller_Name_TR_TextBox.Text;
        //        string sellerGroupId = SellerGroupIdDropDownList.SelectedValue;
        //        string sellerAddress = Seller_Address_TextBox.Text;
        //        string sellerContactName = Seller_Contact_Name_TextBox.Text;
        //        string sellerContactNameBG = Seller_Contact_Name_BG_TextBox.Text;
        //        string sellerContactNameTR = Seller_Contact_Name_TR_TextBox.Text;
        //        string sellerTell = Seller_Tel_TextBox.Text;
        //        string sellerGSM = Seller_GSM_TextBox.Text;
        //        string sellerTaxId = Seller_Tax_Id_TextBox.Text;
        //        string sellerTaxOffice = Seller_Tax_Office_TextBox.Text;
        //        string sellerKeyAccount = Seller_Key_Account_TextBox.Text;
        //        string sellerNote = Seller_Note_TextBox.Text;

        //        SqlCommand editSeller = new SqlCommand($"update [tbl_seller] set [sell_Name]='{sellerName}' , [sell_Name_BG]=@bgName, [sell_Name_TR]='{sellerName_TR}',[sell_Group_Id]='{sellerGroupId}'" +
        //            $",[sell_Address]='{sellerAddress}',[sell_Contact_Name]='{sellerContactName}',[sell_Contact_Name_BG]=@bgNameContact,[sell_Contact_Name_TR]='{sellerContactNameTR}'" +
        //            $",[sell_Tel]='{sellerTell}',[sell_GSM]='{sellerGSM}',[sell_Tax_Number]='{sellerTaxId}',[sell_Tax_Office]='{sellerTaxOffice}',[sell_Key_Account]='{sellerKeyAccount}', [sell_Note]='{sellerNote}'" +
        //            $" where [sell_Id] = '{sellerID}'", conn.Connection());
        //        editSeller.Parameters.AddWithValue("@bgName", sellerName_BG);
        //        editSeller.Parameters.AddWithValue("@bgNameContact", sellerContactNameBG);
        //        editSeller.ExecuteNonQuery();




        //        string acctID;  // pull from tbl_account
        //        string acctName = sellerName;
        //        // First find AcctId of this customer
        //        string pullAcctID = $"SELECT [acct_ID] FROM [tbl_seller]\r\nWHERE [sell_Id] ='{sellerID}' ";
        //        SqlDataAdapter adpt20 = new SqlDataAdapter(pullAcctID, conn.Connection());
        //        DataTable dt20 = new DataTable();
        //        adpt20.Fill(dt20);
        //        acctID = dt20.Rows[0][0].ToString();


        //        SqlCommand editAccount = new SqlCommand($"update [tbl_account] set [acct_Name]='{acctName}',[acct_Notes]='{sellerNote}' WHERE [acct_ID]='{acctID}'", conn.Connection());
        //        editAccount.ExecuteNonQuery();



        //        Response.Redirect("editSeller-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Seller for Edit');</script>");
        //    }

        //}

        protected void EditButton_Click(object sender, EventArgs e)
        {
            string sellerID;
            GridViewRow row = jQuerySellerGridView.SelectedRow;

            if (row != null)
            {
                sellerID = row.Cells[1].Text;
                string sellerName = Seller_Name_TextBox.Text;
                string sellerName_BG = Seller_Name_BG_TextBox.Text;
                string sellerName_TR = Seller_Name_TR_TextBox.Text;
                string sellerGroupId = SellerGroupIdDropDownList.SelectedValue;
                string sellerAddress = Seller_Address_TextBox.Text;
                string sellerContactName = Seller_Contact_Name_TextBox.Text;
                string sellerContactNameBG = Seller_Contact_Name_BG_TextBox.Text;
                string sellerContactNameTR = Seller_Contact_Name_TR_TextBox.Text;
                string sellerTell = Seller_Tel_TextBox.Text;
                string sellerGSM = Seller_GSM_TextBox.Text;
                string sellerTaxId = Seller_Tax_Id_TextBox.Text;
                string sellerTaxOffice = Seller_Tax_Office_TextBox.Text;
                string sellerKeyAccount = Seller_Key_Account_TextBox.Text;
                string sellerNote = Seller_Note_TextBox.Text;

                using (SqlConnection connection = conn.Connection())
                {
                    // Update Seller
                    string querySeller = @"UPDATE [tbl_seller] SET [sell_Name]=@sellerName, [sell_Name_BG]=@bgName, [sell_Name_TR]=@sellerName_TR, [sell_Group_Id]=@sellerGroupId,
                [sell_Address]=@sellerAddress, [sell_Contact_Name]=@sellerContactName, [sell_Contact_Name_BG]=@bgNameContact, [sell_Contact_Name_TR]=@sellerContactNameTR,
                [sell_Tel]=@sellerTell, [sell_GSM]=@sellerGSM, [sell_Tax_Number]=@sellerTaxId, [sell_Tax_Office]=@sellerTaxOffice, [sell_Key_Account]=@sellerKeyAccount,
                [sell_Note]=@sellerNote WHERE [sell_Id]=@sellerID";

                    using (SqlCommand editSeller = new SqlCommand(querySeller, connection))
                    {
                        editSeller.Parameters.AddWithValue("@sellerName", sellerName);
                        editSeller.Parameters.AddWithValue("@bgName", sellerName_BG);
                        editSeller.Parameters.AddWithValue("@sellerName_TR", sellerName_TR);
                        editSeller.Parameters.AddWithValue("@sellerGroupId", sellerGroupId);
                        editSeller.Parameters.AddWithValue("@sellerAddress", sellerAddress);
                        editSeller.Parameters.AddWithValue("@sellerContactName", sellerContactName);
                        editSeller.Parameters.AddWithValue("@bgNameContact", sellerContactNameBG);
                        editSeller.Parameters.AddWithValue("@sellerContactNameTR", sellerContactNameTR);
                        editSeller.Parameters.AddWithValue("@sellerTell", sellerTell);
                        editSeller.Parameters.AddWithValue("@sellerGSM", sellerGSM);
                        editSeller.Parameters.AddWithValue("@sellerTaxId", sellerTaxId);
                        editSeller.Parameters.AddWithValue("@sellerTaxOffice", sellerTaxOffice);
                        editSeller.Parameters.AddWithValue("@sellerKeyAccount", sellerKeyAccount);
                        editSeller.Parameters.AddWithValue("@sellerNote", sellerNote);
                        editSeller.Parameters.AddWithValue("@sellerID", sellerID);

                        editSeller.ExecuteNonQuery();
                    }


                    string acctID;  // pull from tbl_account
                    string acctName = sellerName;

                    // First find AcctId of this customer
                    string pullAcctID = $"SELECT [acct_ID] FROM [tbl_seller] WHERE [sell_Id] = '{sellerID}'";



                    using (SqlDataAdapter adpt20 = new SqlDataAdapter(pullAcctID, connection))
                    {
                        DataTable dt20 = new DataTable();
                        adpt20.Fill(dt20);
                        acctID = dt20.Rows[0][0].ToString();
                    }






                    // Update Account
                    string queryAccount = "UPDATE [tbl_account] SET [acct_Name]=@acctName, [acct_Notes]=@sellerNote WHERE [acct_ID]=@acctID";

                    using (SqlCommand editAccount = new SqlCommand(queryAccount, connection))
                    {
                        editAccount.Parameters.AddWithValue("@acctName", sellerName);
                        editAccount.Parameters.AddWithValue("@sellerNote", sellerNote);
                        editAccount.Parameters.AddWithValue("@acctID", acctID);

                        editAccount.ExecuteNonQuery();
                    }
                }

                Response.Redirect("editSeller-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Seller for Edit');</script>");
            }
        }

    }
}