<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="reportsSubMenu-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.reportsSubMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main" >
        <div class="menu-item" >
            <asp:Panel ID="addItem_Panel_" runat="server">
            <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="euCertButton" runat="server" ImageUrl="~/images/eucertPlast.png" OnClick="euCertButton_Click" /> </td>
                </tr>
                <tr>
                    <td><p>EuCertPlast Reports</p></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="editItem_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="productivityButton" runat="server" ImageUrl="~/images/reportPanel.png" OnClick="productivityButton_Click"  /> </td>
                </tr>
                <tr>
                    <td> <p>Productivity Reports</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
       
    </div>


</asp:Content>
