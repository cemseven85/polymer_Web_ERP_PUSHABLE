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
    public partial class editCustomerGroup_ERP : System.Web.UI.Page
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

        protected void jQueryCustomerGroupGridView_PreRender(object sender, EventArgs e)
        {
            this.CustomerGroupGridViewBind();

            if (jQueryCustomerGroupGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryCustomerGroupGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryCustomerGroupGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryCustomerGroupGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void jQueryCustomerGroupGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = jQueryCustomerGroupGridView.SelectedRow;

            Customer_Group_Name_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
            Customer_Group_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
            Customer_Group_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);
            Customer_Group_Description_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 5);

        }

        //protected void EditButton_Click(object sender, EventArgs e)
        //{
        //    string customerGroupID;
        //    GridViewRow row = jQueryCustomerGroupGridView.SelectedRow;

        //    if(row!= null) { 

        //    customerGroupID = row.Cells[1].Text;
        //    string customerGroupName = Customer_Group_Name_TextBox.Text;
        //    string customerGroupName_BG = Customer_Group_Name_BG_TextBox.Text;
        //    string customerGroupName_TR = Customer_Group_Name_TR_TextBox.Text;
        //    string customerGroupDescription = Customer_Group_Description_TextBox.Text;

        //    SqlCommand edditCustomerGroup = new SqlCommand($"update [tbl_customerGroup] set [cust_Grp_Name]='{customerGroupName}' , [cust_Grp_Name_BG]=@bgName, [cust_Grp_Name_TR]='{customerGroupName_TR}',[cust_Grp_Description]='{customerGroupDescription}' where [cust_Grp_Id] = '{customerGroupID}'", conn.Connection());
        //    edditCustomerGroup.Parameters.AddWithValue("@bgName", customerGroupName_BG);
        //    edditCustomerGroup.ExecuteNonQuery();

        //    Response.Redirect("editCustomerGroup-ERP.aspx");

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Customer Group for Edit');</script>");
        //    }

        //}


        protected void EditButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = jQueryCustomerGroupGridView.SelectedRow;

            if (row != null)
            {
                string customerGroupID = row.Cells[1].Text;
                string customerGroupName = Customer_Group_Name_TextBox.Text;
                string customerGroupName_BG = Customer_Group_Name_BG_TextBox.Text;
                string customerGroupName_TR = Customer_Group_Name_TR_TextBox.Text;
                string customerGroupDescription = Customer_Group_Description_TextBox.Text;

                using (SqlConnection connection = conn.Connection())
                {
                    using (SqlCommand edditCustomerGroup = new SqlCommand($"UPDATE [tbl_customerGroup] SET [cust_Grp_Name]=@customerGroupName, [cust_Grp_Name_BG]=@bgName, [cust_Grp_Name_TR]=@customerGroupName_TR, [cust_Grp_Description]=@customerGroupDescription WHERE [cust_Grp_Id]=@customerGroupID", connection))
                    {
                        edditCustomerGroup.Parameters.AddWithValue("@customerGroupName", customerGroupName);
                        edditCustomerGroup.Parameters.AddWithValue("@bgName", customerGroupName_BG);
                        edditCustomerGroup.Parameters.AddWithValue("@customerGroupName_TR", customerGroupName_TR);
                        edditCustomerGroup.Parameters.AddWithValue("@customerGroupDescription", customerGroupDescription);
                        edditCustomerGroup.Parameters.AddWithValue("@customerGroupID", customerGroupID);
                        edditCustomerGroup.ExecuteNonQuery();
                    }
                }

                Response.Redirect("editCustomerGroup-ERP.aspx");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('You need to select Customer Group for Edit');</script>");
            }
        }


    }
}