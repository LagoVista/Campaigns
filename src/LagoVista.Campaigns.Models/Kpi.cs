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
        [EnumLabel(Kpi.Kpi_Period_Month, CampaignResources.Names.Kpi_Period_Month, typeof(CampaignResources))]
        Month,
        [EnumLabel(Kpi.Kpi_Period_Each, CampaignResources.Names.Kpi_Period_Each, typeof(CampaignResources))]
        Each
    }

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Kpi_Title, CampaignResources.Names.Kpi_Description,
            Resources.CampaignResources.Names.Kpi_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-pz-presentation",
                       GetUrl: "/api/kpi/{id}", GetListUrl: "/api/kpis", SaveUrl: "/api/kpi", DeleteUrl: "/api/kpi/{id}", FactoryUrl: "/api/kpi/factory")]
    public class Kpi : CampaignModelBase, IFormDescriptor, IFormDescriptorCol2, IIconEntity, ISummaryFactory, ICategorized
    {
        public const string Kpi_Period_Month = "month";
        public const string Kpi_Period_Day = "day";
        public const string Kpi_Period_Week = "week";
        public const string Kpi_Period_Hour = "hour";
        public const string Kpi_Period_Each = "each";

        public Kpi()
        {
            Id = Guid.NewGuid().ToId();
            Icon = "icon-pz-presentation";
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Icon),
                nameof(Category),                
                nameof(Description)
            };
        }


        [FormField(LabelResource: CampaignResources.Names.Kpi_Metric, WaterMark:CampaignResources.Names.Kpi_Metric_Select, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/metrics/definitions",
            ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader Metric { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Kpi_Period, FieldType: FieldTypes.Picker, WaterMark: CampaignResources.Names.Kpi_Period_Select, EnumType:typeof(KpiPeriod), 
            ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader<KpiPeriod> Period { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Common_Category, FieldType: FieldTypes.Category, WaterMark: CampaignResources.Names.Common_SelectCategory, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader Category { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Kpi_Attribute1, FieldType: FieldTypes.Picker, ResourceType: typeof(CampaignResources))]
        public EntityHeader Attr1 { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Kpi_Attribute2, FieldType: FieldTypes.Picker, ResourceType: typeof(CampaignResources))]
        public EntityHeader Attr2 { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Kpi_Attribute3, FieldType: FieldTypes.Picker, ResourceType: typeof(CampaignResources))]
        public EntityHeader Attr3 { get; set; }


        [FormField(LabelResource: CampaignResources.Names.Kpi_TargetValue, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
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

        public List<string> GetFormFieldsCol2()
        {
            return new List<string>()
            {
                nameof(TargetValue),
                nameof(Metric),
                nameof(Period),
                nameof(Attr1),
                nameof(Attr2),
                nameof(Attr3),
            };
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
