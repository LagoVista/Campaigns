using LagoVista;
using LagoVista.Campaigns;
using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using Microsoft.Extensions.Configuration;

public class MetricStorageConnectionSettings : IMetricStorageConnectionSettings
{
    public MetricStorageConnectionSettings(IConfigurationRoot configurationRoot)
    {
        var billingDbSection = configurationRoot.GetRequiredSection("MetricsStorage");

        MetricsStorageDBConenction = new ConnectionSettings()
        {
            Uri = billingDbSection.Require("ServerURL"),
            ResourceName = billingDbSection.Require("InitialCatalog"),
            UserName = billingDbSection.Require("UserName"),
            Password = billingDbSection.Require("Password"),
        };
    }

    public LagoVista.Core.Interfaces.IConnectionSettings MetricsStorageDBConenction { get; }
}
