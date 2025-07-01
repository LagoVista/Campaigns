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
    public class Recipeint : IFormDescriptor, IFormConditionalFields
    {
        [FormField(LabelResource: CampaignResources.Names.Recipient_FirstName, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string FirstName { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_LastName, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string LastName { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_EmailAddress, FieldType: FieldTypes.Email, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string EmailAddress { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_Company, FieldType: FieldTypes.CustomerPicker, WaterMark: CampaignResources.Names.Recipient_Company_Select, ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Company { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_Company, FieldType: FieldTypes.Custom, CustomFieldType:"contactpicker", WaterMark: CampaignResources.Names.Recipient_Company_Select, ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Contact { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_Industry, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: CampaignResources.Names.Recipient_Industry_Select, EntityHeaderPickerUrl: "/api/industries", ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Industry { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipient_IndustryNiche, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: CampaignResources.Names.Recipient_IndustryNiche_Select, EntityHeaderPickerUrl: "/api/industry/{industry.id}/niches", ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader IndustryNiche { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Recipeint_Persona, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: CampaignResources.Names.Recipeint_Persona_Select, EntityHeaderPickerUrl: "/api/personas", ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Persona { get; set; }

        public FormConditionals GetConditionalFields()
        {
            return new FormConditionals()
            {
                ConditionalFields = new List<string>() { nameof(FirstName), nameof(LastName), nameof(EmailAddress)},
                Conditionals = new List<FormConditional>()
                {
                   new FormConditional()
                   {
                        Field = nameof(Contact),
                        NotSet = true,
                        RequiredFields = new List<string>() {nameof(FirstName), nameof(LastName), nameof(EmailAddress)},
                        VisibleFields = new List<string>() {nameof(FirstName), nameof(LastName), nameof(EmailAddress)}
                   },
                   new FormConditional()
                   {
                        Field = nameof(Contact),
                        Value = "*",
                        VisibleFields = new List<string>() {}
                   },
                }
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(FirstName),
                nameof(LastName),
                nameof(EmailAddress),
                nameof(Company),
                nameof(Contact),
                nameof(Industry),
                nameof(IndustryNiche),
                nameof(Persona),
            };
        }
    }
}
