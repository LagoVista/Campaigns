using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.Campaigns.Models
{
    public enum KpiPeriod
    {
        [EnumLabel(Kpi.Kpi_Period_Hour, CampaignResources.Names.Kpi_Period_Hour, typeof(CampaignResources))]
        Hour,
        [EnumLabel(Kpi.Kpi_Period_Day, CampaignResources.Names.Kpi_Period_Day, typeof(CampaignResources))]
        Day,
        [EnumLabel(Kpi.Kpi_Period_Week, CampaignResources.Names.Kpi_Period_Week, typeof(CampaignResources))]
        Week,
        [EnumLabel(Kpi.Kpi_Period_Hour, CampaignResources.Names.Kpi_Period_Hour, typeof(CampaignResources))]
        Month
    }


    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Kpi_Title, CampaignResources.Names.Kpi_Description,
            Resources.CampaignResources.Names.Kpi_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-call-center",
                       GetUrl: "/api/kpi/{id}", GetListUrl: "/api/kpis", SaveUrl: "/api/kpi", DeleteUrl: "/api/kpi/{id}", FactoryUrl: "/api/kpi/factory")]
    public class Kpi : CampaignModelBase, IFormDescriptor, IIconEntity, ISummaryFactory, ICategorized
    {
        public const string Kpi_Period_Month = "month";
        public const string Kpi_Period_Day = "day";
        public const string Kpi_Period_Week = "week";
        public const string Kpi_Period_Hour = "hour";

        public Kpi()
        {
            Id = Guid.NewGuid().ToId();
            Icon = "icon-ae-call-center";
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Icon),
                nameof(Category),
                nameof(Period),
                nameof(TargetValue),
                nameof(Description)
            };
        }


        [FormField(LabelResource: CampaignResources.Names.Kpi_Period, FieldType: FieldTypes.Picker, WaterMark: CampaignResources.Names.Kpi_Period_Select, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader<KpiPeriod> Period { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Common_Category, FieldType: FieldTypes.Category, WaterMark: CampaignResources.Names.Common_SelectCategory, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader Category { get; set; }


        [FormField(LabelResource: CampaignResources.Names.Kpi_TargetValue, IsUserEditable: false, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal TargetValue { get; set; }

        public KpiSummary CreateSummary()
        {
            return new KpiSummary()
            {
                Name = Name,
                Icon = Icon,
                Id = Id,
                Description = Description,
                IsPublic = IsPublic,
                Category = Category,
                Key = Key,
            };
        }

        ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }

        [FormField(LabelResource: CampaignResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Icon { get; set; }

    }

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Kpis_Title, CampaignResources.Names.Kpi_Description,
            Resources.CampaignResources.Names.Kpi_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(CampaignResources), Icon: "icon-ae-call-center",
            GetUrl: "/api/kpi/{id}", GetListUrl: "/api/kpis", SaveUrl: "/api/kpi", DeleteUrl: "/api/kpi/{id}", FactoryUrl: "/api/kpi/factory")]
    public class KpiSummary : CategorizedSummaryData
    {
        public decimal TargetValue { get; set; }
    }
}
