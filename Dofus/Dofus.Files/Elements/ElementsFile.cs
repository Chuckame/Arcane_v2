using Dofus.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dofus.Files.Exceptions;
using Dofus.Files.Utils;
using Dofus.Files.Common;
using System.Collections;
using Dofus.Files.Elements.ElementTypes;

namespace Dofus.Files.Elements
{
    internal class ElementsFile : AbstractDofusFile, IElementsFile
    {
        public static readonly byte HEADER = 69;
        private readonly IDictionary<int, GraphicalElementData> _elements;

        private readonly ICollection<int> _jpgList;

        public ElementsFile()
        {
            _jpgList = new LinkedList<int>();
            _elements = new Dictionary<int, GraphicalElementData>();
        }

        public override DofusFileTypeEnum DofusFileType
        {
            get
            {
                return DofusFileTypeEnum.MapElements;
            }
        }
        public byte FileVersion { get; set; }

        public bool ElementExists(int elementId)
        {
            return _elements.ContainsKey(elementId);
        }

        public GraphicalElementData this[int elementId]
        {
            get
            {
                return GetElementData(elementId);
            }
        }

        public GraphicalElementData GetElementData(int elementId)
        {
            return ElementExists(elementId) ? _elements[elementId] : null;
        }

        public bool IsJpg(int gfxId)
        {
            return _jpgList.Contains(gfxId);
        }
        public void SetIsJpg(int gfxId, bool isJpg = true)
        {
            if (isJpg && !IsJpg(gfxId))
                _jpgList.Add(gfxId);
            else if (!isJpg && IsJpg(gfxId))
                _jpgList.Remove(gfxId);
        }

        public override void FromRaw(IDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            var header = reader.ReadByte();
            if (header != HEADER)
            {
                try
                {
                    var data = reader.Data;
                    reader = DofusIOUtils.CreateBigEndianReader(ZipHelper.Uncompress(data));
                    header = reader.ReadByte();
                }
                catch (Exception ex)
                {
                    throw new FileLoadException("Wrong header file", ex);
                }
                if (header != HEADER)
                    throw new FileLoadException("Wrong header file");
            }
            try
            {
                FileVersion = reader.ReadByte();
                var elementsCount = reader.ReadUInt();
                _elements.Clear();
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
                        var ed = GraphicalElementDataFactory.GetGraphicalElementData(edType, edId, this);
                        ed.ReadFrom(reader);
                        _elements.Add(edId, ed);
                    }
                    else
                    {
                        var pos = reader.Position;
                        var edType = (GraphicalElementTypesEnum)reader.ReadByte();
                        var ed = GraphicalElementDataFactory.GetGraphicalElementData(edType, edId, this);
                        ed.ReadFrom(reader);
                        _elements.Add(edId, ed);
                        reader.SetPosition(pos + skypLen - 4);
                    }
                }
                if (FileVersion >= 8)
                {
                    var gfxCount = reader.ReadInt();
                    _jpgList.Clear();
                    for (int i = 0; i < gfxCount; i++)
                    {
                        var gfxId = reader.ReadInt();
                        _jpgList.Add(gfxId);
                    }
                }
            }
            catch (Exception e)
            {
                throw new FileLoadException("Error during the file parsing.", e);
            }
        }

        public override void ToRaw(IDataWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            writer.WriteByte(HEADER);
            writer.WriteByte(FileVersion);
            writer.WriteUInt((uint)_elements.Count);
            foreach (var element in _elements.Values)
            {
                writer.WriteInt(element.ElementId);
                writer.WriteByte((byte)element.GraphicalElementType);
                element.WriteTo(writer);
            }
            if (FileVersion >= 8)
            {
                writer.WriteInt(_jpgList.Count);
                foreach (var gfxId in _jpgList)
                {
                    writer.WriteInt(gfxId);
                }
            }
        }

        public override string ToString()
        {
            return $"ElementsFile(Count:{Count})";
        }

        #region ICollection<> members
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public int Count
        {
            get
            {
                return _elements.Count;
            }
        }


        public void Add(GraphicalElementData element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            if (Contains(element))
                throw new AlreadyExistsException();
            _elements.Add(element.ElementId, element);
        }
        public void Clear()
        {
            _elements.Clear();
        }

        public bool Contains(GraphicalElementData item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return _elements.ContainsKey(item.ElementId);
        }

        public void CopyTo(GraphicalElementData[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            _elements.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<GraphicalElementData> GetEnumerator()
        {
            return _elements.Values.GetEnumerator();
        }

        public bool Remove(GraphicalElementData item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return _elements.Remove(item.ElementId);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.Values.GetEnumerator();
        }
        #endregion
    }
}
