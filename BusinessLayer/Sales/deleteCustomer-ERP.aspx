<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="deleteCustomer-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.deleteCustomer_ERP" %>
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
                                <Columns>
                                    <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC"/>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>                           
        
        
         <div class="menu-item">
            <table class="item-table">

                <tr>
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" Text="DELETE" Height="50px" Width="300" Font-Size="20pt" Visible="True"   OnClientClick="return confirm('Are you sure you want to Delete this item?');" OnClick="DeleteButton_Click"  />
                    </td>
                </tr>

            </table>
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
