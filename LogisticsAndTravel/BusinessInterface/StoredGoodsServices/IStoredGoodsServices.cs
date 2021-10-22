using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsAndTravel.Models;

namespace LogisticsAndTravel.BusinessInterface.StoredGoodsServices
{
    public interface IStoredGoodsServices
    {
        IList<StoredGoods> GetAllStoredGoods();

        IList<StoredGoods> SearchStoredGoods(string search);

    }
}
