using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.GameData
{
    public class GameDataManager
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        #region Singleton
        private static GameDataManager _instance = new GameDataManager();
        public static GameDataManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        private Dictionary<Type, Dictionary<int, IDataObject>> _modules;

        private GameDataManager()
        {
            _modules = new Dictionary<Type, Dictionary<int, IDataObject>>();
        }

        public static void AddContainerAssembly(params Assembly[] asms)
        {
            foreach (var asm in asms)
            {
                if (!D2OReader.ClassesContainers.Contains(asm))
                    D2OReader.ClassesContainers.Add(asm);
            }
        }

        public void Load(string filePath)
        {
            LOGGER.Info($"Loading '{filePath}'...");
            var i = 0;
            using (var reader = new D2OReader(filePath))
            {
                foreach (var item in reader.ReadObjects())
                {
                    if (!_modules.ContainsKey(item.Value.GetType()))
                        _modules.Add(item.Value.GetType(), new Dictionary<int, IDataObject>());
                    _modules[item.Value.GetType()][item.Key] = ((IDataObject)item.Value);
                    i++;
                }
            }
            LOGGER.Info($"Loaded '{filePath}': {i} objects !");
        }

        public IEnumerable<T> GetObjects<T>() where T : IDataObject
        {
            return _modules[typeof(T)].Values.Cast<T>();
        }

        public T GetObject<T>(int id) where T : IDataObject
        {
            var module = _modules[typeof(T)];
            if (module.ContainsKey(id))
                return (T)module[id];
            return default(T);
        }
    }
}
