using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
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
        public CampaignsController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {

        }

        [HttpGet("/api/campaigns")]
        public Task<ListResponse<CampaignSummary>> GetCampaigns()
        {
            throw new NotImplementedException();
        }
    }
}
