using System.Threading.Tasks;

namespace DidactCore.Blocks
{
    public interface IBlockRepository
    {
        /// <summary>
        /// Asynchronously saves a Block log to persistent storage.
        /// </summary>
        /// <returns></returns>
        Task SaveLogAsync(string log);
    }
}
