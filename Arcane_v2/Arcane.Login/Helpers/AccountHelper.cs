using Arcane.Base.Entities;
using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Helpers
{
    public static class AccountHelper
    {
        public static Account GetAccountByLogin(string login)
        {
            using (new SessionScope())
            {
                return Account.Queryable.FirstOrDefault(x => x.Login.Equals(login));
            }
        }
        public static void UpdateLastConnection(this Account account, IPAddress ip, DateTime date)
        {
            using (new SessionScope())
            {
                account.LastConnectionDate = date;
                account.LastConnectionIp = ip.ToString();
                account.Update();
            }
        }

        internal static bool NicknameAlreadyExists(string newNickname)
        {
            using (new SessionScope())
            {
                return Account.Queryable.Any(a => a.Nickname != null && newNickname.ToUpperInvariant().Equals(a.Nickname.ToUpperInvariant()));
            }
        }

        internal static void UpdateNickname(this Account account, string newNickname)
        {
            using (new SessionScope())
            {
                account.Nickname = newNickname;
                account.Update();
            }
        }
    }
}
