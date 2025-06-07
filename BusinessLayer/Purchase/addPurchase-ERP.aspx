<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addPurchase-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addPurchase_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
        <asp:ScriptManager runat="server" />
        <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->

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
                            <asp:Label ID="Purchase_Date_Lable" runat="server" Text="Date" Font-Size="20pt"></asp:Label></td>
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
                       <%-- <td>
                            <asp:TextBox ID="VAT_TextBox" runat="server" CssClass="textBoxXS" Font-Size="15pt" ReadOnly="true"></asp:TextBox>
                        </td>--%>



                                                    <%--Added DropDownList for VAT selection after the tbl_Purchase-add-taxId Branch --%>

                        <td>
                            <asp:DropDownList ID="VATDropDownList" runat="server" CssClass="textBoxXS" Font-Size="15pt"></asp:DropDownList>
                        </td>


                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel_7" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Num_Bales_Label" runat="server" Text="Number Of Bales"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Num_Bales_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                ControlToValidate="Num_Bales_TextBox" runat="server"
                                ErrorMessage="Only Integer Allowed"
                                CssClass="valError"
                                ValidationExpression="\d+">                                 
                            </asp:RegularExpressionValidator>

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
                        <asp:Button ID="AddButton" runat="server" Text="ADD" Height="50px" Width="300" Font-Size="20pt" Visible="True" OnClientClick="return confirm('Are you sure you want to add this item?');" OnClick="AddButton_Click" />
                    </td>
                </tr>

            </table>
        </div>


        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_10" runat="server" GroupingText="Last 90 Days Purchase List">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!--   Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryPurchaseGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true">
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
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
                    order: [[0, 'desc']],



                });





            $('#ContentPlaceHolder1_jQueryPurchaseGridView tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                } else {
                    table.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                }


                //Reference the GridView Row.
                var row = $(this).closest("tr");
                //Determine the Row Index.
                var message = "Selected Purchase Details ";
                //Read values from Cells.
                message += "\nDate: " + row.find("td").eq(0).html();
                message += "\nProduct: " + row.find("td").eq(1).html();
                message += "\nSeller: " + row.find("td").eq(2).html();
                message += "\nInvoice No" + row.find("td").eq(3).html();
                message += "\nOrigin: " + row.find("td").eq(7).html();
                message += "\nUnit: " + row.find("td").eq(11).html();
                message += "\nQuantitiy: " + row.find("td").eq(12).html();
                message += "\nPrice: " + row.find("td").eq(13).html();
                message += "\nTotal Amount: " + row.find("td").eq(14).html();
                message += "\nVAT Include Amount: " + row.find("td").eq(16).html();
                message += "\nStock Zone: " + row.find("td").eq(5).html();
                //Display the data using JavaScript Alert Message Box.
                alert(message);
                return false;


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
