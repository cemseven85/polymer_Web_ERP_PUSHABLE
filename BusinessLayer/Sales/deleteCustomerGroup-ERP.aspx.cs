using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class deleteCustomerGroup_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerGroupGridViewBind();
        }

        private void CustomerGroupGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listCustomerGroup", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryCustomerGroupGridView.DataSource = dt;
                        jQueryCustomerGroupGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryCustomerGroupGridView.UseAccessibleHeader = true;
            jQueryCustomerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void jQueryCustomerGroupGridView_PreRender(object sender, EventArgs e)
        {
            this.CustomerGroupGridViewBind();

            if (jQueryCustomerGroupGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryCustomerGroupGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryCustomerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryCustomerGroupGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryCustomerGroupGridView.SelectedRow;


        //    if(row != null)
        //    {



        //    string rid = row.Cells[1].Text;

        //    SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_customerGroup] WHERE [cust_Grp_Id] = '{rid}'", conn.Connection());
        //    cmd.ExecuteNonQuery();

        //    Response.Redirect("deleteCustomerGroup-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Customer Group for DELETE');</script>");
        //    }
        //}


        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryCustomerGroupGridView.SelectedRow;

            if (row != null)
            {
                string rid = row.Cells[1].Text;

                using (SqlConnection connection = conn.Connection())
                {
                    using (SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_customerGroup] WHERE [cust_Grp_Id] = '{rid}'", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Redirect("deleteCustomerGroup-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Customer Group for DELETE');</script>");
            }
        }

    }
}