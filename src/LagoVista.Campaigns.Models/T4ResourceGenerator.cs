
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
//Resources:CampaignResources:Promotion_ExcludeWeekend

		public static string Promotion_ExcludeWeekend { get { return GetResourceString("Promotion_ExcludeWeekend"); } }
//Resources:CampaignResources:Promotion_Posts

		public static string Promotion_Posts { get { return GetResourceString("Promotion_Posts"); } }
//Resources:CampaignResources:Promotion_PromoType

		public static string Promotion_PromoType { get { return GetResourceString("Promotion_PromoType"); } }
//Resources:CampaignResources:Promotion_Spend

		public static string Promotion_Spend { get { return GetResourceString("Promotion_Spend"); } }
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
			public const string Campaign_Promotions = "Campaign_Promotions";
			public const string Campaign_StartDate = "Campaign_StartDate";
			public const string Campaign_Title = "Campaign_Title";
			public const string Campaign_TotalBudget = "Campaign_TotalBudget";
			public const string Campaign_TotalBudget_Help = "Campaign_TotalBudget_Help";
			public const string Campaign_TotalSpend = "Campaign_TotalSpend";
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
			public const string Promotion_ExcludeWeekend = "Promotion_ExcludeWeekend";
			public const string Promotion_Posts = "Promotion_Posts";
			public const string Promotion_PromoType = "Promotion_PromoType";
			public const string Promotion_Spend = "Promotion_Spend";
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
