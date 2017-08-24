using Excalibur.Utilities.Core.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excalibur.Utilities.CleverDAL.ADO.Models
{
    public class StorageProcedureProvider : IStorageProcedureProvider
    {
        public string ConnectionString { get; set; }

        public StorageProcedureProvider()
        {
        }

        public object[,] CallStorageProcedure(string storageProcedureName, Dictionary<string, object> parameters)
        {
            var dataSet = CallQueryStorageProcedure(storageProcedureName, parameters);

            if (dataSet.Tables.Count < 0)
                return null;

            var table = dataSet.Tables[0];

            var rowsCount = table.Rows.Count;
            var columnsCount = table.Columns.Count;

            var res = new object[rowsCount, columnsCount];

            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < columnsCount; j++)
                {
                    res[i, j] = table.Rows[i][j];
                }
            }

            return res;
        }

        public StorageProcedureModel GetStorageProcedure(string storageProcedureName)
        {
            var res = new StorageProcedureModel();

            var sqlQuery = GetQueryStorageProcedure(storageProcedureName);

            var storageProceduresDataSet = CallQueryText(sqlQuery);

            if (storageProceduresDataSet.Tables.Count == 0)
            {
                throw new Exception("Don't have any storage procedures in DB");
            }

            var spList = ParseDataSet(storageProceduresDataSet);

            res = spList.First();

            return res;
        }

        public ICollection<StorageProcedureModel> GetStorageProcedureCollection()
        {
            var res = new List<StorageProcedureModel>();

            var sqlQuery = GetQueryStoreageProcedureList();

            var storageProceduresDataSet = CallQueryText(sqlQuery);

            if (storageProceduresDataSet.Tables.Count == 0)
            {
                throw new Exception("Don't have any storage procedures in DB");
            }

            var spList = ParseDataSet(storageProceduresDataSet);

            res = spList.ToList();

            return res;
        }


        private DataSet CallQueryText(string sqlQuery)
        {
            var dataSet = new DataSet();

            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlDataAdapter = new SqlDataAdapter();
            var cmd = new SqlCommand(sqlQuery, sqlConnection);

            cmd.CommandText = sqlQuery;
            sqlDataAdapter.SelectCommand = cmd;

            sqlConnection.Open();
            sqlDataAdapter.Fill(dataSet);
            sqlConnection.Close();

            return dataSet;
        }

        private DataSet CallQueryStorageProcedure(string storageProcedureName, Dictionary<string, object> parameters)
        {
            var dataSet = new DataSet();

            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlDataAdapter = new SqlDataAdapter(storageProcedureName, sqlConnection);

            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            foreach (var prm in parameters)
            {
                sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter(prm.Key, prm.Value));
            }

            sqlDataAdapter.Fill(dataSet);
            sqlConnection.Close();

            return dataSet;
        }

        private ICollection<StorageProcedureModel> ParseDataSet(DataSet ds)
        {
            var res = new List<StorageProcedureModel>();

            var rowsCount = ds.Tables[0].Rows.Count;

            //
            // table return: sp.name, param.name, type.name, type.maxLength
            //
            var storageProcList = new List<Tuple<string, string, string>>();

            for (var i = 0; i < rowsCount; i++)
            {
                var row = ds.Tables[0].Rows[i];

                string name = Convert.ToString(row[0]);

                string param = row[1] is null ? null : Convert.ToString(row[1]);

                string type = row[2] is null ? null : Convert.ToString(row[2]);

                storageProcList.Add(new Tuple<string, string, string>(name, param, type));
            }

            var groupedByStorageProcedureName = storageProcList.GroupBy(x => x.Item1).ToList();

            res = groupedByStorageProcedureName.Select(sp =>
            {
                var item = new StorageProcedureModel()
                {
                    Name = sp.Key,
                    Parameters = new Dictionary<string, string>()
                };

                var prms = sp.Where(x => !string.IsNullOrEmpty(x.Item2));

                foreach (var prm in prms)
                {
                    item.Parameters.Add(prm.Item2, prm.Item3);
                }

                return item;
            }).ToList();

            return res;
        }

        private string GetQueryStoreageProcedureList()
        {
            return
                @"SELECT " +
                    "prs.name, " +
                    "prmnt.name, " +
                    "tps.name, " +
                    "tps.max_length " +
                "FROM sys.procedures prs " +
                "LEFT JOIN sys.parameters prmnt ON prs.object_id = prmnt.object_id " +
                "LEFT JOIN sys.types tps " +
                    "ON prmnt.system_type_id = tps.system_type_id " +
                    "AND prmnt.user_type_id = tps.user_type_id";
        }

        private string GetQueryStorageProcedure(string storageProcedureName)
        {
            return
                string.Format("SELECT " +
                    "prs.name, " +
                    "prmnt.name, " +
                    "tps.name, " +
                    "tps.max_length " +
                "FROM sys.procedures prs " +
                "LEFT JOIN sys.parameters prmnt ON prs.object_id = prmnt.object_id " +
                "LEFT JOIN sys.types tps " +
                    "ON prmnt.system_type_id = tps.system_type_id " +
                    "AND prmnt.user_type_id = tps.user_type_id " +
                "WHERE prs.name = '{0}'", storageProcedureName.Replace("'", "").Replace("\"", ""));
        }
    }
}
