using LagoVista.Campaigns.Interfaces;
using LagoVista.Campaigns.Models;
using LagoVista.Core;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.Logging.Loggers;
using MongoDB.Driver.Core.Configuration;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Repos
{
    public class MetricsRepo : IMetricsRepo
    {
        IConnectionSettings _connectionSettings;
        IAdminLogger _adminLogger;

        /*
Cdrop table public.metrics;
CREATE TABLE public.metrics (
    "time" timestamp with time zone NOT NULL,
    metric text NOT NULL,
    metricid text NOT NULL,
    span character(1) NOT NULL,
    orgid text NOT NULL,
    org text NOT NULL,
    userid text,
    username text,
    categoryid text,
    category text,
    attr1id text,
    attr1 text,
    attr2id text,
    attr2 text,
    attr3id text,
    attr3 text,
    attr4id text,
    attr4 text,
    attr5id text,
    attr5 text,
    value double precision NOT NULL
);          

drop table metrics_definition;
CREATE TABLE metrics_definition(
    id  char(32),
    name         text not null,
    key          text not null,
	attr1name text not null,
	attr2name text not null,
	attr3name text not null,	
	attr4name text not null,
	attr5name text not null
); 

insert into metrics_definition(id, name, key, attr1name, attr2name, attr3name, attr4name, attr5name) values('4A84863CF9654F009E6463C87B46D5D6', 'directemailssent', 'Direct Emails Sent', 'Industry', 'Industry Niche','Sales Stage', 'Campaign', 'Promotion' );
insert into metrics_definition(id, name, key, attr1name, attr2name, attr3name, attr4name, attr5name) values('A8D44B760C83469EB6814100F79476FF', 'directemailsopened', 'Direct Emails Opended', 'Industry', 'Industry Niche','Sales Stage', 'Campaign', 'Promotion');
insert into metrics_definition(id, name, key, attr1name, attr2name, attr3name, attr4name, attr5name) values('A9677684F14A443E93A320147929A035', 'directemailclicks', 'Direct Emails Clicked', 'Industry', 'Industry Niche','Sales Stage', 'Campaign', 'Promotion');


        */

        public MetricsRepo(IMetricStorageConnectionSettings repoSettings, IAdminLogger adminLogger)
        {
            _connectionSettings = repoSettings.MetricsStorageDBConenction;
            _adminLogger = adminLogger;
        }


        protected NpgsqlConnection OpenConnection(string orgId)
        {
            var connString = $"Host={_connectionSettings.Uri};Username={_connectionSettings.UserName};Password={_connectionSettings.Password};";// ;
            connString += $"Database={_connectionSettings.ResourceName}{orgId.ToLower()}";

            var conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }

        public async Task<IEnumerable<KpiMetricsValue>> GetMetricsForKpi(ListRequest listRequest, Kpi kpi)
        {
            using (var cn = OpenConnection(kpi.OwnerOrganization.Id))
            using (var cmd = new NpgsqlCommand())
            {
                var sql = @"select time_bucket('1 day', ""time"")  as day,
 count(value) value
 from Metrics
 where metricid = @metricId ";

                var bldr = new StringBuilder();
                bldr.Append($" @metric={kpi.Metric.Id};");
                cmd.Parameters.Add(new NpgsqlParameter("@metricId", kpi.Metric.Id));

                if (!EntityHeader.IsNullOrEmpty(kpi.Attr1))
                {
                    sql += " and attr1 = @attr1 ";
                    bldr.Append($" @attr1={kpi.Attr1.Id};");
                    cmd.Parameters.Add(new NpgsqlParameter("@attr1", kpi.Attr1.Id));
                }

                if (!EntityHeader.IsNullOrEmpty(kpi.Attr2))
                {
                    sql += " and attr2 = @attr2 ";
                    bldr.Append($" @attr2={kpi.Attr2.Id};");
                    cmd.Parameters.Add(new NpgsqlParameter("@attr2", kpi.Attr2.Id));
                }

                if (!EntityHeader.IsNullOrEmpty(kpi.Attr3))
                {
                    sql += " and attr3 = @attr3 ";
                    bldr.Append($" @attr3={kpi.Attr3.Id};");
                    cmd.Parameters.Add(new NpgsqlParameter("@attr3", kpi.Attr3.Id));
                }

                if (!EntityHeader.IsNullOrEmpty(kpi.Attr4))
                {
                    sql += " and attr4 = @attr4 ";
                    bldr.Append($" @attr4={kpi.Attr4.Id};");
                    cmd.Parameters.Add(new NpgsqlParameter("@attr4", kpi.Attr4.Id));
                }

                if (!EntityHeader.IsNullOrEmpty(kpi.Attr5))
                {
                    sql += " and attr5 = @attr5 ";
                    bldr.Append($" @attr5={kpi.Attr5.Id};");
                    cmd.Parameters.Add(new NpgsqlParameter("@attr5", kpi.Attr5.Id));
                }

                sql += "and time between @start and @end ";
                
                var start = new DateTime(listRequest.StartDate.ToDateTime().Year,
                    listRequest.StartDate.ToDateTime().Month,
                    listRequest.StartDate.ToDateTime().Day,0,0,0,
                     kind: DateTimeKind.Utc);

                var end = new DateTime(listRequest.EndDate.ToDateTime().Year,
                    listRequest.EndDate.ToDateTime().Month,
                    listRequest.EndDate.ToDateTime().Day, 0, 0, 0,
                     kind: DateTimeKind.Utc);


                cmd.Parameters.Add(new NpgsqlParameter() { ParameterName = "@start", DbType = System.Data.DbType.DateTime, Value = start} );
                cmd.Parameters.Add(new NpgsqlParameter() { ParameterName = "@end", DbType = System.Data.DbType.DateTime, Value = end });

                bldr.Append($"@start={start}; @end={end};");

                sql += @"group by day
                         order by day;";

                cmd.Connection = cn;
                cmd.CommandText = sql;

                _adminLogger.Trace($"[MetricsRepo__GetMetricsForKpi] - {sql} {bldr}");

                var tempMetrics = new List<KpiMetricsValue>();

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read()) {
                    tempMetrics.Add(new KpiMetricsValue() {
                        TimeStamp = Convert.ToDateTime(reader[0]).ToJSONString(),
                        Value = Convert.ToDouble(reader[1])
                    });
                }

                var current = start;

                var metrics = new List<KpiMetricsValue>();
                while(current < end)
                {
                    var hasMetric = tempMetrics.FirstOrDefault(tmp => tmp.TimeStamp == current.ToJSONString());
                    
                    metrics.Add(new KpiMetricsValue()
                    {
                        TimeStamp = current.ToJSONString(),
                        Value = hasMetric == null ? 0 : hasMetric.Value
                    });

                    current = current.AddDays(1);
                }


                return metrics;
            }
   
        }


        public async Task AddMetricsDefinition(MetricsDefinition metricsDefinition)
        {
            try
            {
                var insertClause = "insert into metrics_definition(org, orgid, name, key, metrics_definition_id)";
                var valuesClause = $"values (@org, @orgId, @name, @key, @def_id)";


                using (var cn = OpenConnection(metricsDefinition.OwnerOrganization.Id))
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = $"{insertClause} {valuesClause} ";
                    cmd.Parameters.Add(new NpgsqlParameter("@org", metricsDefinition.OwnerOrganization.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@orgid", metricsDefinition.OwnerOrganization.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@name", metricsDefinition.Name));
                    cmd.Parameters.Add(new NpgsqlParameter("@key", metricsDefinition.Key));
                    cmd.Parameters.Add(new NpgsqlParameter("@def_id", metricsDefinition.Id));

                    var recordCount = await cmd.ExecuteNonQueryAsync();
                    if (recordCount != 1)
                        throw new Exception();
                }
            }
            catch (Exception ex)
            {
                var password = _connectionSettings.Password.ToCharArray().First() + "***" + _connectionSettings.Password.ToCharArray().Last();

                _adminLogger.AddError("[MetricsRepo__AddMetirc]", ex.Message, _connectionSettings.Uri.ToKVP("uri"),
                    _connectionSettings.UserName.ToKVP("username"), password.ToKVP("password"), _connectionSettings.ResourceName.ToKVP("database"));

                throw;
            }
        }

        public async Task UpdateMetricsDefinition(MetricsDefinition metricsDefinition)
        {
            try
            {
                var updateClause = @"Updates metrics_definition(name = @name) where metrics_definition_id = @def_id )";
                

                using (var cn = OpenConnection(metricsDefinition.OwnerOrganization.Id))
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = updateClause;
                    cmd.Parameters.Add(new NpgsqlParameter("@name", metricsDefinition.Name));
                    cmd.Parameters.Add(new NpgsqlParameter("@def_id", metricsDefinition.Id));

                    var recordCount = await cmd.ExecuteNonQueryAsync();
                    if (recordCount != 1)
                        throw new Exception();
                }
            }
            catch (Exception ex)
            {
                var password = _connectionSettings.Password.ToCharArray().First() + "***" + _connectionSettings.Password.ToCharArray().Last();

                _adminLogger.AddError("[MetricsRepo__AddMetirc]", ex.Message, _connectionSettings.Uri.ToKVP("uri"),
                    _connectionSettings.UserName.ToKVP("username"), password.ToKVP("password"), _connectionSettings.ResourceName.ToKVP("database"));
            }
        }


        public async Task AddMetric(KpiMetric metric)
        {
            try
            {
                var insertClause = "insert into Metrics(time, span, orgid, org, userid, username, categoryid, category, metric, metricid,   attr1id,  attr1,   attr2id,  attr2,   attr3id,  attr3,   attr4id,  attr4,   attr5id,  attr5,  value)";
                var valuesClause = $"values (@time, @span, @org, @orgId, @user, @userId, @categoryId, @category, @metric, @metricid,       @attr1id, @attr1,  @attr2id, @attr2,  @attr3id, @attr3,  @attr4id, @attr4,  @attr5id, @attr5, @value)";

                var span = "-";
                switch (metric.Period)
                {
                    case KpiPeriod.Month: span = "M"; break;
                    case KpiPeriod.Day: span = "D"; break;
                    case KpiPeriod.Hour: span = "H"; break;
                    case KpiPeriod.Week: span = "W"; break;
                    case KpiPeriod.Each: span = "E"; break;
                }

                using (var cn = OpenConnection(metric.Org.Id))
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = $"{insertClause} {valuesClause}";
                    var tsParameter = new NpgsqlParameter()
                    {
                        ParameterName = "@time",
                        DbType = System.Data.DbType.DateTime,
                        Value = metric.TimeStamp.ToDateTime(),
                    };
                    cmd.Parameters.Add(tsParameter);
                    cmd.Parameters.Add(new NpgsqlParameter("@span", span));
                    cmd.Parameters.Add(new NpgsqlParameter("@org", metric.Org.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@orgId", metric.Org.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@category", metric.Category.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@categoryId", metric.Category.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@metric", metric.Metric.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@metricId", metric.Metric.Id));

                    cmd.Parameters.Add(new NpgsqlParameter("@user", EntityHeader.IsNullOrEmpty(metric.User) ? (object)DBNull.Value : (object)metric.User.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@userId", EntityHeader.IsNullOrEmpty(metric.User) ? (object)DBNull.Value : metric.User.Id));

                    cmd.Parameters.Add(new NpgsqlParameter("@attr1id", EntityHeader.IsNullOrEmpty(metric.Attr1) ? (object)DBNull.Value : metric.Attr1.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr1", EntityHeader.IsNullOrEmpty(metric.Attr1) ? (object)DBNull.Value : metric.Attr1.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr2id", EntityHeader.IsNullOrEmpty(metric.Attr2) ? (object)DBNull.Value : metric.Attr2.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr2", EntityHeader.IsNullOrEmpty(metric.Attr2) ? (object)DBNull.Value : metric.Attr2.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr3id", EntityHeader.IsNullOrEmpty(metric.Attr3) ? (object)DBNull.Value : metric.Attr3.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr3", EntityHeader.IsNullOrEmpty(metric.Attr3) ? (object)DBNull.Value : metric.Attr3.Id));

                    cmd.Parameters.Add(new NpgsqlParameter("@attr4id", EntityHeader.IsNullOrEmpty(metric.Attr4) ? (object)DBNull.Value : metric.Attr4.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr4", EntityHeader.IsNullOrEmpty(metric.Attr4) ? (object)DBNull.Value : metric.Attr4.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr5id", EntityHeader.IsNullOrEmpty(metric.Attr5) ? (object)DBNull.Value : metric.Attr5.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr5", EntityHeader.IsNullOrEmpty(metric.Attr5) ? (object)DBNull.Value : metric.Attr5.Id));

                    cmd.Parameters.Add(new NpgsqlParameter("@value", metric.Value));

                    var recordCount = await cmd.ExecuteNonQueryAsync();
                    if (recordCount != 1)
                        throw new Exception();
                }

                _adminLogger.Trace($"[MetricsRepo__Addmetric] Inserted Metric: {metric.Metric.Text}");
            }
            catch (Exception ex)
            {
                var password = _connectionSettings.Password.ToCharArray().First() + "***" + _connectionSettings.Password.ToCharArray().Last();

                _adminLogger.AddError("[MetricsRepo__AddMetirc]", ex.Message, _connectionSettings.Uri.ToKVP("uri"), 
                    _connectionSettings.UserName.ToKVP("username"), password.ToKVP("password"), _connectionSettings.ResourceName.ToKVP("database"));
            }

        }
    }
}
