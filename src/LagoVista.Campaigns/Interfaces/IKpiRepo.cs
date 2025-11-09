// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 8b3ad6d6126a015f403014af3c6a57bacbeaefaa4fb3f56bb36d23d6a254d81d
// IndexVersion: 2
// --- END CODE INDEX META ---
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
