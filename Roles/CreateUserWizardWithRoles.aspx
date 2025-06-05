<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUserWizardWithRoles.aspx.cs" Inherits="polymer_Web_ERP_V4.Roles.CreateUserWizardWithRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create a User Account (with Roles!)</h2>

    <%--    LoginCreatedUser property to False. This LoginCreatedUser property specifies whether the visitor is automatically logged on as the just-created user,
    and it defaults to True. We set it to False because when an administrator creates a new account we want to keep him signed in as himself.--%>


    <asp:CreateUserWizard ID="RegisterUserWithRoles" runat="server" 
        ContinueDestinationPageUrl="~/Default.aspx" 
        onactivestepchanged="RegisterUserWithRoles_ActiveStepChanged" 
        LoginCreatedUser="False">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:WizardStep ID="SpecifyRolesStep" runat="server" StepType="Step" 
                Title="Specify Roles" AllowReturn="False">
                <asp:CheckBoxList ID="RoleList" runat="server">
                </asp:CheckBoxList>
            </asp:WizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
