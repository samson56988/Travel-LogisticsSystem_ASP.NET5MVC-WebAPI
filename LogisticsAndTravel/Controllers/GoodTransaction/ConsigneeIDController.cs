using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.BusinessLogic.GoodsTransactionBL;
using LogisticsAndTravel.Models;

namespace LogisticsAndTravel.Controllers.GoodTransaction
{
    public class ConsigneeIDController : ApiController
    {
        private readonly GoodsTransactionRepository transaction = new GoodsTransactionRepository();

        [HttpGet]
        public List<ConsigneeID> PopulateConsignee()
        {
            return transaction.PopulateConsignee().ToList();
        }
    }
}
