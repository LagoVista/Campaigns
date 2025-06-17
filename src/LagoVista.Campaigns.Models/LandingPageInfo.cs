using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.LandingPageInfo_Title, CampaignResources.Names.LandingPageInfo_Description,
     Resources.CampaignResources.Names.LandingPageInfo_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-calling-2",
       FactoryUrl: "/api/landingpageinfo/factory")]
    public class LandingPageInfo : IFormDescriptor
    {
        public LandingPageInfo()
        {
            Id = Guid.NewGuid().ToId();
        }

        public string Id { get; set; }

        [FormField(LabelResource: CampaignResources.Names.LandingPageInfo_LandingPage, WaterMark: CampaignResources.Names.LandingPageInfo_LandingPage_Select, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/landingpages", IsRequired:true, ResourceType: typeof(CampaignResources))]
        public EntityHeader LandingPage { get; set; }

        [FormField(LabelResource: CampaignResources.Names.LandingPageInfo_Label,  FieldType: FieldTypes.Text, IsRequired:true, ResourceType: typeof(CampaignResources))]
        public string Label { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Label),
                nameof(LandingPage)
            };
        }
    }

}
