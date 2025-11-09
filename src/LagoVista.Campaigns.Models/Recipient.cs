// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 07e834e5c5e1c7e072e3ae13ae4afcf19948a86878705aa196fcbfa6c1633107
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Recipient_Title, CampaignResources.Names.Recipient_Description,
     Resources.CampaignResources.Names.Recipient_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-pz-support-1",
       FactoryUrl: "/api/recipient/factory")]
    public class Recipient : IFormDescriptor
    {
        [FormField(LabelResource: CampaignResources.Names.Recipient_FirstName, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string FirstName { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_LastName, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string LastName { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_EmailAddress, FieldType: FieldTypes.Email, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string EmailAddress { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_Company, FieldType: FieldTypes.CustomerPicker, WaterMark: CampaignResources.Names.Recipient_Company_Select, ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Company { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_Contact, FieldType: FieldTypes.ContactPicker, WaterMark: CampaignResources.Names.Recipient_Contact_Select, ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Contact { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_Industry, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: CampaignResources.Names.Recipient_Industry_Select, EntityHeaderPickerUrl: "/api/industries", ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Industry { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_IndustryNiche, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: CampaignResources.Names.Recipient_IndustryNiche_Select, EntityHeaderPickerUrl: "/api/industry/{industry.id}/niches", ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader IndustryNiche { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipeint_Persona, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: CampaignResources.Names.Recipeint_Persona_Select, EntityHeaderPickerUrl: "/api/personas", ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Persona { get; set; }

 
        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Company),
                nameof(Contact),
                nameof(FirstName),
                nameof(LastName),
                nameof(Persona),
                nameof(EmailAddress),
                nameof(Industry),
                nameof(IndustryNiche),
            };
        }
    }
}
