using LagoVista.Core.Interfaces;

namespace LagoVista.Campaigns
{
    public interface ICampaignConnectionSettings
    {
        IConnectionSettings CampaignDocDbStorage { get; }

        IConnectionSettings CampaignTableStorage { get; }
        IConnectionSettings MetricsStorageConnection { get; }

        bool ShouldConsolidateCollections { get; }
    }
}
