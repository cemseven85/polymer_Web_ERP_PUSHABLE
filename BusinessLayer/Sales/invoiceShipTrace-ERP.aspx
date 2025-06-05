<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="invoiceShipTrace-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Sales.invoiceShipTrace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="product-type" id="productTypeDiv">

        <div class="menu-item-datalist" style="overflow: scroll">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Ship Invoice Trace List" Font-Size="25pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="ItemDateMin_Label" runat="server" Text="Start Date" Font-Size="15pt"></asp:Label>
                        &nbsp  &nbsp  &nbsp    &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp &nbsp 
                        <asp:Label ID="ItemDateMax_Label" runat="server" Text="End Date" Font-Size="15pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryShipInvoiceTraceListGridView_PreRender"></asp:TextBox>
                        <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryShipInvoiceTraceListGridView_PreRender"></asp:TextBox>
                        <asp:Button ID="ShowShipInvoiceTraceListButton" runat="server" Text="Show Invoice List" OnClick="ShowShipInvoiceTraceListButton_Click" />
                    </td>
                </tr>
                <tr>
                    <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->

                    <td>
                        <asp:GridView ID="jQueryShipInvoiceTraceListGridView" runat="server" AutoGenerateColumns="false" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryShipInvoiceTraceListGridView_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Invoice_Date" HeaderText="Invoice_Date" ReadOnly="true" DataFormatString="{0:yyyy/MM/dd}" />
                                <asp:BoundField DataField="Invoice_ID" HeaderText="Invoice_ID" ReadOnly="true" />
                                <asp:BoundField DataField="Ship_ID" HeaderText="Ship_ID" ReadOnly="true" />
                                <asp:BoundField DataField="Customer" HeaderText="Customer" ReadOnly="true" />
                                <asp:BoundField DataField="Consultant" HeaderText="Consultant" ReadOnly="true" />




                            </Columns>


                        </asp:GridView>
                        <!-- Need to put GridView Here  -->
                        <!-- Need to put GridView Here  -->
                        <!-- Need to put GridView Here  -->
                    </td>
                </tr>

                <tr>


                    <td style="text-align: left;">
                        <asp:Button ID="InvoiceDetailExcel" runat="server" Text="EXCEL" OnClick="ExcelButton_Click" Height="38px" Width="162px" />


                    </td>

                </tr>


            </table>

        </div>

    </div>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=jQueryShipInvoiceTraceListGridView.ClientID%>').DataTable();


        };



    </script>
</asp:Content>
