using Dofus.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dofus.Files.Exceptions;
using Dofus.Files.Utils;
using Dofus.Files.Common;

namespace Dofus.Files.Elements
{
    internal class ElementsFile : AbstractDofusFile, IElementsFile
    {
        public static readonly byte Header = 69;

        public override DofusFileTypeEnum DofusFileType
        {
            get
            {
                return DofusFileTypeEnum.MapElements;
            }
        }

        private List<int> _mJpgList = new List<int>();
        private readonly Dictionary<int, GraphicalElementData> _mMapElements = new Dictionary<int, GraphicalElementData>();
        private int _mLastId = 1;

        public byte FileVersion
        { get; private set; }
        public bool Parsed
        { get; private set; }

        public GraphicalElementData this[int elementId]
        {
            get
            {
                return GetElementData(elementId);
            }
        }

        public ElementsFile()
        {
        }

        public int GetNextElementId()
        {
            return _mLastId;
        }
        public GraphicalElementData GetElementData(int elementId)
        {
            return Contains(elementId) ? _mMapElements[elementId] : null;
        }

        public IList<GraphicalElementData> GetElementsList()
        {
            return _mMapElements.Values.ToList();
        }
        public IDictionary<int, GraphicalElementData> GetElements()
        {
            return _mMapElements.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public bool IsJpg(int gfxId)
        {
            return _mJpgList.Contains(gfxId);
        }

        public void Add(GraphicalElementData element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (Contains(element.ElementId))
                throw new AlreadyExistsException();
            _mMapElements.Add(element.ElementId, element);
            if (element.ElementId > _mLastId)
                _mLastId = element.ElementId;
        }

        public override void FromRaw(IDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            var header = reader.ReadByte();
            if (header != Header)
            {
                try
                {
                    var data = reader.Data;
                    reader.Dispose();
                    reader = DofusIOUtils.CreateBigEndianReader(ZipHelper.Uncompress(data));
                    header = reader.ReadByte();
                }
                catch (Exception ex)
                {
                    throw new FileLoadException("Wrong header file", ex);
                }
                if (header != Header)
                    throw new FileLoadException("Wrong header file");
            }
            try
            {
                FileVersion = reader.ReadByte();
                var elementsCount = reader.ReadUInt();
                _mMapElements.Clear();
                var skypLen = 0;
                for (int i = 0; i < elementsCount; ++i)
                {
                    if (FileVersion >= 9)
                    {
                        skypLen = reader.ReadUShort();
                    }
                    var edId = reader.ReadInt();
                    if (FileVersion <= 8)
                    {
                        var edType = (GraphicalElementTypesEnum)reader.ReadByte();
                        var ed = GraphicalElementDataFactory.GetGraphicalElementData(edId, edType);
                        ed.FromRaw(reader, FileVersion);
                        _mMapElements.Add(edId, ed);
                        if (edId > _mLastId)
                            _mLastId = edId;
                    }
                    else
                    {
                        var pos = reader.Position;
                        var edType = (GraphicalElementTypesEnum)reader.ReadByte();
                        var ed = GraphicalElementDataFactory.GetGraphicalElementData(edId, edType);
                        ed.FromRaw(reader, FileVersion);
                        _mMapElements.Add(edId, ed);
                        if (edId > _mLastId)
                            _mLastId = edId;
                        reader.SetPosition(pos + skypLen - 4);
                    }
                }
                if (FileVersion >= 8)
                {
                    var gfxCount = reader.ReadInt();
                    _mJpgList = new List<int>();
                    for (int i = 0; i < gfxCount; i++)
                    {
                        var gfxId = reader.ReadInt();
                        _mJpgList.Add(gfxId);
                    }
                }
                Parsed = true;
            }
            catch (Exception e)
            {
                throw new FileLoadException("Error during the file parsing.", e);
            }
        }

        public int Count()
        {
            return _mMapElements.Count;
        }
        public bool Contains(int elementId)
        {
            return _mMapElements.ContainsKey(elementId);
        }

        public override void ToRaw(IDataWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            writer.WriteByte(Header);
            writer.WriteByte(FileVersion);
            writer.WriteUInt((uint)_mMapElements.Count);
            foreach (var element in _mMapElements)
            {
                writer.WriteInt(element.Key);
                writer.WriteByte((byte)element.Value.GraphicalElementType);
                element.Value.ToRaw(writer, FileVersion);
            }
            if (FileVersion >= 8)
            {
                writer.WriteInt(_mJpgList.Count);
                foreach (var gfxId in _mJpgList)
                {
                    writer.WriteInt(gfxId);
                }
            }
        }
    }
}
