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
    public partial class editTxn_ERP : System.Web.UI.Page
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
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listTxnEdit '{ItemDateMin_TextBox.Text}', '{ItemDateMax_TextBox.Text}'", con))
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




        protected void jQueryList_Txn_GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            jQueryList_Txn_GridView.EditIndex = e.NewEditIndex;

            
            jQueryList_Txn_GridViewBind();


            // Hide all other rows
            foreach (GridViewRow row in jQueryList_Txn_GridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow && row.RowIndex != e.NewEditIndex)
                {
                    row.Visible = false;
                }
            }

        }


        protected void jQueryList_Txn_GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            jQueryList_Txn_GridView.EditIndex = -1;



            jQueryList_Txn_GridViewBind();


        }


        protected void jQueryList_Txn_GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

           

            GridViewRow row = jQueryList_Txn_GridView.Rows[e.RowIndex];

            TextBox debitTxtBox = (TextBox)row.FindControl("debitTxtBox");
            TextBox creditTxtBox = (TextBox)row.FindControl("creditTxtBox");

            string debitTxtDot= debitTxtBox.Text;
            string creditTxtDot= creditTxtBox.Text;

            debitTxtDot = debitTxtDot.Replace(".", ",");
            creditTxtDot= creditTxtDot.Replace(".", ",");


            int txnIDNum = Convert.ToInt32(jQueryList_Txn_GridView.DataKeys[e.RowIndex].Values["txnID"]);

            string txnID = Convert.ToString(txnIDNum);

            double uPdebitTxnDot = Convert.ToDouble(debitTxtDot);
            double uPcreditTxnDot = Convert.ToDouble(creditTxtDot);



            //SqlCommand editTXN = new SqlCommand($"update tbl_transactions set txn_Debit=@uPdebitTxnDot ,txn_Credit=@uPcreditTxnDot where txn_ID='{txnID}'", conn.Connection());
            //editTXN.Parameters.Add("@uPdebitTxnDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPdebitTxnDot, CultureInfo.CurrentCulture);
            //editTXN.Parameters.Add("@uPcreditTxnDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPcreditTxnDot, CultureInfo.CurrentCulture);

            //editTXN.ExecuteNonQuery();

            //if (conn != null)
            //{
            //    conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
            //}


            using (SqlConnection connection = conn.Connection())
            {
                SqlCommand editTXN = new SqlCommand($"update tbl_transactions set txn_Debit=@uPdebitTxnDot ,txn_Credit=@uPcreditTxnDot where txn_ID=@txnID", connection);
                editTXN.Parameters.Add("@uPdebitTxnDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPdebitTxnDot, CultureInfo.CurrentCulture);
                editTXN.Parameters.Add("@uPcreditTxnDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPcreditTxnDot, CultureInfo.CurrentCulture);
                editTXN.Parameters.AddWithValue("@txnID", txnID);

                editTXN.ExecuteNonQuery();
            }


            jQueryList_Txn_GridView.EditIndex = -1;

            jQueryList_Txn_GridViewBind();

        }


        protected void Show_Txn_List_Button_Click(object sender, EventArgs e)
        {

            jQueryList_Txn_GridViewBind();
        }





    }
}