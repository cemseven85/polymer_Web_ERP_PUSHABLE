<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="editCustomerGroup-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.editCustomerGroup_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="product-type">
         <asp:ScriptManager runat="server" />
        <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->

          <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_10" runat="server" GroupingText="Customer Group List">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryCustomerGroupGridView" runat="server" CssClass="product-type-gridview" OnPreRender="jQueryCustomerGroupGridView_PreRender" OnSelectedIndexChanged="jQueryCustomerGroupGridView_SelectedIndexChanged"  ShowHeaderWhenEmpty="true" >
                                <Columns>
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC"/>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>



        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_2" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Customer_Group_Name_Lable" runat="server" Text="Customer Group Name (EN)" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Customer_Group_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_3" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Customer_Group_Name_Label_BG" runat="server" Text="Име на клиентска група (BG)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Customer_Group_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
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
                            <asp:Label ID="Customer_Group_Name_TR_Label" runat="server" Text="Musteri Grup Adı (TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Customer_Group_Name_TR_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
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
                            <asp:Label ID="Customer_Group_Description_Label" runat="server" Text="Description (EN-TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Customer_Group_Description_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <table class="item-table">

                <tr>
                    <td>
                        <asp:Button ID="EditButton" runat="server" Text="EDIT" Height="50px" Width="300" Font-Size="20pt" Visible="True"   OnClientClick="return confirm('Are you sure you want to edit this item?');" OnClick="EditButton_Click"   />
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
