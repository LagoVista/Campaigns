using LagoVista.Campaigns.Models;
using LagoVista.Core;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace LagoVista.Campaigns.Repos
{
    public class MetricsRepo
    {
        IConnectionSettings _connectionSettings;

        public MetricsRepo(IMetricStorageConnectionSettings repoSettings)
        {
            _connectionSettings = repoSettings.MetricsStorageDBConenction;
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
            var insertClause = "insert into Metrics(time, span, orgid, org, userid, username, categoryid, category, metric, metricid, attr1id, attr1, attr2id, attr2, attr3id, attr3, value)";
            var valuesClause = $"values (@time, @span, @org, @orgId, @user, @userId, @categoryId, @category, @metric, @metricid, @attr1id,   @attr1, @attr2id, @attr2, @attr3id, @attr3, @value)";

            var span = "-";
            switch(metric.Period)
            {
                case KpiPeriod.Month: span = "M"; break;
                case KpiPeriod.Day: span = "D"; break;
                case KpiPeriod.Hour: span = "H"; break;
                case KpiPeriod.Week: span = "W"; break;
            }

            using (var cn = OpenConnection())
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

                cmd.Parameters.Add(new NpgsqlParameter("@value", metric.Value));

                var recordCount = await cmd.ExecuteNonQueryAsync();
                if (recordCount != 1)
                    throw new Exception();
            }
        }
    }
}
