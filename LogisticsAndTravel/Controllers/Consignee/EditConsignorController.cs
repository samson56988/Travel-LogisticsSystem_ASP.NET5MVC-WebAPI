using LogisticsAndTravel.BusinessLogic.ConsigneeBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogisticsAndTravel.Controllers.Consignee
{
    public class EditConsignorController : ApiController
    {
        private readonly ConsigneeRepository consignee = new ConsigneeRepository();

        public Models.Consignee GetConsigneeID(int id)
        {
            return consignee.ConsigneeID(id);
        }
    }
}
