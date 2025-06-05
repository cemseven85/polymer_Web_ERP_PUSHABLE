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
    public partial class addProgressPayment_ERP : System.Web.UI.Page
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

        protected void Create_Progress_Payment_Button_Click(object sender, EventArgs e)
        {
            // First we understand the pull the Releted Months Yaer and Month for calculating Working Days

            DateTime nowDate = DateTime.Now;

            string createDateNow = nowDate.ToString("yyyy/MM/dd");


            string earnedMonth = Related_Progress_MonthTextBox.Text;

            DateTime date = DateTime.Parse(Related_Progress_MonthTextBox.Text);

            int year = date.Year;
            int month = date.Month;

            // If tbl_earnedSalarie has a Value same with EarnedMonth Then Alert User About That



            using (SqlConnection sqlConn = conn.Connection())    // For Using Modification Just add this and adapters conn.Connection() to  sqlConn and delete conn!= null  conn.Conection().Close
            {

                string com30 = $"select [earnedSal_ID] from tbl_earnedSalarie where [related_Month]='{earnedMonth}'";
                SqlDataAdapter sda30 = new SqlDataAdapter(com30, sqlConn);
                DataTable dt30 = new DataTable();
                sda30.Fill(dt30);

                bool checkNullDataTable = false;

                if (dt30.Rows.Count == 0 || string.IsNullOrEmpty(dt30.Rows[0][0]?.ToString()))   // Whis is the way to check is data table is null or Empty. 
                {
                    checkNullDataTable = true;
                }
                else
                {

                }

                if (checkNullDataTable == false)
                {

                    string message = "Progress Payment Was Created Previously for This Month!! If You Need To Change Wage Per Hour You Need To Change Individually !!       Holiday Calculation Can Not Be Done Again !!        Go Edit Module For That !!";
                    string script = "if(confirm('" + message + "')){ }";   // If you want to redirect a page you need to write inside { window.location='addProgressPayment-ERP.aspx?'; } 
                    ScriptManager.RegisterStartupScript(this, GetType(), "AddConfirmation", script, true);

                }
            }

            // Show User All Nations Total Working Days With Holidays 

            int showWD_BG = WorkingDays.GetWorkingDaysInMonth(year, month);
            int hol_BG = int.Parse(Extra_Holiday_BG_DropDownList.SelectedValue);
            showWD_BG = showWD_BG - hol_BG;

            BG_WD_Label.Text = "BG= " + (showWD_BG.ToString()) + " Days";


            int showWD_SAA = WorkingDays.GetWorkingDaysInMonth(year, month, 6);
            int hol_SAA = int.Parse(Extra_Holiday_SAA_DropDownList.SelectedValue);
            showWD_SAA = showWD_SAA - hol_SAA;

            SAA_WD_Label.Text = "SAA= " + (showWD_SAA.ToString()) + " Days";

            int showWD_TR = WorkingDays.GetWorkingDaysInMonth(year, month, 6);
            int hol_TR = int.Parse(Extra_Holiday_TR_DropDownList.SelectedValue);
            showWD_TR = showWD_TR - hol_TR;

            TR_WD_Label.Text = "TR= " + (showWD_TR.ToString()) + " Days";

            // Create a Data Table that has the IDs of Active  Working Employees

            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;

            DataTable dt = new DataTable();
            //DataTable emplDt = new DataTable();   // I Create ıt in Using Stement line  307


            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"execute prc_monthlyProgressPaymentEmplIDList '{earnedMonth}'", con))
                {
                    sda.Fill(dt);

                }
            }



            // Add all active Employees to tbl_earnedSalarie with the Related Month

            foreach (DataRow row in dt.Rows)
            {



                //Chage Code with Using Statement One  ***************************************
                //foreach (var item in row.ItemArray)
                //{
                //    string emplID = item.ToString();


                //    // We will need also acount ID ın Future for TXN lets detearmine the acctID of this employee table too


                //    string com = $"select * from tbl_employee where empl_Id='{emplID}'";
                //    SqlDataAdapter sda2 = new SqlDataAdapter(com, conn.Connection());

                //    sda2.Fill(emplDt);

                //    if (conn != null)
                //    {
                //        conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
                //    }

                //    string emplNationalityID = emplDt.Rows[0][5].ToString();

                //    string acctID = emplDt.Rows[0][16].ToString();
                //    string salary;
                //    string salaryDot = emplDt.Rows[0][10].ToString();
                //    string wage;
                //    string wageDot = emplDt.Rows[0][11].ToString();
                //    string mealSupport;
                //    string mealSupportDot = emplDt.Rows[0][17].ToString();
                //    mealSupportDot = mealSupportDot != " " ? mealSupportDot : "0";
                //    string coffeeSupport;
                //    string coffeeSupportDot = emplDt.Rows[0][18].ToString();
                //    coffeeSupportDot = coffeeSupportDot != " " ? coffeeSupportDot : "0";
                //    string additionalSupport;
                //    string additionalSupportDot = emplDt.Rows[0][19].ToString();
                //    additionalSupportDot = additionalSupportDot != "" ? additionalSupportDot : "0";
                //    string dayPerWeak = emplDt.Rows[0][20].ToString();
                //    string hourPerDay = emplDt.Rows[0][21].ToString();
                //    string socSecTax;
                //    string socSecTaxDot = emplDt.Rows[0][22].ToString();
                //    socSecTaxDot = socSecTaxDot != " " ? socSecTaxDot : "0";
                //    string overTimeWagePerHourDot = emplDt.Rows[0][23].ToString();
                //    overTimeWagePerHourDot = overTimeWagePerHourDot != "" ? overTimeWagePerHourDot : "0";
                //    string hourWage;
                //    int wDays = 0;


                //    //********** Start Add the TXN Row  for all Employees.   Two TXN Row for each employee One for 4Polymer Consultant (Official) and One for 4Recycle (Cash Payments)  *******

                //    string txn_Id_4P;
                //    string txn_Id_4R;
                //    string txnTypeID = "5"; // All Wage Movments are ID 5.    //******************************Burda Kaldım *********************
                //    string txnDetailID = "20";  // 20 for 4 Polymer  21 for 4 Recycle Wages
                //    string consultantID = "1"; // 1 for 4 Polymer  2 for 4 Recycle Wages
                //    string txnNull = "0";
                //    string txnNotes = "txn From 4P Wage " + earnedMonth;

                //    SqlCommand addTxn4P = new SqlCommand($"insert into [tbl_transactions] ([txn_Date]\r\n,[acct_ID]\r\n,[txn_Type_ID]\r\n,[txn_Detail_ID]\r\n,[consultant_ID]\r\n,[txn_Debit],[txn_Credit]\r\n,[txn_Notes] )" +
                //                $"values ('{createDateNow}',{acctID},{txnTypeID},{txnDetailID},{consultantID},@txnNull,@txnNull,'{txnNotes}')", conn.Connection());

                //    addTxn4P.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
                //    addTxn4P.ExecuteNonQuery();

                //    if (conn != null)
                //    {
                //        conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
                //    }

                //    txnDetailID = "21";  // 20 for 4 Polymer  21 for 4 Recycle Wages
                //    consultantID = "2"; // 1 for 4 Polymer  2 for 4 Recycle Wages
                //    txnNotes = "txn From 4R Wage " + earnedMonth;

                //    SqlCommand addTxn4R = new SqlCommand($"insert into [tbl_transactions] ([txn_Date]\r\n,[acct_ID]\r\n,[txn_Type_ID]\r\n,[txn_Detail_ID]\r\n,[consultant_ID]\r\n,[txn_Debit],[txn_Credit]\r\n,[txn_Notes] )" +
                //                $"values ('{createDateNow}',{acctID},{txnTypeID},{txnDetailID},{consultantID},@txnNull,@txnNull,'{txnNotes}')", conn.Connection());

                //    addTxn4R.Parameters.Add("@txnNull", SqlDbType.Decimal).Value = Convert.ToDecimal(txnNull, CultureInfo.CurrentCulture);
                //    addTxn4R.ExecuteNonQuery();
                //    if (conn != null)
                //    {
                //        conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
                //    }

                //    // We need to pull last TXN and assign the Value to txn_Id_4R and minus 0ne to txn_Id_4P. 


                //    string lastTxnID = $"SELECT [txn_Id] FROM [tbl_transactions]\r\nWHERE [txn_Id] = (\r\n    SELECT MAX([txn_Id]) FROM [tbl_transactions])";
                //    SqlDataAdapter adpt10 = new SqlDataAdapter(lastTxnID, conn.Connection());
                //    DataTable dt10 = new DataTable();
                //    adpt10.Fill(dt10);
                //    if (conn != null)
                //    {
                //        conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
                //    }


                //    txn_Id_4R = dt10.Rows[0][0].ToString();

                //    int intTxn_Id_4P;
                //    int intTxn_Id_4R;

                //    intTxn_Id_4R = int.Parse(txn_Id_4R);
                //    intTxn_Id_4P = intTxn_Id_4R - 1;

                //    txn_Id_4P = intTxn_Id_4P.ToString();

                //    //Now we have Txn Id s for tbl_earnedSalarie tables. 

                //    //*************   TXN Null Debit Credit Row Add Finished Here ***************************************************



                //    // Calculate the Hourly Wage for all 
                //    if (emplNationalityID == "1") // For BG
                //    {
                //        wDays = WorkingDays.GetWorkingDaysInMonth(year, month);
                //        wDays -= int.Parse(Extra_Holiday_BG_DropDownList.SelectedValue);

                //    }
                //    else if (emplNationalityID == "3")  // For TR
                //    {
                //        wDays = WorkingDays.GetWorkingDaysInMonth(year, month, 1);
                //        wDays -= int.Parse(Extra_Holiday_TR_DropDownList.SelectedValue);
                //    }
                //    else if (emplNationalityID == "4")  // For SAA
                //    {
                //        wDays = WorkingDays.GetWorkingDaysInMonth(year, month, 1);
                //        wDays -= int.Parse(Extra_Holiday_SAA_DropDownList.SelectedValue);

                //    }

                //    double wageDouble = double.Parse(wageDot);
                //    double dailyWageDouble = wageDouble / wDays;
                //    double hourWageDouble = dailyWageDouble / int.Parse(hourPerDay);

                //    hourWage = hourWageDouble.ToString();

                //    // Add to tbl_earnedSalarie 

                //    SqlCommand addProgressPayment = new SqlCommand($"insert into [tbl_earnedSalarie] ([emp_ID]\r\n      ,[acct_ID]\r\n      ,[cal_Date]\r\n      ,[related_Month]\r\n      ,[emp_Salarie]\r\n      ,[emp_Wage]\r\n      ,[emp_Hourly_Wage]\r\n , [emp_Working_Hour]     ,[emp_Meal_Supp]\r\n      ,[emp_Coffe_Supp]\r\n      ,[emp_add_Supp], [overtime_WagePHour],[over_Working_Hour],[txn_Id_4P],[txn_Id_4R])" +

                //        $"values ('{emplID}','{acctID}','{createDateNow}','{earnedMonth}',@salaryDot,@wageDot,@hourWage,'0',@mealSupportDot,@coffeeSupportDot,@additionalSupportDot,@overTimeWagePerHourDot,'0','{txn_Id_4P}','{txn_Id_4R}')", conn.Connection());
                //    addProgressPayment.Parameters.Add("@salaryDot", SqlDbType.Decimal).Value = Convert.ToDecimal(salaryDot, CultureInfo.CurrentCulture);
                //    addProgressPayment.Parameters.Add("@wageDot", SqlDbType.Decimal).Value = Convert.ToDecimal(wageDot, CultureInfo.CurrentCulture);
                //    addProgressPayment.Parameters.Add("@hourWage", SqlDbType.Decimal).Value = Convert.ToDecimal(hourWage, CultureInfo.CurrentCulture);
                //    addProgressPayment.Parameters.Add("@mealSupportDot", SqlDbType.Decimal).Value = Convert.ToDecimal(mealSupportDot, CultureInfo.CurrentCulture);
                //    addProgressPayment.Parameters.Add("@coffeeSupportDot", SqlDbType.Decimal).Value = Convert.ToDecimal(coffeeSupportDot, CultureInfo.CurrentCulture);
                //    addProgressPayment.Parameters.Add("@additionalSupportDot", SqlDbType.Decimal).Value = Convert.ToDecimal(additionalSupportDot, CultureInfo.CurrentCulture);
                //    addProgressPayment.Parameters.Add("@overTimeWagePerHourDot", SqlDbType.Decimal).Value = Convert.ToDecimal(overTimeWagePerHourDot, CultureInfo.CurrentCulture);
                //    addProgressPayment.ExecuteNonQuery();
                //    if (conn != null)
                //    {
                //        conn.Connection().Close(); // Close the connection in a finally block to ensure it always gets closed.
                //    }








                //    emplDt.Rows.Clear();  // We clear the rows for new data. 


                //    //Check if the empleyee has an earning ın that month and do not add these to Erning period Table !!!!


                //}
                ////*********************************************************************
                foreach (var item in row.ItemArray)
                {
                    string emplID = item.ToString();

                    using (SqlConnection sqlConn = conn.Connection())
                    {
                        string com = "SELECT * FROM tbl_employee WHERE empl_Id=@emplID";
                        using (SqlCommand cmd = new SqlCommand(com, sqlConn))
                        {
                            cmd.Parameters.AddWithValue("@emplID", emplID);

                            DataTable emplDt = new DataTable();
                            using (SqlDataAdapter sda2 = new SqlDataAdapter(cmd))
                            {
                                sda2.Fill(emplDt);
                            }

                            // Check if emplDt is not null and has rows
                            if (emplDt != null && emplDt.Rows.Count > 0)
                            {
                                // Process the DataTable
                                string emplNationalityID = emplDt.Rows[0][5].ToString();
                                string acctID = emplDt.Rows[0][16].ToString();
                                string salaryDot = emplDt.Rows[0][10].ToString();
                                string wageDot = emplDt.Rows[0][11].ToString();
                                string mealSupportDot = emplDt.Rows[0][17].ToString();
                                string coffeeSupportDot = emplDt.Rows[0][18].ToString();
                                string additionalSupportDot = emplDt.Rows[0][19].ToString();
                                string hourPerDay = emplDt.Rows[0][21].ToString();
                                string overTimeWagePerHourDot = emplDt.Rows[0][23].ToString();

                                // Calculate working days
                                int wDays = 0;
                                if (emplNationalityID == "1") // For BG
                                {
                                    wDays = WorkingDays.GetWorkingDaysInMonth(year, month);
                                    wDays -= int.Parse(Extra_Holiday_BG_DropDownList.SelectedValue);
                                }
                                else if (emplNationalityID == "3")  // For TR
                                {
                                    wDays = WorkingDays.GetWorkingDaysInMonth(year, month, 1);
                                    wDays -= int.Parse(Extra_Holiday_TR_DropDownList.SelectedValue);
                                }
                                else if (emplNationalityID == "4")  // For SAA
                                {
                                    wDays = WorkingDays.GetWorkingDaysInMonth(year, month, 1);
                                    wDays -= int.Parse(Extra_Holiday_SAA_DropDownList.SelectedValue);
                                }

                                // Calculate hourly wage
                                double wageDouble = double.Parse(wageDot);
                                double dailyWageDouble = wageDouble / wDays;
                                double hourWageDouble = dailyWageDouble / int.Parse(hourPerDay);
                                string hourWage = hourWageDouble.ToString();

                                
                                string txnNotes = "txn From 4P Wage " + earnedMonth;

                                // Add rows to tbl_transactions table
                                AddTransaction(sqlConn, createDateNow, acctID, "5", "20", "1", txnNotes);

                                txnNotes = "txn From 4R Wage " + earnedMonth;

                                AddTransaction(sqlConn, createDateNow, acctID, "5", "21", "2", txnNotes);

                                // Get last txn Id
                                string lastTxnID = "SELECT MAX(txn_Id) FROM tbl_transactions";
                                SqlCommand getLastTxnIdCmd = new SqlCommand(lastTxnID, sqlConn);
                                string txn_Id_4R = getLastTxnIdCmd.ExecuteScalar().ToString();
                                int intTxn_Id_4P = int.Parse(txn_Id_4R) - 1;
                                string txn_Id_4P = intTxn_Id_4P.ToString();

                                // Add rows to tbl_earnedSalarie table
                                AddProgressPayment(sqlConn, emplID, acctID, createDateNow, earnedMonth, salaryDot, wageDot, hourWage, mealSupportDot, coffeeSupportDot, additionalSupportDot, overTimeWagePerHourDot, txn_Id_4P, txn_Id_4R);

                                // Clear the DataTable after use
                                emplDt.Rows.Clear();
                            }

                            
                        }
                    }
                }

            }





            jQueryRelated_Month_Progress_Payment_GridViewBind();

            DataKeyCheckBox.Visible = true;
            DetailCheckBox.Visible = true;

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


            // RE Write With Using Statement 

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



            using (SqlConnection sqlConn = conn.Connection())
            {
                SqlCommand editEarning = new SqlCommand(
                    $"UPDATE [tbl_earnedSalarie] " +
                    $"SET [emp_Salarie] = @uPreletedMonthSalarieTxtBoxDot, " +
                    $"[emp_Wage] = @uPreletedWageTxtBoxDot, " +
                    $"[emp_Hourly_Wage] = @uPreletedWage_Per_HourTxtBoxDot, " +
                    $"[emp_Working_Hour] = @uPreletedHour_WorkedTxtBoxDot, " +
                    $"[emp_Meal_Supp] = @uPmealSupportTextBoxDot, " +
                    $"[emp_Coffe_Supp] = @uPcoffeeSupportTextBoxDot, " +
                    $"[emp_add_Supp] = @uPadditionalSupportTextBoxDot, " +
                    $"[overtime_WagePHour] = @uPoverTimeWagePerHourTxtBoxDot, " +
                    $"[over_Working_Hour] = @uPover_Working_HourTxtBoxDot " +
                    $"WHERE [earnedSal_ID] = @progressID", sqlConn);

                editEarning.Parameters.Add("@uPreletedMonthSalarieTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPreletedMonthSalarieTxtBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@uPreletedWageTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPreletedWageTxtBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@uPreletedWage_Per_HourTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPreletedWage_Per_HourTxtBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@uPreletedHour_WorkedTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPreletedHour_WorkedTxtBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@uPmealSupportTextBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPmealSupportTextBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@uPcoffeeSupportTextBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPcoffeeSupportTextBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@uPadditionalSupportTextBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPadditionalSupportTextBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@uPoverTimeWagePerHourTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPoverTimeWagePerHourTxtBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@uPover_Working_HourTxtBoxDot", SqlDbType.Decimal).Value = Convert.ToDecimal(uPover_Working_HourTxtBoxDot, CultureInfo.CurrentCulture);
                editEarning.Parameters.Add("@progressID", SqlDbType.NVarChar).Value = progressID;

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


            // RE Write With Using Statement 

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

            using (SqlConnection sqlConn = conn.Connection())
            {
                SqlCommand editTXN4p = new SqlCommand(
                    $"UPDATE tbl_transactions " +
                    $"SET txn_Credit = @txn_4PDot " +
                    $"WHERE txn_ID = @txn_ID_4P", sqlConn);

                editTXN4p.Parameters.Add("@txn_4PDot", SqlDbType.Decimal).Value = Convert.ToDecimal(txn_4PDot, CultureInfo.CurrentCulture);
                editTXN4p.Parameters.Add("@txn_ID_4P", SqlDbType.NVarChar).Value = txn_ID_4P;

                editTXN4p.ExecuteNonQuery();
            }

            using (SqlConnection sqlConn = conn.Connection())
            {
                SqlCommand editTXN4r = new SqlCommand(
                    $"UPDATE tbl_transactions " +
                    $"SET txn_Credit = @txn_4RDot " +
                    $"WHERE txn_ID = @txn_ID_4R", sqlConn);

                editTXN4r.Parameters.Add("@txn_4RDot", SqlDbType.Decimal).Value = Convert.ToDecimal(txn_4RDot, CultureInfo.CurrentCulture);
                editTXN4r.Parameters.Add("@txn_ID_4R", SqlDbType.NVarChar).Value = txn_ID_4R;

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


        // Add after Chat GPT Code Rewiiw about Using Statement ****************************** Yaklaşım Doğru Ancak Bussiness Logic Hatalı GPT De 

        private void AddProgressPayment(SqlConnection sqlConn, string emplID, string acctID, string createDateNow, string earnedMonth, string salaryDot, string wageDot, string hourWage, string mealSupportDot, string coffeeSupportDot, string additionalSupportDot, string overTimeWagePerHourDot, string txn_Id_4P, string txn_Id_4R)
        {

            SqlCommand addProgressPayment = new SqlCommand(
                $"INSERT INTO tbl_earnedSalarie (emp_ID, acct_ID, cal_Date, related_Month, emp_Salarie, emp_Wage, emp_Hourly_Wage, emp_Working_Hour, emp_Meal_Supp, emp_Coffe_Supp, emp_add_Supp, overtime_WagePHour, over_Working_Hour, txn_Id_4P, txn_Id_4R) " +
                $"VALUES (@emplID, @acctID, @createDateNow, @earnedMonth, @salaryDot, @wageDot, @hourWage, '0', @mealSupportDot, @coffeeSupportDot, @additionalSupportDot, @overTimeWagePerHourDot, '0', @txn_Id_4P, @txn_Id_4R)",
                sqlConn);

            addProgressPayment.Parameters.AddWithValue("@emplID", emplID);
            addProgressPayment.Parameters.AddWithValue("@acctID", acctID);
            addProgressPayment.Parameters.AddWithValue("@createDateNow", createDateNow);
            addProgressPayment.Parameters.AddWithValue("@earnedMonth", earnedMonth);
            addProgressPayment.Parameters.AddWithValue("@salaryDot", Convert.ToDecimal(salaryDot, CultureInfo.CurrentCulture));
            addProgressPayment.Parameters.AddWithValue("@wageDot", Convert.ToDecimal(wageDot, CultureInfo.CurrentCulture));
            addProgressPayment.Parameters.AddWithValue("@hourWage", Convert.ToDecimal(hourWage, CultureInfo.CurrentCulture));
            addProgressPayment.Parameters.AddWithValue("@mealSupportDot", Convert.ToDecimal(mealSupportDot != " " ? mealSupportDot : "0", CultureInfo.CurrentCulture));
            addProgressPayment.Parameters.AddWithValue("@coffeeSupportDot", Convert.ToDecimal(coffeeSupportDot != " " ? coffeeSupportDot : "0", CultureInfo.CurrentCulture));
            addProgressPayment.Parameters.AddWithValue("@additionalSupportDot", Convert.ToDecimal(string.IsNullOrEmpty(additionalSupportDot) ? "0" : additionalSupportDot, CultureInfo.CurrentCulture));
            addProgressPayment.Parameters.AddWithValue("@overTimeWagePerHourDot", Convert.ToDecimal(string.IsNullOrEmpty(overTimeWagePerHourDot) ? "0" : overTimeWagePerHourDot, CultureInfo.CurrentCulture));
            addProgressPayment.Parameters.AddWithValue("@txn_Id_4P", txn_Id_4P);
            addProgressPayment.Parameters.AddWithValue("@txn_Id_4R", txn_Id_4R);

            addProgressPayment.ExecuteNonQuery();
        }

        private void AddTransaction(SqlConnection sqlConn, string createDateNow, string acctID, string txnTypeID, string txnDetailID, string consultantID, string txnNotes)
        {
            SqlCommand addTxn = new SqlCommand(
                $"INSERT INTO tbl_transactions (txn_Date, acct_ID, txn_Type_ID, txn_Detail_ID, consultant_ID, txn_Debit, txn_Credit, txn_Notes) " +
                $"VALUES (@createDateNow, @acctID, @txnTypeID, @txnDetailID, @consultantID, @txnNull, @txnNull, @txnNotes)",
                sqlConn);

            addTxn.Parameters.AddWithValue("@createDateNow", createDateNow);
            addTxn.Parameters.AddWithValue("@acctID", acctID);
            addTxn.Parameters.AddWithValue("@txnTypeID", txnTypeID);
            addTxn.Parameters.AddWithValue("@txnDetailID", txnDetailID);
            addTxn.Parameters.AddWithValue("@consultantID", consultantID);
            addTxn.Parameters.AddWithValue("@txnNull", Convert.ToDecimal("0", CultureInfo.CurrentCulture));
            addTxn.Parameters.AddWithValue("@txnNotes", txnNotes);

            addTxn.ExecuteNonQuery();
        }





        




    }
}