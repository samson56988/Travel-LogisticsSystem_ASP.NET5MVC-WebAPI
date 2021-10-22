using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers.StoredGoods
{
    public class StoredGoodsController : Controller
    {
        // GET: StoredGoods
        public async System.Threading.Tasks.Task<ActionResult> StoredGoods()
        {
            //string user = Session["Username"].ToString();

            List<Models.StoredGoods> storedgoods = new List<Models.StoredGoods>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/StoredGoods/GetStoredGoods"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    storedgoods = JsonConvert.DeserializeObject<List<Models.StoredGoods>>(apiResponse);

                }
            }
            return View(storedgoods);
        }
    }
}