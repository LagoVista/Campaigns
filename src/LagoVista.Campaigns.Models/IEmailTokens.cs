// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: fc22fa4a7e88de3c11aba4dd5e659a8f0456f06b26dca3e74b9a781ed905381f
// IndexVersion: 2
// --- END CODE INDEX META ---
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

        public List<Recipient> ToRecipients { get; set;}
        public List<Recipient> CcRecipients { get; set; }

        public List<PageLink> PageLinks { get; }
        public List<EmailAttachment> Attachments { get;  }
        public string SenderEmailSignature { get; }
        public string SenderPhone { get; }
    }

}
