<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="addPartType.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.addPartType" %>
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
                        <asp:Label ID="Label1" runat="server" Text="Part Type Name" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPartTypeName" CssClass="textBox" runat="server" Font-Size="20pt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartTypeName" ErrorMessage="Part Type Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>

        <%-- Write same code block for other field part type description--%>
        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Part Type Description" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPartTypeDescription" CssClass="textBox" runat="server" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>

        <%--//Add button to save the data with same dic design--%>
        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td style="display: flex; justify-content: flex-start;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to save this part type?');" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to cancel this part type?');" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>

       


        <%--//add grid view to show the data with same design--%>



        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="PartType_List_Panel" runat="server" GroupingText="Part Type List">


                <asp:GridView ID="gvPartType" runat="server" DataKeyNames="partType_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvPartType_PreRender">
                    <Columns>

                        <asp:BoundField DataField="partType_ID" HeaderText="Part Type ID" ReadOnly="true" />
                        <asp:BoundField DataField="partType_Name" HeaderText="Part Type Name" ReadOnly="true" />
                        <asp:BoundField DataField="partType_Description" HeaderText="Part Type Description" ReadOnly="true" />

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
            var table = $('#<%=gvPartType.ClientID%>').DataTable(
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



</asp:Content>
