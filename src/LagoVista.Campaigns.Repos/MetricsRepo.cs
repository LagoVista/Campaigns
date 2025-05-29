using LagoVista.Campaigns.Interfaces;
using LagoVista.Campaigns.Models;
using LagoVista.Core;
using LagoVista.Core.Exceptions;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.Logging.Loggers;
using MongoDB.Driver.Core.Configuration;
using Npgsql;
using Prometheus;
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
    public class MetricsRepo : IMetricsRepo, IMetricsDefinitionRepo
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
    attr6id text,
    attr6 text,
    value double precision NOT NULL
);          


drop table metrics_definition;
CREATE TABLE metrics_definition(
    id  char(32),
    name         text not null,
    summary      text not null,
    help         text not null,
    description  text not null,
    key          text not null,
    icon         text not null,
    categoryId   text not null,
    categoryKey  text not null,
    categoryName text not null,
	attr1name text null,
	attr1key text null,
	attr2name text null,
	attr2key text null,
	attr3name text null,	
	attr3key text null,
	attr4name text null,
	attr4key text null,
	attr5name text null,
	attr5key text null,
    attr6name text null,
	attr6key text null,
    readonly boolean not null
); 

insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
                        attr4name, attr4key, attr5name, attr5key, attr6name, attr6key, 
						readonly) 
                values('1A84863CF9654F009E6463C87B46D5D9', 'contactpageview', 'Contact Page View', 
                        'Contact Page View', 'Number of times a contact page  page has been viewed','',
                        'icon-pz-stock-1','30C28365B52A428BB8C32D38C690732A', 'marketing', 'Marketing',
                        'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
                        'Campaign', 'campaign', 'Promotion', 'promotion', 'Template', 'template', 
						true);


insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
                        attr4name, attr4key, attr5name, attr5key, attr6name, attr6key, 
						readonly) 
                values('2A84863CF9654F009E6463C87B46D5D8', 'contactpagesubmitted', 'Contact Us Submitted', 
                       'Contact Us Submitted', 'Number of times a contact has populated and submitted a Contact Us page','',
                        'icon-pz-stock-1','30C28365B52A428BB8C32D38C690732A', 'marketing', 'Marketing',
                        'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
                        'Campaign', 'campaign', 'Promotion', 'promotion', 'Template', 'template', 
						true);						


insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
                        attr4name, attr4key, attr5name, attr5key, attr6name, attr6key, 
						readonly) 
                values('3A84863CF9654F009E6463C87B46D5D7', 'landingpageview', 'Landing Page View', 
                       'Landing Page View', 'Number of times a landing page has been viewed','',
                        'icon-pz-stock-1','30C28365B52A428BB8C32D38C690732A', 'marketing', 'Marketing',
                        'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
                        'Campaign', 'campaign', 'Promotion', 'promotion', 'Template', 'template', 
						true);


insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
                        attr4name, attr4key, attr5name, attr5key, attr6name, attr6key, 
						readonly) 
                values('4A84863CF9654F009E6463C87B46D5D6', 'directemailssent', 'Direct Emails Sent', 
                       'Total number of direct emails sent', 'Number of direct emails sent to customers','',
                        'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',
                        'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
                        'Campaign', 'campaign', 'Promotion', 'promotion', 'Template', 'template', 
						true);

insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
                        attr4name, attr4key, attr5name, attr5key, attr6name, attr6key, 
						readonly) 
                values('5A84863CF9654F009E6463C87B46D5D5', 'postalmailssent', 'Direct Mails (postal) Sent', 
                       'Total number of direct email (postal) sent', 'Number of tri-fold or other direct messages sent to customers','',
                        'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',
                        'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
                        'Campaign', 'campaign', 'Promotion', 'promotion', 'Template', 'template', 
						true);						

insert into metrics_definition(id, key, name,  
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
                        attr4name, attr4key, attr5name, attr5key, attr6name, attr6key, 
						readonly) 
            values('A8D44B760C83469EB6814100F79476FF', 'directemailsopened', 'Direct Emails Opended', 
                        'Total number of emails opened', 'Total number of emails that have been opened by customers.  Since some email servers will automatically open emails, only emails opened 2 minutes after send time stamp will be counted','',
                        'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',
                        'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
                        'Campaign', 'campaign', 'Promotion', 'promotion', 'Template', 'template', 
						true);

