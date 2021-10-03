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
        public IEnumerable<Models.Consignee> GetAllConsignee()
        {
            return consignee.GetAllConsignee().ToList();
        }

        [HttpPost]
        public Models.Consignee CreateConsignee([FromBody] Models.Consignee consignees)
        {
            return consignee.InsertNew(consignees);
        }

        
        
        

        [HttpPut]
        public Models.Consignee UpdateConsignee([FromBody] Models.Consignee consignees)
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
