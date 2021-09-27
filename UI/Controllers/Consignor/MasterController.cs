using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers.Master
{
    public class MasterController : Controller
    {
        // GET: Master
        public async System.Threading.Tasks.Task<ActionResult> Consignors()
        {
            List<Consignor> consignor = new List<Consignor>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/Master/GetAllConsignor"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    consignor = JsonConvert.DeserializeObject<List<Consignor>>(apiResponse);

                }
            }
            return View(consignor);
        }

        public ActionResult CreateConsignor()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateConsignor(Models.Consignor consignor)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(consignor), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:17165/api/Master/CreateConsignor", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        consignor = JsonConvert.DeserializeObject<Consignor>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("Consignors");
            }

            return View();
        }


        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> EditConsignor(int id)
        {
            Models.Consignor consignor = new Consignor();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/Consignor/GetConsignorID?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    consignor = JsonConvert.DeserializeObject<Consignor>(apiResponse);

                }
            }
            return View(consignor);
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> EditConsignor(Models.Consignor consignor)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(consignor), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("http://localhost:17165/api/Master/UpdateConsignor", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        consignor = JsonConvert.DeserializeObject<Consignor>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("Consignors");
            }
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> DeleteConsignor(int id)
        {
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.DeleteAsync("http://localhost:17165/api/Master/DeleteConsignor?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }

            return RedirectToAction("Consignors");
        }
    }
}