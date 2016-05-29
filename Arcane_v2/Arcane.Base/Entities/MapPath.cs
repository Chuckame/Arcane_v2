using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Entities
{
    public class MapPath : IEnumerable<MapPoint>
    {
        private LinkedList<MapPoint> _path;

        public MapPath()
        {

        }

        public short[] Compress()
        {
            return null;
        }

        public IEnumerator<MapPoint> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
