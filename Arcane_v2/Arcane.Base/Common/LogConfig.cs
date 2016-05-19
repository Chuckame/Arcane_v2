using Arcane.Base.Entities;
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
    public static class LogConfig
    {
        public static void Initialize()
        {
            var config = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);
            consoleTarget.Layout = @"${threadid}|${longdate}|${level}|${callsite}()|${message}";
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);
            LogManager.Configuration= config;
        }
    }
}
