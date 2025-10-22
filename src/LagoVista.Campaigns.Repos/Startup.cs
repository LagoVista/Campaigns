// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b3ba846f5b47192c0f088ba6a5b9118b647b3f21a92c9416ca03891ade319ebd
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Interfaces;
using LagoVista.Core.Interfaces;
using LagoVista.Kpis.Interfaces;
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