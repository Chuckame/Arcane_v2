using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Tools
{
    public class NameGenerator
    {
        private static char[] m_voyelles = { 'a', 'e', 'i', 'o', 'u', 'y' };
        private static char[] m_consonnes = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        private static string[] formats = { "cvcvvc", "cvcv", "cvvcvc", "cvcvc", "cvcvcvv" };

        public static string GenerateName(int nbMaxOfPartsInName = 2)
        {
            var m_name = new StringBuilder();
            var max = Utils.RandomNumber(1, nbMaxOfPartsInName);
            for (int i = 0; i < max; i++)
            {
                if (i > 0)
                {
                    m_name.Append('-');
                }

                var format = formats.Random();
                for (int j = 0; j < format.Length; ++j)
                {
                    var firstChar = j == 0;
                    switch (format[j])
                    {
                        case 'c':
                            if (firstChar)
                            {
                                m_name.Append(char.ToUpper(m_consonnes.Random()));
                            }
                            else
                            {
                                m_name.Append(m_consonnes.Random());
                            }
                            break;
                        case 'v':
                            if (firstChar)
                            {
                                m_name.Append(char.ToUpper(m_voyelles.Random()));
                            }
                            else
                            {
                                m_name.Append(m_voyelles.Random());
                            }
                            break;
                        default:
                            throw new Exception("Invalid format: '{0}', must contains 'c' or 'v'.");
                    }
                }
            }

            return m_name.ToString();
        }
    }
}
