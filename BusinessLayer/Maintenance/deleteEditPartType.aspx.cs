using polymer_Web_ERP_V4.Productivity;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Drawing;

using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;   // From Here Name Spaces Are For Exel File Transfer 
using Excel = Microsoft.Office.Interop.Excel;  //Before  Excel =   Data Tables And Exels Send Error. 
using System.Globalization;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace polymer_Web_ERP_V4.BusinessLayer.Maintenance
{
    public partial class deleteEditPartType : System.Web.UI.Page
    {
        //add Data Access object with name conn

        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        //add gridView bind method for gvPartType my table name is tbl_machineGroup and fileds are machineGroup_ID and machineGroup_Name and machineGroup_Description with using statements for data bas connection an sql command
        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select partType_ID,partType_Name,partType_Description from tbl_partType", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvPartType.DataSource = dt;
                        gvPartType.DataBind();
                    }
                }
            }
        }

        //code prerender event for gridview with using statements for data base connection and sql command
        protected void gvPartType_PreRender(object sender, EventArgs e)
        {
            this.BindGrid();

            // Configure GridView structure
            if (gvPartType.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvPartType.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                gvPartType.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                gvPartType.FooterRow.TableSection = TableRowSection.TableFooter;



            }

        }







        //code for delete button click event with using statements for data base connection and sql command
        protected void gvPartType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblPartType_ID = (Label)gvPartType.Rows[e.RowIndex].FindControl("lblPartType_ID");
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("delete from tbl_partType where partType_ID='" + lblPartType_ID.Text + "'", con))
                {
                    cmd.ExecuteNonQuery();
                    gvPartType.EditIndex = -1;
                    this.BindGrid();
                }
            }
        }

        //code for edit button click event with using statements for data base connection and sql command
        protected void gvPartType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPartType.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        //code for cancel button click event with using statements for data base connection and sql command
        protected void gvPartType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPartType.EditIndex = -1;
            this.BindGrid();
        }



        //code for update button click event with using statements for data base connection and sql command
        protected void gvPartType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblPartType_ID = (Label)gvPartType.Rows[e.RowIndex].FindControl("lblPartType_ID");
            TextBox txtPartType_Name = (TextBox)gvPartType.Rows[e.RowIndex].FindControl("txtPartType_Name");
            TextBox txtPartType_Description = (TextBox)gvPartType.Rows[e.RowIndex].FindControl("txtPartType_Description");

            string partTypeName = txtPartType_Name?.Text ?? string.Empty;
            string partTypeDescription = txtPartType_Description?.Text ?? string.Empty;

            using (SqlConnection con = conn.Connection())
            {

                using (SqlCommand cmd = new SqlCommand("update tbl_partType set partType_Name='" + partTypeName + "',partType_Description='" + partTypeDescription + "' where partType_ID='" + lblPartType_ID.Text + "'", con))
                {
                    cmd.ExecuteNonQuery();
                    gvPartType.EditIndex = -1;
                    this.BindGrid();
                }
            }
        }





    }
}