using Arcane.Base.Entities;
using Arcane.Protocol.Messages;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Common
{
    public static class DofusMessageBuilderInitializer
    {
        public static void Initialize()
        {
            MessageBuilder.Instance.Initialize(typeof(MessageBuilder).Assembly);
        }
    }
}
