using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticsAndTravel.BusinessInterface.ConsignorServices;
using LogisticsAndTravel.Connection;
using LogisticsAndTravel.Models;
using System.Data.SqlClient;
using System.Data;

namespace LogisticsAndTravel.BusinessLogic.ConsignorBL
{
    public class ConsignorRepository : IConsignorServices
    {
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("Deleteconsignor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@consignorID", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public IList<Consignors> GetAllConsignor()
        {
            List<Consignors> consignors = new List<Consignors>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetConsignor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Consignors consignor = new Consignors();
                    consignor.ConsignorID = Convert.ToInt32(rdr["ConsignorID"].ToString());
                    consignor.Name = rdr["Name"].ToString();
                    consignor.Address1 = rdr["Address1"].ToString();
                    consignor.Address2 = rdr["Address2"].ToString();
                    consignor.State = rdr["State"].ToString();
                    consignor.City = rdr["City"].ToString();
                    consignor.Pincode = Convert.ToInt32(rdr["PinCode"].ToString());
                    consignor.MobileNo = rdr["MobileNo"].ToString();
                    consignor.Email = rdr["Email"].ToString();
                    consignor.ConsignorGst = rdr["ConsignorGst"].ToString();
                    consignors.Add(consignor);
                }
                rdr.Close();
            }

            return consignors;
        }

        public Consignors ConsignorByID(int id)
        {
            Consignors consignor = new Consignors();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetConsignorID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    consignor.ConsignorID = Convert.ToInt32(rdr["ConsignorID"].ToString());
                    consignor.Name = rdr["Name"].ToString();
                    consignor.Address1 = rdr["Address1"].ToString();
                    consignor.Address2 = rdr["Address2"].ToString();
                    consignor.State = rdr["State"].ToString();
                    consignor.City = rdr["City"].ToString();
                    consignor.Pincode = Convert.ToInt32(rdr["PinCode"].ToString());
                    consignor.MobileNo = rdr["MobileNo"].ToString();
                    consignor.Email = rdr["Email"].ToString();
                    consignor.ConsignorGst = rdr["ConsignorGst"].ToString();

                }
                rdr.Close();
            }

            return consignor;
        }

        public Consignors InsertNew(Consignors consignor)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
               
                con.Open();
                SqlCommand cmd2 = new SqlCommand("InsertConsignor", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Name", consignor.Name);
                cmd2.Parameters.AddWithValue("@Address1", consignor.Address1);
                cmd2.Parameters.AddWithValue("@Address2", consignor.Address2);
                cmd2.Parameters.AddWithValue("@State", consignor.State);
                cmd2.Parameters.AddWithValue("@City", consignor.City);
                cmd2.Parameters.AddWithValue("@Pincode", consignor.Pincode);
                cmd2.Parameters.AddWithValue("@Mobileno", consignor.MobileNo);
                cmd2.Parameters.AddWithValue("@Email", consignor.Email);
                cmd2.Parameters.AddWithValue("@ConsignorGST", consignor.ConsignorGst);
                cmd2.ExecuteNonQuery();

                con.Close();
            }

            return consignor;
        }

        public Consignors Update(Consignors consignor)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateConsignor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ConsignorID", consignor.ConsignorID);
                cmd.Parameters.AddWithValue("@Name", consignor.Name);
                cmd.Parameters.AddWithValue("@Address1", consignor.Address1);
                cmd.Parameters.AddWithValue("@Address2", consignor.Address2);
                cmd.Parameters.AddWithValue("@State", consignor.State);
                cmd.Parameters.AddWithValue("@City", consignor.City);
                cmd.Parameters.AddWithValue("@Pincode", consignor.Pincode);
                cmd.Parameters.AddWithValue("@Mobileno", consignor.MobileNo);
                cmd.Parameters.AddWithValue("@Email", consignor.Email);
                cmd.Parameters.AddWithValue("@ConsignorGST", consignor.ConsignorGst);
                cmd.ExecuteNonQuery();

                con.Close();
            }

            return consignor;
        }
    }

}
