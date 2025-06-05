<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addWProduction-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addWProduction_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-type">
        <asp:ScriptManager runat="server" />

        <div class="menu-item">
            <asp:Panel ID="Panel_1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Production_Date_Lable" runat="server" Text="Date" Font-Size="15pt"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="Production_Time_Label" runat="server" Text="Time" Font-Size="15pt"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Production_DateTextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt"></asp:TextBox>

                        </td>
                        <td>
                            <asp:TextBox ID="Production_TimeTextBox" runat="server" CssClass="textBoxS" TextMode="time" Font-Size="10pt"></asp:TextBox>

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
                            <asp:Label ID="Product_Name_Labe" runat="server" Text="Select Scrap Type" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="ProductIDDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td>
                             <asp:Button ID="AllButton" runat="server" Text="All" Height="30px" Width="140" Font-Size="15pt" Visible="True" style="float:right" OnClick="AllButton_Click"/>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel_3" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Name_Labe" runat="server" Text="Select Seller" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="SellerIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="SellerIdDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </td>                        
                        <td>
                            <asp:Button ID="BySellerButton" runat="server" Text="Filter By Seller" Height="30px" Width="140" Font-Size="15pt" Visible="True" style="float:right" OnClick="BySellerButton_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
 


        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_4" runat="server">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryScrapGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryScrapGridView_PreRender" >
                                <Columns>
                                    <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
             <asp:Panel ID="Product_Panel_4a" runat="server">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQuerySellerScrapGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQuerySellerScrapGridView_PreRender" >
                                <Columns>
                                    <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
            
        

        <div class="menu-item">
            <asp:Panel ID="Panel_5" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Purchase_Quantity_Label" runat="server" Text="Quantity" Font-Size="20pt"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="Purchase_Unit_Label" runat="server" Text="Unit" Font-Size="15pt"></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Purchase_Quantity_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                ControlToValidate="Purchase_Quantity_TextBox" runat="server"
                                ErrorMessage="Only Numbers Allowed"
                                CssClass="valError"
                                ValidationExpression="^(\d*\.?\d+|\d*(,\d*)*(\,\d+)?)$">     
                            </asp:RegularExpressionValidator>

                        </td>
                        <td>
                            <asp:TextBox ID="Purchase_Unit_TextBox" runat="server" CssClass="textBoxXS" Font-Size="15pt"></asp:TextBox>

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
            <asp:Panel ID="Panel_7" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Num_Bales_Label" runat="server" Text="Number Of Bales"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Num_Bales_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                ControlToValidate="Num_Bales_TextBox" runat="server"
                                ErrorMessage="Only Integer allowed"
                                CssClass="valError"
                                ValidationExpression="\d+">                                 
                            </asp:RegularExpressionValidator>
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
                            <asp:TextBox ID="Weight_Brige_Code_TextBox" runat="server" CssClass="textBox"   Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>


        <div class="menu-item">
            <asp:Panel ID="Product_Panel_9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Production_Note_Label" runat="server" Text="Production Note"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Production_Note_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <table class="item-table">
                <tr>                   
                    
                    <td>
                        <asp:Button ID="RunButton" runat="server" Text="RUN" Height="30px" Width="150" Font-Size="15pt" Visible="True" OnClientClick="return confirm('Are you sure you want to run this Production?');" OnClick="RunButton_Click"  />
                    </td>
                </tr>
            </table>
        </div>

    </div>



     <script type="text/javascript">

         function pageLoad() {
             createDataTable();
             createDataTableTwo();
         };


         function createDataTable() {
             var table = $('#<%=jQueryScrapGridView.ClientID%>').DataTable(
                 {
                     bLengthChange: true,
                     lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                     bFilter: true,
                     bSort: true,
                     bPaginate: true,
                     retrieve: true,
                     stateSave: false,
                     order: [[1, 'asc']],

                 });

         }


         function createDataTableTwo() {
             var table = $('#<%=jQuerySellerScrapGridView.ClientID%>').DataTable(
                 {
                     bLengthChange: true,
                     lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                     bFilter: true,
                     bSort: true,
                     bPaginate: true,
                     retrieve: true,
                     stateSave: false,
                     order: [[1, 'DESC']],

                 });

         }

     </script>


     <script type="text/javascript">
         $('#<%=ProductIdDropDownList.ClientID%>').chosen();
         $('#<%=SellerIdDropDownList.ClientID%>').chosen();
         $('#<%=EmployeeIDDropDownList.ClientID%>').chosen();

         

         /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


         $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

         /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */
     </script>    





</asp:Content>

