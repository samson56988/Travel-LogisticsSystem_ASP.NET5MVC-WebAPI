using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessLogic.ConsignorBL;

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
        public IHttpActionResult Login(string username, string password)
        {

            string Message = "Correct Details";
            string Failed = "Failed Details";
            SqlDataReader dr;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from StaffTble where Username = '" + username + "'and Password = '" + password + "'";
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                Message.ToString();
                return Ok(Message);

            }
            else
                return BadRequest(Failed);
        }

        [HttpGet]
        public IEnumerable<Consignors> GetAllConsignor()
        {
            return consignor.GetAllConsignor().ToList();
        }


        [HttpPost]
        public Consignors CreateConsignor([FromBody] Consignors consignors)
        {
            return consignor.InsertNew(consignors);
        }

       

        [HttpPut]
        public Consignors UpdateConsignor([FromBody] Consignors consignors)
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
