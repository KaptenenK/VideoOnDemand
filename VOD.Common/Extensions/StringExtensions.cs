using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD.Common.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            else if (value.Length <= length)
            {
                return value;
            }
            return value.Substring(0, length) + "...";

            //return $"{value[..length]} ...";
        }
    }
}
