using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using System.Threading.Tasks;

namespace LagoVista.Campaigns
{
    public interface ICampaignRepo
    {
        Task AddCampaignAsync(Campaign campaign);
        Task UpdateCampaignAsync(Campaign campaign);
        Task<Campaign> GetCampaignAsync(string id);

        Task<ListResponse<CampaignSummary>> GetCampaigns(ListRequest request, string orgId);
    }
}
