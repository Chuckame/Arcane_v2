using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Dofus.Files.Exceptions;
using Dofus.IO;
using Dofus.Files.Common;
using System.Collections;

namespace Dofus.Files.Packed
{
    internal class PackedFile : AbstractDofusFile, IPackedFile
    {
        private static readonly byte[] HEADER = { 2, 1 };
        private readonly Dictionary<string, PackedContainer> _mFiles;

        public override DofusFileTypeEnum DofusFileType
        {
            get
            {
                return DofusFileTypeEnum.Container;
            }
        }
        public string LinkedFileName { get; set; }

        public PackedFile()
        {
            _mFiles = new Dictionary<string, PackedContainer>();
        }

        public PackedContainer this[string fileName]
        {
            get
            {
                return _mFiles[fileName];
            }
            set
            {
                _mFiles[fileName] = value;
            }
        }

        public bool Contains(string fileName)
        {
            return _mFiles.ContainsKey(fileName);
        }

        public override void FromRaw(IDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            LinkedFileName = null;
            _mFiles.Clear();
            var header = new byte[] { reader.ReadByte(), reader.ReadByte() };
            if (header[0] != HEADER[0] || header[1] != HEADER[1])
                throw new FileLoadException("Malformated d2p file.");
            reader.SetPosition(reader.Length - 24);
            var offSet = reader.ReadUInt();
            var unused = reader.ReadUInt();
            var positionToReadFiles = reader.ReadUInt();
            var filesCount = reader.ReadUInt();
            var positionToReadD2p = reader.ReadUInt();
            var d2pLinkFilesCount = reader.ReadUInt();
            reader.SetPosition(positionToReadD2p);
            for (int index = 0; index < d2pLinkFilesCount; ++index)
            {
                var fileType = reader.ReadUTF();
                var fileName = reader.ReadUTF();
                if (fileType.Equals("link"))
                {
                    LinkedFileName = fileName;
                }
            }
            reader.SetPosition(positionToReadFiles);
            var dic = new Dictionary<string, Tuple<long, int>>();
            for (int index = 0; index < filesCount; ++index)
            {
                var _filePath = reader.ReadUTF();
                var fileReadedPositionInReader = reader.ReadInt() + offSet;
                var readedFileLength = reader.ReadInt();
                dic.Add(_filePath, new Tuple<long, int>(fileReadedPositionInReader, readedFileLength));
            }
            foreach (var item in dic)
            {
                reader.SetPosition(item.Value.Item1);
                Add(new PackedContainer { Name = item.Key, Raw = reader.ReadBytes(item.Value.Item2) });
            }
        }

        public override void ToRaw(IDataWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            using (IDataWriter generalWriter = DofusIOUtils.CreateBigEndianWriter(), filesInfosWriter = DofusIOUtils.CreateBigEndianWriter())
            {
                writer.WriteBytes(HEADER);

                generalWriter.WriteUInt((uint)HEADER.Length);//offset

                foreach (var fileItem in this._mFiles.Values)
                {
                    filesInfosWriter.WriteUTF(fileItem.Name);
                    filesInfosWriter.WriteInt((int)(writer.Position - HEADER.Length));
                    filesInfosWriter.WriteInt(fileItem.Raw.Length);
                    writer.WriteBytes(fileItem.Raw);
                }

                generalWriter.WriteUInt((uint)(writer.Position - HEADER.Length));//filesInfoPosition-2
                generalWriter.WriteUInt((uint)writer.Position);//filesInfoPosition
                generalWriter.WriteUInt((uint)this._mFiles.Count);//filesCount

                writer.WriteBytes(filesInfosWriter.Data);

                generalWriter.WriteUInt((uint)writer.Position);//propertiesPosition
                if (string.IsNullOrWhiteSpace(LinkedFileName))
                {
                    generalWriter.WriteUInt(0);//propertiesCount
                }
                else
                {
                    generalWriter.WriteUInt(1);//propertiesCount
                    writer.WriteUTF("link");
                    writer.WriteUTF(LinkedFileName);
                }

                writer.WriteBytes(generalWriter.Data);
            }
        }

        public int Count
        {
            get
            {
                return _mFiles.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(PackedContainer item)
        {
            _mFiles.Add(item.Name, item);
        }

        public void Clear()
        {
            _mFiles.Clear();
        }

        public bool Contains(PackedContainer item)
        {
            return _mFiles.ContainsKey(item.Name);
        }

        public void CopyTo(PackedContainer[] array, int arrayIndex)
        {
            _mFiles.Values.CopyTo(array, arrayIndex);
        }

        public bool Remove(PackedContainer item)
        {
            return _mFiles.Remove(item.Name);
        }

        public IEnumerator<PackedContainer> GetEnumerator()
        {
            return _mFiles.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _mFiles.Values.GetEnumerator();
        }

        public override string ToString()
        {
            return $"PackedFile(Count:{Count})";
        }
    }
}
