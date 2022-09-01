using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core.Attributes;
using System;

namespace LagoVista.Campaigns.Models
{
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


        public Decimal Budget { get; set; }
        public Decimal Spend { get; set; }

    }
}
