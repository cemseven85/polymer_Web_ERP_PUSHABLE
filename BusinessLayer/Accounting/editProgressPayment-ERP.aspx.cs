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
    public partial class editProgressPayment_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataKeyCheckBox.Visible = false;
                DetailCheckBox.Visible = false;
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



        protected void Show_Progress_Payment_Button_Click(object sender, EventArgs e)
        {
            jQueryRelated_Month_Progress_Payment_GridViewBind();

            DataKeyCheckBox.Visible = true;
            DetailCheckBox.Visible = true;



        }

        protected void jQueryRelated_Month_Progress_Payment_GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            jQueryRelated_Month_Progress_Payment_GridView.EditIndex = e.NewEditIndex;


            DetailCheckBox.Checked = true;
           
            DetailCheckBox.Visible = false;
            DataKeyCheckBox.Visible = false;

            jQueryRelated_Month_Progress_Payment_GridViewBind();


            // Hide all other rows
            foreach (GridViewRow row in jQueryRelated_Month_Progress_Payment_GridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow && row.RowIndex != e.NewEditIndex)
                {
                    row.Visible = false;
                }
            }

        }



        protected void jQueryRelated_Month_Progress_Payment_GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            jQueryRelated_Month_Progress_Payment_GridView.EditIndex = -1;


            DetailCheckBox.Visible = true;
            DataKeyCheckBox.Visible = true;

            DataKeyCheckBox.Checked = false;
            DetailCheckBox.Checked = false;

            jQueryRelated_Month_Progress_Payment_GridViewBind();

           


            // Show all rows
            //foreach (GridViewRow row in jQueryRelated_Month_Progress_Payment_GridView.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        row.Visible = true;
            //    }
            //}


        }


        protected void jQueryRelated_Month_Progress_Payment_GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {



            GridViewRow row = jQueryRelated_Month_Progress_Payment_GridView.Rows[e.RowIndex];

            TextBox reletedMonthSalarieTxtBox = (TextBox)row.FindControl("reletedMonthSalarieTxtBox");
            TextBox reletedWageTxtBox = (TextBox)row.FindControl("reletedWageTxtBox");
            TextBox reletedWage_Per_HourTxtBox = (TextBox)row.FindControl("reletedWage_Per_HourTxtBox");
            TextBox reletedHour_WorkedTxtBox = (TextBox)row.FindControl("reletedHour_WorkedTxtBox");
            TextBox mealSupportTextBox = (TextBox)row.FindControl("mealSupportTextBox");
            TextBox coffeeSupportTextBox = (TextBox)row.FindControl("coffeeSupportTextBox");
            TextBox additionalSupportTextBox = (TextBox)row.FindControl("additionalSupportTextBox");
            TextBox reletedoverTimeWagePerHourTxtBox = (TextBox)row.FindControl("overtime_WagePHourTxtBox");
            TextBox reletedHour_overTimeWorkedTxtBox = (TextBox)row.FindControl("over_Working_HourTxtBox");


            string reletedMonthSalarieTxtBoxDot = reletedMonthSalarieTxtBox.Text;
            string reletedWageTxtBoxDot = reletedWageTxtBox.Text;
            string reletedWage_Per_HourTxtBoxDot = reletedWage_Per_HourTxtBox.Text;
            string reletedHour_WorkedTxtBoxDot = reletedHour_WorkedTxtBox.Text;
            string mealSupportTextBoxDot = mealSupportTextBox.Text;
            string coffeeSupportTextBoxDot = coffeeSupportTextBox.Text;
            string additionalSupportTextBoxDot = additionalSupportTextBox.Text;
            string overTimeWagePerHourTxtBoxDot = reletedoverTimeWagePerHourTxtBox.Text;
            string over_Working_HourTxtBoxDot = reletedHour_overTimeWorkedTxtBox.Text;

            reletedMonthSalarieTxtBoxDot = reletedMonthSalarieTxtBoxDot.Replace(".", ","); // All doubles become , 
            reletedWageTxtBoxDot = reletedWageTxtBoxDot.Replace(".", ",");
            reletedWage_Per_HourTxtBoxDot = reletedWage_Per_HourTxtBoxDot.Replace(".", ",");
            reletedHour_WorkedTxtBoxDot = reletedHour_WorkedTxtBoxDot.Replace(".", ",");
            mealSupportTextBoxDot = mealSupportTextBoxDot.Replace(".", ",");
            coffeeSupportTextBoxDot = coffeeSupportTextBoxDot.Replace(".", ",");
            additionalSupportTextBoxDot = additionalSupportTextBoxDot.Replace(".", ",");
            overTimeWagePerHourTxtBoxDot = overTimeWagePerHourTxtBoxDot.Replace(".", ",");
            over_Working_HourTxtBoxDot = over_Working_HourTxtBoxDot.Replace(".", ",");


            // Assuming you have a way to identify the specific row, like "earned_Salarie_ID,emp_ID, acct_ID"

            int progID = Convert.ToInt32(jQueryRelated_Month_Progress_Payment_GridView.DataKeys[e.RowIndex].Values["earned_Salarie_ID"]);
            int empID = Convert.ToInt32(jQueryRelated_Month_Progress_Payment_GridView.DataKeys[e.RowIndex].Values["emp_ID"]);
            int acctID = Convert.ToInt32(jQueryRelated_Month_Progress_Payment_GridView.DataKeys[e.RowIndex].Values["acct_ID"]);

            int txnID4P = Convert.ToInt32(jQueryRelated_Month_Progress_Payment_GridView.DataKeys[e.RowIndex].Values["txn_Id_4P"]);
            int txnID4R = Convert.ToInt32(jQueryRelated_Month_Progress_Payment_GridView.DataKeys[e.RowIndex].Values["txn_Id_4R"]);

            string progressID = progID.ToString();
            string employeeID = empID.ToString();
            string acountID = acctID.ToString();

            string txn_ID_4P = txnID4P.ToString();
            string txn_ID_4R = txnID4R.ToString();


            double uPreletedMonthSalarieTxtBoxDot = Convert.ToDouble(reletedMonthSalarieTxtBoxDot);
            double uPreletedWageTxtBoxDot = Convert.ToDouble(reletedWageTxtBoxDot);
            double uPreletedWage_Per_HourTxtBoxDot = Convert.ToDouble(reletedWage_Per_HourTxtBoxDot);
            double uPreletedHour_WorkedTxtBoxDot = Convert.ToDouble(reletedHour_WorkedTxtBoxDot);
            double uPmealSupportTextBoxDot = Convert.ToDouble(mealSupportTextBoxDot);
            double uPcoffeeSupportTextBoxDot = Convert.ToDouble(coffeeSupportTextBoxDot);
            double uPadditionalSupportTextBoxDot = Convert.ToDouble(additionalSupportTextBoxDot);
            double uPoverTimeWagePerHourTxtBoxDot = Convert.ToDouble(overTimeWagePerHourTxtBoxDot);
            double uPover_Working_HourTxtBoxDot = Convert.ToDouble(over_Working_HourTxtBoxDot);

            // First eddit  tbl_earnedSalarie rows 

            //SqlCommand editEarning = new SqlCommand($"update [tbl_earnedSalarie] set [emp_Salarie]=@uPreletedMonthSalarieTxtBoxDot,[emp_Wage]=@uPreletedWageTxtBoxDot,[emp_Hourly_Wage]=@uPreletedWage_Per_HourTxtBoxDot,[emp_Working_Hour]=@uPreletedHour_WorkedTxtBoxDot,[emp_Meal_Supp]=@uPmealSupportTextBoxDot,[emp_Coffe_Supp]=@uPcoffeeSupportTextBoxDot,[emp_add_Supp]=@uPadditionalSupportTextBoxDot,[overtime_WagePHour]=@uPoverTimeWagePerHourTxtBoxDot ,[over_Working_Hour]=@uPover_Working_HourTxtBoxDot where [earnedSal_ID]='{progressID}'  ", conn.Connection());
            //editEarning.Parameters.Add("@uPreletedMonthSalarieTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPreletedMonthSalarieTxtBoxDot, CultureInfo.CurrentCulture);
            //editEarning.Parameters.Add("@uPreletedWageTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPreletedWageTxtBoxDot, CultureInfo.CurrentCulture);
            //editEarning.Parameters.Add("@uPreletedWage_Per_HourTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPreletedWage_Per_HourTxtBoxDot, CultureInfo.CurrentCulture);
            //editEarning.Parameters.Add("@uPreletedHour_WorkedTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPreletedHour_WorkedTxtBoxDot, CultureInfo.CurrentCulture);
            //editEarning.Parameters.Add("@uPmealSupportTextBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPmealSupportTextBoxDot, CultureInfo.CurrentCulture);
            //editEarning.Parameters.Add("@uPcoffeeSupportTextBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPcoffeeSupportTextBoxDot, CultureInfo.CurrentCulture);
            //editEarning.Parameters.Add("@uPadditionalSupportTextBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPadditionalSupportTextBoxDot, CultureInfo.CurrentCulture);
            //editEarning.Parameters.Add("@uPoverTimeWagePerHourTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPoverTimeWagePerHourTxtBoxDot, CultureInfo.CurrentCulture);
            //editEarning.Parameters.Add("@uPover_Working_HourTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPover_Working_HourTxtBoxDot, CultureInfo.CurrentCulture);

            //editEarning.ExecuteNonQuery();

            //if (conn != null)
            //{
            //    conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
            //}


            // First edit tbl_earnedSalarie rows 
            using (SqlConnection connection = conn.Connection())
            {
                SqlCommand editEarning = new SqlCommand($"update [tbl_earnedSalarie] set [emp_Salarie]=@uPreletedMonthSalarieTxtBoxDot,[emp_Wage]=@uPreletedWageTxtBoxDot,[emp_Hourly_Wage]=@uPreletedWage_Per_HourTxtBoxDot,[emp_Working_Hour]=@uPreletedHour_WorkedTxtBoxDot,[emp_Meal_Supp]=@uPmealSupportTextBoxDot,[emp_Coffe_Supp]=@uPcoffeeSupportTextBoxDot,[emp_add_Supp]=@uPadditionalSupportTextBoxDot,[overtime_WagePHour]=@uPoverTimeWagePerHourTxtBoxDot ,[over_Working_Hour]=@uPover_Working_HourTxtBoxDot where [earnedSal_ID]=@progressID", connection);
                editEarning.Parameters.AddWithValue("@uPreletedMonthSalarieTxtBoxDot", Convert.ToDecimal(uPreletedMonthSalarieTxtBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@uPreletedWageTxtBoxDot", Convert.ToDecimal(uPreletedWageTxtBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@uPreletedWage_Per_HourTxtBoxDot", Convert.ToDecimal(uPreletedWage_Per_HourTxtBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@uPreletedHour_WorkedTxtBoxDot", Convert.ToDecimal(uPreletedHour_WorkedTxtBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@uPmealSupportTextBoxDot", Convert.ToDecimal(uPmealSupportTextBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@uPcoffeeSupportTextBoxDot", Convert.ToDecimal(uPcoffeeSupportTextBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@uPadditionalSupportTextBoxDot", Convert.ToDecimal(uPadditionalSupportTextBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@uPoverTimeWagePerHourTxtBoxDot", Convert.ToDecimal(uPoverTimeWagePerHourTxtBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@uPover_Working_HourTxtBoxDot", Convert.ToDecimal(uPover_Working_HourTxtBoxDot, CultureInfo.CurrentCulture));
                editEarning.Parameters.AddWithValue("@progressID", progressID);

                editEarning.ExecuteNonQuery();
            }





            jQueryRelated_Month_Progress_Payment_GridView.EditIndex = -1;


            DataKeyCheckBox.Checked = false;
            DetailCheckBox.Checked = false;

            jQueryRelated_Month_Progress_Payment_GridViewBind();


            // Second  Edit the TXN Rows

            GridViewRow rowUp = jQueryRelated_Month_Progress_Payment_GridView.Rows[e.RowIndex];


            string txn_4P = rowUp.Cells[19].Text;
            string txn_4R = rowUp.Cells[20].Text;




            double txn_4PDot = Convert.ToDouble(txn_4P);
            double txn_4RDot = Convert.ToDouble(txn_4R);

            //SqlCommand editTXN4p = new SqlCommand($"update tbl_transactions set txn_Credit=@txn_4PDot where txn_ID='{txn_ID_4P}'", conn.Connection());
            //editTXN4p.Parameters.Add("@txn_4PDot", SqlDbType.Decimal).Value = Convert.ToDecimal(txn_4PDot, CultureInfo.CurrentCulture);

            //editTXN4p.ExecuteNonQuery();

            //if (conn != null)
            //{
            //    conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
            //}

            //SqlCommand editTXN4r = new SqlCommand($"update tbl_transactions set txn_Credit=@txn_4RDot where txn_ID='{txn_ID_4R}'", conn.Connection());
            //editTXN4r.Parameters.Add("@txn_4RDot", SqlDbType.Decimal).Value = Convert.ToDecimal(txn_4RDot, CultureInfo.CurrentCulture);

            //editTXN4r.ExecuteNonQuery();

            //if (conn != null)
            //{
            //    conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
            //}


            // Update txn_Credit for txn_ID_4P
            using (SqlConnection connection = conn.Connection())
            {
                SqlCommand editTXN4p = new SqlCommand($"update tbl_transactions set txn_Credit=@txn_4PDot where txn_ID=@txn_ID_4P", connection);
                editTXN4p.Parameters.Add("@txn_4PDot", SqlDbType.Decimal).Value = Convert.ToDecimal(txn_4PDot, CultureInfo.CurrentCulture);
                editTXN4p.Parameters.AddWithValue("@txn_ID_4P", txn_ID_4P);

                editTXN4p.ExecuteNonQuery();
            }

            // Update txn_Credit for txn_ID_4R
            using (SqlConnection connection = conn.Connection())
            {
                SqlCommand editTXN4r = new SqlCommand($"update tbl_transactions set txn_Credit=@txn_4RDot where txn_ID=@txn_ID_4R", connection);
                editTXN4r.Parameters.Add("@txn_4RDot", SqlDbType.Decimal).Value = Convert.ToDecimal(txn_4RDot, CultureInfo.CurrentCulture);
                editTXN4r.Parameters.AddWithValue("@txn_ID_4R", txn_ID_4R);

                editTXN4r.ExecuteNonQuery();
            }




            DetailCheckBox.Visible = true;
            DataKeyCheckBox.Visible = true;
        }



        private void ToggleFourthColumnVisibility()
        {
            /// Change the visibility of the 4th column based on the CheckBox state

            bool control = DataKeyCheckBox.Checked;

            jQueryRelated_Month_Progress_Payment_GridView.Columns[0].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[2].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[3].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[4].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[20].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[21].Visible = control;

        }


        private void DetailColumnsVisibility()
        {
            /// Change the visibility of the 4th column based on the CheckBox state

            bool control = DetailCheckBox.Checked;

            jQueryRelated_Month_Progress_Payment_GridView.Columns[6].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[7].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[12].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[13].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[14].Visible = control;
            jQueryRelated_Month_Progress_Payment_GridView.Columns[15].Visible = control;

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



        


    }
}