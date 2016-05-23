

















// Generated on 05/22/2016 17:50:28
using System;
using System.Collections.Generic;
using Dofus.Files.GameData;

namespace Arcane.Protocol.Datacenter
{

[D2OClass(CensoredWord.MODULE)]
    
public class CensoredWord : IDataObject
{

private const String MODULE = "CensoredWords";
        public uint id;
        public uint listId;
        public String language;
        public String word;
        public Boolean deepLooking;
        

}

}