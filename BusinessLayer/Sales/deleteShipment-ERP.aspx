<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="deleteShipment-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.deleteShipment_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="product-type">


        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_4" runat="server">
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
                            <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="false" OnTextChanged="jQueryShippGridView_PreRender"></asp:TextBox>
                            <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="false" OnTextChanged="jQueryShippGridView_PreRender"></asp:TextBox>
                            <asp:Button ID="ShowShippmentButton" runat="server" Text="Show Shippments" OnClick="ShowShippmentButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->

                        <td>
                            <asp:GridView ID="jQueryShipGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryShippGridView_PreRender">
                                <Columns>                                  
                                            <asp:CommandField SelectText="DELETE" ShowSelectButton="True" />                           
                                </Columns>
                               
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                            <!-- Need to put GridView Here  -->
                            <!-- Need to put GridView Here  -->
                            <!-- Need to put GridView Here  -->
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ShipSummeryButton" runat="server" Text="Show Selected Ship Summary" OnClick="ShipSummeryButton_Click" />

                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="LastShipmentLabel" runat="server" Text="Selected Ship Summary" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryShipDetailGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" >
                            </asp:GridView>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="ShipItemsButton" runat="server" Text="Show Selected Ship Items" OnClick="ShipItemsButton_Click" />

                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Selected Ship Items" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryShipItemListGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                                
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
                        <asp:Button ID="RunButton" runat="server" Text="DELETE Shippment" Height="30px" Width="250" Font-Size="15pt" Visible="True" OnClientClick="return confirm('Are you sure you want to run this Production?');" OnClick="RunButton_Click" />

                    </td>
                </tr>
            </table>
        </div>

    </div>

    <div>
    </div>


     <script type="text/javascript">

         function pageLoad() {
             $('#<%=jQueryShipGridView.ClientID%>').DataTable();
         $('#<%=jQueryShipDetailGridView.ClientID%>').DataTable();
         $('#<%=jQueryShipItemListGridView.ClientID%>').DataTable();


         };



     </script>





</asp:Content>
