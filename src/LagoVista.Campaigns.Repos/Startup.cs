// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b3ba846f5b47192c0f088ba6a5b9118b647b3f21a92c9416ca03891ade319ebd
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Interfaces;
using LagoVista.Campaigns.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Kpis.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]
namespace LagoVista.Campaigns.Repos
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICampaignRepo, CampaignRepo>();
            services.AddTransient<IKpiRepo, KpiRepo>();
            services.AddTransient<IMetricsRepo, MetricsRepo>();
            services.AddTransient<IMetricsDefinitionRepo, MetricsRepo>();
            services.AddTransient<ISocialMediaAccountRepo, SocialMediaAccountRepo>();
        }
    }
}

namespace LagoVista.DependencyInjection
{
    public static class CampaignsModule
    {
        public static void AddCampaignsModule(this IServiceCollection services, IConfigurationRoot configRoot, IAdminLogger logger)
        {
            LagoVista.Campaigns.Repos.Startup.ConfigureServices(services);
            LagoVista.Campaigns.Startup.ConfigureServices(configRoot, services, logger);
            services.AddMetaDataHelper<Campaign>();
        }
    }
}
