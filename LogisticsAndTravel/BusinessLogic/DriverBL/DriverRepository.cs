using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticsAndTravel.BusinessInterface.DriverServices;
using LogisticsAndTravel.Models;
using System.Data.SqlClient;

namespace LogisticsAndTravel.BusinessLogic.DriverBL
{
    public class DriverRepository : IDriverServices
    {
        public IList<Driver> GetAllDriver()
        {
            List<Driver> drivers = new List<Driver>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("getDriver", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Driver driver = new Driver();
                    driver.DriverID = Convert.ToInt32(rdr["DriverID"].ToString());
                    driver.Fullname = rdr["Fullname"].ToString();
                    drivers.Add(driver);
                }
                rdr.Close();
            }

            return drivers;
        }

        public Driver Insertnew(Driver driver)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("InsertDriver", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Fullname", driver.Fullname);
                cmd2.Parameters.AddWithValue("@Age", driver.Age);
                cmd2.Parameters.AddWithValue("@Nationality", driver.Nationality);
                cmd2.Parameters.AddWithValue("@MaritalStatus", driver.MaritalStatus);
                cmd2.ExecuteNonQuery();
                con.Close();
            }

            return driver;
        }
    }
}