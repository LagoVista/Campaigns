using LagoVista.Core;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using Newtonsoft.Json;
using System;

namespace LagoVista.Campaigns.Models
{
    public class SocialMediaAccount : IOwnedEntity, IIDEntity, IValidateable, INoSQLEntity
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

        [JsonProperty("id")]
        public String Id { get; set; }

        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }
        public string CreationDate { get; set; }
        public string LastUpdatedDate { get; set; }
        public EntityHeader CreatedBy { get; set; }
        public EntityHeader LastUpdatedBy { get; set; }
        public string DatabaseName { get; set; }
        public string EntityType { get; set; }


        public string AccountName { get; set; }
        public string AccountId { get; set; }
        public string AccountSecret { get; set; }
        public string AccountSecretId { get; set; }
       
        public EntityHeader<SocialMediaTypes> Type {get; set;}
     }
}
