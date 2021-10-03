using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic.ConsignorBL;
using System.Web;

namespace LogisticsAndTravel.Controllers.Consignors
{
    public class SearchConsignorsController : ApiController
    {
        private readonly ConsignorRepository consignor = new ConsignorRepository();

        [HttpGet]
        public IEnumerable<Models.Consignors> GetAllConsignor(string search)
        {
            return consignor.SearchConsignor(search).ToList();
        }
    }
}
