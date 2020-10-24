using Dapper;
using DataProvider;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Tests
{
    public class SqlServerUnitTest
    {
        private IDataProvider dataProvider;
        private string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;";
        [SetUp]
        public void Setup()
        {
            dataProvider = new SqlServerDataProvider(ConnectionString);
        }

        [Test]
        public async Task TestMethod_測試Select()
        {
            string sql = @"SELECT TOP (10) * FROM [Northwind].[dbo].[Region]";

            var result = await dataProvider.GetDataModelAsync<Region>(sql, System.Data.CommandType.Text);

            Assert.IsTrue(result.Any());
        }

        [Test]
        public async Task TestMethod_測試Select條件_id為1_結果為Eastern()
        {
            string sql = @"SELECT * FROM [Northwind].[dbo].[Region] 
                           WHERE RegionID = @RegionID ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RegionID", 1, DbType.Int32, ParameterDirection.Input);
            var result = await dataProvider.GetDataModelAsync<Region>(sql, CommandType.Text, parameters);

            Assert.AreEqual(result.FirstOrDefault().RegionDescription.Trim(), "Eastern");
        }

        [Test]
        public async Task TestMethod_測試Scalar()
        {
            string sql = @"SELECT COUNT(0) FROM [Northwind].[dbo].[Region]";

            var result = await dataProvider.ExecuteScalarAsync<int>(sql, CommandType.Text);

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task TestMethod_測試Scalar條件_id為1_結果為Eastern()
        {
            string sql = @"SELECT RegionDescription FROM [Northwind].[dbo].[Region] 
                           WHERE RegionID = @RegionID ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@RegionID", 1, DbType.Int32, ParameterDirection.Input);
            var result = await dataProvider.ExecuteScalarAsync<string>(sql, CommandType.Text, parameters);

            Assert.AreEqual(result.Trim(), "Eastern");
        }

        [Test]
        public async Task TestMethod_測試NonQuery_新增資料()
        {
            string sql = @"INSERT INTO [Northwind].[dbo].[Region] 
                            ([RegionID],[RegionDescription]) VALUES
                            (@RegionID, @RegionDescription) ";

            var parameters = new DynamicParameters(new Region { RegionID = 100, RegionDescription = "NewDesc" });
            var result = await dataProvider.ExecuteNonQueryAsync(sql, CommandType.Text, parameters);

            Assert.NotZero(result);
        }

        [Test]
        public async Task TestMethod_測試Transaction()
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    string sql = @"INSERT INTO [Northwind].[dbo].[Region] 
                            ([RegionID],[RegionDescription]) VALUES
                            (@RegionID, @RegionDescription)";
                    var parameters = new DynamicParameters(new Region { RegionID = 200, RegionDescription = "NewDesc2" });

                    await dataProvider.ExecuteNonQueryAsync(con, trans, sql, CommandType.Text, parameters);

                    trans.Commit();
                }
            }

            string sql2 = @"SELECT RegionDescription FROM [Northwind].[dbo].[Region] 
                           WHERE RegionID = @RegionID ";

            DynamicParameters parameters2 = new DynamicParameters();
            parameters2.Add("@RegionID", 200, DbType.Int32, ParameterDirection.Input);
            var result = await dataProvider.ExecuteScalarAsync<string>(sql2, CommandType.Text, parameters2);

            Assert.AreEqual(result.Trim(), "NewDesc2");
        }

        [TearDown]
        public async Task TearDown()
        {
            string sql = @"DELETE FROM [Northwind].[dbo].[Region] 
                            WHERE RegionID in @RegionID ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.AddDynamicParams(new { RegionID = new List<int> { 100, 200 }.ToArray()});
            await dataProvider.ExecuteNonQueryAsync(sql, CommandType.Text, parameters);
        }
    }
}