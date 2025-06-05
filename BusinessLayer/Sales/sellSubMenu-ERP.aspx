<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="sellSubMenu-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.sellSubMenu_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="main" >
        <div class="menu-item" >
            <asp:Panel ID="productType_Panel_" runat="server">
            <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="shipmentButton" runat="server" ImageUrl="~/images/shipment.png" OnClick="shipmentButton_Click"/> </td>
                </tr>
                <tr>
                    <td><p>Shipment</p></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="productGroup_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="invoiceButton" runat="server" ImageUrl="~/images/invoice.png" OnClick="invoiceButton_Click"   /> </td>
                </tr>
                <tr>
                    <td> <p>Invoice Processing</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
        
    </div>


</asp:Content>
