using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsAndTravel.Models;

namespace LogisticsAndTravel.BusinessInterface.ConsignmentService
{
    public interface IConsignmentService
    {
        IList<ConsignmentSummary> GetAllConsigmentSummary();

        ConsignmentSummary InsertNew(ConsignmentSummary consignorsummary);

        ConsignmentSummary GoodstransactionByID(int id);
    }
}
