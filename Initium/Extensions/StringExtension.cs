using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Initium.Extensions
{
    public static class StringExtension
    {
        public static T Deserialize<T>(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? default(T) : JsonConvert.DeserializeObject<T>(value, Initium.JsonSerializerSettings);
        }

        public static bool IsNumeric(this string theValue)
        {
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out _);
        }

        public static bool IsDate(this string input)
        {
            return !string.IsNullOrEmpty(input) && DateTime.TryParse(input, out _);
        }


        public static long ToLong(this string value, long defaultValue = 0)
        {
            return long.TryParse(value, out var result) ? result : defaultValue;
        }

        public static int ToInt(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out var result) ? result : defaultValue;
        }

        public static DateTime? ToDateTime(this string s)
        {
            var tryDtr = DateTime.TryParse(s, out var dtr);
            return (tryDtr) ? dtr : new DateTime?();
        }

        public static DateTime? ToDateTime(this string s, string culture, DateTimeStyles style = DateTimeStyles.None)
        {
            var tryDtr = DateTime.TryParse(s,new CultureInfo(culture), style, out var dtr);
            return (tryDtr) ? dtr : new DateTime?();
        }

        public static string Truncate(this string value, int length = 25, string suffix = "...")
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.Length <= length ? value : string.Join("", value.Substring(0, length - 3), suffix);
        }

        public static bool IsGuid(this string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var format = new Regex(
                "^[A-Fa-f0-9]{32}$|" +
                "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
            var match = format.Match(input);

            return match.Success;
        }
    }
}
