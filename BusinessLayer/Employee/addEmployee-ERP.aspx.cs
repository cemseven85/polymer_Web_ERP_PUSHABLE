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

namespace polymer_Web_ERP_V4
{
    public partial class addEmployee_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                DropDownGenderBind();
                DropDownNationalityBind();
                DropDownTitleBind();
                DropDownDepartmentBind();
                EmployeeGridViewBind();

                 

            }

        }

        //private void DropDownGenderBind()
        //{
        //    string com = "Select * from tbl_gender";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt1 = new DataTable();
        //    adpt.Fill(dt1);
        //    GenderTypeIdDropDownList.DataSource = dt1;
        //    GenderTypeIdDropDownList.DataBind();
        //    GenderTypeIdDropDownList.DataTextField = "gend_Name";
        //    GenderTypeIdDropDownList.DataValueField = "gend_Id";
        //    GenderTypeIdDropDownList.DataBind();

        //    conn.Connection().Close();

        //}

        //private void DropDownNationalityBind()
        //{
        //    string com = "Select * from tbl_origin";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt1 = new DataTable();
        //    adpt.Fill(dt1);
        //    OriginIdDropDownList.DataSource = dt1;
        //    OriginIdDropDownList.DataBind();
        //    OriginIdDropDownList.DataTextField = "org_Name";
        //    OriginIdDropDownList.DataValueField = "org_Id";
        //    OriginIdDropDownList.DataBind();

        //    conn.Connection().Close();

        //}

        //private void DropDownTitleBind()
        //{
        //    string com = "Select * from tbl_title";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt1 = new DataTable();
        //    adpt.Fill(dt1);
        //    TitleIdDropDownList.DataSource = dt1;
        //    TitleIdDropDownList.DataBind();
        //    TitleIdDropDownList.DataTextField = "tl_Name";
        //    TitleIdDropDownList.DataValueField = "tl_Id";
        //    TitleIdDropDownList.DataBind();

        //    conn.Connection().Close();

        //}

        //private void DropDownDepartmentBind()
        //{
        //    string com = "Select * from tbl_department";
        //    SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection());
        //    DataTable dt1 = new DataTable();
        //    adpt.Fill(dt1);
        //    DepartmentIdDropDownList.DataSource = dt1;
        //    DepartmentIdDropDownList.DataBind();
        //    DepartmentIdDropDownList.DataTextField = "dep_Name";
        //    DepartmentIdDropDownList.DataValueField = "dep_Id";
        //    DepartmentIdDropDownList.DataBind();

        //    conn.Connection().Close();

        //}


        private void DropDownGenderBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = "SELECT * FROM tbl_gender";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt1 = new DataTable();
                adpt.Fill(dt1);
                GenderTypeIdDropDownList.DataSource = dt1;
                GenderTypeIdDropDownList.DataBind();
                GenderTypeIdDropDownList.DataTextField = "gend_Name";
                GenderTypeIdDropDownList.DataValueField = "gend_Id";
                GenderTypeIdDropDownList.DataBind();
            }
        }

        private void DropDownNationalityBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = "SELECT * FROM tbl_origin";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt1 = new DataTable();
                adpt.Fill(dt1);
                OriginIdDropDownList.DataSource = dt1;
                OriginIdDropDownList.DataBind();
                OriginIdDropDownList.DataTextField = "org_Name";
                OriginIdDropDownList.DataValueField = "org_Id";
                OriginIdDropDownList.DataBind();
            }
        }

        private void DropDownTitleBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = "SELECT * FROM tbl_title";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt1 = new DataTable();
                adpt.Fill(dt1);
                TitleIdDropDownList.DataSource = dt1;
                TitleIdDropDownList.DataBind();
                TitleIdDropDownList.DataTextField = "tl_Name";
                TitleIdDropDownList.DataValueField = "tl_Id";
                TitleIdDropDownList.DataBind();
            }
        }

        private void DropDownDepartmentBind()
        {
            using (SqlConnection sqlConn = conn.Connection())
            {
                string com = "SELECT * FROM tbl_department";
                SqlDataAdapter adpt = new SqlDataAdapter(com, sqlConn);
                DataTable dt1 = new DataTable();
                adpt.Fill(dt1);
                DepartmentIdDropDownList.DataSource = dt1;
                DepartmentIdDropDownList.DataBind();
                DepartmentIdDropDownList.DataTextField = "dep_Name";
                DepartmentIdDropDownList.DataValueField = "dep_Id";
                DepartmentIdDropDownList.DataBind();
            }
        }



        private void EmployeeGridViewBind()
        {                                                          // We add a connection string to web-config for using it, like data access leyer connection class. 
            string constr = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("execute prc_listEmployee", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        jQueryEmployeeGridView.DataSource = dt;
                        jQueryEmployeeGridView.DataBind();
                    }

                }
            }
            //Required for jQuery DataTables to work.
            jQueryEmployeeGridView.UseAccessibleHeader = true;
            jQueryEmployeeGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

        }


        protected void AddButton_Click(object sender, EventArgs e)
        {


            if (Page.IsValid)
            {


                string pemployeeNameTR;

                string genderTypeID;
                string birthDate;
                string originID;
                string hireDate;
                string quitDate;
                string titleID;
                string departmentID;
                string salary;
                string salaryDot;
                string wage;
                string wageDot;
                string gsm;
                string status;
                string notes;

                string mealSupport;
                string mealSupportDot;
                string coffeeSupport;
                string coffeeSupportDot;
                string additionalSupport;
                string additionalSupportDot;
                string dayPerWeak;
                string hourPerDay;
                string socSecTax;
                string socSecTaxDot;
                string overTimeWagePerHour;
                string overTimeWagePerHourDot;


                mealSupport = MealSupport_TextBox.Text;
                mealSupportDot = mealSupport.Replace(",", ".");
                coffeeSupport = CoffeeSupport_TextBox.Text;
                coffeeSupportDot = coffeeSupport.Replace(",", ".");
                additionalSupport = AdditionalSupport_TextBox.Text;
                additionalSupportDot = additionalSupport.Replace(",", ".");
                dayPerWeak = days_Per_Week_TextBox.Text;
                hourPerDay = hours_per_Day_TextBox.Text;
                socSecTax = soc_Sec_Tax_TextBox.Text;
                socSecTaxDot = socSecTax.Replace(",", ".");
                overTimeWagePerHour = OvertimeWagePerHourTextBox.Text;
                overTimeWagePerHourDot = overTimeWagePerHour.Replace(",",".");
                    



                pemployeeNameTR = Employee_Name_TR_TextBox.Text;
                genderTypeID = GenderTypeIdDropDownList.SelectedValue;
                birthDate = Birth_DateTextBox.Text;
                originID = OriginIdDropDownList.SelectedValue;
                hireDate = Hire_DateTextBox.Text;
                quitDate = Quit_DateTextBox.Text;
                titleID = TitleIdDropDownList.SelectedValue;
                departmentID = DepartmentIdDropDownList.SelectedValue;
                salary = SalerieTextBox.Text;
                salaryDot = salary.Replace(",", ".");
                wage = WageTextBox.Text;
                wageDot = wage.Replace(",", ".");
                gsm = GSMTextBox.Text;
                status = StatusDropDownList.SelectedItem.Text;
                notes = Notes_TextBox.Text;


                // We can Create acct and pull the acctID and when we are creating the Employee enrolle the acctID.

                // Create new acct

                DateTime dateTxn = DateTime.Now;

                string acctCreateDate = dateTxn.ToString("yyyy-MM-dd");
                string acctType = "3"; // All Emplloyee account type is 3. 

                //SqlCommand addNewAcount = new SqlCommand($"insert into [tbl_account] ([acct_Name],[acct_Create_Date],[acct_Type_ID],[acct_Notes]) values ('{pemployeeNameTR}','{acctCreateDate}','{acctType}','{notes}') ", conn.Connection());
                //addNewAcount.ExecuteNonQuery();

                using (SqlCommand addNewAcount = new SqlCommand($"INSERT INTO [tbl_account] ([acct_Name],[acct_Create_Date],[acct_Type_ID],[acct_Notes]) VALUES ('{pemployeeNameTR}','{acctCreateDate}','{acctType}','{notes}')", conn.Connection()))
                {
                    addNewAcount.ExecuteNonQuery();
                }


                // Pull the last accunt ID 



                //string pullLastAcctID = $"SELECT [acct_ID] FROM [tbl_account]\r\n WHERE [acct_ID] = (\r\n SELECT MAX([acct_ID]) FROM [tbl_account])";
                //SqlDataAdapter adpt20 = new SqlDataAdapter(pullLastAcctID, conn.Connection());
                //DataTable dt20 = new DataTable();
                //adpt20.Fill(dt20);
                //string acctId = dt20.Rows[0][0].ToString();   // Last acct ID

                string pullLastAcctID = $"SELECT [acct_ID] FROM [tbl_account] WHERE [acct_ID] = (SELECT MAX([acct_ID]) FROM [tbl_account])";
                DataTable dt20 = new DataTable();

                using (SqlDataAdapter adpt20 = new SqlDataAdapter(pullLastAcctID, conn.Connection()))
                {
                    adpt20.Fill(dt20);
                }

                string acctId = dt20.Rows[0][0].ToString();   // Last acct ID



                //SqlCommand addNewEmployee = new SqlCommand($"insert into [tbl_employee] ([empl_Name_BG],[empl_Name_TR],[empl_Gender_Id],[empl_Birthday],[empl_Nationality_Id],[empl_HireDate],[empl_QuitDate],[empl_Title_ID],[empl_Department_ID],[empl_Salerie],[empl_Wage],[empl_GSM],[empl_Notes],[empl_Last_Name],[empl_Active],[acct_ID],[meal_Support],[coffee_Support],[additional_Support],[days_Per_Week],[hours_Per_Day],[soc_Sec_Tax],[overtime_WagePHour]) " +
                //    $"values ( @bgName , '{pemployeeNameTR}','{genderTypeID}' ,'{birthDate}','{originID}','{hireDate}', '{quitDate}','{titleID}','{departmentID}','{salaryDot}','{wageDot}','{gsm}','{notes}',@lastName ,'{status}','{acctId}','{mealSupport}','{coffeeSupportDot}','{additionalSupportDot}',{dayPerWeak},{hourPerDay},{socSecTaxDot},{overTimeWagePerHourDot})", conn.Connection());
                //addNewEmployee.Parameters.AddWithValue("@bgName", Employee_Name_BG_TextBox.Text);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
                //addNewEmployee.Parameters.AddWithValue("@lastName", Employee_LastName_TextBox.Text);
                //addNewEmployee.ExecuteNonQuery();


                //Response.Redirect("addEmployee-ERP.aspx");

                //conn.Connection().Close();


                using (SqlCommand addNewEmployee = new SqlCommand($"insert into [tbl_employee] ([empl_Name_BG],[empl_Name_TR],[empl_Gender_Id],[empl_Birthday],[empl_Nationality_Id],[empl_HireDate],[empl_QuitDate],[empl_Title_ID],[empl_Department_ID],[empl_Salerie],[empl_Wage],[empl_GSM],[empl_Notes],[empl_Last_Name],[empl_Active],[acct_ID],[meal_Support],[coffee_Support],[additional_Support],[days_Per_Week],[hours_Per_Day],[soc_Sec_Tax],[overtime_WagePHour]) " +
                    $"values ( @bgName , '{pemployeeNameTR}','{genderTypeID}' ,'{birthDate}','{originID}','{hireDate}', '{quitDate}','{titleID}','{departmentID}','{salaryDot}','{wageDot}','{gsm}','{notes}',@lastName ,'{status}','{acctId}','{mealSupport}','{coffeeSupportDot}','{additionalSupportDot}',{dayPerWeak},{hourPerDay},{socSecTaxDot},{overTimeWagePerHourDot})", conn.Connection()))
                {
                    addNewEmployee.Parameters.AddWithValue("@bgName", Employee_Name_BG_TextBox.Text);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
                    addNewEmployee.Parameters.AddWithValue("@lastName", Employee_LastName_TextBox.Text);
                    addNewEmployee.ExecuteNonQuery();
                }

                Response.Redirect("addEmployee-ERP.aspx");

            }

            else
            {

                string message = "Wrong Format You Can Not Add !!";
                string script = "if(confirm('" + message + "')){ window.location='addEmployee-ERP.aspx?'; }";
                ScriptManager.RegisterStartupScript(this, GetType(), "AddConfirmation", script, true);

                conn.Connection().Close();

            }






        }

        


        


    }
}