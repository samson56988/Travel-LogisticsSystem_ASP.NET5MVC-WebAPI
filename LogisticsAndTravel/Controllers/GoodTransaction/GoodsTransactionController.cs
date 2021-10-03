using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic.GoodsTransactionBL;
using System.Web;
using System.Web.SessionState;

namespace LogisticsAndTravel.Controllers.GoodTransaction
{
    public class GoodsTransactionController : ApiController
    {
        private readonly GoodsTransactionRepository transaction = new GoodsTransactionRepository();

        [HttpGet]
        public IEnumerable<Models.GoodTransactions> GetAllGoodsTransaction()
        {
           
            return transaction.GetAllGoodstransaction().ToList();
        }

        [HttpPost]
        public Models.GoodTransactions CreateGoodsTransaction([FromBody] Models.GoodTransactions transactions)
        {
            
            return transaction.InsertNew(transactions);
        }

        
        [HttpDelete]
        public void DeleteGoodsTransaction(int id)
        {
            transaction.Delete(id);
        }
    }
}
