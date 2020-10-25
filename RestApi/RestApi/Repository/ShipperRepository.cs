using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataProvider;
using RestApi.Model;

namespace RestApi.Repository
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly IDataProvider _dataProvider;

        public ShipperRepository(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<int> DeleteShipper(int ShipperID)
        {
            string sql = @"DELETE FROM [Northwind].[dbo].[Shipper] 
                           WHERE ShipperID = @ShipperID ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ShipperID", ShipperID, DbType.Int32, ParameterDirection.Input);
            var result = await _dataProvider.ExecuteNonQueryAsync(sql, CommandType.Text, parameters);
            return result;
        }

        public async Task<IEnumerable<ShipperModel>> GetShipper()
        {
            string sql = @"SELECT * FROM [Northwind].[dbo].[Shipper]";
                        
            var result = await _dataProvider.GetDataModelAsync<ShipperModel>(sql, CommandType.Text);
            return result;
        }

        public async Task<IEnumerable<ShipperModel>> GetShipperByID(int ShipperID)
        {
            string sql = @"SELECT * FROM [Northwind].[dbo].[Shipper] 
                           WHERE ShipperID = @ShipperID ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ShipperID", ShipperID, DbType.Int32, ParameterDirection.Input);
            var result = await _dataProvider.GetDataModelAsync<ShipperModel>(sql, CommandType.Text, parameters);
            return result;
        }

        public async Task<int> InsertShipper(ShipperModel model)
        {
            string sql = @"INSERT INTO [Northwind].[dbo].[Shipper] 
                            ([CompanyName],[Phone]) VALUES
                            (@CompanyName, @Phone) ";

            var parameters = new DynamicParameters(model);
            var result = await _dataProvider.ExecuteNonQueryAsync(sql, CommandType.Text, parameters);
            return result;
        }

        public async Task<int> UpdateShipper(ShipperModel model)
        {
            string sql = @"UPDATE [Northwind].[dbo].[Shipper] 
                            SET [CompanyName] = @CompanyName, [Phone] = @Phone
                            WHERE [ShipperID] = @ShipperID";

            var parameters = new DynamicParameters(model);
            var result = await _dataProvider.ExecuteNonQueryAsync(sql, CommandType.Text, parameters);
            return result;
        }
    }
}
