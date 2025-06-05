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
    public partial class edditSellerGroup_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            SellerGroupGridViewBind();
        }

        private void SellerGroupGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listSellerGroup", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQuerySellerGroupGridView.DataSource = dt;
                        jQuerySellerGroupGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQuerySellerGroupGridView.UseAccessibleHeader = true;
            jQuerySellerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void jQuerySellerGroupGridView_PreRender(object sender, EventArgs e)
        {
            this.SellerGroupGridViewBind();

            if (jQuerySellerGroupGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQuerySellerGroupGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQuerySellerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQuerySellerGroupGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void jQuerySellerGroupGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = jQuerySellerGroupGridView.SelectedRow;

            Seller_Group_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
            Seller_Group_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
            Seller_Group_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);
            Seller_Group_Description_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 5);

        }

        //protected void EditButton_Click(object sender, EventArgs e)
        //{
        //    string sellerGroupID;
        //    GridViewRow row = jQuerySellerGroupGridView.SelectedRow;

        //    if(row != null)
        //    {



        //    sellerGroupID = row.Cells[1].Text;
        //    string sellerGroupName = Seller_Group_Name_TextBox.Text;
        //    string sellerGroupName_BG = Seller_Group_Name_BG_TextBox.Text;
        //    string sellerGroupName_TR = Seller_Group_Name_TR_TextBox.Text;            
        //    string sellerGroupDescription = Seller_Group_Description_TextBox.Text;

        //    SqlCommand edditSellerGroup = new SqlCommand($"update [tbl_sellerGroup] set [sell_Grp_Name]='{sellerGroupName}' , [sell_Grp_Name_BG]=@bgName, [sell_Grp_Name_TR]='{sellerGroupName_TR}',[sell_Grp_Description]='{sellerGroupDescription}' where [sell_Grp_Id] = '{sellerGroupID}'", conn.Connection());
        //    edditSellerGroup.Parameters.AddWithValue("@bgName", sellerGroupName_BG);
        //    edditSellerGroup.ExecuteNonQuery();

        //    Response.Redirect("editSellerGroup-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Seller Group for Edit');</script>");
        //    }
        //}

        protected void EditButton_Click(object sender, EventArgs e)
        {
            string sellerGroupID;
            GridViewRow row = jQuerySellerGroupGridView.SelectedRow;

            if (row != null)
            {
                sellerGroupID = row.Cells[1].Text;
                string sellerGroupName = Seller_Group_Name_TextBox.Text;
                string sellerGroupName_BG = Seller_Group_Name_BG_TextBox.Text;
                string sellerGroupName_TR = Seller_Group_Name_TR_TextBox.Text;
                string sellerGroupDescription = Seller_Group_Description_TextBox.Text;

                using (SqlConnection connection = conn.Connection())
                {
                    using (SqlCommand edditSellerGroup = new SqlCommand($"update [tbl_sellerGroup] set [sell_Grp_Name]='{sellerGroupName}' , [sell_Grp_Name_BG]=@bgName, [sell_Grp_Name_TR]='{sellerGroupName_TR}',[sell_Grp_Description]='{sellerGroupDescription}' where [sell_Grp_Id] = '{sellerGroupID}'", connection))
                    {
                        edditSellerGroup.Parameters.AddWithValue("@bgName", sellerGroupName_BG);
                        edditSellerGroup.ExecuteNonQuery();
                    }
                }

                Response.Redirect("editSellerGroup-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Seller Group for Edit');</script>");
            }
        }


    }
}