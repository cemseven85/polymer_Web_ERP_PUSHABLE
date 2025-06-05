using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System.Security.Cryptography;
using System.Configuration;

namespace polymer_Web_ERP_V4
{
    public partial class deletePrdGroup_ERP : System.Web.UI.Page
    {

        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }


        private void BindGrid()
        {

            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listProductGroup", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryProductGroupGridView.DataSource = dt;
                        jQueryProductGroupGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryProductGroupGridView.UseAccessibleHeader = true;
            jQueryProductGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;


            //  !!!!!!      Error when selected index change not working . !!!!!!!!

            //Drop Doown List Code  


        }

        protected void ProductGroupIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void jQueryProductGroupGridView_PreRender(object sender, EventArgs e)
        {
            this.BindGrid();

            if (jQueryProductGroupGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryProductGroupGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryProductGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryProductGroupGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        //protected void prdGroupDeleteButton_Click(object sender, EventArgs e)
        //{

        //    //  This is the delete index comming from GridWiew Row.

        //    GridViewRow row = jQueryProductGroupGridView.SelectedRow;

        //    if (row != null)
        //    {

        //        string rid = row.Cells[1].Text;

        //        SqlCommand cmd = new SqlCommand($"DELETE FROM tbl_productGroup WHERE prod_Grp_Id = '{rid}'", conn.Connection());

        //        cmd.ExecuteNonQuery();

        //        Response.Redirect("deletePrdGroup-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Product Group for DELETE');</script>");
        //    }

        //}



        protected void prdGroupDeleteButton_Click(object sender, EventArgs e)
        {
            // This is the delete index coming from GridView Row.
            GridViewRow row = jQueryProductGroupGridView.SelectedRow;

            if (row != null)
            {
                string rid = row.Cells[1].Text;

                using (SqlCommand cmd = new SqlCommand($"DELETE FROM tbl_productGroup WHERE prod_Grp_Id = '{rid}'", conn.Connection()))
                {
                    cmd.ExecuteNonQuery();
                }

                Response.Redirect("deletePrdGroup-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Product Group for DELETE');</script>");
            }
        }



    }
}