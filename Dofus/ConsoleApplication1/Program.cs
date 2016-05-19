using System;
using System.Text;
using Dofus.Files.Elements;
using Dofus.Files.Elements.SubTypes;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var elementsFile = Dofus.Files.Utils.DofusFilesUtils.CreateElementsFile();
            elementsFile.Load(@"D:\Program Files (x86)\Ankama\Dofus\app\content\maps\elements.ele");
            var u = elementsFile.Count();
            var tableName = "dwe_elements";
            var sb = new StringBuilder();
            foreach (var it in elementsFile.GetElementsList())
            {
                if (it is NormalGraphicalElementData)
                {
                    if (it.GraphicalElementType == GraphicalElementTypesEnum.Normal)
                    {
                        var item = it as NormalGraphicalElementData;
                        sb.AppendFormat("INSERT INTO {0} id,gfx,height,horizontalSymmetry,ox,oy,sx,sy,layer VALUES ({1});", tableName, string.Join(",", item.ElementId, item.GfxId, item.Height, item.HorizontalSymmetry, item.Origin.X, item.Origin.Y, item.Size.X, item.Size.Y, 2));
                    }
                    sb.AppendLine();
                }
            }
            Console.Write(sb);
            Console.ReadLine();
        }
    }
}
