using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using System.Reflection;

namespace polymer_Web_ERP_V4
{
    public partial class productTypeDelete_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!Page.IsPostBack)
        //    {
        //        string com = "Select prod_Typ_Id as Id, prod_Typ_Name as 'Product Type Name', prod_Typ_Name_BG as 'Product Type Name BG',prod_Typ_Name_TR as 'Product Type Name TR',prod_Typ_Description as 'Product Type Description' from tbl_productType";
        //        SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //        DataTable dt = new DataTable();
        //        adpt.Fill(dt);

        //        ProductTypeGridView.DataSource = dt;
        //        ProductTypeGridView.DataBind();

        //    }
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "SELECT prod_Typ_Id AS Id, prod_Typ_Name AS 'Product Type Name', prod_Typ_Name_BG AS 'Product Type Name BG', prod_Typ_Name_TR AS 'Product Type Name TR', prod_Typ_Description AS 'Product Type Description' FROM tbl_productType";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn.Connection()))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    ProductTypeGridView.DataSource = dataTable;
                    ProductTypeGridView.DataBind();
                }
            }
        }



        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{

        //    GridViewRow row = ProductTypeGridView.SelectedRow;

        //    if(row != null)
        //    {
        //        string rid = row.Cells[1].Text;

        //        SqlCommand cmd = new SqlCommand($"DELETE FROM tbl_productType WHERE prod_Typ_Id = '{rid}'", conn.Connection());
        //        cmd.ExecuteNonQuery();
        //        Response.Redirect("productTypeDelete-ERP.aspx");
        //    }
        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Product Type for DELETE');</script>");
        //    }



        //}


        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = ProductTypeGridView.SelectedRow;

            if (row != null)
            {
                string typeId = row.Cells[1].Text;

                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_productType WHERE prod_Typ_Id = @TypeId", conn.Connection()))
                {
                    cmd.Parameters.AddWithValue("@TypeId", typeId);
                    cmd.ExecuteNonQuery();
                }

                Response.Redirect("productTypeDelete-ERP.aspx");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('You need to select a Product Type for deletion.');</script>");
            }
        }



        //protected void ProductTypeGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    ProductTypeGridView.PageIndex = e.NewPageIndex;   // Initial page index is 1  We just change the index page index of GridView by this method.

        //    string com = "Select prod_Typ_Id as Id, prod_Typ_Name as 'Product Type Name', prod_Typ_Name_BG as 'Product Type Name BG',prod_Typ_Name_TR as 'Product Type Name TR',prod_Typ_Description as 'Product Type Description' from tbl_productType";     //  we generate the data table again     //1
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());                          //2
        //    DataTable dt = new DataTable();                                                            //3
        //    adpt.Fill(dt);                                                                             //4

        //    ProductTypeGridView.DataSource = dt;     // With the new index, we bind the gridView to data table . 
        //    ProductTypeGridView.DataBind();


        //    /* Note: 1,2,3,4  parts can be a method called GetTypes with return type DataTable ---->  DataTabele GetTypes()   */
        //    /* Note: Another better practice is to write a class for  "Select * from tbl_........."  because we will use several times. Best Prictice*/
        //}


        protected void ProductTypeGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductTypeGridView.PageIndex = e.NewPageIndex;

            BindProductTypeGridView(); // Rebind the GridView with updated page index
        }

        private void BindProductTypeGridView()
        {
            string com = "Select prod_Typ_Id as Id, prod_Typ_Name as 'Product Type Name', prod_Typ_Name_BG as 'Product Type Name BG', prod_Typ_Name_TR as 'Product Type Name TR', prod_Typ_Description as 'Product Type Description' from tbl_productType";

            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
            {
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                ProductTypeGridView.DataSource = dt;
                ProductTypeGridView.DataBind();
            }
        }



    }
}