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
    public partial class deleteGProduction_ERP : System.Web.UI.Page
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

                OutPutProductionGridViewBind();

            }

        }


        private void OutPutProductionGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_ListOutPutProduction '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}' ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryOutPutProductionGridView.DataSource = dt;
                        jQueryOutPutProductionGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryOutPutProductionGridView.UseAccessibleHeader = true;
            jQueryOutPutProductionGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryOutPutProductionGridView_PreRender(object sender, EventArgs e)
        {
            this.OutPutProductionGridViewBind();

            if (jQueryOutPutProductionGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryOutPutProductionGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryOutPutProductionGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryOutPutProductionGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryOutPutProductionGridView.SelectedRow;

        //    if(row!= null) { 
        //    string rid = row.Cells[3].Text;

        //    SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_productionOutput] WHERE [item_Id] = '{rid}'", conn.Connection());
        //    cmd.ExecuteNonQuery();

        //    SqlCommand cmd2 = new SqlCommand($"DELETE FROM [tbl_item] WHERE [item_Id] = '{rid}'", conn.Connection());
        //    cmd2.ExecuteNonQuery();


        //    Response.Redirect("deleteGProduction-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Production OutPut for DELETE');</script>");
        //    }

        //}


        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryOutPutProductionGridView.SelectedRow;

            if (row != null)
            {
                string rid = row.Cells[3].Text;

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
                {
                    connection.Open();

                    // Deleting from tbl_productionOutput
                    string deleteProductionOutputQuery = "DELETE FROM [tbl_productionOutput] WHERE [item_Id] = @itemId";
                    using (SqlCommand cmd = new SqlCommand(deleteProductionOutputQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@itemId", rid);
                        cmd.ExecuteNonQuery();
                    }

                    // Deleting from tbl_item
                    string deleteItemQuery = "DELETE FROM [tbl_item] WHERE [item_Id] = @itemId";
                    using (SqlCommand cmd2 = new SqlCommand(deleteItemQuery, connection))
                    {
                        cmd2.Parameters.AddWithValue("@itemId", rid);
                        cmd2.ExecuteNonQuery();
                    }
                }

                Response.Redirect("deleteGProduction-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Production OutPut for DELETE');</script>");
            }
        }


        protected void ShowReportButton_Click(object sender, EventArgs e)
        {
            OutPutProductionGridViewBind();
        }
    }
}