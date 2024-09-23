using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.REST
{
    [Authorize]
    public class CampaignsController : IoT.Web.Common.Controllers.LagoVistaBaseController
    {
        private readonly ICampaignManager _campaignManager;

        public CampaignsController(ICampaignManager campaignManager, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _campaignManager = campaignManager ?? throw new ArgumentNullException(nameof(campaignManager));
        }

        [HttpGet("/api/campaigns")]
        public Task<ListResponse<CampaignSummary>> GetCampaigns()
        {
            return _campaignManager.GetCampaignsAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/campaign/{id}/promotions")]
        public async Task<ListResponse<Promotion>> GetPromotions(string id)
        {
            var campaign = await _campaignManager.GetCampaignAsync(id, OrgEntityHeader, UserEntityHeader);
            return ListResponse<Promotion>.Create(campaign.Promotions);
        }

        [HttpGet("/api/campaign/{id}")]
        public async Task<DetailResponse<Campaign>> GetCampaign(String id)
        {
            var campaign = await _campaignManager.GetCampaignAsync(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<Campaign>.Create(campaign);
        }

        [HttpDelete("/api/campaign/{id}")]
        public async Task<InvokeResult> DeleteCampaign(String id)
        {
            return await _campaignManager.DeleteCampaignAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/campaign/{campaignkey}/{promokey}/increment")]
        public async Task IncrementProgressAsync(string campaignkey, string promokey)
        {
            await _campaignManager.IncrementPromotionProgressAsync(campaignkey, promokey, OrgEntityHeader, UserEntityHeader);
        }

        [AllowAnonymous]
        [HttpGet("/api/public/campaign/{campaignId}/{promoId}/increment")]
        public async Task PublicIncrementProgressAsync(string campaignId, string promoId)
        {
            await _campaignManager.IncrementPromotionProgressAsync(campaignId, promoId);
        }

        [HttpPost("/api/campaign")]
        public Task<InvokeResult<Campaign>> AddCampaignAsycn([FromBody] Campaign campaign)
        {
            return _campaignManager.AddCampaignAsync(campaign, OrgEntityHeader, UserEntityHeader);
        }

        [HttpPut("/api/campaign")]
        public Task<InvokeResult<Campaign>> UpdateCampaignAsycn([FromBody] Campaign campaign)
        {
            SetUpdatedProperties(campaign);
            return _campaignManager.UpdateCampaignAsync(campaign, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/campaign/promotion/factory")]
        public DetailResponse<Promotion> CreatePromotion()
        {
            return DetailResponse<Promotion>.Create();
        }

        [HttpGet("/api/campaign/promotion/post/factory")]
        public DetailResponse<SocialMediaPost> CreateMediaPosts()
        {
            return DetailResponse<SocialMediaPost>.Create();
        }

        [HttpGet("/api/campaign/factory")]
        public DetailResponse<Campaign> CreateCampaigns()
        {
            var campaign = DetailResponse<Campaign>.Create();
            SetAuditProperties(campaign.Model);
            SetOwnedProperties(campaign.Model);
            return campaign;
        }
    }
}
