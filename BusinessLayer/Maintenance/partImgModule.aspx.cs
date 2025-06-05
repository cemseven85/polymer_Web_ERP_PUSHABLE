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
    public partial class partImgModule : System.Web.UI.Page
    {

        //add Data Access object with name conn
        DataAccess conn = new DataAccess();


        string partID;
        bool isEdit=true;
        protected void Page_Load(object sender, EventArgs e)
        {

            partID = Request.QueryString["partID"];
            if (!bool.TryParse(Request.QueryString["isEdit"], out isEdit))
            {
                // Handle the case when isEdit is not present or invalid
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT part_ID, part_Name, part_Description, machine_Name, partGroup_Name, part_Code, part_BarCode, machineGroup_Name, partType_Name FROM tbl_part INNER JOIN tbl_machine ON tbl_part.machine_ID = tbl_machine.machine_ID INNER JOIN tbl_partGroup ON tbl_part.partGroup_ID = tbl_partGroup.partGroup_ID INNER JOIN tbl_machineGroup ON tbl_machine.machineGroup_ID = tbl_machineGroup.machineGroup_ID INNER JOIN tbl_partType ON tbl_partGroup.partType_ID = tbl_partType.partType_ID WHERE part_ID='{partID}'", con))
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

        }


        //write a  bind method for gvImgPart grid view to bind images
        private void BindImgGrid()
        {
            using (SqlConnection con = conn.Connection())
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT  part_ID, part_Name, part_Image_Path_1, part_Image_Path_2, part_Image_Path_3, part_Image_Path_4, part_Image_Path_5 FROM tbl_part where part_ID='{partID}'", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvImgPart.DataSource = dt;
                        gvImgPart.DataBind();
                    }
                }
            }
        }


        //write a prerender method for bind grid view
        protected void gvImgPart_PreRender(object sender, EventArgs e)
        {
            this.BindImgGrid();

            // Configure GridView structure
            if (gvImgPart.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                gvImgPart.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                gvImgPart.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element.
                //Remove if you don't have a footer row
                gvImgPart.FooterRow.TableSection = TableRowSection.TableFooter;

            }

        }

        ////Write a method bind for gvImgPartUpload grid view to bind grid view
        //private void BindImgPartUploadGrid()
        //{
        //    using (SqlConnection con = conn.Connection())
        //    {
        //        using (SqlCommand cmd = new SqlCommand($"SELECT  part_ID, part_Name  FROM tbl_part where part_ID='{partID}'", con))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);
        //                gvImgPartUpload.DataSource = dt;
        //                gvImgPartUpload.DataBind();
        //            }
        //        }
        //    }
        //}

        ////write a prerender method for bind grid view
        //protected void gvImgPartUpload_PreRender(object sender, EventArgs e)
        //{
        //    this.BindImgPartUploadGrid();

        //    // Configure GridView structure
        //    if (gvImgPartUpload.Rows.Count > 0)
        //    {
        //        //This replaces <td> with <th> and adds the scope attribute
        //        gvImgPartUpload.UseAccessibleHeader = true;

        //        //This will add the <thead> and <tbody> elements
        //        gvImgPartUpload.HeaderRow.TableSection = TableRowSection.TableHeader;

        //        //This adds the <tfoot> element.
        //        //Remove if you don't have a footer row
        //        gvImgPartUpload.FooterRow.TableSection = TableRowSection.TableFooter;

        //    }

        //}


        protected void gvImgPart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool showFooter = isEdit;

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Visible = showFooter;
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Find the FileUpload control in the GridView
            FileUpload fuPartImage = (FileUpload)gvImgPart.FooterRow.FindControl("fuPartImage");

            if (fuPartImage.HasFile)
            {
                // Add the image to the data base
                if (fuPartImage.HasFile)
                {
                    string fileName = Path.GetFileName(fuPartImage.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(fuPartImage.PostedFile.FileName);
                    string fileLocation = "~/Images/" + fileName;
                    fuPartImage.SaveAs(Server.MapPath(fileLocation));

                    using (SqlConnection con = conn.Connection())
                    {
                        using (SqlCommand cmd = new SqlCommand($"UPDATE tbl_part SET part_Image_Path_1 = @part_Image WHERE part_ID = '{partID}'", con))
                        {
                            cmd.Parameters.AddWithValue("@part_Image", fileLocation);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }




                // Rebind the GridView
                BindImgGrid();
            }
        }

        //Write a method for btnUpload_2_Click
        protected void btnUpload_2_Click(object sender, EventArgs e)
        {
            // Find the FileUpload control in the GridView
            FileUpload fuPartImage2 = (FileUpload)gvImgPart.FooterRow.FindControl("fuPartImage2");

            if (fuPartImage2.HasFile)
            {
                // Add the image to the data base
                if (fuPartImage2.HasFile)
                {
                    string fileName = Path.GetFileName(fuPartImage2.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(fuPartImage2.PostedFile.FileName);
                    string fileLocation = "~/Images/" + fileName;
                    fuPartImage2.SaveAs(Server.MapPath(fileLocation));

                    using (SqlConnection con = conn.Connection())
                    {
                        using (SqlCommand cmd = new SqlCommand($"UPDATE tbl_part SET part_Image_Path_2 = @part_Image WHERE part_ID = '{partID}'", con))
                        {
                            cmd.Parameters.AddWithValue("@part_Image", fileLocation);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        //Write a method for btnUpload_3_Click
        protected void btnUpload_3_Click(object sender, EventArgs e)
        {
            // Find the FileUpload control in the GridView
            FileUpload fuPartImage3 = (FileUpload)gvImgPart.FooterRow.FindControl("fuPartImage3");

            if (fuPartImage3.HasFile)
            {
                // Add the image to the data base
                if (fuPartImage3.HasFile)
                {
                    string fileName = Path.GetFileName(fuPartImage3.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(fuPartImage3.PostedFile.FileName);
                    string fileLocation = "~/Images/" + fileName;
                    fuPartImage3.SaveAs(Server.MapPath(fileLocation));

                    using (SqlConnection con = conn.Connection())
                    {
                        using (SqlCommand cmd = new SqlCommand($"UPDATE tbl_part SET part_Image_Path_3 = @part_Image WHERE part_ID = '{partID}'", con))
                        {
                            cmd.Parameters.AddWithValue("@part_Image", fileLocation);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        //Write a method for btnUpload_4_Click
        protected void btnUpload_4_Click(object sender, EventArgs e)
        {
            // Find the FileUpload control in the GridView
            FileUpload fuPartImage4 = (FileUpload)gvImgPart.FooterRow.FindControl("fuPartImage4");

            if (fuPartImage4.HasFile)
            {
                // Add the image to the data base
                if (fuPartImage4.HasFile)
                {
                    string fileName = Path.GetFileName(fuPartImage4.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(fuPartImage4.PostedFile.FileName);
                    string fileLocation = "~/Images/" + fileName;
                    fuPartImage4.SaveAs(Server.MapPath(fileLocation));

                    using (SqlConnection con = conn.Connection())
                    {
                        using (SqlCommand cmd = new SqlCommand($"UPDATE tbl_part SET part_Image_Path_4 = @part_Image WHERE part_ID = '{partID}'", con))
                        {
                            cmd.Parameters.AddWithValue("@part_Image", fileLocation);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        //Write a method for btnUpload_5_Click
        protected void btnUpload_5_Click(object sender, EventArgs e)
        {
            // Find the FileUpload control in the GridView
            FileUpload fuPartImage5 = (FileUpload)gvImgPart.FooterRow.FindControl("fuPartImage5");

            if (fuPartImage5.HasFile)
            {
                // Add the image to the data base
                if (fuPartImage5.HasFile)
                {
                    string fileName = Path.GetFileName(fuPartImage5.PostedFile.FileName);
                    string fileExtension = Path.GetExtension(fuPartImage5.PostedFile.FileName);
                    string fileLocation = "~/Images/" + fileName;
                    fuPartImage5.SaveAs(Server.MapPath(fileLocation));

                    using (SqlConnection con = conn.Connection())
                    {
                        using (SqlCommand cmd = new SqlCommand($"UPDATE tbl_part SET part_Image_Path_5 = @part_Image WHERE part_ID = '{partID}'", con))
                        {
                            cmd.Parameters.AddWithValue("@part_Image", fileLocation);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

    }
}