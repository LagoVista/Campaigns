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
