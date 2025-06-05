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



namespace polymer_Web_ERP_V4.Maintenance
{
    public partial class AddMachineGroup : System.Web.UI.Page
    {
        //add Data Access object with name conn

       DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            //add if not postback
            if (!IsPostBack)
            {
              
                
            }
        }


        //add gridView bind method for gvMachineGroup my table name is tbl_machineGroup and fileds are machineGroup_ID and machineGroup_Name and machineGroup_Description with using statements for data bas connection an sql command
        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select machineGroup_ID,machineGroup_Name,machineGroup_Description from tbl_machineGroup", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvMachineGroup.DataSource = dt;
                        gvMachineGroup.DataBind();
                    }
                }
            }
        }


        //code prerender event for gridview with using statements for data base connection and sql command
        protected void gvMachineGroup_PreRender(object sender, EventArgs e)
        {
            this.BindGrid();

            // Configure GridView structure
            if (gvMachineGroup.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvMachineGroup.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                gvMachineGroup.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                gvMachineGroup.FooterRow.TableSection = TableRowSection.TableFooter;



            }

        }


        //add button click event for save button with using statements for data base connection and sql command
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("insert into tbl_machineGroup(machineGroup_Name,machineGroup_Description) values('" + txtMachineGroupName.Text + "','" + txtMachineGroupDescription.Text + "')", con))
                {
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindGrid();
                    txtMachineGroupName.Text = string.Empty;
                    txtMachineGroupDescription.Text = string.Empty;
                }
            }
        }


        //add ccancell button click event with clear text boxes
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtMachineGroupName.Text = string.Empty;
            txtMachineGroupDescription.Text = string.Empty;


           
        }




    }
}