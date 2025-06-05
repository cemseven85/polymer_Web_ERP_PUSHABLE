using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4.Membership
{
    public partial class ResetUserPassword : System.Web.UI.Page
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

        protected void ResetUserPasswordButton_Click(object sender, EventArgs e)
        {
            string username = UserList.SelectedValue;

            MembershipUser user = System.Web.Security.Membership.GetUser(username);

            if(user != null)
{
                // Reset the password and get the new password
                string newPassword = user.ResetPassword();

                //Pull users new password  

                string newUserPassword = NewPassWordTextBox.Text;

                // Update the user's password (you can also prompt the user to set a new password)
                user.ChangePassword(newPassword, newUserPassword); // Replace with the desired new password


                // Password successfully Reset

                Response.Write("<script type=\"text/javascript\">alert('Password successfully Reset');</script>");


                NewPassWordTextBox.Text = string.Empty;

            }

            // Bind the users 
            BindUsersToUserList();

        }
    }
}