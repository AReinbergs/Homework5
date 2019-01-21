using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Helpers
{
    public static class Generator
    {
        public static DateTime? GetBirthdate(string dateTimeString)
        {
            var culture = CultureInfo.GetCultureInfo("lv");
            try
            {
                string date = DateTime.Parse(dateTimeString).ToString("dd.MM.yyyy");
                DateTime d = DateTime.Parse(date);
                return d;
                //return DateTime.ParseExact(dateTimeString, "d", culture);
            }
            catch
            {
                return null;
            }
        }

        public static string GenerateSsn(DateTime? birthday)
        {
            if (birthday.HasValue)
            {
                var text = birthday.Value.ToString("dd.MM.yyyy");
                string[] dayMonthYear = text.Split('.');
                return String.Format("{0}{1}{2}-", dayMonthYear[0], dayMonthYear[1], dayMonthYear[2].Substring(2));
            }
            return "";
        }
    }
}
