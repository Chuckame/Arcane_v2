﻿#region License GNU GPL
// DnsExtensions.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Dofus.Common.Extensions
{
    public class DnsExtensions
    {
        public static IPEndPoint GetIPEndPointFromHostName(string hostName, int port, bool throwIfMoreThanOneIP = true)
        {
            var addresses = Dns.GetHostAddresses(hostName);
            if (addresses.Length == 0)
            {
                throw new ArgumentException("Unable to retrieve address from specified host name.", nameof(hostName));
            }

            if (throwIfMoreThanOneIP && addresses.Length > 1 && addresses.Distinct().Count() > 1)
            {
                throw new ArgumentException("There is more that one IP address to the specified host.", nameof(hostName));
            }

            return new IPEndPoint(addresses[0], port); // Port gets validated here.
        }

        public static IPEndPoint GetIPEndPointFromHostName(string hostName, int port, AddressFamily addressFamily, bool throwIfMoreThanOneIP = true)
        {
            var addresses = Dns.GetHostAddresses(hostName).Where(entry => entry.AddressFamily == addressFamily).ToArray();
            if (addresses.Length == 0)
            {
                throw new ArgumentException("Unable to retrieve address from specified host name.", nameof(hostName));
            }

            if (throwIfMoreThanOneIP && addresses.Length > 1 && addresses.Distinct().Count() > 1)
            {
                throw new ArgumentException("There is more that one IP address to the specified host.", nameof(hostName));
            }

            return new IPEndPoint(addresses[0], port); // Port gets validated here.
        }
    }
}