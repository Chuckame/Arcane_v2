using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Dofus.Files.Exceptions;
using Dofus.IO;
using Dofus.Files.Common;

//namespace Dofus.Files.Localization
//{
//[DofusMinVersion("2.31")]
//internal class LocalizationFile2 : AbstractI18nFile
//{
//    public override void FromRaw(IDataReader reader)
//    {
//        if (reader == null)
//            throw new ArgumentNullException(nameof(reader));
//        _mIndexedTexts.Clear();
//        _mNamedTexts.Clear();
//        var unDiacriticalIndex = new Dictionary<int, string>();
//        var textSortIndex = new Dictionary<int, int>();
//        using (var dataReader = DofusIOUtils.CreateBigEndianReader(reader.Data))
//        {
//            var textsInfosPosition = reader.ReadInt();
//            reader.SetPosition(textsInfosPosition);
//            var textsCount = reader.ReadInt();
//            for (int i = 0; i < textsCount; i += 9)
//            {
//                var id = reader.ReadInt();
//                if (id > _mLastId)
//                    _mLastId = id;
//                var flag = reader.ReadBoolean();
//                var textPos = reader.ReadInt();
//                int unDiacriticalIndexPosition;
//                if (flag)
//                {
//                    i += 4;
//                    unDiacriticalIndexPosition = reader.ReadInt();
//                    //dataReader.SetPosition(unDiacriticalIndexPosition);
//                    //unDiacriticalIndex.Add(unDiacriticalIndexPosition, dataReader.ReadUTF());
//                }
//                else
//                {
//                    unDiacriticalIndexPosition = textPos;
//                }

//                dataReader.SetPosition(textPos);
//                _mIndexedTexts.Add(id, dataReader.ReadUTF());
//            }
//            long loc5 = reader.ReadInt();
//            while (loc5 > 0)
//            {
//                var loc10 = reader.Position;
//                var loc11 = reader.ReadUTF();
//                var loc7 = reader.ReadInt();
//                dataReader.SetPosition(loc7);
//                _mNamedTexts.Add(loc11, dataReader.ReadUTF());
//                loc5 -= reader.Position - loc10;
//            }
//            loc5 = reader.ReadInt();
//            var loc9 = 0;
//            while (loc5 > 0)
//            {
//                var loc10 = reader.Position;
//                textSortIndex[reader.ReadInt()] = ++loc9;
//                loc5 -= reader.Position - loc10;
//            }
//        }
//    }
//    public override void ToRaw(IDataWriter writer)
//    {
//        throw new NotImplementedException();
//    }
//}
//}
