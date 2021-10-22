using LogisticsAndTravel.BusinessLogic.ManifestBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
namespace LogisticsAndTravel.Controllers.Manifest
{
    public class ManifestTransactionController : ApiController
    {
        private readonly ManifestRepository manifest = new ManifestRepository();

        [HttpGet]
        public IEnumerable<Models.GoodTransactions> GetTransactionForManifest()
        {
            return manifest.GetAllGoodstransactionForManifest().ToList();
        }
    }
}
