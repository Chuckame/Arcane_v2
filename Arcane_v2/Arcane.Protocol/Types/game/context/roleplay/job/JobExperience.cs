


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class JobExperience : AbstractType
{

public const short Id = 98;
public override short TypeId { get { return Id; } }

public sbyte jobId;
        public sbyte jobLevel;
        public double jobXP;
        public double jobXpLevelFloor;
        public double jobXpNextLevelFloor;
        

public JobExperience()
{
}

public JobExperience(sbyte jobId, sbyte jobLevel, double jobXP, double jobXpLevelFloor, double jobXpNextLevelFloor)
        {
            this.jobId = jobId;
            this.jobLevel = jobLevel;
            this.jobXP = jobXP;
            this.jobXpLevelFloor = jobXpLevelFloor;
            this.jobXpNextLevelFloor = jobXpNextLevelFloor;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(jobId);
            writer.WriteSByte(jobLevel);
            writer.WriteDouble(jobXP);
            writer.WriteDouble(jobXpLevelFloor);
            writer.WriteDouble(jobXpNextLevelFloor);
            

}

public override void Deserialize(IDataReader reader)
{

jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            jobLevel = reader.ReadSByte();
            if (jobLevel < 0)
                throw new Exception("Forbidden value on jobLevel = " + jobLevel + ", it doesn't respect the following condition : jobLevel < 0");
            jobXP = reader.ReadDouble();
            if (jobXP < 0)
                throw new Exception("Forbidden value on jobXP = " + jobXP + ", it doesn't respect the following condition : jobXP < 0");
            jobXpLevelFloor = reader.ReadDouble();
            if (jobXpLevelFloor < 0)
                throw new Exception("Forbidden value on jobXpLevelFloor = " + jobXpLevelFloor + ", it doesn't respect the following condition : jobXpLevelFloor < 0");
            jobXpNextLevelFloor = reader.ReadDouble();
            if (jobXpNextLevelFloor < 0)
                throw new Exception("Forbidden value on jobXpNextLevelFloor = " + jobXpNextLevelFloor + ", it doesn't respect the following condition : jobXpNextLevelFloor < 0");
            

}


}


}