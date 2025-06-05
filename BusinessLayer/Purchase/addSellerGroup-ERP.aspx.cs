using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using polymer_Web_ERP_V4.Data_Access_Layer;

namespace polymer_Web_ERP_V4
{
    public partial class addSellerGroup_ERP : System.Web.UI.Page
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

        //protected void AddButton_Click(object sender, EventArgs e)
        //{
        //    string sellerGroupName;
        //    string sellerGroupNameBG;
        //    string sellerGrouptNameTR;
        //    string sellerGroupDescription;

        //    sellerGroupName = Seller_Group_Name_TextBox.Text;
        //    sellerGroupNameBG = Seller_Group_Name_BG_TextBox.Text;
        //    sellerGrouptNameTR = Seller_Group_Name_TR_TextBox.Text;
        //    sellerGroupDescription = Seller_Group_Description_TextBox.Text;


        //    SqlCommand addNewProduct = new SqlCommand($"insert into [tbl_sellerGroup] ([sell_Grp_Name],[sell_Grp_Name_BG],[sell_Grp_Name_TR],[sell_Grp_Description]) values ('{sellerGroupName}',@bgName , '{sellerGrouptNameTR}', '{sellerGroupDescription}')", conn.Connection());
        //    addNewProduct.Parameters.AddWithValue("@bgName", sellerGroupNameBG);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
        //    addNewProduct.ExecuteNonQuery();

        //    Response.Redirect("addSellerGroup-ERP.aspx");



        //}



        protected void AddButton_Click(object sender, EventArgs e)
        {
            string sellerGroupName = Seller_Group_Name_TextBox.Text;
            string sellerGroupNameBG = Seller_Group_Name_BG_TextBox.Text;
            string sellerGroupNameTR = Seller_Group_Name_TR_TextBox.Text;
            string sellerGroupDescription = Seller_Group_Description_TextBox.Text;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand addNewSellerGroup = new SqlCommand("INSERT INTO [tbl_sellerGroup] ([sell_Grp_Name],[sell_Grp_Name_BG],[sell_Grp_Name_TR],[sell_Grp_Description]) " +
                    "VALUES (@GroupName, @GroupNameBG, @GroupNameTR, @Description)", connection))
                {
                    addNewSellerGroup.Parameters.AddWithValue("@GroupName", sellerGroupName);
                    addNewSellerGroup.Parameters.AddWithValue("@GroupNameBG", sellerGroupNameBG);
                    addNewSellerGroup.Parameters.AddWithValue("@GroupNameTR", sellerGroupNameTR);
                    addNewSellerGroup.Parameters.AddWithValue("@Description", sellerGroupDescription);
                    addNewSellerGroup.ExecuteNonQuery();
                }
            }

            Response.Redirect("addSellerGroup-ERP.aspx");
        }



    }
}