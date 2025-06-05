using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace polymer_Web_ERP_V4.Membership
{
    public partial class UserBasedAuthorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //    DirectoryInfo class to obtain a list of the files in the application's root folder. 
                //The GetFiles() method returns all of the files in the directory as an array of FileInfo objects, which is then bound to the GridView.
                //The FileInfo object has an assortment of properties, such as Name, Length, and IsReadOnly, among others. 
                //As you can see from its declarative markup, the GridView displays just the Name and Length properties.


                string appPath = Request.PhysicalApplicationPath;
                DirectoryInfo dirInfo = new DirectoryInfo(appPath);

                FileInfo[] files = dirInfo.GetFiles();

                FilesGrid.DataSource = files;
                FilesGrid.DataBind();



                //Programmatically we just allow Tito to see the Delete Button of GridView
                // Is this Tito visiting the page?
                /*
                                string userName = User.Identity.Name;
                                if (string.Compare(userName, "Tito", true) == 0)
                                    // This is Tito, SHOW the Delete column
                                    FilesGrid.Columns[1].Visible = true;
                                else
                                    // This is NOT Tito, HIDE the Delete column
                                    FilesGrid.Columns[1].Visible = false;
                */

            }
        }
        //The attribute for the SelectedIndexChanged event handler dictates that only authenticated users can execute the event handler,

        [PrincipalPermission(SecurityAction.Demand,Authenticated =true)]  
        protected void FilesGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

            //The File class is used to read the selected file's contents into a string,
            //which is then assigned to the FileContents TextBox's Text property,

            // Open the file and display it
            string fullFileName = FilesGrid.SelectedValue.ToString();
            string contents = File.ReadAllText(fullFileName);
            //FileContents.Text = contents;  // !!!!  After attaching this text box in to LogInView CodeBehind can not see the text box. 
            // If you want to reach a text box which is in LogIn View.  Use this code



            TextBox FileContentsTextBox = LoginViewForFileContentsTextBox.FindControl("FileContents") as TextBox;
            FileContentsTextBox.Text = contents;



        }



        //The attribute on the RowDeleting event handler limits the execution to Tito.


        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        protected void FilesGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                //PrincipalPermission permission = new PrincipalPermission(null, "Cem");
                //permission.Demand();
                
                string fullFileName = FilesGrid.DataKeys[e.RowIndex].Value.ToString();

            TextBox FileContentsTextBox = LoginViewForFileContentsTextBox.FindControl("FileContents") as TextBox;
            FileContentsTextBox.Text = string.Format("You have opted to delete {0}.", fullFileName);


            // To actually delete the file, uncomment the following line
            // File.Delete(fullFileName);
}
            catch (SecurityException ex)
            {
                // Handle the security exception (e.g., log, display an error message, etc.)
                // You can customize this part based on your application's requirements
                // For now, let's rethrow the exception:


                //Response.Redirect("~/UnauthorizedAccess.aspx");

                throw;
            }

        }


    }
}