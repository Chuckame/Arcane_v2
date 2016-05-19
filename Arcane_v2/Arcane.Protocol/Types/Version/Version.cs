


















// Generated on 05/16/2016 23:27:40
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class Version : AbstractType
{

public const short Id = 11;
public override short TypeId { get { return Id; } }

public sbyte major;
        public sbyte minor;
        public sbyte release;
        public ushort revision;
        public sbyte patch;
        public sbyte buildType;
        

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
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(major);
            writer.WriteSByte(minor);
            writer.WriteSByte(release);
            writer.WriteUShort(revision);
            writer.WriteSByte(patch);
            writer.WriteSByte(buildType);
            

}

public override void Deserialize(IDataReader reader)
{

major = reader.ReadSByte();
            if (major < 0)
                throw new Exception("Forbidden value on major = " + major + ", it doesn't respect the following condition : major < 0");
            minor = reader.ReadSByte();
            if (minor < 0)
                throw new Exception("Forbidden value on minor = " + minor + ", it doesn't respect the following condition : minor < 0");
            release = reader.ReadSByte();
            if (release < 0)
                throw new Exception("Forbidden value on release = " + release + ", it doesn't respect the following condition : release < 0");
            revision = reader.ReadUShort();
            if (revision < 0 || revision > 65535)
                throw new Exception("Forbidden value on revision = " + revision + ", it doesn't respect the following condition : revision < 0 || revision > 65535");
            patch = reader.ReadSByte();
            if (patch < 0)
                throw new Exception("Forbidden value on patch = " + patch + ", it doesn't respect the following condition : patch < 0");
            buildType = reader.ReadSByte();
            if (buildType < 0)
                throw new Exception("Forbidden value on buildType = " + buildType + ", it doesn't respect the following condition : buildType < 0");
            

}


}


}