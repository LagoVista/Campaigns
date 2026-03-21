using LagoVista.Campaigns;
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
            services.AddTransient<ICampaignConnectionSettings, CampaignConnectionSettings>();
            services.AddTransient<IMetricStorageConnectionSettings, MetricStorageConnectionSettings>();
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
