<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="deleteTxnDetail-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.deleteTxnDetail_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type" >   <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->
        
        <asp:ScriptManager runat="server" />
          
        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Group_Panel_7" runat="server" GroupingText="Transaction Detail List">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview"   -->
                        <td>
                            <asp:GridView ID="TxnDetailGridView"  runat="server"  CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" OnPreRender="TxnDetailGridViewBind_PreRender">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Select"></asp:CommandField>
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
         
         
        
          
    
    
      <div class="menu-item"  >
            <asp:Panel ID="Product_Group_Panel_6" runat="server">
      <table class="item-table-button">
                <tr>
                    <td> </td>
                </tr>
                <tr>
                    <td> <asp:Button ID="DeleteDetailButton" runat="server" Text="Delete Transaction Detail " Height="50px" Width="250px" Font-Size="15pt"   type="button" OnClick="DeleteDetailButton_Click" OnClientClick="confirmDelete()" /> </td>
                            
                   
                </tr>
            </table>               
            </asp:Panel></div>  
         
         



           
    </div>
    <script type="text/javascript">

        function pageLoad() {
            $('#<%=TxnDetailGridView.ClientID%>').DataTable();

        };

    </script>

    <script type="text/javascript">
        function confirmDelete() {
            var confirmValue = document.createElement("INPUT");
            confirmValue.type = "hidden";
            confirmValue.name = "confirmValue";

            if (confirm("Do you want to delete? If you, click yes")) {
                confirmValue.value = "YES";
            }
            else {
                confirmValue.value = "NO";
            }
            document.forms[0].appendChild(confirmValue);
        }
    </script>


</asp:Content>
