using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Promotion_Title, CampaignResources.Names.Promotion_Description,
     Resources.CampaignResources.Names.Promotion_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-calling-2",
       FactoryUrl: "/api/campaign/promotion/factory")]
    public class Promotion : IFormDescriptor, IFormDescriptorCol2, IIconEntity
    {
        public Promotion()
        {
            Id = Guid.NewGuid().ToId();
            Icon = "icon-ae-calling-2";
        }

        public String Id { get; set; } 

        [ListColumn(HeaderResource: CampaignResources.Names.Common_Name, ResourceType: typeof(CampaignResources))]
        [FormField(LabelResource: CampaignResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }


        [FormField(LabelResource: CampaignResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Icon { get; set; }


        [ListColumn(HeaderResource: CampaignResources.Names.Common_Key, ResourceType: typeof(CampaignResources))]
        [FormField(LabelResource: CampaignResources.Names.Common_Key, HelpResource: CampaignResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: CampaignResources.Names.Common_Key_Validation, ResourceType: typeof(CampaignResources), IsRequired: true)]
        public string Key { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(CampaignResources))]
        public string Description { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_Budget, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal Budget { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_Spend, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal Spend { get; set; }

       
        [FormField(LabelResource: CampaignResources.Names.Promotion_Posts, FieldType: FieldTypes.ChildListInline, FactoryUrl: "/api/campaign/promotion/post/factory",
            ResourceType: typeof(CampaignResources))]
        public List<SocialMediaPost> Posts { get; set; } = new List<SocialMediaPost>();

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Icon),
                nameof(Budget),
                nameof(Spend),
                nameof(Description),
            };
        }

        public List<string> GetFormFieldsCol2()
        {
            return new List<string>()
            {  
                nameof(Posts),
            };
        }
    }
}
