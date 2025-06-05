using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace polymer_Web_ERP_V4
{
    public partial class Login : System.Web.UI.Page
    {

        



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                // This is an unauthorized, authenticated request...
                Response.Redirect("~/UnauthorizedAccess.aspx");

        }



        protected void myLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //// Get the email address entered
            //TextBox EmailTextBox = myLogin.FindControl("Email") as TextBox;
            //string email = EmailTextBox.Text.Trim();

            // Verify that the username/password pair is valid
            if (System.Web.Security.Membership.ValidateUser(myLogin.UserName, myLogin.Password))
            {    

                ////This Down code is for E-Mail Valiadation but polymerERP not need this. 

                //// Username/password are valid, check email
                //MembershipUser usrInfo = System.Web.Security.Membership.GetUser(myLogin.UserName);
                //if (usrInfo != null && string.Compare(usrInfo.Email, email, true) == 0)
                //{
                //    // Email matches, the credentials are valid
                //    e.Authenticated = true;
                //}
                //else
                //{
                //    // Email address is invalid...
                //    e.Authenticated = false;
                //}

                // Upper Code Or Down Code For Without PassWord Down Code 

                

            }
            else
            {
                // Username/password are not valid...
                e.Authenticated = false;
            }
        }

        protected void myLogin_LoginError(object sender, EventArgs e)
        {
            // Determine why the user could not login...
            myLogin.FailureText = "Your login attempt was not successful. Please try again.";

            // Does there exist a User account for this user?
            MembershipUser usrInfo = System.Web.Security.Membership.GetUser(myLogin.UserName);
            if (usrInfo != null)
            {
                // Is this user locked out?
                if (usrInfo.IsLockedOut)
                {
                    myLogin.FailureText = "Your account has been locked out because of too many invalid login attempts. Please contact the administrator to have your account unlocked.";
                }
                else if (!usrInfo.IsApproved)
                {
                    //myLogin.FailureText = "Your account has not yet been approved. You cannot login until an administrator has approved your account.";
                }
            }
        }



        //protected void LoginButton_Click(object sender, EventArgs e)
        //{
        //    //// This is the code for  Validating Credentials Manually By Programaticly Not use aspnet_Membership Fream Work  

        //    //// Three valid username/password pairs: Scott/password, Jisun/password, and Sam/password.
        //    //string[] users = { "Scott", "Jisun", "Sam" };
        //    //string[] passwords = { "password", "password", "password" };
        //    //for (int i = 0; i < users.Length; i++)
        //    //{
        //    //    bool validUsername = (string.Compare(UserName.Text, users[i], true) == 0);
        //    //    bool validPassword = (string.Compare(Password.Text, passwords[i], false) == 0);
        //    //    if (validUsername && validPassword)
        //    //    {
        //    //        // TODO: Log in the user...
        //    //        // TODO: Redirect them to the appropriate page

        //    //        FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked);

        //    //        //Response.Redirect("~/BusinessLayer/main-ERP.aspx");
        //    //    }
        //    //}
        //    //// If we reach here, the user's credentials were invalid
        //    //InvalidCredentialsMessage.Visible = true;



        //    ////*This part is witout using Tools --> Login for the aspx part.While use You do not need them all

        //    //// Validate the user against the Membership framework user store
        //    //if (System.Web.Security.Membership.ValidateUser(UserName.Text, Password.Text))
        //    //{
        //    //    // Log the user into the site
        //    //    FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked);

        //    //    Response.Redirect("~/BusinessLayer/main-ERP.aspx");  // After Login Validate User Will Visit The Main Application Page. 
        //    //}
        //    //// If we reach here, the user's credentials were invalid
        //    //InvalidCredentialsMessage.Visible = true;


        //}
    }
}