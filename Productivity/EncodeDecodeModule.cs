using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace polymer_Web_ERP_V4
{
    public class EncodeDecodeModule
    {
        public static string EncodeDecode(GridViewRow workingRow, int cell)
        {
            string encodedTRName = workingRow.Cells[cell].Text.Replace("&nbsp;", " ");
            string decodedTRName = HttpUtility.HtmlDecode(encodedTRName);
            return decodedTRName;
        }

        public static string EncodeDecodeDataTable(DataTable workingDt, int cell)
        {
            string rowData = (string)workingDt.Rows[0][cell];
            rowData=rowData.Replace("&nbsp;", " ");
            string encodedTRName = rowData;
            string decodedTRName = HttpUtility.HtmlDecode(encodedTRName);
            return decodedTRName;
        }

    }
}