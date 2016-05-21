using System;

namespace Arcane.Game.Network.GameLink
{
    public class TicketEntity : IEquatable<TicketEntity>
    {
        public int AccountId { get; }
        public string Ticket { get; }
        public DateTime CreationDate { get; }

        public TicketEntity(int accountId, string ticket)
        {
            AccountId = accountId;
            Ticket = ticket;
            CreationDate = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as TicketEntity);
        }

        public bool Equals(TicketEntity other)
        {
            return this.Ticket.Equals(other.Ticket);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            var hash = 13;
            hash = (hash * 7) + Ticket.GetHashCode();
            return hash;
        }
    }
}