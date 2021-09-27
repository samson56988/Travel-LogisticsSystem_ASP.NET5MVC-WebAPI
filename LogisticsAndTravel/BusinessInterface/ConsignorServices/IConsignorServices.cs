using LogisticsAndTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndTravel.BusinessInterface.ConsignorServices
{
    public interface IConsignorServices
    {
        IList<Consignors> GetAllConsignor();

        Consignors ConsignorByID(int id);

        Consignors InsertNew(Consignors consignor);

        Consignors Update(Consignors consignor);

        void Delete(int id);
    }
}
