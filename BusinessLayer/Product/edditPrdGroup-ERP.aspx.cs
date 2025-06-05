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

namespace polymer_Web_ERP_V4
{
    public partial class edditPrdGroup_ERP : System.Web.UI.Page
    {

        DataAccess conn = new DataAccess();

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    if (!Page.IsPostBack)
        //    {
        //        string com = "Select * from tbl_productGroup";
        //        SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //        DataTable dt = new DataTable();
        //        adpt.Fill(dt);
        //        ProductGroupIdDropDownList.DataSource = dt;
        //        ProductGroupIdDropDownList.DataBind();
        //        ProductGroupIdDropDownList.DataTextField = "prod_Grp_Name";
        //        ProductGroupIdDropDownList.DataValueField = "prod_Grp_Id";
        //        ProductGroupIdDropDownList.DataBind();


        //        string com2 = "Select prod_Grp_Id as Id,prod_Type_Id as 'Type Id' ,prod_Grp_Name as 'Name', prod_Grp_Name_BG as 'Name BG',prod_Grp_Name_TR as 'Name TR',prod_Grp_Description as 'Description' from tbl_productGroup";
        //        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection());
        //        DataTable dt2 = new DataTable();
        //        adpt2.Fill(dt2);

        //        ProductGroupGridView.DataSource = dt2;
        //        ProductGroupGridView.DataBind();


        //        Product_Group_Panel_8.Visible = false;

        //    }

        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (SqlConnection connection = conn.Connection())
                {
                    string com = "Select * from tbl_productGroup";
                    using (SqlDataAdapter adpt = new SqlDataAdapter(com, connection))
                    {
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);
                        ProductGroupIdDropDownList.DataSource = dt;
                        ProductGroupIdDropDownList.DataBind();
                        ProductGroupIdDropDownList.DataTextField = "prod_Grp_Name";
                        ProductGroupIdDropDownList.DataValueField = "prod_Grp_Id";
                        ProductGroupIdDropDownList.DataBind();
                    }

                    string com2 = "Select prod_Grp_Id as Id, prod_Type_Id as 'Type Id', prod_Grp_Name as 'Name', prod_Grp_Name_BG as 'Name BG', prod_Grp_Name_TR as 'Name TR', prod_Grp_Description as 'Description' from tbl_productGroup";
                    using (SqlDataAdapter adpt2 = new SqlDataAdapter(com2, connection))
                    {
                        DataTable dt2 = new DataTable();
                        adpt2.Fill(dt2);

                        ProductGroupGridView.DataSource = dt2;
                        ProductGroupGridView.DataBind();
                    }
                }

