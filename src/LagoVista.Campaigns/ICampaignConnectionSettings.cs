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
