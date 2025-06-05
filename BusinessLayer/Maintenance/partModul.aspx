<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="partModul.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.partModul" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <!-- Add Part -->
        <div class="menu-item">
            <table class="item-table">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Machine Name" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlMachineID" runat="server" DataSourceID="dsMachine" DataValueField="machine_ID" DataTextField="machine_Name"></asp:DropDownList>
                        <asp:SqlDataSource ID="dsMachine" runat="server" ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>" SelectCommand="SELECT machine_ID, machine_Name FROM tbl_machine"></asp:SqlDataSource>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMachineID" ErrorMessage="Machine ID is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Part Group Name" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlPartGroupID" runat="server" DataSourceID="dsPartGroup" DataValueField="partGroup_ID" DataTextField="partGroup_Name"></asp:DropDownList>
                        <asp:SqlDataSource ID="dsPartGroup" runat="server" ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>" SelectCommand="SELECT partGroup_ID, partGroup_Name FROM tbl_partGroup"></asp:SqlDataSource>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPartGroupID" ErrorMessage="Part Group ID is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Part Name" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPartName" CssClass="textBox" runat="server" Font-Size="20pt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartName" ErrorMessage="Part Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Part Description" Font-Size="20pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPartDescription" CssClass="textBox" runat="server" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="display: flex; justify-content: flex-start;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to save this part?');" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to cancel this part?');" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <!-- Edit & Delete Part List -->
        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Part_List_Panel" runat="server" GroupingText="Edit & Delete Part List">
                <asp:GridView ID="gvPart" runat="server" DataKeyNames="part_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false"  OnPreRender="gvPart_PreRender" OnRowEditing="gvPart_RowEditing" OnRowCancelingEdit="gvPart_RowCancelingEdit" OnRowUpdating="gvPart_RowUpdatig" OnRowDataBound="gvPart_RowDataBound" OnRowDeleting="gvPart_RowDeleting" > 
                    <columns>
                        <asp:TemplateField HeaderText="Part ID">
                            <itemtemplate>
                                <asp:Label ID="lblPart_ID" runat="server" Text='<%# Bind("part_ID") %>'></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Name">
                            <itemtemplate>
                                <asp:Label ID="lblPartName" runat="server" Text='<%# Bind("part_Name") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:TextBox ID="txtPart_Name" runat="server" Text='<%# Bind("part_Name") %>'></asp:TextBox>
                            </edititemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Description">
                            <itemtemplate>
                                <asp:Label ID="lblPartDescription" runat="server" Text='<%# Bind("part_Description") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:TextBox ID="txtPart_Description" runat="server" Text='<%# Bind("part_Description") %>'></asp:TextBox>
                            </edititemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine ID">
                            <itemtemplate>
                                <asp:Label ID="lblMachineID" runat="server" Text='<%# Bind("machine_Name") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:DropDownList ID="ddlMachine_ID" runat="server" DataTextField="machine_Name" DataValueField="machine_ID"></asp:DropDownList>
                            </edititemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Group ID">
                            <itemtemplate>
                                <asp:Label ID="lblPartGroupID" runat="server" Text='<%# Bind("partGroup_Name") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:DropDownList ID="ddlPartGroup_ID" runat="server" DataTextField="partGroup_Name" DataValueField="partGroup_ID"></asp:DropDownList>
                            </edititemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <itemtemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit"  CausesValidation="false"  />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete"  CausesValidation="false"  OnClientClick="return confirm('Are you sure you want to delete this part?');" />
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update"  CausesValidation="false"  OnClientClick="return confirm('Are you sure you want to update this part?');" />
                                <asp:Button ID="Button1" runat="server" Text="Cancel" CommandName="Cancel"  CausesValidation="false"  />
                            </edititemtemplate>
                        </asp:TemplateField>
                    </columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvPart.ClientID %>').DataTable();
        });
</script>



</asp:Content>
