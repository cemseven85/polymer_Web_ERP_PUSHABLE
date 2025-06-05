using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using polymer_Web_ERP_V4.Data_Access_Layer;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Configuration;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace polymer_Web_ERP_V4.Productivity
{
    public class WorkingDays
    {


         public static int GetWorkingDaysInMonth(int year, int month)
        {
            Calendar calendar = CultureInfo.InvariantCulture.Calendar;

            int daysInMonth = calendar.GetDaysInMonth(year, month);
            int workingDays = 0;
            for (int i = 1; i <= daysInMonth; i++)
            {
                DateTime date = new DateTime(year, month, i);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }
            return workingDays;

        }


        public static int GetWorkingDaysInMonth(int year, int month,int saaTRWorkingDay)
        {
            Calendar calendar = CultureInfo.InvariantCulture.Calendar;

            int daysInMonth = calendar.GetDaysInMonth(year, month);
            int workingDays = 0;
            for (int i = 1; i <= daysInMonth; i++)
            {
                DateTime date = new DateTime(year, month, i);
                if ( date.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }
            return workingDays;

        }


    }
}