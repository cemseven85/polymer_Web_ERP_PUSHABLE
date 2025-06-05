<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="editPurchase-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.editPurchase_ERP"  %>

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
                            <asp:Button ID="ShowReportButton" runat="server" Text="Show Report" OnClick="ShowReportButton_Click" AutoPostBack="True" EnableViewState="True"  CausesValidation="false" />

                            
                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryPurchaseGridView" runat="server" CssClass="product-type-gridviewS" OnPreRender="jQueryPurchaseGridView_PreRender" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="jQueryPurchaseGridView_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC" />
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
                            <asp:Label ID="Invoice_No_Lable" runat="server" Text="Invoice No" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Invoice_No_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Product_Panel_1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Group_Name_Label" runat="server" Text="Select Seller Group" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="SellerGroupIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="SellerGroupIdDropDownList_SelectedIndexChanged"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Panel1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Name_Labe" runat="server" Text="Select Seller" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="SellerIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel2" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Purchase_Date_Lable" runat="server" Text="Date (MM/DD/YYYY)" Font-Size="15pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Purchase_DateTextBox" runat="server" CssClass="textBox" TextMode="Date" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel3" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="PurchaseProductGroupIDLabel" runat="server" Text="Select Product Group" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="PurchaseProductGroupIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="PurchaseProductGroupIDDropDownList_SelectedIndexChanged"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel4" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="PurchaseProductIDLabel" runat="server" Text="Select Product" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="PurchaseProductIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="PurchaseProductIDDropDownList_SelectedIndexChanged"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel5" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Purchase_Quantity_Label" runat="server" Text="Quantity" Font-Size="15pt"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="Purchase_Unit_Label" runat="server" Text="Unit" Font-Size="15pt"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="Unit_Price_Label" runat="server" Text="Unit Price" Font-Size="15pt"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="VAT_Label" runat="server" Text="VAT%" Font-Size="15pt"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Purchase_Quantity_TextBox" runat="server" CssClass="textBoxS" Font-Size="15pt"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                ControlToValidate="Purchase_Quantity_TextBox" runat="server"
                                ErrorMessage="Please enter a value" Display="Dynamic" CssClass="valError">
                            </asp:RequiredFieldValidator>


                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="Purchase_Quantity_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed" CssClass="valError" ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">     
                            </asp:RegularExpressionValidator>

                        </td>
                        <td>
                            <asp:TextBox ID="Purchase_Unit_TextBox" runat="server" CssClass="textBoxXS" Font-Size="15pt" ReadOnly="true"></asp:TextBox>

                        </td>
                        <td>
                            <asp:TextBox ID="Unit_Price_TextBox" runat="server" CssClass="textBoxS" Font-Size="15pt"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                ControlToValidate="Unit_Price_TextBox" runat="server"
                                ErrorMessage="Please enter a value" Display="Dynamic" CssClass="valError">
                            </asp:RequiredFieldValidator>


                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                ControlToValidate="Unit_Price_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed" CssClass="valError" ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">     
                            </asp:RegularExpressionValidator>

                        </td>
                        <td>
                            <asp:TextBox ID="VAT_TextBox" runat="server" CssClass="textBoxXS" Font-Size="15pt" ReadOnly="true"></asp:TextBox>

                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel6" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="OriginID_Label" runat="server" Text="Select Origin" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="OriginIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel8" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Weight_Brige_Code_Label" runat="server" Text="Weight Brige Code" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Weight_Brige_Code_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Panel7" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="StockZoneID_Label" runat="server" Text="Select Stock Zone" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="StockZoneIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="EmployeeID_Label" runat="server" Text="Select Supervisor" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="EmployeeIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel11" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Consultant_Label" runat="server" Text="Select Consultant" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ConsultantDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel10" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Item_Name_Label" runat="server" Text="Item Name" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Item_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Item_Note_Label" runat="server" Text="Item Notes"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Item_Note_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <table class="item-table">

                <tr>
                    <td>
                        <asp:Button ID="EditButton" runat="server" Text="EDIT" Height="50px" Width="300" Font-Size="20pt" Visible="True" OnClientClick="return confirm('Are you sure you want to edit this item?');" OnClick="EditButton_Click" />
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





    <script type="text/javascript">
        $('#<%=SellerGroupIdDropDownList.ClientID%>').chosen();
        $('#<%=SellerIdDropDownList.ClientID%>').chosen();
        $('#<%=PurchaseProductGroupIDDropDownList.ClientID%>').chosen();
        $('#<%=PurchaseProductIDDropDownList.ClientID%>').chosen();
        $('#<%=StockZoneIDDropDownList.ClientID%>').chosen();
        $('#<%=OriginIDDropDownList.ClientID%>').chosen();
        $('#<%=EmployeeIDDropDownList.ClientID%>').chosen();
        $('#<%=ConsultantDropDownList.ClientID%>').chosen();

        /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


        $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

        /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */
    </script>


</asp:Content>
