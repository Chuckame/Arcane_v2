﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuckame.IO.TCP.Messages
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class MessageHandlerAttribute : Attribute
    {
        public MessageHandlerAttribute()
        {
        }
    }
}
