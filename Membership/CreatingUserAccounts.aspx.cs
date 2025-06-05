using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace polymer_Web_ERP_V4.Membership
{
    public partial class CreatingUserAccounts : System.Web.UI.Page
    {

        // If you are working with Wizard You do not need any of these page codes.  !!!!

        //const string passwordQuestion = "What is your favorite color";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //    SecurityQuestion.Text = passwordQuestion;
        }

        //protected void CreateAccountButton_Click(object sender, EventArgs e)
        //{
        //    MembershipCreateStatus createStatus;

        //    MembershipUser newUser =
        //         System.Web.Security.Membership.CreateUser(Username.Text, Password.Text,
        //                               Email.Text, passwordQuestion,
        //                               SecurityAnswer.Text, true,
        //                               out createStatus);

        //    switch (createStatus)
        //    {
        //        case MembershipCreateStatus.Success:
        //            CreateAccountResults.Text = "The user account was successfully created!";
        //            break;

        //        case MembershipCreateStatus.DuplicateUserName:
        //            CreateAccountResults.Text = "There already exists a user with this username.";
        //            break;

        //        case MembershipCreateStatus.DuplicateEmail:
        //            CreateAccountResults.Text = "There already exists a user with this email address.";
        //            break;

        //        case MembershipCreateStatus.InvalidEmail:
        //            CreateAccountResults.Text = "There email address you provided in invalid.";
        //            break;

        //        case MembershipCreateStatus.InvalidAnswer:
        //            CreateAccountResults.Text = "There security answer was invalid.";
        //            break;

        //        case MembershipCreateStatus.InvalidPassword:
        //            CreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";
        //            break;

        //        default:
        //            CreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
        //            break;
        //    }
        //}
        
    }
}