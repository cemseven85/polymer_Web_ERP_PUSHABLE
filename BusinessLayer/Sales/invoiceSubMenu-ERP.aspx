<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="invoiceSubMenu-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.invoiceSubMenu_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="main" >
        <div class="menu-item" >
            <asp:Panel ID="addItem_Panel_" runat="server">
            <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="addItemButton" runat="server" ImageUrl="~/images/addInvoice.png" OnClick="addItemButton_Click" /> </td>
                </tr>
                <tr>
                    <td><p>Add Invoice</p></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="editItem_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="editItemButton" runat="server" ImageUrl="~/images/editInvoice.png" OnClick="editItemButton_Click" Height="256px" Width="256px"  /> </td>
                </tr>
                <tr>
                    <td> <p>Edit Invoice</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="deleteItem_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="deleteItemButton" runat="server" ImageUrl="~/images/deleteInvoice.png" OnClick="deleteItemButton_Click"  /></td>
                </tr>
                <tr>
                    <td> <p>Delete Invoice</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="listItem_Panel_" runat="server">
      <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="listItemButton" runat="server" ImageUrl="~/images/listItem.png" OnClick="listItemButton_Click"   />  </td>
                </tr>
                <tr>
                    <td><p>List Invoice</p></td>
                </tr>
            </table>               
            </asp:Panel></div>               
    </div>



</asp:Content>
