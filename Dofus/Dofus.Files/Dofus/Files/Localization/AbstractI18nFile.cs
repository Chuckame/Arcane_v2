using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Dofus.Files.Exceptions;
using Dofus.IO;
using Dofus.Files.Common;

namespace Dofus.Files.Localization
{
    internal abstract class AbstractI18nFile : AbstractDofusFile, ILocalizationFile
    {
        public override DofusFileTypeEnum DofusFileType
        {
            get
            {
                return DofusFileTypeEnum.Localization;
            }
        }

        protected readonly IDictionary<int, string> _mIndexedTexts = new Dictionary<int, string>();
        protected readonly IDictionary<string, string> _mNamedTexts = new Dictionary<string, string>();
        protected int _mLastId = 1;

        public IReadOnlyDictionary<int, string> IndexedTexts
        {
            get
            {
                return new ReadOnlyDictionary<int, string>(_mIndexedTexts);
            }
        }
        public IReadOnlyDictionary<string, string> NamedTexts
        {
            get
            {
                return new ReadOnlyDictionary<string, string>(_mNamedTexts);
            }
        }
        public int GetNextId()
        {
            lock (this)
            {
                return ++_mLastId;
            }
        }

        public string this[int id]
        {
            get { return _mIndexedTexts[id]; }
            set { _mIndexedTexts[id] = value; }
        }
        public string this[string uiName]
        {
            get { return _mNamedTexts[uiName]; }
            set { _mNamedTexts[uiName] = value; }
        }

        protected AbstractI18nFile()
        {
        }

        public bool Contains(int id)
        {
            return _mIndexedTexts.ContainsKey(id);
        }
        public bool Contains(string uiName)
        {
            return _mNamedTexts.ContainsKey(uiName);
        }
        public void Add(int id, string value)
        {
            if (Contains(id))
                throw new AlreadyExistsException();
            _mIndexedTexts.Add(id, value);
        }
        public void Add(string uiName, string value)
        {
            if (Contains(uiName))
                throw new AlreadyExistsException();
            _mNamedTexts.Add(uiName, value);
        }
    }
}
