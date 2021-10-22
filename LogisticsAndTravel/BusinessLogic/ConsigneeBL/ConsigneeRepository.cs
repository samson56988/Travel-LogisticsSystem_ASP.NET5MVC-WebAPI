using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessInterface.ConsigneeServices;
using System.Data.SqlClient;

namespace LogisticsAndTravel.BusinessLogic.ConsigneeBL
{
    public class ConsigneeRepository : IConsigneeServices
    {
        public Consignee ConsigneeID(int id)
        {
            Consignee consignee = new Consignee();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("getConsigneeID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ConsigneeID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    consignee.ConsigneeID = Convert.ToInt32(rdr["ConsigneeID"].ToString());
                    consignee.Name = rdr["ConsigneeName"].ToString();
                    consignee.Address1 = rdr["Address1"].ToString();
                    consignee.Address2 = rdr["Address2"].ToString();
                    consignee.State = rdr["State"].ToString();
                    consignee.City = rdr["City"].ToString();
                    consignee.Pincode = Convert.ToInt32(rdr["PinCode"].ToString());
                    consignee.MobileNo = rdr["MobileNo"].ToString();
                    consignee.Email = rdr["Email"].ToString();
                    consignee.ConsignorGst = rdr["ConsigneeGst"].ToString();

                }
                rdr.Close();
            }

            return consignee;
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("DeleteConsignee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ConsigneeID", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public IList<Consignee> GetAllConsignee()
        {
            List<Consignee> consignees = new List<Consignee>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("getConsignee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Consignee consignee = new Consignee();
                    consignee.ConsigneeID = Convert.ToInt32(rdr["ConsigneeID"].ToString());
                    consignee.Name = rdr["ConsigneeName"].ToString();
                    consignee.Address1 = rdr["Address1"].ToString();
                    consignee.Address2 = rdr["Address2"].ToString();
                    consignee.State = rdr["State"].ToString();
                    consignee.City = rdr["City"].ToString();
                    consignee.Pincode = Convert.ToInt32(rdr["PinCode"].ToString());
                    consignee.MobileNo = rdr["MobileNo"].ToString();
                    consignee.Email = rdr["Email"].ToString();
                    consignee.ConsignorGst = rdr["ConsigneeGst"].ToString();
                    consignees.Add(consignee);
                }
                rdr.Close();
            }

            return consignees;
        }

        public Consignee InsertNew(Consignee consignee)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("AddConsignee", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ConsigneeName", consignee.Name);
                cmd2.Parameters.AddWithValue("@Address1", consignee.Address1);
                cmd2.Parameters.AddWithValue("@Address2", consignee.Address2);
                cmd2.Parameters.AddWithValue("@State", consignee.State);
                cmd2.Parameters.AddWithValue("@City", consignee.City);
                cmd2.Parameters.AddWithValue("@Pincode", consignee.Pincode);
                cmd2.Parameters.AddWithValue("@MobileNo", consignee.MobileNo);
                cmd2.Parameters.AddWithValue("@Email", consignee.Email);
                cmd2.Parameters.AddWithValue("@ConsigneeGst", consignee.ConsignorGst);
                cmd2.Parameters.AddWithValue("@Branch", consignee.Branch);
                cmd2.ExecuteNonQuery();
                con.Close();
            }

            return consignee;
        }

        public Consignee Update(Consignee consignee)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateConsignee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ConsigneeID", consignee.ConsigneeID);
                cmd.Parameters.AddWithValue("@ConsigneeName", consignee.Name);
                cmd.Parameters.AddWithValue("@Address1", consignee.Address1);
                cmd.Parameters.AddWithValue("@Address2", consignee.Address2);
                cmd.Parameters.AddWithValue("@State", consignee.State);
                cmd.Parameters.AddWithValue("@City", consignee.City);
                cmd.Parameters.AddWithValue("@Pincode", consignee.Pincode);
                cmd.Parameters.AddWithValue("@MobileNo", consignee.MobileNo);
                cmd.Parameters.AddWithValue("@Email", consignee.Email);
                cmd.Parameters.AddWithValue("@ConsignorGst", consignee.ConsignorGst);
                cmd.Parameters.AddWithValue("@Branch", consignee.Branch);
                cmd.ExecuteNonQuery();

                con.Close();
            }

            return consignee;
        }
    }
}