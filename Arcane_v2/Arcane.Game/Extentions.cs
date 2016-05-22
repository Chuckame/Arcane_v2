using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game
{
    public static class Extentions
    {
        public static sbyte ToSByte(this Enum en)
        {
            return Convert.ToSByte(en);
        }
        public static double ToDofusTimestamp(this DateTime? datetime)
        {
            if (!datetime.HasValue)
                return 0;
            return ToDofusTimestamp(datetime.Value);
        }
        public static double ToDofusTimestamp(this DateTime datetime)
        {
            return datetime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
        public static T[] ParseToArray<T>(this string str, char separator)
        {
            return str.Split(separator).Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray();
        }

        public static string Dump<T>(this IEnumerable<T> collection, char separator)
        {
            return string.Join(separator.ToString(), collection);
        }
    }
}
