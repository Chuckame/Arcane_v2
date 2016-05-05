﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.IO.TCP.Messages
{
    public delegate void MessageHandler<in TMessage>(TMessage message) where TMessage : IMessage;
}
