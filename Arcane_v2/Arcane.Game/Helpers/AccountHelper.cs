using Arcane.Base.Entities;
using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Helpers
{
    public static class AccountHelper
    {
        public static Account GetAccountByNickname(string nickname)
        {
            using (new SessionScope())
            {
                nickname = nickname.ToLowerInvariant();
                return Account.Queryable.FirstOrDefault(a => a.Nickname.ToLowerInvariant().Equals(nickname));
            }
        }
    }
}
