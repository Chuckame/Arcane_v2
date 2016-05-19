


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AuthenticationTicketWithClientPacksMessage : AuthenticationTicketMessage
{

public new const uint Id = 6190;
public override uint MessageId
{
    get { return Id; }
}

public int[] packs;
        

public AuthenticationTicketWithClientPacksMessage()
{
}

public AuthenticationTicketWithClientPacksMessage(string lang, string ticket, int[] packs)
         : base(lang, ticket)
        {
            this.packs = packs;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort((ushort)packs.Length);
            foreach (var entry in packs)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            var limit = reader.ReadUShort();
            packs = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 packs[i] = reader.ReadInt();
            }
            

}


}


}