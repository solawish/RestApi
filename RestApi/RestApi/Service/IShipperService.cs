﻿using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Service
{
    public interface IShipperService
    {
        Task<IEnumerable<ShipperModel>> GetShipper();

        Task<IEnumerable<ShipperModel>> GetShipperByID(int ShipperID);

        Task<int> InsertShipper(ShipperModel model);

        Task<int> UpdateShipper(ShipperModel model);

        Task<int> DeleteShipper(int ShipperID);
    }
}
