using LagoVista.Campaigns.Models;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Repos
{
    public class MetricsRepo
    {
        IConnectionSettings _connectionSettings;

        public MetricsRepo(ICampaignConnectionSettings repoSettings)
        {
            _connectionSettings = repoSettings.MetricsStorageConnection;
        }


        protected NpgsqlConnection OpenConnection()
        {
            var connString = $"Host={_connectionSettings.Uri};Username={_connectionSettings.UserName};Password={_connectionSettings.Password};";// ;
            connString += $"Database={_connectionSettings.ResourceName}";

            var conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }

        public async Task AddMetric(KpiMetric metric)
        {
            var insertClause = "insert into KpiMetric(time, span, orgid, org, userid, username, measure, attr1id, attr1, attr2id, attr2, attr3id, attr3, value)";
            var valuesClause = "values (@time, @span, @org, @orgId, @user, @userId, @measure, @attr1id, @attr1, @attr2id, @attr2, @attr3id, @attr3, @value)";

            using (var cn = OpenConnection())
            using (var cmd = new NpgsqlCommand())
            {
                cmd.CommandText = $"{insertClause} {valuesClause}";
                cmd.Parameters.Add(new NpgsqlParameter("@time", DateTime.Parse(metric.TimeStamp)));
                cmd.Parameters.Add(new NpgsqlParameter("@span", "-"));
                cmd.Parameters.Add(new NpgsqlParameter("@org", metric.Org.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@orgId", metric.Org.Id));
                cmd.Parameters.Add(new NpgsqlParameter("@category", metric.Category.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@categoryId", metric.Category.Id));
                cmd.Parameters.Add(new NpgsqlParameter("@metric", metric.Metric.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@metricId", metric.Metric.Id));

                cmd.Parameters.Add(new NpgsqlParameter("@user", EntityHeader.IsNullOrEmpty(metric.User) ? null : metric.User.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@userId", EntityHeader.IsNullOrEmpty(metric.User) ? null : metric.User.Id));

                cmd.Parameters.Add(new NpgsqlParameter("@attr1id", EntityHeader.IsNullOrEmpty(metric.Attr1) ? null : metric.Attr1.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@attr1", EntityHeader.IsNullOrEmpty(metric.Attr1) ? null : metric.Attr1.Id));
                cmd.Parameters.Add(new NpgsqlParameter("@attr2id", EntityHeader.IsNullOrEmpty(metric.Attr2) ? null : metric.Attr2.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@attr2", EntityHeader.IsNullOrEmpty(metric.Attr2) ? null : metric.Attr2.Id));
                cmd.Parameters.Add(new NpgsqlParameter("@attr3id", EntityHeader.IsNullOrEmpty(metric.Attr3) ? null : metric.Attr3.Text));
                cmd.Parameters.Add(new NpgsqlParameter("@attr3", EntityHeader.IsNullOrEmpty(metric.Attr3) ? null : metric.Attr3.Id));

                cmd.Parameters.Add(new NpgsqlParameter("@value", metric.Value));

                var recordCount = await cmd.ExecuteNonQueryAsync();
                if (recordCount != 1)
                    throw new Exception();
            }
        }
    }
}
