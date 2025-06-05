<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserBasedAuthorization.aspx.cs" Inherits="polymer_Web_ERP_V4.Membership.UserBasedAuthorization" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>User-Based Authorization</h2>


    <%--LoginView control is useful for displaying different interfaces for authenticated and anonymous users, 
    and offers an easy way to hide functionality that is not accessible to anonymous users. --%>

    <asp:LoginView ID="LoginViewForFileContentsTextBox" runat="server">
        <LoggedInTemplate>
            <asp:TextBox ID="FileContents" runat="server" Rows="10"
                TextMode="MultiLine" Width="95%"></asp:TextBox>
        </LoggedInTemplate>
    </asp:LoginView>


    <%--convert the GridView field into a TemplateField. This will generate a template that contains the declarative markup for the View LinkButton.
    We can then add a LoginView control to the TemplateField and place the LinkButton within the LoginView's LoggedInTemplate,
    thereby hiding the View button from anonymous visitors. --%>



    <asp:GridView ID="FilesGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="FullName"
        OnSelectedIndexChanged="FilesGrid_SelectedIndexChanged" OnRowDeleting="FilesGrid_RowDeleting">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LoginView ID="LoginView1" runat="server">
                            <LoggedInTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                     CommandName="Select" Text="View"></asp:LinkButton>
                            </LoggedInTemplate>
                        </asp:LoginView>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Length" DataFormatString="{0:}" HeaderText="Size in Bytes" HtmlEncode="False" />
        </Columns>
    </asp:GridView>
</asp:Content>

