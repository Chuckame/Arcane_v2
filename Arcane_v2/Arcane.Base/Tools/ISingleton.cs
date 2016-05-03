using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Tools
{
    public interface ISingleton<T> where T : class
    {
        T Instance { get; }
    }
}
