
using System.Globalization;
using System.Reflection;

//Resources:CampaignResources:Campaign_Description
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
		
		public static string Campaign_Description { get { return GetResourceString("Campaign_Description"); } }
//Resources:CampaignResources:Campaign_EndDate

		public static string Campaign_EndDate { get { return GetResourceString("Campaign_EndDate"); } }
//Resources:CampaignResources:Campaign_StartDate

		public static string Campaign_StartDate { get { return GetResourceString("Campaign_StartDate"); } }
//Resources:CampaignResources:Campaign_Title

		public static string Campaign_Title { get { return GetResourceString("Campaign_Title"); } }
//Resources:CampaignResources:Common_Description

		public static string Common_Description { get { return GetResourceString("Common_Description"); } }
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
//Resources:CampaignResources:Promotion_Budget

		public static string Promotion_Budget { get { return GetResourceString("Promotion_Budget"); } }
//Resources:CampaignResources:Promotion_Description

		public static string Promotion_Description { get { return GetResourceString("Promotion_Description"); } }
//Resources:CampaignResources:Promotion_Spend

		public static string Promotion_Spend { get { return GetResourceString("Promotion_Spend"); } }
//Resources:CampaignResources:Promotion_Title

		public static string Promotion_Title { get { return GetResourceString("Promotion_Title"); } }
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

		public static class Names
		{
			public const string Campaign_Description = "Campaign_Description";
			public const string Campaign_EndDate = "Campaign_EndDate";
			public const string Campaign_StartDate = "Campaign_StartDate";
			public const string Campaign_Title = "Campaign_Title";
			public const string Common_Description = "Common_Description";
			public const string Common_IsPublic = "Common_IsPublic";
			public const string Common_IsRequired = "Common_IsRequired";
			public const string Common_Key = "Common_Key";
			public const string Common_Key_Help = "Common_Key_Help";
			public const string Common_Key_Validation = "Common_Key_Validation";
			public const string Common_LastUpdated = "Common_LastUpdated";
			public const string Common_LastUpdatedBy = "Common_LastUpdatedBy";
			public const string Common_Name = "Common_Name";
			public const string Promotion_Budget = "Promotion_Budget";
			public const string Promotion_Description = "Promotion_Description";
			public const string Promotion_Spend = "Promotion_Spend";
			public const string Promotion_Title = "Promotion_Title";
			public const string SocialMedia_Account = "SocialMedia_Account";
			public const string SocialMedia_Account_Help = "SocialMedia_Account_Help";
			public const string SocialMedia_AccountId = "SocialMedia_AccountId";
			public const string SocialMedia_AccountKey = "SocialMedia_AccountKey";
			public const string SocialMedia_AccountName = "SocialMedia_AccountName";
		}
	}
}