insert into metrics_definition(id, key, name,  
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
                        attr4name, attr4key, attr5name, attr5key, attr6name, attr6key, 
						readonly) 
            values('A9677684F14A443E93A320147929A035', 'directemailclicks', 'Direct Emails Clicked', 
                        'Total clicks on emails sent to users.', 'Total number of clicks by users on email sent to customers.  Since some email servers will automatically open emails, only emails opened 2 minutes after send time stamp will be counted','',
                        'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',
                        'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
                        'Campaign', 'campaign', 'Promotion', 'promotion', 'Template', 'template', 
						true);

        insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
						readonly) 
                values('137942FCBCFB4BC6A876C31E2843E5FF', 'hostlead', 'Hot Lead',
                       'New Hot Lead', 'Lead where they opened or clicked on an email, they may not have directly contact us','',
                       'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',         
                       'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
						true);


insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
						readonly) 
                values('237942FCBCFB4BC6A876C31E2843E5FE', 'engagedlead', 'Lead Engaged',
                       'New Engaged Lead', 'Leads where a contact was engaged in a two way converstation and expressed interest in a product','',
                       'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',                                               
                       'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
						true);

insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
						readonly) 
                values('337942FCBCFB4BC6A876C31E2843E5FD', 'customerconverted', 'Customer Converted', 
                       'New Customers', 'A customer that has purchased a product or service from us','',
                       'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',                                               
                       'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
						true);

insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
						readonly) 
                values('437942FCBCFB4BC6A876C31E2843E5FC', 'proposalscreated', 'Proposals Created and Submitted',
                       'Customer Proposals Created and Submitted', 'Total number of proposals that have been created and sent out to a a customer','',
                       'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',                                                                                     
                       'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
						true);

insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
						readonly) 
                values('537942FCBCFB4BC6A876C31E2843E5FB', 'agreementscreated', 'Agreements Created and Submitted',
                       'Customer Agreements Created and Submitted', 'Total number of proposals that have been created and sent out to a a customer','',
                       'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',                                                                                                                          
                       'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
						true);
						

insert into metrics_definition(id, key, name,
                        summary, help, description,
                        icon, categoryId, categoryKey, categoryName,
                        attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, 
						readonly) 
                values('437942FCBCFB4BC6A876C31E2843E5FC', 'proposalscreated', 'Proposals Created and Submitted',
                       'Customer Proposals Created and Submitted', 'Total number of proposals that have been created and sent out to a a customer','',
                       'icon-pz-stock-1','40C28365B52C4288B8C32D38C690732B', 'sales', 'Sales',                                                                                     
                       'Industry', 'industry', 'Industry Niche', 'industryniche', 'Sales Stage', 'salestage',
						true);


