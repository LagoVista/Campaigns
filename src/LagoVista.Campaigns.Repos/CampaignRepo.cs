using LagoVista.Campaigns.Models;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.Logging.Loggers;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Repos
{
    public class CampaignRepo : DocumentDBRepoBase<Campaign>, ICampaignRepo
    {
        private bool _shouldConsolidateCollections;

        public CampaignRepo(ICampaignConnectionSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider)
            : base(repoSettings.CampaignDocDbStorage.Uri, repoSettings.CampaignDocDbStorage.AccessKey, repoSettings.CampaignDocDbStorage.ResourceName, logger, cacheProvider)
        {
            this._shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;


        public Task AddCampaignAsync(Campaign campaign)
        {
            return CreateDocumentAsync(campaign);
        }

        public Task<Campaign> GetCampaignAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public Task DeleteCampaignAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public async Task<ListResponse<CampaignSummary>> GetCampaigns(ListRequest request, string orgId)
        {
            return await QuerySummaryAsync<CampaignSummary, Campaign>(cmp => cmp.OwnerOrganization.Id == orgId, cmp => cmp.Name, request);
        }

        public Task UpdateCampaignAsync(Campaign campaign)
        {
            return UpsertDocumentAsync(campaign);
        }
    }
}
