// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 61ecab415b250db71d512cb6e869a92c89e4bfdc12f2901652248fec08d14551
// IndexVersion: 0
// --- END CODE INDEX META ---
using System.Globalization;
using System.Reflection;

//Resources:CampaignResources:Campaign_BudgetAllocated
namespace LagoVista.Campaigns.Models.Resources
{
	public class CampaignResources
	{
        private static global::System.Resources.ResourceManager _resourceManager;
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager 
		{
            get 
			{
                if (object.ReferenceEquals(_resourceManager, null)) 
				{
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LagoVista.Campaigns.Models.Resources.CampaignResources", typeof(CampaignResources).GetTypeInfo().Assembly);
                    _resourceManager = temp;
                }
                return _resourceManager;
            }
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static string GetResourceString(string key, params string[] tokens)
		{
			var culture = CultureInfo.CurrentCulture;;
            var str = ResourceManager.GetString(key, culture);

			for(int i = 0; i < tokens.Length; i += 2)
				str = str.Replace(tokens[i], tokens[i+1]);
										
            return str;
        }
        
        /// <summary>
        ///   Returns the formatted resource string.
        /// </summary>
		/*
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static HtmlString GetResourceHtmlString(string key, params string[] tokens)
		{
			var str = GetResourceString(key, tokens);
							
			if(str.StartsWith("HTML:"))
				str = str.Substring(5);

			return new HtmlString(str);
        }*/
		
		public static string Campaign_BudgetAllocated { get { return GetResourceString("Campaign_BudgetAllocated"); } }
//Resources:CampaignResources:Campaign_BudgetAllocated_Help

		public static string Campaign_BudgetAllocated_Help { get { return GetResourceString("Campaign_BudgetAllocated_Help"); } }
//Resources:CampaignResources:Campaign_Description

		public static string Campaign_Description { get { return GetResourceString("Campaign_Description"); } }
//Resources:CampaignResources:Campaign_EndDate

		public static string Campaign_EndDate { get { return GetResourceString("Campaign_EndDate"); } }
//Resources:CampaignResources:Campaign_Industry

		public static string Campaign_Industry { get { return GetResourceString("Campaign_Industry"); } }
//Resources:CampaignResources:Campaign_Niche

		public static string Campaign_Niche { get { return GetResourceString("Campaign_Niche"); } }
//Resources:CampaignResources:Campaign_Owner

		public static string Campaign_Owner { get { return GetResourceString("Campaign_Owner"); } }
//Resources:CampaignResources:Campaign_Owner_Select

		public static string Campaign_Owner_Select { get { return GetResourceString("Campaign_Owner_Select"); } }
//Resources:CampaignResources:Campaign_Promotions

		public static string Campaign_Promotions { get { return GetResourceString("Campaign_Promotions"); } }
//Resources:CampaignResources:Campaign_StartDate

		public static string Campaign_StartDate { get { return GetResourceString("Campaign_StartDate"); } }
//Resources:CampaignResources:Campaign_Title

		public static string Campaign_Title { get { return GetResourceString("Campaign_Title"); } }
//Resources:CampaignResources:Campaign_TotalBudget

		public static string Campaign_TotalBudget { get { return GetResourceString("Campaign_TotalBudget"); } }
//Resources:CampaignResources:Campaign_TotalBudget_Help

		public static string Campaign_TotalBudget_Help { get { return GetResourceString("Campaign_TotalBudget_Help"); } }
//Resources:CampaignResources:Campaign_TotalSpend

		public static string Campaign_TotalSpend { get { return GetResourceString("Campaign_TotalSpend"); } }
//Resources:CampaignResources:Common_Category

		public static string Common_Category { get { return GetResourceString("Common_Category"); } }
//Resources:CampaignResources:Common_Description

		public static string Common_Description { get { return GetResourceString("Common_Description"); } }
//Resources:CampaignResources:Common_Icon

		public static string Common_Icon { get { return GetResourceString("Common_Icon"); } }
//Resources:CampaignResources:Common_IsActive

		public static string Common_IsActive { get { return GetResourceString("Common_IsActive"); } }
//Resources:CampaignResources:Common_IsPublic

		public static string Common_IsPublic { get { return GetResourceString("Common_IsPublic"); } }
//Resources:CampaignResources:Common_IsRequired

		public static string Common_IsRequired { get { return GetResourceString("Common_IsRequired"); } }
//Resources:CampaignResources:Common_Key

		public static string Common_Key { get { return GetResourceString("Common_Key"); } }
//Resources:CampaignResources:Common_Key_Help

		public static string Common_Key_Help { get { return GetResourceString("Common_Key_Help"); } }
//Resources:CampaignResources:Common_Key_Validation

		public static string Common_Key_Validation { get { return GetResourceString("Common_Key_Validation"); } }
//Resources:CampaignResources:Common_LastUpdated

		public static string Common_LastUpdated { get { return GetResourceString("Common_LastUpdated"); } }
//Resources:CampaignResources:Common_LastUpdatedBy

		public static string Common_LastUpdatedBy { get { return GetResourceString("Common_LastUpdatedBy"); } }
//Resources:CampaignResources:Common_Name

		public static string Common_Name { get { return GetResourceString("Common_Name"); } }
//Resources:CampaignResources:Common_SelectCategory

		public static string Common_SelectCategory { get { return GetResourceString("Common_SelectCategory"); } }
//Resources:CampaignResources:EmailAttachment_Description

		public static string EmailAttachment_Description { get { return GetResourceString("EmailAttachment_Description"); } }
//Resources:CampaignResources:EmailAttachment_FileType

		public static string EmailAttachment_FileType { get { return GetResourceString("EmailAttachment_FileType"); } }
//Resources:CampaignResources:EmailAttachment_FileType_ContentDownload

		public static string EmailAttachment_FileType_ContentDownload { get { return GetResourceString("EmailAttachment_FileType_ContentDownload"); } }
//Resources:CampaignResources:EmailAttachment_FileType_ContentDownload_Select

		public static string EmailAttachment_FileType_ContentDownload_Select { get { return GetResourceString("EmailAttachment_FileType_ContentDownload_Select"); } }
//Resources:CampaignResources:EmailAttachment_FileType_FileUpload

		public static string EmailAttachment_FileType_FileUpload { get { return GetResourceString("EmailAttachment_FileType_FileUpload"); } }
//Resources:CampaignResources:EmailAttachment_FileType_Select

		public static string EmailAttachment_FileType_Select { get { return GetResourceString("EmailAttachment_FileType_Select"); } }
//Resources:CampaignResources:EmailAttachment_FileType_SignedDocument

		public static string EmailAttachment_FileType_SignedDocument { get { return GetResourceString("EmailAttachment_FileType_SignedDocument"); } }
//Resources:CampaignResources:EmailAttachment_FileType_SignedDocument_Select

		public static string EmailAttachment_FileType_SignedDocument_Select { get { return GetResourceString("EmailAttachment_FileType_SignedDocument_Select"); } }
//Resources:CampaignResources:EmailAttachment_Title

		public static string EmailAttachment_Title { get { return GetResourceString("EmailAttachment_Title"); } }
//Resources:CampaignResources:Kpi_Attribute1

		public static string Kpi_Attribute1 { get { return GetResourceString("Kpi_Attribute1"); } }
//Resources:CampaignResources:Kpi_Attribute2

		public static string Kpi_Attribute2 { get { return GetResourceString("Kpi_Attribute2"); } }
//Resources:CampaignResources:Kpi_Attribute3

		public static string Kpi_Attribute3 { get { return GetResourceString("Kpi_Attribute3"); } }
//Resources:CampaignResources:Kpi_Attribute4

		public static string Kpi_Attribute4 { get { return GetResourceString("Kpi_Attribute4"); } }
//Resources:CampaignResources:Kpi_Attribute5

		public static string Kpi_Attribute5 { get { return GetResourceString("Kpi_Attribute5"); } }
//Resources:CampaignResources:Kpi_Attribute6

		public static string Kpi_Attribute6 { get { return GetResourceString("Kpi_Attribute6"); } }
//Resources:CampaignResources:Kpi_Attribute7

		public static string Kpi_Attribute7 { get { return GetResourceString("Kpi_Attribute7"); } }
//Resources:CampaignResources:Kpi_Attribute8

		public static string Kpi_Attribute8 { get { return GetResourceString("Kpi_Attribute8"); } }
//Resources:CampaignResources:Kpi_Description

		public static string Kpi_Description { get { return GetResourceString("Kpi_Description"); } }
//Resources:CampaignResources:Kpi_ExcludeWeekends

		public static string Kpi_ExcludeWeekends { get { return GetResourceString("Kpi_ExcludeWeekends"); } }
//Resources:CampaignResources:Kpi_Metric

		public static string Kpi_Metric { get { return GetResourceString("Kpi_Metric"); } }
//Resources:CampaignResources:Kpi_Metric_Select

		public static string Kpi_Metric_Select { get { return GetResourceString("Kpi_Metric_Select"); } }
//Resources:CampaignResources:Kpi_Period

		public static string Kpi_Period { get { return GetResourceString("Kpi_Period"); } }
//Resources:CampaignResources:Kpi_Period_Day

		public static string Kpi_Period_Day { get { return GetResourceString("Kpi_Period_Day"); } }
//Resources:CampaignResources:Kpi_Period_Each

		public static string Kpi_Period_Each { get { return GetResourceString("Kpi_Period_Each"); } }
//Resources:CampaignResources:Kpi_Period_Hour

		public static string Kpi_Period_Hour { get { return GetResourceString("Kpi_Period_Hour"); } }
//Resources:CampaignResources:Kpi_Period_Month

		public static string Kpi_Period_Month { get { return GetResourceString("Kpi_Period_Month"); } }
//Resources:CampaignResources:Kpi_Period_Select

		public static string Kpi_Period_Select { get { return GetResourceString("Kpi_Period_Select"); } }
//Resources:CampaignResources:Kpi_Period_Week

		public static string Kpi_Period_Week { get { return GetResourceString("Kpi_Period_Week"); } }
//Resources:CampaignResources:Kpi_TargetValue

		public static string Kpi_TargetValue { get { return GetResourceString("Kpi_TargetValue"); } }
//Resources:CampaignResources:Kpi_Title

		public static string Kpi_Title { get { return GetResourceString("Kpi_Title"); } }
//Resources:CampaignResources:Kpis_Title

		public static string Kpis_Title { get { return GetResourceString("Kpis_Title"); } }
//Resources:CampaignResources:LandingPageInfo_Description

		public static string LandingPageInfo_Description { get { return GetResourceString("LandingPageInfo_Description"); } }
//Resources:CampaignResources:LandingPageInfo_Label

		public static string LandingPageInfo_Label { get { return GetResourceString("LandingPageInfo_Label"); } }
//Resources:CampaignResources:LandingPageInfo_LandingPage

		public static string LandingPageInfo_LandingPage { get { return GetResourceString("LandingPageInfo_LandingPage"); } }
//Resources:CampaignResources:LandingPageInfo_LandingPage_Select

		public static string LandingPageInfo_LandingPage_Select { get { return GetResourceString("LandingPageInfo_LandingPage_Select"); } }
//Resources:CampaignResources:LandingPageInfo_Title

		public static string LandingPageInfo_Title { get { return GetResourceString("LandingPageInfo_Title"); } }
//Resources:CampaignResources:MetricDefinition_Attr1Key

		public static string MetricDefinition_Attr1Key { get { return GetResourceString("MetricDefinition_Attr1Key"); } }
//Resources:CampaignResources:MetricDefinition_Attr1Name

		public static string MetricDefinition_Attr1Name { get { return GetResourceString("MetricDefinition_Attr1Name"); } }
//Resources:CampaignResources:MetricDefinition_Attr2Key

		public static string MetricDefinition_Attr2Key { get { return GetResourceString("MetricDefinition_Attr2Key"); } }
//Resources:CampaignResources:MetricDefinition_Attr2Name

		public static string MetricDefinition_Attr2Name { get { return GetResourceString("MetricDefinition_Attr2Name"); } }
//Resources:CampaignResources:MetricDefinition_Attr3Key

		public static string MetricDefinition_Attr3Key { get { return GetResourceString("MetricDefinition_Attr3Key"); } }
//Resources:CampaignResources:MetricDefinition_Attr3Name

		public static string MetricDefinition_Attr3Name { get { return GetResourceString("MetricDefinition_Attr3Name"); } }
//Resources:CampaignResources:MetricDefinition_Attr4Key

		public static string MetricDefinition_Attr4Key { get { return GetResourceString("MetricDefinition_Attr4Key"); } }
//Resources:CampaignResources:MetricDefinition_Attr4Name

		public static string MetricDefinition_Attr4Name { get { return GetResourceString("MetricDefinition_Attr4Name"); } }
//Resources:CampaignResources:MetricDefinition_Attr5Key

		public static string MetricDefinition_Attr5Key { get { return GetResourceString("MetricDefinition_Attr5Key"); } }
//Resources:CampaignResources:MetricDefinition_Attr5Name

		public static string MetricDefinition_Attr5Name { get { return GetResourceString("MetricDefinition_Attr5Name"); } }
//Resources:CampaignResources:MetricDefinition_Attr6Key

		public static string MetricDefinition_Attr6Key { get { return GetResourceString("MetricDefinition_Attr6Key"); } }
//Resources:CampaignResources:MetricDefinition_Attr6Name

		public static string MetricDefinition_Attr6Name { get { return GetResourceString("MetricDefinition_Attr6Name"); } }
//Resources:CampaignResources:MetricDefinition_Attr7Key

		public static string MetricDefinition_Attr7Key { get { return GetResourceString("MetricDefinition_Attr7Key"); } }
//Resources:CampaignResources:MetricDefinition_Attr7Name

		public static string MetricDefinition_Attr7Name { get { return GetResourceString("MetricDefinition_Attr7Name"); } }
//Resources:CampaignResources:MetricDefinition_Attr8Key

		public static string MetricDefinition_Attr8Key { get { return GetResourceString("MetricDefinition_Attr8Key"); } }
//Resources:CampaignResources:MetricDefinition_Attr8Name

		public static string MetricDefinition_Attr8Name { get { return GetResourceString("MetricDefinition_Attr8Name"); } }
//Resources:CampaignResources:MetricsDefinition_Description

		public static string MetricsDefinition_Description { get { return GetResourceString("MetricsDefinition_Description"); } }
//Resources:CampaignResources:MetricsDefinition_Title

		public static string MetricsDefinition_Title { get { return GetResourceString("MetricsDefinition_Title"); } }
//Resources:CampaignResources:MetricsDefinitions_TItle

		public static string MetricsDefinitions_TItle { get { return GetResourceString("MetricsDefinitions_TItle"); } }
//Resources:CampaignResources:PageLink_Description

		public static string PageLink_Description { get { return GetResourceString("PageLink_Description"); } }
//Resources:CampaignResources:PageLink_Label

		public static string PageLink_Label { get { return GetResourceString("PageLink_Label"); } }
//Resources:CampaignResources:PageLink_LandingPage

		public static string PageLink_LandingPage { get { return GetResourceString("PageLink_LandingPage"); } }
//Resources:CampaignResources:PageLink_LinkType

		public static string PageLink_LinkType { get { return GetResourceString("PageLink_LinkType"); } }
//Resources:CampaignResources:PageLink_LinkTypeSelect

		public static string PageLink_LinkTypeSelect { get { return GetResourceString("PageLink_LinkTypeSelect"); } }
//Resources:CampaignResources:PageLink_OpenInNewTab

		public static string PageLink_OpenInNewTab { get { return GetResourceString("PageLink_OpenInNewTab"); } }
//Resources:CampaignResources:PageLink_Product

		public static string PageLink_Product { get { return GetResourceString("PageLink_Product"); } }
//Resources:CampaignResources:PageLink_ProductCategory

		public static string PageLink_ProductCategory { get { return GetResourceString("PageLink_ProductCategory"); } }
//Resources:CampaignResources:PageLink_ProductPage

		public static string PageLink_ProductPage { get { return GetResourceString("PageLink_ProductPage"); } }
//Resources:CampaignResources:PageLink_SiteContentCategory

		public static string PageLink_SiteContentCategory { get { return GetResourceString("PageLink_SiteContentCategory"); } }
//Resources:CampaignResources:PageLink_SiteContentPage

		public static string PageLink_SiteContentPage { get { return GetResourceString("PageLink_SiteContentPage"); } }
//Resources:CampaignResources:PageLink_Survey

		public static string PageLink_Survey { get { return GetResourceString("PageLink_Survey"); } }
//Resources:CampaignResources:PageLink_Title

		public static string PageLink_Title { get { return GetResourceString("PageLink_Title"); } }
//Resources:CampaignResources:PageLink_ToolTip

		public static string PageLink_ToolTip { get { return GetResourceString("PageLink_ToolTip"); } }
//Resources:CampaignResources:PageLink_Type_ContactInformationPage

		public static string PageLink_Type_ContactInformationPage { get { return GetResourceString("PageLink_Type_ContactInformationPage"); } }
//Resources:CampaignResources:PageLink_Type_ContactUsPage

		public static string PageLink_Type_ContactUsPage { get { return GetResourceString("PageLink_Type_ContactUsPage"); } }
//Resources:CampaignResources:PageLink_Type_ContentDownload

		public static string PageLink_Type_ContentDownload { get { return GetResourceString("PageLink_Type_ContentDownload"); } }
//Resources:CampaignResources:PageLink_Type_FaqPage

		public static string PageLink_Type_FaqPage { get { return GetResourceString("PageLink_Type_FaqPage"); } }
//Resources:CampaignResources:PageLink_Type_GlossaryPage

		public static string PageLink_Type_GlossaryPage { get { return GetResourceString("PageLink_Type_GlossaryPage"); } }
//Resources:CampaignResources:PageLink_Type_LandingPage

		public static string PageLink_Type_LandingPage { get { return GetResourceString("PageLink_Type_LandingPage"); } }
//Resources:CampaignResources:PageLink_Type_Link

		public static string PageLink_Type_Link { get { return GetResourceString("PageLink_Type_Link"); } }
//Resources:CampaignResources:PageLink_Type_LoginPage

		public static string PageLink_Type_LoginPage { get { return GetResourceString("PageLink_Type_LoginPage"); } }
//Resources:CampaignResources:PageLink_Type_LogoutPage

		public static string PageLink_Type_LogoutPage { get { return GetResourceString("PageLink_Type_LogoutPage"); } }
//Resources:CampaignResources:PageLink_Type_NuvIoTService

		public static string PageLink_Type_NuvIoTService { get { return GetResourceString("PageLink_Type_NuvIoTService"); } }
//Resources:CampaignResources:PageLink_Type_OrgWebSite

		public static string PageLink_Type_OrgWebSite { get { return GetResourceString("PageLink_Type_OrgWebSite"); } }
//Resources:CampaignResources:PageLink_Type_ParentMenu

		public static string PageLink_Type_ParentMenu { get { return GetResourceString("PageLink_Type_ParentMenu"); } }
//Resources:CampaignResources:PageLink_Type_Product

		public static string PageLink_Type_Product { get { return GetResourceString("PageLink_Type_Product"); } }
//Resources:CampaignResources:PageLink_Type_ProductCategory

		public static string PageLink_Type_ProductCategory { get { return GetResourceString("PageLink_Type_ProductCategory"); } }
//Resources:CampaignResources:PageLink_Type_ProductCategoryType

		public static string PageLink_Type_ProductCategoryType { get { return GetResourceString("PageLink_Type_ProductCategoryType"); } }
//Resources:CampaignResources:PageLink_Type_ProductPage

		public static string PageLink_Type_ProductPage { get { return GetResourceString("PageLink_Type_ProductPage"); } }
//Resources:CampaignResources:PageLink_Type_SignedDocument

		public static string PageLink_Type_SignedDocument { get { return GetResourceString("PageLink_Type_SignedDocument"); } }
//Resources:CampaignResources:PageLink_Type_SiteContactCategory

		public static string PageLink_Type_SiteContactCategory { get { return GetResourceString("PageLink_Type_SiteContactCategory"); } }
//Resources:CampaignResources:PageLink_Type_SiteContactPage

		public static string PageLink_Type_SiteContactPage { get { return GetResourceString("PageLink_Type_SiteContactPage"); } }
//Resources:CampaignResources:PageLink_Type_SocialMediaLinks

		public static string PageLink_Type_SocialMediaLinks { get { return GetResourceString("PageLink_Type_SocialMediaLinks"); } }
//Resources:CampaignResources:PageLink_Type_Survey

		public static string PageLink_Type_Survey { get { return GetResourceString("PageLink_Type_Survey"); } }
//Resources:CampaignResources:PageLink_Type_TypeProductCatalog

		public static string PageLink_Type_TypeProductCatalog { get { return GetResourceString("PageLink_Type_TypeProductCatalog"); } }
//Resources:CampaignResources:PageLink_Type_Url

		public static string PageLink_Type_Url { get { return GetResourceString("PageLink_Type_Url"); } }
//Resources:CampaignResources:Post_Account

		public static string Post_Account { get { return GetResourceString("Post_Account"); } }
//Resources:CampaignResources:Post_Account_Watermark

		public static string Post_Account_Watermark { get { return GetResourceString("Post_Account_Watermark"); } }
//Resources:CampaignResources:Post_Content

		public static string Post_Content { get { return GetResourceString("Post_Content"); } }
//Resources:CampaignResources:Post_SiteContent

		public static string Post_SiteContent { get { return GetResourceString("Post_SiteContent"); } }
//Resources:CampaignResources:Post_SiteContent_Help

		public static string Post_SiteContent_Help { get { return GetResourceString("Post_SiteContent_Help"); } }
//Resources:CampaignResources:Post_SiteContent_Watermark

		public static string Post_SiteContent_Watermark { get { return GetResourceString("Post_SiteContent_Watermark"); } }
//Resources:CampaignResources:Post_Title

		public static string Post_Title { get { return GetResourceString("Post_Title"); } }
//Resources:CampaignResources:Promotion_Budget

		public static string Promotion_Budget { get { return GetResourceString("Promotion_Budget"); } }
//Resources:CampaignResources:Promotion_DailyGoal

		public static string Promotion_DailyGoal { get { return GetResourceString("Promotion_DailyGoal"); } }
//Resources:CampaignResources:Promotion_Description

		public static string Promotion_Description { get { return GetResourceString("Promotion_Description"); } }
//Resources:CampaignResources:Promotion_EmailList

		public static string Promotion_EmailList { get { return GetResourceString("Promotion_EmailList"); } }
//Resources:CampaignResources:Promotion_EmailList_Help

		public static string Promotion_EmailList_Help { get { return GetResourceString("Promotion_EmailList_Help"); } }
//Resources:CampaignResources:Promotion_EmailList_Select

		public static string Promotion_EmailList_Select { get { return GetResourceString("Promotion_EmailList_Select"); } }
//Resources:CampaignResources:Promotion_EmailMailers

		public static string Promotion_EmailMailers { get { return GetResourceString("Promotion_EmailMailers"); } }
//Resources:CampaignResources:Promotion_EmailMailers_Help

		public static string Promotion_EmailMailers_Help { get { return GetResourceString("Promotion_EmailMailers_Help"); } }
//Resources:CampaignResources:Promotion_EmailTemplate

		public static string Promotion_EmailTemplate { get { return GetResourceString("Promotion_EmailTemplate"); } }
//Resources:CampaignResources:Promotion_EmailTemplate_Select

		public static string Promotion_EmailTemplate_Select { get { return GetResourceString("Promotion_EmailTemplate_Select"); } }
//Resources:CampaignResources:Promotion_ExcludeWeekend

		public static string Promotion_ExcludeWeekend { get { return GetResourceString("Promotion_ExcludeWeekend"); } }
//Resources:CampaignResources:Promotion_ExternalCampaignId

		public static string Promotion_ExternalCampaignId { get { return GetResourceString("Promotion_ExternalCampaignId"); } }
//Resources:CampaignResources:Promotion_IndustryNiche

		public static string Promotion_IndustryNiche { get { return GetResourceString("Promotion_IndustryNiche"); } }
//Resources:CampaignResources:Promotion_LandingPages

		public static string Promotion_LandingPages { get { return GetResourceString("Promotion_LandingPages"); } }
//Resources:CampaignResources:Promotion_Owner

		public static string Promotion_Owner { get { return GetResourceString("Promotion_Owner"); } }
//Resources:CampaignResources:Promotion_Owner_Select

		public static string Promotion_Owner_Select { get { return GetResourceString("Promotion_Owner_Select"); } }
//Resources:CampaignResources:Promotion_Persona

		public static string Promotion_Persona { get { return GetResourceString("Promotion_Persona"); } }
//Resources:CampaignResources:Promotion_Posts

		public static string Promotion_Posts { get { return GetResourceString("Promotion_Posts"); } }
//Resources:CampaignResources:Promotion_ProductPage

		public static string Promotion_ProductPage { get { return GetResourceString("Promotion_ProductPage"); } }
//Resources:CampaignResources:Promotion_ProductPage_Select

		public static string Promotion_ProductPage_Select { get { return GetResourceString("Promotion_ProductPage_Select"); } }
//Resources:CampaignResources:Promotion_PromoType

		public static string Promotion_PromoType { get { return GetResourceString("Promotion_PromoType"); } }
//Resources:CampaignResources:Promotion_Spend

		public static string Promotion_Spend { get { return GetResourceString("Promotion_Spend"); } }
//Resources:CampaignResources:Promotion_Survey

		public static string Promotion_Survey { get { return GetResourceString("Promotion_Survey"); } }
//Resources:CampaignResources:Promotion_Survey_Select

		public static string Promotion_Survey_Select { get { return GetResourceString("Promotion_Survey_Select"); } }
//Resources:CampaignResources:Promotion_Title

		public static string Promotion_Title { get { return GetResourceString("Promotion_Title"); } }
//Resources:CampaignResources:Promotion_Type_ColdCall

		public static string Promotion_Type_ColdCall { get { return GetResourceString("Promotion_Type_ColdCall"); } }
//Resources:CampaignResources:Promotion_Type_Email

		public static string Promotion_Type_Email { get { return GetResourceString("Promotion_Type_Email"); } }
//Resources:CampaignResources:Promotion_Type_Other

		public static string Promotion_Type_Other { get { return GetResourceString("Promotion_Type_Other"); } }
//Resources:CampaignResources:Promotion_Type_Select

		public static string Promotion_Type_Select { get { return GetResourceString("Promotion_Type_Select"); } }
//Resources:CampaignResources:Promotion_Type_SocialMedia

		public static string Promotion_Type_SocialMedia { get { return GetResourceString("Promotion_Type_SocialMedia"); } }
//Resources:CampaignResources:Promotion_Type_WebAd

		public static string Promotion_Type_WebAd { get { return GetResourceString("Promotion_Type_WebAd"); } }
//Resources:CampaignResources:Recipeint_Persona

		public static string Recipeint_Persona { get { return GetResourceString("Recipeint_Persona"); } }
//Resources:CampaignResources:Recipeint_Persona_Select

		public static string Recipeint_Persona_Select { get { return GetResourceString("Recipeint_Persona_Select"); } }
//Resources:CampaignResources:Recipient_Company

		public static string Recipient_Company { get { return GetResourceString("Recipient_Company"); } }
//Resources:CampaignResources:Recipient_Company_Select

		public static string Recipient_Company_Select { get { return GetResourceString("Recipient_Company_Select"); } }
//Resources:CampaignResources:Recipient_Contact

		public static string Recipient_Contact { get { return GetResourceString("Recipient_Contact"); } }
//Resources:CampaignResources:Recipient_Contact_Select

		public static string Recipient_Contact_Select { get { return GetResourceString("Recipient_Contact_Select"); } }
//Resources:CampaignResources:Recipient_Description

		public static string Recipient_Description { get { return GetResourceString("Recipient_Description"); } }
//Resources:CampaignResources:Recipient_EmailAddress

		public static string Recipient_EmailAddress { get { return GetResourceString("Recipient_EmailAddress"); } }
//Resources:CampaignResources:Recipient_FirstName

		public static string Recipient_FirstName { get { return GetResourceString("Recipient_FirstName"); } }
//Resources:CampaignResources:Recipient_Industry

		public static string Recipient_Industry { get { return GetResourceString("Recipient_Industry"); } }
//Resources:CampaignResources:Recipient_Industry_Select

		public static string Recipient_Industry_Select { get { return GetResourceString("Recipient_Industry_Select"); } }
//Resources:CampaignResources:Recipient_IndustryNiche

		public static string Recipient_IndustryNiche { get { return GetResourceString("Recipient_IndustryNiche"); } }
//Resources:CampaignResources:Recipient_IndustryNiche_Select

		public static string Recipient_IndustryNiche_Select { get { return GetResourceString("Recipient_IndustryNiche_Select"); } }
//Resources:CampaignResources:Recipient_LastName

		public static string Recipient_LastName { get { return GetResourceString("Recipient_LastName"); } }
//Resources:CampaignResources:Recipient_Title

		public static string Recipient_Title { get { return GetResourceString("Recipient_Title"); } }
//Resources:CampaignResources:SocialMedia_Account

		public static string SocialMedia_Account { get { return GetResourceString("SocialMedia_Account"); } }
//Resources:CampaignResources:SocialMedia_Account_Help

		public static string SocialMedia_Account_Help { get { return GetResourceString("SocialMedia_Account_Help"); } }
//Resources:CampaignResources:SocialMedia_AccountId

		public static string SocialMedia_AccountId { get { return GetResourceString("SocialMedia_AccountId"); } }
//Resources:CampaignResources:SocialMedia_AccountKey

		public static string SocialMedia_AccountKey { get { return GetResourceString("SocialMedia_AccountKey"); } }
//Resources:CampaignResources:SocialMedia_AccountName

		public static string SocialMedia_AccountName { get { return GetResourceString("SocialMedia_AccountName"); } }
//Resources:CampaignResources:SocialMediaPost_Description

		public static string SocialMediaPost_Description { get { return GetResourceString("SocialMediaPost_Description"); } }
//Resources:CampaignResources:SocialMediaPost_Title

		public static string SocialMediaPost_Title { get { return GetResourceString("SocialMediaPost_Title"); } }

		public static class Names
		{
			public const string Campaign_BudgetAllocated = "Campaign_BudgetAllocated";
			public const string Campaign_BudgetAllocated_Help = "Campaign_BudgetAllocated_Help";
			public const string Campaign_Description = "Campaign_Description";
			public const string Campaign_EndDate = "Campaign_EndDate";
			public const string Campaign_Industry = "Campaign_Industry";
			public const string Campaign_Niche = "Campaign_Niche";
			public const string Campaign_Owner = "Campaign_Owner";
			public const string Campaign_Owner_Select = "Campaign_Owner_Select";
			public const string Campaign_Promotions = "Campaign_Promotions";
			public const string Campaign_StartDate = "Campaign_StartDate";
			public const string Campaign_Title = "Campaign_Title";
			public const string Campaign_TotalBudget = "Campaign_TotalBudget";
			public const string Campaign_TotalBudget_Help = "Campaign_TotalBudget_Help";
			public const string Campaign_TotalSpend = "Campaign_TotalSpend";
			public const string Common_Category = "Common_Category";
			public const string Common_Description = "Common_Description";
			public const string Common_Icon = "Common_Icon";
			public const string Common_IsActive = "Common_IsActive";
			public const string Common_IsPublic = "Common_IsPublic";
			public const string Common_IsRequired = "Common_IsRequired";
			public const string Common_Key = "Common_Key";
			public const string Common_Key_Help = "Common_Key_Help";
			public const string Common_Key_Validation = "Common_Key_Validation";
			public const string Common_LastUpdated = "Common_LastUpdated";
			public const string Common_LastUpdatedBy = "Common_LastUpdatedBy";
			public const string Common_Name = "Common_Name";
			public const string Common_SelectCategory = "Common_SelectCategory";
			public const string EmailAttachment_Description = "EmailAttachment_Description";
			public const string EmailAttachment_FileType = "EmailAttachment_FileType";
			public const string EmailAttachment_FileType_ContentDownload = "EmailAttachment_FileType_ContentDownload";
			public const string EmailAttachment_FileType_ContentDownload_Select = "EmailAttachment_FileType_ContentDownload_Select";
			public const string EmailAttachment_FileType_FileUpload = "EmailAttachment_FileType_FileUpload";
			public const string EmailAttachment_FileType_Select = "EmailAttachment_FileType_Select";
			public const string EmailAttachment_FileType_SignedDocument = "EmailAttachment_FileType_SignedDocument";
			public const string EmailAttachment_FileType_SignedDocument_Select = "EmailAttachment_FileType_SignedDocument_Select";
			public const string EmailAttachment_Title = "EmailAttachment_Title";
			public const string Kpi_Attribute1 = "Kpi_Attribute1";
			public const string Kpi_Attribute2 = "Kpi_Attribute2";
			public const string Kpi_Attribute3 = "Kpi_Attribute3";
			public const string Kpi_Attribute4 = "Kpi_Attribute4";
			public const string Kpi_Attribute5 = "Kpi_Attribute5";
			public const string Kpi_Attribute6 = "Kpi_Attribute6";
			public const string Kpi_Attribute7 = "Kpi_Attribute7";
			public const string Kpi_Attribute8 = "Kpi_Attribute8";
			public const string Kpi_Description = "Kpi_Description";
			public const string Kpi_ExcludeWeekends = "Kpi_ExcludeWeekends";
			public const string Kpi_Metric = "Kpi_Metric";
			public const string Kpi_Metric_Select = "Kpi_Metric_Select";
			public const string Kpi_Period = "Kpi_Period";
			public const string Kpi_Period_Day = "Kpi_Period_Day";
			public const string Kpi_Period_Each = "Kpi_Period_Each";
			public const string Kpi_Period_Hour = "Kpi_Period_Hour";
			public const string Kpi_Period_Month = "Kpi_Period_Month";
			public const string Kpi_Period_Select = "Kpi_Period_Select";
			public const string Kpi_Period_Week = "Kpi_Period_Week";
			public const string Kpi_TargetValue = "Kpi_TargetValue";
			public const string Kpi_Title = "Kpi_Title";
			public const string Kpis_Title = "Kpis_Title";
			public const string LandingPageInfo_Description = "LandingPageInfo_Description";
			public const string LandingPageInfo_Label = "LandingPageInfo_Label";
			public const string LandingPageInfo_LandingPage = "LandingPageInfo_LandingPage";
			public const string LandingPageInfo_LandingPage_Select = "LandingPageInfo_LandingPage_Select";
			public const string LandingPageInfo_Title = "LandingPageInfo_Title";
			public const string MetricDefinition_Attr1Key = "MetricDefinition_Attr1Key";
			public const string MetricDefinition_Attr1Name = "MetricDefinition_Attr1Name";
			public const string MetricDefinition_Attr2Key = "MetricDefinition_Attr2Key";
			public const string MetricDefinition_Attr2Name = "MetricDefinition_Attr2Name";
			public const string MetricDefinition_Attr3Key = "MetricDefinition_Attr3Key";
			public const string MetricDefinition_Attr3Name = "MetricDefinition_Attr3Name";
			public const string MetricDefinition_Attr4Key = "MetricDefinition_Attr4Key";
			public const string MetricDefinition_Attr4Name = "MetricDefinition_Attr4Name";
			public const string MetricDefinition_Attr5Key = "MetricDefinition_Attr5Key";
			public const string MetricDefinition_Attr5Name = "MetricDefinition_Attr5Name";
			public const string MetricDefinition_Attr6Key = "MetricDefinition_Attr6Key";
			public const string MetricDefinition_Attr6Name = "MetricDefinition_Attr6Name";
			public const string MetricDefinition_Attr7Key = "MetricDefinition_Attr7Key";
			public const string MetricDefinition_Attr7Name = "MetricDefinition_Attr7Name";
			public const string MetricDefinition_Attr8Key = "MetricDefinition_Attr8Key";
			public const string MetricDefinition_Attr8Name = "MetricDefinition_Attr8Name";
			public const string MetricsDefinition_Description = "MetricsDefinition_Description";
			public const string MetricsDefinition_Title = "MetricsDefinition_Title";
			public const string MetricsDefinitions_TItle = "MetricsDefinitions_TItle";
			public const string PageLink_Description = "PageLink_Description";
			public const string PageLink_Label = "PageLink_Label";
			public const string PageLink_LandingPage = "PageLink_LandingPage";
			public const string PageLink_LinkType = "PageLink_LinkType";
			public const string PageLink_LinkTypeSelect = "PageLink_LinkTypeSelect";
			public const string PageLink_OpenInNewTab = "PageLink_OpenInNewTab";
			public const string PageLink_Product = "PageLink_Product";
			public const string PageLink_ProductCategory = "PageLink_ProductCategory";
			public const string PageLink_ProductPage = "PageLink_ProductPage";
			public const string PageLink_SiteContentCategory = "PageLink_SiteContentCategory";
			public const string PageLink_SiteContentPage = "PageLink_SiteContentPage";
			public const string PageLink_Survey = "PageLink_Survey";
			public const string PageLink_Title = "PageLink_Title";
			public const string PageLink_ToolTip = "PageLink_ToolTip";
			public const string PageLink_Type_ContactInformationPage = "PageLink_Type_ContactInformationPage";
			public const string PageLink_Type_ContactUsPage = "PageLink_Type_ContactUsPage";
			public const string PageLink_Type_ContentDownload = "PageLink_Type_ContentDownload";
			public const string PageLink_Type_FaqPage = "PageLink_Type_FaqPage";
			public const string PageLink_Type_GlossaryPage = "PageLink_Type_GlossaryPage";
			public const string PageLink_Type_LandingPage = "PageLink_Type_LandingPage";
			public const string PageLink_Type_Link = "PageLink_Type_Link";
			public const string PageLink_Type_LoginPage = "PageLink_Type_LoginPage";
			public const string PageLink_Type_LogoutPage = "PageLink_Type_LogoutPage";
			public const string PageLink_Type_NuvIoTService = "PageLink_Type_NuvIoTService";
			public const string PageLink_Type_OrgWebSite = "PageLink_Type_OrgWebSite";
			public const string PageLink_Type_ParentMenu = "PageLink_Type_ParentMenu";
			public const string PageLink_Type_Product = "PageLink_Type_Product";
			public const string PageLink_Type_ProductCategory = "PageLink_Type_ProductCategory";
			public const string PageLink_Type_ProductCategoryType = "PageLink_Type_ProductCategoryType";
			public const string PageLink_Type_ProductPage = "PageLink_Type_ProductPage";
			public const string PageLink_Type_SignedDocument = "PageLink_Type_SignedDocument";
			public const string PageLink_Type_SiteContactCategory = "PageLink_Type_SiteContactCategory";
			public const string PageLink_Type_SiteContactPage = "PageLink_Type_SiteContactPage";
			public const string PageLink_Type_SocialMediaLinks = "PageLink_Type_SocialMediaLinks";
			public const string PageLink_Type_Survey = "PageLink_Type_Survey";
			public const string PageLink_Type_TypeProductCatalog = "PageLink_Type_TypeProductCatalog";
			public const string PageLink_Type_Url = "PageLink_Type_Url";
			public const string Post_Account = "Post_Account";
			public const string Post_Account_Watermark = "Post_Account_Watermark";
			public const string Post_Content = "Post_Content";
			public const string Post_SiteContent = "Post_SiteContent";
			public const string Post_SiteContent_Help = "Post_SiteContent_Help";
			public const string Post_SiteContent_Watermark = "Post_SiteContent_Watermark";
			public const string Post_Title = "Post_Title";
			public const string Promotion_Budget = "Promotion_Budget";
			public const string Promotion_DailyGoal = "Promotion_DailyGoal";
			public const string Promotion_Description = "Promotion_Description";
			public const string Promotion_EmailList = "Promotion_EmailList";
			public const string Promotion_EmailList_Help = "Promotion_EmailList_Help";
			public const string Promotion_EmailList_Select = "Promotion_EmailList_Select";
			public const string Promotion_EmailMailers = "Promotion_EmailMailers";
			public const string Promotion_EmailMailers_Help = "Promotion_EmailMailers_Help";
			public const string Promotion_EmailTemplate = "Promotion_EmailTemplate";
			public const string Promotion_EmailTemplate_Select = "Promotion_EmailTemplate_Select";
			public const string Promotion_ExcludeWeekend = "Promotion_ExcludeWeekend";
			public const string Promotion_ExternalCampaignId = "Promotion_ExternalCampaignId";
			public const string Promotion_IndustryNiche = "Promotion_IndustryNiche";
			public const string Promotion_LandingPages = "Promotion_LandingPages";
			public const string Promotion_Owner = "Promotion_Owner";
			public const string Promotion_Owner_Select = "Promotion_Owner_Select";
			public const string Promotion_Persona = "Promotion_Persona";
			public const string Promotion_Posts = "Promotion_Posts";
			public const string Promotion_ProductPage = "Promotion_ProductPage";
			public const string Promotion_ProductPage_Select = "Promotion_ProductPage_Select";
			public const string Promotion_PromoType = "Promotion_PromoType";
			public const string Promotion_Spend = "Promotion_Spend";
			public const string Promotion_Survey = "Promotion_Survey";
			public const string Promotion_Survey_Select = "Promotion_Survey_Select";
			public const string Promotion_Title = "Promotion_Title";
			public const string Promotion_Type_ColdCall = "Promotion_Type_ColdCall";
			public const string Promotion_Type_Email = "Promotion_Type_Email";
			public const string Promotion_Type_Other = "Promotion_Type_Other";
			public const string Promotion_Type_Select = "Promotion_Type_Select";
			public const string Promotion_Type_SocialMedia = "Promotion_Type_SocialMedia";
			public const string Promotion_Type_WebAd = "Promotion_Type_WebAd";
			public const string Recipeint_Persona = "Recipeint_Persona";
			public const string Recipeint_Persona_Select = "Recipeint_Persona_Select";
			public const string Recipient_Company = "Recipient_Company";
			public const string Recipient_Company_Select = "Recipient_Company_Select";
			public const string Recipient_Contact = "Recipient_Contact";
			public const string Recipient_Contact_Select = "Recipient_Contact_Select";
			public const string Recipient_Description = "Recipient_Description";
			public const string Recipient_EmailAddress = "Recipient_EmailAddress";
			public const string Recipient_FirstName = "Recipient_FirstName";
			public const string Recipient_Industry = "Recipient_Industry";
			public const string Recipient_Industry_Select = "Recipient_Industry_Select";
			public const string Recipient_IndustryNiche = "Recipient_IndustryNiche";
			public const string Recipient_IndustryNiche_Select = "Recipient_IndustryNiche_Select";
			public const string Recipient_LastName = "Recipient_LastName";
			public const string Recipient_Title = "Recipient_Title";
			public const string SocialMedia_Account = "SocialMedia_Account";
			public const string SocialMedia_Account_Help = "SocialMedia_Account_Help";
			public const string SocialMedia_AccountId = "SocialMedia_AccountId";
			public const string SocialMedia_AccountKey = "SocialMedia_AccountKey";
			public const string SocialMedia_AccountName = "SocialMedia_AccountName";
			public const string SocialMediaPost_Description = "SocialMediaPost_Description";
			public const string SocialMediaPost_Title = "SocialMediaPost_Title";
		}
	}
}
