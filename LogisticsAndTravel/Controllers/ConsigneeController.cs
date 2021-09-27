using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic.ConsigneeBL;
namespace LogisticsAndTravel.Controllers
{
    public class ConsigneeController : ApiController
    {
        private readonly ConsigneeRepository consignee = new ConsigneeRepository();


        [HttpGet]
        public IEnumerable<Consignee> GetAllConsignee()
        {
            return consignee.GetAllConsignee().ToList();
        }

        [HttpPost]
        public Consignee CreateConsignee([FromBody] Consignee consignees)
        {
            return consignee.InsertNew(consignees);
        }



        [HttpPut]
        public Consignee UpdateConsignee([FromBody] Consignee consignees)
        {
            return consignee.Update(consignees);
        }

        [HttpDelete]
        public void DeleteConsignee(int id)
        {
            consignee.Delete(id);
        }
    }
}
