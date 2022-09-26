using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.Campaigns.Models
{
    public class SocialMediaPost
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public EntityHeader Account {get; set;}
        public EntityHeader SiteContent { get; set;}
    }
}
