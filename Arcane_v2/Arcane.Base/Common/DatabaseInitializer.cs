using Arcane.Base.Entities;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Castle.ActiveRecord.Framework.Internal.HasManyToAnyModel;

namespace Arcane.Base.Common
{
    public static class DatabaseInitializer
    {
        public static void Initialize(params Assembly[] assemblies)
        {
            ActiveRecordStarter.Initialize(assemblies, new XmlConfigurationSource(CommonConfig.DatabaseConfigFileName));
            ActiveRecordStarter.UpdateSchema();
        }
    }
}
