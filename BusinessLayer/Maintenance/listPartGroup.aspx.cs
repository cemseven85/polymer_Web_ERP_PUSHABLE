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
using polymer_Web_ERP_V4.Maintenance;

namespace polymer_Web_ERP_V4.BusinessLayer.Maintenance
{
    public partial class listPartGroup : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void gvBind()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT pg.partGroup_ID, pg.partGroup_Name, pg.partGroup_Description, pt.partType_Name FROM tbl_partGroup pg INNER JOIN tbl_partType pt ON pg.partType_ID = pt.partType_ID", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvPartGroup.DataSource = dt;
                        gvPartGroup.DataBind();
                    }
                }
            }
        }

        protected void gvPartGroup_PreRender(object sender, EventArgs e)
        {
            this.gvBind();

            if (gvPartGroup.Rows.Count > 0)
            {
                gvPartGroup.UseAccessibleHeader = true;
                gvPartGroup.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvPartGroup.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}