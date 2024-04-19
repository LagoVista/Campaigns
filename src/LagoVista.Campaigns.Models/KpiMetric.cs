using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.Campaigns.Models
{
    public class KpiMetric
    {
        public string TimeStamp { get; set; }

        public KpiPeriod Period { get; set; }
        public EntityHeader Org { get; set; }
        public EntityHeader User { get; set; }
        public EntityHeader Category { get; set; }
        public EntityHeader Metric { get; set; }
        public EntityHeader Attr1 { get; set; }
        public EntityHeader Attr2 { get; set; }
        public EntityHeader Attr3 { get; set; }
        public decimal Value { get; set; }
    }
}
