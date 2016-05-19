using System;
using System.Drawing;

namespace Dofus.Files.Utils
{
    public class Tools
    {
        public static Point PointFromMapId(uint _mapId)
        {
            long _worldId = (_mapId & 1073479680) >> 18;
            long _x = _mapId >> 9 & 511;
            long _y = _mapId & 511;
            if ((_x & 256) == 256)
            {
                _x = -(_x & 255);
            }
            if ((_y & 256) == 256)
            {
                _y = -(_y & 255);
            }
            return new Point((int)_x, (int)_y);
        }

        public static int getWorldFromMapId(uint _mapId)
        {
            return (int)(_mapId & 1073479680) >> 18;
        }

        public static int getMapIdFromCoord(int world, int x, int y)
        {
            var _loc4_ = 2 << 12;
            var _loc5_ = 2 << 8;
            if (x > _loc5_ || y > _loc5_ || world > _loc4_)
            {
                return -1;
            }
            var _loc6_ = world & 4095;
            var _loc7_ = Math.Abs(x) & 255;
            if (x < 0)
            {
                _loc7_ = _loc7_ | 256;
            }
            var _loc8_ = Math.Abs(y) & 255;
            if (y < 0)
            {
                _loc8_ = _loc8_ | 256;
            }
            return _loc6_ << 18 | _loc7_ << 9 | _loc8_;
        }
    }
}
