using Microsoft.Extensions.DependencyInjection;
using System;

namespace DidactCore.Blocks
{
    public class BlockFactory : IBlockFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BlockFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ActionBlock<T> CreateActionBlock<T>() => _serviceProvider.GetRequiredService<ActionBlock<T>>();
    }
}
