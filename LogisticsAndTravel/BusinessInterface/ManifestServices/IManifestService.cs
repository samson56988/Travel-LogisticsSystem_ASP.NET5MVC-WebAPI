using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsAndTravel.Models;

namespace LogisticsAndTravel.BusinessInterface.ManifestServices
{
    public interface IManifestService
    {
        IList<Manifest> GetAllManifest();

        GoodTransactions GetTransactionByID(int id);

        GoodTransactions Insert(GoodTransactions goods);

        IList<Manifest> ConfirmManifest();

        Manifest ConfirmManifest(Manifest manifest);

        IList<GoodTransactions> GetAllGoodstransactionForManifest();
    }
}
