using Dofus.IO;

namespace Dofus.Files.Elements.SubTypes
{
    public class EntityGraphicalElementData : GraphicalElementData
    {
        public override GraphicalElementTypesEnum GraphicalElementType
        {
            get
            {
                return GraphicalElementTypesEnum.Entity;
            }
        }
        public string EntityLook
        { get; set; }
        public bool HorizontalSymmetry
        { get; set; }
        public bool PlayAnimation
        { get; set; }
        public bool PlayAnimStatic
        { get; set; }
        public int MinDelay
        { get; set; }
        public int MaxDelay
        { get; set; }

        internal EntityGraphicalElementData()
        {
        }
        internal EntityGraphicalElementData(int elementId)
            : base(elementId)
        {
        }

        public override void FromRaw(IDataReader reader, int fileVersion)
        {
            this.EntityLook = reader.ReadUTFBytes((ushort)reader.ReadInt());
            this.HorizontalSymmetry = reader.ReadBoolean();
            if (fileVersion >= 7)
            {
                this.PlayAnimation = reader.ReadBoolean();
            }
            if (fileVersion >= 6)
            {
                this.PlayAnimStatic = reader.ReadBoolean();
            }
            if (fileVersion >= 5)
            {
                this.MinDelay = reader.ReadInt();
                this.MaxDelay = reader.ReadInt();
            }
        }

        public override void ToRaw(IDataWriter writer, int fileVersion)
        {
            writer.WriteInt(this.EntityLook.Length);
            writer.WriteUTF(this.EntityLook);
            writer.WriteBoolean(this.HorizontalSymmetry);
            if (fileVersion >= 7)
            {
                writer.WriteBoolean(this.PlayAnimation);
            }
            if (fileVersion >= 6)
            {
                writer.WriteBoolean(this.PlayAnimStatic);
            }
            if (fileVersion >= 5)
            {
                writer.WriteInt(this.MinDelay);
                writer.WriteInt(this.MaxDelay);
            }
        }
    }
}
