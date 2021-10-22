using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers.Vehicle
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public async System.Threading.Tasks.Task<ActionResult> Vehicle()
        {
            List<Models.Vehicle> vehicle = new List<Models.Vehicle>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/Vehicle/GetAllVehicle"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vehicle = JsonConvert.DeserializeObject<List<Models.Vehicle>>(apiResponse);

                }
            }
            return View(vehicle);
        }

        public ActionResult CreateVehicle()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateVehicle(Models.Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:17165/api/Vehicle/CreateVehicle", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        vehicle = JsonConvert.DeserializeObject<Models.Vehicle>(apiResponse);
                    }
                }
                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("Vehicle");
            }

            return View();
        }
    }
}