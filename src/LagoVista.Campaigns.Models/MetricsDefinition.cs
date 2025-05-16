using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.Campaigns.Models
{
    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.MetricsDefinition_Title, CampaignResources.Names.MetricsDefinition_Description,
           Resources.CampaignResources.Names.MetricsDefinition_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-pz-stock-1",
            GetUrl: "/api/metrics/definition/{id}", GetListUrl: "/api/metrics/definitions", SaveUrl: "/api/metrics/definition", DeleteUrl: "/api/metrics/definition/{id}", FactoryUrl: "/api/metrics/definition/factory")]
    public class MetricsDefinition : CampaignModelBase, IFormDescriptor, IFormDescriptorCol2, IIconEntity, ISummaryFactory, ICategorized
    {
        public MetricsDefinition() 
        {
            Id = Guid.NewGuid().ToId();
            Icon = "icon-pz-stock-1";
        }

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


        [FormField(LabelResource: CampaignResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Icon { get; set; }
    
        public MetricsDefinitionSummary CreateSummary()
        {
            var summary = new MetricsDefinitionSummary();
            summary.Populate(this);
            return summary;
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(IsPublic),
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
           GetUrl: "/api/metrics/definition/{id}", GetListUrl: "/api/metrics/definition", SaveUrl: "/api/metrics/definition", DeleteUrl: "/api/metrics/definition/{id}", FactoryUrl: "/api/metrics/definition/factory")]
    public class MetricsDefinitionSummary : SummaryData
    {

    }
}
