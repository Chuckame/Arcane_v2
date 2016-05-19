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
    [DofusMinVersion("2.0")]
    internal class LocalizationFile : AbstractI18nFile
    {
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
