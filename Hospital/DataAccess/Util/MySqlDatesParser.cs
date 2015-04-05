using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Hospital.DataAccess.Util
{
    public class MySqlDatesParser
    {
        public static DateTime parseDate(String date)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            String format = "M/d/yyyy h:mm:ss tt";

            DateTime result;

            result = DateTime.ParseExact(date.Trim(), format, provider);

            return result;
        }

        public static DateTime? parseNullableDate(String date)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            String format = "M/d/yyyy h:mm:ss tt";

            DateTime? result;

            try
            {
                result = DateTime.ParseExact(date.Trim(), format, provider);
            }
            catch (FormatException ex)
            {
                result = null;
            }

            return result;
        }
    }
}
