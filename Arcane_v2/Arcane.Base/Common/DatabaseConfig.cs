using Arcane.Base.Entities;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Common
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            ActiveRecordStarter.Initialize(typeof(Account).Assembly, new XmlConfigurationSource("database.xml"));
            ActiveRecordStarter.UpdateSchema();
        }
    }
}
