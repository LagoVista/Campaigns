// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 682238b9499577c48788ae399aefd9753138311e268c3d3547f4a7d67a83d7dc
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Resources;
using LagoVista.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.Campaigns.Models
{
    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.MetricsDefinition_Title, CampaignResources.Names.MetricsDefinition_Description,
           Resources.CampaignResources.Names.MetricsDefinition_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-pz-stock-1",
            GetUrl: "/api/metrics/definition/{id}", GetListUrl: "/api/metrics/definitions", SaveUrl: "/api/metrics/definition", DeleteUrl: "/api/metrics/definition/{id}", FactoryUrl: "/api/metrics/definition/factory")]
    public class MetricsDefinition : IFormDescriptor, IFormDescriptorCol2, IIconEntity, ISummaryFactory, ICategorized, IValidateable
    {
        public MetricsDefinition()
        {
            Id = Guid.NewGuid().ToId();
            Icon = "icon-pz-stock-1";
        }

        [CloneOptions(false)]
        [FormField(LabelResource: LagoVistaCommonStrings.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(LagoVistaCommonStrings), IsRequired: true, IsUserEditable: true)]
        public virtual string Name { get; set; }

        [CloneOptions(false)]
        [FormField(LabelResource: LagoVistaCommonStrings.Names.Common_Key, HelpResource: LagoVistaCommonStrings.Names.Common_Key_Help, FieldType: FieldTypes.Key,
            RegExValidationMessageResource: LagoVistaCommonStrings.Names.Common_Key_Validation, ResourceType: typeof(LagoVistaCommonStrings), IsRequired: true)]
        public virtual string Key { get; set; }

        [FormField(LabelResource: LagoVistaCommonStrings.Names.Common_Category, FieldType: FieldTypes.Category, WaterMark: LagoVistaCommonStrings.Names.Common_Category_Select, ResourceType: typeof(LagoVistaCommonStrings), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Category { get; set; }

        public bool IsReadOnly { get; set; }


        public string Id { get; set; }

        [FormField(LabelResource: LagoVistaCommonStrings.Names.Common_Summary, IsRequired: true, FieldType: FieldTypes.Text, ResourceType: typeof(LagoVistaCommonStrings))]
        public string Summary { get; set; }

        [FormField(LabelResource: LagoVistaCommonStrings.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(LagoVistaCommonStrings))]
        public string Description { get; set; }

        public string Help { get; set; }

        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr1Name, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute1Name { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr1Key, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute1Key { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr2Name, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute2Name { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr2Key, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute2Key { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr3Name, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute3Name { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr3Key, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute3Key { get; set; }

        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr4Name, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute4Name { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr4Key, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute4Key { get; set; }

        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr5Name, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute5Name { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr5Key, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute5Key { get; set; }

        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr6Name, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute6Name { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr6Key, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute6Key { get; set; }

        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr7Name, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute7Name { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr7Key, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute7Key { get; set; }


        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr8Name, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute8Name { get; set; }
        [FormField(LabelResource: CampaignResources.Names.MetricDefinition_Attr8Key, IsRequired: false, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources))]
        public string Attribute8Key { get; set; }


        [FormField(LabelResource: CampaignResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Icon { get; set; }
    
        public MetricsDefinitionSummary CreateSummary()
        {
            var summary = new MetricsDefinitionSummary()
            {
                Name = Name,
                Key = Key,
                Description = Description,
                Category = Category?.Text,
                CategoryId = Category?.Id,
                CategoryKey = Category?.Key,
                Id = Id,
                Icon = Icon,
                IsDeleted = false,
                IsPublic = false,
            };

            return summary;
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Summary),
                nameof(Category),
                nameof(Icon),
                nameof(Description)
            };
        }

        public List<string> GetFormFieldsCol2()
        {
            return new List<string>()
            {
                nameof(Attribute1Name),
                nameof(Attribute1Key),
                nameof(Attribute2Name),
                nameof(Attribute2Key),
                nameof(Attribute3Name),
                nameof(Attribute3Key),
                nameof(Attribute4Name),
                nameof(Attribute4Key),
                nameof(Attribute5Name),
                nameof(Attribute5Key),
                nameof(Attribute6Name),
                nameof(Attribute6Key),
            };
        }

        ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.MetricsDefinitions_TItle, CampaignResources.Names.MetricsDefinition_Description,
           Resources.CampaignResources.Names.MetricsDefinition_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(CampaignResources), Icon: "icon-ae-call-center",
           GetUrl: "/api/metrics/definition/{id}", GetListUrl: "/api/metrics/definitions", SaveUrl: "/api/metrics/definition", DeleteUrl: "/api/metrics/definition/{id}", FactoryUrl: "/api/metrics/definition/factory")]
    public class MetricsDefinitionSummary : SummaryData
    {
        public string Summary { get; set; }
        public string Help { get; set; }
    }
}
