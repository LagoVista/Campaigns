using LagoVista.Core.Models;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    public class EmailTokens : IEmailTokens
    {
        public string EmailAddress {get; set;}

        public EmailAddress From {get; set;}

        public EmailAddress ReplyTo {get; set;}

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public EntityHeader Org {get; set;}

        public string OrgNameSpace {get; set;}

        public EntityHeader Company { get; set; }
        public EntityHeader Contact { get; set; }

        public EntityHeader Template {get; set;}

        public EntityHeader Industry {get; set;}

        public EntityHeader IndustryNiche {get; set;}

        public EntityHeader IndustryPersona {get; set;}

        public EntityHeader IndustryNichePersona {get; set;}

        public EntityHeader Survey {get; set;}

        public EntityHeader Campaign {get; set;}

        public EntityHeader Promotion {get; set;}

        public EntityHeader ProductPage {get; set;}

        public LandingPageSummary LandingPage {get; set;}

        public string SenderEmailSignature {get; set;}

        public string SenderEmail {get; set;}

        public string SenderName {get; set;}

        public string SenderPhone {get; set;}
    }

}
