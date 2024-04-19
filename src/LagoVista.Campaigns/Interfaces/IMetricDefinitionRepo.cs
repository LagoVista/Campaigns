using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Interfaces
{
    public interface IMetricsDefinitionRepo
    {
        Task AddMetricsDefinitionAsync(MetricsDefinition metricsDefinition);
        Task DeleteMetricsDefinitionAsync(string id);
        Task UpdateMetricsDefinitionAsync(MetricsDefinition metricsDefinition);
        Task<MetricsDefinition> GetMetricsDefinitionAsync(string id);
        Task<MetricsDefinition> GetMetricsDefinitionByKeyAscyn(string orgId, string key);
        Task<ListResponse<MetricsDefinitionSummary>> GetMetricsDefinitionsAsync(ListRequest request, string orgId);
    }
}
