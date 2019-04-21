using System.Net;

namespace PortForwarder.Shared
{
    public class DestinationConfig
    {
        public int DestinationPort { get; }
        public IPAddress DestinationIP { get; }

        public DestinationConfig(int destinationPort, string destinationIP)
        {
            DestinationPort = destinationPort;
            DestinationIP = IPAddress.TryParse(destinationIP, out var ipAddress) ? ipAddress : IPAddress.None;
        }

        public override string ToString()
            => $"{DestinationIP}:{DestinationPort}";
    }
}