using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static double GetDaysBetween(string dateOne, string dateTwo)
        {
            DateTime dateTimeOne = DateTime.Parse(dateOne);
            DateTime dateTimeTwo = DateTime.Parse(dateTwo);

            return (dateTimeTwo - dateTimeOne).TotalDays;
        }
    }
}
