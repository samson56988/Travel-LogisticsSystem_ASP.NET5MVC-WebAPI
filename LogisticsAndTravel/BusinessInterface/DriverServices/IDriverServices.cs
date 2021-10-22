using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsAndTravel.Models;

namespace LogisticsAndTravel.BusinessInterface.DriverServices
{
    public interface IDriverServices
    {
        IList<Driver> GetAllDriver();

        Driver Insertnew(Driver driver);
    }
}
