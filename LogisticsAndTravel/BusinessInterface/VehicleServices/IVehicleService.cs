using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogisticsAndTravel.Models;
using System.Threading.Tasks;


namespace LogisticsAndTravel.BusinessInterface.VehicleServices
{
    public interface IVehicleService
    {
        IList<Vehicle> GetAllVehicle();

        Vehicle InsertNew(Vehicle vehicle);
    }
}
