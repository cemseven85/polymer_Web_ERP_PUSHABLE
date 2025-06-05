<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatingUserAccounts.aspx.cs" Inherits="polymer_Web_ERP_V4.Membership.CreatingUserAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create a New User Account</h2>

    <!-- Create User By Wizard No need any Code Behind  c#  -->
    <p>

        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" DisplayCancelButton="True"
            CancelButtonImageUrl="~/Default.aspx"
            ContinueDestinationPageUrl="~/Default.aspx">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="RegisterUser" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </p>

   <!-- Create User By Code  need  Code Behind  c#  -->
  <%--  <p>
        Enter a username: 
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <br />

        Choose a password:
        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
        <br />

        Enter your email address:
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <br />

        <asp:Label runat="server" ID="SecurityQuestion"></asp:Label>: 
        <asp:TextBox ID="SecurityAnswer" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="CreateAccountButton" runat="server"
            Text="Create the User Account" OnClick="CreateAccountButton_Click" />
    </p>
    <p>
        <asp:Label ID="CreateAccountResults" runat="server"></asp:Label>   
    </p>--%>





</asp:Content>

