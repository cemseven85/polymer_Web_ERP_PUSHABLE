<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="edditPrdGroup-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.edditPrdGroup_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-type" >   <!-- Because layout is same I use the same class with product Type page same css  also same css for dropdown list  CssClass="product-type-modify-dropdown" -->
       
         <div class="menu-item-datalist" style="overflow:scroll"  >
            <asp:Panel ID="Product_Group_Panel_7" runat="server" GroupingText="PRODUCT GROUP LIST">
            <table class="item-table">
                <tr>
                    <td > </td>
                </tr>
                <tr>           <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                    <td> <asp:GridView ID="ProductGroupGridView" GridLines="None" runat="server" AllowPaging="true" PagerStyle-CssClass="paging"  PageSize="3" CssClass="product-type-gridview" OnPageIndexChanging="ProductGroupGridView_PageIndexChanging" OnSelectedIndexChanged="ProductGroupGridView_SelectedIndexChanged"  ShowHeaderWhenEmpty="true" >
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Select" >                            
                            </asp:CommandField>
                        </Columns>
                        <SelectedRowStyle BackColor="#3333CC" />
                        </asp:GridView> </td>                       
                </tr>
            </table>
            </asp:Panel></div>


        
        
        <div class="menu-item" >
            <asp:Panel ID="Product_Group_Panel_8" runat="server">
            <table class="item-table" style="background-color:brown"">
                <tr>
                    <td ><asp:Label  ID="Select_Group_Name_Label" runat="server" Text="Select Product Group Name To Edit" Font-Size="20pt"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:DropDownList ID="ProductGroupIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ProductGroupIdDropDownList_SelectedIndexChanged"  ></asp:DropDownList></td>
                      
                </tr>
            </table>
            </asp:Panel></div> 
        
        
        
        <div class="menu-item" >
            <asp:Panel ID="Product_Group_Panel_1" runat="server">
            <table class="item-table">
                <tr>
                    <td ><asp:Label  ID="Product_Type_Name_Label" runat="server" Text="Edit Product Group Type Name" Font-Size="20pt"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:DropDownList ID="ProductTypeIdDropDownList" runat="server" CssClass="product-type-modify-dropdown" AutoPostBack="True"   ></asp:DropDownList></td>
                        
                </tr>
            </table>
            </asp:Panel></div>
         
         <div class="menu-item" >
            <asp:Panel ID="Product_Group_Panel_2" runat="server">
            <table class="item-table">
                <tr>
                    <td ><asp:Label  ID="Product_Group_Name_Lable" runat="server" Text="Edit Product Group Name (EN)" Font-Size="20pt"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:TextBox  ID="Product_Group_Name_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox></td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="Product_Group_Panel_3" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:Label  ID="Product_Group_Name_Label_BG" runat="server" Text=" редактиране име на продуктова група (BG)"></asp:Label></td>
                </tr>
                <tr>
                    <td> <asp:TextBox ID="Product_Group_Name_BG_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"  ></asp:TextBox> </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="Product_Group_Panel_4" runat="server">
                <table class="item-table">
                <tr>
                    <td><asp:Label  ID="Product_Group_Name_TR_Label" runat="server" Text="Düzenle Ürün Grup Adı (TR)"></asp:Label> </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="Product_Group_Name_TR_TextBox" runat="server" CssClass="textBox" Font-Size="20pt"></asp:TextBox> </td>
                </tr>
            </table>
            </asp:Panel></div>
        <div class="menu-item"  >
            <asp:Panel ID="Product_Group_Panel_5" runat="server">
      <table class="item-table">
                <tr>
                    <td><asp:Label  ID="Product_Group_Description_Label" runat="server" Text="Edit Description (EN-TR)"></asp:Label>  </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="Product_Group_Description_TextBox" runat="server" CssClass="textBox" Font-Size="20pt" Max-Width="650px" Width="98%"  Height="200px" TextMode="MultiLine"  ></asp:TextBox>  </td>
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
                    <td> <asp:Button ID="EdditGroupButton" runat="server" Text="Eddit Group " Height="50px" Width="250px" Font-Size="20pt"   type="button" OnClick="EdditGroupButton_Click" OnClientClick="return confirm('Are you sure you want to Edit this item?');"  /> </td>
                            
                   
                </tr>
            </table>               
            </asp:Panel></div>  
         
         

        <div>
            <script>
                $('#<%=ProductGroupIdDropDownList.ClientID%>').chosen();   
                $('#<%=ProductTypeIdDropDownList.ClientID%>').chosen();              
                /* $(".chosen-results").css('font-size', '20pt');      CSS StyleSheet de yaptım.    .chosen-results  altında    */
                $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control it script  */
             
            </script>         
        </div>        

    </div>

</asp:Content>
