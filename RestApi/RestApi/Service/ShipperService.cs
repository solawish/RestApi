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

        public async Task<int> DeleteShipper(int ShipperID)
        {
            return await _shipperRepository.DeleteShipper(ShipperID);
        }

        public async Task<IEnumerable<ShipperModel>> GetShipper()
        {
            return await _shipperRepository.GetShipper();
        }

        public async Task<IEnumerable<ShipperModel>> GetShipperByID(int ShipperID)
        {
            return await _shipperRepository.GetShipperByID(ShipperID);
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
