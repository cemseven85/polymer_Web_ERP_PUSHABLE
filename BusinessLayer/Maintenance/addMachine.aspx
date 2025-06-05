<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addMachine.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.addMachine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- add div tag with calass product type, inside div one more div with class menu item and insede it table with class item table and inside table tr and td first th has a lable and second td has a textbox--%>
    <div class="product-type">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Machine Group Name" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlMachineGroup" CssClass="product-type-modify-dropdown" runat="server" DataSourceID="MachineGroupDataSource" DataTextField="machineGroup_Name" DataValueField="machineGroup_ID"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMachineGroup" ErrorMessage="Machine Group is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="MachineGroupDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>" SelectCommand="SELECT machineGroup_ID, machineGroup_Name FROM tbl_machineGroup"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </div>


        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Machine  Name" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtMachineName" CssClass="textBox" runat="server" Font-Size="20pt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMachineName" ErrorMessage="Machine  Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>

        <%-- Write same code block for other field machine  description--%>
        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Machine  Description" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtMachineDescription" CssClass="textBox" runat="server" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>

        <%--//Add button to save the data with same dic design--%>
         <div class="menu-item">
         <table class="item-table">
             <tr>
                 <td style="display: flex; justify-content: flex-start;">
                     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to save this machine ?');" OnClick="btnSave_Click" />
                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to cancel this machine ?');" OnClick="btnCancel_Click" />
                 </td>
             </tr>
         </table>
     </div>




        <%--//add grid view to show the data with same design--%>



             <div class="menu-item-datalist" style="overflow: scroll">
         <asp:Panel ID="Machine_List_Panel" runat="server" ingText="Machine  List">


             <asp:GridView ID="gvMachine" runat="server" DataKeyNames="machine_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvMachine_PreRender">
                 <Columns>

                     <asp:BoundField DataField="machine_ID" HeaderText="Machine ID" ReadOnly="true" />      
                      <asp:BoundField DataField="machineGroup_Name" HeaderText="Machine Group Name" ReadOnly="true" />
                     <asp:BoundField DataField="machine_Name" HeaderText="Machine Name" ReadOnly="true" />                                        
                     <asp:BoundField DataField="machine_Description" HeaderText="Machine Description" ReadOnly="true" />

                 </Columns>

             </asp:GridView>


         </asp:Panel>

     </div>
    </div>


    <script type="text/javascript">

     function pageLoad() {
         createDataTable();
     };


     function createDataTable() {
         var table = $('#<%=gvMachine.ClientID%>').DataTable(
             {
                 bLengthChange: true,
                 lengthMenu: [[20, 30, 50, -1], [20, 30, 50, "All"]],
                 bFilter: true,
                 bSort: true,
                 bPaginate: true,
                 retrieve: true,
                 stateSave: false,
                 order: [[1, 'asc']],

             });

        }

 </script>

    <%--//add a script tag to make ddl searchable--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=ddlMachineGroup.ClientID%>').chosen();
        });
    </script>

</asp:Content>
