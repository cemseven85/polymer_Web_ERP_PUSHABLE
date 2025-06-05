<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="productSubMenu-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.productSubMenu_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main" >
        <div class="menu-item" >
            <asp:Panel ID="productType_Panel_" runat="server">
            <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="productTypeButton" runat="server" ImageUrl="~/images/productTypeIcon.png" OnClick="productTypeButton_Click"  /> </td>
                </tr>
                <tr>
                    <td><p>Product Type</p></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="productGroup_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="productGroupButton" runat="server" ImageUrl="~/images/productGroupIcon.png" OnClick="productGroupButton_Click"  /> </td>
                </tr>
                <tr>
                    <td> <p>Product Group</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="product_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="productButton" runat="server" ImageUrl="~/images/productIcon.png" OnClick="productButton_Click"  /></td>
                </tr>
                <tr>
                    <td> <p>Product</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="wasteCode_Panel_" runat="server">
      <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="wasteCodeButton" runat="server" ImageUrl="~/images/wasteCodeIcon.png" /> </td>
                </tr>
                <tr>
                    <td><p>Waste Code</p></td>
                </tr>
            </table>               
            </asp:Panel></div>               
    </div>

</asp:Content>
