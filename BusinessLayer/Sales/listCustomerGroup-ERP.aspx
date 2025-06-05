<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listCustomerGroup-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listCustomerGroup_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
         <asp:ScriptManager runat="server" />
         <div class="menu-item-datalist" style="overflow: scroll">
             <asp:Panel ID="Product_Panel_1" runat="server" GroupingText="Customer Group List">
                 <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryCustomerGroupGridView" runat="server" CssClass="product-type-gridview" OnPreRender="jQueryCustomerGroupGridView_PreRender"  ShowHeaderWhenEmpty="true" >
                               
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
                          var table = $('#<%=jQueryCustomerGroupGridView.ClientID%>').DataTable(
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
