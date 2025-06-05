﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4.Membership
{
    public partial class Guestbook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            
           

        }

        protected void PostCommentButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            // Determine the currently logged on user's UserId
            MembershipUser currentUser = System.Web.Security.Membership.GetUser();
            Guid currentUserId = (Guid)currentUser.ProviderUserKey;

            // Insert a new record into GuestbookComments
            string connectionString = ConfigurationManager.ConnectionStrings["polymerConnectionString"].ConnectionString;
                 
            string insertSql = "INSERT INTO tbl_dailyNotice(notice_Subject, notice_Body, UserId) VALUES(@Subject,@Body, @UserId)";



            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
                myCommand.Parameters.AddWithValue("@Subject", Subject.Text.Trim());
                myCommand.Parameters.AddWithValue("@Body", Body.Text.Trim());
                myCommand.Parameters.AddWithValue("@UserId", currentUserId);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }

            // "Reset" the Subject and Body TextBoxes
            Subject.Text = string.Empty;
            Body.Text = string.Empty;


            //CommentList.DataBind();

        }

    }
}