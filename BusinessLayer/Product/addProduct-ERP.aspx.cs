using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace polymer_Web_ERP_V4
{
    public partial class addProduct_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DropDownPrdGroupBind();
                DropDownUnitBind();
                DropDownVATBind();
                ProductGridViewBind();
                DropDownWasteCodeBind();
            }


        }


        //private void DropDownPrdGroupBind()
        //{
        //    string com = "Select * from tbl_productGroup";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ProductGroupIdDropDownList.DataSource = dt2;
        //    ProductGroupIdDropDownList.DataBind();
        //    ProductGroupIdDropDownList.DataTextField = "prod_Grp_Name";
        //    ProductGroupIdDropDownList.DataValueField = "prod_Grp_Id";
        //    ProductGroupIdDropDownList.DataBind();
        //}

        //private void DropDownUnitBind()
        //{
        //    string com = "Select * from tbl_unit";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ProductUnitIdDropDownList.DataSource = dt2;
        //    ProductUnitIdDropDownList.DataBind();
        //    ProductUnitIdDropDownList.DataTextField = "unt_Name";
        //    ProductUnitIdDropDownList.DataValueField = "unt_Id";
        //    ProductUnitIdDropDownList.DataBind();
        //}

        //private void DropDownVATBind()
        //{
        //    string com = "Select * from tbl_VAT";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ProductVATIdDropDownList.DataSource = dt2;
        //    ProductVATIdDropDownList.DataBind();
        //    ProductVATIdDropDownList.DataTextField = "vat_Name";
        //    ProductVATIdDropDownList.DataValueField = "vat_Id";
        //    ProductVATIdDropDownList.DataBind();
        //}

        //private void DropDownWasteCodeBind()
        //{
        //    string com = "Select * from tbl_wasteCode";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    ProductWasteCodeIdDropDownList.DataSource = dt2;
        //    ProductWasteCodeIdDropDownList.DataBind();
        //    ProductWasteCodeIdDropDownList.DataTextField = "wasteCode_Name";
        //    ProductWasteCodeIdDropDownList.DataValueField = "wasteCode_Id";
        //    ProductWasteCodeIdDropDownList.DataBind();
        //}



        private void DropDownPrdGroupBind()
        {
            using (SqlDataAdapter adpt = new SqlDataAdapter("Select * from tbl_productGroup", conn.Connection()))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                ProductGroupIdDropDownList.DataSource = dt2;
                ProductGroupIdDropDownList.DataBind();
                ProductGroupIdDropDownList.DataTextField = "prod_Grp_Name";
                ProductGroupIdDropDownList.DataValueField = "prod_Grp_Id";
                ProductGroupIdDropDownList.DataBind();
            }
        }

        private void DropDownUnitBind()
        {
            using (SqlDataAdapter adpt = new SqlDataAdapter("Select * from tbl_unit", conn.Connection()))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                ProductUnitIdDropDownList.DataSource = dt2;
                ProductUnitIdDropDownList.DataBind();
                ProductUnitIdDropDownList.DataTextField = "unt_Name";
                ProductUnitIdDropDownList.DataValueField = "unt_Id";
                ProductUnitIdDropDownList.DataBind();
            }
        }

        private void DropDownVATBind()
        {
            using (SqlDataAdapter adpt = new SqlDataAdapter("Select * from tbl_VAT", conn.Connection()))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                ProductVATIdDropDownList.DataSource = dt2;
                ProductVATIdDropDownList.DataBind();
                ProductVATIdDropDownList.DataTextField = "vat_Name";
                ProductVATIdDropDownList.DataValueField = "vat_Id";
                ProductVATIdDropDownList.DataBind();
            }
        }

        private void DropDownWasteCodeBind()
        {
            using (SqlDataAdapter adpt = new SqlDataAdapter("Select * from tbl_wasteCode", conn.Connection()))
            {
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                ProductWasteCodeIdDropDownList.DataSource = dt2;
                ProductWasteCodeIdDropDownList.DataBind();
                ProductWasteCodeIdDropDownList.DataTextField = "wasteCode_Name";
                ProductWasteCodeIdDropDownList.DataValueField = "wasteCode_Id";
                ProductWasteCodeIdDropDownList.DataBind();
            }
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




        //protected void prdAddButton_Click(object sender, EventArgs e)
        //{
        //    string productName;
        //    string productNameBG;
        //    string productNameTR;
        //    string productDescription;

        //    productName = Product_Name_TextBox.Text;
        //    productNameBG = Product_Name_BG_TextBox.Text;
        //    productNameTR = Product_Name_TR_TextBox.Text;
        //    productDescription= Product_Description_TextBox.Text;


        //    SqlCommand addNewProduct = new SqlCommand($"insert into tbl_product (prod_Name,prod_Name_BG,prod_Name_TR,prod_Group_Id,prod_Unit_Id,prod_VAT_Id,prod_Waste_Code_Id,prod_Description) values ('{productName}',@bgName , '{productNameTR}','{ProductGroupIdDropDownList.SelectedValue}' ,'{ProductUnitIdDropDownList.SelectedValue}','{ProductVATIdDropDownList.SelectedValue}','{ProductWasteCodeIdDropDownList.SelectedValue}', '{productDescription}')", conn.Connection());
        //    addNewProduct.Parameters.AddWithValue("@bgName", Product_Name_BG_TextBox.Text);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
        //    addNewProduct.ExecuteNonQuery();

        //    Response.Redirect("addProduct-ERP.aspx");



        //}

        protected void prdAddButton_Click(object sender, EventArgs e)
        {
            string productName;
            string productNameBG;
            string productNameTR;
            string productDescription;

            productName = Product_Name_TextBox.Text;
            productNameBG = Product_Name_BG_TextBox.Text;
            productNameTR = Product_Name_TR_TextBox.Text;
            productDescription = Product_Description_TextBox.Text;

            using (SqlCommand addNewProduct = new SqlCommand($"insert into tbl_product (prod_Name,prod_Name_BG,prod_Name_TR,prod_Group_Id,prod_Unit_Id,prod_VAT_Id,prod_Waste_Code_Id,prod_Description) values ('{productName}',@bgName , '{productNameTR}','{ProductGroupIdDropDownList.SelectedValue}' ,'{ProductUnitIdDropDownList.SelectedValue}','{ProductVATIdDropDownList.SelectedValue}','{ProductWasteCodeIdDropDownList.SelectedValue}', '{productDescription}')", conn.Connection()))
            {
                addNewProduct.Parameters.AddWithValue("@bgName", Product_Name_BG_TextBox.Text);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
                addNewProduct.ExecuteNonQuery();

                Response.Redirect("addProduct-ERP.aspx");
            }
        }

    }
}