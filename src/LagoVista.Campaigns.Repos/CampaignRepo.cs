using LagoVista.Campaigns.Models;
using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.Logging.Loggers;
using System.Linq;
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
            var campaigns = await QueryAsync(cmp => cmp.OwnerOrganization.Id == orgId, request);
            return ListResponse<CampaignSummary>.Create(request, campaigns.Model.Select(cmp => cmp.CreateSummary()));
        }

        public Task UpdateCampaignAsync(Campaign campaign)
        {
            return UpsertDocumentAsync(campaign);
        }
    }
}
