<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="productTypeDelete-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.productTypeDelete_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type" >
       
        <div class="menu-item-datalist" style="overflow:scroll"  >
            <asp:Panel ID="Product_Type_Panel_1" runat="server" GroupingText="PRODUCT TYPE LIST">
            <table class="item-table">
                <tr>
                    <td > </td>
                </tr>
                <tr>
                    <td> <asp:GridView ID="ProductTypeGridView" GridLines="None" runat="server" AllowPaging="true" PagerStyle-CssClass="paging"  PageSize="5" CssClass="product-type-gridview"  OnPageIndexChanging="ProductTypeGridView_PageIndexChanging"  >
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Delete" >                            
                            </asp:CommandField>
                        </Columns>
                        <SelectedRowStyle BackColor="#3333CC" />
                        </asp:GridView> </td>                       
                </tr>
            </table>
            </asp:Panel></div>
       
        
    
    
      <div class="menu-item" >
            <asp:Panel ID="Product_Type_Panel_2" runat="server">
      <table class="item-table-button">
                <tr>
                    <td>  </td>
                </tr>
                <tr>
                    <td>  <asp:Button ID="DeleteButton" runat="server" Text="Delete Product Type" Height="50px" Width="350" Font-Size="20pt" OnClick="DeleteButton_Click" /></td>
                    <td>  </td>
                </tr>
            </table>               
            </asp:Panel></div> 
          
    </div>

</asp:Content>
