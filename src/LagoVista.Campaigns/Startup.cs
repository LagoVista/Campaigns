// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 55df9cd45e168931ac506f2efebd72890ef7b3807d28cf849e9c347670100904
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Interfaces;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.Logging.Exceptions;
using LagoVista.Kpis;
using LagoVista.Kpis.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
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

            var connectionSettings = new MetricStorageConnectionSettings(configurationRoot, logger);
            services.AddSingleton<IMetricStorageConnectionSettings>(connectionSettings);
        }
    }

    public class MetricStorageConnectionSettings : IMetricStorageConnectionSettings
    {
        public MetricStorageConnectionSettings(IConfigurationRoot configurationRoot, ILogger logger)
        {
            var billingDbSection = configurationRoot.GetSection("MetricsStorage");
            if (billingDbSection == null)
            {
                logger.AddCustomEvent(LogLevel.ConfigurationError, "Campaigns_Startup", "Missing Section MetricsStorage");
                throw new InvalidConfigurationException(new IoT.Logging.Error() { ErrorCode = "CFG9991", Message = "Missing Section MetricsStorage" });
            }

            MetricsStorageDBConenction = new ConnectionSettings()
            {
                Uri = billingDbSection["ServerURL"],
                ResourceName = billingDbSection["InitialCatalog"],
                UserName = billingDbSection["UserName"],
                Password = billingDbSection["Password"],
            };
        }

        public IConnectionSettings MetricsStorageDBConenction { get; }
    }
}
