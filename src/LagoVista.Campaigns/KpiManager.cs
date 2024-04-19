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

namespace LagoVista.Kpis
{
    

    public class KpiManager : ManagerBase, IKpiManager
    {
        public IKpiRepo _kpiRepo;

        public KpiManager(IKpiRepo kpiRepo, ILogger logger, IAppConfig appConfig, IDependencyManager dependencyManager, ISecurity security) :
            base(logger, appConfig, dependencyManager, security)
        {
            _kpiRepo = kpiRepo ?? throw new ArgumentNullException(nameof(kpiRepo));
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
            return await _kpiRepo.GetKpis(request, org.Id);
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
