// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 30fc8a32f8c38d91563c781160918d85b6776497949bfefe9c72aa7bf997b449
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Interfaces;

namespace LagoVista.Campaigns
{
    public interface ICampaignConnectionSettings
    {
        IConnectionSettings CampaignDocDbStorage { get; }

        IConnectionSettings CampaignTableStorage { get; }

        bool ShouldConsolidateCollections { get; }
    }

    public interface IMetricStorageConnectionSettings
    {
        IConnectionSettings MetricsStorageDBConenction { get; }
    }
}
