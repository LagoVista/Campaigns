using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LagoVista.Campaigns.Models
{

    public enum EmailAttachmentFileTypes
    {
        [EnumLabel(EmailAttachment.TypeFileUpload, CampaignResources.Names.EmailAttachment_FileType_FileUpload, typeof(CampaignResources))]
        FileUpload,
        [EnumLabel(EmailAttachment.TypeProposal, CampaignResources.Names.EmailAttachment_FileType_Proposal, typeof(CampaignResources))]
        Propsoal,
        [EnumLabel(EmailAttachment.TypeAgreement, CampaignResources.Names.EmailAttachment_FileType_Agreement, typeof(CampaignResources))]
        Agreement,
        [EnumLabel(EmailAttachment.TypeInvoice, CampaignResources.Names.EmailAttachment_FileType_Invoice, typeof(CampaignResources))]
        Invoice,
    }

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.EmailAttachment_Title, CampaignResources.Names.EmailAttachment_Description,
                   CampaignResources.Names.EmailAttachment_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-editing",
                   FactoryUrl: "/api/email/attachment/factory")]
    public class EmailAttachment : IValidateable, IFormDescriptor, IFormConditionalFields
    {
        public const string TypeFileUpload = "fileupload";
        public const string TypeProposal = "proposal";
        public const string TypeAgreement = "agreement";
        public const string TypeInvoice = "invoice";

        [FormField(LabelResource: CampaignResources.Names.EmailAttachment_FileType, FieldType: FieldTypes.Picker, EnumType: typeof(EmailAttachmentFileTypes), WaterMark: CampaignResources.Names.EmailAttachment_FileType_Select, IsRequired: true, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader<EmailAttachmentFileTypes> FileType { get; set; }

        [FormField(LabelResource: CampaignResources.Names.EmailAttachment_FileType_FileUpload, FieldType: FieldTypes.FileUpload, IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader Resource { get; set; }

        [FormField(LabelResource: CampaignResources.Names.EmailAttachment_FileType_Proposal, FieldType: FieldTypes.Custom, CustomFieldType:"proposalpicker", WaterMark:CampaignResources.Names.EmailAttachment_FileType_Proposal_Select,
            EntityHeaderPickerUrl: "/api/business/proposals", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader Proposal { get; set; }

        [FormField(LabelResource: CampaignResources.Names.EmailAttachment_FileType_Agreement, FieldType: FieldTypes.Custom, CustomFieldType:"agreementpicker", WaterMark: CampaignResources.Names.EmailAttachment_FileType_Agreement_Select,
            EntityHeaderPickerUrl: "/api/agreements", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader Agreement { get; set; }

        [FormField(LabelResource: CampaignResources.Names.EmailAttachment_FileType_Invoice, FieldType: FieldTypes.Custom, CustomFieldType: "invoicepicker", WaterMark: CampaignResources.Names.EmailAttachment_FileType_Invoice_Select, 
            EntityHeaderPickerUrl: "/api/invoices", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader Invoice { get; set; }

        public FormConditionals GetConditionalFields()
        {
            return new FormConditionals()
            {
                ConditionalFields = new List<string>() { nameof(Resource), nameof(Proposal), nameof(Agreement), nameof(Invoice) },
                Conditionals = new List<FormConditional>()
                {
                    new FormConditional()
                    {
                        Field = nameof(FileType),
                        Value = TypeFileUpload,
                        RequiredFields = new List<string>() { nameof(Resource) },
                        VisibleFields = new List<string>() { nameof(Resource) },
                    },
                    new FormConditional()
                    {
                        Field = nameof(FileType),
                        Value = TypeProposal,
                        RequiredFields = new List<string>() { nameof(Proposal) },
                        VisibleFields = new List<string>() { nameof(Proposal) },
                    },
                    new FormConditional()
                    {
                        Field = nameof(FileType),
                        Value = TypeAgreement,
                        RequiredFields = new List<string>() { nameof(Agreement) },
                        VisibleFields = new List<string>() { nameof(Agreement) },
                    },
                    new FormConditional()
                    {
                        Field = nameof(FileType),
                        Value = TypeInvoice,
                        RequiredFields = new List<string>() { nameof(Invoice) },
                        VisibleFields = new List<string>() { nameof(Invoice) },
                    },
                }
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(FileType),
                nameof(Resource),
                nameof(Proposal),
                nameof(Agreement),
                nameof(Invoice),
            };
        }
    }
}
