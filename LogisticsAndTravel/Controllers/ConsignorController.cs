using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic.ConsignorBL;
namespace LogisticsAndTravel.Controllers
{
    public class ConsignorController : ApiController
    {
        private readonly ConsignorRepository consignor = new ConsignorRepository();

        [HttpGet]
        public Consignors GetConsignorID(int id)
        {
            return consignor.ConsignorByID(id);
        }
    }
}
