using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Dofus.Files.Exceptions;
using Dofus.IO;
using Dofus.Files.Common;

namespace Dofus.Files.Packed
{
    internal class PackedFile : AbstractDofusFile, IPackedFile
    {
        private static readonly byte[] HEADER = { 2, 1 };
        public override DofusFileTypeEnum DofusFileType
        {
            get
            {
                return DofusFileTypeEnum.Container;
            }
        }
        public PackedFile()
        {
            Files = new ReadOnlyDictionary<string, byte[]>(_mFiles);
        }

        private readonly IDictionary<string, byte[]> _mFiles = new Dictionary<string, byte[]>();
        public IReadOnlyDictionary<string, byte[]> Files { get; }
        public byte[] this[string fileName]
        {
            get { return GetFile(fileName); }
            set { SetFile(fileName, value); }
        }

        public string LinkedFileName
        { get; set; }

        public void AddFile(string fileName, byte[] data)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            var filePath = fileName.Replace('\\', '/');
            if (!IsValidFileName(filePath))
                throw new ArgumentException("Not valid", nameof(fileName));
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (Contains(filePath))
                throw new AlreadyExistsException(string.Format("'{0}' already exists.", filePath));
            _mFiles.Add(filePath, data);
        }

        public void AddFile(string fileName, string srcFilePath)
        {
            if (srcFilePath == null)
                throw new ArgumentNullException(nameof(srcFilePath));
            if (!File.Exists(srcFilePath))
                throw new FileNotFoundException(null, srcFilePath);
            AddFile(fileName, File.ReadAllBytes(srcFilePath));
        }

        public void AddFile(string fileName, Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            stream.Seek(0, SeekOrigin.Begin);
            var buff = new byte[stream.Length];
            stream.Read(buff, 0, buff.Length);
            AddFile(fileName, buff);
        }

        public void AddFile(string fileName, IDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            AddFile(fileName, reader.Data);
        }

        public void SetFile(string fileName, byte[] data)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            var filePath = fileName.Replace('\\', '/');
            if (!Contains(filePath))
                throw new FileNotFoundException(null, fileName);
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            _mFiles[filePath] = data;
        }

        public byte[] GetFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            var filePath = fileName.Replace('\\', '/');
            if (!Contains(filePath))
                throw new FileNotFoundException(null, fileName);
            return _mFiles[filePath];
        }

        public bool Remove(string fileName)
        {
            if (Contains(fileName))
            {
                return _mFiles.Remove(fileName);
            }
            return false;
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
                throw new Exception("Malformated d2p file.");
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
                AddFile(item.Key, reader.ReadBytes(item.Value.Item2));
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

                foreach (var fileItem in this._mFiles)
                {
                    filesInfosWriter.WriteUTF(fileItem.Key);
                    filesInfosWriter.WriteInt((int)(writer.Position - HEADER.Length));
                    filesInfosWriter.WriteInt(fileItem.Value.Length);
                    writer.WriteBytes(fileItem.Value);
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

        public static bool IsValidFileName(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            var filePath = fileName.Replace('\\', '/');
            return filePath.Length > 0 && filePath[0] != '/';
        }
    }
}
