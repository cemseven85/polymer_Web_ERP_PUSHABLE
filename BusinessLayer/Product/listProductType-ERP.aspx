<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listProductType-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listProductType_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-type" >
        
           
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
