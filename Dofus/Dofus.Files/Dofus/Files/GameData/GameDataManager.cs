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

        public void AddContainerAssembly(params Assembly[] asms)
        {
            foreach (var asm in asms)
            {
                if (!D2OReader.ClassesContainers.Contains(asm))
                    D2OReader.ClassesContainers.Add(asm);
            }
        }

        public void Load(string filePath)
        {
            var reader = new D2OReader(filePath);
            foreach (var item in reader.ReadObjects())
            {
                if (!_modules.ContainsKey(item.Value.GetType()))
                    _modules.Add(item.Value.GetType(), new Dictionary<int, IDataObject>());
                _modules[item.Value.GetType()].Add(item.Key, (IDataObject)item.Value);
            }
            reader.Close();
        }

        public T[] GetObjects<T>() where T : IDataObject
        {
            return _modules[typeof(T)].Values.Cast<T>().ToArray();
        }

        public T GetObject<T>(int id) where T : IDataObject
        {
            return (T)_modules[typeof(T)][id];
        }
    }
}
