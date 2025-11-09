// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 8def3cfca4b957913c40eb1ca475d314f72ba2d896798cd1ded680563050da8a
// IndexVersion: 2
// --- END CODE INDEX META ---
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
