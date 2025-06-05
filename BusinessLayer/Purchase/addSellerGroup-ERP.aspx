<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addSellerGroup-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addSellerGroup_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="product-type">
         <asp:ScriptManager runat="server" />
        <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->


        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_2" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Group_Name_Lable" runat="server" Text="Seller Group Name (EN)" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Group_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_3" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Group_Name_Label_BG" runat="server" Text="Име на група продавач (BG)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Group_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_4" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Group_Name_TR_Label" runat="server" Text="Satıcı Grup Adı (TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Group_Name_TR_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>         
        <div class="menu-item">
            <asp:Panel ID="Product_Panel_9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Group_Description_Label" runat="server" Text="Description (EN-TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Group_Description_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <table class="item-table">

                <tr>
                    <td>
                        <asp:Button ID="sellerGroupAddButton" runat="server" Text="ADD" Height="50px" Width="300" Font-Size="20pt" Visible="True"   OnClientClick="return confirm('Are you sure you want to add this item?');" OnClick="AddButton_Click" />
                    </td>
                </tr>

            </table>
        </div>
         <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_10" runat="server"  GroupingText="Seller Group List">
                <table class="item-table">
                    <tr>
                        <td> </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQuerySellerGroupGridView" runat="server" CssClass="product-type-gridview"  ShowHeaderWhenEmpty="true">
                                <SelectedRowStyle BackColor="#3333CC"/>
                            </asp:GridView>
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
                          var table = $('#<%=jQuerySellerGroupGridView.ClientID%>').DataTable(
                        {
                            bLengthChange: true,
                            lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                            bFilter: true,
                            bSort: true,
                            bPaginate: true,
                            retrieve: true,
                            stateSave: false,
                            order: [[0, 'desc']],

                        });

                   
                          $('#ContentPlaceHolder1_jQuerySellerGroupGridView tbody').on('click', 'tr', function () {
                              if ($(this).hasClass('selected')) {
                                  $(this).removeClass('selected');
                              } else {
                                  table.$('tr.selected').removeClass('selected');
                                  $(this).addClass('selected');
                              }


                              //Reference the GridView Row.
                              var row = $(this).closest("tr");
                              //Determine the Row Index.
                              var message = "Selected Seller Group Details " ;
                              //Read values from Cells.
                              message += "\nName: " + row.find("td").eq(1).html();
                              message += "\nName_BG: " + row.find("td").eq(2).html();
                              message += "\nName_TR: " + row.find("td").eq(3).html();
                              message += "\nDescription: " + row.find("td").eq(4).html();
                              
                              //Display the data using JavaScript Alert Message Box.
                              alert(message);
                              return false;


                          });
                   
                      }
                     
    </script>




</asp:Content>
