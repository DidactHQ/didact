using DidactCore.Constants;
using DidactCore.Flows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DidactCore.Plugins
{
    public class PluginSynchronizer
    {
        public string PluginCacheFilepath { get; set; }

        public DateTime PluginCacheAt { get; set; }

        public PluginSynchronizer()
        {
        }

        public async Task SynchronizePluginSource()
        {
        }
    }
}
