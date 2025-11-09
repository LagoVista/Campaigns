// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: bd250e1f967c29e26357ae6dcc09adae6beec5869267726f58ed278c2121dcb3
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Models.UIMetaData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.Campaigns.Models
{
    [DomainDescriptor]
    public class CampaignDomain
    {
        public const string CampaignAdmin = "Campaigns";

        [DomainDescription(CampaignAdmin)]
        public static DomainDescription DeploymentAdminDescription
        {
            get
            {
                return new DomainDescription()
                {
                    Description = "Campaing Module is used to track goals.",
                    DomainType = DomainDescription.DomainTypes.BusinessObject,
                    Name = "Campaign",
                    CurrentVersion = new Core.Models.VersionInfo()
                    {
                        Major = 1,
                        Minor = 0,
                        Build = 001,
                        DateStamp = new DateTime(2022, 9, 17),
                        Revision = 1,
                        ReleaseNotes = "Initial Release"
                    }
                };
            }
        }
    }
}
