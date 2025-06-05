<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="editProduct-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.editProduct_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="product-type">
         <asp:ScriptManager runat="server" />
        <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->

          <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_10" runat="server"  GroupingText="PRODUCT LIST">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryProductGridView" runat="server" CssClass="product-type-gridview" OnPreRender="jQueryProductGridView_PreRender" OnSelectedIndexChanged="jQueryProductGridView_SelectedIndexChanged"  ShowHeaderWhenEmpty="true"  >
                                <Columns>
                                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC"/>
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
                            <asp:Label ID="Product_Name_Lable" runat="server" Text="Product Name (EN)" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Product_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_3" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Product_Name_Label_BG" runat="server" Text="име на продуктова (BG)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Product_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_4" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Product_Name_TR_Label" runat="server" Text="Ürün Adı (TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Product_Name_TR_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Panel_1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Product_Group_Name_Label" runat="server" Text="Select Product Group" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductGroupIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Panel_5" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Product_Unit_Label" runat="server" Text="Select Product Unit" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductUnitIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Panel_6" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Product_VAT_Label" runat="server" Text="Select Product VAT" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductVATIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Panel_7" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Product_WasteCode_Label" runat="server" Text="Select Product Waste Code" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductWasteCodeIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>       
        <div class="menu-item">
            <asp:Panel ID="Product_Panel_9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Product_Description_Label" runat="server" Text="Description (EN-TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Product_Description_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <table class="item-table">

                <tr>
                    <td>
                        <asp:Button ID="prdEditButton" runat="server" Text="EDIT" Height="50px" Width="300" Font-Size="20pt" Visible="True"   OnClientClick="return confirm('Are you sure you want to edit this item?');" OnClick="prdEditButton_Click"   />
                    </td>
                    <td>
                        <asp:Button ID="prdCancelButton" runat="server" Text="CANCEL" Height="50px" Width="300" Font-Size="20pt" Visible="True" OnClick="prdCancelButton_Click"     />
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
                          var table = $('#<%=jQueryProductGridView.ClientID%>').DataTable(
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

    <script>
        $('#<%=ProductGroupIdDropDownList.ClientID%>').chosen();
        $('#<%=ProductUnitIdDropDownList.ClientID%>').chosen();
        $('#<%=ProductVATIdDropDownList.ClientID%>').chosen();
        $('#<%=ProductWasteCodeIdDropDownList.ClientID%>').chosen();

        /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


        $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

        /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */
    </script> 



</asp:Content>
