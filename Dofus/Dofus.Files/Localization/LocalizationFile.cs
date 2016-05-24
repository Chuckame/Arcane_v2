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
    internal class LocalizationFile : AbstractDofusFile, ILocalizationFile
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
        public override void FromRaw(IDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            _mIndexedTexts.Clear();
            _mNamedTexts.Clear();
            using (var dataReader = DofusIOUtils.CreateBigEndianReader(reader.Data))
            {
                var textsInfosPosition = reader.ReadInt();
                reader.SetPosition(textsInfosPosition);
                var textsCount = reader.ReadInt();
                for (int i = 0; i < textsCount; i += 8)
                {
                    var id = reader.ReadInt();
                    if (id > _mLastId)
                        _mLastId = id;
                    var textPos = reader.ReadInt();

                    dataReader.SetPosition(textPos);
                    _mIndexedTexts.Add(id, dataReader.ReadUTF());
                }
                while (reader.BytesAvailable > 0)
                {
                    var uiId = reader.ReadUTF();
                    var uiTextPos = reader.ReadInt();

                    dataReader.SetPosition(uiTextPos);
                    _mNamedTexts.Add(uiId, dataReader.ReadUTF());
                }
            }
        }

        public override void ToRaw(IDataWriter writer)
        {
            using (IDataWriter tempWriter = DofusIOUtils.CreateBigEndianWriter())
            {
                writer.SetPosition(4);
                foreach (var entry in _mIndexedTexts)
                {
                    tempWriter.WriteInt(entry.Key);
                    tempWriter.WriteInt((int)writer.Position);
                    writer.WriteUTF(entry.Value);
                }
                var position = (int)tempWriter.Position;
                foreach (var entry in _mNamedTexts)
                {
                    tempWriter.WriteUTF(entry.Key);
                    tempWriter.WriteInt((int)writer.Position);
                    writer.WriteUTF(entry.Value);
                }
                var pos = (int)writer.Position;
                writer.WriteInt(position);
                writer.WriteBytes(tempWriter.Data);
                writer.SetPosition(0);
                writer.WriteInt(pos);
            }
        }
    }
}
