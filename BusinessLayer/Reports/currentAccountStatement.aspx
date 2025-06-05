<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="currentAccountStatement.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Reports.current_Account_Statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="product-type">

        <div class="menu-item">
            <asp:Panel ID="Panel_2" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Start Date" Font-Size="15pt"></asp:Label>
                            &nbsp  &nbsp  &nbsp    &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp &nbsp 
                           <asp:Label ID="Label2" runat="server" Text="End Date" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="false" ></asp:TextBox>
                            <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="false" ></asp:TextBox>
                        </td>
                    </tr>
                    

                </table>
            </asp:Panel>
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
            <asp:Button ID="Show_Txn_List_Button" runat="server" Text="Show Txn List" Height="30px" Width="150" Font-Size="15pt" OnClick="Show_Txn_List_Button_Click"   />

        </div>


     <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Show_Txn_List_Panel" runat="server" GroupingText="Transaction Module">

            
                <asp:GridView ID="jQueryList_Txn_GridView" runat="server" DataKeyNames="txnID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="jQueryList_Txn_GridView_PreRender" >
                    <Columns>
                        
                        
                        <asp:BoundField DataField="txnID" HeaderText="txn_ID" ReadOnly="true" />
                        <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                        <asp:BoundField DataField="Transaction" HeaderText="Transaction" ReadOnly="true" />
                        <asp:BoundField DataField="txnType" HeaderText="txnType" ReadOnly="true" />
                        <asp:BoundField DataField="txnDetail" HeaderText="txnDetail" ReadOnly="true" />
                        <asp:BoundField DataField="accType" HeaderText="accType" ReadOnly="true" />

                        
                        <asp:BoundField DataField="Account" HeaderText="Account" ReadOnly="true"  />
                        <asp:BoundField DataField="Debit" HeaderText ="Debit" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Credit" HeaderText="Credit" ReadOnly="true" DataFormatString="{0:N2}" />
                         <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="true" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="D/C" HeaderText="D/C" ReadOnly="true"  />
                        <asp:BoundField DataField="Consultant" HeaderText="Consultant" ReadOnly="true"  />
                        <asp:BoundField DataField="Notes" HeaderText="Notes" ReadOnly="true"  />
                        
                        

                    </Columns>
                     <SelectedRowStyle BackColor="#3333CC" />
                </asp:GridView>

                 <asp:Button ID="ExcelButton" runat="server" Text="Excel" OnClick="ExcelButton_Click" />
            </asp:Panel>

        </div>


 </div>



    <script type="text/javascript">

        $('#<%=accTypeIDDropDownList.ClientID%>').chosen();
        $('#<%=accNameIDDropDownList.ClientID%>').chosen();
       


        /* $(".chosen-results").css('font-size', '20pt');  CSS StyleSheet de yaptım.   .chosen-results  altında    */


        $(".chosen-container").css('font-size', '15pt');     /* .chosen-container  is coming from chosen()  chosen.min.css" we can control its CSS script  */

        /* By this code we can style the dropdownlist  related with Jquary. Important Practice  */
    </script>





</asp:Content>
