using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers.Manifest
{
    public class ManifestController : Controller
    {
        // GET: Manifest
        public async System.Threading.Tasks.Task<ActionResult> Manifest()
        {
            List<Models.Manifest> manifest = new List<Models.Manifest>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/Manifest/GetAllManifest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   manifest  = JsonConvert.DeserializeObject<List<Models.Manifest>>(apiResponse);

                }
            }
            return View(manifest);
        }


        public async System.Threading.Tasks.Task<ActionResult> GetAllTransactionForManifest()
        {
            List<Models.GoodsTransactions> transaction = new List<GoodsTransactions>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/ManifestTransaction/GetTransactionForManifest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    transaction = JsonConvert.DeserializeObject<List<GoodsTransactions>>(apiResponse);

                }
            }
            return View(transaction);
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> AddToManifest(int id)
        {
            Models.GoodsTransactions transaction = new GoodsTransactions();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/GetTransactionForManifest/TransactionID?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    transaction = JsonConvert.DeserializeObject<Models.GoodsTransactions>(apiResponse);

                }
            }
            return View(transaction);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> AddToManifest(GoodsTransactions transaction)
        {
            if (ModelState.IsValid)
            {     
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(transaction), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:17165/api/Manifest/AddtoManifest", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        transaction = JsonConvert.DeserializeObject<GoodsTransactions>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("GetAllTransactionForManifest");
            }

            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> ManifestConfirmList()
        {
            List<Models.Manifest> manifest = new List<Models.Manifest>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/ManifestConfirmList/GetAllConfirmManifest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    manifest = JsonConvert.DeserializeObject<List<Models.Manifest>>(apiResponse);

                }
            }
            return View(manifest);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> ManifestConfirmList(Models.Manifest manifest)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(manifest), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:17165/api/ConfirmManifestTransaction/ConfirmManifestList", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        manifest = JsonConvert.DeserializeObject<Models.Manifest>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("Manifest");
            }

            return View();
        }

    }
}