using Arcane.Base.Network.GameLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections.ObjectModel;

namespace Arcane.Game.Network.GameLink
{
    public class TicketManager
    {
        private HashSet<TicketEntity> _tickets = new HashSet<TicketEntity>();

        public TicketEntity UseTicket(string ticket)
        {
            var tick = _tickets.FirstOrDefault(t => t.Ticket.Equals(ticket));
            if (tick == null)
                throw new UnknownTicketException();
            _tickets.Remove(tick);
            if ((DateTime.Now - tick.CreationDate) > Config.TicketExpirationTime)
                throw new TicketExpiredException();
            return tick;
        }

        public void AddTicket(TicketEntity ticket)
        {
            _tickets.Remove(ticket);
            _tickets.Add(ticket);
        }

        public bool ExistsTicket(string ticket)
        {
            return _tickets.Any(t => t.Ticket.Equals(ticket));
        }

        [Serializable]
        public class UnknownTicketException : TicketException
        {
        }

        [Serializable]
        public class TicketExpiredException : TicketException
        {
        }

        [Serializable]
        public class TicketException : Exception
        {
        }
    }
}