using Arcane.Game.Wrappers;
using Dofus.Files.Packed;
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

        private Dictionary<int, MapWrapper> Maps { get; }
        private Dictionary<int, byte[]> mapsRaw;

        private MapManager()
        {
            Maps = new Dictionary<int, MapWrapper>();
            mapsRaw = new Dictionary<int, byte[]>();
        }

        public void LoadMapsFromPackedFile(IPackedFile file)
        {
            foreach (var container in file.Where(c => c.Name.EndsWith(".dlm")))
            {
                mapsRaw.Add(int.Parse(container.Name.Split(PackedContainerHelper.PATH_SEPARATOR).Last().Split('.').First()), container.Raw);
            }
        }

        public MapWrapper GetMap(int id)
        {
            lock (Maps)
            {
                if (!Maps.ContainsKey(id))
                {
                    if (!mapsRaw.ContainsKey(id))
                        throw new ArgumentException($"Map#{id} raw not found. Cannot load this map.");
                    var loadedMap = Dofus.Files.Dofus.Files.Maps.MapsManager.Instance.Load(mapsRaw[id]);
                    var map = new MapWrapper(loadedMap);
                    Maps.Add(id, map);
                    return map;
                }
                else
                {
                    return Maps[id];
                }
            }
        }
    }
}
