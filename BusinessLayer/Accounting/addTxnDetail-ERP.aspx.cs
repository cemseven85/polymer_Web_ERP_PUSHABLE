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
    public partial class addTransactionDetail_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                TransactionTypeIdDropDownListBind();

                TxnDetailGridViewBind();
            }

        }



        protected void TransactionTypeIdDropDownListBind()
        {
            // Wrap the database interaction in a using statement
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = "SELECT * FROM tbl_transactionType";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                TransactionTypeIdDropDownList.DataSource = dt;
                TransactionTypeIdDropDownList.DataBind();

                TransactionTypeIdDropDownList.DataTextField = "txn_Type_Name";
                TransactionTypeIdDropDownList.DataValueField = "txn_Type_ID";
                TransactionTypeIdDropDownList.DataBind();

                // Close the connection
                sqlConn.Close();
            }
        }


        /*
        protected void TxnDetailGridViewBind()
        {
            string com2 = "execute prc_listTxnDetailList";
            SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection());
            DataTable dt2 = new DataTable();
            adpt2.Fill(dt2);

            TxnDetailGridView.DataSource = dt2;
            TxnDetailGridView.DataBind();

        }

        */

        protected void AddGroupButton_Click(object sender, EventArgs e)
        {
            string txnDetailName = Transaction_Detail_Name_TextBox.Text;
            string txnDetailName2 = Transaction_Detail_Name2_BG_TextBox.Text;
            string txnDetailNameDescription = Transaction_Detail_Description_TextBox.Text;

            // Wrap the database interaction in a using statement
            using (SqlConnection sqlConn = conn.Connection())
            {
                SqlCommand addNewGroup = new SqlCommand($"INSERT INTO tbl_transactionDetail (txn_Type_ID, txn_Detail_Name, txn_Detail_Name2, txn_Detail_Description) VALUES ('{TransactionTypeIdDropDownList.SelectedValue}', '{txnDetailName}', '{txnDetailName2}', '{txnDetailNameDescription}')", sqlConn);
                addNewGroup.ExecuteNonQuery();
            }

            Response.Redirect("addTxnDetail-ERP.aspx");
        }




        private void TxnDetailGridViewBind()
        {
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"EXEC prc_listTxnDetailList", con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    TxnDetailGridView.DataSource = dt;
                    TxnDetailGridView.DataBind();
                }
            }

            // Required for jQuery DataTables to work.
            TxnDetailGridView.UseAccessibleHeader = true;
            TxnDetailGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        }


        protected void TxnDetailGridViewBind_PreRender(object sender, EventArgs e)
        {
            this.TxnDetailGridViewBind();

            if (TxnDetailGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                TxnDetailGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                TxnDetailGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                TxnDetailGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        

        /*
        protected void TxnDetailGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            TxnDetailGridView.PageIndex = e.NewPageIndex;

            string com2 = "execute prc_listTxnDetailList";
            SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection());
            DataTable dt2 = new DataTable();
            adpt2.Fill(dt2);

            TxnDetailGridView.DataSource = dt2;
            TxnDetailGridView.DataBind();
        }

        */
    }
}