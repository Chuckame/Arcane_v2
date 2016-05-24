using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Dofus.Files.Utils
{
    public static class EnumFlagsExtensions
    {
        public static T SetFlag<T>(this T value, T flag, bool hasFlag)
        {
            if (!value.GetType().IsEnum)
                throw new ArgumentException($"'{nameof(value)}' must be an Enum.");

            var underlyingType = Enum.GetUnderlyingType(value.GetType());
            dynamic valueAsInt = Convert.ChangeType(value, underlyingType);
            dynamic flagAsInt = Convert.ChangeType(flag, underlyingType);
            if (hasFlag)
            {
                valueAsInt |= flagAsInt;
            }
            else
            {
                valueAsInt &= ~flagAsInt;
            }
            return (T)Enum.ToObject(value.GetType(), valueAsInt);
        }
    }
}
