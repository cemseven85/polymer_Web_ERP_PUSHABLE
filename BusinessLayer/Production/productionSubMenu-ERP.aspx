<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="productionSubMenu-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.productionSubMenu_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="main" >
        <div class="menu-item" >
            <asp:Panel ID="productType_Panel_" runat="server">
            <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="forklitftButton" runat="server" ImageUrl="~/images/forkliftIcon.png" OnClick="forklitftButton_Click" /><asp:ImageButton ID="sortButton" runat="server" ImageUrl="~/images/sortIcon.png" OnClick="sortButton_Click" /> </td>                   
                </tr>
                
                <tr>
                    <td><asp:ImageButton ID="shreddingButton" runat="server" ImageUrl="~/images/shredder_Icon.png" OnClick="shreddingButton_Click" /><asp:ImageButton ID="washingButton" runat="server" ImageUrl="~/images/washingIcon.png" OnClick="washingButton_Click" /></td>                  
                </tr>
                
                <tr>
                    <td><p>Sorting Shredding Washing</p></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="productGroup_Panel_" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:ImageButton ID="extrusionButton" runat="server" ImageUrl="~/images/extruder.png" OnClick="extrusionButton_Click"   /> </td>
                </tr>
                <tr>
                    <td> <p>Extrusion Granule</p>   </td>
                </tr>
            </table>
            </asp:Panel></div>
            
    </div>

</asp:Content>
