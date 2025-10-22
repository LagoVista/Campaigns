// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 2ce63f6be46cc7aaf84a91ca0f8437cc9e7327c955e999a831634b16e3e4b5bf
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Campaigns;
using LagoVista.Campaigns.Interfaces;
using LagoVista.Campaigns.Repos;
using LagoVista.CloudStorage.Utils;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Kpis.Interfaces;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CampaignTests
{
    public class KPITests
    {
        IKpiRepo _kpiRepo;
        private IMetricsRepo _metricsRepo;

        [SetUp]
        public void Setup()
        {
            _kpiRepo = new KpiRepo(new CampaignConnectionSettings(), new AdminLogger(new LagoVista.IoT.Logging.Utils.ConsoleLogWriter()), null);
            _metricsRepo = new MetricsRepo(new MetricsStorageConnections(), new AdminLogger(new LagoVista.IoT.Logging.Utils.ConsoleLogWriter()));
        }

        [Test]
        public async Task GetKPI()
        {
            var kpi = await _kpiRepo.GetKpiAsync("BD4351629C55441B80DDE819E0C97F2E");

            Console.WriteLine("KPI - " + kpi.Name);

            var listRequest = new ListRequest()
            {
                StartDate = "2024/04/15",
                EndDate = "2024/04/29"
            };

            var results = await _metricsRepo.GetMetricsForKpi(listRequest, kpi);
            foreach(var result in results)
            {
                Console.WriteLine(result.TimeStamp + " " + result.Value);
            }            
        }
    }

    public class CampaignConnectionSettings : ICampaignConnectionSettings
    {
        public IConnectionSettings CampaignDocDbStorage => TestConnections.ProductionDocDB;

        public IConnectionSettings CampaignTableStorage => TestConnections.ProductionTableStorageDB;

        public bool ShouldConsolidateCollections => true;
    }

    public class MetricsStorageConnections : IMetricStorageConnectionSettings
    {
        public IConnectionSettings MetricsStorageDBConenction => TestConnections.ProdMetricsStorage;
    }

}
