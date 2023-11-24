using LagoVista.Core;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    public class SocialMediaAccount : EntityBase, IValidateable
    {
        public enum SocialMediaTypes
        {
            Twitter,
            Facebook,
            Instagram,
            LinkedIn
        }

        public SocialMediaAccount()
        {
            Id = Guid.NewGuid().ToId();
        }

        public List<EntityChangeSet> History { get; set; } = new List<EntityChangeSet>();

        public string AccountName { get; set; }
        public string AccountId { get; set; }
        public string AccountSecret { get; set; }
        public string AccountSecretId { get; set; }
       
        public EntityHeader<SocialMediaTypes> Type {get; set;}
     }
}
