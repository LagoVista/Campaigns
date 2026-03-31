using LagoVista;
using LagoVista.Campaigns;
using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using Microsoft.Extensions.Configuration;

public class MetricStorageConnectionSettings : IMetricStorageConnectionSettings
{
    public MetricStorageConnectionSettings(IConfiguration configurationRoot)
    {
        var metricsSection = configurationRoot.GetSection("MetricsDB");

        MetricsStorageDBConenction = new ConnectionSettings()
        {
            Uri = metricsSection.Require("ServerURL"),
            ResourceName = metricsSection.Require("InitialCatalog"),
            UserName = metricsSection.Require("UserName"),
            Password = metricsSection.Require("Password"),
        };
    }

    public LagoVista.Core.Interfaces.IConnectionSettings MetricsStorageDBConenction { get; }
}
