<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="deleteEditPartGroup.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.deleteEditPartGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="product-type">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="PartGroup_List_Panel" runat="server" GroupingText="Edit & Delete Part Group List">
                <asp:GridView ID="gvPartGroup" runat="server" DataKeyNames="partGroup_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvPartGroup_PreRender" OnRowDataBound="gvPartGroup_RowDataBound"  OnRowEditing="gvPartGroup_RowEditing" OnRowUpdating="gvPartGroup_RowUpdating" OnRowDeleting="gvPartGroup_RowDeleting" OnRowCancelingEdit="gvPartGroup_RowCancelingEdit">

                    <Columns>

                        <asp:TemplateField HeaderText="Part Group ID">
                            <ItemTemplate>
                                <asp:Label ID="lblPartGroupID" runat="server" Text='<%# Eval("partGroup_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Type">
                            <ItemTemplate>
                                <asp:Label ID="lblPartType" runat="server" Text='<%# Bind("partType_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPartType" runat="server" DataTextField="partType_Name" DataValueField="partType_ID"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Group Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPartGroupName" runat="server" Text='<%# Bind("partGroup_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPartGroup_Name" runat="server" Text='<%# Bind("partGroup_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Group Description">
                            <ItemTemplate>
                                <asp:Label ID="lblPartGroupDescription" runat="server" Text='<%# Bind("partGroup_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPartGroup_Description" runat="server" Text='<%# Bind("partGroup_Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this part group?');" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" OnClientClick="return confirm('Are you sure you want to update this part group?');" />
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
            $('#<%=gvPartGroup.ClientID %>').DataTable();
        });

    </script>



</asp:Content>
