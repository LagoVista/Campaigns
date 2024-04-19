using LagoVista.Campaigns.Interfaces;
using LagoVista.Campaigns.Models;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Validation;
using System;
using System.Threading.Tasks;
using LagoVista.Core.Managers;

namespace LagoVista.Campaigns
{
    public class MetricsDefinitionManager : ManagerBase, IMetricsDefinitionManager
    {
        public IMetricsDefinitionRepo _metricsDefinitionRepo;

        public MetricsDefinitionManager(IMetricsDefinitionRepo metricsDefinitionRepo, ILogger logger, IAppConfig appConfig, IDependencyManager dependencyManager, ISecurity security) :
            base(logger, appConfig, dependencyManager, security)
        {
            _metricsDefinitionRepo = metricsDefinitionRepo ?? throw new ArgumentNullException(nameof(metricsDefinitionRepo));
        }

        public async Task<InvokeResult> AddMetricsDefinitionAsync(MetricsDefinition metricsDefinition, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(metricsDefinition, Actions.Create);

            await AuthorizeAsync(metricsDefinition, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _metricsDefinitionRepo.AddMetricsDefinitionAsync(metricsDefinition);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteMetricsDefinitionAsync(string id, EntityHeader org, EntityHeader user)
        {
            var metricsDefinition = await _metricsDefinitionRepo.GetMetricsDefinitionAsync(id);
            await AuthorizeAsync(metricsDefinition, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _metricsDefinitionRepo.DeleteMetricsDefinitionAsync(id);
            return InvokeResult.Success;
        }

        public async Task<MetricsDefinition> GetMetricsDefinitionAsync(string id, EntityHeader org, EntityHeader user)
        {
            var metricsDefinition = await _metricsDefinitionRepo.GetMetricsDefinitionAsync(id);
            await AuthorizeAsync(metricsDefinition, AuthorizeResult.AuthorizeActions.Read, user, org);
            return metricsDefinition;
        }

        public async Task<MetricsDefinition> GetMetricsDefinitionByKeyAsync(string key, EntityHeader org, EntityHeader user)
        {
            var metricsDefinition = await _metricsDefinitionRepo.GetMetricsDefinitionByKeyAscyn(org.Id, key);
            await AuthorizeAsync(metricsDefinition, AuthorizeResult.AuthorizeActions.Read, user, org);
            return metricsDefinition;
        }

        public async Task<ListResponse<MetricsDefinitionSummary>> GetMetricsDefinitionsAsync(ListRequest request, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(MetricsDefinitionSummary), Actions.Read);
            return await _metricsDefinitionRepo.GetMetricsDefinitionsAsync(request, org.Id);
        }

        public async Task<InvokeResult> UpdateMetricsDefinitionAsync(MetricsDefinition metricsDefinition, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(metricsDefinition, Actions.Update);

            await AuthorizeAsync(metricsDefinition, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _metricsDefinitionRepo.UpdateMetricsDefinitionAsync(metricsDefinition);

            return InvokeResult.Success;
        }
    }
}
