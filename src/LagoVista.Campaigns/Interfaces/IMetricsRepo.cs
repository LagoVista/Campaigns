// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 9fc814d93e701608cb40d5778507f666ab576923553a9c4eb80c3c02d980e09d
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Interfaces
{
    public interface IMetricsRepo
    {
        Task AddMetric(KpiMetric metric);
        Task<IEnumerable<KpiMetricsValue>> GetMetricsForKpi(ListRequest listRequest, Kpi kpi);
    }
}
