<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addTxn-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addTxn_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="product-type" id="productTypeDiv">


        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Payment / Collection:" Font-Size="15pt"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Date:" Font-Size="15pt"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:DropDownList ID="paymentCollectionIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" AutoPostBack="False">
                            <asp:ListItem Text="[ Select Transaction Mode ]" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Payment" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Collection" Value="2"></asp:ListItem>

                        </asp:DropDownList>
                    </td>

                    <td>
                        <asp:TextBox ID="TxnDate_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>

        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Transaction Type:" Font-Size="15pt"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Transaction Detail:" Font-Size="15pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="txnTypeIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" AutoPostBack="true" OnSelectedIndexChanged="txnTypeIDDropDownList_ScelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="txnDetailIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>

            </table>
        </div>


        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Account Type:" Font-Size="15pt"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Account Name:" Font-Size="15pt"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="accTypeIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" AutoPostBack="true" OnSelectedIndexChanged="accTypeIDDropDownList_ScelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="accNameIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" AutoPostBack="true" OnSelectedIndexChanged="aaccNameIDDropDownList_ScelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>

            </table>

        </div>

        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Consultant:" Font-Size="15pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="consultantIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" AutoPostBack="False"></asp:DropDownList>
                    </td>
                </tr>
            </table>

        </div>


        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Amount of Transaction:" Font-Size="15pt"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Account Balance :" Font-Size="15pt" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="amount_TextBox" runat="server" CssClass="textBoxM" Font-Size="15pt" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                            ControlToValidate="amount_TextBox" runat="server"
                            ErrorMessage="Only Numbers Allowed" CssClass="valError" ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$"> </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Label ID="Current_Balance_Label" runat="server" Text="............." Font-Size="15pt" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="creditDebitLabel" runat="server" Text="............." Font-Size="15pt" ForeColor="Red"></asp:Label>
                    </td>
                </tr>


            </table>

        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Item_Note_Label" runat="server" Text="Transaction Notes"></asp:Label>
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
            <asp:Panel ID="Panel1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Button
                                ID="CreateTxnButton"
                                runat="server"
                                Text="Confirm Transaction"
                                Font-Size="20pt"
                                OnClientClick="return confirm('Are you sure you want to make this Transaction?')" OnClick="CreateTxnButton_Click" />
                        </td>
                    </tr>

                </table>
            </asp:Panel>
        </div>



    </div>



    <script type="text/javascript">
        $('#<%=paymentCollectionIDDropDownList.ClientID%>').chosen();
        $('#<%=txnTypeIDDropDownList.ClientID%>').chosen();
        $('#<%=txnDetailIDDropDownList.ClientID%>').chosen();
        $('#<%=accTypeIDDropDownList.ClientID%>').chosen();
        $('#<%=accNameIDDropDownList.ClientID%>').chosen();
        $('#<%=consultantIDDropDownList.ClientID%>').chosen();


        /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


        $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

        /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */

        

    </script>


    



    <%--
    <script type="text/javascript">

        function pageLoad() {
            $('#<%=jQueryShipGridView.ClientID%>').DataTable();


        };



    </script>

    <script type="text/javascript">
        function printDiv() {
            var printContents = document.getElementById('productTypeDiv').innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;


        }
    </script>
    --%>
</asp:Content>


