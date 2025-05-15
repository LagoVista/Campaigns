using LagoVista.Campaigns.Interfaces;
using LagoVista.Campaigns.Models;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.Logging.Loggers;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Repos
{
    public class MetricsDefinitionRepo : DocumentDBRepoBase<MetricsDefinition>, IMetricsDefinitionRepo
    {
        private bool _shouldConsolidateCollections;

        public MetricsDefinitionRepo(ICampaignConnectionSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider)
            : base(repoSettings.CampaignDocDbStorage.Uri, repoSettings.CampaignDocDbStorage.AccessKey, repoSettings.CampaignDocDbStorage.ResourceName, logger, cacheProvider)
        {
            this._shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddMetricsDefinitionAsync(MetricsDefinition metricsDefinition)
        {
            return CreateDocumentAsync(metricsDefinition);
        }

        public Task DeleteMetricsDefinitionAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public Task<MetricsDefinition> GetMetricsDefinitionAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<MetricsDefinition> GetMetricsDefinitionByKeyAscyn(string orgId, string key)
        {
            return (await QueryAsync(cmp => cmp.Key == key && (cmp.OwnerOrganization.Id == orgId || cmp.IsPublic))).FirstOrDefault();
        }

        public Task<ListResponse<MetricsDefinitionSummary>> GetMetricsDefinitionsAsync(ListRequest request, string orgId)
        {
            return QuerySummaryAsync<MetricsDefinitionSummary, MetricsDefinition>(k => (k.OwnerOrganization.Id == orgId || k.IsPublic), k => k.Name, request);
        }

        public Task UpdateMetricsDefinitionAsync(MetricsDefinition metricsDefinition)
        {
            return UpsertDocumentAsync(metricsDefinition);
        }
    }
}
