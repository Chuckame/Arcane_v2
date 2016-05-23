using Arcane.Protocol.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game
{
    public static class EntityLookExtension
    {
        public static EntityLook Copy(this EntityLook entityLook)
        {
            return new EntityLook(entityLook.bonesId, entityLook.skins, entityLook.indexedColors, entityLook.scales, entityLook.subentities);
        }

        private static Tuple<int, int> ExtractIndexedColor(int indexedColor)
        {
            int num = indexedColor >> 0x18;
            return new Tuple<int, int>(num, indexedColor & 0xffffff);
        }

        private static T[] ParseCollection<T>(string str, Func<string, T> converter)
        {
            if (converter == null)
                throw new ArgumentNullException(nameof(converter));
            if (string.IsNullOrEmpty(str))
            {
                return new T[0];
            }
            int startIndex = 0;
            int index = str.IndexOf(',', startIndex);
            if (index == -1)
            {
                return new T[] { converter(str) };
            }
            var localArray = new LinkedList<T>();
            int num3 = 0;
            while (index != -1)
            {
                localArray.AddLast(converter(str.Substring(startIndex, index - startIndex)));
                startIndex = index + 1;
                index = str.IndexOf(',', startIndex);
                num3++;
            }
            localArray.AddLast(converter(str.Substring(startIndex, str.Length - startIndex)));
            return localArray.ToArray();
        }

        private static int ParseIndexedColor(string str)
        {
            int index = str.IndexOf('=');
            bool flag = str[index + 1] == '#';
            int num2 = int.Parse(str.Substring(0, index));
            int num3 = int.Parse(str.Substring(index + (flag ? 2 : 1), str.Length - (index + (flag ? 2 : 1))), flag ? NumberStyles.HexNumber : NumberStyles.Integer);
            return ((num2 << 0x18) | num3);
        }

        public static EntityLook ToEntityLook(this string str)
        {
            if (string.IsNullOrEmpty(str) || (str[0] != '{'))
            {
                throw new Exception("Incorrect EntityLook format : " + str);
            }
            int startIndex = 1;
            int index = str.IndexOf('|');
            if (index == -1)
            {
                index = str.IndexOf('}');
                if (index == -1)
                {
                    throw new Exception("Incorrect EntityLook format : " + str);
                }
            }
            short bonesId = short.Parse(str.Substring(startIndex, index - startIndex));
            startIndex = index + 1;
            short[] skins = new short[0];
            if (((index = str.IndexOf('|', startIndex)) != -1) || ((index = str.IndexOf('}', startIndex)) != -1))
            {
                skins = ParseCollection<short>(str.Substring(startIndex, index - startIndex), new Func<string, short>(short.Parse));
                startIndex = index + 1;
            }
            int[] indexedColors = new int[0];
            if (((index = str.IndexOf('|', startIndex)) != -1) || ((index = str.IndexOf('}', startIndex)) != -1))
            {
                indexedColors = ParseCollection<int>(str.Substring(startIndex, index - startIndex), new Func<string, int>(EntityLookExtension.ParseIndexedColor));
                startIndex = index + 1;
            }
            short[] scales = new short[0];
            if (((index = str.IndexOf('|', startIndex)) != -1) || ((index = str.IndexOf('}', startIndex)) != -1))
            {
                scales = ParseCollection<short>(str.Substring(startIndex, index - startIndex), new Func<string, short>(short.Parse));
                startIndex = index + 1;
            }
            var list = new List<SubEntity>();
            while (startIndex < str.Length)
            {
                int num4 = str.IndexOf('@', startIndex, 3);
                int num5 = str.IndexOf('=', num4 + 1, 3);
                byte num6 = byte.Parse(str.Substring(startIndex, num4 - startIndex));
                byte num7 = byte.Parse(str.Substring(num4 + 1, num5 - (num4 + 1)));
                int num8 = 0;
                int num9 = num5 + 1;
                StringBuilder builder = new StringBuilder();
                do
                {
                    builder.Append(str[num9]);
                    if (str[num9] == '{')
                    {
                        num8++;
                    }
                    else if (str[num9] == '}')
                    {
                        num8--;
                    }
                    num9++;
                }
                while (num8 > 0);
                list.Add(new SubEntity((sbyte)num6, (sbyte)num7, builder.ToString().ToEntityLook()));
                startIndex = num9 + 1;
            }
            return new EntityLook(bonesId, skins, indexedColors, scales, list.ToArray());
        }
    }
}
