<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addPartGroup.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.addPartGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Part Group Name" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlPartType" CssClass="product-type-modify-dropdown" runat="server" DataSourceID="PartTypeDataSource" DataTextField="partType_Name" DataValueField="partType_ID"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPartType" ErrorMessage="Part Type is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="PartTypeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>" SelectCommand="SELECT partType_ID, partType_Name FROM tbl_partType"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </div>


        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Part Group Name" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPartGroupName" CssClass="textBox" runat="server" Font-Size="20pt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartGroupName" ErrorMessage="Part Group Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>

        <%-- Write same code block for other field partGroup_Description--%>
        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Part Group Description" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPartGroupDescription" CssClass="textBox" runat="server" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>

        <%--//Add button to save the data with same dic design--%>
        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td style="display: flex; justify-content: flex-start;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to save this part group ?');" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to cancel this part group ?');" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <%--//add grid view to show the data with same design--%>

        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="PartGroup_List_Panel" runat="server" ingText="Part Group List">
                <asp:GridView ID="gvPartGroup" runat="server" DataKeyNames="partGroup_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvPartGroup_PreRender">
                    <Columns>
                        <asp:BoundField DataField="partGroup_ID" HeaderText="Part Group ID" ReadOnly="true" />
                        <asp:BoundField DataField="partType_Name" HeaderText="Part Type Name" ReadOnly="true" />
                        <asp:BoundField DataField="partGroup_Name" HeaderText="Part Group Name" ReadOnly="true" />
                        <asp:BoundField DataField="partGroup_Description" HeaderText="Part Group Description" ReadOnly="true" />


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
            var table = $('#<%=gvPartGroup.ClientID%>').DataTable(
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

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=ddlPartType.ClientID%>').chosen();
        });
    </script>


</asp:Content>
