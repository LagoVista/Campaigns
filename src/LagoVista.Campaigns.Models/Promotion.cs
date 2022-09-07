using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core.Attributes;
using System;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Promotion_Title, CampaignResources.Names.Promotion_Description,
     Resources.CampaignResources.Names.Promotion_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources))]
    public class Promotion
    {
        public String Id { get; set; } 

        [ListColumn(HeaderResource: CampaignResources.Names.Common_Name, ResourceType: typeof(CampaignResources))]
        [FormField(LabelResource: CampaignResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [ListColumn(HeaderResource: CampaignResources.Names.Common_Key, ResourceType: typeof(CampaignResources))]
        [FormField(LabelResource: CampaignResources.Names.Common_Key, HelpResource: CampaignResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: CampaignResources.Names.Common_Key_Validation, ResourceType: typeof(CampaignResources), IsRequired: true)]
        public string Key { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(CampaignResources))]
        public string Description { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_Budget, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal Budget { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_Spend, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal Spend { get; set; }

        public List<SocialMediaPost> Posts { get; set; } = new List<SocialMediaPost>();
    }
}
