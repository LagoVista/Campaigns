// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: d039f433c21e7781e5a236b299af2dfe84203db99cb869ce4fda2f06dd1a24bb
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Kpis.Interfaces;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LagoVista.Campaigns.Models;
using System.Collections.Generic;
using LagoVista.Core;

namespace LagoVista.Kpis.REST
{
    [Authorize]
    public class KpiController : IoT.Web.Common.Controllers.LagoVistaBaseController
    {
        private readonly IKpiManager _kpiManager;

        public KpiController(IKpiManager kpiManager, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _kpiManager = kpiManager ?? throw new ArgumentNullException(nameof(kpiManager));
        }

        [HttpGet("/api/kpis")]
        public Task<ListResponse<KpiSummary>> GetKpis()
        {
            return _kpiManager.GetKpisAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/kpi/{id}")]
        public async Task<DetailResponse<Kpi>> GetKpi(String id)
        {
            var kpi = await _kpiManager.GetKpiAsync(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<Kpi>.Create(kpi);
        }

        [HttpDelete("/api/kpi/{id}")]
        public async Task<InvokeResult> DeleteKpi(String id)
        {
            return await _kpiManager.DeleteKpiAsync(id, OrgEntityHeader, UserEntityHeader);
        }
 

        [HttpPost("/api/kpi")]
        public Task<InvokeResult> AddKpiAsycn([FromBody] Kpi kpi)
        {
            return _kpiManager.AddKpiAsync(kpi, OrgEntityHeader, UserEntityHeader);
        }

        [HttpPut("/api/kpi")]
        public Task<InvokeResult> UpdateKpiAsycn([FromBody] Kpi kpi)
        {
            SetUpdatedProperties(kpi);
            return _kpiManager.UpdateKpiAsync(kpi, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/kpi/metrics/{id}")]
        public async Task<ListResponse<KpiMetricsValue>> GetMetricValues(String id)
        {
            var request = GetListRequestFromHeader();

            if (String.IsNullOrEmpty(request.StartDate))
                request.StartDate = DateTime.Now.AddDays(-15).ToDateOnly();

            if (String.IsNullOrEmpty(request.EndDate))
                request.EndDate = DateTime.Now.AddDays(1).ToDateOnly();

            var result = await  _kpiManager.GetMetricsValuesAsync(id, request, OrgEntityHeader, UserEntityHeader);

            return ListResponse<KpiMetricsValue>.Create(result);
        }

        [HttpGet("/api/kpi/factory")]
        public DetailResponse<Kpi> CreateKpis()
        {
            var kpi = DetailResponse<Kpi>.Create();
            SetAuditProperties(kpi.Model);
            SetOwnedProperties(kpi.Model);
            return kpi;
        }
    }
}
