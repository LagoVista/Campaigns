using LagoVista.Campaigns;
using LagoVista.CloudStorage.Utils;
using LagoVista.Core.Interfaces;

namespace CampaignTests
{
    internal class LocalMetricStorageConnectionSettings : IMetricStorageConnectionSettings
    {
        public LocalMetricStorageConnectionSettings()
        {
            MetricsStorageDBConenction = TestConnections.ProdMetricsStorage;
        }

        public IConnectionSettings MetricsStorageDBConenction { get;  }
    }
}
