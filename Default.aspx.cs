using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                WelcomeBackMessage.Text = WelcomeBackMessage.Text = "Welcome back, " + User.Identity.Name + "!";

                AuthenticatedMessagePanel.Visible = true;
                AnonymousMessagePanel.Visible = false;
            }
            else
            {
                AuthenticatedMessagePanel.Visible = false;
                AnonymousMessagePanel.Visible = true;
            }
        }
    }
}