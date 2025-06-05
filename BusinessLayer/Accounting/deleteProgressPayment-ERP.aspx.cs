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
    public partial class deleteProgressPayment_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataKeyCheckBox.Visible = false;
                DetailCheckBox.Visible = false;

                DataKeyCheckBox.Checked = false;
                DetailCheckBox.Checked = false;
            }


        }



        private void jQueryRelated_Month_Progress_Payment_GridViewBind()
        {

            string earnedMonth = Related_Progress_MonthTextBox.Text;


            // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_monthlyProgressPayment '{earnedMonth}'", con))   //Note we add the Invoice Detail Row In This Procedure !!!
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryRelated_Month_Progress_Payment_GridView.DataSource = dt;
                        jQueryRelated_Month_Progress_Payment_GridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryRelated_Month_Progress_Payment_GridView.UseAccessibleHeader = true;
            jQueryRelated_Month_Progress_Payment_GridView.HeaderRow.TableSection = TableRowSection.TableHeader;


            ToggleFourthColumnVisibility();

            DetailColumnsVisibility();

        }



        protected void jQueryRelated_Month_Progress_Payment_GridView_PreRender(object sender, EventArgs e)
        {
            this.jQueryRelated_Month_Progress_Payment_GridViewBind();

            //if (jQueryRelated_Month_Progress_Payment_GridView.Rows.Count > 0)
            //{
            //    //This replaces <td> with <th> and adds the scope attribute
            //    jQueryRelated_Month_Progress_Payment_GridView.UseAccessibleHeader = true;

            //    //This will add the <thead> and <tbody> elements
            //    jQueryRelated_Month_Progress_Payment_GridView.HeaderRow.TableSection = TableRowSection.TableHeader;

            //    //This adds the <tfoot> element.
            //    //Remove if you don't have a footer row
            //    jQueryRelated_Month_Progress_Payment_GridView.FooterRow.TableSection = TableRowSection.TableFooter;
            //}

            // Configure GridView structure
            if (jQueryRelated_Month_Progress_Payment_GridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryRelated_Month_Progress_Payment_GridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryRelated_Month_Progress_Payment_GridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryRelated_Month_Progress_Payment_GridView.FooterRow.TableSection = TableRowSection.TableFooter;

                // Check if a row is selected
                if (jQueryRelated_Month_Progress_Payment_GridView.SelectedIndex >= 0)
                {
                    // Hide other rows if a row is selected
                    HideOtherRows();
                }
                else
                {
                    // If no row is selected, ensure all rows are visible
                    foreach (GridViewRow row in jQueryRelated_Month_Progress_Payment_GridView.Rows)
                    {
                        row.Visible = true;
                    }
                }
            }


        }







        protected void Show_Progress_Payment_Button_Click(object sender, EventArgs e)
        {
            jQueryRelated_Month_Progress_Payment_GridViewBind();

            DataKeyCheckBox.Visible = true;
            DetailCheckBox.Visible = true;

        }

        private void ToggleFourthColumnVisibility()
        {
            /// Change the visibility of the 4th column based on the CheckBox state

            bool control = DataKeyCheckBox.Checked;

            jQueryRelated_Month_Progress_Payment_GridView.Columns[1].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[3].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[4].Visible = control;
           
            jQueryRelated_Month_Progress_Payment_GridView.Columns[21].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[22].Visible = control;

        }


        private void DetailColumnsVisibility()
        {
            /// Change the visibility of the 4th column based on the CheckBox state

            bool control = DetailCheckBox.Checked;

            jQueryRelated_Month_Progress_Payment_GridView.Columns[5].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[7].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[13].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[14].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[15].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[16].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[17].Visible = control;

        }



        protected void DataKeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleFourthColumnVisibility();
            jQueryRelated_Month_Progress_Payment_GridViewBind();
        }


        protected void DetailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DetailColumnsVisibility();
            jQueryRelated_Month_Progress_Payment_GridViewBind();
        }


        // Changed for Using Statement 

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{


        //    if (jQueryRelated_Month_Progress_Payment_GridView.SelectedIndex >= 0) 
        //    {




        //    GridViewRow rowDelete = jQueryRelated_Month_Progress_Payment_GridView.SelectedRow;




        //    //string progressID = rowDelete.Cells[1].Text;
        //    //string acountID = rowDelete.Cells[4].Text;
        //    //string txn_ID_4P = rowDelete.Cells[21].Text;
        //    //string txn_ID_4R = rowDelete.Cells[22].Text;



        //    // By using DataKeys for pulling ID I can pull the Non-Viasble columns.  

        //    // Retrieve the data keys
        //    string progressID = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[rowDelete.RowIndex]["earned_Salarie_ID"].ToString();
        //    string acountID = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[rowDelete.RowIndex]["acct_ID"].ToString();

        //    string txn_ID_4P = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[rowDelete.RowIndex]["txn_Id_4P"].ToString();
        //    string txn_ID_4R = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[rowDelete.RowIndex]["txn_Id_4R"].ToString();



        //    // DELETE Progress Payment

        //    SqlCommand cmd1 = new SqlCommand($"DELETE FROM [tbl_earnedSalarie] WHERE [earnedSal_ID] = '{progressID}'", conn.Connection());
        //    cmd1.ExecuteNonQuery();

        //        if (conn != null)
        //        {
        //            conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //        }



        //        // DELETE The related TXN Rows

        //        SqlCommand cmd10 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txn_ID_4P}'", conn.Connection());
        //    cmd10.ExecuteNonQuery();


        //        if (conn != null)
        //        {
        //            conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //        }


        //        SqlCommand cmd11 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txn_ID_4R}'", conn.Connection());
        //    cmd11.ExecuteNonQuery();


        //        if (conn != null)
        //        {
        //            conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //        }


        //        Response.Redirect("deleteProgressPayment-ERP.aspx");
        //    }

        //    else
        //    {
        //        Response.Write($"<script type=\"text/javascript\">alert('You need to select Pregress for DELETE');</script>");
        //    }

        //}


        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (jQueryRelated_Month_Progress_Payment_GridView.SelectedIndex >= 0)
            {
                GridViewRow rowDelete = jQueryRelated_Month_Progress_Payment_GridView.SelectedRow;

                // Retrieve the data keys
                string progressID = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[rowDelete.RowIndex]["earned_Salarie_ID"].ToString();
                string acountID = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[rowDelete.RowIndex]["acct_ID"].ToString();
                string txn_ID_4P = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[rowDelete.RowIndex]["txn_Id_4P"].ToString();
                string txn_ID_4R = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[rowDelete.RowIndex]["txn_Id_4R"].ToString();

                // DELETE Progress Payment
                using (SqlConnection sqlConn = conn.Connection())
                {
                    SqlCommand cmd1 = new SqlCommand($"DELETE FROM [tbl_earnedSalarie] WHERE [earnedSal_ID] = '{progressID}'", sqlConn);
                    cmd1.ExecuteNonQuery();

                    // DELETE The related TXN Rows
                    SqlCommand cmd10 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txn_ID_4P}'", sqlConn);
                    cmd10.ExecuteNonQuery();

                    SqlCommand cmd11 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txn_ID_4R}'", sqlConn);
                    cmd11.ExecuteNonQuery();
                }

                Response.Redirect("deleteProgressPayment-ERP.aspx");
            }
            else
            {
                Response.Write($"<script type=\"text/javascript\">alert('You need to select Progress for DELETE');</script>");
            }
        }




        // Changed for Using Statement

        //protected void DeleteAllButton_Click(object sender, EventArgs e)
        //{

        //    foreach(GridViewRow row in jQueryRelated_Month_Progress_Payment_GridView.Rows)
        //    {
        //        string progressID = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[row.RowIndex]["earned_Salarie_ID"].ToString();
        //        string acountID = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[row.RowIndex]["acct_ID"].ToString();

        //        string txn_ID_4P = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[row.RowIndex]["txn_Id_4P"].ToString();
        //        string txn_ID_4R = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[row.RowIndex]["txn_Id_4R"].ToString();



        //        // DELETE Progress Payment

        //        SqlCommand cmd1 = new SqlCommand($"DELETE FROM [tbl_earnedSalarie] WHERE [earnedSal_ID] = '{progressID}'", conn.Connection());
        //        cmd1.ExecuteNonQuery();

        //        if (conn != null)
        //        {
        //            conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //        }



        //        // DELETE The related TXN Rows

        //        SqlCommand cmd10 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txn_ID_4P}'", conn.Connection());
        //        cmd10.ExecuteNonQuery();

        //        if (conn != null)
        //        {
        //            conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //        }

        //        SqlCommand cmd11 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txn_ID_4R}'", conn.Connection());
        //        cmd11.ExecuteNonQuery();

        //        if (conn != null)
        //        {
        //            conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //        }

        //    }


        //    Response.Redirect("deleteProgressPayment-ERP.aspx");

        //}



        protected void DeleteAllButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in jQueryRelated_Month_Progress_Payment_GridView.Rows)
            {
                string progressID = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[row.RowIndex]["earned_Salarie_ID"].ToString();
                string acountID = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[row.RowIndex]["acct_ID"].ToString();
                string txn_ID_4P = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[row.RowIndex]["txn_Id_4P"].ToString();
                string txn_ID_4R = jQueryRelated_Month_Progress_Payment_GridView.DataKeys[row.RowIndex]["txn_Id_4R"].ToString();

                // DELETE Progress Payment
                using (SqlConnection sqlConn = conn.Connection())
                {
                    SqlCommand cmd1 = new SqlCommand($"DELETE FROM [tbl_earnedSalarie] WHERE [earnedSal_ID] = '{progressID}'", sqlConn);
                    cmd1.ExecuteNonQuery();

                    // DELETE The related TXN Rows
                    SqlCommand cmd10 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txn_ID_4P}'", sqlConn);
                    cmd10.ExecuteNonQuery();

                    SqlCommand cmd11 = new SqlCommand($"DELETE FROM [tbl_transactions] WHERE [txn_ID] = '{txn_ID_4R}'", sqlConn);
                    cmd11.ExecuteNonQuery();
                }
            }

            Response.Redirect("deleteProgressPayment-ERP.aspx");
        }




        private void HideOtherRows()
        {
            foreach (GridViewRow row in jQueryRelated_Month_Progress_Payment_GridView.Rows)
            {
                if (row.RowIndex != jQueryRelated_Month_Progress_Payment_GridView.SelectedIndex)
                {
                    row.Visible = false;
                }
            }
        }


        protected void CancelButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("deleteProgressPayment-ERP.aspx");
        }



    }
}