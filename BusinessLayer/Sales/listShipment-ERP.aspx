<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listShipment-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listShipment_ERP" %>

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
                            <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryShippGridView_PreRender"></asp:TextBox>
                            <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryShippGridView_PreRender"></asp:TextBox>
                            <asp:Button ID="ShowShippmentButton" runat="server" Text="Show Shippments" OnClick="ShowShippmentButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->

                        <td>
                            <asp:GridView ID="jQueryShipGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryShippGridView_PreRender">
                                <Columns>
                                    <asp:CommandField SelectText="SELECT" ShowSelectButton="True" />
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
                            <asp:Button ID="Button2" runat="server" Text="Excel" OnClick="ExcelButtonLSh_Click" />

                        </td>
                    </tr>



                    <tr>
                        <td>
                            <asp:Button ID="SelectedShipSummeryButton" runat="server" Text="Show Selected Ship Summary" OnClick="ShipSummeryButton_Click" />
                            <asp:Button ID="AllShipSummeryButton" runat="server" Text="Show All Ship Summary" OnClick="AllShipSummeryButton_Click" />
                       </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Panel ID="SelectedShipDetailPanel" runat="server">

                            <asp:Label ID="LastShipmentLabel" runat="server" Text="Selected Shipment Summary" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryShipDetailGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                            </asp:GridView>
                            <asp:Button ID="Button1" runat="server" Text="Excel" OnClick="ExcelButtonLShD_Click" />
                            </asp:Panel>

                            <asp:Panel ID="AllShipDetailPanel" runat="server">

                            <asp:Label ID="Label2" runat="server" Text="All Shipment Summary" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryAllShipDetailGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                            </asp:GridView>
                            <asp:Button ID="Button4" runat="server" Text="Excel" OnClick="ExcelButtonLAllShD_Click" />

                            </asp:Panel>

                        </td>

                    </tr>

                    <tr>
                        <td>
                            

                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Button ID="SelectedShipItemsButton" runat="server" Text="Show Selected Ship Items" OnClick="ShipItemsButton_Click" />
                             <asp:Button ID="AllShipItemsButton" runat="server" Text="Show All Ship Items" OnClick="AllShipItemsButton_Click" />
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Panel ID="SelectedShipItemsPanel" runat="server">

                            <asp:Label ID="Label1" runat="server" Text="Selected Shipment Item List" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryShipItemListGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                            </asp:GridView>  
                            <asp:Button ID="Button3" runat="server" Text="Excel" OnClick="ExcelButtonLShI_Click" />

                            </asp:Panel>

                            <asp:Panel ID="AllShipItemsPanel" runat="server">

                            <asp:Label ID="Label3" runat="server" Text="All Shipment Item List" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryAllShipItemListGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                            </asp:GridView> 
                            <asp:Button ID="Button5" runat="server" Text="Excel" OnClick="ExcelButtonLAllShI_Click" /> 

                            </asp:Panel>

                        </td>
                    </tr>

                    <tr>
                        <td>
                            

                        </td>
                    </tr>


                </table>
            </asp:Panel>

            


        </div>








    </div>

    <div>
    </div>


    <script type="text/javascript">

        function pageLoad() {
           
            var table = $('#<%=jQueryShipGridView.ClientID%>').DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    retrieve: true,
                    stateSave: false,
                    order: [[1, 'desc']],

                });

        };



    </script>




</asp:Content>
