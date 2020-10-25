﻿using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repository
{
    public interface IShipperRepository
    {
        Task<IEnumerable<ShipperModel>> GetShipper();

        Task<IEnumerable<ShipperModel>> GetShipper(ShipperModel model);

        Task<int> InsertShipper(ShipperModel model);
        
        Task<int> UpdateShipper(ShipperModel model);

        Task<int> DeleteShipper(int RegionID);
    }
}
