using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Login(Login log)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:17165/api/Master/");
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
            var consumedata = await hc.GetAsync("Login?username=" + log.username + "&password=" + log.password+"&branch="+log.branch);


            if (consumedata.IsSuccessStatusCode)
            {
                var resultMessage = consumedata.Content.ReadAsStringAsync().Result;
                Session["Username"] = log.username.ToString();
                Session["Branch"] = log.branch.ToString();
                return RedirectToAction("Consignors", "Master");

                
            }

            return View();
        }
    }
}