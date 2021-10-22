using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }

        public string VehicleRegistration { get; set; }

        public string Vehiclemodel { get; set; }

        public string Color { get; set; }

        public string Vehiclemakername { get; set; }

        public string chesisno { get; set; }

        public DateTime insuranceValidUpto { get; set; }

        public string permitdetails { get; set; }

        public string VehicleType { get; set; }
    }
}