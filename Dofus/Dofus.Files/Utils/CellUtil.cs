using System;

namespace Dofus.Files.Utils
{
    public static class CellUtil
    {
        /*
        public static int getPixelXFromMapPoint(MapPoint cellId)
        {
            var _loc_2 = InteractiveCellManager.getCell(cellId.cellId);
            return _loc_2.x + _loc_2.width / 2;
        }

        public static int getPixelYFromMapPoint(MapPoint cellId)
        {
            var _loc_2 = InteractiveCellManager.getCell(cellId.cellId);
            return _loc_2.y + _loc_2.height / 2;
        }*/

        public static bool IsLeftCol(int cellId)
        {
            return cellId % 14 == 0;
        }

        public static bool IsRightCol(int cellId)
        {
            return IsLeftCol(cellId + 1);
        }

        public static bool IsTopRow(int cellId)
        {
            return cellId < 28;
        }

        public static bool IsBottomRow(int cellId)
        {
            return cellId > 531;
        }

        public static bool IsEvenRow(int param1)
        {
            return (int)Math.Floor(param1 / 14.0) % 2 == 0;
        }
    }
}
