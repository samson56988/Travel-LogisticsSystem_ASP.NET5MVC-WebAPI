using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers.GoodsTransaction
{
    public class GoodTransactionController : Controller
    {

        string ConsignorDropdown;
        // GET: GoodTransaction
        public async System.Threading.Tasks.Task<ActionResult> GoodTransactions()
        {
            //string user = Session["Username"].ToString();

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

        //public async System.Threading.Tasks.Task<List<ConsignorID>> PopulateConsignor()
        //{
        //    List<Models.ConsignorID> consignor = null;
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("http://localhost:17165/api/GoodsTransact/PopulateConsignor"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            consignor = JsonConvert.DeserializeObject<List<ConsignorID>>(apiResponse);
        //            ViewBag.Consignor = consignor;
        //        }
        //    }
        //    return consignor;
        //}

        //public async System.Threading.Tasks.Task<List<GoodsTransactions>> PopulateConsignee()
        //{
        //    List<Models.GoodsTransactions> transaction = new List<GoodsTransactions>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("http://localhost:17165/api/ConsigneeID/PopulateConsignee"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            transaction = JsonConvert.DeserializeObject<List<GoodsTransactions>>(apiResponse);

        //        }
        //    }
        //    return transaction;
        //}
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> CreateTransaction()
        {
            List<Models.ConsignorID> consignor = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/GoodsTransact/PopulateConsignor"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    consignor = JsonConvert.DeserializeObject<List<ConsignorID>>(apiResponse);
                    ViewBag.Consignor = consignor;
                }
            }

            List<Models.ConsigneeID> consignee = new List<ConsigneeID>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:17165/api/ConsigneeID/PopulateConsignee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    consignee = JsonConvert.DeserializeObject<List<ConsigneeID>>(apiResponse);
                    ViewBag.Consignee = consignee;

                }
            }
            //ViewBag.Consignor = PopulateConsignor(); ;
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateTransaction(Models.GoodsTransactions transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.StaffID = Session["Username"].ToString();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(transaction), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:17165/api/GoodsTransaction/CreateGoodsTransaction", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        transaction = JsonConvert.DeserializeObject<GoodsTransactions>(apiResponse);

                    }
                }

                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("GoodTransactions");
            }

            return View();
        }



    }
}