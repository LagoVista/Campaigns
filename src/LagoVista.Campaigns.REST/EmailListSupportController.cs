using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.UserAdmin.Interfaces.Managers;
using LagoVista.UserAdmin.Managers;
using LagoVista.UserAdmin.Models.Contacts;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.REST
{
    public class SendEmailCampaignRequest
    {
        public string Name { get; set; }
        public string ListId { get; set; }
        public string SenderId { get; set; }
        public string DesignId { get; set; }
    }

    [Authorize]
    public class EmailListSupportController : IoT.Web.Common.Controllers.LagoVistaBaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly IAppUserManager _appUserManager;

        public EmailListSupportController(IEmailSender emailSender, IAppUserManager appUserManager, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            this._emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            this._appUserManager = appUserManager ?? throw new ArgumentNullException(nameof(appUserManager));
        }

        [HttpGet("/api/email/mailinglists")]
        public Task<ListResponse<ContactList>> GetMailingListsForIndustryAsync()
        {
            return _emailSender.GetListsAsync(OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/mailinglist/{id}/refresh")]
        public Task<InvokeResult> RefreshEmailList(string id)
        {
            return _emailSender.RefreshSegementAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        [HttpDelete("/api/email/mailinglist/{id}")]
        public Task<InvokeResult> DeleteMailingList(string id)
        {
            return _emailSender.DeleteEmailListAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/senders")]
        public Task<ListResponse<EntityHeader>> GetEmailSendersAsync()
        {
            return _emailSender.GetEmailSendersAsync(OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/sender/create/{userid}")]
        public async Task<InvokeResult<AppUser>> AddEmailSenderAsync(string userid)
        {
            var appUser = await _appUserManager.GetUserByIdAsync(userid, OrgEntityHeader, UserEntityHeader);
            return await _emailSender.AddEmailSenderAsync(appUser, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/designs")]
        public async Task<ListResponse<EmailDesign>> GetEmailDesignsAsync()
        {
            return await _emailSender.GetEmailDesignsAsync(OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/campaigns")]
        public async Task<ListResponse<EmailListSend>> GetEmailCampaignsAsync()
        {
            return await _emailSender.GetEmailListSendsAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/campaign/send")]
        public async Task<InvokeResult<string>> CreateEmailCampaign(SendEmailCampaignRequest request)
        {
            return await _emailSender.SendToListAsync(request.Name, request.ListId, request.SenderId, request.DesignId, OrgEntityHeader, UserEntityHeader);
        }
    }
}
