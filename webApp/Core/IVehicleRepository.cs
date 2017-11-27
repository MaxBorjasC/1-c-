﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApp.Core.Models;

namespace webApp.Core
{

    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
        Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery filter);
    }

}
