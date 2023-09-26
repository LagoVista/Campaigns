﻿using LagoVista.Campaigns.Models;
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
    public class SocialMediaAccountController : IoT.Web.Common.Controllers.LagoVistaBaseController
    {
        private readonly ISocialMediaAccountManager _oscialMediaManager;

        public SocialMediaAccountController(ISocialMediaAccountManager socialMediaManager, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _oscialMediaManager = socialMediaManager ?? throw new ArgumentNullException(nameof(socialMediaManager));
        }

        [HttpGet("/api/socialmedia/accounts")]
        public Task<ListResponse<SocialMediaAccount>> GetAccounts()
        {
            return _oscialMediaManager.GetAccountsAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        [HttpPost("/api/socialmedia/accounts")]
        public Task<InvokeResult<SocialMediaAccount>> AddAccountAsync([FromBody] SocialMediaAccount account)
        {
            return _oscialMediaManager.AddAccountAsync(account, OrgEntityHeader, UserEntityHeader);
        }

        [HttpPut("/api/socialmedia/accounts")]
        public Task<InvokeResult<SocialMediaAccount>> UpdateAccountAsync([FromBody] SocialMediaAccount account)
        {
            return _oscialMediaManager.UpdateAccountAsync(account, OrgEntityHeader, UserEntityHeader);
        }
    }
}
