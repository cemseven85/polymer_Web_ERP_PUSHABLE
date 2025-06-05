using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class addCustomerGroup_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerGroupGridViewBind();
        }

        private void CustomerGroupGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listCustomerGroup", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryCustomerGroupGridView.DataSource = dt;
                        jQueryCustomerGroupGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryCustomerGroupGridView.UseAccessibleHeader = true;
            jQueryCustomerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        //protected void AddButton_Click(object sender, EventArgs e)
        //{
        //    string customerGroupName;
        //    string customerGroupNameBG;
        //    string customerGrouptNameTR;
        //    string customerGroupDescription;

        //    customerGroupName = Customer_Group_Name_TextBox.Text;
        //    customerGroupNameBG = Customer_Group_Name_BG_TextBox.Text;
        //    customerGrouptNameTR = Customer_Group_Name_TR_TextBox.Text;
        //    customerGroupDescription = Customer_Group_Description_TextBox.Text;


        //    SqlCommand addNewProduct = new SqlCommand($"insert into [tbl_customerGroup] ([cust_Grp_Name],[cust_Grp_Name_BG],[cust_Grp_Name_TR],[cust_Grp_Description]) values ('{customerGroupName}',@bgName , '{customerGrouptNameTR}', '{customerGroupDescription}')", conn.Connection());
        //    addNewProduct.Parameters.AddWithValue("@bgName", customerGroupNameBG);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
        //    addNewProduct.ExecuteNonQuery();

        //    Response.Redirect("addCustomerGroup-ERP.aspx");



        //}


        protected void AddButton_Click(object sender, EventArgs e)
        {
            string customerGroupName = Customer_Group_Name_TextBox.Text;
            string customerGroupNameBG = Customer_Group_Name_BG_TextBox.Text;
            string customerGroupNameTR = Customer_Group_Name_TR_TextBox.Text;
            string customerGroupDescription = Customer_Group_Description_TextBox.Text;

            using (SqlConnection connection = conn.Connection())
            {
               

                using (SqlCommand addNewCustomerGroup = new SqlCommand($"INSERT INTO [tbl_customerGroup] ([cust_Grp_Name],[cust_Grp_Name_BG],[cust_Grp_Name_TR],[cust_Grp_Description]) VALUES ('{customerGroupName}',@bgName,'{customerGroupNameTR}','{customerGroupDescription}')", connection))
                {
                    addNewCustomerGroup.Parameters.AddWithValue("@bgName", customerGroupNameBG);
                    addNewCustomerGroup.ExecuteNonQuery();
                }
            }

            Response.Redirect("addCustomerGroup-ERP.aspx");
        }


    }
}