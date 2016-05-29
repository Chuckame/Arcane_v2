using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Entities
{
    [ActiveRecord("characters_items", "heart_emu_game")]
    public class CharacterItemEntity : ActiveRecordLinqBase<ExperienceStepEntity>
    {
        [PrimaryKey("id", Generator = PrimaryKeyType.Identity)]
        public int Id { get; private set; }

        [BelongsTo("owner_id", NotNull = true)]
        public CharacterEntity Owner { get; set; }

        [Property("item_id", NotNull = true)]
        public int ItemId { get; set; }

        [Property("quantity", NotNull = true)]
        public int Quantity { get; set; }
    }
}
