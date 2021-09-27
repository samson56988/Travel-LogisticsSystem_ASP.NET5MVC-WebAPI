using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Models;
namespace UI.Controllers.Consignors
{
    public class ConsigneeController : Controller
    {
        // GET: Consignee
        public async System.Threading.Tasks.Task<ActionResult> Consignee()
        {
            List<Recievers> consignee = new List<Recievers>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/Consignee/GetAllConsignee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    consignee = JsonConvert.DeserializeObject<List<Recievers>>(apiResponse);

                }
            }
            return View(consignee);
        }
    }
}