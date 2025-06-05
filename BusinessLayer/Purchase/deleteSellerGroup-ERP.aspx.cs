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
    public partial class deleteSellerGroup_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            SellerGroupGridViewBind();
        }

        private void SellerGroupGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listSellerGroup", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQuerySellerGroupGridView.DataSource = dt;
                        jQuerySellerGroupGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQuerySellerGroupGridView.UseAccessibleHeader = true;
            jQuerySellerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void jQuerySellerGroupGridView_PreRender(object sender, EventArgs e)
        {
            this.SellerGroupGridViewBind();

            if (jQuerySellerGroupGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQuerySellerGroupGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQuerySellerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQuerySellerGroupGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQuerySellerGroupGridView.SelectedRow;

        //    if(row != null)
        //    {



        //    string rid = row.Cells[1].Text;

        //    SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_sellerGroup] WHERE [sell_Grp_Id] = '{rid}'", conn.Connection());
        //    cmd.ExecuteNonQuery();

        //    Response.Redirect("deleteSellerGroup-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Seller Group for DELETE');</script>");
        //    }
        //}

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = conn.Connection())
            {
                GridViewRow row = jQuerySellerGroupGridView.SelectedRow;

                if (row != null)
                {
                    string rid = row.Cells[1].Text;

                    string deleteQuery = "DELETE FROM [tbl_sellerGroup] WHERE [sell_Grp_Id] = @SellerGroupId";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@SellerGroupId", rid);
                       
                        cmd.ExecuteNonQuery();
                    }

                    Response.Redirect("deleteSellerGroup-ERP.aspx");
                }
                else
                {
                    Response.Write("<script>alert('You need to select a Seller Group for deletion.');</script>");
                }
            }
        }



    }




}