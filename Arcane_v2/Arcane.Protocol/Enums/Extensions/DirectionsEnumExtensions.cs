namespace Arcane.Protocol.Enums.Extensions
{
    using System;
    using System.Runtime.CompilerServices;

    public static class DirectionsEnumExtensions
    {
        public static DirectionsEnum GetOpposedDirection(this DirectionsEnum direction)
        {
            return (DirectionsEnum)Math.Abs((int)direction - 4);
        }
    }
}

