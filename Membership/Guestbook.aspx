<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Guestbook.aspx.cs" Inherits="polymer_Web_ERP_V4.Membership.Guestbook"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Leave a Comment</h3>
    <p>
        <b>Subject:</b>
        <asp:RequiredFieldValidator ID="SubjectReqValidator" runat="server"
            ErrorMessage="You must provide a value for Subject"
            ControlToValidate="Subject" ValidationGroup="EnterComment">
        </asp:RequiredFieldValidator><br />
        <asp:TextBox ID="Subject" Columns="40" runat="server"></asp:TextBox>
    </p>
    <p>
        <b>Body:</b>
        <asp:RequiredFieldValidator ID="BodyReqValidator" runat="server"
            ControlToValidate="Body"
            ErrorMessage="You must provide a value for Body" ValidationGroup="EnterComment">
        </asp:RequiredFieldValidator><br />
        <asp:TextBox ID="Body" TextMode="MultiLine" Width="95%"
            Rows="8" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="PostCommentButton" runat="server"
            Text="Post Your Comment"
            ValidationGroup="EnterComment" OnClick="PostCommentButton_Click" />
    </p>


    <%--The ListView's layout can be constructed manually--%>


    <h3>Daily Notice</h3>
    <asp:ListView ID="CommentList" runat="server" DataSourceID="CommentsDataSource" EnableViewState="false">
        <LayoutTemplate>
            <span id="itemPlaceholder" runat="server" />

            <p>
                <asp:DataPager ID="DataPager1" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True"
                            ShowLastPageButton="True" />
                    </Fields>
                </asp:DataPager>
            </p>
        </LayoutTemplate>

        <ItemTemplate>
            <h4>
                <asp:Label ID="SubjectLabel" runat="server" Text='<%# Eval("notice_Subject") %>' /></h4>
            <asp:Label ID="BodyLabel" runat="server" Text='<%# Eval("notice_Body").ToString().Replace(Environment.NewLine, "<br />") %>' />

           <%-- <p>
                ---<br />
                <asp:Label ID="SignatureLabel" Font-Italic="true" runat="server" Text='<%# Eval("Signature") %>' />
                <br />
                <br />
                My Home Town:
                <asp:Label ID="HomeTownLabel" runat="server" Text='<%# Eval("HomeTown") %>' />
                <br />
                My Homepage:
                <asp:HyperLink ID="HomepageUrlLink" runat="server" NavigateUrl='<%# Eval("HomepageUrl") %>' Text='<%# Eval("HomepageUrl") %>' />
            </p>--%>
            <p align="center">
                Posted by 
                    <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                on
                    <asp:Label ID="CommentDateLabel" runat="server" Text='<%# Eval("notice_Date") %>' />
            </p>
        </ItemTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="CommentsDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>"
        SelectCommand="SELECT tbl_dailyNotice.notice_Subject, tbl_dailyNotice.notice_Body, tbl_dailyNotice.notice_Date,aspnet_Users.UserName FROM tbl_dailyNotice  INNER JOIN aspnet_Users ON tbl_dailyNotice.UserId = aspnet_Users.UserId ORDER BY tbl_dailyNotice.notice_Date DESC"></asp:SqlDataSource>

        
</asp:Content>

<%--Since each guestbook comment requires a subject and body, add a RequiredFieldValidator for each of the TextBoxes.
Set the ValidationGroup property of these controls to "EnterComment";
likewise, set the PostCommentButton control's ValidationGroup property to "EnterComment".--%>