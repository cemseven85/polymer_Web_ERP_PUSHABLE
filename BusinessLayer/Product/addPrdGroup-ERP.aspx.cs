using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class addPrdGroup_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    if (!Page.IsPostBack)
        //    {
        //        string com = "Select * from tbl_productType";
        //        SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //        DataTable dt = new DataTable();
        //        adpt.Fill(dt);
        //        ProductTypeIdDropDownList.DataSource = dt;
        //        ProductTypeIdDropDownList.DataBind();
        //        ProductTypeIdDropDownList.DataTextField = "prod_Typ_Name";
        //        ProductTypeIdDropDownList.DataValueField = "prod_Typ_Id";
        //        ProductTypeIdDropDownList.DataBind();


        //        string com2 = "execute prc_listProductGroup";
        //        SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection());
        //        DataTable dt2 = new DataTable();
        //        adpt2.Fill(dt2);

        //        ProductGroupGridView.DataSource = dt2;
        //        ProductGroupGridView.DataBind();


        //    }

        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (SqlCommand cmd = new SqlCommand("Select * from tbl_productType", conn.Connection()))
                {
                    using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);
                        ProductTypeIdDropDownList.DataSource = dt;
                        ProductTypeIdDropDownList.DataBind();
                        ProductTypeIdDropDownList.DataTextField = "prod_Typ_Name";
                        ProductTypeIdDropDownList.DataValueField = "prod_Typ_Id";
                        ProductTypeIdDropDownList.DataBind();
                    }
                }

                using (SqlCommand cmd2 = new SqlCommand("execute prc_listProductGroup", conn.Connection()))
                {
                    using (SqlDataAdapter adpt2 = new SqlDataAdapter(cmd2))
                    {
                        DataTable dt2 = new DataTable();
                        adpt2.Fill(dt2);
                        ProductGroupGridView.DataSource = dt2;
                        ProductGroupGridView.DataBind();
                    }
                }
            }
        }



        //protected void AddGroupButton_Click(object sender, EventArgs e)
        //{
        //    string productGroupName;
        //    string productGroupNameBG;
        //    string productGroupNameTR;
        //    string productGroupDescription;

        //    productGroupName = Product_Group_Name_TextBox.Text;
        //    productGroupNameBG = Product_Group_Name_BG_TextBox.Text;
        //    productGroupNameTR = Product_Group_Name_TR_TextBox.Text;
        //    productGroupDescription = Product_Group_Description_TextBox.Text;


        //    SqlCommand addNewGroup = new SqlCommand($"insert into tbl_productGroup (prod_Type_Id,prod_Grp_Name,prod_Grp_Name_BG,prod_Grp_Name_TR,prod_Grp_Description) values ( '{ProductTypeIdDropDownList.SelectedValue}' ,'{productGroupName}', @bgName ,'{productGroupNameTR}','{productGroupDescription}')", conn.Connection());
        //    addNewGroup.Parameters.AddWithValue("@bgName", Product_Group_Name_BG_TextBox.Text);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
        //    addNewGroup.ExecuteNonQuery();

        //    Response.Redirect("addPrdGroup-ERP.aspx");
        //}





        //protected void ProductGroupGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //    ProductGroupGridView.PageIndex = e.NewPageIndex;

        //    string com2 = "execute prc_listProductGroup";
        //    SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt2.Fill(dt2);

        //    ProductGroupGridView.DataSource = dt2;
        //    ProductGroupGridView.DataBind();
        //}



        protected void AddGroupButton_Click(object sender, EventArgs e)
        {
            string productGroupName;
            string productGroupNameBG;
            string productGroupNameTR;
            string productGroupDescription;

            productGroupName = Product_Group_Name_TextBox.Text;
            productGroupNameBG = Product_Group_Name_BG_TextBox.Text;
            productGroupNameTR = Product_Group_Name_TR_TextBox.Text;
            productGroupDescription = Product_Group_Description_TextBox.Text;

            using (SqlCommand addNewGroup = new SqlCommand($"insert into tbl_productGroup (prod_Type_Id,prod_Grp_Name,prod_Grp_Name_BG,prod_Grp_Name_TR,prod_Grp_Description) values ( '{ProductTypeIdDropDownList.SelectedValue}' ,'{productGroupName}', @bgName ,'{productGroupNameTR}','{productGroupDescription}')", conn.Connection()))
            {
                addNewGroup.Parameters.AddWithValue("@bgName", productGroupNameBG);
                addNewGroup.ExecuteNonQuery();
            }

            Response.Redirect("addPrdGroup-ERP.aspx");
        }

        protected void ProductGroupGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductGroupGridView.PageIndex = e.NewPageIndex;

            using (SqlDataAdapter adpt2 = new SqlDataAdapter("execute prc_listProductGroup", conn.Connection()))
            {
                DataTable dt2 = new DataTable();
                adpt2.Fill(dt2);
                ProductGroupGridView.DataSource = dt2;
                ProductGroupGridView.DataBind();
            }
        }




    }
}