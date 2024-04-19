﻿using LagoVista.Campaigns.Interfaces;
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
            services.AddTransient<IMetricsDefinitionManager, MetricsDefinitionManager>();
            services.AddTransient<ISocialMediaAccountRepo, SocialMediaAccountRepo>();
        }
    }
}