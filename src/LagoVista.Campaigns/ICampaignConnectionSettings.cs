using LagoVista.Core.Interfaces;

namespace LagoVista.Campaigns
{
    public interface ICampaignConnectionSettings
    {
        IConnectionSettings CampaignDocDbStorage { get; set; }

        IConnectionSettings CampaignTableStorage { get; set; }

        bool ShouldConsolidateCollections { get; }
    }
}
