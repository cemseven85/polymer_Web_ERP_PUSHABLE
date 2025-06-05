using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4.Roles
{
    public partial class RoleBasedAuthorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindUserGrid();
        }

        private void BindUserGrid()
        {
            MembershipUserCollection allUsers = System.Web.Security.Membership.GetAllUsers();
            UserGrid.DataSource = allUsers;
            UserGrid.DataBind();
        }

        protected void UserGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the grid's EditIndex and rebind the data

            UserGrid.EditIndex = e.NewEditIndex;
            BindUserGrid();
        }

        protected void UserGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Revert the grid's EditIndex to -1 and rebind the data
            UserGrid.EditIndex = -1;
            BindUserGrid();
        }



        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Supervisor")]
        protected void UserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Exit if the page is not valid
            if (!Page.IsValid)
                return;

            // Determine the username of the user we are editing
            string UserName = UserGrid.DataKeys[e.RowIndex].Value.ToString();

            // Read in the entered information and update the user
            TextBox EmailTextBox = UserGrid.Rows[e.RowIndex].FindControl("Email") as TextBox;
            TextBox CommentTextBox = UserGrid.Rows[e.RowIndex].FindControl("Comment") as TextBox;

            // Return information about the user
            MembershipUser UserInfo = System.Web.Security.Membership.GetUser(UserName);

            // Update the User account information
            UserInfo.Email = EmailTextBox.Text.Trim();
            UserInfo.Comment = CommentTextBox.Text.Trim();

            System.Web.Security.Membership.UpdateUser(UserInfo);

            // Revert the grid's EditIndex to -1 and rebind the data
            UserGrid.EditIndex = -1;
            BindUserGrid();
        }


        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        protected void UserGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Determine the username of the user we are editing
            string UserName = UserGrid.DataKeys[e.RowIndex].Value.ToString();

            // Delete the user
            System.Web.Security.Membership.DeleteUser(UserName);

            // Revert the grid's EditIndex to -1 and rebind the data
            UserGrid.EditIndex = -1;
            BindUserGrid();
        }



        //Whenever data is bound to the GridView, 
        // the GridView enumerates the records in its DataSource property and generates a corresponding GridViewRow object. 
        // As each GridViewRow object is created, the RowCreated event is fired. In order to hide the Edit and Delete buttons for unauthorized users, 
        //we need to create an event handler for this event and programmatically reference the Edit and Delete LinkButtons, 
        // setting their Visible properties accordingly.


        //Keep in mind that the RowCreated event fires for all of the GridView rows, including the header, the footer, the pager interface, and so forth.
        //We only want to programmatically reference the Edit and Delete LinkButtons if we are dealing with a data row not in edit mode(since the row in edit mode has Update and Cancel buttons instead of Edit and Delete). 
        //This check is handled by the if statement.


        protected void UserGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != UserGrid.EditIndex)
            {
                // Programmatically reference the Edit and Delete LinkButtons
                LinkButton EditButton = e.Row.FindControl("EditButton") as LinkButton;

                LinkButton DeleteButton = e.Row.FindControl("DeleteButton") as LinkButton;

                EditButton.Visible = (User.IsInRole("Administrators") || User.IsInRole("Supervisor"));
                DeleteButton.Visible = User.IsInRole("Administrators");
            }
        }

    }
}