<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="deleteEditMachine.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.deleteEditMachine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Machine_List_Panel" runat="server" GroupingText="Edit & Delete Machine List">
                <asp:GridView ID="gvMachine" runat="server" DataKeyNames="machine_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvMachine_PreRender" OnRowEditing="gvMachine_RowEditing" OnRowDataBound="gvMachine_RowDataBound" OnRowUpdating="gvMachine_RowUpdating" OnRowDeleting="gvMachine_RowDeleting" OnRowCancelingEdit="gvMachine_RowCancelingEdit">

                    <Columns>

                        <asp:TemplateField HeaderText="Machine ID">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineID" runat="server" Text='<%# Eval("machine_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine Group">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineGroup" runat="server" Text='<%# Bind("machineGroup_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlMachineGroup" runat="server" DataTextField="machineGroup_Name" DataValueField="machineGroup_ID"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine Name">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineName" runat="server" Text='<%# Bind("machine_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMachine_Name" runat="server" Text='<%# Bind("machine_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine Description">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineDescription" runat="server" Text='<%# Bind("machine_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMachine_Description" runat="server" Text='<%# Bind("machine_Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <%-- <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />--%>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this machine?');" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" OnClientClick="return confirm('Are you sure you want to update this machine?');" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                            </EditItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvMachine.ClientID %>').DataTable();
        });

    </script>

</asp:Content>
