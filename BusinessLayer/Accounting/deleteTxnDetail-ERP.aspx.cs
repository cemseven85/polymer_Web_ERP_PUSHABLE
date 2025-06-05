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
    public partial class deleteTxnDetail_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

               

                TxnDetailGridViewBind();

            }

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
        protected void DeleteDetailButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = TxnDetailGridView.SelectedRow;
            string rid = row.Cells[1].Text;

            using (SqlConnection connection = conn.Connection())
            {
                SqlCommand modfiyDetail = new SqlCommand($"delete from tbl_transactionDetail where txn_Detail_ID = '{rid}'", connection);
                modfiyDetail.ExecuteNonQuery();
            }

            Response.Redirect("deleteTxnDetail-ERP.aspx");
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