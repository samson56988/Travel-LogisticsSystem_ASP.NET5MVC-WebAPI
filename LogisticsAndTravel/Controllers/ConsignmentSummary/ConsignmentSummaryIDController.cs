using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic;
using LogisticsAndTravel.BusinessLogic.GoodsSummaryBL;

namespace LogisticsAndTravel.Controllers.ConsignmentSummary
{
    public class ConsignmentSummaryIDController : ApiController
    {
        private readonly GoodsSummaryBL goods = new GoodsSummaryBL();

        [HttpGet]
        public Models.ConsignmentSummary GetconsignmentID(int id)
        {
            return goods.GoodstransactionByID(id);
        }
    }
}
