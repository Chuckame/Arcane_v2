


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildInformationsPaddocksMessage : AbstractMessage
{

public const uint Id = 5959;
public override uint MessageId
{
    get { return Id; }
}

public sbyte nbPaddockMax;
        public Types.PaddockContentInformations[] paddocksInformations;
        

public GuildInformationsPaddocksMessage()
{
}

public GuildInformationsPaddocksMessage(sbyte nbPaddockMax, Types.PaddockContentInformations[] paddocksInformations)
        {
            this.nbPaddockMax = nbPaddockMax;
            this.paddocksInformations = paddocksInformations;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(nbPaddockMax);
            writer.WriteUShort((ushort)paddocksInformations.Length);
            foreach (var entry in paddocksInformations)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

nbPaddockMax = reader.ReadSByte();
            if (nbPaddockMax < 0)
                throw new Exception("Forbidden value on nbPaddockMax = " + nbPaddockMax + ", it doesn't respect the following condition : nbPaddockMax < 0");
            var limit = reader.ReadUShort();
            paddocksInformations = new Types.PaddockContentInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 paddocksInformations[i] = new Types.PaddockContentInformations();
                 paddocksInformations[i].Deserialize(reader);
            }
            

}


}


}