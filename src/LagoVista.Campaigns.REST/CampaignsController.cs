﻿using LagoVista.Campaigns.Models;
using LagoVista.Core;
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
            return _campaignManager.GetCampaigns(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/campaign/{id}")]
        public async Task<DetailResponse<Campaign>> GetCampaigns(String id)
        {
            var campaign = await _campaignManager.GetCampaign(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<Campaign>.Create(campaign);
        }


        [HttpPost("/api/campaign")]
        public Task<InvokeResult<Campaign>> AddCampaignAsycn([FromBody] Campaign campaign)
        {
            return _campaignManager.AddCampaignAsync(campaign, OrgEntityHeader, UserEntityHeader);
        }

        [HttpPut("/api/campaign")]
        public Task<InvokeResult<Campaign>> UpdateCampaignAsycn([FromBody] Campaign campaign)
        {
            return _campaignManager.UpdateCampaignAsync(campaign, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/campaign/factory")]
        public DetailResponse<Campaign> CreateCampaigns()
        {
            var campaign = DetailResponse<Campaign>.Create();
            campaign.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(campaign.Model);
            SetOwnedProperties(campaign.Model);
            return campaign;
        }
    }
}
