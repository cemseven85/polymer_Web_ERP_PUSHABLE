<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listCustomer-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listCustomer_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div class="product-type">
         <asp:ScriptManager runat="server" />
        <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->
         <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_10" runat="server" GroupingText="Customer List">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryCustomerGridView" runat="server" CssClass="product-type-gridview" OnPreRender="jQueryCustomerGridView_PreRender"  ShowHeaderWhenEmpty="true"  >
                                
                                <SelectedRowStyle BackColor="#3333CC"/>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ExcelButton" runat="server" Text="EXCEL" OnClick="ExcelButton_Click"/>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>                           
        
        
      
    </div>
    
     <script type="text/javascript">

         function pageLoad() {
             createDataTable();
         };


         function createDataTable() {
             var table = $('#<%=jQueryCustomerGridView.ClientID%>').DataTable(
                 {
                     bLengthChange: true,
                     lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                     bFilter: true,
                     bSort: true,
                     bPaginate: true,
                     retrieve: true,
                     stateSave: false,
                     order: [[1, 'asc']],

                 });

             

         }


         

     </script>


</asp:Content>
