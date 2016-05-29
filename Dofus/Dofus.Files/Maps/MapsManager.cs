using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Dofus.Files.Maps
{
    public class MapsManager
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        #region Singleton
        private static MapsManager _instance = new MapsManager();
        public static MapsManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        private Dictionary<uint, MapFile> _maps;

        private MapsManager()
        {
            _maps = new Dictionary<uint, MapFile>();
        }

        public IMapFile Load(byte[] bytes)
        {
            var map = new MapFile();
            map.FromBytes(bytes);
            if (_maps.ContainsKey(map.Id))
                throw new ArgumentException($"Maps#{map.Id} already exists.");
            _maps.Add(map.Id, map);
            LOGGER.Info($"Loaded '{map}' !");
            return map;
        }

        public IMapFile GetMap(uint id)
        {
            if (!_maps.ContainsKey(id))
                throw new ArgumentException($"No map with id '{id}' found.");
            return _maps[id];
        }

        public bool IsMapLoaded(uint id)
        {
            return _maps.ContainsKey(id);
        }
    }
}
