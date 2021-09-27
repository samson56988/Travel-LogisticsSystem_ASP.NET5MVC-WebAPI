using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsAndTravel.Models;


namespace LogisticsAndTravel.BusinessInterface.ConsigneeServices
{
    public interface IConsigneeServices
    {
        IList<Consignee> GetAllConsignee();

        Consignee ConsigneeID(int id);

        Consignee InsertNew(Consignee consignee);

        Consignee Update(Consignee consignee);

        void Delete(int id);
    }
}
