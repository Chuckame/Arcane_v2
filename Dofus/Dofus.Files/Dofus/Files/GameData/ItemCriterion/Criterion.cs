using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.GameData.ItemCriterion
{
    public class Criterion
    {
        enum CriterionOperatorEnum
        {
            AND = '&',
            OR = '|',
        }
        private const char PARENTHESIS_IN = '(';
        private const char PARENTHESIS_OUT = ')';
        public CriterionEnum CriterionType { get; set; }
        public CriterionRealName CriterionName { get { return (CriterionRealName)CriterionType; } }
        public CriterionComparatorEnum Comparator { get; set; }
        public string Value { get; set; }
        public Criterion(CriterionEnum criterionType, CriterionComparatorEnum comparator, string value)
        {
            CriterionType = criterionType;
            Comparator = comparator;
            Value = value;
        }
        public static Criterion ParseString(string str)
        {
            if (str.Contains((char)CriterionOperatorEnum.AND) || str.Contains((char)CriterionOperatorEnum.OR) || str.Contains(PARENTHESIS_IN) || str.Contains(PARENTHESIS_OUT))
                throw new Exception();
            CriterionEnum crit = 0;
            CriterionComparatorEnum comp = 0;
            string val = "";
            foreach (var critComp in CriterionReader.Comparators)
            {
                if (str[2] == (char)critComp)
                {
                    crit = (CriterionEnum)Enum.Parse(typeof(CriterionEnum), str.Substring(0, 2));
                    val = str.Substring(3, str.Length - 3);
                    comp = (CriterionComparatorEnum)critComp;
                    return new Criterion(crit, comp, val);
                }
            }
            throw new Exception("Le critère est invalide !");
        }
        public bool CompareInt(int value)
        {
            switch (Comparator)
            {
                case CriterionComparatorEnum.SUPERIOR:
                    return value > int.Parse(Value);
                case CriterionComparatorEnum.INFERIOR:
                    return value < int.Parse(Value);
                case CriterionComparatorEnum.EQUAL:
                    return value == int.Parse(Value);
                case CriterionComparatorEnum.DIFFERENT:
                    return value != int.Parse(Value);
                default:
                    throw new Exception("unknown comparator !");
            }
        }
        public bool CompareString(string value)
        {
            switch (Comparator)
            {
                case CriterionComparatorEnum.EQUAL:
                    return value == Value;
                case CriterionComparatorEnum.EQUAL_ToLower:
                    return value.ToLower() == Value.ToLower();
                case CriterionComparatorEnum.StartWith_ToLower:
                    return value.ToLower().First() == Value.ToLower().First();
                case CriterionComparatorEnum.StartWith:
                    return value.First() == Value.First();
                case CriterionComparatorEnum.EndWith_ToLower:
                    return value.ToLower().Last() == Value.ToLower().Last();
                case CriterionComparatorEnum.EndWith:
                    return value.Last() == Value.Last();
                case CriterionComparatorEnum.DIFFERENT:
                    return value != Value;
                default:
                    throw new Exception("unknown comparator !");
            }
        }
        public bool Compare(string value)
        {
            int parsed;
            int.TryParse(value, out parsed);
            if (int.TryParse(value, out parsed))
                return CompareInt(parsed);
            return CompareString(value);
        }

        public override string ToString()
        {
            string str = "";
            if (Enum.IsDefined(typeof(CriterionRealName), this.CriterionName.ToString()))
            {
                str = "(" + CriterionType + ")" + CriterionName;
            }
            else
            {
                str = CriterionType.ToString();
            }
            return string.Format("{0} {1} {2}", str, (char)this.Comparator, this.Value);
        }
    }
}
