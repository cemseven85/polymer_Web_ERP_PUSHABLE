<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listTxn-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.listTxn_ERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="product-type">
          <div class="menu-item">
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
                            <asp:TextBox ID="ItemDateMin_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" ></asp:TextBox>
                            <asp:TextBox ID="ItemDateMax_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt" AutoPostBack="False" ></asp:TextBox>                            
                        </td>
                    </tr>
            </table>
        </div>

        <div class="menu-item">
            <asp:Button ID="Show_Txn_List_Button" runat="server" Text="Show Txn List" Height="30px" Width="150" Font-Size="15pt" OnClick="Show_Txn_List_Button_Click"  />

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

                function pageLoad() {
                    createDataTable();
                };
                
      
                      function createDataTable() {
                          var table = $('#<%=jQueryList_Txn_GridView.ClientID%>').DataTable(
                        {
                            bLengthChange: true,
                            lengthMenu: [[20, 30,50, -1], [20, 30,50,"All"]],
                            bFilter: true,
                            bSort: true,
                            bPaginate: true,
                            retrieve: true,
                            stateSave: false,
                            order: [[1, 'asc']],

                        });

                   
                                             
                      }
                     
    </script>


</asp:Content>
