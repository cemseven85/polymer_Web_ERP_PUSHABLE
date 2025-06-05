using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4.Membership
{
    public partial class DeleteUserAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Bind the users 
                BindUsersToUserList();

            }
        }

        private void BindUsersToUserList()
        {
            // Get all of the user accounts 
            MembershipUserCollection users = System.Web.Security.Membership.GetAllUsers();
            UserList.DataSource = users;
            UserList.DataBind();
        }

        protected void DeleteUserButton_Click(object sender, EventArgs e)
        {
            string usernameToDelete = UserList.SelectedValue;

            try
            {
                // Delete the user
                bool isDeleted = System.Web.Security.Membership.DeleteUser(usernameToDelete, true); // Set the second parameter to true for deleting related data (e.g., user profile)

                if (isDeleted)
                {
                    // User successfully deleted
                    
                    Response.Write("<script type=\"text/javascript\">alert('User has been deleted.');</script>");

                }
                else
                {
                    // User not found or unable to delete
                    
                    Response.Write("<script type=\"text/javascript\">alert('User could not be deleted.');</script>");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., user not found, database error)
                Console.WriteLine($"Error deleting user '{usernameToDelete}': {ex.Message}");
            }

            BindUsersToUserList();
        }
    }
}