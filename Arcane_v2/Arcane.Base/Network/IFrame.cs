using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IFrame<TClient>
        where TClient : IClient<TClient>
    {
        TClient Client { get; }

        bool Dispatch(IMessage message);
    }
}
