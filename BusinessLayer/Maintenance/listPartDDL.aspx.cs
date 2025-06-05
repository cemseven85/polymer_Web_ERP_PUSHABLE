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
using OfficeOpenXml;
using System.Globalization;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace polymer_Web_ERP_V4.BusinessLayer.Maintenance
{
    public partial class listPartDDL : System.Web.UI.Page
    {
        //add Data Access object with name conn
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindDropdowns();
                //BindGrid();
            }


        }

        private void BindGrid(string filterText = null)
        {
            using (SqlConnection con = conn.Connection())
            {
                string query = "SELECT part_ID, part_Name, part_Description, machine_Name, partGroup_Name, part_Code, part_BarCode, machineGroup_Name, partType_Name FROM tbl_part INNER JOIN tbl_machine ON tbl_part.machine_ID = tbl_machine.machine_ID INNER JOIN tbl_partGroup ON tbl_part.partGroup_ID = tbl_partGroup.partGroup_ID INNER JOIN tbl_machineGroup ON tbl_machine.machineGroup_ID = tbl_machineGroup.machineGroup_ID INNER JOIN tbl_partType ON tbl_partGroup.partType_ID = tbl_partType.partType_ID";



                if (!string.IsNullOrEmpty(filterText))
                {
                    // Add a WHERE clause to your query to filter the results
                    query += " WHERE part_Name LIKE @filter OR part_Description LIKE @filter OR machine_Name LIKE @filter OR partGroup_Name LIKE @filter OR part_Code LIKE @filter OR part_BarCode LIKE @filter OR machineGroup_Name LIKE @filter OR partType_Name LIKE @filter";
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(filterText))
                    {
                        // Add the filter parameter
                        cmd.Parameters.AddWithValue("@filter", "%" + filterText + "%");
                    }

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
            // Get the filter text from the ViewState
            string filterText = ViewState["FilterText"] as string;

            // Call BindGrid() with the filter text
            BindGrid(filterText);

           

            // Call BindDropdowns() after the GridView has been bound
            BindDropdowns();

            // Find the DropDownList and restore the selected value from the ViewState
            DropDownList ddlPartType = gvPart.HeaderRow?.FindControl("ddlPartType_Filter") as DropDownList;
            if (ddlPartType != null && ViewState["SelectedValue"] != null && ddlPartType.Items.FindByValue(ViewState["SelectedValue"].ToString()) != null)
            {
                ddlPartType.SelectedValue = ViewState["SelectedValue"].ToString();
            }


            // Restore the text of the TextBox from the ViewState
            foreach (TableCell cell in gvPart.HeaderRow.Cells)
            {
                TextBox textBox = cell.Controls.OfType<TextBox>().FirstOrDefault();
                if (textBox != null && ViewState[textBox.ID] != null)
                {
                    textBox.Text = ViewState[textBox.ID].ToString();
                }
            }

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

        //Deneme drop Down List 

        private void BindDropdowns()
        {
            using (SqlConnection con = conn.Connection())
            {
                
                // Example for populating Part Types
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT partType_Name FROM tbl_partType", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                DropDownList ddlPartType = gvPart.HeaderRow?.FindControl("ddlPartType_Filter") as DropDownList;
                if (ddlPartType != null)
                {
                    ddlPartType.DataSource = ds;
                    ddlPartType.DataTextField = "partType_Name";
                    ddlPartType.DataValueField = "partType_Name";
                    ddlPartType.DataBind();
                    ddlPartType.Items.Insert(0, new ListItem("--Select Part Type--", ""));
                }

                con.Close();
            }
        }


        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            string filterText = ddl.SelectedValue;

            // Store the filter text in the ViewState
            ViewState["FilterText"] = filterText;

            // Store the selected value in the ViewState
            ViewState["SelectedValue"] = ddl.SelectedValue;


            BindGrid(filterText);
        }


        protected void txtFilter_TextChanged(object sender, EventArgs e)
        {
            // Get the TextBox that raised the event
            TextBox txtFilter = (TextBox)sender;

            // Get the filter text from the TextBox
            string filterText = txtFilter.Text;

            // Store the filter text in the ViewState
            ViewState["FilterText"] = filterText;

            // Call BindGrid() with the filter text
            BindGrid(filterText);

            // Store the text of the TextBox in the ViewState
            ViewState[txtFilter.ID] = txtFilter.Text;
        }
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            Response.Redirect("listPart.aspx");
        }



        protected void btnSelect_Click(object sender, EventArgs e)
        {
            // Get the button that raised the event
            Button btnSelect = (Button)sender;

            // Find the row that contains the button
            GridViewRow gvr = (GridViewRow)btnSelect.NamingContainer;

            // Find the label that contains the part_ID
            Label lblPartID = (Label)gvr.FindControl("lblPart_ID");

            // Redirect to another page with the Part ID and a boolean value
            bool isEdit = false; // replace with your actual boolean value
            Response.Redirect("partImgModule.aspx?partID=" + lblPartID.Text + "&isEdit=" + isEdit.ToString());



        }
    }
}