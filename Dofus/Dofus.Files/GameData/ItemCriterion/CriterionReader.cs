using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dofus.Files.GameData.ItemCriterion
{
    public class CriterionReader
    {
        private const string regex_GetParenthesis = @"\([tf\&\|]+\)";
        private static Dictionary<string, string> dicOr;
        private static Dictionary<string, string> dicAnd;
        internal static List<CriterionComparatorEnum> Comparators;
        private static bool _isInitialized;
        private static void _initialize()
        {
            if (!_isInitialized)
            {
                dicAnd = new Dictionary<string, string>();
                dicAnd.Add("t&t", "t");
                dicAnd.Add("f&t", "f");
                dicAnd.Add("t&f", "f");
                dicAnd.Add("f&f", "f");

                dicOr = new Dictionary<string, string>();
                dicOr.Add("t|t", "t");
                dicOr.Add("f|t", "t");
                dicOr.Add("t|f", "t");
                dicOr.Add("f|f", "f");

                Comparators = new List<CriterionComparatorEnum>();
                foreach (string entry in Enum.GetNames(typeof(CriterionComparatorEnum)))
                {
                    Comparators.Add((CriterionComparatorEnum)Enum.Parse(typeof(CriterionComparatorEnum), entry));
                }

                _isInitialized = true;
            }
        }
        private List<Criterion> _mCriterions;
        public Criterion[] CriterionsList { get { return _mCriterions.ToArray(); } }
        private string ResultTemplate { get; set; }
        public static CriterionReader ParseString(string criteria)
        {
            _initialize();
            var reader = new CriterionReader
            {
                _mCriterions = new List<Criterion>()
            };

            criteria = criteria.Replace(" ", "");
            if (string.IsNullOrEmpty(criteria) || criteria == "null")
                return reader;
            var regex = @"[a-zA-Z0-9\<\>\=\!\~\#\/\,]+";
            var result = new string(criteria.ToArray());
            var matches = Regex.Matches(criteria, regex);
            for (int i = 0; i < matches.Count; ++i)
            {
                var match = matches[i];
                reader._mCriterions.Add(Criterion.ParseString(match.Value));
                result = result.Replace(match.Value, "{" + i + "}");
            }
            reader.ResultTemplate = result;

            return reader;
        }
        public bool GetResult(Dictionary<Criterion, bool> results)
        {
            if (string.IsNullOrEmpty(ResultTemplate))
                return true;
            var result = string.Format(ResultTemplate, results.Select(x => (object)(x.Value ? "t" : "f")).ToArray());
            while (Regex.Match(result, regex_GetParenthesis).Value != "")
            {
                var match = Regex.Match(result, regex_GetParenthesis);
                result = result.Replace(match.Value, ReduceWithoutParenthesis(match.Value));
            }
            result = ReduceWithoutParenthesis(result);
            return result == "t";
        }
        private static string ReduceWithoutParenthesis(string operation)
        {
            var result = new string(operation.ToArray());
            if (result.First() == '(' && result.Last() == ')')
                result = result.Substring(1, result.Length - 2);
            if (result.Contains('(') || result.Contains(')'))
                throw new Exception();

            while (result.Contains('&'))
            {
                foreach (var entry in dicAnd)
                {
                    while (result != result.Replace(entry.Key, entry.Value))
                    {
                        result = result.Replace(entry.Key, entry.Value);
                    }
                }
            }
            while (result.Contains('|'))
            {
                foreach (var entry in dicOr)
                {
                    while (result != result.Replace(entry.Key, entry.Value))
                    {
                        result = result.Replace(entry.Key, entry.Value);
                    }
                }
            }
            return result;
        }
    }
}
