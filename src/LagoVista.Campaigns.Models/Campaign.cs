﻿using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Campaign_Title, CampaignResources.Names.Campaign_Description, 
        Resources.CampaignResources.Names.Campaign_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources),
        GetUrl: "/api/campaign/{id}", GetListUrl: "/api/campaigns", SaveUrl: "/api/campaign", DeleteUrl: "/api/campaign/{id}", FactoryUrl: "/api/campaign/factory")]

    public class Campaign : CampaignModelBase, IFormDescriptor
    {
        [FormField(LabelResource: CampaignResources.Names.Campaign_Promotions, FieldType: FieldTypes.ChildListInline, ResourceType: typeof(CampaignResources),  IsUserEditable: true)]
        public List<Promotion> Promotions { get; set; } = new List<Promotion>();

        [FormField(LabelResource: CampaignResources.Names.Campaign_StartDate, FieldType: FieldTypes.Date, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string StartDate { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Campaign_EndDate, FieldType: FieldTypes.Date, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string EndDate { get; set; }
    
        public CampaignSummary CreateSummary()
        {
            return new CampaignSummary()
            {
                Id = Id,
                Description = Description,
                Name = Name,
                IsPublic = IsPublic,
                Key = Key,
                StartDate = StartDate,
                EndDate = EndDate,
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Description),
                nameof(StartDate),
                nameof(EndDate),
                nameof(Promotions),
            };
        }
    }


    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Campaign_Title, CampaignResources.Names.Campaign_Description,
        Resources.CampaignResources.Names.Campaign_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources),
        GetUrl: "/api/campaign/{id}", GetListUrl: "/api/campaigns", SaveUrl: "/api/campaign", DeleteUrl: "/api/campaign/{id}", FactoryUrl: "/api/campaign/factory")]
    public class CampaignSummary : SummaryData
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
