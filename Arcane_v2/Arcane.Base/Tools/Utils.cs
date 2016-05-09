using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Base.Extentions;

namespace Arcane.Base.Tools
{
    public static class Utils
    {
        private static string[] Hash = { "a", "z", "e", "r", "t", "y", "u", "i", "o", "p", "q", "s", "d", "f", "g", "h", "j", "k", "l", "m", "w", "x", "c", "v", "b", "n" };
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
        public static double RandomDouble()
        {
            return random.NextDouble();
        }
        public static double GetTimestamp()
        {
            return GetTimestamp(DateTime.Now);
        }

        public static string NormalizeString(string str)
        {
            var final = new StringBuilder();
            foreach (var @char in str.Normalize(NormalizationForm.FormD))
            {
                var tt = CharUnicodeInfo.GetUnicodeCategory(@char);
                if (tt != UnicodeCategory.NonSpacingMark)
                    final.Append(@char);
            }
            return final.ToString();
        }

        public static double GetTimestamp(DateTime time)
        {
            return time.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public static int GetIntTimestamp()
        {
            return GetIntTimestamp(DateTime.Now);
        }

        public static int GetIntTimestamp(DateTime time)
        {
            return (int)(GetTimestamp(time) / 1000.0);
        }

        public static string RandomString(int lenght)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < lenght; ++i)
            {
                builder.Append(Hash.Random());
            }
            return builder.ToString();
        }

        public static string DateTimeToString(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //public static DateTime StringToDateTime(string str)
        //{
        //    if (string.IsNullOrEmpty(str) || str == "0")
        //        return new DateTime(0);
        //    var split = str.Split(' ');
        //    var date = split[0].ParseString<int>('-');
        //    var time = split[1].ParseString<int>(':');
        //    return new DateTime(date[0], date[1], date[2], time[0], time[1], time[2]);
        //}

        public static string UppercaseWords(string value, params char[] separators)
        {
            char[] array = value.ToLower().ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            for (int i = 1; i < array.Length; i++)
            {
                if (separators.Contains(array[i - 1]))
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
    }
}
