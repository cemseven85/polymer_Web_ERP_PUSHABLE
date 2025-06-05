<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="salesSubMenu-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.salesSubMenu_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="main" >
        <div class="menu-item" >
            <asp:Panel ID="productType_Panel_" runat="server">
            <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="customerGroupButton" runat="server" ImageUrl="~/images/productGroupIcon.png" OnClick="customerGroupButton_Click"/> </td>
                </tr>
                <tr>
                    <td><p>Customer Group</p></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="productGroup_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="customerButton" runat="server" ImageUrl="~/images/customer.png" OnClick="customerButton_Click"   /> </td>
                </tr>
                <tr>
                    <td> <p>Customer</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="product_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="salesButton" runat="server" ImageUrl="~/images/sell.png" OnClick="salesButton_Click"  /></td>
                </tr>
                <tr>
                    <td> <p>Sell</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>       
    </div>

</asp:Content>
