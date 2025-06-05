using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Globalization;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Microsoft.SqlServer.Server;
using System.Windows.Forms;

namespace polymer_Web_ERP_V4
{
    public partial class addTxn_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dateTxn = DateTime.Now;

            if (!this.IsPostBack)
            {

                TxnDate_TextBox.Text = dateTxn.ToString("yyyy-MM-dd");

                txnTypeIDDropDownListBind();
                txnDetailIDDropDownListBind();
                accTypeIDDropDownListBind();
                accNameIDDropDownListBind();
                consultantIDDropDownListBind();

                acctBalanceCalculation();

                
            }

        }




        private void txnTypeIDDropDownListBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = $"SELECT * FROM [tbl_transactionType]";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt1 = new DataTable();

                adpt.Fill(dt1);

                // After filling the DataTable, close the connection
                sqlConn.Close();

                // Remove unwanted rows
                dt1.Rows[0].Delete();
                dt1.Rows[1].Delete();
                dt1.Rows[4].Delete();
                dt1.AcceptChanges();

                // Bind the DataTable to the DropDownList
                txnTypeIDDropDownList.DataSource = dt1;
                txnTypeIDDropDownList.DataTextField = "txn_Type_Name";
                txnTypeIDDropDownList.DataValueField = "txn_Type_ID";
                txnTypeIDDropDownList.DataBind();
            }
        }



        protected void txnTypeIDDropDownList_ScelectedIndexChanged(object sender, EventArgs e)
        {
            txnDetailIDDropDownListBind();
        }


        private void txnDetailIDDropDownListBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = $"SELECT * FROM [tbl_transactionDetail] WHERE txn_Type_ID = '{txnTypeIDDropDownList.SelectedValue}'";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt1 = new DataTable();

                adpt.Fill(dt1);

                // After filling the DataTable, close the connection
                sqlConn.Close();

                // Bind the DataTable to the DropDownList
                txnDetailIDDropDownList.DataSource = dt1;
                txnDetailIDDropDownList.DataTextField = "txn_Detail_Name";
                txnDetailIDDropDownList.DataValueField = "txn_Detail_ID";
                txnDetailIDDropDownList.DataBind();
            }
        }




        private void accTypeIDDropDownListBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = $"SELECT * FROM [tbl_accountType]";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt1 = new DataTable();

                adpt.Fill(dt1);

                // After filling the DataTable, close the connection
                sqlConn.Close();

                // Bind the DataTable to the DropDownList
                accTypeIDDropDownList.DataSource = dt1;
                accTypeIDDropDownList.DataTextField = "acc_Type_Name";
                accTypeIDDropDownList.DataValueField = "acct_Type_ID";
                accTypeIDDropDownList.DataBind();
            }
        }


        protected void accTypeIDDropDownList_ScelectedIndexChanged(object sender, EventArgs e)
        {

            accNameIDDropDownListBind();
            acctBalanceCalculation();
        }


        private void accNameIDDropDownListBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = $"SELECT * FROM [tbl_account] WHERE [acct_Type_ID] = @acctTypeID";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                adpt.SelectCommand.Parameters.AddWithValue("@acctTypeID", accTypeIDDropDownList.SelectedValue);
                DataTable dt1 = new DataTable();

                adpt.Fill(dt1);

                // After filling the DataTable, close the connection
                sqlConn.Close();

                // Bind the DataTable to the DropDownList
                accNameIDDropDownList.DataSource = dt1;
                accNameIDDropDownList.DataTextField = "acct_Name";
                accNameIDDropDownList.DataValueField = "acct_ID";
                accNameIDDropDownList.DataBind();
            }
        }



        protected void aaccNameIDDropDownList_ScelectedIndexChanged(object sender, EventArgs e)
        {
            acctBalanceCalculation();

        }


        private void acctBalanceCalculation()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = $"EXECUTE prc_acctBalance @acctID";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                adpt.SelectCommand.Parameters.AddWithValue("@acctID", accNameIDDropDownList.SelectedValue);
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);

                // After filling the DataTable, close the connection
                sqlConn.Close();

                string balanceBefore = dt2.Rows.Count > 0 ? dt2.Rows[0][0].ToString() : "";

                if (!string.IsNullOrEmpty(balanceBefore))
                {
                    double balanceBeforeNum = Convert.ToDouble(balanceBefore);
                    creditDebitLabel.Text = balanceBeforeNum < 0 ? "(Debit)" : "(Credit)";
                    Current_Balance_Label.Text = balanceBeforeNum.ToString("N2");
                }
                else
                {
                    Current_Balance_Label.Text = "..............";
                }
            }
        }








        private void consultantIDDropDownListBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = $"SELECT * FROM [tbl_consultant]";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt1 = new DataTable();

                adpt.Fill(dt1);

                // After filling the DataTable, close the connection
                sqlConn.Close();

                consultantIDDropDownList.DataSource = dt1;
                consultantIDDropDownList.DataBind();

                consultantIDDropDownList.DataTextField = "cnslt_Name";
                consultantIDDropDownList.DataValueField = "cnslt_Id";
                consultantIDDropDownList.DataBind();
            }
        }


        //ChangePassword with using statement  

        //protected void CreateTxnButton_Click(object sender, EventArgs e)
        //{
        //    string txnPayColl;

        //    string txnDate;
        //    string acctID;
        //    string txnTypeID;
        //    string txnDetailID;
        //    string consultantID;
        //    string txnAmount;
        //    string txnNotes;



        //    string txnAmountDot;

        //    txnPayColl = paymentCollectionIDDropDownList.SelectedValue; // 0 Null  1 Payment  2 Collection 

        //    txnDate = TxnDate_TextBox.Text;
        //    acctID = accNameIDDropDownList.SelectedValue;
        //    txnTypeID = txnTypeIDDropDownList.SelectedValue;
        //    txnDetailID = txnDetailIDDropDownList.SelectedValue;
        //    consultantID = consultantIDDropDownList.SelectedValue;
        //    txnAmount = amount_TextBox.Text;
        //    txnAmount = (txnAmount == "") ? "0" : txnAmount;   // Validation for Empty Quantitiy 
            
            
        //    txnAmountDot = txnAmount.Replace(".", ",");
        //    txnNotes = Item_Note_TextBox.Text;



        //    // First pull the current balance before this Transaction. 

        //    string com = $"execute prc_acctBalance '{acctID}' ";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt.Fill(dt2);

        //    conn.Connection().Close();

        //    string balanceBefore = dt2.Rows[0][0].ToString();

        //    // If we want to cancel this query we can pull data from acctBalance Lable  

        //    double balanceBeforeNum;
        //    double addToBalanceNum;

        //    if (balanceBefore.Length > 0)

        //    {

        //         balanceBeforeNum = Convert.ToDouble(balanceBefore);
        //         addToBalanceNum = Convert.ToDouble(txnAmount);
        //    }
        //    else
        //    {
        //        balanceBeforeNum = 0;
        //        addToBalanceNum = Convert.ToDouble(txnAmount);
        //    }
        //    double acctBalanceNum;
        //    string acctBalance;


        //    // Payment will make a Debit movment for that account. 
        //    // Collection will make a Credit movment for that account. 

        //    string txnNull = "0";

        //    if (txnPayColl == "1")
        //    {



        //        acctBalanceNum = balanceBeforeNum - addToBalanceNum;


                

        //        acctBalance = acctBalanceNum.ToString();



        //        SqlCommand addTxn = new SqlCommand($"insert into [tbl_transactions] ([txn_Date]\r\n,[acct_ID]\r\n,[txn_Type_ID]\r\n,[txn_Detail_ID]\r\n,[consultant_ID]\r\n,[txn_Debit]\r\n,[txn_Credit],[txn_Notes] )" +
        //            $"values ('{txnDate}','{acctID}','{txnTypeID}','{txnDetailID}','{consultantID}',@txnAmount,@txnNull,'{txnNotes}')", conn.Connection());
        //        addTxn.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmountDot, CultureInfo.CurrentCulture);
                
        //        addTxn.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
        //        addTxn.ExecuteNonQuery();


        //        if (conn != null)
        //        {
        //            conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //        }


        //        Response.Redirect("addTxn-ERP.aspx");

        //    }

        //    else if (txnPayColl == "2")
        //    {

        //        acctBalanceNum = balanceBeforeNum + addToBalanceNum;

                

        //        acctBalance = acctBalanceNum.ToString();

        //        SqlCommand addTxn = new SqlCommand($"insert into [tbl_transactions] ([txn_Date]\r\n,[acct_ID]\r\n,[txn_Type_ID]\r\n,[txn_Detail_ID]\r\n,[consultant_ID]\r\n,[txn_Debit],[txn_Credit]\r\n,[txn_Notes] )" +
        //                $"values ('{txnDate}',{acctID},{txnTypeID},{txnDetailID},{consultantID},@txnNull,@txnAmount,'{txnNotes}')", conn.Connection());
        //        addTxn.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmountDot, CultureInfo.CurrentCulture);
                
        //        addTxn.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
        //        addTxn.ExecuteNonQuery();


        //        if (conn != null)
        //        {
        //            conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
        //        }


        //        Response.Redirect("addTxn-ERP.aspx");

        //    }


        //    else if (txnPayColl == "0")
        //    {
        //        Response.Write("<script>alert('You need to choose PAYMENT or COLLECTION')</script>");

        //    }

            
        //}

        protected void CreateTxnButton_Click(object sender, EventArgs e)
        {
            string txnPayColl;

            string txnDate;
            string acctID;
            string txnTypeID;
            string txnDetailID;
            string consultantID;
            string txnAmount;
            string txnNotes;
            string txnAmountDot;

            txnPayColl = paymentCollectionIDDropDownList.SelectedValue; // 0 Null  1 Payment  2 Collection 

             

            txnDate = TxnDate_TextBox.Text;
            acctID = accNameIDDropDownList.SelectedValue;
            txnTypeID = txnTypeIDDropDownList.SelectedValue;
            txnDetailID = txnDetailIDDropDownList.SelectedValue;
            consultantID = consultantIDDropDownList.SelectedValue;
            txnAmount = amount_TextBox.Text;
            txnAmount = (txnAmount == "") ? "0" : txnAmount;   // Validation for Empty Quantitiy 


            txnAmountDot = txnAmount.Replace(".", ",");
            txnNotes = Item_Note_TextBox.Text;

            // Wrap the database interaction in a using statement
            using (SqlConnection sqlConn = conn.Connection())
            {
                // First pull the current balance before this Transaction.
                string com = $"EXECUTE prc_acctBalance '{acctID}' ";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt2 = new DataTable();
                adpt.Fill(dt2);

                string balanceBefore = dt2.Rows[0][0].ToString();
                double balanceBeforeNum;
                double addToBalanceNum;

                if (balanceBefore.Length > 0)
                {
                    balanceBeforeNum = Convert.ToDouble(balanceBefore);
                    addToBalanceNum = Convert.ToDouble(txnAmount);
                }
                else
                {
                    balanceBeforeNum = 0;
                    addToBalanceNum = Convert.ToDouble(txnAmount);
                }

                double acctBalanceNum;
                string acctBalance;

                // Payment will make a Debit movement for that account.
                // Collection will make a Credit movement for that account.
                string txnNull = "0";

                if (txnPayColl == "1")
                {
                    acctBalanceNum = balanceBeforeNum - addToBalanceNum;
                    acctBalance = acctBalanceNum.ToString();

                    SqlCommand addTxn = new SqlCommand(
                        $"INSERT INTO [tbl_transactions] ([txn_Date], [acct_ID], [txn_Type_ID], [txn_Detail_ID], [consultant_ID], [txn_Debit], [txn_Credit], [txn_Notes]) " +
                        $"VALUES ('{txnDate}', '{acctID}', '{txnTypeID}', '{txnDetailID}', '{consultantID}', @txnAmount, @txnNull, '{txnNotes}')",
                        sqlConn);

                    addTxn.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmountDot, CultureInfo.CurrentCulture);
                    addTxn.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
                    addTxn.ExecuteNonQuery();
                }
                else if (txnPayColl == "2")
                {
                    acctBalanceNum = balanceBeforeNum + addToBalanceNum;
                    acctBalance = acctBalanceNum.ToString();

                    SqlCommand addTxn = new SqlCommand(
                        $"INSERT INTO [tbl_transactions] ([txn_Date], [acct_ID], [txn_Type_ID], [txn_Detail_ID], [consultant_ID], [txn_Debit], [txn_Credit], [txn_Notes]) " +
                        $"VALUES ('{txnDate}', '{acctID}', '{txnTypeID}', '{txnDetailID}', '{consultantID}', @txnNull, @txnAmount, '{txnNotes}')",
                        sqlConn);

                    addTxn.Parameters.Add("@txnAmount", SqlDbType.Decimal).Value = Convert.ToDecimal(txnAmountDot, CultureInfo.CurrentCulture);
                    addTxn.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
                    addTxn.ExecuteNonQuery();
                }
                else if (txnPayColl == "0")
                {
                    Response.Write("<script>alert('You need to choose PAYMENT or COLLECTION')</script>");
                }

                // Close the connection
                sqlConn.Close();
            }

            Response.Redirect("addTxn-ERP.aspx");
        }



    }
}