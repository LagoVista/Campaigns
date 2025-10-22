// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 51606dbc9ce257847cc0d1e5970b26a4dc86edc470a4695340460ed708b63542
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using LagoVista.Campaigns.Interfaces;

namespace LagoVista.Campaigns.REST
{
    public class MetricsControllerz : IoT.Web.Common.Controllers.LagoVistaBaseController
    {
        private readonly IMetricsDefinitionManager _metricsManager;

        public MetricsControllerz(IMetricsDefinitionManager metricsManager, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _metricsManager = metricsManager ?? throw new ArgumentNullException(nameof(metricsManager));
        }

        [HttpGet("/api/metrics/definitions")]
        public Task<ListResponse<MetricsDefinitionSummary>> GetmetricsDefinitionsAsync()
        {
            return _metricsManager.GetMetricsDefinitionsAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/metrics/definition/{id}")]
        public async Task<DetailResponse<MetricsDefinition>> GetmetricsDefinition(String id)
        {
            var metrics = await _metricsManager.GetMetricsDefinitionAsync(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<MetricsDefinition>.Create(metrics);
        }

        [HttpDelete("/api/metrics/definition/{id}")]
        public async Task<InvokeResult> DeleteMetricsDefinition(String id)
        {
            return await _metricsManager.DeleteMetricsDefinitionAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        [HttpPost("/api/metrics/definition")]
        public Task<InvokeResult> AddmetricsAsycn([FromBody] MetricsDefinition metrics)
        {
            return _metricsManager.AddMetricsDefinitionAsync(metrics, OrgEntityHeader, UserEntityHeader);
        }

        [HttpPut("/api/metrics/definition")]
        public Task<InvokeResult> UpdatemetricsAsycn([FromBody] MetricsDefinition metrics)
        {
            return _metricsManager.UpdateMetricsDefinitionAsync(metrics, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/metrics/factory")]
        public DetailResponse<MetricsDefinition> Createmetricss()
        {
            var metrics = DetailResponse<MetricsDefinition>.Create();
            return metrics;
        }
    }
}
