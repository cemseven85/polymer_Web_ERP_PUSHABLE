<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="deleteGProduction-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.deleteGProduction_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="product-type">
        <asp:ScriptManager runat="server" />

        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_4" runat="server"  GroupingText="Production OutPut List">
                <table class="item-table">
                     <tr>
                        <td>
                            <asp:Label ID="ItemDateMin_Label" runat="server" Text="Start Date" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp    &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp &nbsp 
                           <asp:Label ID="ItemDateMax_Label" runat="server" Text="End Date" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryOutPutProductionGridView_PreRender"></asp:TextBox>
                            <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryOutPutProductionGridView_PreRender"></asp:TextBox>
                            <asp:Button ID="ShowReportButton" runat="server" Text="Show Report" OnClick="ShowReportButton_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryOutPutProductionGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryOutPutProductionGridView_PreRender"  >
                                <Columns>
                                    <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC" />
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
                        <asp:Button ID="DeleteButton" runat="server" Text="DELETE" Height="30px" Width="150" Font-Size="15pt" Visible="True" OnClientClick="return confirm('Are you sure you want to DELETE this Production?');" OnClick="DeleteButton_Click"  />
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
             var table = $('#<%=jQueryOutPutProductionGridView.ClientID%>').DataTable(
                 {
                     bLengthChange: true,
                     lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                     bFilter: true,
                     bSort: true,
                     bPaginate: true,
                     retrieve: true,
                     stateSave: false,
                     order: [[1, 'DESC']],

                 });

         }


        

     </script>



</asp:Content>
