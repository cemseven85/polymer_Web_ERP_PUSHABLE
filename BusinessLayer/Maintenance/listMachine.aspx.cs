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
    public partial class listMachine : System.Web.UI.Page
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
    }
}