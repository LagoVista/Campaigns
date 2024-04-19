using LagoVista.Campaigns;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Logging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignTests
{
    internal class CampaignConnection : ICampaignConnectionSettings
    {
        public CampaignConnection()
        {
            MetricsStorageConnection = new ConnectionSettings()
            {
                Uri = Environment.GetEnvironmentVariable("DEV_PSSQL_URL"),
                UserName = Environment.GetEnvironmentVariable("DEV_PSSQL_USER"),
                Password = Environment.GetEnvironmentVariable("DEV_PSSQL_PASSWORD")
            };
        }

        public IConnectionSettings CampaignDocDbStorage { get; }

        public IConnectionSettings CampaignTableStorage { get; }

        public IConnectionSettings MetricsStorageConnection { get; }

        public bool ShouldConsolidateCollections => true;
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
