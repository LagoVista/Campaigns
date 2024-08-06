using LagoVista.Campaigns.Models;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using System.Threading.Tasks;

namespace LagoVista.Campaigns
{
    public interface ICampaignManager
    {
        Task<InvokeResult<Campaign>> AddCampaignAsync(Campaign campaign, EntityHeader org, EntityHeader user);
        Task<BasicCampaignInformation> GetBasicCampaignInformationAsync(string id);
        Task<Campaign> GetCampaignAsync(string id, EntityHeader org, EntityHeader user);

        Task<InvokeResult> DeleteCampaignAsync(string id, EntityHeader org, EntityHeader user);

        Task<InvokeResult<Campaign>> UpdateCampaignAsync(Campaign campaign, EntityHeader org, EntityHeader user);
        Task<ListResponse<CampaignSummary>> GetCampaignsAsync(ListRequest request, EntityHeader org, EntityHeader user);

        Task IncrementPromotionProgressAsync(string campaignKey, string promotionKey, EntityHeader org, EntityHeader user, bool throwOnNotFound = true);
        Task IncrementPromotionProgressAsync(PromotionTypes promoType, string industryId, string nicheId, EntityHeader org, EntityHeader user, bool throwOnNotFound = true);
        Task IncrementPromotionProgressAsync(string campaignId, string promoId);
    }
}
