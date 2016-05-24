using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dofus.Files.Dofus.Files.Common
{
    public interface IXmlSerializable
    {
        XElement ToXml();
    }
}
