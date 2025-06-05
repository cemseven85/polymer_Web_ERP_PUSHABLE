<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="purchaseSubMenu-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.purchaseSubMenu_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main" >
        <div class="menu-item" >
            <asp:Panel ID="productType_Panel_" runat="server">
            <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="sellerGroupButton" runat="server" ImageUrl="~/images/productGroupIcon.png" OnClick="sellerGroupButton_Click" /> </td>
                </tr>
                <tr>
                    <td><p>Seller Group</p></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="productGroup_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="sellerButton" runat="server" ImageUrl="~/images/sellerIcon.png" OnClick="sellerButton_Click"  /> </td>
                </tr>
                <tr>
                    <td> <p>Seller</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="product_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="purchaseButton" runat="server" ImageUrl="~/images/purchaseIcon.png" OnClick="purchaseButton_Click" /></td>
                </tr>
                <tr>
                    <td> <p>Purchase</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>       
    </div>
</asp:Content>
