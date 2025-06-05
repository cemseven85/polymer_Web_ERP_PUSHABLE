using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace polymer_Web_ERP_V4
{
    public partial class editTxnDetail_ERP : System.Web.UI.Page
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
            DataTable dt = new DataTable();
            using (SqlConnection connection = conn.Connection())
            {
                string com = "SELECT * FROM tbl_transactionType";
                SqlDataAdapter adpt = new SqlDataAdapter(com, connection);
                adpt.Fill(dt);
            }

            TransactionTypeIdDropDownList.DataSource = dt;
            TransactionTypeIdDropDownList.DataTextField = "txn_Type_Name";
            TransactionTypeIdDropDownList.DataValueField = "txn_Type_ID";
            TransactionTypeIdDropDownList.DataBind();
        }




        private void TxnDetailGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_listTxnDetailList", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        TxnDetailGridView.DataSource = dt;
                        TxnDetailGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
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

        protected void EditDetailButton_Click(object sender, EventArgs e)
        {
            string txnDetailName;
            string txnDetailName2;
            string txnDetailNameDescription;

            txnDetailName = Transaction_Detail_Name_TextBox.Text;
            txnDetailName2 = Transaction_Detail_Name2_BG_TextBox.Text;
            txnDetailNameDescription = Transaction_Detail_Description_TextBox.Text;

            GridViewRow row = TxnDetailGridView.SelectedRow;
            string rid = row.Cells[1].Text;

            //SqlCommand modfiyDetail = new SqlCommand($"update tbl_transactionDetail set txn_Type_ID='{TransactionTypeIdDropDownList.SelectedValue}' , txn_Detail_Name='{txnDetailName}',txn_Detail_Name2='{txnDetailName2}',txn_Detail_Description='{txnDetailNameDescription}' where txn_Detail_ID = '{rid}'", conn.Connection());

            //modfiyDetail.ExecuteNonQuery();

            //if (conn != null)
            //{
            //    conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
            //}

            using (SqlCommand modfiyDetail = new SqlCommand($"UPDATE tbl_transactionDetail SET txn_Type_ID=@TypeId, txn_Detail_Name=@DetailName, txn_Detail_Name2=@DetailName2, txn_Detail_Description=@Description WHERE txn_Detail_ID = @DetailId", conn.Connection()))
            {
                modfiyDetail.Parameters.AddWithValue("@TypeId", TransactionTypeIdDropDownList.SelectedValue);
                modfiyDetail.Parameters.AddWithValue("@DetailName", txnDetailName);
                modfiyDetail.Parameters.AddWithValue("@DetailName2", txnDetailName2);
                modfiyDetail.Parameters.AddWithValue("@Description", txnDetailNameDescription);
                modfiyDetail.Parameters.AddWithValue("@DetailId", rid);

                modfiyDetail.ExecuteNonQuery();
            }




            Response.Redirect("editTxnDetail-ERP.aspx");
        }

        //protected void TxnDetailGridView_SelectedIndexChanged(object sender, EventArgs e)   // Grid View Selected Row Writting to all TaxBox And DropDownList. Ready To Edit. 
        //{
        //    GridViewRow row = TxnDetailGridView.SelectedRow;

        //    string rid = row.Cells[1].Text;

        //    string txnTypeName = row.Cells[2].Text;
        //    string txnDetailName=row.Cells[3].Text;
        //    string txnDetailName2=row.Cells[4].Text;
        //    string txnDetailNameDescription=row.Cells[5].Text;


        //    string com = $"select txn_Type_ID from tbl_transactionType where txn_Type_Name='{txnTypeName}'";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);

        //    if (conn != null)
        //    {
        //        conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //    }




        //    string rid2 = dt2.Rows[0][0].ToString();






        //    Transaction_Detail_Name_TextBox.Text = txnDetailName;
        //    Transaction_Detail_Name2_BG_TextBox.Text = txnDetailName2;
        //    Transaction_Detail_Description_TextBox.Text= txnDetailNameDescription;
        //    TransactionTypeIdDropDownList.SelectedValue = rid2;




        //}

        protected void TxnDetailGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = TxnDetailGridView.SelectedRow;

            string rid = row.Cells[1].Text;

            string txnTypeName = row.Cells[2].Text;
            string txnDetailName = row.Cells[3].Text;
            string txnDetailName2 = row.Cells[4].Text;
            string txnDetailNameDescription = row.Cells[5].Text;

            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = $"SELECT txn_Type_ID FROM tbl_transactionType WHERE txn_Type_Name = @TypeName";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                adpt.SelectCommand.Parameters.AddWithValue("@TypeName", txnTypeName);
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);

                string rid2 = dt2.Rows[0][0].ToString();

                Transaction_Detail_Name_TextBox.Text = txnDetailName;
                Transaction_Detail_Name2_BG_TextBox.Text = txnDetailName2;
                Transaction_Detail_Description_TextBox.Text = txnDetailNameDescription;
                TransactionTypeIdDropDownList.SelectedValue = rid2;
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