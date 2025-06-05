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
    public partial class deleteSeller_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                SellerGridViewBind();
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



        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQuerySellerGridView.SelectedRow;

        //    if (row != null)
        //    {

        //        string rid = row.Cells[1].Text;


        //        // First find AcctId of this customer
        //        string pullAcctID = $"SELECT [acct_ID] FROM [tbl_seller]\r\nWHERE [sell_Id] ='{rid}' ";
        //        SqlDataAdapter adpt20 = new SqlDataAdapter(pullAcctID, conn.Connection());
        //        DataTable dt20 = new DataTable();
        //        adpt20.Fill(dt20);
        //        string acctID = dt20.Rows[0][0].ToString();


        //        SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_seller] WHERE [sell_Id] = '{rid}'", conn.Connection());
        //        cmd.ExecuteNonQuery();


        //        SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_account] WHERE [acct_ID] = '{acctID}'", conn.Connection());
        //        cmd2.ExecuteNonQuery();


        //        Response.Redirect("deleteSeller-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Seller for DELETE');</script>");
        //    }

        //}

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = conn.Connection())
            {
                GridViewRow row = jQuerySellerGridView.SelectedRow;

                if (row != null)
                {
                    string rid = row.Cells[1].Text;

                    string acctID;

                    // First, find the acctID of the seller
                    string pullAcctID = "SELECT [acct_ID] FROM [tbl_seller] WHERE [sell_Id] = @SellerId";
                    using (SqlCommand cmdPullAcctID = new SqlCommand(pullAcctID, connection))
                    {
                        cmdPullAcctID.Parameters.AddWithValue("@SellerId", rid);
                        
                        acctID = cmdPullAcctID.ExecuteScalar()?.ToString();
                    }

                    // Next, delete the seller
                    string deleteSellerQuery = "DELETE FROM [tbl_seller] WHERE [sell_Id] = @SellerId";
                    using (SqlCommand cmdDeleteSeller = new SqlCommand(deleteSellerQuery, connection))
                    {
                        cmdDeleteSeller.Parameters.AddWithValue("@SellerId", rid);
                        cmdDeleteSeller.ExecuteNonQuery();
                    }

                    // Then, delete the associated account
                    string deleteAccountQuery = "DELETE FROM [tbl_account] WHERE [acct_ID] = @AcctID";
                    using (SqlCommand cmdDeleteAccount = new SqlCommand(deleteAccountQuery, connection))
                    {
                        cmdDeleteAccount.Parameters.AddWithValue("@AcctID", acctID);
                        cmdDeleteAccount.ExecuteNonQuery();
                    }

                    Response.Redirect("deleteSeller-ERP.aspx");
                }
                else
                {
                    Response.Write("<script>alert('You need to select a seller for deletion.');</script>");
                }
            }
        }



    }
}