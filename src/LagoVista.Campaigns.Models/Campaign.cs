using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Campaign_Title, CampaignResources.Names.Campaign_Description, 
        Resources.CampaignResources.Names.Campaign_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-call-center",
        GetUrl: "/api/campaign/{id}", GetListUrl: "/api/campaigns", SaveUrl: "/api/campaign", DeleteUrl: "/api/campaign/{id}", FactoryUrl: "/api/campaign/factory")]
    public class Campaign : CampaignModelBase, IFormDescriptor, IFormDescriptorCol2, IIconEntity, ISummaryFactory
    {
        public Campaign()
        {
            Id = Guid.NewGuid().ToId();
            Icon = "icon-ae-call-center";
        }

        [FormField(LabelResource: CampaignResources.Names.Campaign_Promotions, FieldType: FieldTypes.ChildListInline, ResourceType: typeof(CampaignResources),  IsUserEditable: true)]
        public List<Promotion> Promotions { get; set; } = new List<Promotion>();


        [FormField(LabelResource: CampaignResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Icon { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Campaign_StartDate, FieldType: FieldTypes.Date, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string StartDate { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Campaign_EndDate, FieldType: FieldTypes.Date, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string EndDate { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Campaign_BudgetAllocated, HelpResource:CampaignResources.Names.Campaign_BudgetAllocated_Help, 
                IsUserEditable: true, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal BudgetAllocated { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Campaign_TotalBudget, HelpResource: CampaignResources.Names.Campaign_TotalBudget_Help, 
                IsUserEditable: false, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal TotalBudget { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Campaign_TotalSpend, IsUserEditable: false, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal TotalSpend { get; set; }


        [FormField(LabelResource: CampaignResources.Names.Campaign_Industry, IsRequired: false, FieldType: FieldTypes.Picker, EntityHeaderPickerUrl: "/api/industries", ResourceType: typeof(CampaignResources))]
        public EntityHeader Industry { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Campaign_Niche, IsRequired: false, FieldType: FieldTypes.Picker, EntityHeaderPickerUrl: "/api/industry/{industry.id}/niches", ResourceType: typeof(CampaignResources))]
        public EntityHeader IndustryNiche { get; set; }


        public CampaignSummary CreateSummary()
        {
            return new CampaignSummary()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                IsPublic = IsPublic,
                Key = Key,
                Icon = Icon,
                StartDate = StartDate,
                EndDate = EndDate,
                BudgetAllocated = BudgetAllocated,
                TotalBudget = TotalBudget,
                TotalSpend = TotalSpend
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Icon),
                nameof(StartDate),
                nameof(EndDate),
                nameof(Industry),
                nameof(IndustryNiche),                
                nameof(Description),
            };
        }

        public List<string> GetFormFieldsCol2()
        {
            return new List<string>()
            {
                nameof(BudgetAllocated),
                nameof(TotalBudget),
                nameof(TotalSpend),
                nameof(Promotions),
            };
        }

        ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Campaign_Title, CampaignResources.Names.Campaign_Description,
        Resources.CampaignResources.Names.Campaign_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-call-center",
        GetUrl: "/api/campaign/{id}", GetListUrl: "/api/campaigns", SaveUrl: "/api/campaign", DeleteUrl: "/api/campaign/{id}", FactoryUrl: "/api/campaign/factory")]
    public class CampaignSummary : SummaryData
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal TotalSpend { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal BudgetAllocated { get; set; }
    }
}
