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
    public partial class addMachine : System.Web.UI.Page
    {

        //add Data Access object with name conn

        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        //add gridView bind method for gvMachine my table name is tbl_machine and fileds are machine_ID and machine_Name and machine_Description and machineGroup_ID with using statements for data bas connection an sql command
        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select machine_ID,machine_Name,machine_Description,(SELECT machineGroup_Name FROM tbl_machineGroup WHERE tbl_machineGroup.machineGroup_ID = tbl_machine.machineGroup_ID) AS machineGroup_Name from tbl_machine", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvMachine.DataSource = dt;
                        gvMachine.DataBind();
                    }
                }
            }
        }


        //write a prerender method for bind grid view
        protected void gvMachine_PreRender(object sender, EventArgs e)
        {
            this.BindGrid();

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

        //Write code for save button click event with using statements for data base connection and sql command
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("insert into tbl_machine(machine_Name, machine_Description, machineGroup_ID) values('" + txtMachineName.Text + "','" + txtMachineDescription.Text + "','" + ddlMachineGroup.SelectedValue + "')", con))
                {
                    cmd.ExecuteNonQuery();
                    txtMachineName.Text = string.Empty;
                    txtMachineDescription.Text = string.Empty;
                    ddlMachineGroup.SelectedIndex = 0;
                }
            }
        }


        //write code for cancel button click event
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtMachineName.Text = string.Empty;
            txtMachineDescription.Text = string.Empty;
            ddlMachineGroup.SelectedIndex = 0;
        }


    }
}