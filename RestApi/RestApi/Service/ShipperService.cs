using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Model;
using RestApi.Repository;

namespace RestApi.Service
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<int> DeleteShipper(int RegionID)
        {
            return await _shipperRepository.DeleteShipper(RegionID);
        }

        public async Task<IEnumerable<ShipperModel>> GetShipper()
        {
            return await _shipperRepository.GetShipper();
        }

        public async Task<IEnumerable<ShipperModel>> GetShipper(ShipperModel model)
        {
            return await _shipperRepository.GetShipper(model);
        }

        public async Task<int> InsertShipper(ShipperModel model)
        {
            return await _shipperRepository.InsertShipper(model);
        }

        public async Task<int> UpdateShipper(ShipperModel model)
        {
            return await _shipperRepository.UpdateShipper(model);
        }
    }
}
