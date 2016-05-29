using Arcane.Base.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base
{
    public static class CollectionExtentions
    {
        public static T Random<T>(this IEnumerable<T> collection)
        {
            var count = collection.Count();
            if (collection.Count() < 1)
                return default(T);
            return collection.ElementAt(Utils.RandomNumber(0, count - 1));
        }
    }
}
