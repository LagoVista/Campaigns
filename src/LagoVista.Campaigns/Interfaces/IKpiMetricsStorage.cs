using LagoVista.Campaigns.Models;
using LagoVista.Core.Models;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Interfaces
{

    /*
    create table Metrics (
    time TimestampTz not null,
    span character not null,
    orgid text not null,
    org text not null,
    userid text null,
    username text null,
    categoryid text null,
    category text null,
    attr1id text not null,
    attr1 text null,
    attr2id text not null,
    attr2 text null,
    attr3id text not null,
    attr3 text null,    
    value double precision not null);

    SELECT create_hypertable('Metrics', 'time');

grant connect on database metricstest to metricsdevuser;
GRANT ALL PRIVILEGES ON DATABASE "metricstest" to metricsdevuser;
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public to metricsdevuser;


);*/

    public interface IKpiMetricsStorage
    {
        Task AddMetric(KpiMetric metric);
    }
}
