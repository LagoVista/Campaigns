using LagoVista.Core.Models;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    public class EmailTokens : IEmailTokens
    {
        public string EmailAddress {get; set;}

        public EmailAddress From {get; set;}
        public EmailAddress ReplyTo {get; set;}

        public EntityHeader Org {get; set;}

        public string OrgNameSpace {get; set;}

        public EntityHeader Template {get; set;}



        public EntityHeader Campaign {get; set;}

        public EntityHeader Promotion {get; set;}




        public string SenderEmailSignature {get; set;}        
        public string SenderPhone { get; set;  }

        public List<PageLink> PageLinks { get; set; } = new List<PageLink>();
        public List<Recipient> ToRecipients { get; set; } = new List<Recipient>();
        public List<Recipient> CcRecipients { get; set; } = new List<Recipient>();
    }
}
