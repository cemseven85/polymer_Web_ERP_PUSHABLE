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
    public partial class deleteCustomer_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                CustomerGridViewBind();
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



        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryCustomerGridView.SelectedRow;


        //    if (row != null)
        //    {

        //        string rid = row.Cells[1].Text;

        //        // First find AcctId of this customer
        //        string pullAcctID = $"SELECT [acct_ID] FROM [tbl_customer]\r\nWHERE [cust_Id] ='{rid}' ";
        //        SqlDataAdapter adpt20 = new SqlDataAdapter(pullAcctID, conn.Connection());
        //        DataTable dt20 = new DataTable();
        //        adpt20.Fill(dt20);
        //        string acctID = dt20.Rows[0][0].ToString();


        //        SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_customer] WHERE [cust_Id] = '{rid}'", conn.Connection());
        //        cmd.ExecuteNonQuery();

        //        SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_account] WHERE [acct_ID] = '{acctID}'", conn.Connection());
        //        cmd2.ExecuteNonQuery();


        //        Response.Redirect("deleteCustomer-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Customer for DELETE');</script>");

        //    }
        //}

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryCustomerGridView.SelectedRow;

            if (row != null)
            {
                string rid = row.Cells[1].Text;

                // First find AcctId of this customer
                string pullAcctID = $"SELECT [acct_ID] FROM [tbl_customer]\r\nWHERE [cust_Id] ='{rid}' ";
                using (SqlConnection connection = conn.Connection())
                {
                    SqlDataAdapter adpt20 = new SqlDataAdapter(pullAcctID, connection);
                    DataTable dt20 = new DataTable();
                    adpt20.Fill(dt20);
                    string acctID = dt20.Rows[0][0].ToString();

                    using (SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_customer] WHERE [cust_Id] = '{rid}'", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_account] WHERE [acct_ID] = '{acctID}'", connection))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                }

                Response.Redirect("deleteCustomer-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Customer for DELETE');</script>");
            }
        }


    }
}