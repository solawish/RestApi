using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataProvider
{
    public class SqlServerDataProvider : IDataProvider
    {
        private string connectionString;

        public SqlServerDataProvider(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:SqlServer"];
        }

        public Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.ExecuteAsync(commandText, null, null, null, commandType);
            }
        }

        public Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, DynamicParameters commandParameters)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                return con.ExecuteAsync(commandText, commandParameters, null, null, commandType);
            }
        }

        public Task<int> ExecuteNonQueryAsync(IDbConnection dbConnection, IDbTransaction dbTransaction, string commandText, CommandType commandType)
        {
            return dbConnection.ExecuteAsync(commandText, null, dbTransaction, null, commandType);
        }

        public Task<int> ExecuteNonQueryAsync(IDbConnection dbConnection, IDbTransaction dbTransaction, string commandText, CommandType commandType, DynamicParameters commandParameters)
        {
            return dbConnection.ExecuteAsync(commandText, commandParameters, dbTransaction, null, commandType);
        }

        public Task<T> ExecuteScalarAsync<T>(string commandText, CommandType commandType)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.ExecuteScalarAsync<T>(commandText, null, null, null, commandType);
            }
        }

        public Task<T> ExecuteScalarAsync<T>(string commandText, CommandType commandType, DynamicParameters commandParameters)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.ExecuteScalarAsync<T>(commandText, commandParameters, null, null, commandType);
            }
        }

        public Task<IEnumerable<T>> GetDataModelAsync<T>(string commandText, CommandType commandType)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.QueryAsync<T>(commandText, null, null, null, commandType);
            }
        }

        public Task<IEnumerable<T>> GetDataModelAsync<T>(string commandText, CommandType commandType, DynamicParameters commandParameters)
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.QueryAsync<T>(commandText, commandParameters, null, null, commandType);
            }
        }
    }
}
