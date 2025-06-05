<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="productType-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.productType_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
       
          <meta http-equiv="Content-Type" content="text/html"; charset="utf-8" ;encoding="UTF-8"/>
    
          
    
</asp:Content>

<asp:Content ID="ProductType" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="product-type" >
        <div class="menu-item" >
            <asp:Panel ID="Product_Type_Panel_1" runat="server">
            <table class="item-table">
                <tr>
                    <td ><asp:Label  ID="Product_Type_Name_Lable" runat="server" Text="Product Type Name (EN)" Font-Size="20pt"></asp:Label></td>
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
                    <td> <asp:TextBox ID="Product_Type_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"  ></asp:TextBox> </td>
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
                    <td> <asp:Button ID="KaydetButton" runat="server" Text="Add Type " Height="50px" Width="250px" Font-Size="20pt" OnClick="KaydetButton_Click"  type="button" /> 
                         <asp:Button ID="ModifyButton" runat="server" Text="Modify Type" Height="50px" Width="250px" Font-Size="20pt" type="button" OnClick="ModifyButton_Click"/>  
                         <asp:Button ID="DeleteButton" runat="server" Text="Delete Type" Height="50px" Width="250px" Font-Size="20pt" OnClick="DeleteButton_Click" />      </td>
                   
                </tr>
            </table>               
            </asp:Panel></div> 
           
           <div class="menu-item-datalist"  style="overflow:scroll"  >     <!-- We also use the same css for data list at productType with overflow:scroll -->
            <asp:Panel ID="Product_Type_Panel_6" runat="server" GroupingText="PRODUCT TYPE LIST">
      <table class="item-table-datalist">
                <tr style="font-weight: bolder; text-align: center; font-size: 20pt;">
                   <td><asp:Label ID="Label5" runat="server"  Text="Product Type Name"></asp:Label></td>
                   <td> <asp:Label ID="Label6" runat="server" Text="Product Type Name BG"></asp:Label></td>                         
                   <td><asp:Label ID="Label7" runat="server" Text="Product Type Name TR"></asp:Label></td>                        
                   <td><asp:Label ID="Label8" runat="server" Text="Product Type Description"></asp:Label></td>                     
                                                                                 
                </tr>
                <tr>
                     
                        <asp:DataList ID="ProductTypeDataList" runat="server" Width="100%"  >
                            <ItemTemplate>
                                <table align="left" class="item-table-datalist" >                                                                                                                                                                                                                                                                                                 
                                    <tr>
                                        <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("prod_Typ_Name") %>'></asp:Label></td>                                                                                                                                                                                                                    
                                        <td> <asp:Label ID="Label2" runat="server" Text='<%# Eval("prod_Typ_Name_BG") %>'></asp:Label></td>
                                        <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("prod_Typ_Name_TR") %>'></asp:Label></td>                                                                                   
                                        <td> <asp:Label ID="Label4" runat="server" Text='<%# Eval("prod_Typ_Description") %>'></asp:Label></td>                                                                   
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                   
                        
                </tr>
            </table>               
            </asp:Panel></div>      
    </div>


</asp:Content>
