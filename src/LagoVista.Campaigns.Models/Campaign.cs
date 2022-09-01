using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core.Attributes;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    [EntityDescription(CampaignDomain.CampaignAdmin, CampaignResources.Names.Campaign_Title, CampaignResources.Names.Campaign_Description, 
        Resources.CampaignResources.Names.Campaign_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(CampaignResources))]
    public class Campaign : CampaignModelBase
    {
        public List<Promotion> Promotions { get; set; } = new List<Promotion>();
   
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class CampaignSummary
    {

    }
}
