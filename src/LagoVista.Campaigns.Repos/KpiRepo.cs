﻿using LagoVista.Campaigns.Models;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Kpis.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Repos
{
    public class KpiRepo : DocumentDBRepoBase<Kpi>, IKpiRepo
    {
        private bool _shouldConsolidateCollections;

        public KpiRepo(ICampaignConnectionSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider)
    : base(repoSettings.CampaignDocDbStorage.Uri, repoSettings.CampaignDocDbStorage.AccessKey, repoSettings.CampaignDocDbStorage.ResourceName, logger, cacheProvider)
        {
            this._shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddKpiAsync(Kpi kpi)
        {
            return CreateDocumentAsync(kpi);
        }

        public Task DeleteKpiAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public Task<Kpi> GetKpiAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<Kpi> GetKpiByKeyAscyn(string orgId, string key)
        {
            return (await QueryAsync(cmp => cmp.Key == key && cmp.OwnerOrganization.Id == orgId)).FirstOrDefault();
        }

        public Task<ListResponse<KpiSummary>> GetKpis(ListRequest request, string orgId)
        {
            return QuerySummaryAsync<KpiSummary, Kpi>(k => k.OwnerOrganization.Id == orgId, k => k.Name, request);
        }

        public Task UpdateKpiAsync(Kpi kpi)
        {
            return UpsertDocumentAsync(kpi);
        }
    }
}
