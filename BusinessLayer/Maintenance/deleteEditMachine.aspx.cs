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
    public partial class deleteEditMachine : System.Web.UI.Page
    {



        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //add gvBind() method for bind data to gridview gvMachine with using statements for data base connection and sql command
        private void gvBind()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select m.machine_ID, m.machine_Name, m.machine_Description, mg.machineGroup_Name from tbl_machine m inner join tbl_machineGroup mg on m.machineGroup_ID = mg.machineGroup_ID", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        sda.Fill(dt);
                        gvMachine.DataSource = dt;
                        gvMachine.DataBind();
                    }
                }
            }
        }

        //code for gridview prerender event with using statements for data base connection and sql command
        protected void gvMachine_PreRender(object sender, EventArgs e)
        {
            this.gvBind();

            // Configure GridView structure
            if (gvMachine.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvMachine.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                gvMachine.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                gvMachine.FooterRow.TableSection = TableRowSection.TableFooter;



            }
        }

        //code for gridview row editing event with using statements for data base connection and sql command
        protected void gvMachine_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMachine.EditIndex = e.NewEditIndex;
            gvBind();
        }


        //Wite a function to get machine groups from database
        private DataTable GetMachineGroups()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select machineGroup_ID, machineGroup_Name from tbl_machineGroup", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void gvMachine_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvMachine.EditIndex == e.Row.RowIndex)
            {
                //if (e.Row.RowState == DataControlRowState.Edit)  This is not working throw false value if row is even in edit mode
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    // Get the DropDownList control from the row in edit mode
                    DropDownList ddlMachineGroup = (DropDownList)e.Row.FindControl("ddlMachineGroup");

                    // Populate the DropDownList with machine group names
                    ddlMachineGroup.DataSource = GetMachineGroups(); // Function to get machine groups from database
                    ddlMachineGroup.DataTextField = "machineGroup_Name";
                    ddlMachineGroup.DataValueField = "machineGroup_ID";
                    ddlMachineGroup.DataBind();

                    // Set the selected value of the DropDownList to the current machine group
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    string machineGroupName = dr["machineGroup_Name"].ToString();

                    // Find the corresponding machineGroup_ID based on the machineGroupName
                    int machineGroupID = GetMachineGroupID(machineGroupName);

                    // Set the selected value of the DropDownList to the machineGroup_ID
                    ddlMachineGroup.SelectedValue = machineGroupID.ToString();



                }
            }
        }


        // Write a function to get machine group ID based on machine group name
        private int GetMachineGroupID(string machineGroupName)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select machineGroup_ID from tbl_machineGroup where machineGroup_Name = @machineGroupName", con))
                {
                    cmd.Parameters.AddWithValue("@machineGroupName", machineGroupName);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        //code for row edit cancel event with using statements for data base connection and sql command
        protected void gvMachine_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMachine.EditIndex = -1;
            gvBind();
        }

        //code for row updating event with using statements for data base connection and sql command
        protected void gvMachine_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int machineID = Convert.ToInt32(gvMachine.DataKeys[e.RowIndex].Values[0]);
            TextBox txtMachineName = (TextBox)gvMachine.Rows[e.RowIndex].FindControl("txtMachine_Name");
            TextBox txtMachineDescription = (TextBox)gvMachine.Rows[e.RowIndex].FindControl("txtMachine_Description");
            DropDownList ddlMachineGroup = (DropDownList)gvMachine.Rows[e.RowIndex].FindControl("ddlMachineGroup");

            // Update the machine record in the database
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("update tbl_machine set machine_Name = @machineName, machine_Description = @machineDescription, machineGroup_ID = @machineGroupID where machine_ID = @machineID", con))
                {
                    cmd.Parameters.AddWithValue("@machineName", txtMachineName.Text);
                    cmd.Parameters.AddWithValue("@machineDescription", txtMachineDescription.Text);
                    cmd.Parameters.AddWithValue("@machineGroupID", ddlMachineGroup.SelectedValue);
                    cmd.Parameters.AddWithValue("@machineID", machineID);
                    cmd.ExecuteNonQuery();
                }
            }

            gvMachine.EditIndex = -1;
            gvBind();
        }

        //add row deleting event with using statements for data base connection and sql command
        protected void gvMachine_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int machineID = Convert.ToInt32(gvMachine.DataKeys[e.RowIndex].Values[0]);

            // Delete the machine record from the database
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("delete from tbl_machine where machine_ID = @machineID", con))
                {
                    cmd.Parameters.AddWithValue("@machineID", machineID);
                    cmd.ExecuteNonQuery();
                }
            }

            gvBind();
        }


    }
}