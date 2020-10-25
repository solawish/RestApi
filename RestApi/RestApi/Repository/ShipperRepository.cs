using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<int> DeleteShipper(int RegionID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShipperModel>> GetShipper()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShipperModel>> GetShipper(ShipperModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertShipper(ShipperModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateShipper(ShipperModel model)
        {
            throw new NotImplementedException();
        }
    }
}
