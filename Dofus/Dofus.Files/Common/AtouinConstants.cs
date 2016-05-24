using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Dofus.Files.Common
{
    public static class AtouinConstants
    {
        public static readonly bool DEBUG_FILES_PARSING = false;
        public static readonly bool DEBUG_FILES_PARSING_ELEMENTS = false;
        public static readonly uint MAP_WIDTH = 14;
        public static readonly uint MAP_HEIGHT = 20;
        public static readonly int MAP_CELLS_COUNT = 560;
        public static readonly uint CELL_WIDTH = 86;
        public static readonly uint CELL_HALF_WIDTH = 43;
        public static readonly uint CELL_HEIGHT = 43;
        public static readonly double CELL_HALF_HEIGHT = 21.5;
        public static readonly uint ALTITUDE_PIXEL_UNIT = 10;
        public static readonly int LOADERS_POOL_INITIAL_SIZE = 30;
        public static readonly int LOADERS_POOL_GROW_SIZE = 5;
        public static readonly int LOADERS_POOL_WARN_LIMIT = 100;
        public static readonly double OVERLAY_MODE_ALPHA = 0.7;
        public static readonly int MAX_ZOOM = 4;
        public static readonly int MAX_GROUND_CACHE_MEMORY = 5;
        public static readonly int GROUND_MAP_VERSION = 1;
        public static readonly double MIN_DISK_SPACE_AVAILABLE = Math.Pow(2, 20) * 512;
        public static readonly int PATHFINDER_MIN_X = 0;
        public static readonly int PATHFINDER_MAX_X = 34;
        public static readonly int PATHFINDER_MIN_Y = -19;
        public static readonly int PATHFINDER_MAX_Y = 14;
        public static readonly int VIEW_DETECT_CELL_WIDTH = 172;
        public static readonly int MIN_MAP_X = -255;
        public static readonly int MAX_MAP_X = 255;
        public static readonly int MIN_MAP_Y = -255;
        public static readonly int MAX_MAP_Y = 255;
        public static readonly Point RESOLUTION_HIGH_QUALITY = new Point(1276, 876);
        public static readonly Point RESOLUTION_MEDIUM_QUALITY = new Point(957, 657);
        public static readonly Point RESOLUTION_LOW_QUALITY = new Point(638, 438);
    }
}
