using LogisticsAndTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsAndTravel.BusinessInterface.GoodsTransactionServices
{
    public interface IGoodTransactionServices
    {
        IList<GoodTransactions> GetAllGoodstransaction();

        int GoodstransactionByID(int id);

        GoodTransactions InsertNew(GoodTransactions goods);

        GoodTransactions Update(GoodTransactions goods);

        List<ConsignorID> PopulateConsignor();

        List<ConsigneeID> PopulateConsignee();

        void Delete(int id);
    }
}
