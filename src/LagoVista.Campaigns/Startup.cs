using LagoVista.Campaigns.Interfaces;
using LagoVista.Core.Interfaces;
using LagoVista.Kpis;
using LagoVista.Kpis.Interfaces;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]
namespace LagoVista.Campaigns
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICampaignManager, CampaignManager>();
            services.AddTransient<IKpiManager, KpiManager>();
            services.AddTransient<IMetricsDefinitionManager, MetricsDefinitionManager>();
            services.AddTransient<ISocialMediaAccountManager, SocialMediaAccountManager>();
        }
    }
}
