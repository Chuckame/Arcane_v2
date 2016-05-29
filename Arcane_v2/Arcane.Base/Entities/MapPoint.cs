using Arcane.Protocol.Enums;
using Dofus.Files.Dofus.Files.Common;
using Dofus.Files.Dofus.Files.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Entities
{
    public class MapPoint : IComparable, IComparable<MapPoint>, IEquatable<MapPoint>
    {
        private short _nCellId;
        private int _nX;
        private int _nY;
        private static readonly Point VECTOR_RIGHT = new Point(1, 1);
        private static readonly Point VECTOR_SOUTH_EAST = new Point(1, 0);
        private static readonly Point VECTOR_DOWN = new Point(1, -1);
        private static readonly Point VECTOR_SOUTH_WEST = new Point(0, -1);
        private static readonly Point VECTOR_LEFT = new Point(-1, -1);
        private static readonly Point VECTOR_NORTH_WEST = new Point(-1, 0);
        private static readonly Point VECTOR_UP = new Point(-1, 1);
        private static readonly Point VECTOR_NORTH_EAST = new Point(0, 1);
        private static bool _bInit = false;
        public static Dictionary<short, Point> CELLPOS = new Dictionary<short, Point>();
        public short CellId
        {
            get
            {
                return this._nCellId;
            }
            set
            {
                this._nCellId = value;
                this.setFromCellId();
            }
        }
        public int X
        {
            get
            {
                return this._nX;
            }
            set
            {
                this._nX = value;
                this.setFromCoords();
            }
        }
        public int Y
        {
            get
            {
                return this._nY;
            }
            set
            {
                this._nY = value;
                this.setFromCoords();
            }
        }

        public MapPoint()
        {
        }
        public MapPoint(short cellId)
        {
            this.CellId = cellId;
        }
        public MapPoint(int x, int y)
        {
            this._nX = x;
            this._nY = y;
            this.setFromCoords();
        }

        public int distanceTo(MapPoint point)
        {
            return (int)Math.Sqrt(Math.Pow(point.X - this.X, 2) + Math.Pow(point.Y - this.Y, 2));
        }

        public int distanceToCell(MapPoint point)
        {
            return Math.Abs(this.X - point.X) + Math.Abs(this.Y - point.Y);
        }

        public DirectionsEnum orientationTo(MapPoint point)
        {
            DirectionsEnum _loc_3 = 0;
            var _loc_2 = new Point
            {
                X = point.X > this.X ? (1) : (point.X < this.X ? (-1) : (0)),
                Y = point.Y > this.Y ? (1) : (point.Y < this.Y ? (-1) : (0))
            };
            if (_loc_2.X == VECTOR_RIGHT.X && _loc_2.Y == VECTOR_RIGHT.Y)
            {
                _loc_3 = DirectionsEnum.EAST;
            }
            else if (_loc_2.X == VECTOR_SOUTH_EAST.X && _loc_2.Y == VECTOR_SOUTH_EAST.Y)
            {
                _loc_3 = DirectionsEnum.SOUTH_EAST;
            }
            else if (_loc_2.X == VECTOR_DOWN.X && _loc_2.Y == VECTOR_DOWN.Y)
            {
                _loc_3 = DirectionsEnum.SOUTH;
            }
            else if (_loc_2.X == VECTOR_SOUTH_WEST.X && _loc_2.Y == VECTOR_SOUTH_WEST.Y)
            {
                _loc_3 = DirectionsEnum.SOUTH_WEST;
            }
            else if (_loc_2.X == VECTOR_LEFT.X && _loc_2.Y == VECTOR_LEFT.Y)
            {
                _loc_3 = DirectionsEnum.WEST;
            }
            else if (_loc_2.X == VECTOR_NORTH_WEST.X && _loc_2.Y == VECTOR_NORTH_WEST.Y)
            {
                _loc_3 = DirectionsEnum.NORTH_WEST;
            }
            else if (_loc_2.X == VECTOR_UP.X && _loc_2.Y == VECTOR_UP.Y)
            {
                _loc_3 = DirectionsEnum.NORTH;
            }
            else if (_loc_2.X == VECTOR_NORTH_EAST.X && _loc_2.Y == VECTOR_NORTH_EAST.Y)
            {
                _loc_3 = DirectionsEnum.NORTH_EAST;
            }
            return _loc_3;
        }

        public DirectionsEnum advancedOrientationTo(MapPoint point, bool diagonalOnly = true)
        {
            var _loc_3 = point.X - this.X;
            var _loc_4 = this.Y - point.Y;
            var _loc_5 = Math.Acos(_loc_3 / Math.Sqrt(Math.Pow(_loc_3, 2) + Math.Pow(_loc_4, 2))) * 180 / Math.PI * (point.Y > this.Y ? (-1) : (1));
            if (diagonalOnly)
            {
                _loc_5 = Math.Round(_loc_5 / 90) * 2 + 1;
            }
            else
            {
                _loc_5 = Math.Round(_loc_5 / 45) + 1;
            }
            if (_loc_5 < 0)
            {
                _loc_5 = _loc_5 + 8;
            }
            return (DirectionsEnum)_loc_5;
        }

        public IEnumerable<MapPoint> GetNearestCells(bool onlyDiagonals)
        {
            return GetNearestFreeCells(null, onlyDiagonals);
        }

        public IEnumerable<MapPoint> GetNearestFreeCells(IMapFile map, bool onlyDiagonals)
        {
            var list = new List<MapPoint>();
            foreach (var direction in EnumExtensions.GetAllDirections(onlyDiagonals))
            {
                var cell = GetNearestCellInDirection(DirectionsEnum.NORTH_EAST);
                if (cell != null && (map == null || map.Cells[cell.CellId].Mov))
                    list.Add(cell);
            }
            return list;
        }

        public MapPoint GetNearestCellInDirection(DirectionsEnum direction)
        {
            MapPoint nearestCell = null;
            switch (direction)
            {
                case DirectionsEnum.EAST:
                    {
                        nearestCell = MapPoint.FromCoords((this._nX + 1), (this._nY + 1));
                        break;
                    }
                case DirectionsEnum.SOUTH_EAST:
                    {
                        nearestCell = MapPoint.FromCoords((this._nX + 1), this._nY);
                        break;
                    }
                case DirectionsEnum.SOUTH:
                    {
                        nearestCell = MapPoint.FromCoords((this._nX + 1), (this._nY - 1));
                        break;
                    }
                case DirectionsEnum.SOUTH_WEST:
                    {
                        nearestCell = MapPoint.FromCoords(this._nX, (this._nY - 1));
                        break;
                    }
                case DirectionsEnum.WEST:
                    {
                        nearestCell = MapPoint.FromCoords((this._nX - 1), (this._nY - 1));
                        break;
                    }
                case DirectionsEnum.NORTH_WEST:
                    {
                        nearestCell = MapPoint.FromCoords((this._nX - 1), this._nY);
                        break;
                    }
                case DirectionsEnum.NORTH:
                    {
                        nearestCell = MapPoint.FromCoords((this._nX - 1), (this._nY + 1));
                        break;
                    }
                case DirectionsEnum.NORTH_EAST:
                    {
                        nearestCell = MapPoint.FromCoords(this._nX, (this._nY + 1));
                        break;
                    }
            }
            if (MapPoint.IsInMap(nearestCell._nX, nearestCell._nY))
            {
                return nearestCell;
            }
            return null;
        }

        public MapPoint Clone()
        {
            return new MapPoint(this.CellId);
        }

        private void setFromCoords()
        {
            if (!_bInit)
            {
                Init();
            }
            this._nCellId = (short)((this._nX - this._nY) * AtouinConstants.MAP_WIDTH + this._nY + (this._nX - this._nY) / 2.0);
        }

        private void setFromCellId()
        {
            if (!_bInit)
            {
                Init();
            }
            if (!CELLPOS.ContainsKey(this._nCellId))
            {
                throw new IndexOutOfRangeException($"Cell identifier out of bounds ({this._nCellId}).");
            }
            var _loc_1 = CELLPOS[this._nCellId];
            this._nX = _loc_1.X;
            this._nY = _loc_1.Y;
        }

        public static MapPoint FromCellId(short cellId)
        {
            return new MapPoint(cellId);
        }

        public static MapPoint FromCoords(int x, int y)
        {
            return new MapPoint(x, y);
        }

        public static bool IsInMap(int x, int y)
        {
            return x + y >= 0 && x - y >= 0 && x - y < AtouinConstants.MAP_HEIGHT * 2 && x + y < AtouinConstants.MAP_WIDTH * 2;
        }

        public static List<MapPoint> GetAllCellsInPath(List<MapPoint> points)
        {
            var list = new List<MapPoint>();

            for (int ptIndex = 0; ptIndex < points.Count - 1; ++ptIndex)
            {
                var currentCellId = points[ptIndex];
                var nextCellId = points[ptIndex + 1];
                var diffX = nextCellId.X - currentCellId.X;
                var diffY = nextCellId.Y - currentCellId.Y;
                if (diffX > 0)
                {
                    for (int x = currentCellId.X; x != nextCellId.X; ++x)
                    {
                        list.Add(new MapPoint(x, currentCellId.Y));
                    }
                }
                else if (diffX < 0)
                {
                    for (int x = currentCellId.X; x != nextCellId.X; --x)
                    {
                        list.Add(new MapPoint(x, currentCellId.Y));
                    }
                }
                else if (diffY > 0)
                {
                    for (int y = currentCellId.Y; y != nextCellId.Y; ++y)
                    {
                        list.Add(new MapPoint(currentCellId.X, y));
                    }
                }
                else if (diffY < 0)
                {
                    for (int y = currentCellId.Y; y != nextCellId.Y; --y)
                    {
                        list.Add(new MapPoint(currentCellId.X, y));
                    }
                }
                else//la case actuelle est la même ! WTF ??!
                {

                }
            }
            list.Add(new MapPoint(points.Last().CellId));

            return list;
        }

        public override string ToString()
        {
            return $"[{X};{Y}]#{CellId}";
        }

        public static void Init()
        {
            _bInit = true;
            var x = 0;
            var y = 0;
            short cellId = 0;
            for (int _loc_5 = 0; _loc_5 < AtouinConstants.MAP_HEIGHT; _loc_5++)
            {
                for (int i = 0; i < AtouinConstants.MAP_WIDTH; i++)
                {
                    CELLPOS[cellId] = new Point(x + i, y + i);
                    cellId++;
                }
                x++;
                for (int i = 0; i < AtouinConstants.MAP_WIDTH; i++)
                {
                    CELLPOS[cellId] = new Point(x + i, y + i);
                    cellId++;
                }
                y--;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj is MapPoint && Equals(obj as MapPoint);
        }

        public bool Equals(short _cellId)
        {
            return _cellId == this.CellId;
        }

        public override int GetHashCode()
        {
            return this.CellId;
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as MapPoint);
        }

        public int CompareTo(MapPoint other)
        {
            return this.CellId.CompareTo(other.CellId);
        }

        public bool Equals(MapPoint other)
        {
            return other.CellId.Equals(this.CellId);
        }
    }
}
