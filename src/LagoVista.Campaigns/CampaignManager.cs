﻿using LagoVista.Campaigns.Models;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Validation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.Campaigns
{
    public class CampaignManager : ManagerBase, ICampaignManager
    {
        private readonly ICampaignRepo _repo;

        public CampaignManager(ICampaignRepo campaignRepo,  ILogger logger, IAppConfig appConfig, IDependencyManager dependencyManager, ISecurity security) :
            base(logger, appConfig, dependencyManager, security)
        {
           _repo = campaignRepo ?? throw new ArgumentNullException(nameof(campaignRepo));
        }

        public async Task<InvokeResult<Campaign>> AddCampaignAsync(Campaign campaign, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(campaign, Actions.Create);

            campaign.TotalSpend = campaign.Promotions.Sum(prm => prm.Spend);
            campaign.TotalBudget = campaign.Promotions.Sum(prm => prm.Budget);

            await AuthorizeAsync(campaign, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddCampaignAsync(campaign);

            return InvokeResult<Campaign>.Create(campaign);
        }

        public async Task<InvokeResult> DeleteCampaignAsync(string id, EntityHeader org, EntityHeader user)
        {
            var campaign = await _repo.GetCampaignAsync(id);
            await AuthorizeAsync(campaign, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeleteCampaignAsync(id);
            return InvokeResult.Success;
        }

        public async Task<Campaign> GetCampaignAsync(string id, EntityHeader org, EntityHeader user)
        {
            var campaign = await _repo.GetCampaignAsync(id);
            await AuthorizeAsync(campaign, AuthorizeResult.AuthorizeActions.Read, user, org);

            return campaign;
        }

        public async Task<ListResponse<CampaignSummary>> GetCampaignsAsync(ListRequest request, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(CampaignSummary), Actions.Read);
            return await _repo.GetCampaigns(request, org.Id);
        }

        public async Task<InvokeResult<Campaign>> UpdateCampaignAsync(Campaign campaign, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(campaign, Actions.Update);

            await AuthorizeAsync(campaign, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.UpdateCampaignAsync(campaign);

            return InvokeResult<Campaign>.Create(campaign);
        }
    }
}