                Product_Group_Panel_8.Visible = false;
            }
        }



        //protected void ProductGroupGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //    ProductGroupGridView.PageIndex = e.NewPageIndex;

        //    string com2 = "Select prod_Grp_Id as Id,prod_Type_Id as 'Type Id' ,prod_Grp_Name as 'Product Group Name', prod_Grp_Name_BG as 'Product Group Name BG',prod_Grp_Name_TR as 'Product Group Name TR',prod_Grp_Description as 'Product Group Description' from tbl_productGroup";
        //    SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt2.Fill(dt2);

        //    ProductGroupGridView.DataSource = dt2;
        //    ProductGroupGridView.DataBind();
        //}


        protected void ProductGroupGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductGroupGridView.PageIndex = e.NewPageIndex;

            using (SqlConnection connection = conn.Connection())
            {
                string com2 = "Select prod_Grp_Id as Id, prod_Type_Id as 'Type Id', prod_Grp_Name as 'Product Group Name', prod_Grp_Name_BG as 'Product Group Name BG', prod_Grp_Name_TR as 'Product Group Name TR', prod_Grp_Description as 'Product Group Description' from tbl_productGroup";
                using (SqlDataAdapter adpt2 = new SqlDataAdapter(com2, connection))
                {
                    DataTable dt2 = new DataTable();
                    adpt2.Fill(dt2);

                    ProductGroupGridView.DataSource = dt2;
                    ProductGroupGridView.DataBind();
                }
            }
        }



        //protected void ProductGroupIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    SqlCommand cmd = new SqlCommand("select prod_Type_Id, prod_Grp_Name,prod_Grp_Name_BG,prod_Grp_Name_TR,prod_Grp_Description from tbl_productGroup where prod_Grp_Id = '" + ProductGroupIdDropDownList.SelectedValue + "'", conn.Connection());
        //    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);

        //    //Dynamic Assign Value to  DropDownList 

        //    string cmd2 = "select *from tbl_productType";
        //    SqlDataAdapter adpt2 = new SqlDataAdapter(cmd2, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt2.Fill(dt2);

        //    ProductTypeIdDropDownList.DataSource = dt2;
        //    ProductTypeIdDropDownList.DataBind();
        //    ProductTypeIdDropDownList.DataTextField = "prod_Typ_Name";
        //    ProductTypeIdDropDownList.DataValueField = "prod_Typ_Id";
        //    ProductTypeIdDropDownList.DataBind();

        //    //Dynamic Assign Value to  DropDownList 
        //    // We use other dataTables row values to assingn Value.
        //    ProductTypeIdDropDownList.SelectedValue = dt.Rows[0][0].ToString();    // Assigning DropDownList value by SelectingValue by Code. 
        //    // Product_Group_Name_TextBox.Text = (string)dt.Rows[0][1];
        //    Product_Group_Name_TextBox.Text = EncodeDecodeModule.EncodeDecodeDataTable(dt, 1);
        //    Product_Group_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecodeDataTable(dt, 2);
        //    Product_Group_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecodeDataTable(dt, 3);
        //    Product_Group_Description_TextBox.Text = EncodeDecodeModule.EncodeDecodeDataTable(dt, 4);
        //}


        protected void ProductGroupIdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = conn.Connection())
            {
                SqlCommand cmd = new SqlCommand("select prod_Type_Id, prod_Grp_Name, prod_Grp_Name_BG, prod_Grp_Name_TR, prod_Grp_Description from tbl_productGroup where prod_Grp_Id = @groupId", connection);
                cmd.Parameters.AddWithValue("@groupId", ProductGroupIdDropDownList.SelectedValue);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                //Dynamic Assign Value to DropDownList 

                string cmd2 = "select * from tbl_productType";
                SqlDataAdapter adpt2 = new SqlDataAdapter(cmd2, connection);
                DataTable dt2 = new DataTable();
                adpt2.Fill(dt2);

                ProductTypeIdDropDownList.DataSource = dt2;
                ProductTypeIdDropDownList.DataBind();
                ProductTypeIdDropDownList.DataTextField = "prod_Typ_Name";
                ProductTypeIdDropDownList.DataValueField = "prod_Typ_Id";
                ProductTypeIdDropDownList.DataBind();

                //Dynamic Assign Value to DropDownList 
                // We use other dataTables row values to assign Value.
                if (dt.Rows.Count > 0)
                {
                    //Dynamic Assign Value to  DropDownList 
                    // We use other dataTables row values to assingn Value.
                    ProductTypeIdDropDownList.SelectedValue = dt.Rows[0][0].ToString();    // Assigning DropDownList value by SelectingValue by Code. 
                                                                                           // Product_Group_Name_TextBox.Text = (string)dt.Rows[0][1];
                    Product_Group_Name_TextBox.Text = EncodeDecodeModule.EncodeDecodeDataTable(dt, 1);
                    Product_Group_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecodeDataTable(dt, 2);
                    Product_Group_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecodeDataTable(dt, 3);
                    Product_Group_Description_TextBox.Text = EncodeDecodeModule.EncodeDecodeDataTable(dt, 4);
                }
            }
        }



        //protected void EdditGroupButton_Click(object sender, EventArgs e)
        //{



        //    GridViewRow row = ProductGroupGridView.SelectedRow;

        //    if(row != null) 
        //    { 

        //    string productGrpName;
        //    string productGrpNameBG;
        //    string productGrpNameTR;
        //    string productGrpDescription;

        //    productGrpName = Product_Group_Name_TextBox.Text;
        //    productGrpNameBG = Product_Group_Name_BG_TextBox.Text;
        //    productGrpNameTR = Product_Group_Name_TR_TextBox.Text;
        //    productGrpDescription = Product_Group_Description_TextBox.Text;

        //    string prod_Type_Id = ProductTypeIdDropDownList.SelectedValue;

        //    SqlCommand modfiyType = new SqlCommand($"update tbl_productGroup set prod_Type_Id='{prod_Type_Id}' , prod_Grp_Name='{productGrpName}', prod_Grp_Name_BG=@bgName,prod_Grp_Name_TR='{productGrpNameTR}',prod_Grp_Description='{productGrpDescription}' where prod_Grp_Id = '" + ProductGroupIdDropDownList.SelectedValue + "'", conn.Connection());
        //    modfiyType.Parameters.AddWithValue("@bgName", Product_Group_Name_BG_TextBox.Text);
        //    modfiyType.ExecuteNonQuery();

        //    Response.Redirect("edditPrdGroup-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Product Group for Edit');</script>");
        //    }

        //}


        protected void EdditGroupButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = ProductGroupGridView.SelectedRow;

            if (row != null)
            {
                string productGrpName;
                string productGrpNameBG;
                string productGrpNameTR;
                string productGrpDescription;

                productGrpName = Product_Group_Name_TextBox.Text;
                productGrpNameBG = Product_Group_Name_BG_TextBox.Text;
                productGrpNameTR = Product_Group_Name_TR_TextBox.Text;
                productGrpDescription = Product_Group_Description_TextBox.Text;

                string prod_Type_Id = ProductTypeIdDropDownList.SelectedValue;

                using (SqlConnection connection = conn.Connection())
                {
                    SqlCommand modfiyType = new SqlCommand("update tbl_productGroup set prod_Type_Id = @prodTypeId, prod_Grp_Name = @grpName, prod_Grp_Name_BG = @bgName, prod_Grp_Name_TR = @trName, prod_Grp_Description = @description where prod_Grp_Id = @groupId", connection);
                    modfiyType.Parameters.AddWithValue("@prodTypeId", prod_Type_Id);
                    modfiyType.Parameters.AddWithValue("@grpName", productGrpName);
                    modfiyType.Parameters.AddWithValue("@bgName", productGrpNameBG);
                    modfiyType.Parameters.AddWithValue("@trName", productGrpNameTR);
                    modfiyType.Parameters.AddWithValue("@description", productGrpDescription);
                    modfiyType.Parameters.AddWithValue("@groupId", ProductGroupIdDropDownList.SelectedValue);

                    modfiyType.ExecuteNonQuery();
                }

                Response.Redirect("edditPrdGroup-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Product Group for Edit');</script>");
            }
        }



        //protected void ProductGroupGridView_SelectedIndexChanged(object sender, EventArgs e)   // Grid View Selected Row Writting to all TaxBox And DropDownList. Ready To Edit. 
        //{
        //    GridViewRow row = ProductGroupGridView.SelectedRow;
        //    string rid = row.Cells[1].Text;

        //    ProductGroupIdDropDownList.SelectedValue = rid;

        //    ProductGroupIdDropDownList_SelectedIndexChanged(sender, e);    

        //}


        protected void ProductGroupGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ProductGroupGridView.SelectedRow;
            string rid = row.Cells[1].Text;

            ProductGroupIdDropDownList.SelectedValue = rid;

            // Call the event handler method directly instead of raising the event
            ProductGroupIdDropDownList_SelectedIndexChanged(sender, e);
        }




    }
}


