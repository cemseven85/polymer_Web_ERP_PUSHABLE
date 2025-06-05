using polymer_Web_ERP_V4.Productivity;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Drawing;

using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;   // From Here Name Spaces Are For Exel File Transfer 
using Excel = Microsoft.Office.Interop.Excel;  //Before  Excel =   Data Tables And Exels Send Error. 
using System.Globalization;
using System.Runtime.Remoting.Metadata.W3cXsd2001;


namespace polymer_Web_ERP_V4.BusinessLayer.Maintenance
{
    public partial class partModulWImg : System.Web.UI.Page
    {   
        
        //add Data Access object with name conn
        DataAccess conn = new DataAccess();


        private bool isEditing = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT part_ID, part_Name, part_Description, machine_Name, partGroup_Name, part_Image_Path_1,part_Code,part_BarCode FROM tbl_part INNER JOIN tbl_machine ON tbl_part.machine_ID = tbl_machine.machine_ID INNER JOIN tbl_partGroup ON tbl_part.partGroup_ID = tbl_partGroup.partGroup_ID", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvPart.DataSource = dt;
                        gvPart.DataBind();
                    }
                }
            }
        }



        //write a prerender method for bind grid view
        protected void gvPart_PreRender(object sender, EventArgs e)
        {
            this.BindGrid();

            // Configure GridView structure
            if (gvPart.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvPart.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                gvPart.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                gvPart.FooterRow.TableSection = TableRowSection.TableFooter;



            }


            if (isEditing)
            {
                for (int i = 0; i < gvPart.Rows.Count; i++)
                {
                    if (i != gvPart.EditIndex)
                    {
                        gvPart.Rows[i].Visible = false;
                    }
                }
            }


        }

        protected void ddlMachineGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsMachine.Select(DataSourceSelectArguments.Empty);
            ddlMachineID.DataBind();
        }

        protected void ddlPartTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsPartGroup.Select(DataSourceSelectArguments.Empty);
            ddlPartGroupID.DataBind();
        }



        //Write code for save button click event with using statements for data base connection and sql command
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_part (part_Name, part_Description, machine_ID, partGroup_ID,part_Code,part_BarCode) VALUES (@part_Name, @part_Description, @machine_ID, @partGroup_ID,@part_Code,@part_BarCode)", con))
                {
                    cmd.Parameters.AddWithValue("@part_Name", txtPartName.Text);
                    cmd.Parameters.AddWithValue("@part_Description", txtPartDescription.Text);
                    cmd.Parameters.AddWithValue("@machine_ID", ddlMachineID.SelectedValue);
                    cmd.Parameters.AddWithValue("@partGroup_ID", ddlPartGroupID.SelectedValue);
                    cmd.Parameters.AddWithValue("@part_Code", txtPartCode.Text);
                   cmd.Parameters.AddWithValue("@part_BarCode", txtPartBarCode.Text);
                    cmd.ExecuteNonQuery();
                    this.BindGrid();
                }
            }

            // Add the image to the data base
            if (fuPartImage_1.HasFile)
            {
                string fileName = Path.GetFileName(fuPartImage_1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fuPartImage_1.PostedFile.FileName);
                string fileLocation = "~/Images/" + fileName;
                fuPartImage_1.SaveAs(Server.MapPath(fileLocation));

                using (SqlConnection con = conn.Connection())
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tbl_part SET part_Image_Path_1 = @part_Image WHERE part_Name = @part_Name", con))
                    {
                        cmd.Parameters.AddWithValue("@part_Image", fileLocation);
                        cmd.Parameters.AddWithValue("@part_Name", txtPartName.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            
            //add image to the data base fuPartImage_2
            if (fuPartImage_2.HasFile)
            {
                string fileName = Path.GetFileName(fuPartImage_2.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fuPartImage_2.PostedFile.FileName);
                string fileLocation = "~/Images/" + fileName;
                fuPartImage_2.SaveAs(Server.MapPath(fileLocation));

                using (SqlConnection con = conn.Connection())
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tbl_part SET part_Image_Path_2 = @part_Image WHERE part_Name = @part_Name", con))
                    {
                        cmd.Parameters.AddWithValue("@part_Image", fileLocation);
                        cmd.Parameters.AddWithValue("@part_Name", txtPartName.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            //add image to the data base fuPartImage_3
            if (fuPartImage_3.HasFile)
            {
                string fileName = Path.GetFileName(fuPartImage_3.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fuPartImage_3.PostedFile.FileName);
                string fileLocation = "~/Images/" + fileName;
                fuPartImage_3.SaveAs(Server.MapPath(fileLocation));

                using (SqlConnection con = conn.Connection())
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tbl_part SET part_Image_Path_3 = @part_Image WHERE part_Name = @part_Name", con))
                    {
                        cmd.Parameters.AddWithValue("@part_Image", fileLocation);
                        cmd.Parameters.AddWithValue("@part_Name", txtPartName.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            //add image to the data base fuPartImage_4
            if (fuPartImage_4.HasFile)
            {
                string fileName = Path.GetFileName(fuPartImage_4.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fuPartImage_4.PostedFile.FileName);
                string fileLocation = "~/Images/" + fileName;
                fuPartImage_4.SaveAs(Server.MapPath(fileLocation));

                using (SqlConnection con = conn.Connection())
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tbl_part SET part_Image_Path_4 = @part_Image WHERE part_Name = @part_Name", con))
                    {
                        cmd.Parameters.AddWithValue("@part_Image", fileLocation);
                        cmd.Parameters.AddWithValue("@part_Name", txtPartName.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            //add image to the data base fuPartImage_5
            if (fuPartImage_5.HasFile)
            {
                string fileName = Path.GetFileName(fuPartImage_5.PostedFile.FileName);
                string fileExtension = Path.GetExtension(fuPartImage_5.PostedFile.FileName);
                string fileLocation = "~/Images/" + fileName;
                fuPartImage_5.SaveAs(Server.MapPath(fileLocation));

                using (SqlConnection con = conn.Connection())
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tbl_part SET part_Image_Path_5 = @part_Image WHERE part_Name = @part_Name", con))
                    {
                        cmd.Parameters.AddWithValue("@part_Image", fileLocation);
                        cmd.Parameters.AddWithValue("@part_Name", txtPartName.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }







        }




        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload1.HasFile)
        //    {
        //        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //        string folderPath = Server.MapPath("~/Images/");
        //        string filePath = folderPath + fileName;

        //        // Save the file to the server
        //        FileUpload1.SaveAs(filePath);

        //        // Display a success message
        //        Response.Write("File uploaded successfully.");
        //    }
        //    else
        //    {
        //        // Display an error message
        //        Response.Write("Please select a file to upload.");
        //    }
        //}


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string folderPath = Server.MapPath("~/Images/");
                string filePath = folderPath + fileName;

                // Create a Bitmap from the uploaded file
                Bitmap originalBMP = new Bitmap(FileUpload1.PostedFile.InputStream);

                // Calculate the new image dimensions
                int origWidth = originalBMP.Width;
                int origHeight = originalBMP.Height;
                int sngRatio = origWidth / origHeight;
                int newWidth = 640;
                int newHeight = newWidth / sngRatio;

                // Create a new bitmap which will hold the previous resized bitmap
                Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

                // Create a graphic based on the new bitmap
                Graphics oGraphics = Graphics.FromImage(newBMP);

                // Set the properties for the new graphic file
                oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Draw the new graphic based on the resized bitmap
                oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);

                // Save the new graphic file to the server
                newBMP.Save(filePath);

                // Once finished with the bitmap objects, we deallocate them.
                originalBMP.Dispose();
                newBMP.Dispose();
                oGraphics.Dispose();

                // Display a success message
                Response.Write("File uploaded successfully.");
            }
            else
            {
                // Display an error message
                Response.Write("Please select a file to upload.");
            }
        }







        //write code for cancel button click event
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPartName.Text = string.Empty;
            txtPartDescription.Text = string.Empty;
            ddlMachineID.SelectedIndex = 0;
            ddlPartGroupID.SelectedIndex = 0;
        }

        //code for gridview row editing event with using statements for data base connection and sql command
        protected void gvPart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPart.EditIndex = e.NewEditIndex;
            this.BindGrid();
            isEditing = true;

            // Hide all rows except the one being edited
            for (int i = 0; i < gvPart.Rows.Count; i++)
            {
                if (i != e.NewEditIndex)
                {
                    gvPart.Rows[i].Visible = false;
                }
            }


        }

        //Wite a function to get machine from database
        private DataTable GetMachine()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT machine_ID, machine_Name FROM tbl_machine", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }



        // Write a function to get machine ID based on machine name
        private int GetMachineID(string machineName)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT machine_ID FROM tbl_machine WHERE machine_Name = @machineName", con))
                {
                    cmd.Parameters.AddWithValue("@machineName", machineName);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }




        //Wite a function to get partGroup from database
        private DataTable GetPartGroup()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT partGroup_ID, partGroup_Name FROM tbl_partGroup", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }



        // Write a function to get partGroup ID based on partGroup name
        private int GetPartGroupID(string partGroupName)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT partGroup_ID FROM tbl_partGroup WHERE partGroup_Name = @partGroupName", con))
                {
                    cmd.Parameters.AddWithValue("@partGroupName", partGroupName);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }



        //code for rowdatabound event of grid view with using statements for data base connection and sql command
        protected void gvPart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvPart.EditIndex == e.Row.RowIndex)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    // Get the DropDownList control from the row in edit mode
                    DropDownList ddlMachineID = (DropDownList)e.Row.FindControl("ddlMachine_ID");
                    DropDownList ddlPartGroupID = (DropDownList)e.Row.FindControl("ddlPartGroup_ID");

                    // Populate the DropDownList with machine names
                    ddlMachineID.DataSource = GetMachine(); // Function to get machine groups from database
                    ddlMachineID.DataTextField = "machine_Name";
                    ddlMachineID.DataValueField = "machine_ID";
                    ddlMachineID.DataBind();

                    // Set the selected value of the DropDownList to the current machine
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    string machineName = dr["machine_Name"].ToString();

                    // Find the corresponding machine_ID based on the machineName
                    int machineID = GetMachineID(machineName);

                    // Set the selected value of the DropDownList to the machine_ID
                    ddlMachineID.SelectedValue = machineID.ToString();

                    // Populate the DropDownList with partGroup names
                    ddlPartGroupID.DataSource = GetPartGroup(); // Function to get machine groups from database
                    ddlPartGroupID.DataTextField = "partGroup_Name";
                    ddlPartGroupID.DataValueField = "partGroup_ID";
                    ddlPartGroupID.DataBind();

                    // Set the selected value of the DropDownList to the current partGroup
                    string partGroupName = dr["partGroup_Name"].ToString();

                    // Find the corresponding partGroup_ID based on the partGroupName
                    int partGroupID = GetPartGroupID(partGroupName);

                    // Set the selected value of the DropDownList to the partGroup_ID
                    ddlPartGroupID.SelectedValue = partGroupID.ToString();

                }
            }
        }


        //code for row edit cancel event with using statements for data base connection and sql command
        protected void gvPart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPart.EditIndex = -1;
            this.BindGrid();
            isEditing = false;

            // Make all rows visible again
            foreach (GridViewRow row in gvPart.Rows)
            {
                row.Visible = true;
            }
        }




        //code for row updating event with using statements for data base connection and sql command
        protected void gvPart_RowUpdatig(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_part SET part_Name = @part_Name, part_Description = @part_Description, machine_ID = @machine_ID, partGroup_ID = @partGroup_ID, part_Code = @part_Code, part_BarCode = @part_BarCode WHERE part_ID = @part_ID", con))
                {
                    cmd.Parameters.AddWithValue("@part_Name", (gvPart.Rows[e.RowIndex].FindControl("txtPart_Name") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@part_Description", (gvPart.Rows[e.RowIndex].FindControl("txtPart_Description") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@machine_ID", (gvPart.Rows[e.RowIndex].FindControl("ddlMachine_ID") as DropDownList).SelectedValue);
                    cmd.Parameters.AddWithValue("@partGroup_ID", (gvPart.Rows[e.RowIndex].FindControl("ddlPartGroup_ID") as DropDownList).SelectedValue);
                    cmd.Parameters.AddWithValue("@part_Code", (gvPart.Rows[e.RowIndex].FindControl("txtPart_Code") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@part_BarCode", (gvPart.Rows[e.RowIndex].FindControl("txtPart_BarCode") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@part_ID", gvPart.DataKeys[e.RowIndex].Value);
                    cmd.ExecuteNonQuery();
                    gvPart.EditIndex = -1;
                    this.BindGrid();
                }
            }

            // Make all rows visible again
            foreach (GridViewRow row in gvPart.Rows)
            {
                row.Visible = true;
            }

            isEditing = false;

        }







        //code for row deleting event with using statements for data base connection and sql command
        protected void gvPart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_part WHERE part_ID = @part_ID", con))
                {
                    cmd.Parameters.AddWithValue("@part_ID", gvPart.DataKeys[e.RowIndex].Value);
                    cmd.ExecuteNonQuery();
                    this.BindGrid();
                }
            }
        }



        protected void btnUpdateImage_Click(object sender, EventArgs e)
        {


            // Find the GridViewRow that contains the clicked button
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            // Get the part ID from the DataKeys collection
            int partID = Convert.ToInt32(gvPart.DataKeys[row.RowIndex].Value);

            // Cancel the edit
            gvPart.EditIndex = -1;
            BindGrid();

            // Redirect to another page with the Part ID and a boolean value
            bool isEdit = true; // replace with your actual boolean value
            Response.Redirect("partImgModule.aspx?partID=" + partID + "&isEdit=" + isEdit.ToString());
        }



       


    }
}