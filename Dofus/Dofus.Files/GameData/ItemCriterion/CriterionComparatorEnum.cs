using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.GameData.ItemCriterion
{
    public enum CriterionComparatorEnum
    {
        SUPERIOR = '>',
        INFERIOR = '<',
        EQUAL = '=',
        DIFFERENT = '!',
        EQUAL_ToLower = '~',
        StartWith_ToLower = 'S',
        StartWith = 's',
        EndWith_ToLower = 'E',
        EndWith = 'e',
        Other1 = 'v',
        Other2 = 'i',
        Other3 = '#',
        Other4 = 'X',
        Other5 = '/',
    }
}
