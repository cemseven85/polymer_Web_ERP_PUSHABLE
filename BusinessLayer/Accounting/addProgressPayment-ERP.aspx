<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addProgressPayment-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addProgressPayment_ERP" %>

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
            <asp:Panel ID="Extra_Holiday_Panel" runat="server" GroupingText="Holidays And Working Days">
                <table class="item-table">
                    <tr>
                        <td>
                            <p style="font-size:50%;">Extra Holidays</p>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Extra_Holiday_BG_Lable" runat="server" Text=" Group BG =" Font-Size="15pt"></asp:Label>
                            <asp:DropDownList ID="Extra_Holiday_BG_DropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="100px" Width="25%" AutoPostBack="False">
                                <asp:ListItem Text="0" Value="0" Selected="true" />
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                                <asp:ListItem Text="5" Value="5" />
                                <asp:ListItem Text="6" Value="6" />
                                <asp:ListItem Text="7" Value="7" />
                                <asp:ListItem Text="8" Value="8" />
                                <asp:ListItem Text="9" Value="9" />
                                <asp:ListItem Text="10" Value="10" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Extra_Holiday_SAA_Lable" runat="server" Text=" Group SAA =" Font-Size="15pt"></asp:Label>
                            <asp:DropDownList ID="Extra_Holiday_SAA_DropDownList" runat="server" CssClass="product-type-modify-dropdown" MMax-Width="100px" Width="25%" AutoPostBack="False">
                                <asp:ListItem Text="0" Value="0" Selected="true" />
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                                <asp:ListItem Text="5" Value="5" />
                                <asp:ListItem Text="6" Value="6" />
                                <asp:ListItem Text="7" Value="7" />
                                <asp:ListItem Text="8" Value="8" />
                                <asp:ListItem Text="9" Value="9" />
                                <asp:ListItem Text="10" Value="10" />
                            </asp:DropDownList>
                        </td>
                        
                        <td>
                            <asp:Label ID="Extra_Holiday_TR_Lable" runat="server" Text=" Group TR =" Font-Size="15pt"></asp:Label>
                            <asp:DropDownList ID="Extra_Holiday_TR_DropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="100px" Width="25%" AutoPostBack="False">
                                <asp:ListItem Text="0" Value="0" Selected="true" />
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                                <asp:ListItem Text="5" Value="5" />
                                <asp:ListItem Text="6" Value="6" />
                                <asp:ListItem Text="7" Value="7" />
                                <asp:ListItem Text="8" Value="8" />
                                <asp:ListItem Text="9" Value="9" />
                                <asp:ListItem Text="10" Value="10" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p style="font-size:50%;">Total Working Days</p>
                        </td>

                    </tr>
                    <tr>                       
                        <td><asp:Label ID="BG_WD_Label" runat="server" Text="......." Font-Size="15pt" ForeColor="Red"></asp:Label></td>                       
                        <td><asp:Label ID="SAA_WD_Label" runat="server" Text="......." Font-Size="15pt" ForeColor="Red"></asp:Label></td>                        
                        <td><asp:Label ID="TR_WD_Label" runat="server" Text="......." Font-Size="15pt" ForeColor="Red" ></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Button ID="Create_Progress_Payment_Button" runat="server" Text="Create Progress Payment" OnClick="Create_Progress_Payment_Button_Click" />

        </div>


        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Add_Progress_Payment_Panel" runat="server" GroupingText="Progress Payment Module">

                <asp:CheckBox ID="DataKeyCheckBox" runat="server" Text="Show IDs" AutoPostBack="true" OnCheckedChanged="DataKeyCheckBox_CheckedChanged"/>
                <asp:CheckBox ID="DetailCheckBox" runat="server" Text="Show Detail" AutoPostBack="true" OnCheckedChanged="DetailCheckBox_CheckedChanged"/>
                <asp:GridView ID="jQueryRelated_Month_Progress_Payment_GridView" runat="server" DataKeyNames="earned_Salarie_ID,emp_ID, acct_ID,txn_Id_4P,txn_Id_4R" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AutoGenerateEditButton="true" OnRowEditing="jQueryRelated_Month_Progress_Payment_GridView_RowEditing" OnRowCancelingEdit="jQueryRelated_Month_Progress_Payment_GridView_RowCancelingEdit" OnRowUpdating="jQueryRelated_Month_Progress_Payment_GridView_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="earned_Salarie_ID" HeaderText="p_ID" ReadOnly="true" />
                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="true" />
                        <asp:BoundField DataField="emp_ID" HeaderText="emp_ID" ReadOnly="true" />
                        <asp:BoundField DataField="acct_ID" HeaderText="acct_ID" ReadOnly="true" />
                        <asp:BoundField DataField="Cal_Date" HeaderText="Cal_Date" ReadOnly="true" />
                        <asp:BoundField DataField="Progress_Month" HeaderText="P_Month" ReadOnly="true" />

                        <asp:TemplateField HeaderText="Salarie">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}", Eval("Salarie")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="reletedMonthSalarieTxtBox" CssClass="textBoxUpDateS" runat="server" Text='<%# Bind("Salarie") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Wage">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}", Eval ("Wage")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="reletedWageTxtBox" CssClass="textBoxUpDateS" runat="server" Text='<%# Bind("Wage") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PerHour">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}", Eval ("Wage_Per_Hour")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="reletedWage_Per_HourTxtBox" CssClass="textBoxUpDateS" runat="server" Text='<%# Bind("Wage_Per_Hour") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="HourW">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}", Eval ("Hour_Worked")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="reletedHour_WorkedTxtBox" CssClass="textBoxUpDateS" runat="server" Text='<%# Bind("Hour_Worked") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="OverHrW">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}", Eval ("OverT_WagePHour")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="overtime_WagePHourTxtBox" CssClass="textBoxUpDateS" runat="server" Text='<%# Bind("OverT_WagePHour") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="OverHour">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}", Eval ("Over_W_Hour")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="over_Working_HourTxtBox" CssClass="textBoxUpDateS" runat="server" Text='<%# Bind("Over_W_Hour") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Meal_Supp">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}",  Eval("Meal_Support")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="mealSupportTextBox" runat="server" CssClass="textBoxUpDateS" Text='<%# Bind("Meal_Support") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Coffe_Supp">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}",  Eval("Coffe_Support")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="coffeeSupportTextBox" runat="server" CssClass="textBoxUpDateS"  Text='<%# Bind("Coffe_Support") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Addl_Supp">
                            <ItemTemplate>
                                <%#String.Format("{0:N2}",  Eval("Additional_Support")) %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="additionalSupportTextBox" runat="server" CssClass="textBoxUpDateS" Text='<%# Bind("Additional_Support") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Total_Wage" HeaderText="Tot_Wage" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Over_T_Wage" HeaderText ="OvrT_Tot" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Total_Earning" HeaderText="Receivable" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="txn_4P" HeaderText="txn_4P" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="txn_4R" HeaderText="txn_4R" ReadOnly="true" DataFormatString="{0:N2}" />
                         <asp:BoundField DataField="txn_Id_4P" HeaderText="txn_Id_4P" ReadOnly="true" DataFormatString="{0:N0}" />
                        <asp:BoundField DataField="txn_Id_4R" HeaderText="txn_Id_4R" ReadOnly="true" DataFormatString="{0:N0}" />

                    </Columns>

                </asp:GridView>


            </asp:Panel>

        </div>


    </div>


    <script type="text/javascript">

        function pageLoad() {
            $('#<%=jQueryRelated_Month_Progress_Payment_GridView.ClientID%>').DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[10,25, 50, -1], [10,25, 50, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    retrieve: true,
                    stateSave: false,
                    order: [[1, 'asc']],

                });



        };



    </script>


</asp:Content>
