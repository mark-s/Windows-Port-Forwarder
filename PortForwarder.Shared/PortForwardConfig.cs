using System.Diagnostics;

namespace PortForwarder.Shared
{
    [DebuggerDisplay("{Name}: Source [{Source}] Destination [{Destination}]")]
    public class PortForwardConfig
    {
        public string Name { get; set; }

        public SourceConfig Source { get;  }

        public DestinationConfig Destination { get; }

        public PortForwardConfig(string name, SourceConfig source, DestinationConfig destination)
        {
            Name = name;
            Source = source;
            Destination = destination;
        }

    }
}