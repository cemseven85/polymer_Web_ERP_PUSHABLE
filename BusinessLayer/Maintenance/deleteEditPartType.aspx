<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="deleteEditPartType.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.deleteEditPartType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="menu-item-datalist" style="overflow: scroll">


            <asp:Panel ID="PartType_List_Panel" runat="server" GroupingText="Edit & Delete Part Type List">

                <asp:GridView ID="gvPartType" runat="server" DataKeyNames="partType_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvPartType_PreRender" OnRowCancelingEdit="gvPartType_RowCancelingEdit" OnRowDeleting="gvPartType_RowDeleting" OnRowUpdating="gvPartType_RowUpdating" OnRowEditing="gvPartType_RowEditing">
                    <Columns>

                        <asp:TemplateField HeaderText="Part Type ID">
                            <ItemTemplate>
                                <asp:Label ID="lblPartType_ID" runat="server" Text='<%# Bind("partType_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Type Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPartTypeName" runat="server" Text='<%# Bind("partType_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPartType_Name" runat="server" Text='<%# Bind("partType_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Part Type Description">
                            <ItemTemplate>
                                <asp:Label ID="lblPartTypeDescription" runat="server" Text='<%# Bind("partType_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPartType_Description" runat="server" Text='<%# Bind("partType_Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
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
            $('#<%=gvPartType.ClientID %>').DataTable();
        });
    </script>





</asp:Content>
