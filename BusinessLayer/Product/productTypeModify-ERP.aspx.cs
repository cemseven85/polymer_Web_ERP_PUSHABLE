using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System.Drawing;
using System.Net.NetworkInformation;

namespace polymer_Web_ERP_V4
{
    public partial class productTypeModify_ERP : System.Web.UI.Page
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
        //        ProductTypeDropDownList.DataSource = dt;
        //        ProductTypeDropDownList.DataBind();
        //        ProductTypeDropDownList.DataTextField = "prod_Typ_Name";
        //        ProductTypeDropDownList.DataValueField = "prod_Typ_Id";
        //        ProductTypeDropDownList.DataBind();

        //    }



        //}



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string com = "Select * from tbl_productType";

                using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
                {
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);

                    ProductTypeDropDownList.DataSource = dt;
                    ProductTypeDropDownList.DataTextField = "prod_Typ_Name";
                    ProductTypeDropDownList.DataValueField = "prod_Typ_Id";
                    ProductTypeDropDownList.DataBind();
                }
            }
        }


        //protected void ShowProductTypeButton_Click(object sender, EventArgs e)
        //{

        //    SqlCommand cmd = new SqlCommand("select prod_Typ_Name,prod_Typ_Name_BG,prod_Typ_Name_TR,prod_Typ_Description from tbl_productType where prod_Typ_Id = '" + ProductTypeDropDownList.SelectedValue + "'", conn.Connection());
        //    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);

        //    Product_Type_Name_TextBox.Text = (string)dt.Rows[0][0];
        //    Product_Type_Name_BG_TextBox.Text = (string)dt.Rows[0][1];
        //    Product_Type_Name_TR_TextBox.Text=(string)dt.Rows[0][2];
        //    Product_Type_Description_TextBox.Text = (string)dt.Rows[0][3];
        //}


        protected void ShowProductTypeButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select prod_Typ_Name, prod_Typ_Name_BG, prod_Typ_Name_TR, prod_Typ_Description from tbl_productType where prod_Typ_Id = @TypeId", conn.Connection());
            cmd.Parameters.AddWithValue("@TypeId", ProductTypeDropDownList.SelectedValue);

            using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Product_Type_Name_TextBox.Text = dt.Rows[0]["prod_Typ_Name"].ToString();
                    Product_Type_Name_BG_TextBox.Text = dt.Rows[0]["prod_Typ_Name_BG"].ToString();
                    Product_Type_Name_TR_TextBox.Text = dt.Rows[0]["prod_Typ_Name_TR"].ToString();
                    Product_Type_Description_TextBox.Text = dt.Rows[0]["prod_Typ_Description"].ToString();
                }
                else
                {
                    // Handle case when no data is returned
                }
            }
        }



        //protected void ModifyButton_Click(object sender, EventArgs e)
        //{   
        //    string productTypeName;
        //    string productTypeNameBG;
        //    string productTypeNameTR;
        //    string productTypeDescription;

        //    productTypeName = Product_Type_Name_TextBox.Text;
        //    productTypeNameBG = Product_Type_Name_BG_TextBox.Text;
        //    productTypeNameTR = Product_Type_Name_TR_TextBox.Text;
        //    productTypeDescription = Product_Type_Description_TextBox.Text;


        //    SqlCommand modfiyType = new SqlCommand($"update tbl_productType set prod_Typ_Name='{productTypeName}', prod_Typ_Name_BG=@bgName,prod_Typ_Name_TR='{productTypeNameTR}',prod_Typ_Description='{productTypeDescription}' where prod_Typ_Id = '" + ProductTypeDropDownList.SelectedValue + "'", conn.Connection());
        //    modfiyType.Parameters.AddWithValue("@bgName", Product_Type_Name_BG_TextBox.Text);
        //    modfiyType.ExecuteNonQuery();

        //    Response.Redirect("productTypeModify-ERP.aspx");
        //}


        protected void ModifyButton_Click(object sender, EventArgs e)
        {
            string productTypeName = Product_Type_Name_TextBox.Text;
            string productTypeNameBG = Product_Type_Name_BG_TextBox.Text;
            string productTypeNameTR = Product_Type_Name_TR_TextBox.Text;
            string productTypeDescription = Product_Type_Description_TextBox.Text;

            SqlCommand modfiyType = new SqlCommand("UPDATE tbl_productType SET prod_Typ_Name = @TypeName, prod_Typ_Name_BG = @TypeNameBG, prod_Typ_Name_TR = @TypeNameTR, prod_Typ_Description = @TypeDescription WHERE prod_Typ_Id = @TypeId", conn.Connection());
            modfiyType.Parameters.AddWithValue("@TypeName", productTypeName);
            modfiyType.Parameters.AddWithValue("@TypeNameBG", productTypeNameBG);
            modfiyType.Parameters.AddWithValue("@TypeNameTR", productTypeNameTR);
            modfiyType.Parameters.AddWithValue("@TypeDescription", productTypeDescription);
            modfiyType.Parameters.AddWithValue("@TypeId", ProductTypeDropDownList.SelectedValue);

            modfiyType.ExecuteNonQuery();

            Response.Redirect("productTypeModify-ERP.aspx");
        }



        //protected void ShowDetais()
        //{
        //    SqlCommand cmd = new SqlCommand("select prod_Typ_Name,prod_Typ_Name_BG,prod_Typ_Name_TR,prod_Typ_Description from tbl_productType where prod_Typ_Id = '" + ProductTypeDropDownList.SelectedValue + "'", conn.Connection());
        //    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);

        //    Product_Type_Name_TextBox.Text = (string)dt.Rows[0][0];
        //    Product_Type_Name_BG_TextBox.Text = (string)dt.Rows[0][1];
        //    Product_Type_Name_TR_TextBox.Text = (string)dt.Rows[0][2];
        //    Product_Type_Description_TextBox.Text = (string)dt.Rows[0][3];

        //}

        protected void ShowDetails()
        {
            SqlCommand cmd = new SqlCommand("SELECT prod_Typ_Name, prod_Typ_Name_BG, prod_Typ_Name_TR, prod_Typ_Description FROM tbl_productType WHERE prod_Typ_Id = @TypeId", conn.Connection());
            cmd.Parameters.AddWithValue("@TypeId", ProductTypeDropDownList.SelectedValue);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Product_Type_Name_TextBox.Text = dt.Rows[0]["prod_Typ_Name"].ToString();
                Product_Type_Name_BG_TextBox.Text = dt.Rows[0]["prod_Typ_Name_BG"].ToString();
                Product_Type_Name_TR_TextBox.Text = dt.Rows[0]["prod_Typ_Name_TR"].ToString();
                Product_Type_Description_TextBox.Text = dt.Rows[0]["prod_Typ_Description"].ToString();
            }
            else
            {
                // Handle case when no data is found for the selected product type
                // For example, display an error message or clear the text boxes
            }
        }


        protected void ProductTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            ShowDetails();
        }
    }
}