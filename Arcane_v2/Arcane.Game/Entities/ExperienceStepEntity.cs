using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Entities
{
    [ActiveRecord("experience_steps", "heart_emu_game")]
    public class ExperienceStepEntity : ActiveRecordLinqBase<ExperienceStepEntity>
    {
        [PrimaryKey("level", Generator = PrimaryKeyType.Assigned)]
        public byte Level { get; private set; }

        [Property("`character`")]
        public double Character { get; private set; }

        [Property("job")]
        public double Job { get; private set; }

        [Property("mount")]
        public double Mount { get; private set; }

        [Property("pvp")]
        public double Pvp { get; private set; }

        [Property("guild")]
        public double Guild { get; private set; }

        private ExperienceStepEntity()
        {

        }
    }
}