CREATE EXTENSION IF NOT EXISTS timescaledb;
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

                if (!EntityHeader.IsNullOrEmpty(kpi.Attr6))
                {
                    sql += " and attr6 = @attr6 ";
                    bldr.Append($" @attr5={kpi.Attr6.Id};");
                    cmd.Parameters.Add(new NpgsqlParameter("@attr6", kpi.Attr6.Id));
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


        public async Task AddMetricsDefinitionAsync(string orgId, MetricsDefinition metricsDefinition)
        {
            var insertClause = @"insert into metrics_definition(id, name, summary, help, description, key, icon, categoryId, categoryKey, categoryName, attr1name, attr1key, attr2name, attr2key, attr3name, attr3key, attr4name, attr4key, attr5name, attr5key, attr6name, attr6key, readonly)";
            var valuesClause = $"values (@id, @name, @summary, @help, @description, @key, @icon, @categoryId, @categoryKey, @categoryName, @attr1name, @attr1key, @attr2name, @attr2key, @attr3name, @attr3key, @attr4name, @attr4key, @attr5name, @attr5key, @attr6name, @attr6key, @readonly)";

            using (var cn = OpenConnection(orgId))
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = $"{insertClause} {valuesClause}";
                cmd.Parameters.Add(new NpgsqlParameter("@id", string.IsNullOrEmpty(metricsDefinition.Id) ? (object)DBNull.Value : metricsDefinition.Id));
                cmd.Parameters.Add(new NpgsqlParameter("@name", string.IsNullOrEmpty(metricsDefinition.Name) ? (object)DBNull.Value : metricsDefinition.Name));
                cmd.Parameters.Add(new NpgsqlParameter("@key", string.IsNullOrEmpty(metricsDefinition.Key) ? (object)DBNull.Value : metricsDefinition.Key));
                cmd.Parameters.Add(new NpgsqlParameter("@description", string.IsNullOrEmpty(metricsDefinition.Description) ? (object)DBNull.Value : metricsDefinition.Description));
                cmd.Parameters.Add(new NpgsqlParameter("@icon", metricsDefinition.Icon));
                cmd.Parameters.Add(new NpgsqlParameter("@categoryId", metricsDefinition.Category?.Id ?? (object)DBNull.Value));
                cmd.Parameters.Add(new NpgsqlParameter("@categoryKey", metricsDefinition.Category?.Key ?? (object)DBNull.Value));
                cmd.Parameters.Add(new NpgsqlParameter("@categoryName", metricsDefinition.Category?.Text ?? (object)DBNull.Value));
                cmd.Parameters.Add(new NpgsqlParameter("@attr1name", string.IsNullOrEmpty(metricsDefinition.Attribute1Name) ? (object)DBNull.Value : metricsDefinition.Attribute1Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr2name", string.IsNullOrEmpty(metricsDefinition.Attribute2Name) ? (object)DBNull.Value : metricsDefinition.Attribute2Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr3name", string.IsNullOrEmpty(metricsDefinition.Attribute3Name) ? (object)DBNull.Value : metricsDefinition.Attribute3Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr4name", string.IsNullOrEmpty(metricsDefinition.Attribute4Name) ? (object)DBNull.Value : metricsDefinition.Attribute4Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr5name", string.IsNullOrEmpty(metricsDefinition.Attribute5Name) ? (object)DBNull.Value : metricsDefinition.Attribute5Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr6name", string.IsNullOrEmpty(metricsDefinition.Attribute6Name) ? (object)DBNull.Value : metricsDefinition.Attribute6Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr1key", string.IsNullOrEmpty(metricsDefinition.Attribute1Key) ? (object)DBNull.Value : metricsDefinition.Attribute1Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr2key", string.IsNullOrEmpty(metricsDefinition.Attribute2Key) ? (object)DBNull.Value : metricsDefinition.Attribute2Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr3key", string.IsNullOrEmpty(metricsDefinition.Attribute3Key) ? (object)DBNull.Value : metricsDefinition.Attribute3Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr4key", string.IsNullOrEmpty(metricsDefinition.Attribute4Key) ? (object)DBNull.Value : metricsDefinition.Attribute4Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr5key", string.IsNullOrEmpty(metricsDefinition.Attribute5Key) ? (object)DBNull.Value : metricsDefinition.Attribute5Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr6key", string.IsNullOrEmpty(metricsDefinition.Attribute6Key) ? (object)DBNull.Value : metricsDefinition.Attribute6Key));
                cmd.Parameters.Add(new NpgsqlParameter("@summary", string.IsNullOrEmpty(metricsDefinition.Summary) ? (object)DBNull.Value : metricsDefinition.Summary));
                cmd.Parameters.Add(new NpgsqlParameter("@help", string.IsNullOrEmpty(metricsDefinition.Help) ? (object)DBNull.Value : metricsDefinition.Help));
                cmd.Parameters.Add(new NpgsqlParameter("@readonly", metricsDefinition.IsReadOnly));

                var recordCount = await cmd.ExecuteNonQueryAsync();
                if (recordCount != 1)
                    throw new Exception();
            }

            _adminLogger.Trace($"[MetricsRepo__Addmetric] Inserted MetricsDefinition: {metricsDefinition.Name}", orgId.ToKVP("orgId"));
        }



        public async Task AddMetric(KpiMetric metric)
        {
            try
            {
                var insertClause = "insert into Metrics(time, span, orgid, org, userid, username, categoryid, category, metric, metricid,   attr1id,  attr1,   attr2id,  attr2,   attr3id,  attr3,   attr4id,  attr4,   attr5id,  attr5,   attr6id,  attr6,  value)";
                var valuesClause = $"values (@time, @span, @org, @orgId, @user, @userId, @categoryId, @category, @metric, @metricid,       @attr1id, @attr1,  @attr2id, @attr2,  @attr3id, @attr3,  @attr4id, @attr4,  @attr5id, @attr5,  @attr6id, @attr6, @value)";

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

                    cmd.Parameters.Add(new NpgsqlParameter("@attr6id", EntityHeader.IsNullOrEmpty(metric.Attr6) ? (object)DBNull.Value : metric.Attr6.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@attr6", EntityHeader.IsNullOrEmpty(metric.Attr6) ? (object)DBNull.Value : metric.Attr6.Id));

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

        public Task DeleteMetricsDefinitionAsync(string orgId, string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMetricsDefinitionAsync(string orgId, MetricsDefinition metricsDefinition)
        {
            var updateClause = @"
update metrics_definition
   set  name = @name,
        description = @description,
        icon = @icon,
        category = @categoryId,
        categoryKey = @categoryKey,
        categoryName = @categoryName,
        attr1name = @attr1name,
        attr1key = @attr1key,
        attr2name = @attr2name,
        attr2key = @attr2key,
        attr3name = @attr3name,
        attr3key = @attr3key,
        attr4name = @attr4name,
        attr4key = @attr4key,
        attr5name = @attr5name,
        attr5key = @attr5key,
        attr6name = @attr6name,
        attr6key = @attr6key
       where id = @id and readonly = false;";

            using (var cn = OpenConnection(orgId))
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = $"{updateClause}";
                cmd.Parameters.Add(new NpgsqlParameter("@id", string.IsNullOrEmpty(metricsDefinition.Id) ? (object)DBNull.Value : metricsDefinition.Id));
                cmd.Parameters.Add(new NpgsqlParameter("@name", string.IsNullOrEmpty(metricsDefinition.Name) ? (object)DBNull.Value : metricsDefinition.Name));
                cmd.Parameters.Add(new NpgsqlParameter("@key", string.IsNullOrEmpty(metricsDefinition.Key) ? (object)DBNull.Value : metricsDefinition.Key));
                cmd.Parameters.Add(new NpgsqlParameter("@description", string.IsNullOrEmpty(metricsDefinition.Description) ? (object)DBNull.Value : metricsDefinition.Description));
                cmd.Parameters.Add(new NpgsqlParameter("@icon", metricsDefinition.Icon));
                cmd.Parameters.Add(new NpgsqlParameter("@categoryId", metricsDefinition.Category?.Id ?? (object)DBNull.Value));
                cmd.Parameters.Add(new NpgsqlParameter("@categoryKey", metricsDefinition.Category?.Key ?? (object)DBNull.Value));
                cmd.Parameters.Add(new NpgsqlParameter("@categoryName", metricsDefinition.Category?.Text ?? (object)DBNull.Value));
                cmd.Parameters.Add(new NpgsqlParameter("@attr1name", string.IsNullOrEmpty(metricsDefinition.Attribute1Name) ? (object)DBNull.Value : metricsDefinition.Attribute1Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr2name", string.IsNullOrEmpty(metricsDefinition.Attribute2Name) ? (object)DBNull.Value : metricsDefinition.Attribute2Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr3name", string.IsNullOrEmpty(metricsDefinition.Attribute3Name) ? (object)DBNull.Value : metricsDefinition.Attribute3Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr4name", string.IsNullOrEmpty(metricsDefinition.Attribute4Name) ? (object)DBNull.Value : metricsDefinition.Attribute4Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr5name", string.IsNullOrEmpty(metricsDefinition.Attribute5Name) ? (object)DBNull.Value : metricsDefinition.Attribute5Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr6name", string.IsNullOrEmpty(metricsDefinition.Attribute6Name) ? (object)DBNull.Value : metricsDefinition.Attribute6Name));
                cmd.Parameters.Add(new NpgsqlParameter("@attr1key", string.IsNullOrEmpty(metricsDefinition.Attribute1Key) ? (object)DBNull.Value : metricsDefinition.Attribute1Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr2key", string.IsNullOrEmpty(metricsDefinition.Attribute2Key) ? (object)DBNull.Value : metricsDefinition.Attribute2Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr3key", string.IsNullOrEmpty(metricsDefinition.Attribute3Key) ? (object)DBNull.Value : metricsDefinition.Attribute3Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr4key", string.IsNullOrEmpty(metricsDefinition.Attribute4Key) ? (object)DBNull.Value : metricsDefinition.Attribute4Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr5key", string.IsNullOrEmpty(metricsDefinition.Attribute5Key) ? (object)DBNull.Value : metricsDefinition.Attribute5Key));
                cmd.Parameters.Add(new NpgsqlParameter("@attr6key", string.IsNullOrEmpty(metricsDefinition.Attribute6Key) ? (object)DBNull.Value : metricsDefinition.Attribute6Key));

                var recordCount = await cmd.ExecuteNonQueryAsync();
                if (recordCount != 1)
                    throw new Exception();
            }

            _adminLogger.Trace($"[MetricsRepo__Addmetric] Inserted MetricsDefinition: {metricsDefinition.Name}", orgId.ToKVP("orgId"));
        }

        private MetricsDefinition ReadResults(NpgsqlDataReader reader)
        {
            var definition = new MetricsDefinition
            {
                Id = reader["id"].ToString(),
                Name = reader["name"].ToString(),
                Summary = reader["summary"].ToString(),
                Help = reader["help"].ToString(),
                Description = reader["description"].ToString(),
                Key = reader["key"].ToString(),
                Icon = reader["icon"].ToString(),
                Category = new EntityHeader<Core.Models.EntityHeader>
                {
                    Id = reader["categoryId"].ToString(),
                    Key = reader["categoryKey"].ToString(),
                    Text = reader["categoryName"].ToString()
                },
                Attribute1Name = reader["attr1name"]?.ToString(),
                Attribute1Key = reader["attr1key"]?.ToString(),
                Attribute2Name = reader["attr2name"]?.ToString(),
                Attribute2Key = reader["attr2key"]?.ToString(),
                Attribute3Name = reader["attr3name"]?.ToString(),
                Attribute3Key = reader["attr3key"]?.ToString(),
                Attribute4Name = reader["attr4name"]?.ToString(),
                Attribute4Key = reader["attr4key"]?.ToString(),
                Attribute5Name = reader["attr5name"]?.ToString(),
                Attribute5Key = reader["attr5key"]?.ToString(),
                Attribute6Name = reader["attr6name"]?.ToString(),
                Attribute6Key = reader["attr6key"]?.ToString(),
                IsReadOnly = (bool)reader["readonly"]
            };

            if (reader["categoryId"] != DBNull.Value && reader["categoryKey"] != DBNull.Value && reader["category"] != DBNull.Value)
            {
                definition.Category = new EntityHeader<Core.Models.EntityHeader>
                {
                    Id = reader["categoryId"].ToString(),
                    Key = reader["categoryKey"].ToString(),
                    Text = reader["categoryName"].ToString()
                };
            }

            return definition;
        }

        public async Task<MetricsDefinition> GetMetricsDefinitionAsync(string orgId, string id)
        {
            var sql = @"SELECT *
                        FROM metrics_definition
                        WHERE id = @id";

            using (var cn = OpenConnection(orgId))
            using (var cmd = new NpgsqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return ReadResults(reader);
                    }
                    else
                    {
                        throw new RecordNotFoundException(nameof(MetricsDefinition), id);
                    }
                }
            }
        }

        public async Task<MetricsDefinition> GetMetricsDefinitionByKeyAscyn(string orgId, string key)
        {
            var sql = @"SELECT *
                        FROM metrics_definition
                        WHERE key = @key";

            using (var cn = OpenConnection(orgId))
            using (var cmd = new NpgsqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@key", key);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return ReadResults(reader);
                    }
                    else
                    {
                        throw new RecordNotFoundException(nameof(MetricsDefinition), $"key={key}");
                    }
                }
            }
        }

        public async Task<ListResponse<MetricsDefinitionSummary>> GetMetricsDefinitionsAsync(ListRequest request, string orgId)
        {
            var sql = @$"SELECT id, name, summary, key, icon, categoryName, categoryid, categorykey
                        FROM metrics_definition
                         order by name
                        limit {request.PageSize}
                        offset {request.PageSize * request.PageIndex - 1};";

            
            using (var cn = OpenConnection(orgId))
            using (var cmd = new NpgsqlCommand(sql, cn))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    var results = new List<MetricsDefinitionSummary>();
                    while (reader.Read())
                    {
                        var definition = new MetricsDefinitionSummary()
                        {
                            Id = reader["id"].ToString(),
                            Name = reader["name"].ToString(),
                            Description = reader["description"].ToString(),
                            Key = reader["key"].ToString(),
                            Icon = reader["icon"].ToString(),
                            CategoryId = reader["categoryId"] != DBNull.Value ? reader["categoryId"].ToString() : string.Empty,
                            CategoryKey = reader["categorykey"] != DBNull.Value ? reader["categoryKey"].ToString() : string.Empty,
                            Category = reader["categoryName"] != DBNull.Value ? reader["categoryName"].ToString() : string.Empty,
                        };
                        results.Add(definition);
                    }

                    return ListResponse<MetricsDefinitionSummary>.Create(results, request);             
                }
            }
        }
    }
}
