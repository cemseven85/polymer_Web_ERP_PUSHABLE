<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listMachine.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.listMachine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="product-type">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Machine_List_Panel" runat="server" GroupingText="Edit & Delete Machine List">
                <asp:GridView ID="gvMachine" runat="server" DataKeyNames="machine_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvMachine_PreRender">

                    <columns>

                        <asp:TemplateField HeaderText="Machine ID">
                            <itemtemplate>
                                <asp:Label ID="lblMachineID" runat="server" Text='<%# Eval("machine_ID") %>'></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine Group">
                            <itemtemplate>
                                <asp:Label ID="lblMachineGroup" runat="server" Text='<%# Bind("machineGroup_Name") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:DropDownList ID="ddlMachineGroup" runat="server" DataTextField="machineGroup_Name" DataValueField="machineGroup_ID"></asp:DropDownList>
                            </edititemtemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Machine Name">
                            <itemtemplate>
                                <asp:Label ID="lblMachineName" runat="server" Text='<%# Bind("machine_Name") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:TextBox ID="txtMachine_Name" runat="server" Text='<%# Bind("machine_Name") %>'></asp:TextBox>
                            </edititemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine Description">
                            <itemtemplate>
                                <asp:Label ID="lblMachineDescription" runat="server" Text='<%# Bind("machine_Description") %>'></asp:Label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:TextBox ID="txtMachine_Description" runat="server" Text='<%# Bind("machine_Description") %>'></asp:TextBox>
                            </edititemtemplate>
                        </asp:TemplateField>


                    </columns>
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
