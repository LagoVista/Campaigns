// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 7903ead0f36f73ab13d732d775130b401416da8a58f0ceba7b4701c3e5b4cb1f
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.SocialMediaPost_Title, CampaignResources.Names.SocialMediaPost_Description,
     Resources.CampaignResources.Names.SocialMediaPost_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-calling-2",
       FactoryUrl: "/api/campaign/promotion/post/factory")]
    public class SocialMediaPost : IFormDescriptor
    {
        public SocialMediaPost()
        {
            Id = Guid.NewGuid().ToId();
        }

        public string Id { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Post_Title, IsRequired: true, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Name { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Post_Content, IsRequired: true, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(CampaignResources))]
        public string Content { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Post_Account, IsRequired: false, FieldType: FieldTypes.EntityHeaderPicker, 
            WaterMark:CampaignResources.Names.Post_Account_Watermark, ResourceType: typeof(CampaignResources))]
        public EntityHeader SocialMediaAccount {get; set;}

        [FormField(LabelResource: CampaignResources.Names.Post_SiteContent, IsRequired: false, HelpResource:CampaignResources.Names.Post_SiteContent_Help, 
            WaterMark:CampaignResources.Names.Post_SiteContent_Watermark, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(CampaignResources))]
        public EntityHeader SiteContent { get; set;}

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(SocialMediaAccount),
                nameof(SiteContent),
                nameof(Content),
            };
        }
    }
}
