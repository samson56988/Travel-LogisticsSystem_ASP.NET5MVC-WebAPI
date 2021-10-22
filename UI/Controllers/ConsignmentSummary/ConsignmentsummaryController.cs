using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers.ConsignmentSummary
{
    public class ConsignmentsummaryController : Controller
    {
        // GET: Consignmentsummary
        public async System.Threading.Tasks.Task<ActionResult> GetAllConsignmentDetails()
        {
            List<Models.ConsignmentSummary> consignment = new List<Models.ConsignmentSummary>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/ConsignmentSummary/GetAllConsignment"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    consignment = JsonConvert.DeserializeObject<List<Models.ConsignmentSummary>>(apiResponse);

                }
            }
            return View(consignment);
        }

        public async System.Threading.Tasks.Task<ActionResult> GetAllTransaction()
        {
            List<Models.GoodsTransactions> transaction = new List<GoodsTransactions>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/GoodsTransaction/GetAllGoodsTransaction"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    transaction = JsonConvert.DeserializeObject<List<GoodsTransactions>>(apiResponse);

                }
            }
            return View(transaction);
        }

        public async System.Threading.Tasks.Task<ActionResult> AddConsignmentsummary(int id)
        {
            Models.ConsignmentSummary consignment = new Models.ConsignmentSummary();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/ConsignmentSummaryID/GetconsignmentID?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   consignment = JsonConvert.DeserializeObject<Models.ConsignmentSummary>(apiResponse);

                }
            }
            return View(consignment);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> AddConsignmentsummary(Models.ConsignmentSummary summary)
        {
            if (ModelState.IsValid)
            {
                summary.branch = Session["Branch"].ToString();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(summary), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:17165/api/ConsignmentSummary/CreateConsignmentsummary", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        summary = JsonConvert.DeserializeObject<Models.ConsignmentSummary>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("GetAllConsignmentDetails");
            }

            return View();
        }


    }
}