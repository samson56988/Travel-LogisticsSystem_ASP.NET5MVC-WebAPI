using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic.ManifestBL;

namespace LogisticsAndTravel.Controllers.Manifest
{
    public class GetTransactionForManifestController : ApiController
    {
        private readonly ManifestRepository manifest = new ManifestRepository();

        [HttpGet]
        public Models.GoodTransactions TransactionID(int id)
        {
            return manifest.GetTransactionByID(id);
        }

    }
}
