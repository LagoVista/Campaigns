// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b389273ffbef43a3bb68530920ba7c05b448a7a332792a9dbd4dd5d89289e240
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Interfaces
{
    public interface IMetricsDefinitionRepo
    {
        Task AddMetricsDefinitionAsync(string orgId,MetricsDefinition metricsDefinition);
        Task DeleteMetricsDefinitionAsync(string orgId, string id);
        Task UpdateMetricsDefinitionAsync(string orgId, MetricsDefinition metricsDefinition);
        Task<MetricsDefinition> GetMetricsDefinitionAsync(string orgId, string id);
        Task<MetricsDefinition> GetMetricsDefinitionByKeyAscyn(string orgId, string key);
        Task<ListResponse<MetricsDefinitionSummary>> GetMetricsDefinitionsAsync(ListRequest request, string orgId);
    }
}
