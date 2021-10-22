using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticsAndTravel.Models
{
    public class Driver
    {
        public int DriverID { get; set; }

        public string Fullname { get; set; }

        public int Age { get; set; }

        public string Nationality { get; set; }

        public string MaritalStatus { get; set; }
    }
}