using Arcane.Base.Entities;
using Arcane.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Helpers
{
    public static class ConnectionHelper
    {
        public static IdentificationSuccessMessage MakeIdentificationSuccessMessage(Account account, bool wasAlreadyConnected)
        {
            return new IdentificationSuccessMessage(account.IsAdmin, wasAlreadyConnected, account.Login, account.Nickname, account.Id, account.Community.ToSByte(), account.SecretQuestion, account.SubscriptionEndDate.ToDofusTimestamp(), account.AccountCreationDate.ToDofusTimestamp());
        }
    }
}
