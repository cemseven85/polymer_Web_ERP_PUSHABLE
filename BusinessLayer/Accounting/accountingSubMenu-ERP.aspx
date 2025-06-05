<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="accountingSubMenu-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.accountingSubMenu_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main">

        <div class="menu-item">
            <asp:Panel ID="productGroup_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="transactionsButton" runat="server" ImageUrl="~/images/transactionSubMenu.png" OnClick="transactionsButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Transactions Menu</p>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="productType_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="progressPaymentsButton" runat="server" ImageUrl="~/images/wageSubMenu.png" OnClick="progressPaymentsButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Progress Payments Menu</p>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

    </div>
</asp:Content>
