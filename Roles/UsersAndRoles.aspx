<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersAndRoles.aspx.cs" Inherits="polymer_Web_ERP_V4.Roles.UsersAndRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>User Role Management</h2>
    <p align="center">
        <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
    </p>
    <h3>Manage Roles By User</h3>
    <p>
        <b>Select a User:</b>

        <%--This DropDownList will be bound to a collection of MembershipUser objects.
        Because we want the DropDownList to display the UserName property of the MembershipUser object (and use it as the value of the list items), 
        set the DropDownList's DataTextField and DataValueField properties to "UserName".--%>

        <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True"
            DataTextField="UserName" DataValueField="UserName" OnSelectedIndexChanged="UserList_SelectedIndexChanged">
        </asp:DropDownList>
    </p>

    <%--This Repeater will list all of the roles in the system as a series of checkboxes.
    Define the Repeater's ItemTemplate using the following declarative markup:--%>
    <%--Text property is bound to Container.DataItem. The reason the databinding syntax is simply Container.
    DataItem is because the Roles framework returns the list of role names as a string array, and it is this string array that we will be binding to the Repeater.
    A thorough description of why this syntax is used to display the contents of an array bound to a data Web control is beyond the scope of this tutorial. 
    For more information on this matter, refer to Binding a Scalar Array to a Data Web Control.--%>

    <p>
        <asp:Repeater ID="UsersRoleList" runat="server">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true" Text='<%# Container.DataItem %>' OnCheckedChanged="RoleCheckBox_CheckChanged" />
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </p>


    <h3>Manage Users By Role</h3>
    <p>
        <b>Select a Role:</b>

        <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RoleList_SelectedIndexChanged"></asp:DropDownList>
    </p>

    <p>
        <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False" EmptyDataText="No users belong to this role." OnRowDeleting="RolesUserList_RowDeleting">
            <Columns>
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
                <asp:TemplateField HeaderText="Users">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="UserNameLabel"
                            Text='<%# Container.DataItem %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
    </p>


    <p> 
     <b>UserName:</b> 
     <asp:TextBox ID="UserNameToAddToRole" runat="server"></asp:TextBox> 
     <br /> 
     <asp:Button ID="AddUserToRoleButton" runat="server" Text="Add User to Role" OnClick="AddUserToRoleButton_Click" /> 

</p>

</asp:Content>
