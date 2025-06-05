<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="polymer_Web_ERP_V4.Login" UnobtrusiveValidationMode="None"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">       <%--//!!!!!!GEÇİCİ OLARAK LOGİN PAGE i MASTER PAGE SITE MASTER YAPTIM CONTENTLERINI ONA GÖRE AYARLADIM   !!!GERI ALDIM!!!! --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainLogin">

        <div class="login">

             <asp:Label ID="LoginHeaderLabel" runat="server" Text=" LYAS - Log In" CssClass="loginHeader"></asp:Label>
           <%-- <p>
                <asp:Label ID="UsernameLable" runat="server" Text=" Username:" CssClass="loginLable"></asp:Label>
                <asp:TextBox ID="UserName" runat="server" CssClass="loginTextBox"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PasswordLabel" runat="server" Text=" Password: " CssClass="loginLable"></asp:Label>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="loginTextBox"></asp:TextBox>
            </p>
            <p>
                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me" />
            </p>
            <p>
                <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="loginButton" OnClick="LoginButton_Click" />
            </p>
            <p>
                <asp:Label ID="InvalidCredentialsMessage" runat="server" ForeColor="Red" Text="Your username or password is invalid. Please try again."
                    Visible="False"></asp:Label>
            </p>--%>

            <asp:Login ID="myLogin" runat="server"
                UserNameLabelText="Username :" LoginButtonText="Login" 
                PasswordLabelText="Password :" TitleText="" DestinationPageUrl="~/BusinessLayer/main-ERP.aspx" >
                <LabelStyle CssClass="loginLable" />
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td align="right" class="loginLable">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username :</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="loginTextBox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="loginLable">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password :</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" CssClass="loginTextBox" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="loginButton" Text="Login" ValidationGroup="myLogin" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <LoginButtonStyle CssClass="loginButton" />
                <TextBoxStyle CssClass="loginTextBox" />
             </asp:Login>


        </div>

    </div>
</asp:Content>
