<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listProgressPayment-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listProgressPayment_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="product-type">

        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Related_Progress_Month_Lable" runat="server" Text=" Select Related Progress Month" Font-Size="15pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="Related_Progress_MonthTextBox" runat="server" CssClass="textBoxM" TextMode="Month" Font-Size="15pt"></asp:TextBox>

                    </td>
                </tr>
            </table>
        </div>




        <div class="menu-item">
            <asp:Button ID="Show_Progress_Payment_Button" runat="server" Text="Show Progress Payment" OnClick="Show_Progress_Payment_Button_Click" />

        </div>


        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Add_Progress_Payment_Panel" runat="server" GroupingText="Progress Payment Module">

                <asp:CheckBox ID="DataKeyCheckBox" runat="server" Text="Show IDs" AutoPostBack="true" OnCheckedChanged="DataKeyCheckBox_CheckedChanged" />
                <asp:CheckBox ID="DetailCheckBox" runat="server" Text="Show Detail" AutoPostBack="true" OnCheckedChanged="DetailCheckBox_CheckedChanged" />

                <asp:GridView ID="jQueryRelated_Month_Progress_Payment_GridView" runat="server" DataKeyNames="earned_Salarie_ID,emp_ID, acct_ID,txn_Id_4P,txn_Id_4R" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="earned_Salarie_ID" HeaderText="p_ID" ReadOnly="true" />
                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="true" />
                        <asp:BoundField DataField="emp_ID" HeaderText="emp_ID" ReadOnly="true" />
                        <asp:BoundField DataField="acct_ID" HeaderText="acct_ID" ReadOnly="true" />
                        <asp:BoundField DataField="Cal_Date" HeaderText="Cal_Date" ReadOnly="true" />
                        <asp:BoundField DataField="Progress_Month" HeaderText="P_Month" ReadOnly="true" />
                        <asp:BoundField DataField="Salarie" HeaderText="Salarie" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Wage" HeaderText="Wage" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Wage_Per_Hour" HeaderText="PerHour" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Hour_Worked" HeaderText="HourW" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="OverT_WagePHour" HeaderText="OverHrW" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Over_W_Hour" HeaderText="OverHour" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Meal_Support" HeaderText="Meal_Supp" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Coffe_Support" HeaderText="Coffe_Supp" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Additional_Support" HeaderText="Addl_Supp" ReadOnly="true" DataFormatString="{0:N2}" />
                      
                        <asp:BoundField DataField="Total_Wage" HeaderText="Tot_Wage" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Over_T_Wage" HeaderText="OvrT_Tot" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Total_Earning" HeaderText="Receivable" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="txn_4P" HeaderText="txn_4P" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="txn_4R" HeaderText="txn_4R" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="txn_Id_4P" HeaderText="txn_Id_4P" ReadOnly="true" DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="txn_Id_4R" HeaderText="txn_Id_4R" ReadOnly="true" DataFormatString="{0:N0}" />

                    </Columns>

                </asp:GridView>
                <asp:Button ID="ExcelButton" runat="server" Text="Excel" OnClick="ExcelButton_Click" />

            </asp:Panel>

        </div>


        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td style="float: right">
                        <asp:Label ID="txn_4PNumLabel" runat="server" ForeColor="DarkRed" Font-Bold="true" Font-Size="XX-Large" Text="..........."></asp:Label>
                    </td>
                    <td style="float: right">
                        <asp:Label ID="txn_4PLabel" runat="server" Font-Size="X-Large" Text="Total Txn 4P&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td style="float: right">
                        <asp:Label ID="txn_4RNumLabel" runat="server" ForeColor="DarkRed" Font-Bold="true" Font-Size="XX-Large" Text="..........."></asp:Label>
                    </td>
                    <td style="float: right">
                        <asp:Label ID="txn_4RLabel" runat="server" Font-Size="X-Large" Text="Total Txn 4R&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td style="float: right">
                        <asp:Label ID="txn_TotaNumLabel" runat="server" ForeColor="DarkRed" Font-Bold="true" Font-Size="XX-Large" Text="..........."></asp:Label>
                    </td>
                    <td style="float: right">
                        <asp:Label ID="txn_TotalLabel" runat="server" Text="Total Txn&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td style="float: right">
                        <asp:Label ID="OverTNum_TotalLabel" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="X-Large" Text="..........."></asp:Label>
                    </td>
                    <td style="float: right">
                        <asp:Label ID="OverT_TotalLabel" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large" Text="Total Over Time &nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
                    </td>

                </tr>
            </table>
        </div>






    </div>


    <script type="text/javascript">

        function pageLoad() {
            $('#<%=jQueryRelated_Month_Progress_Payment_GridView.ClientID%>').DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[20, 30, 50, -1], [20, 30, 50, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    retrieve: true,
                    stateSave: false,
                    order: [[0, 'asc']],

                });



        };



    </script>

</asp:Content>
