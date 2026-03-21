using LagoVista.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Repos
{
    public class CampaignConnectionSettings : ICampaignConnectionSettings
    {
        public IConnectionSettings CampaignDocDbStorage { get; }

        public IConnectionSettings CampaignTableStorage { get; }

        public CampaignConnectionSettings(IConfiguration configurationRoot)
        {
            CampaignDocDbStorage = configurationRoot.CreateDefaultDBStorageSettings();
            CampaignTableStorage = configurationRoot.CreateDefaultTableStorageSettings();
        }
    }
}
