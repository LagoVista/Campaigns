// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 8142cb7b23a3637e7caefbb5cdaaeff2b850b9c1bc94c74dce7fb6fdf832062c
// IndexVersion: 0
// --- END CODE INDEX META ---
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
        [EnumLabel(EmailAttachment.TypeSignedDocument, CampaignResources.Names.EmailAttachment_FileType_SignedDocument, typeof(CampaignResources))]
        SignedDocument
    }

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.EmailAttachment_Title, CampaignResources.Names.EmailAttachment_Description,
                   CampaignResources.Names.EmailAttachment_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-editing",
                   FactoryUrl: "/api/email/attachment/factory")]
    public class EmailAttachment : IValidateable, IFormDescriptor, IFormConditionalFields
    {
        public const string TypeFileUpload = "fileupload";
        public const string TypeSignedDocument = "signedocument";
        public const string TypeContentDownload = "contentdownload";

        public string Name { get; set; }

        [FormField(LabelResource: CampaignResources.Names.EmailAttachment_FileType, FieldType: FieldTypes.Picker, EnumType: typeof(EmailAttachmentFileTypes), WaterMark: CampaignResources.Names.EmailAttachment_FileType_Select, IsRequired: true, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader<EmailAttachmentFileTypes> FileType { get; set; }

        [FormField(LabelResource: CampaignResources.Names.EmailAttachment_FileType_FileUpload, FieldType: FieldTypes.FileUpload, IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader Resource { get; set; }
        

        [FormField(LabelResource: CampaignResources.Names.EmailAttachment_FileType_SignedDocument, FieldType: FieldTypes.Custom, CustomFieldType: "invoicepicker", WaterMark: CampaignResources.Names.EmailAttachment_FileType_SignedDocument_Select, 
            EntityHeaderPickerUrl: "/api/sitecontent/{siteContentCategory.key}/all", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader SignedDocument { get; set; }

        public FormConditionals GetConditionalFields()
        {
            return new FormConditionals()
            {
                ConditionalFields = new List<string>() { nameof(Resource), nameof(SignedDocument) },
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
                        Value = TypeSignedDocument,
                        RequiredFields = new List<string>() { nameof(SignedDocument) },
                        VisibleFields = new List<string>() { nameof(SignedDocument) },
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
                nameof(SignedDocument),
            };
        }
    }
}
