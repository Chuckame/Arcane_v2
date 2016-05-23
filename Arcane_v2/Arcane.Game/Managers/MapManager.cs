using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Managers
{
    public class MapManager
    {
        #region singleton
        private static MapManager _instance = new MapManager();
        public static MapManager Instance { get { return _instance; } }
        #endregion

        public

        private MapManager()
        {

        }
    }
}
