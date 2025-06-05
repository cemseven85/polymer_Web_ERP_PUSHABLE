<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="editSeller-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.editSeller_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="product-type">
         <asp:ScriptManager runat="server" />
        <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->
         <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_10" runat="server" GroupingText="Seller List">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQuerySellerGridView" runat="server" CssClass="product-type-gridview" OnPreRender="jQuerySellerGridView_PreRender" OnSelectedIndexChanged="jQuerySellerGridView_SelectedIndexChanged"  ShowHeaderWhenEmpty="true" >
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
                            <asp:Label ID="Seller_Name_Lable" runat="server" Text="Seller Name (EN)" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Group_Panel_3" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Name_Label_BG" runat="server" Text="име на продавача (BG)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
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
                            <asp:Label ID="Seller_Name_TR_Label" runat="server" Text="Satıcı Adı (TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Name_TR_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
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
                            <asp:Label ID="Seller_Group_Name_Label" runat="server" Text="Select Seller Group" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="SellerGroupIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" Max-Width="300px" Width="50%" AutoPostBack="True"></asp:DropDownList></td>

                    </tr>
                </table>
            </asp:Panel>
        </div>
         <div class="menu-item">
            <asp:Panel ID="Product_Panel_5" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Address_Label" runat="server" Text="Seller Address (EN)" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Address_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="70px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
          <div class="menu-item">
            <asp:Panel ID="Product_Panel_6" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Contact_Name_Lable" runat="server" Text="Seller Contact Name (EN)" Font-Size="20pt"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Contact_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Panel_7" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Contact_Name_BG_Lable" runat="server" Text="Име за връзка с продавача (BG)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Contact_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Product_Panel_8" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Contact_Name_TR_Lable" runat="server" Text="Satıcı Yetkili Adı (TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Contact_Name_TR_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
         <div class="menu-item">
            <asp:Panel ID="Product_Panel_11" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Tel_Lable" runat="server" Text="Telephone Number"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Tel_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
         <div class="menu-item">
            <asp:Panel ID="Product_Panel_12" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_GSM_Lable" runat="server" Text="Mobile Number (GSM)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_GSM_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
         <div class="menu-item">
            <asp:Panel ID="Product_Panel_13" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Tax_Id_Lable" runat="server" Text="Tax Id Number"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Tax_Id_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
         <div class="menu-item">
            <asp:Panel ID="Product_Panel_14" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Tax_Office_Lable" runat="server" Text="Tax Office Name"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Tax_Office_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
         <div class="menu-item">
            <asp:Panel ID="Product_Panel_15" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Key_Account_Lable" runat="server" Text="Seller Key Account Name"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Key_Account_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Product_Panel_9" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Seller_Note_Label" runat="server" Text="Notes About Seller (EN-TR)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Seller_Note_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        
         <div class="menu-item">
            <table class="item-table">

                <tr>
                    <td>
                        <asp:Button ID="EditButton" runat="server" Text="EDİT" Height="50px" Width="300" Font-Size="20pt" Visible="True"   OnClientClick="return confirm('Are you sure you want to edit this item?');" OnClick="EditButton_Click"  />
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
             var table = $('#<%=jQuerySellerGridView.ClientID%>').DataTable(
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
        $('#<%=SellerGroupIdDropDownList.ClientID%>').chosen();


        /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


        $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

        /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */
    </script> 

</asp:Content>
