using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace polymer_Web_ERP_V4
{
    public class Global : System.Web.HttpApplication
    {

        //    protected void Application_Start(object sender, EventArgs e)
        //    {

        //    }

        //    protected void Session_Start(object sender, EventArgs e)
        //    {

        //    }

        //    protected void Application_BeginRequest(object sender, EventArgs e)
        //    {

        //    }

        //    protected void Application_AuthenticateRequest(object sender, EventArgs e)
        //    {

        //    }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            // Check if the exception is a SecurityException
            if (ex is SecurityException)
            {
                // Handle the SecurityException here
                // For demonstration purposes, you can log the exception
                //LogException(ex);

                // Optionally, redirect the user to a custom error page
                Response.Redirect("~/Exceptions/UnauthorizedAccess.aspx",true);
            }
            //else if (ex is System.Web.HttpUnhandledException)
            //{
            //    Response.Redirect("~/Exceptions/HttpUnhandledException.aspx",true);
            //}


            //// Clear the error to prevent the error page from being displayed
            //Server.ClearError();
        }



        //    private void LogException(Exception ex)
        //    {
        //        // Log the exception to a log file, database, or any other desired location
        //        // Example logging code
        //        // LogHelper.LogException(ex);
        //    }

        //    protected void Session_End(object sender, EventArgs e)
        //    {

        //    }

        //    protected void Application_End(object sender, EventArgs e)
        //    {

        //    }
    }
}