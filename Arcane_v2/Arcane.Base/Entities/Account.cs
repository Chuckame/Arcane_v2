using Arcane.Base.Enums;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Entities
{
    [ActiveRecord("accounts", "heart_emu_login")]
    public class Account : ActiveRecordLinqBase<Account>
    {
        [Property("account_creation_date", NotNull = true)]
        public DateTime AccountCreationDate { get; set; }

        [Property("banned_end_date")]
        public DateTime? BannedEndDate { get; set; }

        [Property("community", NotNull = true)]
        public ServerCommunitiesEnum Community { get; set; }

        [HasAndBelongsToMany(Schema = "heart_emu_login", ColumnKey = "owner_id", ColumnRef = "friend_account_id", Table = "friends", Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public IList<Account> Friends { get; private set; }

        [PrimaryKey("account_id", Generator = PrimaryKeyType.Identity)]
        public int Id { get; private set; }

        [Property("is_admin", NotNull = true)]
        public bool IsAdmin { get; set; }

        [Property("last_connection_date")]
        public DateTime? LastConnectionDate { get; set; }

        [Property("last_connection_ip", Length = 50)]
        public string LastConnectionIp { get; set; }

        [Property("login", NotNull = true, Length = 30)]
        public string Login { get; set; }

        [Property("nickname", Length = 30)]
        public string Nickname { get; set; }

        [Property("password", NotNull = true, Length = 50)]
        public string Password { get; set; }

        [Property("secret_question", NotNull = true, Length = 100)]
        public string SecretQuestion { get; set; }

        [Property("secret_response", NotNull = true, Length = 100)]
        public string SecretResponse { get; set; }

        [Property("subscription_end_date")]
        public DateTime? SubscriptionEndDate { get; set; }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            var other = obj as Account;
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public bool HasNickname()
        {
            return !string.IsNullOrWhiteSpace(Nickname);
        }

        public bool IsBanned()
        {
            return BannedEndDate.HasValue && DateTime.Now <= BannedEndDate.Value;
        }

        public override string ToString()
        {
            return $"Account({Login}#{Id})";
        }
    }
}
