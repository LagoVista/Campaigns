// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 7d70d67407cb0e54f93d59cfa6f46cf9c6e0ec2753360bf542df337cc4ea85bd
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System.Threading.Tasks;
using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Collections.Generic;

namespace LagoVista.Kpis.Interfaces
{
    public interface IKpiManager
    {
        Task<InvokeResult> AddKpiAsync(Kpi kpi, EntityHeader org, EntityHeader user);
        Task<Kpi> GetKpiAsync(string id, EntityHeader org, EntityHeader user);
        Task<Kpi> GetKpiByKeyAsync(string id, EntityHeader org, EntityHeader user);

        Task<InvokeResult> DeleteKpiAsync(string id, EntityHeader org, EntityHeader user);

        Task<InvokeResult> UpdateKpiAsync(Kpi kpi, EntityHeader org, EntityHeader user);

        Task<ListResponse<KpiSummary>> GetKpisAsync(ListRequest request, EntityHeader org, EntityHeader user);

        Task<IEnumerable<KpiMetricsValue>> GetMetricsValuesAsync(string kpiId, ListRequest request, EntityHeader org, EntityHeader user);
    }
}
