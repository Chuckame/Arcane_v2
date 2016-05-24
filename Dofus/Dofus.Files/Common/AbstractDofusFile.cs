using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;
using Dofus.Files.Exceptions;

namespace Dofus.Files.Common
{
    public abstract class AbstractDofusFile : IDofusFile
    {
        public abstract DofusFileTypeEnum DofusFileType
        {
            get;
        }

        public void Load(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException();
            using (var fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = DofusIOUtils.CreateBigEndianReader(fStream))
                {
                    FromRaw(reader);
                }
            }
        }

        public void FromBytes(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));
            using (var reader = DofusIOUtils.CreateBigEndianReader(bytes))
            {
                FromRaw(reader);
            }
        }

        public void Save(string path, bool @override = false)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (@override && File.Exists(path))
                File.Delete(path);
            if (!@override && File.Exists(path))
                throw new AlreadyExistsException("Un fichier du même nom existe déjà.");
            File.WriteAllBytes(path, ToBytes());
        }

        public byte[] ToBytes()
        {
            byte[] result;
            using (IDataWriter writer = DofusIOUtils.CreateBigEndianWriter())
            {
                ToRaw(writer);
                result = writer.Data;
            }
            return result;
        }

        public abstract void FromRaw(IDataReader reader);

        public abstract void ToRaw(IDataWriter writer);
    }
}
