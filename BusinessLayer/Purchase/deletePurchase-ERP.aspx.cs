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

namespace polymer_Web_ERP_V4
{
    public partial class deletPurchase_ERP : System.Web.UI.Page
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

                PurchaseGridViewBind();
            }
        }


        private void PurchaseGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
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

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryPurchaseGridView.SelectedRow;

        //    if (row != null)
        //    {
        //        string rid = row.Cells[20].Text;


        //        // First we need the txnID for TXN DELETE that from this purchase. 


        //        string itemID = row.Cells[20].Text;
        //        string purID;  // Need to pull purID  for the TxnId



        //        string pullpurID = $"SELECT [pur_Id] FROM [tbl_purchase] WHERE [item_Id] = '{itemID}'";
        //        SqlDataAdapter adpt9 = new SqlDataAdapter(pullpurID, conn.Connection());
        //        DataTable dt9 = new DataTable();
        //        adpt9.Fill(dt9);
        //        purID = dt9.Rows[0][0].ToString();



        //        string pullTxnID = $"SELECT [txn_Id] FROM [tbl_purchase] WHERE [pur_Id] = '{purID}'";
        //        SqlDataAdapter adpt10 = new SqlDataAdapter(pullTxnID, conn.Connection());
        //        DataTable dt10 = new DataTable();
        //        adpt10.Fill(dt10);
        //        string txnID = dt10.Rows[0][0].ToString();


        //        //DELETE PURCHASE

        //        SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_purchase] WHERE [item_Id] = '{rid}'", conn.Connection());
        //        cmd.ExecuteNonQuery();

        //        //DELETE ITEM

        //        SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_item] WHERE [item_Id] = '{rid}'", conn.Connection());
        //        cmd2.ExecuteNonQuery();


        //        //DELETE TXN

        //        SqlCommand cmd3 = new SqlCommand($"DELETE FROM [tbl_transactions] where [txn_ID]='{txnID}'", conn.Connection());
        //        cmd3.ExecuteNonQuery();

        //        Response.Redirect("deletePurchase-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Purchase for DELETE');</script>");
        //    }
        //}



        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = conn.Connection())
            {
                GridViewRow row = jQueryPurchaseGridView.SelectedRow;

                if (row != null)
                {
                    string itemID = row.Cells[20].Text;
                    string purID;
                    string txnID;

                    // First, get the purID for the given itemID
                    string pullpurID = $"SELECT [pur_Id] FROM [tbl_purchase] WHERE [item_Id] = @ItemID";
                    using (SqlCommand cmdPullpurID = new SqlCommand(pullpurID, connection))
                    {
                        cmdPullpurID.Parameters.AddWithValue("@ItemID", itemID);
                        
                        purID = cmdPullpurID.ExecuteScalar()?.ToString();
                    }

                    // Next, get the txnID associated with the purID
                    string pullTxnID = $"SELECT [txn_Id] FROM [tbl_purchase] WHERE [pur_Id] = @PurID";
                    using (SqlCommand cmdPullTxnID = new SqlCommand(pullTxnID, connection))
                    {
                        cmdPullTxnID.Parameters.AddWithValue("@PurID", purID);
                        txnID = cmdPullTxnID.ExecuteScalar()?.ToString();
                    }

                    // Now delete the purchase
                    string deletePurchaseQuery = "DELETE FROM [tbl_purchase] WHERE [item_Id] = @ItemID";
                    using (SqlCommand deletePurchaseCmd = new SqlCommand(deletePurchaseQuery, connection))
                    {
                        deletePurchaseCmd.Parameters.AddWithValue("@ItemID", itemID);
                        deletePurchaseCmd.ExecuteNonQuery();
                    }

                    // Next, delete the item
                    string deleteItemQuery = "DELETE FROM [tbl_item] WHERE [item_Id] = @ItemID";
                    using (SqlCommand deleteItemCmd = new SqlCommand(deleteItemQuery, connection))
                    {
                        deleteItemCmd.Parameters.AddWithValue("@ItemID", itemID);
                        deleteItemCmd.ExecuteNonQuery();
                    }

                    // Finally, delete the transaction
                    string deleteTxnQuery = "DELETE FROM [tbl_transactions] WHERE [txn_ID] = @TxnID";
                    using (SqlCommand deleteTxnCmd = new SqlCommand(deleteTxnQuery, connection))
                    {
                        deleteTxnCmd.Parameters.AddWithValue("@TxnID", txnID);
                        deleteTxnCmd.ExecuteNonQuery();
                    }

                    Response.Redirect("deletePurchase-ERP.aspx");
                }
                else
                {
                    Response.Write("<script>alert('You need to select a purchase for deletion.');</script>");
                }
            }
        }



        protected void ShowReportButton_Click(object sender, EventArgs e)
        {
            PurchaseGridViewBind();
        }
    }
}