


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage
{

public new const uint Id = 6113;
public override uint MessageId
{
    get { return Id; }
}

public int boostUID;
        

public GameActionFightDispellEffectMessage()
{
}

public GameActionFightDispellEffectMessage(short actionId, int sourceId, int targetId, int boostUID)
         : base(actionId, sourceId, targetId)
        {
            this.boostUID = boostUID;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(boostUID);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            boostUID = reader.ReadInt();
            if (boostUID < 0)
                throw new Exception("Forbidden value on boostUID = " + boostUID + ", it doesn't respect the following condition : boostUID < 0");
            

}


}


}