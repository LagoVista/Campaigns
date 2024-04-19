using LagoVista.Campaigns;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Logging.Models;
using System;
using System.Threading.Tasks;

namespace CampaignTests
{
    internal class LocalMetricStorageConnectionSettings : IMetricStorageConnectionSettings
    {
        public LocalMetricStorageConnectionSettings()
        {
            MetricsStorageDBConenction = new ConnectionSettings()
            {
                Uri = Environment.GetEnvironmentVariable("DEV_PSSQL_URL"),
                UserName = Environment.GetEnvironmentVariable("DEV_PSSQL_USER"),
                ResourceName = Environment.GetEnvironmentVariable("TEST_PSSQL_DB"),
                Password = Environment.GetEnvironmentVariable("DEV_PSSQL_PASSWORD")
            };
        }

        public IConnectionSettings MetricsStorageDBConenction { get;  }
    }

    internal class Writer : ILogWriter
    {
        public Task WriteError(LogRecord record)
        {
            return Task.CompletedTask;
        }

        public Task WriteEvent(LogRecord record)
        {
            return Task.CompletedTask;
        }
    }
}
