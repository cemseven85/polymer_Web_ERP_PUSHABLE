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
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace polymer_Web_ERP_V4
{
    public partial class edittEmployee_ERP : System.Web.UI.Page
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

        //}

        private void DropDownGenderBind()
        {
            string com = "Select * from tbl_gender";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
            {
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
            string com = "Select * from tbl_origin";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
            {
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
            string com = "Select * from tbl_title";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
            {
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
            string com = "Select * from tbl_department";
            using (SqlDataAdapter adpt = new SqlDataAdapter(com, conn.Connection()))
            {
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

        protected void jQueryEmployeeGridView_PreRender(object sender, EventArgs e)
        {
            this.EmployeeGridViewBind();

            if (jQueryEmployeeGridView.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                jQueryEmployeeGridView.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                jQueryEmployeeGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                jQueryEmployeeGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }


        // Try to makae a method for Encoding and Decoding Turkish Characters


        // Encode and Decode Turkish Characters



        //protected void jQueryEmployeeGridView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = jQueryEmployeeGridView.SelectedRow;



        //    string employeeID = row.Cells[1].Text;


        //    string com1 = $"select *from [tbl_employee] where [empl_Id]='{employeeID}'";
        //    SqlDataAdapter adpt1 = new SqlDataAdapter(com1, conn.Connection());
        //    DataTable dt1 = new DataTable();
        //    adpt1.Fill(dt1);
        //    string genderID = dt1.Rows[0][3].ToString();


        //    // BirthDay
        //    string birthDayTime = dt1.Rows[0][4].ToString();
        //    int birthDayTimeLenght = birthDayTime.Length;

        //    string daybirth;
        //    string monthbirth;
        //    string yearbirth;
        //    string birthDay;

        //    if (birthDayTimeLenght == 19)
        //    {

        //        daybirth = birthDayTime.Substring(0, 2);
        //        monthbirth = birthDayTime.Substring(3, 2);
        //        yearbirth = birthDayTime.Substring(6, 4);
        //        birthDay = yearbirth + "-" + monthbirth + "-" + daybirth;

        //    }
        //    else
        //    {

        //        daybirth = birthDayTime.Substring(0, 1);
        //        monthbirth = birthDayTime.Substring(2, 2);
        //        yearbirth = birthDayTime.Substring(5, 4);
        //        birthDay = yearbirth + "-" + monthbirth + "-0" + daybirth;

        //    }

        //    Birth_DateTextBox.Text = birthDay;



        //    //HireDay
        //    string hireDayTime = dt1.Rows[0][6].ToString();
        //    int hireDayTimeLenght = birthDayTime.Length;

        //    string dayHire;
        //    string monthHire;
        //    string yearHire;
        //    string hireDay;


        //    if (hireDayTimeLenght == 19)
        //    {

        //        dayHire = hireDayTime.Substring(0, 2);
        //        monthHire = hireDayTime.Substring(3, 2);
        //        yearHire = hireDayTime.Substring(6, 4);
        //        hireDay = yearHire + "-" + monthHire + "-" + dayHire;

        //    }
        //    else
        //    {

        //        dayHire = hireDayTime.Substring(0, 1);
        //        monthHire = hireDayTime.Substring(2, 2);
        //        yearHire = hireDayTime.Substring(5, 4);
        //        hireDay = yearHire + "-" + monthHire + "-0" + dayHire;

        //    }

        //    Hire_DateTextBox.Text = hireDay;



        //    //QuitDay
        //    string quitDayTime = dt1.Rows[0][7].ToString();
        //    int quitDayTimeLength = quitDayTime.Length;

        //    string dayQuit;
        //    string monthQuit;
        //    string yearQuit;
        //    string quitDay;

        //    try
        //    {

        //        if (quitDayTimeLength == 19)
        //        {

        //            dayQuit = quitDayTime.Substring(0, 2);
        //            monthQuit = quitDayTime.Substring(3, 2);
        //            yearQuit = quitDayTime.Substring(6, 4);
        //            quitDay = yearQuit + "-" + monthQuit + "-" + dayQuit;

        //        }

        //        else
        //        {

        //            dayQuit = quitDayTime.Substring(0, 1);
        //            monthQuit = quitDayTime.Substring(2, 2);
        //            yearQuit = quitDayTime.Substring(5, 4);
        //            quitDay = yearQuit + "-" + monthQuit + "-0" + dayQuit;

        //        }

        //        Quit_DateTextBox.Text = quitDay;
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        Quit_DateTextBox.Text = quitDayTime;
        //    }


        //    // GSM  Name-BG  Name-TR Last Name
        //    string gsm = dt1.Rows[0][12].ToString();

        //    Employee_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);

        //    // Trying to Encode Turkish Characters
        //    /*
        //    string encodedTRName = row.Cells[3].Text.Replace("&nbsp;", " ");
        //    string decodedTRName = HttpUtility.HtmlDecode(encodedTRName);           
        //   */

        //    Employee_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);   // We start to meke Encode Decode With Method

        //    Employee_LastName_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);


        //    //Gender
        //    GenderTypeIdDropDownList.SelectedValue = genderID;




        //    //GSM
        //    GSMTextBox.Text = gsm;


        //    // Nationality_Name to Nationality_ID
        //    string nationalityName = row.Cells[5].Text;
        //    string com2 = $"select [org_ID] from [tbl_origin] where [org_Name]='{nationalityName}'";
        //    SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection());
        //    DataTable dt2 = new DataTable();
        //    adpt2.Fill(dt2);
        //    string rid2 = dt2.Rows[0][0].ToString();
        //    OriginIdDropDownList.SelectedValue = rid2;

        //    // Title_Name to Title_ID
        //    string titleName = row.Cells[6].Text;
        //    string com3 = $"select [tl_Id] from [tbl_title] where [tl_Name]='{titleName}'";
        //    SqlDataAdapter adpt3 = new SqlDataAdapter(com3, conn.Connection());
        //    DataTable dt3 = new DataTable();
        //    adpt3.Fill(dt3);
        //    string rid3 = dt3.Rows[0][0].ToString();
        //    TitleIdDropDownList.SelectedValue = rid3;

        //    // Department_Name to Department_ID
        //    string departmentName = row.Cells[7].Text;
        //    string com4 = $"select [dep_Id] from [tbl_department] where [dep_Name]='{departmentName}'";
        //    SqlDataAdapter adpt4 = new SqlDataAdapter(com4, conn.Connection());
        //    DataTable dt4 = new DataTable();
        //    adpt4.Fill(dt4);
        //    string rid4 = dt4.Rows[0][0].ToString();
        //    DepartmentIdDropDownList.SelectedValue = rid4;


        //    //Salerie 
        //    SalerieTextBox.Text = EncodeDecodeModule.EncodeDecode(row, 8);    // TAKE DATA FROM DATABASE TO AVOİD MONEY FLOAT PROBLEM 

        //    //Total Cost
        //    WageTextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);


        //    OvertimeWagePerHourTextBox.Text = EncodeDecodeModule.EncodeDecode(row, 22);


        //    //Status 
        //    string status = EncodeDecodeModule.EncodeDecode(row, 10);

        //    if (status == "Select Status")
        //    {
        //        StatusDropDownList.SelectedValue = "0";
        //    }
        //    else if (status == "Active")
        //    {
        //        StatusDropDownList.SelectedValue = "1";
        //    }
        //    else if (status == "Not Active")
        //    {
        //        StatusDropDownList.SelectedValue = "2";
        //    }


        //    //Notes
        //    Notes_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);



        //    // meal - coffrr  - additional Supports  

        //    MealSupport_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 16);

        //    CoffeeSupport_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 17);

        //    AdditionalSupport_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 18);

        //    days_Per_Week_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 19);

        //    hours_per_Day_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 20);

        //    soc_Sec_Tax_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 21);




        //}



        protected void jQueryEmployeeGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = jQueryEmployeeGridView.SelectedRow;

            string employeeID = row.Cells[1].Text;

            string com1 = $"select * from [tbl_employee] where [empl_Id]='{employeeID}'";
            using (SqlDataAdapter adpt1 = new SqlDataAdapter(com1, conn.Connection()))
            {
                DataTable dt1 = new DataTable();
                adpt1.Fill(dt1);
                string genderID = dt1.Rows[0][3].ToString();

                // BirthDay
                string birthDayTime = dt1.Rows[0][4].ToString();
                int birthDayTimeLenght = birthDayTime.Length;

                string daybirth;
                string monthbirth;
                string yearbirth;
                string birthDay;

                if (birthDayTimeLenght == 19)
                {
                    daybirth = birthDayTime.Substring(0, 2);
                    monthbirth = birthDayTime.Substring(3, 2);
                    yearbirth = birthDayTime.Substring(6, 4);
                    birthDay = yearbirth + "-" + monthbirth + "-" + daybirth;
                }
                else
                {
                    daybirth = birthDayTime.Substring(0, 1);
                    monthbirth = birthDayTime.Substring(2, 2);
                    yearbirth = birthDayTime.Substring(5, 4);
                    birthDay = yearbirth + "-" + monthbirth + "-0" + daybirth;
                }
                Birth_DateTextBox.Text = birthDay;

                //HireDay
                string hireDayTime = dt1.Rows[0][6].ToString();
                int hireDayTimeLenght = birthDayTime.Length;

                string dayHire;
                string monthHire;
                string yearHire;
                string hireDay;

                if (hireDayTimeLenght == 19)
                {
                    dayHire = hireDayTime.Substring(0, 2);
                    monthHire = hireDayTime.Substring(3, 2);
                    yearHire = hireDayTime.Substring(6, 4);
                    hireDay = yearHire + "-" + monthHire + "-" + dayHire;
                }
                else
                {
                    dayHire = hireDayTime.Substring(0, 1);
                    monthHire = hireDayTime.Substring(2, 2);
                    yearHire = hireDayTime.Substring(5, 4);
                    hireDay = yearHire + "-" + monthHire + "-0" + dayHire;
                }
                Hire_DateTextBox.Text = hireDay;

                //QuitDay
                string quitDayTime = dt1.Rows[0][7].ToString();
                int quitDayTimeLength = quitDayTime.Length;

                string dayQuit;
                string monthQuit;
                string yearQuit;
                string quitDay;

                try
                {
                    if (quitDayTimeLength == 19)
                    {
                        dayQuit = quitDayTime.Substring(0, 2);
                        monthQuit = quitDayTime.Substring(3, 2);
                        yearQuit = quitDayTime.Substring(6, 4);
                        quitDay = yearQuit + "-" + monthQuit + "-" + dayQuit;
                    }
                    else
                    {
                        dayQuit = quitDayTime.Substring(0, 1);
                        monthQuit = quitDayTime.Substring(2, 2);
                        yearQuit = quitDayTime.Substring(5, 4);
                        quitDay = yearQuit + "-" + monthQuit + "-0" + dayQuit;
                    }
                    Quit_DateTextBox.Text = quitDay;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Quit_DateTextBox.Text = quitDayTime;
                }

                // GSM  Name-BG  Name-TR Last Name
                string gsm = dt1.Rows[0][12].ToString();
                Employee_Name_BG_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 2);
                Employee_Name_TR_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 3);
                Employee_LastName_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 4);

                //Gender
                GenderTypeIdDropDownList.SelectedValue = genderID;

                //GSM
                GSMTextBox.Text = gsm;

                // Nationality_Name to Nationality_ID
                string nationalityName = row.Cells[5].Text;
                string com2 = $"select [org_ID] from [tbl_origin] where [org_Name]='{nationalityName}'";
                using (SqlDataAdapter adpt2 = new SqlDataAdapter(com2, conn.Connection()))
                {
                    DataTable dt2 = new DataTable();
                    adpt2.Fill(dt2);
                    string rid2 = dt2.Rows[0][0].ToString();
                    OriginIdDropDownList.SelectedValue = rid2;
                }

                // Title_Name to Title_ID
                string titleName = row.Cells[6].Text;
                string com3 = $"select [tl_Id] from [tbl_title] where [tl_Name]='{titleName}'";
                using (SqlDataAdapter adpt3 = new SqlDataAdapter(com3, conn.Connection()))
                {
                    DataTable dt3 = new DataTable();
                    adpt3.Fill(dt3);
                    string rid3 = dt3.Rows[0][0].ToString();
                    TitleIdDropDownList.SelectedValue = rid3;
                }

                // Department_Name to Department_ID
                string departmentName = row.Cells[7].Text;
                string com4 = $"select [dep_Id] from [tbl_department] where [dep_Name]='{departmentName}'";
                using (SqlDataAdapter adpt4 = new SqlDataAdapter(com4, conn.Connection()))
                {
                    DataTable dt4 = new DataTable();
                    adpt4.Fill(dt4);
                    string rid4 = dt4.Rows[0][0].ToString();
                    DepartmentIdDropDownList.SelectedValue = rid4;
                }

                // Salerie
                SalerieTextBox.Text = EncodeDecodeModule.EncodeDecode(row, 8);

                //Total Cost
                WageTextBox.Text = EncodeDecodeModule.EncodeDecode(row, 9);
                OvertimeWagePerHourTextBox.Text = EncodeDecodeModule.EncodeDecode(row, 22);

                //Status 
                string status = EncodeDecodeModule.EncodeDecode(row, 10);
                if (status == "Select Status")
                {
                    StatusDropDownList.SelectedValue = "0";
                }
                else if (status == "Active")
                {
                    StatusDropDownList.SelectedValue = "1";
                }
                else if (status == "Not Active")
                {
                    StatusDropDownList.SelectedValue = "2";
                }

                //Notes
                Notes_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 11);

                // meal - coffrr  - additional Supports  
                MealSupport_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 16);
                CoffeeSupport_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 17);
                AdditionalSupport_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 18);
                days_Per_Week_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 19);
                hours_per_Day_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 20);
                soc_Sec_Tax_TextBox.Text = EncodeDecodeModule.EncodeDecode(row, 21);
            }
        }






        //protected void EditButton_Click(object sender, EventArgs e)
        //{
        //    if (jQueryEmployeeGridView.SelectedValue != null)
        //    {



        //        if (Page.IsValid)
        //        {

        //            GridViewRow row = jQueryEmployeeGridView.SelectedRow;

        //            string employeeID;
        //            string pemployeeNameTR;

        //            string genderTypeID;
        //            string birthDate;
        //            string originID;
        //            string hireDate;
        //            string quitDate;
        //            string titleID;
        //            string departmentID;
        //            string salerie;
        //            string wage;
        //            string wageDot;
        //            string gsm;
        //            string status;
        //            string notes;


        //            string mealSupport;
        //            string mealSupportDot;
        //            string coffeeSupport;
        //            string coffeeSupportDot;
        //            string additionalSupport;
        //            string additionalSupportDot;
        //            string dayPerWeak;
        //            string hourPerDay;
        //            string socSecTax;
        //            string socSecTaxDot;
        //            string overTimeWagePerHour;
        //            string overTimeWagePerHourDot;


        //            mealSupport = MealSupport_TextBox.Text;
        //            mealSupportDot = mealSupport.Replace(",", ".");
        //            mealSupportDot = mealSupportDot == " " ?"0" :mealSupportDot;
        //            coffeeSupport = CoffeeSupport_TextBox.Text;
        //            coffeeSupportDot = coffeeSupport.Replace(",", ".");
        //            coffeeSupportDot = coffeeSupportDot != " " ? coffeeSupportDot : "0";
        //            additionalSupport = AdditionalSupport_TextBox.Text;
        //            additionalSupportDot = additionalSupport.Replace(",", ".");
        //            additionalSupportDot = additionalSupportDot == " " ?"0":additionalSupportDot;
        //            dayPerWeak = days_Per_Week_TextBox.Text;
        //            hourPerDay = hours_per_Day_TextBox.Text;
        //            socSecTax = soc_Sec_Tax_TextBox.Text;
        //            socSecTaxDot = socSecTax.Replace(",", ".");
        //            socSecTaxDot = socSecTaxDot != " " ? socSecTaxDot : "0";
        //            overTimeWagePerHour = OvertimeWagePerHourTextBox.Text;
        //            overTimeWagePerHourDot = overTimeWagePerHour.Replace(",", ".");
        //            overTimeWagePerHourDot = overTimeWagePerHourDot != " " ? overTimeWagePerHourDot : "0";


        //            pemployeeNameTR = Employee_Name_TR_TextBox.Text;
        //            genderTypeID = GenderTypeIdDropDownList.SelectedValue;
        //            birthDate = Birth_DateTextBox.Text;
        //            originID = OriginIdDropDownList.SelectedValue;
        //            hireDate = Hire_DateTextBox.Text;
        //            quitDate = Quit_DateTextBox.Text;
        //            titleID = TitleIdDropDownList.SelectedValue;
        //            departmentID = DepartmentIdDropDownList.SelectedValue;
        //            salerie = SalerieTextBox.Text;
        //            wage = WageTextBox.Text;
        //            wageDot = wage.Replace(",", ".");   // For solving Money type problem in SQL  . You can use comma as decimal separator in presentation but not in code. Inside the code decimal values look like 49.55. 
        //            gsm = GSMTextBox.Text;
        //            status = StatusDropDownList.SelectedItem.Text;
        //            notes = Notes_TextBox.Text;
        //            employeeID = row.Cells[1].Text;

        //            SqlCommand editEmployee = new SqlCommand($"update [tbl_employee] set [empl_Name_BG]= @bgName , [empl_Name_TR]='{pemployeeNameTR}', [empl_Gender_Id]='{genderTypeID}',[empl_Birthday]='{birthDate}',[empl_Nationality_Id]='{originID}',[empl_HireDate]='{hireDate}',[empl_QuitDate]='{quitDate}',[empl_Title_ID]='{titleID}',[empl_Department_ID]='{departmentID}', [empl_Salerie]=REPLACE('{salerie}',',','.' ), [empl_Wage]='{wageDot}' ,[empl_GSM]='{gsm}',[empl_Notes]='{notes}',[empl_Last_Name]=@lastName ,[empl_Active]='{status}',[meal_Support]='{mealSupportDot}',[coffee_Support]='{coffeeSupportDot}',[additional_Support]='{additionalSupportDot}',[days_Per_Week]='{dayPerWeak}',[hours_Per_Day]='{hourPerDay}',[soc_Sec_Tax]='{socSecTaxDot}' ,[overtime_WagePHour]='{overTimeWagePerHourDot}' where [empl_Id] = '{employeeID}'", conn.Connection());
        //            editEmployee.Parameters.AddWithValue("@bgName", Employee_Name_BG_TextBox.Text);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
        //            editEmployee.Parameters.AddWithValue("@lastName", Employee_LastName_TextBox.Text);
        //            editEmployee.ExecuteNonQuery();


        //            Response.Redirect("editEmployee-ERP.aspx");

        //        }
        //        else
        //        {


        //            string message = "Wrong Format You Can Not Edit !!";
        //            string script = "if(confirm('" + message + "')){ window.location='editEmployee-ERP.aspx?'; }";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "EditConfirmation", script, true);


        //        }

        //    }
        //    else
        //    {
        //        string message = "You Did Not Select Employee ! You Can Not Edit !!";
        //        string script = "if(confirm('" + message + "')){ window.location='editEmployee-ERP.aspx?'; }";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "EditConfirmation", script, true);


        //    }


        //}


        protected void EditButton_Click(object sender, EventArgs e)
        {
            if (jQueryEmployeeGridView.SelectedValue != null)
            {
                if (Page.IsValid)
                {
                    GridViewRow row = jQueryEmployeeGridView.SelectedRow;

                    string employeeID;
                    string pemployeeNameTR;
                    string genderTypeID;
                    string birthDate;
                    string originID;
                    string hireDate;
                    string quitDate;
                    string titleID;
                    string departmentID;
                    string salerie;
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
                    mealSupportDot = mealSupportDot == " " ? "0" : mealSupportDot;
                    coffeeSupport = CoffeeSupport_TextBox.Text;
                    coffeeSupportDot = coffeeSupport.Replace(",", ".");
                    coffeeSupportDot = coffeeSupportDot != " " ? coffeeSupportDot : "0";
                    additionalSupport = AdditionalSupport_TextBox.Text;
                    additionalSupportDot = additionalSupport.Replace(",", ".");
                    additionalSupportDot = additionalSupportDot == " " ? "0" : additionalSupportDot;
                    dayPerWeak = days_Per_Week_TextBox.Text;
                    hourPerDay = hours_per_Day_TextBox.Text;
                    socSecTax = soc_Sec_Tax_TextBox.Text;
                    socSecTaxDot = socSecTax.Replace(",", ".");
                    socSecTaxDot = socSecTaxDot != " " ? socSecTaxDot : "0";
                    overTimeWagePerHour = OvertimeWagePerHourTextBox.Text;
                    overTimeWagePerHourDot = overTimeWagePerHour.Replace(",", ".");
                    overTimeWagePerHourDot = overTimeWagePerHourDot != " " ? overTimeWagePerHourDot : "0";

                    pemployeeNameTR = Employee_Name_TR_TextBox.Text;
                    genderTypeID = GenderTypeIdDropDownList.SelectedValue;
                    birthDate = Birth_DateTextBox.Text;
                    originID = OriginIdDropDownList.SelectedValue;
                    hireDate = Hire_DateTextBox.Text;
                    quitDate = Quit_DateTextBox.Text;
                    titleID = TitleIdDropDownList.SelectedValue;
                    departmentID = DepartmentIdDropDownList.SelectedValue;
                    salerie = SalerieTextBox.Text;
                    wage = WageTextBox.Text;
                    wageDot = wage.Replace(",", ".");
                    gsm = GSMTextBox.Text;
                    status = StatusDropDownList.SelectedItem.Text;
                    notes = Notes_TextBox.Text;
                    employeeID = row.Cells[1].Text;

                    using (SqlCommand editEmployee = new SqlCommand($"update [tbl_employee] set [empl_Name_BG]= @bgName , [empl_Name_TR]='{pemployeeNameTR}', [empl_Gender_Id]='{genderTypeID}',[empl_Birthday]='{birthDate}',[empl_Nationality_Id]='{originID}',[empl_HireDate]='{hireDate}',[empl_QuitDate]='{quitDate}',[empl_Title_ID]='{titleID}',[empl_Department_ID]='{departmentID}', [empl_Salerie]=REPLACE('{salerie}',',','.' ), [empl_Wage]='{wageDot}' ,[empl_GSM]='{gsm}',[empl_Notes]='{notes}',[empl_Last_Name]=@lastName ,[empl_Active]='{status}',[meal_Support]='{mealSupportDot}',[coffee_Support]='{coffeeSupportDot}',[additional_Support]='{additionalSupportDot}',[days_Per_Week]='{dayPerWeak}',[hours_Per_Day]='{hourPerDay}',[soc_Sec_Tax]='{socSecTaxDot}' ,[overtime_WagePHour]='{overTimeWagePerHourDot}' where [empl_Id] = '{employeeID}'", conn.Connection()))
                    {
                        editEmployee.Parameters.AddWithValue("@bgName", Employee_Name_BG_TextBox.Text);
                        editEmployee.Parameters.AddWithValue("@lastName", Employee_LastName_TextBox.Text);
                        editEmployee.ExecuteNonQuery();
                    }

                    Response.Redirect("editEmployee-ERP.aspx");
                }
                else
                {
                    string message = "Wrong Format You Can Not Edit !!";
                    string script = "if(confirm('" + message + "')){ window.location='editEmployee-ERP.aspx?'; }";
                    ScriptManager.RegisterStartupScript(this, GetType(), "EditConfirmation", script, true);
                }
            }
            else
            {
                string message = "You Did Not Select Employee ! You Can Not Edit !!";
                string script = "if(confirm('" + message + "')){ window.location='editEmployee-ERP.aspx?'; }";
                ScriptManager.RegisterStartupScript(this, GetType(), "EditConfirmation", script, true);
            }
        }





    }
}