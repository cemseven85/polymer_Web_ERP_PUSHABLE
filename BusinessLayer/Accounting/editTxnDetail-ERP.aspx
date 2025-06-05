<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="editTxnDetail-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.editTxnDetail_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div class="product-type" >   <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->
        
          <asp:ScriptManager runat="server" />
          
        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Group_Panel_7" runat="server" GroupingText="Transaction Detail List">
                <table class="item-table">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview"   -->
                        <td>
                            <asp:GridView ID="TxnDetailGridView"  runat="server"  CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" OnPreRender="TxnDetailGridViewBind_PreRender" OnSelectedIndexChanged="TxnDetailGridView_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Select"></asp:CommandField>
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
         
         
         <div class="menu-item" >
            <asp:Panel ID="Product_Group_Panel_1" runat="server">
            <table class="item-table">
                <tr>
                    <td ><asp:Label  ID="Transaction_Type_Name_Label" runat="server" Text="Select Transaction Type" Font-Size="20pt"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:DropDownList ID="TransactionTypeIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"   ></asp:DropDownList></td>
                        
                </tr>
            </table>
            </asp:Panel></div>
         
         <div class="menu-item" >
            <asp:Panel ID="Product_Group_Panel_2" runat="server">
            <table class="item-table">
                <tr>
                    <td ><asp:Label  ID="Transaction_Detail_Name_Lable" runat="server" Text="Transaction Detail Name" Font-Size="20pt"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:TextBox  ID="Transaction_Detail_Name_TextBox" runat="server" CssClass="textBoxL" Font-Size="15pt"></asp:TextBox></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="Product_Group_Panel_3" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:Label  ID="Transaction_Detail_Name2_Label_BG" runat="server" Text="Transaction Detail Name2"></asp:Label></td>
                </tr>
                <tr>
                    <td> <asp:TextBox ID="Transaction_Detail_Name2_BG_TextBox" runat="server" CssClass="textBoxL" Font-Size="15pt"  ></asp:TextBox> </td>
                </tr>
            </table>
            </asp:Panel></div>
        
        <div class="menu-item"  >
            <asp:Panel ID="Product_Group_Panel_5" runat="server">
      <table class="item-table">
                <tr>
                    <td><asp:Label  ID="Transaction_Detail_Description_Label" runat="server" Text="Description (EN-TR)"></asp:Label>  </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="Transaction_Detail_Description_TextBox" runat="server" CssClass="textBoxL" Font-Size="15pt" Max-Width="650px" Width="98%"  Height="200px" TextMode="MultiLine" ></asp:TextBox>  </td>
                </tr>
            </table>               
            </asp:Panel></div>       
    
    
      <div class="menu-item"  >
            <asp:Panel ID="Product_Group_Panel_6" runat="server">
      <table class="item-table-button">
                <tr>
                    <td> </td>
                </tr>
                <tr>
                    <td> <asp:Button ID="EditDetailButton" runat="server" Text="Edit Transaction Detail " Height="50px" Width="250px" Font-Size="15pt"   type="button" OnClick="EditDetailButton_Click" /> </td>
                            
                   
                </tr>
            </table>               
            </asp:Panel></div>  
         
         

         <div>

              <script type="text/javascript">

                  function pageLoad() {
                      $('#<%=TxnDetailGridView.ClientID%>').DataTable();

                  };

              </script>

            <script>

                $('#<%=TransactionTypeIdDropDownList.ClientID%>').chosen();
                $(".chosen-container").css('font-size', '15pt');
            </script>
        </div>


           
    </div>

</asp:Content>
