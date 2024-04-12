using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.Campaigns
{
    public interface ICampaignRepo
    {
        Task AddCampaignAsync(Campaign campaign);
        Task DeleteCampaignAsync(string id);
        Task UpdateCampaignAsync(Campaign campaign);
        Task<Campaign> GetCampaignAsync(string id);
        Task<Campaign> GetCampaignByKeyAsync(string orgId, string key);
        Task<IEnumerable<Campaign>> GetActiveCampaignsByIndustryAsync(string orgId, string industryId);
        Task<ListResponse<CampaignSummary>> GetCampaigns(ListRequest request, string orgId);
    }
}
