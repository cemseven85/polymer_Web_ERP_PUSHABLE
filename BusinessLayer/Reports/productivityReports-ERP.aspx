<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="productivityReports-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.productivityReports_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="product-type">
        <asp:ScriptManager runat="server" />



        <div class="menu-item">
            <asp:Panel ID="Panel2" runat="server">
                <table class="item-table">

                    <tr>
                        <td>
                            <asp:RadioButtonList ID="ProductivitytReportsRadioButtonList" runat="server" RepeatLayout="Table"
                                RepeatColumns="2">
                              
                                <asp:ListItem Text="Current Account Statement" Value="1" />
                                <%--currentAccountStatement--%>
                                <asp:ListItem Text="Daily Granule Production Report" Value="2" />
                               <%-- dailyGranuleProduction--%>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please select Report.<br />"
                                ControlToValidate="ProductivitytReportsRadioButtonList" runat="server" ForeColor="Red" Display="Dynamic"  ValidationGroup="myValidator"/>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnReport" Text="Report" runat="server" OnClick="report_Click" ValidationGroup="myValidator" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
         
        
        

    </div>


   
</asp:Content>
