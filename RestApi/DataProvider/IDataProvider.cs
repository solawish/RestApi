using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    interface IDataProvider
    {
        Task<IEnumerable<T>> GetDataModelAsync<T>(string commandText, CommandType commandType);
        Task<IEnumerable<T>> GetDataModelAsync<T>(string commandText, CommandType commandType, DynamicParameters commandParameters);
        Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType);
        Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, DynamicParameters commandParameters);
        Task<int> ExecuteNonQueryAsync(IDbConnection dbConnection, IDbTransaction dbTransaction, string commandText, CommandType commandType);
        Task<int> ExecuteNonQueryAsync(IDbConnection dbConnection, IDbTransaction dbTransaction, string commandText, CommandType commandType, DynamicParameters commandParameters);
        Task<T> ExecuteScalarAsync<T>(string commandText, CommandType commandType);
        Task<T> ExecuteScalarAsync<T>(string commandText, CommandType commandType, DynamicParameters commandParameters);
    }
}
