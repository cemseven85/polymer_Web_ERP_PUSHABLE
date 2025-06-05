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
    public partial class partModul : System.Web.UI.Page
    {

        //add Data Access object with name conn

        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT part_ID, part_Name, part_Description, machine_Name, partGroup_Name FROM tbl_part INNER JOIN tbl_machine ON tbl_part.machine_ID = tbl_machine.machine_ID INNER JOIN tbl_partGroup ON tbl_part.partGroup_ID = tbl_partGroup.partGroup_ID", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvPart.DataSource = dt;
                        gvPart.DataBind();
                    }
                }
            }
        }


        //write a prerender method for bind grid view
        protected void gvPart_PreRender(object sender, EventArgs e)
        {
            this.BindGrid();

            // Configure GridView structure
            if (gvPart.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvPart.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                gvPart.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                gvPart.FooterRow.TableSection = TableRowSection.TableFooter;



            }
        }

        //Write code for save button click event with using statements for data base connection and sql command
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_part (part_Name, part_Description, machine_ID, partGroup_ID) VALUES (@part_Name, @part_Description, @machine_ID, @partGroup_ID)", con))
                {
                    cmd.Parameters.AddWithValue("@part_Name", txtPartName.Text);
                    cmd.Parameters.AddWithValue("@part_Description", txtPartDescription.Text);
                    cmd.Parameters.AddWithValue("@machine_ID", ddlMachineID.SelectedValue);
                    cmd.Parameters.AddWithValue("@partGroup_ID", ddlPartGroupID.SelectedValue);
                    cmd.ExecuteNonQuery();
                    this.BindGrid();
                }
            }
        }


        //write code for cancel button click event
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPartName.Text = string.Empty;
            txtPartDescription.Text = string.Empty;
            ddlMachineID.SelectedIndex = 0;
            ddlPartGroupID.SelectedIndex = 0;
        }

        //code for gridview row editing event with using statements for data base connection and sql command
        protected void gvPart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPart.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        //Wite a function to get machine from database
        private DataTable GetMachine()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT machine_ID, machine_Name FROM tbl_machine", con))
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


        // Write a function to get machine ID based on machine name
        private int GetMachineID(string machineName)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT machine_ID FROM tbl_machine WHERE machine_Name = @machineName", con))
                {
                    cmd.Parameters.AddWithValue("@machineName", machineName);
                    
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        //Wite a function to get partGroup from database
        private DataTable GetPartGroup()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT partGroup_ID, partGroup_Name FROM tbl_partGroup", con))
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


        // Write a function to get partGroup ID based on partGroup name
        private int GetPartGroupID(string partGroupName)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT partGroup_ID FROM tbl_partGroup WHERE partGroup_Name = @partGroupName", con))
                {
                    cmd.Parameters.AddWithValue("@partGroupName", partGroupName);
                    
                    return (int)cmd.ExecuteScalar();
                }
            }
        }


        //code for rowdatabound event of grid view with using statements for data base connection and sql command
        protected void gvPart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvPart.EditIndex == e.Row.RowIndex)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    // Get the DropDownList control from the row in edit mode
                    DropDownList ddlMachineID = (DropDownList)e.Row.FindControl("ddlMachine_ID");
                    DropDownList ddlPartGroupID = (DropDownList)e.Row.FindControl("ddlPartGroup_ID");

                    // Populate the DropDownList with machine names
                    ddlMachineID.DataSource = GetMachine(); // Function to get machine groups from database
                    ddlMachineID.DataTextField = "machine_Name";
                    ddlMachineID.DataValueField = "machine_ID";
                    ddlMachineID.DataBind();

                    // Set the selected value of the DropDownList to the current machine
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    string machineName = dr["machine_Name"].ToString();

                    // Find the corresponding machine_ID based on the machineName
                    int machineID = GetMachineID(machineName);

                    // Set the selected value of the DropDownList to the machine_ID
                    ddlMachineID.SelectedValue = machineID.ToString();

                    // Populate the DropDownList with partGroup names
                    ddlPartGroupID.DataSource = GetPartGroup(); // Function to get machine groups from database
                    ddlPartGroupID.DataTextField = "partGroup_Name";
                    ddlPartGroupID.DataValueField = "partGroup_ID";
                    ddlPartGroupID.DataBind();

                    // Set the selected value of the DropDownList to the current partGroup
                    string partGroupName = dr["partGroup_Name"].ToString();

                    // Find the corresponding partGroup_ID based on the partGroupName
                    int partGroupID = GetPartGroupID(partGroupName);

                    // Set the selected value of the DropDownList to the partGroup_ID
                    ddlPartGroupID.SelectedValue = partGroupID.ToString();

                }
            }
        }


        //code for row edit cancel event with using statements for data base connection and sql command
        protected void gvPart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPart.EditIndex = -1;
            this.BindGrid();
        }



        //code for row updating event with using statements for data base connection and sql command
        protected void gvPart_RowUpdatig(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_part SET part_Name = @part_Name, part_Description = @part_Description, machine_ID = @machine_ID, partGroup_ID = @partGroup_ID WHERE part_ID = @part_ID", con))
                {
                    cmd.Parameters.AddWithValue("@part_Name", (gvPart.Rows[e.RowIndex].FindControl("txtPart_Name") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@part_Description", (gvPart.Rows[e.RowIndex].FindControl("txtPart_Description") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@machine_ID", (gvPart.Rows[e.RowIndex].FindControl("ddlMachine_ID") as DropDownList).SelectedValue);
                    cmd.Parameters.AddWithValue("@partGroup_ID", (gvPart.Rows[e.RowIndex].FindControl("ddlPartGroup_ID") as DropDownList).SelectedValue);
                    cmd.Parameters.AddWithValue("@part_ID", gvPart.DataKeys[e.RowIndex].Value);
                    cmd.ExecuteNonQuery();
                    gvPart.EditIndex = -1;
                    this.BindGrid();
                }
            }
        }







        //code for row deleting event with using statements for data base connection and sql command
        protected void gvPart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_part WHERE part_ID = @part_ID", con))
                {
                    cmd.Parameters.AddWithValue("@part_ID", gvPart.DataKeys[e.RowIndex].Value);
                    cmd.ExecuteNonQuery();
                    this.BindGrid();
                }
            }
        }

    }
}