using Dofus.IO;

namespace Dofus.Files.Elements.SubTypes
{
    public class AnimatedGraphicalElementData : NormalGraphicalElementData
    {
        public int MinDelay
        { get; set; }
        public int MaxDelay
        { get; set; }

        internal AnimatedGraphicalElementData()
        {
        }
        internal AnimatedGraphicalElementData(int elementId)
            : base(elementId)
        {
        }

        public override void FromRaw(IDataReader reader, int fileVersion)
        {
            base.FromRaw(reader, fileVersion);
            if (fileVersion == 4)
            {
                this.MinDelay = reader.ReadInt();
                this.MaxDelay = reader.ReadInt();
            }
        }

        public override void ToRaw(IDataWriter writer, int fileVersion)
        {
            base.ToRaw(writer, fileVersion);
            if (fileVersion == 4)
            {
                writer.WriteInt(this.MinDelay);
                writer.WriteInt(this.MaxDelay);
            }
        }
    }
}
