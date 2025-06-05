<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listPrdGroup-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listPrdGroup_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-type">
        <asp:ScriptManager runat="server" />
        


        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Group_Panel_3" runat="server" GroupingText="PRODUCT GROUP LIST">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryProductGroupGridView" runat="server" CssClass="product-type-gridview" OnPreRender="jQueryProductGroupGridView_PreRender"  ShowHeaderWhenEmpty="true">
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
                          var table = $('#<%=jQueryProductGroupGridView.ClientID%>').DataTable(
                        {
                            bLengthChange: true,
                            lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                            bFilter: true,
                            bSort: true,
                            bPaginate: true,
                            retrieve: true,
                            stateSave: false,
                        });

                   
                          $('#ContentPlaceHolder1_jQueryProductGroupGridView tbody').on('click', 'tr', function () {
                              if ($(this).hasClass('selected')) {
                                  $(this).removeClass('selected');
                              } else {
                                  table.$('tr.selected').removeClass('selected');
                                  $(this).addClass('selected');
                              }


                              //Reference the GridView Row.
                              var row = $(this).closest("tr");
                              //Determine the Row Index.
                              var message = "Row Index: " + (row[0].rowIndex - 1);
                              //Read values from Cells.
                              message += "\nGroup Id: " + row.find("td").eq(1).html();
                              message += "\nType Id: " + row.find("td").eq(2).html();
                              //Display the data using JavaScript Alert Message Box.
                              alert(message);
                              return false;


                          });
                   
                      }
                     
            </script>
       
            
                

</asp:Content>
