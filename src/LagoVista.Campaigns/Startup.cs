using LagoVista.Campaigns.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using LagoVista.Kpis;
using LagoVista.Kpis.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]
namespace LagoVista.Campaigns
{
    public class Startup
    {
        public static void ConfigureServices(IConfigurationRoot configurationRoot, IServiceCollection services, ILogger logger)
        {
            services.AddTransient<ICampaignManager, CampaignManager>();
            services.AddTransient<IKpiManager, KpiManager>();
            services.AddTransient<IMetricsDefinitionManager, MetricsDefinitionManager>();
            services.AddTransient<ISocialMediaAccountManager, SocialMediaAccountManager>();
        }
    }
}
