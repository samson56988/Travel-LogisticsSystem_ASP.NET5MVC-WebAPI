using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace LogisticsAndTravel.Connection
{
    public class ConnectionString
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["TravelandLogistics"].ConnectionString;

        }
    }
}