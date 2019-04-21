namespace PortForwarder.Shared
{
    public class PortForwardConfig
    {
        public SourceConfig Source { get;  }
        public DestinationConfig Destination { get; }

        public PortForwardConfig(SourceConfig source, DestinationConfig destination)
        {
            Source = source;
            Destination = destination;
        }
    }
}