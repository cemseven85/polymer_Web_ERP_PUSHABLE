using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using polymer_Web_ERP_V4.Data_Access_Layer;
using static System.Collections.Specialized.BitVector32;
using System.Text;

namespace polymer_Web_ERP_V4
{
    public partial class productType_ERP : System.Web.UI.Page
    {
        DataAccess conn = new DataAccess();

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    SqlCommand command = new SqlCommand("select *from tbl_productType", conn.Connection());
        //    SqlDataReader read = command.ExecuteReader();
        //    ProductTypeDataList.DataSource = read;
        //    ProductTypeDataList.DataBind();


        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM tbl_productType", conn.Connection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProductTypeDataList.DataSource = reader;
                        ProductTypeDataList.DataBind();
                    }
                }
            }
        }


        //protected void KaydetButton_Click(object sender, EventArgs e)
        //{
        //    string productTypeName;
        //    string productTypeNameBG;
        //    string productTypeNameTR;
        //    string productTypeDescription;

        //    productTypeName=Product_Type_Name_TextBox.Text;                     
        //    productTypeNameBG = Product_Type_Name_BG_TextBox.Text;                                
        //    productTypeNameTR= Product_Type_Name_TR_TextBox.Text ;
        //    productTypeDescription=Product_Type_Description_TextBox.Text ;

        //    if (String.IsNullOrEmpty(Product_Type_Name_TextBox.Text) == false)
        //    {
        //        SqlCommand addNewType = new SqlCommand($"insert into tbl_productType (prod_Typ_Name,prod_Typ_Name_BG,prod_Typ_Name_TR,prod_Typ_Description) values ('{productTypeName}',@bgName,'{productTypeNameTR}','{productTypeDescription}')", conn.Connection());
        //        addNewType.Parameters.AddWithValue("@bgName", Product_Type_Name_BG_TextBox.Text);   // We had a problem by using string varible that contains Crilic Characters. But use direct parameter solve problem. 
        //        addNewType.ExecuteNonQuery();


        //    }


        //    Product_Type_Name_TextBox.Text = string.Empty;
        //    Product_Type_Name_BG_TextBox.Text = string.Empty;
        //    Product_Type_Name_TR_TextBox.Text = string.Empty;
        //    Product_Type_Description_TextBox.Text = string.Empty;

        //    Response.Redirect("productType-ERP.aspx");  // Normaly we do not need this, but when I refrech  data incert twice. 
        //                                                // I solve it this way bun not right way to work.  ??? 
        //                                                // c# Code solution is on my documantation about asp.net 
        //}


        protected void KaydetButton_Click(object sender, EventArgs e)
        {
            string productTypeName = Product_Type_Name_TextBox.Text;
            string productTypeNameBG = Product_Type_Name_BG_TextBox.Text;
            string productTypeNameTR = Product_Type_Name_TR_TextBox.Text;
            string productTypeDescription = Product_Type_Description_TextBox.Text;

            if (!string.IsNullOrEmpty(productTypeName))
            {
                using (SqlCommand addNewType = new SqlCommand($"INSERT INTO tbl_productType (prod_Typ_Name, prod_Typ_Name_BG, prod_Typ_Name_TR, prod_Typ_Description) VALUES (@productName, @bgName, @trName, @description)", conn.Connection()))
                {
                    addNewType.Parameters.AddWithValue("@productName", productTypeName);
                    addNewType.Parameters.AddWithValue("@bgName", productTypeNameBG);
                    addNewType.Parameters.AddWithValue("@trName", productTypeNameTR);
                    addNewType.Parameters.AddWithValue("@description", productTypeDescription);
                    addNewType.ExecuteNonQuery();
                }
            }

            // Clear the input fields after insertion
            Product_Type_Name_TextBox.Text = string.Empty;
            Product_Type_Name_BG_TextBox.Text = string.Empty;
            Product_Type_Name_TR_TextBox.Text = string.Empty;
            Product_Type_Description_TextBox.Text = string.Empty;

            // Redirect to the specified page
            Response.Redirect("productType-ERP.aspx");
        }


        protected void ModifyButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("productTypeModify-ERP.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("productTypeDelete-ERP.aspx");
        }
    }
}





/*

string htmlEncodedText = myTextbox.Text;
string htmlDecodedText = HttpUtility.UrlDecode(htmlEncodedText);

Encoding latinEncoding = Encoding.GetEncoding("8859-1");
Encoding utfEncoding = Encoding.UTF8;
byte[] utfBytes = utfEncoding.GetBytes(htmlDecodedText);
byte[] latinBytes =
    System.Text.Encoding.Convert(utfEncoding, latinEncoding, utfBytes);
string latinString = latinEncoding.GetString(latinBytes);

*/