using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic.StoredGoodsBL;

namespace LogisticsAndTravel.Controllers.StoredGoods
{
    public class StoredGoodsController : ApiController
    {
        private readonly StoredGoodsRepository storedgoods = new StoredGoodsRepository();

        [HttpGet]
        public List<Models.StoredGoods> GetStoredGoods()
        {
            return storedgoods.GetAllStoredGoods().ToList();
        }

    }
}
