<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="listPartGroup.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.listPartGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="product-type">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <div class="menu-item-datalist" style="overflow: scroll">
         <asp:Panel ID="PartGroup_List_Panel" runat="server" GroupingText="Part Group List">
             <asp:GridView ID="gvPartGroup" runat="server" DataKeyNames="partGroup_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvPartGroup_PreRender">

                 <columns>

                     <asp:TemplateField HeaderText="Part Group ID">
                         <itemtemplate>
                             <asp:Label ID="lblPartGroupID" runat="server" Text='<%# Eval("partGroup_ID") %>'></asp:Label>
                         </itemtemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Part Type">
                         <itemtemplate>
                             <asp:Label ID="lblPartType" runat="server" Text='<%# Bind("partType_Name") %>'></asp:Label>
                         </itemtemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Part Group Name">
                         <itemtemplate>
                             <asp:Label ID="lblPartGroupName" runat="server" Text='<%# Bind("partGroup_Name") %>'></asp:Label>
                         </itemtemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Part Group Description">
                         <itemtemplate>
                             <asp:Label ID="lblPartGroupDescription" runat="server" Text='<%# Bind("partGroup_Description") %>'></asp:Label>
                         </itemtemplate>
                     </asp:TemplateField>

                 </columns>
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
