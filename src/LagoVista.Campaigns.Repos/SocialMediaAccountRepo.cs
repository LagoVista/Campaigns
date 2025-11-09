// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: cdbc2b7da193c5a08c02d33998e84a78fd4499a34a423c38c70da944b3b86761
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models;
using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Repos
{
    public class SocialMediaAccountRepo : DocumentDBRepoBase<SocialMediaAccount>, ISocialMediaAccountRepo
    {
        private bool _shouldConsolidateCollections;

        public SocialMediaAccountRepo(ICampaignConnectionSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider)
            : base(repoSettings.CampaignDocDbStorage.Uri, repoSettings.CampaignDocDbStorage.AccessKey, repoSettings.CampaignDocDbStorage.ResourceName, logger, cacheProvider)
        {
            this._shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;


        public Task AddAccountAsync(SocialMediaAccount account)
        {
            return CreateDocumentAsync(account);
        }

        public Task<SocialMediaAccount> GetAccountAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<ListResponse<SocialMediaAccount>> GetAccountsAsync(ListRequest request, string orgId)
        {
            return await QueryAsync(cmp => cmp.OwnerOrganization.Id == orgId, request);
        }

        public Task UpdateAccountAsync(SocialMediaAccount account)
        {
            return UpsertDocumentAsync(account);
        }
    }
}
