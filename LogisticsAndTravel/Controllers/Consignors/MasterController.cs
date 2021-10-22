using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic.ConsignorBL;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace LogisticsAndTravel.Controllers
{
    public class MasterController : ApiController
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = Connection.ConnectionString.GetConnection();
        }
        private readonly ConsignorRepository consignor = new ConsignorRepository();

        [HttpGet]
        public IHttpActionResult Login(string username, string password,string branch)
        {
            
            string Message = "Correct Details";
            string Failed = "Failed Details";
            SqlDataReader dr;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from StaffTbl where Username = '" + username + "'and Password = '" + password + "' and Branch = '"+branch+"'";
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                FormsAuthentication.SetAuthCookie(username, true);
                
                //HttpContext.Current.Session["Username"] = username.ToString();

                var session = HttpContext.Current.Session;
                if (session != null)
                {
                    if (session["Username"] == null)
                    {
                        session["Username"] = username.ToString();

                        var users = session["Username"].ToString();
                    }
                }


                string user = HttpContext.Current.Session["Username"].ToString();

                Message.ToString();
                return Ok(Message);

            }
            else
                return BadRequest(Failed);
        }

        [HttpGet]
        public IEnumerable<Models.Consignors> GetAllConsignor()
        {
            return consignor.GetAllConsignor().ToList();
        }
        [HttpPost]
        public Models.Consignors CreateConsignor([FromBody] Models.Consignors consignors)
        {      
            return consignor.InsertNew(consignors);
        }     
        [HttpPut]
        public Models.Consignors UpdateConsignor([FromBody] Models.Consignors consignors)
        {
            return consignor.Update(consignors);
        }
        [HttpDelete]
        public void DeleteConsignor(int id)
        {
            consignor.Delete(id);
        }
    }
}
