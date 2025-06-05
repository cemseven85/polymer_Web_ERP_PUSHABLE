<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addShipment-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addShipment_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Attach the click event handler to the button
            $('#<%= btnUpdate.ClientID %>').click(function (e) {
                e.preventDefault();
                __doPostBack('<%= btnUpdate.UniqueID %>', '');
            });
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="product-type">


        <div class="menu-item">
            <asp:Panel ID="Panel_1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Production_Date_Lable" runat="server" Text="Shipment Date" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Production_DateTextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Panel_2" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Product_Group_Label" runat="server" Text="Select Product Group" Font-Size="20pt"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Product_Name_Label" runat="server" Text="Select Product" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductGroupIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="ProductGroupIdDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ProductIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Customer_Group_Label" runat="server" Text="Select Customer Group" Font-Size="20pt"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Customer_Name_Lable" runat="server" Text="Select Customer" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="CustomerGroupIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="CustomerGroupIdDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="CustomerIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>

                </table>
            </asp:Panel>
        </div>





        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_4" runat="server" GroupingText="Granules in Stock List">
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
                            <asp:Button ID="ShowItemsButton" runat="server" Text="Show Shippments" OnClick="ShowItemsButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->

                        <td>
                            <asp:GridView ID="jQueryShipGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryShippGridView_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbSelect" runat="server" CssClass="chkRow" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                            <!-- Need to put GridView Here  -->
                            <!-- Need to put GridView Here  -->
                            <!-- Need to put GridView Here  -->
                        </td>
                        <td  style="border:double">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Image ID="Kg_Loaded_Icon" runat="server" ImageUrl="~/images/lose-weight.png" Height="183px" Width="183px" ImageAlign="Middle" />
                                    <br />
                                    <asp:Label ID="lblResult" runat="server" Text="Initial"  Font-Size="30pt" Width="183px"  style="text-align:center"></asp:Label>
                                    <br />
                                    <asp:Button ID="btnUpdate" runat="server" Text="KG to be Loaded Now" OnClick="btnUpdate_Click" Height="40px" Width="183px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LastShipmentLabel" runat="server" Text="Last Shipment" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp
                            <asp:GridView ID="jQueryLastShipGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryLastShippGridView_PreRender">
                            </asp:GridView>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="AddToLastShip_Button" runat="server" Text="ADD TO LAST SHIPPMENT" CssClass="runButtonL" Visible="True" OnClientClick="return confirm('Are you sure you want to run this Production?');" OnClick="AddToLastShip_Click" />
                        </td>
                    </tr>

                </table>
            </asp:Panel>
        </div>



        <div class="menu-item">
            <asp:Panel ID="Panel_6" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="EmployeeID_Label" runat="server" Text="Select Supervisor" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="EmployeeIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Panel_8" runat="server">
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
            <asp:Panel ID="Product_Panel_9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Shipment_Note_Label" runat="server" Text="Shipment Note"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Shipment_Note_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <table class="item-table">
                <tr>

                    <td>
                        <asp:Button ID="RunButton" runat="server" Text="NEW SHIP" Height="30px" Width="150" Font-Size="15pt" Visible="True" OnClientClick="return confirm('Are you sure you want to run this Production?');" OnClick="RunButton_Click" />

                    </td>
                </tr>
            </table>
        </div>

    </div>

    <div>
    </div>


    <script type="text/javascript">

        function pageLoad() {
            $('#<%=jQueryShipGridView.ClientID%>').DataTable({
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true,
                retrieve: true,
                stateSave: false,
                order: [[0, 'DESC']],

            });
            $('#<%=jQueryLastShipGridView.ClientID%>').DataTable();
           


        };



    </script>







    <script type="text/javascript">
        $('#<%=ProductIdDropDownList.ClientID%>').chosen();
        $('#<%=ProductGroupIdDropDownList.ClientID%>').chosen();
        $('#<%=CustomerIdDropDownList.ClientID%>').chosen();
        $('#<%=CustomerGroupIdDropDownList.ClientID%>').chosen();
        $('#<%=EmployeeIDDropDownList.ClientID%>').chosen();



        /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


        $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

        /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */
    </script>





</asp:Content>
