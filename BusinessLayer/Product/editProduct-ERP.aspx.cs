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
    public partial class editProduct_ERP : System.Web.UI.Page
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
            using (SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM tbl_productGroup", conn.Connection()))
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
            using (SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM tbl_unit", conn.Connection()))
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
            using (SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM tbl_VAT", conn.Connection()))
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
            using (SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM tbl_wasteCode", conn.Connection()))
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

        //protected void jQueryProductGridView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryProductGridView.SelectedRow;

        //    Product_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
        //    Product_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
        //    Product_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);

        //    // ProductGroup_Name to ProductGroup_ID
        //    string productGroupName = row.Cells[5].Text;
        //    string com = $"select prod_Grp_Id from tbl_productGroup where prod_Grp_Name='{productGroupName}'";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);
        //    string rid = dt2.Rows[0][0].ToString();
        //    ProductGroupIdDropDownList.SelectedValue = rid;

        //    // ProductUnit_Name to ProductUnit_ID
        //    string productUnitName = row.Cells[6].Text;
        //    string com2 = $"select unt_Id from tbl_unit where unt_Name='{productUnitName}'";
        //    SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection());
        //    DataTable dt3 = new DataTable();
        //    adpt2.Fill(dt3);
        //    string rid2 = dt3.Rows[0][0].ToString();
        //    ProductUnitIdDropDownList.SelectedValue = rid2;

        //    // ProductVAT_Name to ProductVAT_ID
        //    string productVATName = row.Cells[7].Text;
        //    string com3 = $"select vat_Id from tbl_VAT where vat_Name='{productVATName}'";
        //    SqlDataAdapter adpt3 = new SqlDataAdapter(com3, conn.Connection());
        //    DataTable dt4 = new DataTable();
        //    adpt3.Fill(dt4);
        //    string rid3 = dt4.Rows[0][0].ToString();
        //    ProductVATIdDropDownList.SelectedValue = rid3;

        //    //ProductWasteCode_Name to WasteCode_ID
        //    string productWasteCodeName = row.Cells[8].Text;
        //    string com4 = $"select [wasteCode_Id] from [tbl_wasteCode] where [wasteCode_Name]='{productWasteCodeName}'";
        //    SqlDataAdapter adpt4 = new SqlDataAdapter(com4, conn.Connection());
        //    DataTable dt5 = new DataTable();
        //    adpt4.Fill(dt5);
        //    string rid4 = dt5.Rows[0][0].ToString();
        //    ProductWasteCodeIdDropDownList.SelectedValue = rid4;



        //    Product_Description_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);


        //    //// Iterate through each row in the GridView
        //    //foreach (GridViewRow rowV in jQueryProductGridView.Rows)
        //    //{
        //    //    // Check if the current row is the selected row
        //    //    if (rowV.RowIndex == jQueryProductGridView.SelectedIndex)
        //    //    {
        //    //        // If it's the selected row, keep it visible
        //    //        rowV.Visible = true;
        //    //    }
        //    //    else
        //    //    {
        //    //        // If it's not the selected row, hide it
        //    //        rowV.Visible = false;
        //    //    }
        //    //}

        //    ////
        //}



        protected void jQueryProductGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = jQueryProductGridView.SelectedRow;

            Product_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
            Product_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
            Product_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);

            // ProductGroup_Name to ProductGroup_ID
            string productGroupName = row.Cells[5].Text;
            string com = $"select prod_Grp_Id from tbl_productGroup where prod_Grp_Name=@productGroupName";
            using (SqlCommand cmd = new SqlCommand(com, conn.Connection()))
            {
                cmd.Parameters.AddWithValue("@productGroupName", productGroupName);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    string rid = dt2.Rows[0][0].ToString();
                    ProductGroupIdDropDownList.SelectedValue = rid;
                }
            }

            // ProductUnit_Name to ProductUnit_ID
            string productUnitName = row.Cells[6].Text;
            string com2 = $"select unt_Id from tbl_unit where unt_Name=@productUnitName";
            using (SqlCommand cmd2 = new SqlCommand(com2, conn.Connection()))
            {
                cmd2.Parameters.AddWithValue("@productUnitName", productUnitName);
                SqlDataAdapter adpt2 = new SqlDataAdapter(cmd2);
                DataTable dt3 = new DataTable();
                adpt2.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    string rid2 = dt3.Rows[0][0].ToString();
                    ProductUnitIdDropDownList.SelectedValue = rid2;
                }
            }

            // ProductVAT_Name to ProductVAT_ID
            string productVATName = row.Cells[7].Text;
            string com3 = $"select vat_Id from tbl_VAT where vat_Name=@productVATName";
            using (SqlCommand cmd3 = new SqlCommand(com3, conn.Connection()))
            {
                cmd3.Parameters.AddWithValue("@productVATName", productVATName);
                SqlDataAdapter adpt3 = new SqlDataAdapter(cmd3);
                DataTable dt4 = new DataTable();
                adpt3.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    string rid3 = dt4.Rows[0][0].ToString();
                    ProductVATIdDropDownList.SelectedValue = rid3;
                }
            }

            //ProductWasteCode_Name to WasteCode_ID
            string productWasteCodeName = row.Cells[8].Text;
            string com4 = $"select [wasteCode_Id] from [tbl_wasteCode] where [wasteCode_Name]=@productWasteCodeName";
            using (SqlCommand cmd4 = new SqlCommand(com4, conn.Connection()))
            {
                cmd4.Parameters.AddWithValue("@productWasteCodeName", productWasteCodeName);
                SqlDataAdapter adpt4 = new SqlDataAdapter(cmd4);
                DataTable dt5 = new DataTable();
                adpt4.Fill(dt5);
                if (dt5.Rows.Count > 0)
                {
                    string rid4 = dt5.Rows[0][0].ToString();
                    ProductWasteCodeIdDropDownList.SelectedValue = rid4;
                }
            }

            Product_Description_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);
        }


        //protected void prdEditButton_Click(object sender, EventArgs e)
        //{
        //    string productID;
        //    GridViewRow row = jQueryProductGridView.SelectedRow;

        //    if (row != null)
        //    {



        //        productID = row.Cells[1].Text;
        //        string productName = Product_Name_TextBox.Text;
        //        string productName_BG = Product_Name_BG_TextBox.Text;
        //        string productName_TR = Product_Name_TR_TextBox.Text;
        //        string ProductGroupId = ProductGroupIdDropDownList.SelectedValue;
        //        string ProductUnitId = ProductUnitIdDropDownList.SelectedValue;
        //        string ProductVATId = ProductVATIdDropDownList.SelectedValue;
        //        string ProductWasteCodeId = ProductWasteCodeIdDropDownList.SelectedValue;
        //        string productDescription = Product_Description_TextBox.Text;

        //        SqlCommand editProduct = new SqlCommand($"update [tbl_product] set [prod_Name]='{productName}' , [prod_Name_BG]=@bgName, [prod_Name_TR]='{productName_TR}',[prod_Group_Id]='{ProductGroupId}',[prod_Unit_Id]='{ProductUnitId}',[prod_VAT_Id]='{ProductVATId}',[prod_Waste_Code_Id]='{ProductWasteCodeId}',[prod_Description]='{productDescription}' where [prod_Id] = '{productID}'", conn.Connection());
        //        editProduct.Parameters.AddWithValue("@bgName", productName_BG);
        //        editProduct.ExecuteNonQuery();

        //        Response.Redirect("editProduct-ERP.aspx");
        //    }
        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Product for Edit');</script>");
        //    }

        //}


        protected void prdEditButton_Click(object sender, EventArgs e)
        {
            string productID;
            GridViewRow row = jQueryProductGridView.SelectedRow;

            if (row != null)
            {
                productID = row.Cells[1].Text;
                string productName = Product_Name_TextBox.Text;
                string productName_BG = Product_Name_BG_TextBox.Text;
                string productName_TR = Product_Name_TR_TextBox.Text;
                string ProductGroupId = ProductGroupIdDropDownList.SelectedValue;
                string ProductUnitId = ProductUnitIdDropDownList.SelectedValue;
                string ProductVATId = ProductVATIdDropDownList.SelectedValue;
                string ProductWasteCodeId = ProductWasteCodeIdDropDownList.SelectedValue;
                string productDescription = Product_Description_TextBox.Text;

                string query = @"UPDATE [tbl_product] 
                        SET [prod_Name]=@productName, 
                            [prod_Name_BG]=@productName_BG, 
                            [prod_Name_TR]=@productName_TR,
                            [prod_Group_Id]=@ProductGroupId,
                            [prod_Unit_Id]=@ProductUnitId,
                            [prod_VAT_Id]=@ProductVATId,
                            [prod_Waste_Code_Id]=@ProductWasteCodeId,
                            [prod_Description]=@productDescription 
                        WHERE [prod_Id]=@productID";

                using (SqlCommand editProduct = new SqlCommand(query, conn.Connection()))
                {
                    editProduct.Parameters.AddWithValue("@productName", productName);
                    editProduct.Parameters.AddWithValue("@productName_BG", productName_BG);
                    editProduct.Parameters.AddWithValue("@productName_TR", productName_TR);
                    editProduct.Parameters.AddWithValue("@ProductGroupId", ProductGroupId);
                    editProduct.Parameters.AddWithValue("@ProductUnitId", ProductUnitId);
                    editProduct.Parameters.AddWithValue("@ProductVATId", ProductVATId);
                    editProduct.Parameters.AddWithValue("@ProductWasteCodeId", ProductWasteCodeId);
                    editProduct.Parameters.AddWithValue("@productDescription", productDescription);
                    editProduct.Parameters.AddWithValue("@productID", productID);

                    editProduct.ExecuteNonQuery();
                }

                Response.Redirect("editProduct-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Product for Edit');</script>");
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

        protected void prdCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("editProduct-ERP.aspx");
        }
    }
}