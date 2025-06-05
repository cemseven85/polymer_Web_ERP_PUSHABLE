<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addInvoice-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addInvoice_ERP" Culture="de-DE" UICulture="fr-FR" %>

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
                            <asp:Label ID="Label7" runat="server" Text="Search Un Billed Shipments" Font-Size="25pt"></asp:Label>
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
                            <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryShippGridView_PreRender"></asp:TextBox>
                            <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryShippGridView_PreRender"></asp:TextBox>
                            <asp:Button ID="ShowShippmentButton" runat="server" Text="Show Shippments" OnClick="ShowShippmentButton_Click" CausesValidation="False"/>
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
                            <asp:Button ID="Button2" runat="server" Text="Excel" OnClick="ExcelButtonLSh_Click" CausesValidation="False"/>

                        </td>
                    </tr>



                    <tr>
                        <td>
                            <asp:Button ID="SelectedShipSummeryButton" runat="server" Text="Show Selected Ship Summary" Width="45%" OnClick="ShipSummeryButton_Click" CausesValidation="False"/>
                            <asp:Button ID="AllShipSummeryButton" runat="server" Text="Show All Ship Summary" Width="45%" OnClick="AllShipSummeryButton_Click"  CausesValidation="False"/>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Panel ID="SelectedShipDetailPanel" runat="server">

                                <asp:Label ID="LastShipmentLabel" runat="server" Text="Selected Shipment Summary" Font-Size="15pt"></asp:Label>
                                &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryShipDetailGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                            </asp:GridView>
                                <asp:Button ID="Button1" runat="server" Text="Excel" OnClick="ExcelButtonLShD_Click" CausesValidation="False"/>
                            </asp:Panel>

                            <asp:Panel ID="AllShipDetailPanel" runat="server">

                                <asp:Label ID="Label2" runat="server" Text="All Shipment Summary" Font-Size="15pt"></asp:Label>
                                &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryAllShipDetailGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                            </asp:GridView>
                                <asp:Button ID="Button4" runat="server" Text="Excel" OnClick="ExcelButtonLAllShD_Click" CausesValidation="False"/>

                            </asp:Panel>

                        </td>

                    </tr>

                    <tr>
                        <td></td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Button ID="SelectedShipItemsButton" runat="server" Text="Show Selected Ship Items" Width="45%" OnClick="ShipItemsButton_Click"  CausesValidation="False"/>
                            <asp:Button ID="AllShipItemsButton" runat="server" Text="Show All Ship Items" Width="45%" OnClick="AllShipItemsButton_Click"  CausesValidation="False"/>
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Panel ID="SelectedShipItemsPanel" runat="server">

                                <asp:Label ID="Label1" runat="server" Text="Selected Shipment Item List" Font-Size="15pt"></asp:Label>
                                &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryShipItemListGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                            </asp:GridView>
                                <asp:Button ID="Button3" runat="server" Text="Excel" OnClick="ExcelButtonLShI_Click" CausesValidation="False"/>

                            </asp:Panel>

                            <asp:Panel ID="AllShipItemsPanel" runat="server">

                                <asp:Label ID="Label3" runat="server" Text="All Shipment Item List" Font-Size="15pt"></asp:Label>
                                &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryAllShipItemListGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                            </asp:GridView>
                                <asp:Button ID="Button5" runat="server" Text="Excel" OnClick="ExcelButtonLAllShI_Click" CausesValidation="False" />

                            </asp:Panel>

                        </td>
                    </tr>




                </table>
            </asp:Panel>


            <asp:Panel ID="CreateInvoicePanel" runat="server">
                <table class="item-table">
                    <tr>
                        <td>&nbsp &nbsp  &nbsp &nbsp
                            <asp:Button ID="OpenPanelButton" runat="server" Text="Open Search Panel" Width="30%" OnClick="OpenPanelButton_Click" CausesValidation="False" />
                            &nbsp &nbsp  &nbsp &nbsp 
                            <asp:Button ID="ClosePanelButton" runat="server" Text="Close Search Panel" Width="30%" OnClick="ClosePanelButton_Click" CausesValidation="False" />
                        </td>
                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Select Shippments For Invoicing" Font-Size="25pt"></asp:Label>

                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Start Date" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp    &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp &nbsp 
                           <asp:Label ID="Label5" runat="server" Text="End Date" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="MinDateUnBilledShipmentTextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False"></asp:TextBox>
                            <asp:TextBox ID="MaxDateUnBilledShipmentTextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" OnTextChanged="jQueryShippGridView_PreRender"></asp:TextBox>
                            <asp:Button ID="ShowUnBilledShippmentButton" runat="server" Text="Show Shippments" OnClick="ShowUnBilledShippmentButton_Click" CausesValidation="False"    />
                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <!-- If you make this part  AutoGenerateEditButton="true"  instead of false this is a ready editable gridview. This is just for test not use -->
                        <td>
                            <asp:GridView ID="jQueryUnBilledShipmentsGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" AutoGenerateColumns="true" AutoGenerateEditButton="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbSelect" runat="server" CssClass="chkRow"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                </Columns>

                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>




                            <!-- Trying Editable GridView Start Here  <asp:TemplateField HeaderText="Quantitiy">-->
                            <!-- Trying Editable GridView Finish Here </asp:TemplateField>-->
                            <!-- Trying Editable GridView Plus AutoGenerateEditButton="True"-->
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="InvoiceDateLabel" runat="server" Text="Date:" Font-Size="15pt" Width="30%"></asp:Label>
                            &nbsp &nbsp
                            

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="InvoiceDateTextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False"></asp:TextBox>


                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="VAT:" Font-Size="15pt" Width="30%"></asp:Label>
                            <asp:Label ID="Label8" runat="server" Text="Consultant:" Font-Size="15pt" Width="30%"></asp:Label>
                            <asp:Label ID="Label9" runat="server" Text="PaymentStatus:" Font-Size="15pt" Width="30%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="VATDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="30%" AutoPostBack="False"></asp:DropDownList>
                            <asp:DropDownList ID="ConsultantDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="30%" AutoPostBack="False"></asp:DropDownList>
                           
                            <asp:DropDownList ID="PaymentStatusDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="30%" AutoPostBack="False">
                                <asp:ListItem Text="Open" Value="1" Selected="true" />
                                <asp:ListItem Text="Close" Value="2" />
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ErrorMessage="Consultant Required" ControlToValidate="ConsultantDropDownList"
                                InitialValue="" runat="server" ForeColor="Red" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="NoteLabel" runat="server" Text="Notes:"></asp:Label>
                            <asp:TextBox ID="InvoiceNotesTextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Button
                                ID="CreateInvoiceButton"
                                runat="server"
                                Text="Create Invoice"
                                Font-Size="20pt"
                                OnClientClick="return confirmAndSubmit();" 
                                OnClick="CreateInvoiceButton_Click" />
                        </td>
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
                            <asp:GridView ID="jQueryInvoiceDetailGridView" runat="server" DataKeyNames="InvDetID, InvID" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AutoGenerateEditButton="true" OnRowEditing="jQueryInvoiceDetailGridView_RowEditing" OnRowCancelingEdit="jQueryInvoiceDetailGridView_RowCancelingEdit" OnRowUpdating="jQueryInvoiceDetailGridView_RowUpdating">
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
                                    <asp:BoundField DataField="VAT Included Amount" HeaderText="VAT Included Amount" ReadOnly="true" DataFormatString="{0:N2}" />
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
                        <td style="text-align: left;">
                            <asp:Button ID="PrintButton" runat="server" Text="Print Invoice" OnClientClick="printDiv()" Height="38px" Width="162px" /></td>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align: left;">
                            <asp:Button ID="CloseInvoiceButton" runat="server" Text="Transaction and Close" Height="38px" Width="162px" OnClick="CloseInvoiceButton_Click" /></td>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                </table>

            </asp:Panel>






        </div>








    </div>

    <div>
    </div>


    <script type="text/javascript">

        function pageLoad() {
            $('#<%=jQueryShipGridView.ClientID%>').DataTable();
            $('#<%=jQueryUnBilledShipmentsGridView.ClientID%>').DataTable();
            $('#<%=jQueryAllShipDetailGridView.ClientID%>').DataTable();
            $('#<%=jQueryAllShipItemListGridView.ClientID%>').DataTable();


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


    <%--This procedure is for validation and confirmation together usage and validation can start work after page load immediately--%> 


    <script type="text/javascript">
        function confirmAndSubmit() {
            // Trigger client-side validation
            var isValid = Page_ClientValidate();

            if (isValid) {
                // If validation is successful, show confirmation
                if (confirm('Are you sure you want to CREATE this invoice?')) {
                    // User confirmed, trigger the server-side click event
                    __doPostBack('<%= CreateInvoiceButton.UniqueID %>', '');
                } else {
                    // User canceled, prevent the server-side click event
                    return false;
                }
            } else {
                // If validation fails, prevent the server-side click event
                return false;
            }
        }
    </script>





</asp:Content>
