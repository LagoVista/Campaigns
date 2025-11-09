// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 2cc2b898c988db385ae3341d021d73bbcaf21ebc81ac11170687c14e9d329816
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models;
using LagoVista.Core.Exceptions;
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
using System.Linq;
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
        public Task<ListResponse<EmailSenderSummary>> GetEmailSendersAsync()
        {
            return _emailSender.GetEmailSendersAsync(OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/sender/{id}")]
        public async Task<DetailResponse<EmailSender>> GetEmailSendersAsync(string id)
        {
            var sender = await _emailSender.GetEmailSenderAsync(id, OrgEntityHeader, UserEntityHeader);
            return DetailResponse<EmailSender>.Create(sender);
        }


        [HttpDelete("/api/email/sender/{id}")]
        public async Task<InvokeResult> DeleteSenderAsync(string id)
        {
            return await _emailSender.DeleteEmailSenderAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        [HttpPost("/api/email/sender")]
        public Task<InvokeResult> AddEmailSenderAsync([FromBody] EmailSender emailSender)
        {
            if (emailSender == null) throw new ArgumentNullException(nameof(emailSender));
            return _emailSender.AddEmailSenderAsync(emailSender, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/sender/factory")]
        public DetailResponse<EmailSender> CreateEmailSender()
        {
            return DetailResponse<EmailSender>.Create(new EmailSender()
            {
                OrganizationId = OrgEntityHeader.Id,
                ReplyTo = new EmailSenderAddress(),
                From = new EmailSenderAddress(),
            }, false);
        }

        [HttpGet("/api/email/sender/email/factory")]
        public  DetailResponse<EmailSenderAddress> CreateEmailSenderAddress()
        {
            return DetailResponse<EmailSenderAddress>.Create();
        }

        [HttpPut("/api/email/sender")]
        public Task<InvokeResult> UpdateEmailSenderAsync([FromBody] EmailSender emailSender)
        {
            if (emailSender == null) throw new ArgumentNullException(nameof(emailSender));
            return _emailSender.UpdateEmailSenderAsync(emailSender, OrgEntityHeader, UserEntityHeader);
        }

        [HttpGet("/api/email/sender/create/{userid}")]
        public async Task<InvokeResult<AppUser>> AddEmailSenderAsync(string userid, string nickname="")
        {
            var appUser = await _appUserManager.GetUserByIdAsync(userid, OrgEntityHeader, UserEntityHeader);
            return await _emailSender.AddEmailSenderAsync(appUser, nickname, OrgEntityHeader, UserEntityHeader);
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


        [HttpGet("/api/pagelink/factory")]
        public DetailResponse<PageLink> CreatePageLink()
        {
            return DetailResponse<PageLink>.Create();
        }


        [HttpGet("/api/email/attachment/factory")]
        public DetailResponse<Models.EmailAttachment> CreateEmailAttachment()
        {
            return DetailResponse<Models.EmailAttachment>.Create();
        }

        [HttpGet("/api/recipient/factory")]
        public DetailResponse<Recipient> CreateRecipient()
        {
            return DetailResponse<Recipient>.Create();
        }
    }
}
