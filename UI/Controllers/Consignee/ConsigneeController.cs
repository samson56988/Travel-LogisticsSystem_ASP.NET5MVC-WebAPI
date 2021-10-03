using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public ActionResult CreateConsignee()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateConsignee(Models.Recievers reciever)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(reciever), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:17165/api/Consignee/CreateConsignee", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reciever = JsonConvert.DeserializeObject<Recievers>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("Consignee");
            }

            return View();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> EditConsignee(int id)
        {
            Models.Recievers reciever = new Recievers();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/EditConsignor/GetConsigneeID?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reciever = JsonConvert.DeserializeObject<Recievers>(apiResponse);

                }
            }
            return View(reciever);
        }



    }
}