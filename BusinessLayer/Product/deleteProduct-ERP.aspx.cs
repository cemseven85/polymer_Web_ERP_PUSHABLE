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
    public partial class deleteProduct_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductGridViewBind();
        }

        private void ProductGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listProducts", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryProductGridView.DataSource = dt;
                        jQueryProductGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryProductGridView.UseAccessibleHeader = true;
            jQueryProductGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void jQueryProductGridView_PreRender(object sender, EventArgs e)
        {
            this.ProductGridViewBind();

            //if (jQueryProductGridView.Rows.Count > 0)
            //{
            //    //This replaces <td> with <th> and adds the scope attribute
            //    jQueryProductGridView.UseAccessibleHeader = true;

            //    //This will add the <thead> and <tbody> elements
            //    jQueryProductGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

            //    //This adds the <tfoot> element.
            //    //Remove if you don't have a footer row
            //    jQueryProductGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            //}

            // Configure GridView structure
            if (jQueryProductGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryProductGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryProductGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryProductGridView.FooterRow.TableSection = TableRowSection.TableFooter;

                // Check if a row is selected
                if (jQueryProductGridView.SelectedIndex >= 0)
                {
                    // Hide other rows if a row is selected
                    HideOtherRows();
                }
                else
                {
                    // If no row is selected, ensure all rows are visible
                    foreach (GridViewRow row in jQueryProductGridView.Rows)
                    {
                        row.Visible = true;
                    }
                }
            }


        }

        //protected void prdDeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryProductGridView.SelectedRow;
        //    if (row != null)
        //    {



        //        string rid = row.Cells[1].Text;

        //        SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_product] WHERE [prod_Id] = '{rid}'", conn.Connection());
        //        cmd.ExecuteNonQuery();

        //        Response.Redirect("deleteProduct-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Product for DELETE');</script>");
        //    }

        //}


        protected void prdDeleteButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryProductGridView.SelectedRow;
            if (row != null)
            {
                string rid = row.Cells[1].Text;

                using (SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_product] WHERE [prod_Id] = '{rid}'", conn.Connection()))
                {
                    cmd.ExecuteNonQuery();
                }

                Response.Redirect("deleteProduct-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Product for DELETE');</script>");
            }
        }



        private void HideOtherRows()
        {
            foreach (GridViewRow row in jQueryProductGridView.Rows)
            {
                if (row.RowIndex != jQueryProductGridView.SelectedIndex)
                {
                    row.Visible = false;
                }
            }
        }

        

        protected void prdCancelButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("deleteProduct-ERP.aspx");
        }
    }
}