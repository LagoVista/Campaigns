
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
//Resources:CampaignResources:Kpi_Attribute1

		public static string Kpi_Attribute1 { get { return GetResourceString("Kpi_Attribute1"); } }
//Resources:CampaignResources:Kpi_Attribute2

		public static string Kpi_Attribute2 { get { return GetResourceString("Kpi_Attribute2"); } }
//Resources:CampaignResources:Kpi_Attribute3

		public static string Kpi_Attribute3 { get { return GetResourceString("Kpi_Attribute3"); } }
//Resources:CampaignResources:Kpi_Description

		public static string Kpi_Description { get { return GetResourceString("Kpi_Description"); } }
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
//Resources:CampaignResources:MetricsDefinition_Description

		public static string MetricsDefinition_Description { get { return GetResourceString("MetricsDefinition_Description"); } }
//Resources:CampaignResources:MetricsDefinition_Title

		public static string MetricsDefinition_Title { get { return GetResourceString("MetricsDefinition_Title"); } }
//Resources:CampaignResources:MetricsDefinitions_TItle

		public static string MetricsDefinitions_TItle { get { return GetResourceString("MetricsDefinitions_TItle"); } }
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
//Resources:CampaignResources:Promotion_EmailList_Select

		public static string Promotion_EmailList_Select { get { return GetResourceString("Promotion_EmailList_Select"); } }
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
//Resources:CampaignResources:Promotion_LandingPage

		public static string Promotion_LandingPage { get { return GetResourceString("Promotion_LandingPage"); } }
//Resources:CampaignResources:Promotion_LandingPage_Select

		public static string Promotion_LandingPage_Select { get { return GetResourceString("Promotion_LandingPage_Select"); } }
//Resources:CampaignResources:Promotion_Owner

		public static string Promotion_Owner { get { return GetResourceString("Promotion_Owner"); } }
//Resources:CampaignResources:Promotion_Owner_Select

		public static string Promotion_Owner_Select { get { return GetResourceString("Promotion_Owner_Select"); } }
//Resources:CampaignResources:Promotion_Persona

		public static string Promotion_Persona { get { return GetResourceString("Promotion_Persona"); } }
//Resources:CampaignResources:Promotion_Posts

		public static string Promotion_Posts { get { return GetResourceString("Promotion_Posts"); } }
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
			public const string Common_IsPublic = "Common_IsPublic";
			public const string Common_IsRequired = "Common_IsRequired";
			public const string Common_Key = "Common_Key";
			public const string Common_Key_Help = "Common_Key_Help";
			public const string Common_Key_Validation = "Common_Key_Validation";
			public const string Common_LastUpdated = "Common_LastUpdated";
			public const string Common_LastUpdatedBy = "Common_LastUpdatedBy";
			public const string Common_Name = "Common_Name";
			public const string Common_SelectCategory = "Common_SelectCategory";
			public const string Kpi_Attribute1 = "Kpi_Attribute1";
			public const string Kpi_Attribute2 = "Kpi_Attribute2";
			public const string Kpi_Attribute3 = "Kpi_Attribute3";
			public const string Kpi_Description = "Kpi_Description";
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
			public const string MetricDefinition_Attr1Key = "MetricDefinition_Attr1Key";
			public const string MetricDefinition_Attr1Name = "MetricDefinition_Attr1Name";
			public const string MetricDefinition_Attr2Key = "MetricDefinition_Attr2Key";
			public const string MetricDefinition_Attr2Name = "MetricDefinition_Attr2Name";
			public const string MetricDefinition_Attr3Key = "MetricDefinition_Attr3Key";
			public const string MetricDefinition_Attr3Name = "MetricDefinition_Attr3Name";
			public const string MetricsDefinition_Description = "MetricsDefinition_Description";
			public const string MetricsDefinition_Title = "MetricsDefinition_Title";
			public const string MetricsDefinitions_TItle = "MetricsDefinitions_TItle";
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
			public const string Promotion_EmailList_Select = "Promotion_EmailList_Select";
			public const string Promotion_EmailTemplate = "Promotion_EmailTemplate";
			public const string Promotion_EmailTemplate_Select = "Promotion_EmailTemplate_Select";
			public const string Promotion_ExcludeWeekend = "Promotion_ExcludeWeekend";
			public const string Promotion_ExternalCampaignId = "Promotion_ExternalCampaignId";
			public const string Promotion_IndustryNiche = "Promotion_IndustryNiche";
			public const string Promotion_LandingPage = "Promotion_LandingPage";
			public const string Promotion_LandingPage_Select = "Promotion_LandingPage_Select";
			public const string Promotion_Owner = "Promotion_Owner";
			public const string Promotion_Owner_Select = "Promotion_Owner_Select";
			public const string Promotion_Persona = "Promotion_Persona";
			public const string Promotion_Posts = "Promotion_Posts";
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
