using System.Collections.Generic;
using System.Threading.Tasks;
using DidactCore.Entities;

namespace DidactCore.Flows
{
    public interface IFlowRepository
    {
        /// <summary>
        /// Asynchronously saves the values from IFlowConfigurator to persistent storage.
        /// </summary>
        /// <param name="flowConfigurator"></param>
        /// <see cref="IFlowConfigurator"/>
        /// <returns></returns>
        Task SaveConfigurationsAsync(IFlowConfigurator flowConfigurator);

        /// <summary>
        /// Asynchronously retrieves a Flow from persistent storage by its primary key.
        /// </summary>
        /// <param name="flowId"></param>
        /// <returns></returns>
        Task<Flow> GetFlowByIdAsync(long flowId);

        /// <summary>
        /// Asynchronously retrieves a Flow from persistent storage by its Type name.
        /// </summary>
        /// <param name="flowTypeName"></param>
        /// <returns></returns>
        Task<Flow> GetFlowByTypeNameAsync(string flowTypeName);

        /// <summary>
        /// Asynchronously retrieves a Flow from persistent storage by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Flow> GetFlowByNameAsync(string name);

        /// <summary>
        /// Asynchronously retrieves all Flows from persistent storage by the given organization primary key.
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        Task<IEnumerable<Flow>> GetAllOrganizationFlowsFromStorageAsync(int organizationId);

        /// <summary>
        /// Asynchronously retrieves all Flows previously saved to persistent storage.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Flow>> GetAllFlowsFromStorageAsync();

        /// <summary>
        /// Asynchronously deactivates a Flow in persistent storage by its primary key.
        /// </summary>
        /// <param name="flowId"></param>
        /// <returns></returns>
        Task DeactivateFlowByIdAsync(long flowId);

        /// <summary>
        /// Asynchronously activates a Flow in persistent storage by its primary key.
        /// </summary>
        /// <param name="flowId"></param>
        /// <returns></returns>
        Task ActivateFlowByIdAsync(long flowId);
    }
}
