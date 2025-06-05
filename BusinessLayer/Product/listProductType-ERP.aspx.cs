using polymer_Web_ERP_V4.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public partial class listProductType_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM tbl_productType", conn.Connection()))
                {
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        ProductTypeDataList.DataSource = read;
                        ProductTypeDataList.DataBind();
                    }
                }
            }
        }

    }
}