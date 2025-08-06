namespace DidactCore.Blocks
{
    public interface IBlockFactory
    {
        /// <summary>
        /// Instantiates a new <see cref="ActionBlock{T}"/> with dependency injection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ActionBlock<T> CreateActionBlock<T>();
    }
}
