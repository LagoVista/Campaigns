using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using Newtonsoft.Json.Linq;
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
        public EntityHeader Attr4 { get; set; }
        public EntityHeader Attr5 { get; set; }
        public EntityHeader Attr6 { get; set; }
        public EntityHeader Attr7 { get; set; }
        public EntityHeader Attr8 { get; set; }
        public decimal Value { get; set; }

        public static readonly EntityHeader DirectEmailSent = EntityHeader.Create("4A84863CF9654F009E6463C87B46D5D6", "directemailssent", "Direct Emails Sent");
        public static readonly EntityHeader DirectPostalMailSent = EntityHeader.Create("5A84863CF9654F009E6463C87B46D5D5", "postalmailssent", "Direct Mails (postal) Sent");
        public static readonly EntityHeader DirectEmailOpen = EntityHeader.Create("A8D44B760C83469EB6814100F79476FF", "directemailsopened", "Direct Emails Opended");
        public static readonly EntityHeader DirectEmailClicked = EntityHeader.Create("A9677684F14A443E93A320147929A035", "directemailclicks", "Direct Emails Clicked");
        public static readonly EntityHeader ContactPageView = EntityHeader.Create("1A84863CF9654F009E6463C87B46D5D9", "contactpageview", "Contact Page View");
        public static readonly EntityHeader ContactPageSubmitted = EntityHeader.Create("2A84863CF9654F009E6463C87B46D5D8", "contactpagesubmitted", "Contact Us Submitted");
        public static readonly EntityHeader LandingPageView = EntityHeader.Create("3A84863CF9654F009E6463C87B46D5D7", "landingpageview", "Landing Page View");

        
        public static readonly EntityHeader HotLeads = EntityHeader.Create("137942FCBCFB4BC6A876C31E2843E5FF", "hotlead", "Hot Lead");
        public static readonly EntityHeader LeadsEngaged = EntityHeader.Create("237942FCBCFB4BC6A876C31E2843E5FE", "engagedlead", "Lead Engaged");
        public static readonly EntityHeader ProposalsCreatedAndSubmitted = EntityHeader.Create("437942FCBCFB4BC6A876C31E2843E5FC", "proposalscreated", "Proposals Created and Submitted");
        public static readonly EntityHeader AgreementsCreatedAndSubmitted = EntityHeader.Create("537942FCBCFB4BC6A876C31E2843E5FB", "agreementscreated", "Agreements Created and Submitted");
        public static readonly EntityHeader CustomersConverted = EntityHeader.Create("337942FCBCFB4BC6A876C31E2843E5FD", "customerconverted", "Customer Converted");

        public static readonly EntityHeader SalesCategory = EntityHeader.Create("4B1BD86D53FA4BF6BD7DE1EAB46D96AC", "sales", "Sales");
        public static readonly EntityHeader MarketingCategory = EntityHeader.Create("30C28365B52A428BB8C32D38C690732A", "marketing", "Marketing");

        public static readonly EntityHeader TotalLeadsInSalesStage = EntityHeader.Create("AACCDDCCCBCFB4BC6A876C31E28434321", "leadsinsalesstage", "Total Leads in Sales Stage");
    }
}