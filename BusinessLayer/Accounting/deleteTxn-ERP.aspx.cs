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

namespace polymer_Web_ERP_V4
{
    public partial class deleteTxn_ERP : System.Web.UI.Page
    {

        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateMax = DateTime.Now;
            DateTime dateMin = dateMax.AddDays(-390);

            if (!this.IsPostBack)
            {
                ItemDateMin_TextBox.Text = dateMin.ToString("yyyy-MM-dd");
                ItemDateMax_TextBox.Text = dateMax.ToString("yyyy-MM-dd");

                jQueryList_Txn_GridViewBind();
            }


        }




        private void jQueryList_Txn_GridViewBind()
        {

            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listTxn '{ItemDateMin_TextBox.Text}', '{ItemDateMax_TextBox.Text}'", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryList_Txn_GridView.DataSource = dt;
                        jQueryList_Txn_GridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryList_Txn_GridView.UseAccessibleHeader = true;
            jQueryList_Txn_GridView.HeaderRow.TableSection = TableRowSection.TableHeader;




        }


        protected void jQueryList_Txn_GridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryList_Txn_GridViewBind();

            // Configure GridView structure
            if (jQueryList_Txn_GridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryList_Txn_GridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryList_Txn_GridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryList_Txn_GridView.FooterRow.TableSection = TableRowSection.TableFooter;

                // Check if a row is selected
                if (jQueryList_Txn_GridView.SelectedIndex >= 0)
                {
                    // Hide other rows if a row is selected
                    HideOtherRows();
                }
                else
                {
                    // If no row is selected, ensure all rows are visible
                    foreach (GridViewRow row in jQueryList_Txn_GridView.Rows)
                    {
                        row.Visible = true;
                    }
                }
            }

        }
        protected void Show_Txn_List_Button_Click(object sender, EventArgs e)
        {
            jQueryList_Txn_GridViewBind();
        }



        // Change for Using Statement 

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    if (jQueryList_Txn_GridView.SelectedIndex >= 0)
        //    {

        //        GridViewRow rowDelete = jQueryList_Txn_GridView.SelectedRow;

        //        string controlType= rowDelete.Cells[4].Text;
        //        string txnID= rowDelete.Cells[1].Text;


        //        if(controlType== "Bank  Movements"||controlType== "Case Movements")
        //        {

        //            // DELETE The related TXN Rows

        //            SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txnID}'", conn.Connection());
        //            cmd.ExecuteNonQuery();

        //            if (conn != null)
        //            {
        //                conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //            }


        //            Response.Redirect("deleteTxn-ERP.aspx");
        //        }
        //        else
        //        {
        //            Response.Write($"<script type=\"text/javascript\">alert('You need to go {controlType} Module for DELETE');</script>");
        //        }

        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Txn for DELETE');</script>");
        //    }


        //}


        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (jQueryList_Txn_GridView.SelectedIndex >= 0)
            {
                GridViewRow rowDelete = jQueryList_Txn_GridView.SelectedRow;
                string controlType = rowDelete.Cells[4].Text;
                string txnID = rowDelete.Cells[1].Text;

                if (controlType == "Bank  Movements" || controlType == "Case Movements")
                {
                    // DELETE The related TXN Rows
                    using (SqlConnection sqlConn = conn.Connection())
                    {
                        SqlCommand cmd = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txnID}'", sqlConn);
                        cmd.ExecuteNonQuery();
                    }

                    Response.Redirect("deleteTxn-ERP.aspx");
                }
                else
                {
                    Response.Write($"<script type=\"text/javascript\">alert('You need to go {controlType} Module for DELETE');</script>");
                }
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Txn for DELETE');</script>");
            }
        }






        protected void CancelButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("deleteTxn-ERP.aspx");


        }


        private void HideOtherRows()
        {
            foreach (GridViewRow row in jQueryList_Txn_GridView.Rows)
            {
                if (row.RowIndex != jQueryList_Txn_GridView.SelectedIndex)
                {
                    row.Visible = false;
                }
            }
        }

    }
}