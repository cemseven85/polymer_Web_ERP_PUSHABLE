<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listInvoice-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listInvoice_ERP" Culture="de-DE" UICulture="fr-FR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="product-type" id="productTypeDiv">

        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Search_Panel" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Invoice List" Font-Size="25pt"></asp:Label>
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
                            <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryInvoiceListGridView_PreRender"></asp:TextBox>
                            <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryInvoiceListGridView_PreRender"></asp:TextBox>
                            <asp:Button ID="ShowInvoiceListButton" runat="server" Text="Show Invoice List" OnClick="ShowInvoiceListButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->

                        <td>
                            <asp:GridView ID="jQueryInvoiceListGridView" runat="server" AutoGenerateColumns="false" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryInvoiceListGridView_PreRender">
                                <Columns>
                                    <asp:CommandField SelectText="SELECT" ShowSelectButton="True" />
                                    <asp:BoundField DataField="Invoice ID" HeaderText="Invoice ID" ReadOnly="true" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="Company" HeaderText="Company" ReadOnly="true" />
                                    <asp:BoundField DataField="Consultant" HeaderText="Consultant" ReadOnly="true" />

                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="true" DataFormatString="{0:N2}" />
                                    <asp:BoundField DataField="VAT Inc Amount" HeaderText="VAT Inc Amount" ReadOnly="true" DataFormatString="{0:N2}" />
                                    <asp:BoundField DataField="ShipInvoiceQuantitiyDifference" HeaderText="ShipInvoiceQuantitiyDifference" ReadOnly="true" DataFormatString="{0:N2}" />
                                     <asp:BoundField DataField="Notes" HeaderText="Notes" ReadOnly="true" />
                                     <asp:BoundField DataField="txn_ID" HeaderText="txn_ID" ReadOnly="true" />
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
                            <asp:Button ID="ExcelButton" runat="server" Text="EXCEL" OnClick="ExcelButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;">
                            <asp:Button ID="showDetailButton" runat="server" Text="Show Invoice Detail" Height="51px" Width="208px" OnClick="showDetailButton_Click" />

                        </td>

                        <td style="text-align: right;">
                            <asp:Button ID="OpenInvoiceShipTracePageButton" runat="server" Text="Open Invoice Ship Trace Page" Height="51px" Width="208px" OnClick="OpenInvoiceShipTracePageButton_Click" BackColor="#66FF33" />
                        <td>
                    </tr>

                    <tr>
                        <td style="text-align: left;"></td>
                    </tr>

                </table>
            </asp:Panel>

            <asp:Panel ID="InvoiceDetailPanel" runat="server">

                <table class="item-table">
                    <tr>
                        <td style="text-align: left;">
                            <asp:Label ID="ConsultantLabel" runat="server" Text="........." Font-Size="30pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label11" runat="server" Text="Invoice" Font-Size="30pt"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label15" runat="server" Text="Invoice No:" Font-Size="12pt"></asp:Label>
                            <asp:Label ID="InvIdLabel" runat="server" Text="............" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="DateLabel" runat="server" Text="............" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Billed To:" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="CustomerLabel" runat="server" Text="............." Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:GridView ID="jQueryInvoiceDetailGridView" runat="server" DataKeyNames="InvDetID, InvID" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AutoGenerateEditButton="false">
                                <Columns>
                                    <asp:BoundField DataField="InvDetID" HeaderText="Detail ID" ReadOnly="true" />
                                    <asp:BoundField DataField="InvID" HeaderText="Invoice ID" ReadOnly="true" />
                                    <asp:BoundField DataField="Product" HeaderText="Product" ReadOnly="true" />
                                    <asp:BoundField DataField="ShipQuantity" HeaderText="Shippment Quantity" ReadOnly="true" />

                                    <asp:TemplateField HeaderText="Invoice Quantity">
                                        <ItemTemplate>
                                            <%# Eval("InvQuantity") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtInvoiceQuantity" runat="server" Text='<%# Bind("InvQuantity") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <%# Eval("UnitPrice") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="VAT%" HeaderText="VAT" ReadOnly="true" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="true" DataFormatString="{0:N2}" />
                                    <asp:BoundField DataField="VAT Amount" HeaderText="VAT Amount" ReadOnly="true" DataFormatString="{0:N2}" />

                                    <asp:BoundField DataField="VAT Included Amount" HeaderText="VAT Included Amount" DataFormatString="{0:N2}" />
                                </Columns>
                            </asp:GridView>


                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label13" runat="server" Text="Total Amount"></asp:Label>&nbsp;&nbsp;<asp:Label ID="TotalAmountLabel" runat="server" Text="........."></asp:Label></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label12" runat="server" Text="VAT Amount"></asp:Label>&nbsp;&nbsp;<asp:Label ID="VATAmountLabel" runat="server" Text="........."></asp:Label></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label16" runat="server" Text="VAT Included Amount"></asp:Label>&nbsp;&nbsp;<asp:Label ID="VATIncludedAmountLabel" runat="server" Text="........."></asp:Label></td>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>


                        <td style="text-align: left;">
                            <asp:Button ID="InvoiceDetailExcel" runat="server" Text="EXCEL" OnClick="ExceDetaillButton_Click" Height="38px" Width="162px" />
                            <asp:Button ID="PrintButton" runat="server" Text="Print Invoice" OnClientClick="printDiv()" Height="38px" Width="162px" />

                        </td>

                    </tr>


                    <tr>
                        <td style="text-align: left;">
                            <asp:Button ID="OpenInvoicePanelButton" runat="server" Text="Show Invoice List" Height="51px" Width="208px" OnClick="OpenInvoicePanelButton_Click" />
                        </td>



                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                </table>

            </asp:Panel>



        </div>








    </div>

    <script type="text/javascript">

        function pageLoad() {
            $('#<%=jQueryInvoiceListGridView.ClientID%>').DataTable();


        };



    </script>

    <%--<script type="text/javascript">
        function printDiv() {
            var printContents = document.getElementById('productTypeDiv').innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;


        }
    </script>--%>


    <script type="text/javascript">
        function printDiv() {
            var printContents = document.getElementById('productTypeDiv').innerHTML;
            var originalTitle = document.title; // Store the original document title
            document.title = "Invoice"; // Set the document title to "Invoice"
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
            document.title = originalTitle; // Restore the original document title
        }
    </script>



</asp:Content>
