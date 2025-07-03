using LagoVista.Core.Models;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    public interface IEmailTokens
    {
        public EmailAddress From { get; }

        public EmailAddress ReplyTo { get; }

        public EntityHeader Org { get; set; }
        public string OrgNameSpace { get; set; }

        public EntityHeader Template { get; set; }

        public EntityHeader Campaign { get;}
        public EntityHeader Promotion { get;  }

        public List<Recipient> Recipients { get; set;}

        public List<PageLink> PageLinks { get; }
        public string SenderEmailSignature { get; }
        public string SenderPhone { get; }
    }

}
