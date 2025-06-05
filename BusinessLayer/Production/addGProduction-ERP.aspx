<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addGProduction-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.addGProduction" %>
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
                            <asp:Label ID="Production_Date_Lable" runat="server" Text="OutPut Date" Font-Size="15pt"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="Production_Time_Label" runat="server" Text="OutPut Time" Font-Size="15pt"></asp:Label>

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
                            <asp:Label ID="Product_Group_Labe" runat="server" Text="Select Product Group" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductGroupIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="ProductGroupIDDropDownList_SelectedIndexChanged"></asp:DropDownList>
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
                            <asp:Label ID="Product_Name_Labe" runat="server" Text="Select Product" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True" ></asp:DropDownList>
                        </td>                        
                        
                    </tr>
                </table>
            </asp:Panel>
        </div>
 
         <div class="menu-item">
            <asp:Panel ID="Panel_10" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Item_Name_Label" runat="server" Text="Item Name" Font-Size="20pt"></asp:Label>
                        </td>                       
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Item_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>

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
            <asp:Panel ID="Panel_11" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="StockZoneID_Label" runat="server" Text="Select Stock Zone" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="StockZoneIDDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList>
                        </td>
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
                        <asp:Button ID="RunButton" runat="server" Text="START" Height="30px" Width="150" Font-Size="15pt" Visible="True" OnClientClick="return confirm('Are you sure you want to run this Production?');" OnClick="RunButton_Click"  />
                    </td>
                </tr>
            </table>
        </div>

         <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_4" runat="server"  GroupingText="DAILY GRANULE PRODUCTION LIST">
                <table class="item-table">
                    
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryProductOutPutGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true" OnPreRender="jQueryDailyGranuleGridViewBind_PreRender"  >
                                
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
             var table = $('#<%=jQueryProductOutPutGridView.ClientID%>').DataTable(
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



     </script>


     <script type="text/javascript">
         $('#<%=ProductIdDropDownList.ClientID%>').chosen();
         $('#<%=ProductGroupIdDropDownList.ClientID%>').chosen();
         $('#<%=EmployeeIDDropDownList.ClientID%>').chosen();
         $('#<%=StockZoneIDDropDownList.ClientID%>').chosen();
         $('#<%=ConsultantDropDownList.ClientID%>').chosen();
         
         /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


         $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

         /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */
     </script>    




</asp:Content>
