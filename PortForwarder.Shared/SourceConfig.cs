using System;
using System.Net;

namespace PortForwarder.Shared
{
    public class SourceConfig
    {
        public int SourcePort { get; }
        public IPAddress SourceIP { get; }

        public SourceConfig(int sourcePort, string sourceIP)
        {
            SourcePort = sourcePort;
            SourceIP = IPAddress.TryParse(sourceIP, out var ipAddress) ? ipAddress : IPAddress.None;
        }

        public override string ToString()
            => $"{SourceIP}:{SourcePort}";
    }
}