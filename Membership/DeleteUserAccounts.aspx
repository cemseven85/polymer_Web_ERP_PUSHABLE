<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteUserAccounts.aspx.cs" Inherits="polymer_Web_ERP_V4.Membership.DeleteUserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h2>Delete a User Account</h2>

     <p>
        <b>Select a User:</b>

        <%--This DropDownList will be bound to a collection of MembershipUser objects.
        Because we want the DropDownList to display the UserName property of the MembershipUser object (and use it as the value of the list items), 
        set the DropDownList's DataTextField and DataValueField properties to "UserName".--%>

        <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True"
            DataTextField="UserName" DataValueField="UserName" >
        </asp:DropDownList>
    </p>
     <br /> 
     <asp:Button ID="DeleteUserButton" runat="server" Text="Delete User" OnClick="DeleteUserButton_Click" /> 

</asp:Content>
