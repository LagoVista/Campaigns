// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 3b9ca5f3e19f71d71f835eea5586603c16d3205e5d7978b1d36f15e15698a787
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Campaigns.Models.Resources;
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.Campaigns.Models
{
    public class CampaignModelBase : EntityBase, IValidateable, IDescriptionEntity
    {
        public CampaignModelBase()
        {
            Id = Guid.NewGuid().ToId();
        }

        [FormField(LabelResource: CampaignResources.Names.Common_Description, IsRequired: false, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(CampaignResources))]
        public string Description { get; set; }
    }
}
