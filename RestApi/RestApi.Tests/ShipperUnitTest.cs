using DataProvider;
using NUnit.Framework;
using RestApi.Model;
using RestApi.Repository;
using RestApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Tests
{
    public class ShipperUnitTest
    {
        private IDataProvider dataProvider;
        private IShipperRepository shipperRepository;
        private IShipperService shipperService;
        private string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;";

        [SetUp]
        public void Setup()
        {
            dataProvider = new SqlServerDataProvider(ConnectionString);
            shipperRepository = new ShipperRepository(dataProvider);
            shipperService = new ShipperService(shipperRepository);


        }

        [Test]
        public async Task TestMethod_測試GetShipper()
        {
            var result = await shipperService.GetShipper();

            Assert.IsTrue(result.Any());
        }

        [Test]
        public async Task TestMethod_測試GetShipperByID()
        {
            var ShipperID = 1;

            var result = await shipperService.GetShipperByID(ShipperID);

            Assert.IsTrue(result.Any());
        }

        [Test]
        public async Task TestMethod_測試InsertShipper()
        {
            var ShipperID = new ShipperModel { CompanyName = "Fragile", Phone = "(503) 555-9000" };

            var result = await shipperService.InsertShipper(ShipperID);

            Assert.AreEqual(result, 1);
        }

        [Test]
        public async Task TestMethod_測試UpdateShipper()
        {
            var ShipperID = await GetMaxId();
            var RandomTel = DateTime.Now.ToString("hhmmss");
            var Shipper = new ShipperModel { ShipperID = ShipperID, CompanyName = "Fragile", Phone = RandomTel};

            var result = await shipperService.UpdateShipper(Shipper);

            var GetResult = await shipperService.GetShipperByID(ShipperID);

            Assert.AreEqual(GetResult.FirstOrDefault().Phone, RandomTel);
        }

        [Test]
        public async Task TestMethod_測試DeleteShipper()
        {
            var ShipperID = await GetMaxId();

            var result = await shipperService.DeleteShipper(ShipperID);

            Assert.AreEqual(result, 1);
        }

        public async Task<int> GetMaxId()
        {
            string sql = @"SELECT Max([ShipperID]) FROM [Northwind].[dbo].[Shippers]";

            var result = await dataProvider.ExecuteScalarAsync<int>(sql, System.Data.CommandType.Text);

            return result;
        }
    }
}
