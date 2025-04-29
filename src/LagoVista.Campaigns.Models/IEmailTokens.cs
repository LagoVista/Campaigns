using LagoVista.Core.Models;
using System.Collections.Generic;

namespace LagoVista.Campaigns.Models
{
    public interface IEmailTokens
    {
        public EmailAddress From { get; }

        public EmailAddress ReplyTo { get; }

        public string EmailAddress { get; set; }
        public string FirstName { get;  }
        public string LastName { get; }
        public EntityHeader Company { get; set; }
        public EntityHeader Contact { get; set; }

        public EntityHeader Org { get; set; }
        public string OrgNameSpace { get; set; }

        public EntityHeader Template { get; set; }
        public EntityHeader Industry { get; }
        public EntityHeader IndustryNiche { get; }
        public EntityHeader IndustryPersona { get; }
        public EntityHeader IndustryNichePersona { get;  }
        public EntityHeader Survey { get; }
        public EntityHeader Campaign { get;}
        public EntityHeader Promotion { get;  }
        public EntityHeader ProductPage { get;  }
        public LandingPageSummary LandingPage { get; }
        public string SenderEmailSignature { get; }
        public string SenderEmail { get; }
        public string SenderName { get;  }
        public string SenderPhone { get; }
    }

}
