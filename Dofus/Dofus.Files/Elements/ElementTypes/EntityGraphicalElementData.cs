using Dofus.IO;

namespace Dofus.Files.Elements.ElementTypes
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
        public string EntityLook { get; set; }
        public bool HorizontalSymmetry { get; set; }
        public bool PlayAnimation { get; set; }
        public bool PlayAnimStatic { get; set; }
        public int MinDelay { get; set; }
        public int MaxDelay { get; set; }

        public EntityGraphicalElementData(int elementId, IElementsFile elementsFile)
            : base(elementId, elementsFile)
        {
        }

        public override void ReadFrom(IDataReader reader)
        {
            this.EntityLook = reader.ReadUTFBytes((ushort)reader.ReadInt());
            this.HorizontalSymmetry = reader.ReadBoolean();
            if (ElementsFile.FileVersion >= 7)
            {
                this.PlayAnimation = reader.ReadBoolean();
            }
            if (ElementsFile.FileVersion >= 6)
            {
                this.PlayAnimStatic = reader.ReadBoolean();
            }
            if (ElementsFile.FileVersion >= 5)
            {
                this.MinDelay = reader.ReadInt();
                this.MaxDelay = reader.ReadInt();
            }
        }

        public override void WriteTo(IDataWriter writer)
        {
            writer.WriteInt(this.EntityLook.Length);
            writer.WriteUTF(this.EntityLook);
            writer.WriteBoolean(this.HorizontalSymmetry);
            if (ElementsFile.FileVersion >= 7)
            {
                writer.WriteBoolean(this.PlayAnimation);
            }
            if (ElementsFile.FileVersion >= 6)
            {
                writer.WriteBoolean(this.PlayAnimStatic);
            }
            if (ElementsFile.FileVersion >= 5)
            {
                writer.WriteInt(this.MinDelay);
                writer.WriteInt(this.MaxDelay);
            }
        }
    }
}
