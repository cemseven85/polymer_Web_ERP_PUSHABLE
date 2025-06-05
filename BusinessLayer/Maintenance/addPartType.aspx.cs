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
    public partial class addPartType : System.Web.UI.Page
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

        //add gridView bind method for gvPartType my table name is tbl_partType and fields are partType_ID, partType_Name, and partType_Description with using statements for database connection and SQL command
        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select partType_ID, partType_Name, partType_Description from tbl_partType", con))
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

        //code prerender event for gridview with using statements for database connection and SQL command
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

        //add button click event for save button with using statements for database connection and SQL command
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("insert into tbl_partType(partType_Name, partType_Description) values('" + txtPartTypeName.Text + "','" + txtPartTypeDescription.Text + "')", con))
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindGrid();
                    txtPartTypeName.Text = string.Empty;
                    txtPartTypeDescription.Text = string.Empty;
                }
            }
        }

        //add cancel button click event with clear text boxes
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPartTypeName.Text = string.Empty;
            txtPartTypeDescription.Text = string.Empty;
        }
    }
}