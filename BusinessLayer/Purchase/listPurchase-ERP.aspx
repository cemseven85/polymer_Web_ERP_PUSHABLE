<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listPurchase-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listPurchase_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
        <asp:ScriptManager runat="server" />
        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_10" runat="server" GroupingText="Purchase List">
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
                            <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryPurchaseGridView_PreRender"></asp:TextBox>
                            <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryPurchaseGridView_PreRender"></asp:TextBox>
                            <asp:Button ID="ShowReportButton" runat="server" Text="Show Report" OnClick="ShowReportButton_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryPurchaseGridView" runat="server" CssClass="product-type-gridviewS" OnPreRender="jQueryPurchaseGridView_PreRender"  ShowHeaderWhenEmpty="true">
                               
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
             var table = $('#<%=jQueryPurchaseGridView.ClientID%>').DataTable(
                 {
                     bLengthChange: true,
                     lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                     bFilter: true,
                     bSort: true,
                     bPaginate: true,
                     retrieve: true,
                     stateSave: false,
                     order: [[20, 'desc']],

                 });



         }

        </script>



</asp:Content>
