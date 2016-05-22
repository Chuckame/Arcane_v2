using Arcane.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Helpers
{
    public static class ExperienceStepHelper
    {
        private static ExperienceStepEntity GetExpByLevel(byte level)
        {
            return ExperienceStepEntity.Find(level);
        }

        public static double GetCharacterExpByLevel(byte level)
        {
            return GetExpByLevel(level).Character;
        }

        public static double GetGuildExpByLevel(byte level)
        {
            return GetExpByLevel(level).Guild;
        }

        public static double GetJobExpByLevel(byte level)
        {
            return GetExpByLevel(level).Job;
        }

        public static double GetMountExpByLevel(byte level)
        {
            return GetExpByLevel(level).Mount;
        }

        public static double GetPvpExpByLevel(byte level)
        {
            return GetExpByLevel(level).Pvp;
        }

        public static byte GetCharacterLevelByExp(double exp)
        {
            return ExperienceStepEntity.Queryable.First(x => exp >= x.Character).Level;
        }

        public static byte GetGuildLevelByExp(double exp)
        {
            return ExperienceStepEntity.Queryable.First(x => exp >= x.Guild).Level;
        }

        public static byte GetJobLevelByExp(double exp)
        {
            return ExperienceStepEntity.Queryable.First(x => exp >= x.Job).Level;
        }

        public static byte GetMountLevelByExp(double exp)
        {
            return ExperienceStepEntity.Queryable.First(x => exp >= x.Mount).Level;
        }

        public static byte GetPvpLevelByExp(double exp)
        {
            return ExperienceStepEntity.Queryable.First(x => exp >= x.Pvp).Level;
        }
    }
}
