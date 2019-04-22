using System.Collections.Generic;

namespace PortForwarder.Shared
{
    public interface IOutputParser<out TOut>
    {
        IReadOnlyList<TOut> Parse(string output);
    }
}