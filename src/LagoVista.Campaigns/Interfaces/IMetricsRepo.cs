using LagoVista.Campaigns.Models;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Interfaces
{
    public interface IMetricsRepo
    {
        Task AddMetric(KpiMetric metric);
    }
}
