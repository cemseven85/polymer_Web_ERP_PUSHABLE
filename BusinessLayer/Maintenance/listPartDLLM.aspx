<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listPartDLLM.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.listPartDLLM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-type">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <!-- Part Details List -->
        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Part_List_Panel" runat="server" GroupingText="Part Detail List">
                <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
                

                <asp:GridView ID="gvPart" runat="server" DataKeyNames="part_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvPart_PreRender">
                    <Columns>
                        <asp:TemplateField HeaderText="Part ID">
                            <ItemTemplate>
                                <asp:Label ID="lblPart_ID" runat="server" Text='<%# Bind("part_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Machine Group">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineGroup" runat="server" Text='<%# Bind("machineGroup_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Machine Name">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineID" runat="server" Text='<%# Bind("machine_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Part Type">
                            <ItemTemplate>
                                <asp:Label ID="lblPartType" runat="server" Text='<%# Bind("partType_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Part Group">
                            <ItemTemplate>
                                <asp:Label ID="lblPartGroupID" runat="server" Text='<%# Bind("partGroup_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Part Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPartName" runat="server" Text='<%# Bind("part_Name") %>' Style="background-color: lightgreen; font-weight: bold;"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Part Code">
                            <ItemTemplate>
                                <asp:Label ID="lblPartCode" runat="server" Text='<%# Bind("part_Code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Barcode">
                            <ItemTemplate>
                                <asp:Label ID="lblBarcode" runat="server" Text='<%# Bind("part_BarCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Part Description">
                            <ItemTemplate>
                                <asp:Label ID="lblPartDescription" runat="server" Text='<%# Bind("part_Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
