using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using NLog.Layouts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LagoVista.Campaigns.Models
{
    public enum PageLinkTypes
    {
        [EnumLabel(PageLink.TypeParentMenu, CampaignResources.Names.PageLink_Type_ParentMenu, typeof(CampaignResources))]
        ParentMenu,
        [EnumLabel(PageLink.TypeLink, CampaignResources.Names.PageLink_Type_Link, typeof(CampaignResources))]
        Link,
        [EnumLabel(PageLink.TypeLandingPage, CampaignResources.Names.PageLink_Type_LandingPage, typeof(CampaignResources))]
        LandingPage,
        [EnumLabel(PageLink.TypeContactInformationPage, CampaignResources.Names.PageLink_Type_ContactInformationPage, typeof(CampaignResources))]
        ContactInformationPage,
        [EnumLabel(PageLink.TypeContactUsPage, CampaignResources.Names.PageLink_Type_ContactUsPage, typeof(CampaignResources))]
        ContactUsPage,
        [EnumLabel(PageLink.TypeLoginPage, CampaignResources.Names.PageLink_Type_LoginPage, typeof(CampaignResources))]
        LoginPage,
        [EnumLabel(PageLink.TypeLogoutPage, CampaignResources.Names.PageLink_Type_LogoutPage, typeof(CampaignResources))]
        LogoutPage,
        [EnumLabel(PageLink.TypeSiteContentPage, CampaignResources.Names.PageLink_Type_SiteContactPage, typeof(CampaignResources))]
        SiteContentPage,
        [EnumLabel(PageLink.TypeSiteContentCategory, CampaignResources.Names.PageLink_Type_SiteContactCategory, typeof(CampaignResources))]
        SiteContentCategory,
        [EnumLabel(PageLink.TypeFaq, CampaignResources.Names.PageLink_Type_FaqPage, typeof(CampaignResources))]
        Faq,
        [EnumLabel(PageLink.TypeGlossary, CampaignResources.Names.PageLink_Type_GlossaryPage, typeof(CampaignResources))]
        Glossary,
        [EnumLabel(PageLink.TypeNuvIoTService, CampaignResources.Names.PageLink_Type_NuvIoTService, typeof(CampaignResources))]
        NuvIoTService,
        [EnumLabel(PageLink.TypeProductCatalog, CampaignResources.Names.PageLink_Type_TypeProductCatalog, typeof(CampaignResources))]
        ProductCatalog,
        [EnumLabel(PageLink.TypeProductCategoryType, CampaignResources.Names.PageLink_Type_ProductCategoryType, typeof(CampaignResources))]
        ProductCategoryType,
        [EnumLabel(PageLink.TypeProductCategory, CampaignResources.Names.PageLink_Type_ProductCategory, typeof(CampaignResources))]
        ProductCategory,
        [EnumLabel(PageLink.TypeProductPage, CampaignResources.Names.PageLink_Type_ProductPage, typeof(CampaignResources))]
        Product,
        [EnumLabel(PageLink.TypeSurvey, CampaignResources.Names.PageLink_Type_Survey, typeof(CampaignResources))]
        Survey,
        [EnumLabel(PageLink.TypeContentDownload, CampaignResources.Names.PageLink_Type_ContentDownload, typeof(CampaignResources))]
        ContentDownload,
    }

    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.PageLink_Title, CampaignResources.Names.PageLink_Description,
                   CampaignResources.Names.PageLink_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources), Icon: "icon-ae-editing",
                   FactoryUrl: "/api/pagelink/factory")]
    public class PageLink : IValidateable, IFormDescriptor, IFormConditionalFields
    {
        public const string TypeParentMenu = "parentmenu";
        public const string TypeLink = "link";
        public const string TypeLoginPage = "loginpage";
        public const string TypeLogoutPage = "logoutpage";
        public const string TypeLandingPage = "landingpage";
        public const string TypeContactInformationPage = "contactinformationpage";
        public const string TypeContactUsPage = "contactuspage";
        public const string TypeFaqPage = "faqpage";
        public const string TypeSiteContentCategory = "sitecontentcategory";
        public const string TypeSiteContentPage = "sitecontentpage";
        public const string TypeFaq = "faq";
        public const string TypeGlossary = "glossary";
        public const string TypeNuvIoTService = "nuviotservice";
        public const string TypeProductCatalog = "productcatalog";
        public const string TypeProductCategoryType = "productcategorytype";
        public const string TypeProductCategory = "productcategory";
        public const string TypeProductPage = "productpage";
        public const string TypeSurvey = "survey";
        public const string TypeContentDownload = "contentdownload";


        public string Id { get; set; } = Guid.NewGuid().ToId();

        [FormField(LabelResource: CampaignResources.Names.PageLink_Label, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: (typeof(CampaignResources)))]
        public string Label { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_LinkType, FieldType: FieldTypes.Picker, EnumType: typeof(PageLinkTypes), WaterMark: CampaignResources.Names.PageLink_LinkTypeSelect, IsRequired: true, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader<PageLinkTypes> Type { get; set; }


        [FormField(LabelResource: CampaignResources.Names.PageLink_SiteContentCategory, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/categories/sitecontent", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader SiteContentCategory { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_SiteContentPage, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/sitecontent/{siteContentCategory.key}/all", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader SiteContentPage { get; set; }


        [FormField(LabelResource: CampaignResources.Names.PageLink_SiteContentCategory, FieldType: FieldTypes.Text, EntityHeaderPickerUrl: "/api/categories/sitecontent", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader Glossary { get; set; }


        [FormField(LabelResource: CampaignResources.Names.PageLink_Label, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: (typeof(CampaignResources)))]
        public string LinkUrl { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_LandingPage, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/landingpages", EditorPath: "/contentmanagement/landingpage/{id}", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader LandingPage { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_LandingPage, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/content/downloads/published", EditorPath: "/contentmanagement/download/{id}", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader ContentDownload { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_ToolTip, FieldType: FieldTypes.Text, IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public string ToolTip { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_ProductCategory, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/product/category/types", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader ProductCategoryType { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_ProductCategory, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/product/categories", EditorPath: "/business/productcatalogs/products", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader ProductCategory { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_ProductPage, FieldType: FieldTypes.ProductPicker, IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader Product { get; set; }

        [FormField(LabelResource: CampaignResources.Names.PageLink_Survey, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/surveys", EditorPath: "/contentmanagement/surveys/edit/{id}", IsRequired: false, ResourceType: (typeof(CampaignResources)))]
        public EntityHeader Survey { get; set; }

        public List<PageLink> SubMenus { get; set; } = new List<PageLink>();

        public FormConditionals GetConditionalFields()
        {
            return new FormConditionals()
            {
                ConditionalFields = new List<string>()
                {
                    nameof(SiteContentCategory),
                    nameof(SiteContentPage),
                    nameof(ContentDownload),
                    nameof(Glossary),
                    nameof(LinkUrl),
                    nameof(LandingPage),
                    nameof(ProductCategory),
                    nameof(ProductCategoryType),
                    nameof(Product)
                },
                Conditionals = new List<FormConditional>()
                {
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeContentDownload, RequiredFields = new List<string>() { nameof(ContentDownload) }, VisibleFields = new List<string>() { nameof(ContentDownload) } },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeParentMenu, RequiredFields = new List<string>() { }, VisibleFields = new List<string>() { nameof(SubMenus) } },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeLink, RequiredFields = new List<string>() {nameof(LinkUrl) }, VisibleFields = new List<string>() { nameof(LinkUrl) } },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeLandingPage, RequiredFields = new List<string>() { nameof(LandingPage) }, VisibleFields = new List<string>() { nameof(LandingPage) } },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeLoginPage },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeLoginPage },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeLoginPage },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeFaqPage },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeProductCategoryType, RequiredFields = new List<string>() {nameof(ProductCategoryType) }, VisibleFields = new List<string>() {nameof(ProductCategoryType) }  },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeProductCategory, RequiredFields = new List<string>() {nameof(ProductCategoryType), nameof(ProductCategory) }, VisibleFields = new List<string>() {nameof(ProductCategoryType), nameof(ProductCategory) }  },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeProductPage,  RequiredFields = new List<string>() {nameof(Product) }, VisibleFields = new List<string>() {nameof(ProductCategoryType) }  },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeContactInformationPage },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeContactUsPage },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeGlossary, RequiredFields = new List<string>() {nameof(Glossary) } },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeNuvIoTService },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeSiteContentCategory, RequiredFields = new List<string>() { nameof(SiteContentCategory) }, VisibleFields = new List<string>() { nameof(SiteContentCategory) } },
                    new FormConditional(){ Field = nameof(Type), Value = PageLink.TypeSiteContentPage, RequiredFields = new List<string>() { nameof(SiteContentCategory), nameof(SiteContentPage) }, VisibleFields = new List<string>() { nameof(SiteContentCategory), nameof(SiteContentPage) } },
                }
            };
        }

        public string GetLinkPath(string orgNameSpace, string rootUrl)
        {
            switch (Type.Value)
            {
                case PageLinkTypes.LandingPage:
                    return $"{rootUrl}/lp/{orgNameSpace}/{LandingPage.Key}";
                case PageLinkTypes.LogoutPage:
                    return $"{rootUrl}/auth/logout";
                case PageLinkTypes.LoginPage:
                    return $"{rootUrl}/auth/welcome";
                case PageLinkTypes.ParentMenu:
                    throw new InvalidOperationException("Should not call get link for Parent Menu");
                case PageLinkTypes.NuvIoTService:
                case PageLinkTypes.Link:
                    return $"{rootUrl}{LinkUrl}";
                case PageLinkTypes.ContactInformationPage:
                    return $"{rootUrl}/public/{orgNameSpace}/about";
                case PageLinkTypes.ContactUsPage:
                    return $"{rootUrl}/public/{orgNameSpace}contactus";
                case PageLinkTypes.SiteContentPage:
                    return $"{rootUrl}/public/{orgNameSpace}/{SiteContentCategory.Key}/{SiteContentPage.Key}";
                case PageLinkTypes.SiteContentCategory:
                    return $"{rootUrl}/public/{orgNameSpace}/{SiteContentCategory.Key}";
                case PageLinkTypes.Faq:
                    return $"{rootUrl}/public/{orgNameSpace}/faq";
                case PageLinkTypes.Glossary:
                    return $"{rootUrl}/public/{orgNameSpace}/faq";
                case PageLinkTypes.ProductCategoryType:
                    return $"{rootUrl}/public/{orgNameSpace}/productcategories/{ProductCategoryType.Id}";
                case PageLinkTypes.ProductCategory:
                    return $"{rootUrl}/public/{orgNameSpace}/productcategories/{ProductCategoryType.Id}/{ProductCategory.Id}/products";
                case PageLinkTypes.Product:
                    return $"{rootUrl}/public/{orgNameSpace}/product/{Product.Id}";
                case PageLinkTypes.Survey:
                    return $"{rootUrl}/public/{orgNameSpace}/survey/{Survey.Id}";
                case PageLinkTypes.ContentDownload:
                    return $"{rootUrl}/{orgNameSpace}/{ContentDownload.Key}/download";
            }

            throw new NotImplementedException($"Do not know how to handle {Type.Value}");

        }


        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Label),
                nameof(ToolTip),
                nameof(Type),
                nameof(LinkUrl),
                nameof(LandingPage),
                nameof(Glossary),
                nameof(SiteContentCategory),
                nameof(SiteContentPage),
                nameof(ContentDownload),
                nameof(ProductCategory),
                nameof(ProductCategoryType),
                nameof(Product)
            };
        }
    }

}
