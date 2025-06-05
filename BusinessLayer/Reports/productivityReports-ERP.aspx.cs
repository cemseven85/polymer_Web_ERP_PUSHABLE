using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class productivityReports_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
        }




        protected void report_Click(object sender, EventArgs e)
        {
            string selectedReport;


            selectedReport = ProductivitytReportsRadioButtonList.SelectedItem.Text;

            switch (selectedReport)
            {
                case "Current Account Statement":

                    Response.Redirect("~/BusinessLayer/Reports/currentAccountStatement.aspx");

                   
                    break;

                case "Daily Granule Production Report":

                    Response.Redirect("~/BusinessLayer/Reports/dailyGranuleProduction.aspx");
                    
                   
                    break;
               

                default:

                    break;
            }

          

        }
    }
}