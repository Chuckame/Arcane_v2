using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Arcane.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Entities
{
    [ActiveRecord("servers", "arcane2_login")]
    public class GameServerEntity : ActiveRecordLinqBase<GameServerEntity>
    {
        [PrimaryKey("server_id")]
        public ushort Id { get; set; }

        [Property("status", NotNull = true)]
        public ServerStatusEnum Status { get; set; }

        [Property("completion", NotNull = true)]
        public sbyte Completion { get; set; }

        [Property("creation_date", NotNull = true)]
        public DateTime CreationDate { get; set; }

        [Property("host", NotNull = true)]
        public string Host { get; set; }

        [Property("port", NotNull = true)]
        public ushort Port { get; set; }
    }
}
