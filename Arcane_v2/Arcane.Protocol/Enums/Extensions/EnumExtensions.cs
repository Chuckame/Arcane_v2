namespace Arcane.Protocol.Enums
{
    using System;
    using System.Runtime.CompilerServices;

    public static class EnumExtensions
    {
        public static DirectionsEnum GetOpposedDirection(this DirectionsEnum direction)
        {
            return (DirectionsEnum)Math.Abs((int)direction - 4);
        }

        public static bool ToBoolean(this SexEnum sex)
        {
            return sex == SexEnum.Female;
        }
    }
}

