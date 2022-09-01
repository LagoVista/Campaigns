using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.Campaigns.Models
{
    public class CampaignModelBase : IIDEntity, IValidateable, IOwnedEntity, INamedEntity, IAuditableEntity, INoSQLEntity
    {
        public CampaignModelBase()
        {
            Id = Guid.NewGuid().ToId();
        }

        [JsonProperty("id")]
        public String Id { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Common_IsPublic, FieldType: FieldTypes.CheckBox, ResourceType: typeof(CampaignResources))]
        public bool IsPublic { get; set; }

        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }
        public string CreationDate { get; set; }
        public string LastUpdatedDate { get; set; }
        public EntityHeader CreatedBy { get; set; }
        public EntityHeader LastUpdatedBy { get; set; }
        public string DatabaseName { get; set; }
        public string EntityType { get; set; }


        [ListColumn(HeaderResource: CampaignResources.Names.Common_Name, ResourceType: typeof(CampaignResources))]
        [FormField(LabelResource: CampaignResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [ListColumn(HeaderResource: CampaignResources.Names.Common_Key, ResourceType: typeof(CampaignResources))]
        [FormField(LabelResource: CampaignResources.Names.Common_Key, HelpResource: CampaignResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: CampaignResources.Names.Common_Key_Validation, ResourceType: typeof(CampaignResources), IsRequired: true)]
        public string Key { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(CampaignResources))]
        public string Description { get; set; }
    }
}
