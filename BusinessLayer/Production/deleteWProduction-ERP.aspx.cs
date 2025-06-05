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
    public partial class deleteWProduction_ERP : System.Web.UI.Page
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



                InPutProductionGridViewBind();

            }

        }


        private void InPutProductionGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listInPutProduction '{ItemDateMax_TextBox.Text}','{ItemDateMin_TextBox.Text}' ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryInPutProductionGridView.DataSource = dt;
                        jQueryInPutProductionGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryInPutProductionGridView.UseAccessibleHeader = true;
            jQueryInPutProductionGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void jQueryScrapGridView_PreRender(object sender, EventArgs e)
        {
            this.InPutProductionGridViewBind();

            if (jQueryInPutProductionGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryInPutProductionGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryInPutProductionGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryInPutProductionGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }



        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryInPutProductionGridView.SelectedRow;


        //    if (row != null)
        //    {

        //        string rid = row.Cells[1].Text;

        //        SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_productionInput] WHERE [prodI_Id] = '{rid}'", conn.Connection());
        //        cmd.ExecuteNonQuery();




        //        Response.Redirect("deleteWProduction-ERP.aspx");


        //    }

        //    else
        //    {

        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Production Input for DELETE');</script>");
        //    }

        //}


        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryInPutProductionGridView.SelectedRow;

            if (row != null)
            {
                string rid = row.Cells[1].Text;

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM [tbl_productionInput] WHERE [prodI_Id] = @prodI_Id";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@prodI_Id", rid);
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Redirect("deleteWProduction-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Production Input for DELETE');</script>");
            }
        }


        protected void ShowReportButton_Click(object sender, EventArgs e)
        {

        }
    }
}