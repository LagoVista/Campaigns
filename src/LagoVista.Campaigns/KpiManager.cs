// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 826a6ab68a1acb25fe4da0ec3dcc8ef5727315a4e2d69bc86a64e3dadaf784b2
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Validation;
using LagoVista.Kpis.Interfaces;
using System;
using System.Threading.Tasks;
using LagoVista.Campaigns.Models;
using System.Collections.Generic;
using LagoVista.Campaigns.Interfaces;

namespace LagoVista.Kpis
{
    

    public class KpiManager : ManagerBase, IKpiManager
    {
        private IKpiRepo _kpiRepo;
        private IMetricsRepo _metricsRepo;


        public KpiManager(IMetricsRepo metricsRepo, IKpiRepo kpiRepo, ILogger logger, IAppConfig appConfig, IDependencyManager dependencyManager, ISecurity security) :
            base(logger, appConfig, dependencyManager, security)
        {
            _kpiRepo = kpiRepo ?? throw new ArgumentNullException(nameof(kpiRepo));
            _metricsRepo = metricsRepo ?? throw new ArgumentNullException(nameof(metricsRepo));
        }

        public async Task<InvokeResult> AddKpiAsync(Kpi kpi, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(kpi, Actions.Create);

            await AuthorizeAsync(kpi, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _kpiRepo.AddKpiAsync(kpi);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteKpiAsync(string id, EntityHeader org, EntityHeader user)
        {
            var campaign = await _kpiRepo.GetKpiAsync(id);
            await AuthorizeAsync(campaign, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _kpiRepo.DeleteKpiAsync(id);
            return InvokeResult.Success;
        }

        public async Task<Kpi> GetKpiAsync(string id, EntityHeader org, EntityHeader user)
        {
            var campaign = await _kpiRepo.GetKpiAsync(id);
            await AuthorizeAsync(campaign, AuthorizeResult.AuthorizeActions.Read, user, org);

            return campaign;
        }

        public async Task<Kpi> GetKpiByKeyAsync(string key, EntityHeader org, EntityHeader user)
        {
            var kpi = await _kpiRepo.GetKpiByKeyAscyn(org.Id, key);
            await AuthorizeAsync(kpi, AuthorizeResult.AuthorizeActions.Read, user, org);
            return kpi;
        }

        public async Task<ListResponse<KpiSummary>> GetKpisAsync(ListRequest request, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(KpiSummary), Actions.Read);
            return await _kpiRepo.GetKpisAsync(request, org.Id);
        }

        public async Task<IEnumerable<KpiMetricsValue>> GetMetricsValuesAsync(string kpiId, ListRequest request, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(KpiMetricsValue), Actions.Read);

            var kpi = await _kpiRepo.GetKpiAsync(kpiId);
            return await _metricsRepo.GetMetricsForKpi(request, kpi);
        }

        public async Task<InvokeResult> UpdateKpiAsync(Kpi kpi, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(kpi, Actions.Update);

            await AuthorizeAsync(kpi, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _kpiRepo.UpdateKpiAsync(kpi);

            return InvokeResult.Success;
        }
    }
}
