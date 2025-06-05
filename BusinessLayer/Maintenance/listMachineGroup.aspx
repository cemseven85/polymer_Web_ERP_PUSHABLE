<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listMachineGroup.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.ListMachineGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="product-type">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="MachineGroup_List_Panel" runat="server" GroupingText="Machine Group List">

                <asp:GridView ID="gvMachineGroup" runat="server" DataKeyNames="machineGroup_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvMachineGroup_PreRender" >
                    <Columns>

                        <asp:TemplateField HeaderText="Machine Group ID">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineGroup_ID" runat="server" Text='<%# Bind("machineGroup_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine Group Name">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineGroupName" runat="server" Text='<%# Bind("machineGroup_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMachineGroup_Name" runat="server" Text='<%# Bind("machineGroup_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Machine Group Description">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineGroupDescription" runat="server" Text='<%# Bind("machineGroup_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMachineGroup_Description" runat="server" Text='<%# Bind("machineGroup_Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                      

                    </Columns>

                </asp:GridView>
                
                <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />
            </asp:Panel>

        </div>

    </div>



    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvMachineGroup.ClientID %>').DataTable();
        });
    </script>

  


</asp:Content>
