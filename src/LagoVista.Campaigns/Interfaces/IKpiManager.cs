using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System.Threading.Tasks;
using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;

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
    }
}
