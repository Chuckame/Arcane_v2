using Arcane.Base.Entities;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Database
{
    public class Database
    {
        public static void Init()
        {
            ActiveRecordStarter.Initialize(new XmlConfigurationSource("login_database.xml"), typeof(Account));
            ActiveRecordStarter.UpdateSchema();
        }
    }
}
