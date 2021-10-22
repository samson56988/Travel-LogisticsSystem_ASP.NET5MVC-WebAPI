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
    public class ConfirmManifestTransactionController : ApiController
    {
        private readonly ManifestRepository manifest = new ManifestRepository();


        [HttpPost]
        public Models.Manifest ConfirmManifestList([FromBody] Models.Manifest manifests)
        {
            return manifest.ConfirmManifest(manifests);
        }

    }
}
