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
    public class ConsignmentSummaryController : ApiController
    {
        private readonly GoodsSummaryBL goods = new GoodsSummaryBL();

         [HttpGet]
        public IEnumerable<Models.ConsignmentSummary> GetAllConsignment()
        {
            return goods.GetAllConsigmentSummary().ToList();
        }

        [HttpPost]
        public Models.ConsignmentSummary CreateConsignmentsummary([FromBody] Models.ConsignmentSummary consignments)
        {
            return goods.InsertNew(consignments);
        }

        //


    }
}
