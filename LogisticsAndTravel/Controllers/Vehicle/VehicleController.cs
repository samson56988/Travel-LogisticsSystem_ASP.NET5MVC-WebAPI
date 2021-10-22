using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.BusinessLogic.VehicleBL;
using LogisticsAndTravel.Models;

namespace LogisticsAndTravel.Controllers.Vehicle
{
    public class VehicleController : ApiController
    {
        private readonly VehicleRepository vehicle = new VehicleRepository();

        [HttpGet]
        public IEnumerable<Models.Vehicle> GetAllVehicle()
        {
            return vehicle.GetAllVehicle().ToList();
        }

        [HttpPost]
        public Models.Vehicle CreateVehicle([FromBody] Models.Vehicle vehicles)
        {
            return vehicle.InsertNew(vehicles);
        }
    }
}
