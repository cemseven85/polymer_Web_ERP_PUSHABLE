using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4.BusinessLayer.Maintenance
{
    public partial class listPartDLLM : System.Web.UI.Page
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

        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                string query = "SELECT part_ID, part_Name, part_Description, machine_Name, partGroup_Name, part_Code, part_BarCode, machineGroup_Name, partType_Name FROM tbl_part INNER JOIN tbl_machine ON tbl_part.machine_ID = tbl_machine.machine_ID INNER JOIN tbl_partGroup ON tbl_part.partGroup_ID = tbl_partGroup.partGroup_ID INNER JOIN tbl_machineGroup ON tbl_machine.machineGroup_ID = tbl_machineGroup.machineGroup_ID INNER JOIN tbl_partType ON tbl_partGroup.partType_ID = tbl_partType.partType_ID";

                using (SqlCommand cmd = new SqlCommand(query, con))
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
            

            // Call BindGrid() with the filter text
            BindGrid();


           

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