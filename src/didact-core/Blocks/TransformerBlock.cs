using Microsoft.Extensions.Logging;
using System;

namespace DidactCore.Blocks
{
    public class TransformerBlock<T1, TReturn>
    {
        private readonly ILogger<TransformerBlock<T1, TReturn>> _logger;

        public Func<T1, TReturn> Executor { get; private set; }

        public T1 Arg1 { get; private set; }

        public TransformerBlock(ILogger<TransformerBlock<T1, TReturn>> logger)
        {
            _logger = logger;
        }
    }
}
