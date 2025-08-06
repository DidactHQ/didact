using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DidactCore.Blocks
{
    /// <summary>
    ///     <para>
    ///         A transformer block that executes a Func&lt;<typeparamref name="T1"/>, <typeparamref name="Task"/>&lt;<typeparamref name="TReturn"/>&gt;&gt; delegate.
    ///     </para>
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    public class TransformerTaskBlock<T1, TReturn>
    {
        private readonly ILogger<TransformerTaskBlock<T1, Task<TReturn>>> _logger;

        public Func<T1, Task<TReturn>> Executor { get; private set; }

        public T1 Arg1 { get; private set; }

        public TransformerTaskBlock(ILogger<TransformerTaskBlock<T1, Task<TReturn>>> logger)
        {
            _logger = logger;
        }
    }
}
