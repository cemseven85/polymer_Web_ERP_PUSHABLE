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
    public partial class deleteEmployee_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                jQueryEmployeeGridViewBind();

            }

        }


        private void jQueryEmployeeGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listEmployee ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryEmployeeGridView.DataSource = dt;
                        jQueryEmployeeGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryEmployeeGridView.UseAccessibleHeader = true;
            jQueryEmployeeGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryEmployeeGridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryEmployeeGridViewBind();

            if (jQueryEmployeeGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryEmployeeGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryEmployeeGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryEmployeeGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryEmployeeGridView.SelectedRow;

        //    if(row != null)
        //    {



        //    string rid = row.Cells[1].Text;


        //        // First find AcctId of this customer
        //        string pullAcctID = $"SELECT [acct_ID] FROM [tbl_employee]\r\nWHERE [empl_Id] ='{rid}' ";
        //        SqlDataAdapter adpt20 = new SqlDataAdapter(pullAcctID, conn.Connection());
        //        DataTable dt20 = new DataTable();
        //        adpt20.Fill(dt20);
        //        string acctID = dt20.Rows[0][0].ToString();



        //        SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_employee] WHERE [empl_Id] = '{rid}'", conn.Connection());
        //    cmd.ExecuteNonQuery();


        //        SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_account] WHERE [acct_ID] = '{acctID}'", conn.Connection());
        //        cmd2.ExecuteNonQuery();

        //        Response.Redirect("deleteEmployee-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Employee  for DELETE');</script>");
        //    }


        //}

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryEmployeeGridView.SelectedRow;

            if (row != null)
            {
                string rid = row.Cells[1].Text;

                // First find AcctId of this customer
                string pullAcctID = "SELECT [acct_ID] FROM [tbl_employee] WHERE [empl_Id] = @rid";

                using (SqlCommand pullAcctCmd = new SqlCommand(pullAcctID, conn.Connection()))
                {
                    pullAcctCmd.Parameters.AddWithValue("@rid", rid);

                    string acctID = pullAcctCmd.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(acctID))
                    {
                        string deleteEmployeeQuery = "DELETE FROM [tbl_employee] WHERE [empl_Id] = @rid";
                        string deleteAccountQuery = "DELETE FROM [tbl_account] WHERE [acct_ID] = @acctID";

                        using (SqlCommand deleteEmployeeCmd = new SqlCommand(deleteEmployeeQuery, conn.Connection()))
                        using (SqlCommand deleteAccountCmd = new SqlCommand(deleteAccountQuery, conn.Connection()))
                        {
                            deleteEmployeeCmd.Parameters.AddWithValue("@rid", rid);
                            deleteAccountCmd.Parameters.AddWithValue("@acctID", acctID);

                            deleteEmployeeCmd.ExecuteNonQuery();
                            deleteAccountCmd.ExecuteNonQuery();
                        }

                        Response.Redirect("deleteEmployee-ERP.aspx");
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Failed to find associated account for deletion');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('You need to select an Employee to DELETE');</script>");
            }
        }



    }
}