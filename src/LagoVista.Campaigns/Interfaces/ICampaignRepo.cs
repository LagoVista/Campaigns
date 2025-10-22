// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 3a67728477305afd4986a6132e1dc1c84e869513d11fda086cd5cbf48df6b727
// IndexVersion: 0
// --- END CODE INDEX META ---
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
