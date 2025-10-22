// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 7e09f48cd1937736dffb571ed0cebe0e861a5eb072aa7853eaf79e2447ddb4ab
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Repos;
using LagoVista.Core;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Logging.Utils;
using MongoDB.Bson;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CampaignTests
{
    public class Tests
    {
        private MetricsRepo _metricsRepo;

        [SetUp]
        public void Setup()
        {
            _metricsRepo = new MetricsRepo(new LocalMetricStorageConnectionSettings(), new AdminLogger(new ConsoleLogWriter()));
        }

        [Test]
        public async Task WriteMetric()
        {
            await _metricsRepo.AddMetric(new LagoVista.Campaigns.Models.KpiMetric()
            {
                TimeStamp = DateTime.UtcNow.ToJSONString(),
                Period =  LagoVista.Campaigns.Models.KpiPeriod.Hour,
                Metric = LagoVista.Core.Models.EntityHeader.Create("4", "metrickey", "Metric Key"),
                Org = LagoVista.Core.Models.EntityHeader.Create("112233", "orgkey", "My Org Name"),
                Value = 34,
                Category = LagoVista.Core.Models.EntityHeader.Create("1", "catkey", "Category Key"),
                User = LagoVista.Core.Models.EntityHeader.Create("12344", "usidkey", "User Key"),
                Attr1 = LagoVista.Core.Models.EntityHeader.Create("1112344", "attr1", "Attr1 Key"),
                Attr2 = LagoVista.Core.Models.EntityHeader.Create("222344", "attr2", "Attr2 Key"),
                Attr3 = LagoVista.Core.Models.EntityHeader.Create("333344", "attr3", "Attr3 Key"),
            });
        }
    }

}