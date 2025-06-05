<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdditionalUserInfo.aspx.cs" Inherits="polymer_Web_ERP_V4.Membership.AdditionalUserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:DetailsView ID="UserProfile" runat="server" 
        AutoGenerateRows="False" DataKeyNames="UserId" 
        DataSourceID="UserProfileDataSource"  DefaultMode="Edit"
        onitemupdated="UserProfile_ItemUpdated">
       <Fields>
            <asp:BoundField DataField="HomeTown" HeaderText="HomeTown" 
                SortExpression="HomeTown" />
            <asp:BoundField DataField="HomepageUrl" HeaderText="HomepageUrl" 
                SortExpression="HomepageUrl" />
            <asp:BoundField DataField="Signature" HeaderText="Signature" 
                SortExpression="Signature" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>


   <asp:SqlDataSource ID="UserProfileDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SecurityTutorialsConnectionString %>"        
        SelectCommand="SELECT [UserId], [HomeTown], [HomepageUrl], [Signature] FROM [UserProfiles] WHERE ([UserId] = @UserId)" 
        onselecting="UserProfileDataSource_Selecting" 
        UpdateCommand="UPDATE UserProfiles SET HomeTown = @HomeTown, HomepageUrl = @HomepageUrl, Signature = @Signature WHERE UserId = @UserId">
        <SelectParameters>
            <asp:Parameter Name="UserId" Type="Object" />
        </SelectParameters>
       <UpdateParameters>
            <asp:Parameter Name="HomeTown" />
            <asp:Parameter Name="HomepageUrl" />
            <asp:Parameter Name="Signature" />
            <asp:Parameter Name="UserId" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <asp:Label ID="SettingsUpdatedMessage" runat="server"
     Text="Your settings have been updated."
     EnableViewState="false"
     Visible="false"></asp:Label>


</asp:Content>
