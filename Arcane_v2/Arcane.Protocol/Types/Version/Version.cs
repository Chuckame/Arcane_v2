using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;

namespace Arcane.Protocol.Types.Version
{
    public class Version : AbstractType
    {
        public sbyte buildType;
        public const uint Id = 11;
        public sbyte major;
        public sbyte minor;
        public sbyte patch;
        public sbyte release;
        public ushort revision;

        public Version()
        {
        }

        public Version(sbyte major, sbyte minor, sbyte release, ushort revision, sbyte patch, sbyte buildType)
        {
            this.major = major;
            this.minor = minor;
            this.release = release;
            this.revision = revision;
            this.patch = patch;
            this.buildType = buildType;
        }

        public override void Deserialize(IDataReader reader)
        {
            this.major = reader.ReadSByte();
            if (this.major < 0)
            {
                throw new Exception("Forbidden value on major = " + this.major + ", it doesn't respect the following condition : major < 0");
            }
            this.minor = reader.ReadSByte();
            if (this.minor < 0)
            {
                throw new Exception("Forbidden value on minor = " + this.minor + ", it doesn't respect the following condition : minor < 0");
            }
            this.release = reader.ReadSByte();
            if (this.release < 0)
            {
                throw new Exception("Forbidden value on release = " + this.release + ", it doesn't respect the following condition : release < 0");
            }
            this.revision = reader.ReadUShort();
            if ((this.revision < 0) || (this.revision > 0xffff))
            {
                throw new Exception("Forbidden value on revision = " + this.revision + ", it doesn't respect the following condition : revision < 0 || revision > 65535");
            }
            this.patch = reader.ReadSByte();
            if (this.patch < 0)
            {
                throw new Exception("Forbidden value on patch = " + this.patch + ", it doesn't respect the following condition : patch < 0");
            }
            this.buildType = reader.ReadSByte();
            if (this.buildType < 0)
            {
                throw new Exception("Forbidden value on buildType = " + this.buildType + ", it doesn't respect the following condition : buildType < 0");
            }
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(this.major);
            writer.WriteSByte(this.minor);
            writer.WriteSByte(this.release);
            writer.WriteUShort(this.revision);
            writer.WriteSByte(this.patch);
            writer.WriteSByte(this.buildType);
        }

        public override uint TypeId
        {
            get
            {
                return Id;
            }
        }
    }
}
