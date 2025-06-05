<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addEmployee-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addEmployee_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-type">

        <asp:ScriptManager runat="server" />
        <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->

        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_3" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Employee_Name_Label_BG" runat="server" Text="Име на служителя (BG)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Employee_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_4" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Employee_Name_TR_Label" runat="server" Text="Personel Adı (TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Employee_Name_TR_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="Employee_Name_TR_TextBox">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_2" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Employee_LastName_Lable" runat="server" Text="Employee Last Name (TR-BG)" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Employee_LastName_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Product_Panel_1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Gender_Type_Label" runat="server" Text="Select Gender Type" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="GenderTypeIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_11" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Birth_Date_Lable" runat="server" Text="Birth Date" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Birth_DateTextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_5" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Employee_Nationality_Label" runat="server" Text="Select Nationality" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="OriginIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_12" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Hire_Date_Label" runat="server" Text="Hire Date" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Hire_DateTextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_13" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Quit_Date_Label" runat="server" Text="Quit Date" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Quit_DateTextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Product_Panel_6" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Title_Label" runat="server" Text="Select Employee Title" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="TitleIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Product_Panel_7" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Department_Label" runat="server" Text="Select Department" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DepartmentIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_14" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Salerie_Label" runat="server" Text="Employee Salerie" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="SalerieTextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="SalerieTextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="SalerieTextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>

                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Product_Panel_15" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Wage_Label" runat="server" Text="Employee Wage" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="WageTextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                 CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="WageTextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                ControlToValidate="WageTextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel7" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Overtime Wage Per Hour" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="OvertimeWagePerHourTextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                 CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="OvertimeWagePerHourTextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9"
                                ControlToValidate="OvertimeWagePerHourTextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Panel1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="meal_Support_Label" runat="server" Text="Meal Support" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="MealSupport_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                 CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="MealSupport_TextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                ControlToValidate="MealSupport_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel2" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="coffee_Support_Label" runat="server" Text="Coffee Support" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="CoffeeSupport_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                 CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="CoffeeSupport_TextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                ControlToValidate="CoffeeSupport_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Panel3" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="additional_Support_Lable" runat="server" Text="Additional Support" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="AdditionalSupport_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                 CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="AdditionalSupport_TextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                                ControlToValidate="AdditionalSupport_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel4" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="days_Per_Week_Label" runat="server" Text="Working Days Per Week" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="days_Per_Week_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="days_Per_Week_TextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6"
                                ControlToValidate="days_Per_Week_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel5" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="hours_per_Day_Label" runat="server" Text="Working Hours Per Day" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="hours_per_Day_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="hours_per_Day_TextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                                ControlToValidate="hours_per_Day_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Panel6" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="soc_Sec_Tax_Label" runat="server" Text="Social Security Tax" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="soc_Sec_Tax_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                CssClass="valError"
                                ErrorMessage="Required Field" ControlToValidate="soc_Sec_Tax_TextBox">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                                ControlToValidate="soc_Sec_Tax_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_16" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="GSM_Label" runat="server" Text="Employee GSM" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="GSMTextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_17" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Status_Label" runat="server" Text="Select Status" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="StatusDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True">
                                <asp:ListItem Text="Select Status" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Not Active" Value="2"></asp:ListItem>
                            </asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>



        <div class="menu-item">
            <asp:Panel ID="Product_Panel_9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Notes_Label" runat="server" Text="Employee Notes (EN-TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Notes_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <table class="item-table">

                <tr>
                    <td>
                        <asp:Button ID="AddButton" runat="server" Text="ADD" Height="50px" Width="300" Font-Size="20pt" Visible="True" OnClientClick="return confirm('Are you sure you want to add this Employee?');" OnClick="AddButton_Click" />
                    </td>
                </tr>

            </table>
        </div>
        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_10" runat="server" GroupingText="EMPLOYEE LIST">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryEmployeeGridView" runat="server" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true">
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

    </div>



    <script type="text/javascript">

        function pageLoad() {
            createDataTable();
        };


        function createDataTable() {
            var table = $('#<%=jQueryEmployeeGridView.ClientID%>').DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    retrieve: true,
                    stateSave: false,
                    order: [[0, 'desc']],

                });


            $('#ContentPlaceHolder1_jQueryEmployeeGridView tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                } else {
                    table.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                }


                //Reference the GridView Row.
                var row = $(this).closest("tr");
                //Determine the Row Index.
                var message = "Selected Products Details ";
                //Read values from Cells.

                message += "\nName_BG: " + row.find("td").eq(1).html();
                message += "\nName_TR: " + row.find("td").eq(2).html();
                message += "\nLastName: " + row.find("td").eq(3).html();
                message += "\nNationality " + row.find("td").eq(4).html();
                message += "\nTitle: " + row.find("td").eq(5).html();
                message += "\nDepartment: " + row.find("td").eq(6).html();
                message += "\nSalerie: " + row.find("td").eq(7).html();
                message += "\nNotes: " + row.find("td").eq(8).html();
                //Display the data using JavaScript Alert Message Box.
                alert(message);
                return false;


            });

        }

    </script>

    <script>
        $('#<%=GenderTypeIdDropDownList.ClientID%>').chosen();
        $('#<%=OriginIdDropDownList.ClientID%>').chosen();
        $('#<%=TitleIdDropDownList.ClientID%>').chosen();
        $('#<%=DepartmentIdDropDownList.ClientID%>').chosen();
        $('#<%=StatusDropDownList.ClientID%>').chosen();

        /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


        $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

        /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */
    </script>


</asp:Content>
