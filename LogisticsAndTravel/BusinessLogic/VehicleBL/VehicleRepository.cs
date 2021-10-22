using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticsAndTravel.BusinessInterface;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessInterface.VehicleServices;
using System.Data.SqlClient;

namespace LogisticsAndTravel.BusinessLogic.VehicleBL
{
    public class VehicleRepository : IVehicleService
    {
        public IList<Vehicle> GetAllVehicle()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("getVehicles", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleID =  Convert.ToInt32(rdr["VehicleID"].ToString());
                    vehicle.VehicleRegistration = rdr["RegistrationNumber"].ToString();
                    vehicle.Vehiclemodel = rdr["Vehiclemodel"].ToString();
                    vehicle.Color = rdr["color"].ToString();
                    vehicle.Vehiclemakername = rdr["Vehiclemakername"].ToString();
                    vehicle.chesisno = rdr["Chesisno"].ToString();
                    vehicle.insuranceValidUpto = Convert.ToDateTime(rdr["Insurancevalidupto"].ToString());
                    vehicle.permitdetails = rdr["permitdetails"].ToString();
                    vehicle.VehicleType = rdr["VehicleType"].ToString();                
                    vehicles.Add(vehicle);
                }
                rdr.Close();
            }

            return vehicles;
        }

        public Vehicle InsertNew(Vehicle vehicle)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("InsertVehicle", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@RegistrationNumber", vehicle.VehicleRegistration);
                cmd2.Parameters.AddWithValue("@Vehiclemodel ", vehicle.Vehiclemodel);
                cmd2.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd2.Parameters.AddWithValue("@Vehiclemakername", vehicle.Vehiclemakername);
                cmd2.Parameters.AddWithValue("@Chesisno", vehicle.chesisno);
                cmd2.Parameters.AddWithValue("@Insurancevalidupto", vehicle.insuranceValidUpto);
                cmd2.Parameters.AddWithValue("@permitdetails", vehicle.permitdetails);
                cmd2.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            return vehicle;
        }
    }
}