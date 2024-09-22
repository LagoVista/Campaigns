using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    public enum PromotionTypes
    {
        [EnumLabel(Promotion.PromotType_Email, CampaignResources.Names.Promotion_Type_Email, typeof(CampaignResources))]
        Email,
        [EnumLabel(Promotion.PromotType_ColdCall, CampaignResources.Names.Promotion_Type_ColdCall, typeof(CampaignResources))]
        ColdCall,
        [EnumLabel(Promotion.PromotType_WebAd, CampaignResources.Names.Promotion_Type_WebAd, typeof(CampaignResources))]
        WebAd,
        [EnumLabel(Promotion.PromotType_SocialMedia, CampaignResources.Names.Promotion_Type_SocialMedia, typeof(CampaignResources))]
        SocialMedia,
        [EnumLabel(Promotion.PromotType_Other, CampaignResources.Names.Promotion_Type_Other, typeof(CampaignResources))]
        Other,
    }

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Promotion_Title, CampaignResources.Names.Promotion_Description,
     Resources.CampaignResources.Names.Promotion_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-calling-2",
       FactoryUrl: "/api/campaign/promotion/factory")]
    public class Promotion : IFormDescriptor, IFormDescriptorCol2, IIconEntity
    {
        public const string PromotType_Email = "email";
        public const string PromotType_ColdCall = "coldcall";
        public const string PromotType_WebAd = "webad";
        public const string PromotType_SocialMedia = "socialmedia";
        public const string PromotType_Other = "other";

        public Promotion()
        {
            Id = Guid.NewGuid().ToId();
            Icon = "icon-ae-calling-2";
            PromotionType = EntityHeader<PromotionTypes>.Create(PromotionTypes.Other);
        }

        public String Id { get; set; } 

        [ListColumn(HeaderResource: CampaignResources.Names.Common_Name, ResourceType: typeof(CampaignResources))]
        [FormField(LabelResource: CampaignResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(CampaignResources), IsRequired: true, IsUserEditable: true)]
        public string Icon { get; set; }


        [FormField(LabelResource: CampaignResources.Names.Promotion_IndustryNiche, IsRequired: false, FieldType: FieldTypes.Picker, EntityHeaderPickerUrl: "/api/industry/{parent.industry.id}/niches", ResourceType: typeof(CampaignResources))]
        public EntityHeader IndustryNiche { get; set; }

        [FKeyProperty("EmailTemplate", WhereClause:"EmailTemplate.Id = {0}")]
        [FormField(LabelResource: CampaignResources.Names.Promotion_EmailTemplate, IsRequired: false, EntityHeaderPickerUrl: "/api/sales/emailtemplates", FieldType: FieldTypes.EntityHeaderPicker, WaterMark: CampaignResources.Names.Promotion_EmailTemplate_Select, ResourceType: typeof(CampaignResources))]
        public EntityHeader EmailTemplate { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_ExternalCampaignId, FieldType: FieldTypes.Text, ResourceType: typeof(CampaignResources), IsRequired: false)]
        public string ExternalCampaignId { get; set; }

        [FKeyProperty("Survey", WhereClause: "Survey.Id = {0}")]
        [FormField(LabelResource: CampaignResources.Names.Promotion_Survey, IsRequired: false, EntityHeaderPickerUrl: "/api/surveyadmin/surveys", FieldType: FieldTypes.EntityHeaderPicker, WaterMark: CampaignResources.Names.Promotion_Survey_Select, ResourceType: typeof(CampaignResources))]
        public EntityHeader Survey { get; set; }

        [ListColumn(HeaderResource: CampaignResources.Names.Common_Key, ResourceType: typeof(CampaignResources))]
        [FormField(LabelResource: CampaignResources.Names.Common_Key, HelpResource: CampaignResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: CampaignResources.Names.Common_Key_Validation, ResourceType: typeof(CampaignResources), IsRequired: true)]
        public string Key { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(CampaignResources))]
        public string Description { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_Budget, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal Budget { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_Spend, IsRequired: true, FieldType: FieldTypes.Decimal, ResourceType: typeof(CampaignResources))]
        public Decimal Spend { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_Owner, IsRequired: false, FieldType: FieldTypes.UserPicker, WaterMark: CampaignResources.Names.Promotion_Owner_Select, ResourceType: typeof(CampaignResources))]
        public EntityHeader Owner { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_ExcludeWeekend, IsRequired: true, FieldType: FieldTypes.CheckBox, ResourceType: typeof(CampaignResources))]
        public bool ExcludeWeekends { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_DailyGoal, IsRequired: true, FieldType: FieldTypes.Integer, ResourceType: typeof(CampaignResources))]
        public int DailyGoal { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_PromoType, ResourceType: typeof(CampaignResources), IsRequired: true, FieldType: FieldTypes.Picker,
            EnumType: typeof(PromotionTypes), WaterMark: CampaignResources.Names.Promotion_Type_Select)]
        public EntityHeader<PromotionTypes> PromotionType { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_LandingPage, WaterMark:CampaignResources.Names.Promotion_LandingPage_Select, FieldType: FieldTypes.Custom, CustomFieldType:"landingpagepicker", ResourceType: typeof(CampaignResources))]
        public LandingPageSummary LandingPage { get; set; }

        [FormField(LabelResource: CampaignResources.Names.Promotion_ProductPage, FieldType: FieldTypes.EntityHeaderPicker, WaterMark:CampaignResources.Names.Promotion_ProductPage_Select, EntityHeaderPickerUrl: "/api/product/page/list", ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader ProductPage { get; set; }


        [FormField(LabelResource: CampaignResources.Names.Promotion_EmailList, FieldType: FieldTypes.EntityHeaderPicker, WaterMark:CampaignResources.Names.Promotion_EmailList_Select, EntityHeaderPickerUrl: "/api/product/page/list", ResourceType: typeof(CampaignResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader EmailList { get; set; }

        public List<PromotionProgress> Progress { get; set; } = new List<PromotionProgress>();

        [FormField(LabelResource: CampaignResources.Names.Promotion_Posts, FieldType: FieldTypes.ChildListInline, FactoryUrl: "/api/campaign/promotion/post/factory",
            ResourceType: typeof(CampaignResources))]
        public List<SocialMediaPost> Posts { get; set; } = new List<SocialMediaPost>();

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(IndustryNiche),
                nameof(PromotionType),
                nameof(EmailTemplate),
                nameof(LandingPage),
                nameof(Survey),
                nameof(ProductPage),
                nameof(Owner),
                nameof(ExternalCampaignId),
                nameof(Icon),
                nameof(ExcludeWeekends),
                nameof(DailyGoal),
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

    public class LandingPageSummary
    {
        public string Id { get; set; }
        public EntityHeader Page { get; set; }
        public EntityHeader Industry { get; set; }
        public EntityHeader Niche { get; set; }
        public EntityHeader Persona { get; set; }
        public string Link { get; set; }
    }
}
