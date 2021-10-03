using LogisticsAndTravel.BusinessLogic.GoodsTransactionBL;
using LogisticsAndTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogisticsAndTravel.Controllers.GoodTransaction
{
    public class GoodsTransactController : ApiController
    {
        private readonly GoodsTransactionRepository transaction = new GoodsTransactionRepository();

        [HttpGet]
        public List<ConsignorID> PopulateConsignor()
        {
            return transaction.PopulateConsignor().ToList();
        }

        

    }
}
