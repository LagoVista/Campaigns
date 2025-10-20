// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 601f5a42a703ebc10e6a00bbec2f4712748f1f4381ba5b3683dd0bcf3a2f5054
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
using System.Collections.Generic;
using System.Net.Mail;

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

        public List<EmailAttachment> Attachments { get; set; } = new List<EmailAttachment>();
        public List<PageLink> PageLinks { get; set; } = new List<PageLink>();
        public List<Recipient> ToRecipients { get; set; } = new List<Recipient>();
        public List<Recipient> CcRecipients { get; set; } = new List<Recipient>();
    }
}
