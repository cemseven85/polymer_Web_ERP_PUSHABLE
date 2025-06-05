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
    public partial class deleteEditPartGroup : System.Web.UI.Page
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

        protected void gvPartGroup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPartGroup.EditIndex = e.NewEditIndex;
            gvBind();
        }

        protected void gvPartGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvPartGroup.EditIndex == e.Row.RowIndex)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlPartType = (DropDownList)e.Row.FindControl("ddlPartType");
                    ddlPartType.DataSource = GetPartTypes();
                    ddlPartType.DataTextField = "partType_Name";
                    ddlPartType.DataValueField = "partType_ID";
                    ddlPartType.DataBind();

                    DataRowView dr = e.Row.DataItem as DataRowView;
                    string partTypeName = dr["partType_Name"].ToString();
                    int partTypeID = GetPartTypeID(partTypeName);
                    ddlPartType.SelectedValue = partTypeID.ToString();


                  

                }
            }
        }


        private DataTable GetPartTypes()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select partType_ID, partType_Name from tbl_partType", con))
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

        private int GetPartTypeID(string partTypeName)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("select partType_ID from tbl_partType where partType_Name = @partTypeName", con))
                {
                    cmd.Parameters.AddWithValue("@partTypeName", partTypeName);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        protected void gvPartGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPartGroup.EditIndex = -1;
            gvBind();
        }


        protected void gvPartGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int partGroupID = Convert.ToInt32(gvPartGroup.DataKeys[e.RowIndex].Values[0]);
            TextBox txtPartGroupName = (TextBox)gvPartGroup.Rows[e.RowIndex].FindControl("txtPartGroup_Name");
            TextBox txtPartGroupDescription = (TextBox)gvPartGroup.Rows[e.RowIndex].FindControl("txtPartGroup_Description");
            DropDownList ddlPartType = (DropDownList)gvPartGroup.Rows[e.RowIndex].FindControl("ddlPartType");

            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("update tbl_partGroup set partGroup_Name = @partGroupName, partGroup_Description = @partGroupDescription, partType_ID = @partTypeID where partGroup_ID = @partGroupID", con))
                {
                    cmd.Parameters.AddWithValue("@partGroupName", txtPartGroupName.Text);
                    cmd.Parameters.AddWithValue("@partGroupDescription", txtPartGroupDescription.Text);
                    cmd.Parameters.AddWithValue("@partTypeID", ddlPartType.SelectedValue);
                    cmd.Parameters.AddWithValue("@partGroupID", partGroupID);
                    cmd.ExecuteNonQuery();
                }
            }

            gvPartGroup.EditIndex = -1;
            gvBind();
        }

        protected void gvPartGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int partGroupID = Convert.ToInt32(gvPartGroup.DataKeys[e.RowIndex].Values[0]);

            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("delete from tbl_partGroup where partGroup_ID = @partGroupID", con))
                {
                    cmd.Parameters.AddWithValue("@partGroupID", partGroupID);
                    cmd.ExecuteNonQuery();
                }
            }

            gvBind();
        }

    }
}