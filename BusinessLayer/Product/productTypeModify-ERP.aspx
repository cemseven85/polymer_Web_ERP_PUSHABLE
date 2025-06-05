<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="productTypeModify-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.productTypeModify_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type" >
        <div class="menu-item" >
            <asp:Panel ID="Product_Type_Panel_6" runat="server">
            <table class="item-table">
                <tr>
                    <td ><asp:Label  ID="Select_Product_Type_Name_Lable" runat="server" Text="Select Product Type Name To Modify" Font-Size="20pt"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:DropDownList ID="ProductTypeDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ProductTypeDropDownList_SelectedIndexChanged"   ></asp:DropDownList></td>                       
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item" >
            <asp:Panel ID="Product_Type_Panel_1" runat="server">
            <table class="item-table">
                <tr>
                    <td ><asp:Label  ID="Product_Type_Name_Label" runat="server" Text="Product Type Name (EN)" Font-Size="20pt"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:TextBox  ID="Product_Type_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="Product_Type_Panel_2" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:Label  ID="Product_Type_Name_Label_BG" runat="server" Text="име на тип продукт (BG)"></asp:Label></td>
                </tr>
                <tr>
                    <td> <asp:TextBox ID="Product_Type_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox> </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="Product_Type_Panel_3" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:Label  ID="Product_Type_Name_TR_Label" runat="server" Text="Ürün Türü Adı (TR)"></asp:Label> </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="Product_Type_Name_TR_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox> </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="Product_Type_Panel_4" runat="server">
      <table class="item-table">
                <tr>
                    <td><asp:Label  ID="Product_Type_Description_Label" runat="server" Text="Description (EN-TR)"></asp:Label>  </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="Product_Type_Description_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%"  Height="200px" TextMode="MultiLine"></asp:TextBox>  </td>
                </tr>
            </table>               
            </asp:Panel></div>       
    
    
      <div class="menu-item"  >
            <asp:Panel ID="Product_Type_Panel_5" runat="server">
      <table class="item-table-button">
                <tr>
                    <td> </td>
                </tr>
                <tr>
                    <td> <asp:Button ID="ShowProductTypeButton" runat="server" Text="Show Product Type" Height="50px" Width="175px" Font-Size="12pt" OnClick="ShowProductTypeButton_Click" /> </td>
                    <td> <asp:Button ID="ModifyButton" runat="server" Text="Modify Product Type" Height="50px" Width="175px" Font-Size="12pt" OnClick="ModifyButton_Click" OnClientClick="return confirm('Are you sure you want to Edit this item?');" />  </td>
                </tr>
            </table>               
            </asp:Panel></div> 

        <div>
            <script>               
                $('#<%=ProductTypeDropDownList.ClientID%>').chosen();
                $(".chosen-container").css('font-size', '15pt');
            </script>
        </div>
          
    </div>




</asp:Content>
