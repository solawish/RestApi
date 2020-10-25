using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataProvider
{
    public class SqlServerDataProvider : IDataProvider
    {
        private string _connectionString;

        public SqlServerDataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType)
        {
            using (IDbConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                return await con.ExecuteAsync(commandText, null, null, null, commandType);
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, DynamicParameters commandParameters)
        {
            using (IDbConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                return await con.ExecuteAsync(commandText, commandParameters, null, null, commandType);
            }
        }

        public async Task<int> ExecuteNonQueryAsync(IDbConnection dbConnection, IDbTransaction dbTransaction, string commandText, CommandType commandType)
        {
            return await dbConnection.ExecuteAsync(commandText, null, dbTransaction, null, commandType);
        }

        public async Task<int> ExecuteNonQueryAsync(IDbConnection dbConnection, IDbTransaction dbTransaction, string commandText, CommandType commandType, DynamicParameters commandParameters)
        {
            return await dbConnection.ExecuteAsync(commandText, commandParameters, dbTransaction, null, commandType);
        }

        public async Task<T> ExecuteScalarAsync<T>(string commandText, CommandType commandType)
        {
            using (IDbConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                return await con.ExecuteScalarAsync<T>(commandText, null, null, null, commandType);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string commandText, CommandType commandType, DynamicParameters commandParameters)
        {
            using (IDbConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                return await con.ExecuteScalarAsync<T>(commandText, commandParameters, null, null, commandType);
            }
        }

        public async Task<IEnumerable<T>> GetDataModelAsync<T>(string commandText, CommandType commandType)
        {
            using (IDbConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                return await con.QueryAsync<T>(commandText, null, null, null, commandType);
            }
        }

        public async Task<IEnumerable<T>> GetDataModelAsync<T>(string commandText, CommandType commandType, DynamicParameters commandParameters)
        {
            using (IDbConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                return await con.QueryAsync<T>(commandText, commandParameters, null, null, commandType);
            }
        }
    }
}
