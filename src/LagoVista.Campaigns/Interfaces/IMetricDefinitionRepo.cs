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
