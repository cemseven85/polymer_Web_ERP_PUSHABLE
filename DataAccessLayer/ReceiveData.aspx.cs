using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4.DataAccessLayer
{
    public partial class ReceiveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (Request.HttpMethod == "POST")
            {
                string xmlData;
                using (StreamReader reader = new StreamReader(Request.InputStream))
                {
                    xmlData = reader.ReadToEnd();
                }

                try
                {
                    // Parse the XML data
                    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                    doc.LoadXml(xmlData);
                    double temperature = Convert.ToDouble(doc.SelectSingleNode("//temperature").InnerText);  
                    double humidity = Convert.ToDouble(doc.SelectSingleNode("//humidity").InnerText);

                    // Insert data into the database
                    DataAccess dataAccess = new DataAccess();
                    using (SqlConnection conn = dataAccess.Connection())
                    {
                        string query = "INSERT INTO tbl_tempHum (sample_Time, item_Temp, item_Hum) VALUES (@Time, @Temp, @Hum)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Time", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Temp", temperature);
                            cmd.Parameters.AddWithValue("@Hum", humidity);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    using (StreamWriter writer = new StreamWriter(Server.MapPath("~/App_Data/ReceiveData.log"), true))
                    {
                        writer.WriteLine(DateTime.Now.ToString() + ": " + ex.Message);
                    }
                }
               
            }
        }
    }
}


