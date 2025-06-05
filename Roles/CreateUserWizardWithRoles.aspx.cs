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
using System.Diagnostics;
using System.Collections.Generic;


namespace polymer_Web_ERP_V4.Roles
{
    public partial class CreateUserWizardWithRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Reference the SpecifyRolesStep WizardStep
                WizardStep SpecifyRolesStep = RegisterUserWithRoles.FindControl("SpecifyRolesStep") as WizardStep;

                // Reference the RoleList CheckBoxList
                CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

                // Bind the set of roles to RoleList
                RoleList.DataSource = System.Web.Security.Roles.GetAllRoles();
                RoleList.DataBind();
            }
        }

        protected void RegisterUserWithRoles_ActiveStepChanged(object sender, EventArgs e)
        {

            //Import the System.Diagnostics namespace at the beginning of your code file:
            //Insert the debugging statement within your code
            //In Visual Studio, go to "View" > "Output"
            //"Output\" window. Look for the line that starts with \"Active Step Title:\" to see the title of the active step."

            Debug.WriteLine("Active Step Title: " + RegisterUserWithRoles.ActiveStep.Title);

            // Have we JUST reached the Complete step?
            if (string.Equals(RegisterUserWithRoles.ActiveStep.Title.Trim(), "Complete", StringComparison.CurrentCultureIgnoreCase))

            {
                // Reference the SpecifyRolesStep WizardStep
                WizardStep SpecifyRolesStep = RegisterUserWithRoles.FindControl("SpecifyRolesStep") as WizardStep;

                // Reference the RoleList CheckBoxList
                CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

                // Add the checked roles to the just-added user
                foreach (ListItem li in RoleList.Items)
                {
                    if (li.Selected)
                        System.Web.Security.Roles.AddUserToRole(RegisterUserWithRoles.UserName, li.Text);
                }
            }
        }
    }
}