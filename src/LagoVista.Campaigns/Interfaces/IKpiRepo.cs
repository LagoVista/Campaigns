using LagoVista.Core.Models.UIMetaData;
using System.Threading.Tasks;
using LagoVista.Campaigns.Models;

namespace LagoVista.Kpis.Interfaces
{
    public interface IKpiRepo
    {
        Task AddKpiAsync(Kpi Kpi);
        Task DeleteKpiAsync(string id);
        Task UpdateKpiAsync(Kpi kpi);
        Task<Kpi> GetKpiAsync(string id);
        Task<Kpi> GetKpiByKeyAscyn(string orgId, string key);
        Task<ListResponse<KpiSummary>> GetKpisAsync(ListRequest request, string orgId);
    }
}
