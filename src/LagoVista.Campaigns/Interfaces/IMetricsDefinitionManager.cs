﻿using LagoVista.Campaigns.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Interfaces
{
    public interface IMetricsDefinitionManager
    {
        Task<InvokeResult> AddMetricsDefinitionAsync(MetricsDefinition metricsDefinition, EntityHeader org, EntityHeader user);
        Task<MetricsDefinition> GetMetricsDefinitionAsync(string id, EntityHeader org, EntityHeader user);
        Task<MetricsDefinition> GetMetricsDefinitionByKeyAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteMetricsDefinitionAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateMetricsDefinitionAsync(MetricsDefinition metricsDefinition, EntityHeader org, EntityHeader user);
        Task<ListResponse<MetricsDefinitionSummary>> GetMetricsDefinitionsAsync(ListRequest request, EntityHeader org, EntityHeader user);
    }
}
