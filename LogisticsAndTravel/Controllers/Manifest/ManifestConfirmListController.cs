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
    public class ManifestConfirmListController : ApiController
    {
        private readonly ManifestRepository manifest = new ManifestRepository();

        [HttpGet]
        public IEnumerable<Models.Manifest> GetAllConfirmManifest()
        {
            return manifest.ConfirmManifest().ToList();
        }
    }
}
