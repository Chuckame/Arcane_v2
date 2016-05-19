


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class IgnoredOnlineInformations : IgnoredInformations
{

public new const short Id = 105;
public override short TypeId { get { return Id; } }

public string playerName;
        public sbyte breed;
        public bool sex;
        

public IgnoredOnlineInformations()
{
}

public IgnoredOnlineInformations(int accountId, string accountName, string playerName, sbyte breed, bool sex)
         : base(accountId, accountName)
        {
            this.playerName = playerName;
            this.breed = breed;
            this.sex = sex;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUTF(playerName);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            playerName = reader.ReadUTF();
            breed = reader.ReadSByte();
            if (breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Zobal)
                throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Zobal");
            sex = reader.ReadBoolean();
            

}


}


}