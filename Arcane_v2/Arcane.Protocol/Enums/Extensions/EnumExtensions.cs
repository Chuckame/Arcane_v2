namespace Arcane.Protocol.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class EnumExtensions
    {
        public static DirectionsEnum GetOpposedDirection(this DirectionsEnum direction)
        {
            return (DirectionsEnum)Math.Abs((int)direction - 4);
        }

        public static IEnumerable<DirectionsEnum> GetAllDirections(bool onlyDiagonals = false)
        {
            var list = new List<DirectionsEnum>();
            list.Add(DirectionsEnum.NORTH_EAST);
            list.Add(DirectionsEnum.SOUTH_EAST);
            list.Add(DirectionsEnum.SOUTH_WEST);
            list.Add(DirectionsEnum.NORTH_WEST);
            if (!onlyDiagonals)
            {
                list.Add(DirectionsEnum.EAST);
                list.Add(DirectionsEnum.SOUTH);
                list.Add(DirectionsEnum.WEST);
                list.Add(DirectionsEnum.NORTH);
            }
            return list;
        }

        public static bool ToBoolean(this SexEnum sex)
        {
            return sex == SexEnum.Female;
        }
    }
}

