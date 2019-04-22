using System;
using System.Collections.Generic;
using System.Linq;

namespace PortForwarder.Shared
{
    public class CmdOutputParser : IOutputParser<PortForwardConfig>
    {
        public IReadOnlyList<PortForwardConfig> Parse(string cmdOutput)
        {
            if (string.IsNullOrEmpty(cmdOutput) || cmdOutput.Contains("---") == false)
                return new List<PortForwardConfig>(0);

            return cmdOutput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                 .SkipWhile(sl => sl.Contains("---") == false)
                 .Skip(1)
                 .Select(ToPortForwardConfig)
                 .ToList();
        }

        private PortForwardConfig ToPortForwardConfig(string s)
        {
            var parts = s.Split(' ').Where(p => !string.IsNullOrEmpty(p)).ToList();
            return new PortForwardConfig("Unset",
                new SourceConfig(int.Parse(parts[1]), parts[0]),
                new DestinationConfig(int.Parse(parts[3]), parts[2]));
        }
    }
}
