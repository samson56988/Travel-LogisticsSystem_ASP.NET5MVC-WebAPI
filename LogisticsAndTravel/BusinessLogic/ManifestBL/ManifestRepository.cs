using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticsAndTravel.BusinessInterface.ManifestServices;
using LogisticsAndTravel.Models;
using System.Data.SqlClient;

namespace LogisticsAndTravel.BusinessLogic.ManifestBL
{
    public class ManifestRepository : IManifestService
    {
        public IList<Manifest> ConfirmManifest()
        {
            List<Manifest> manifests = new List<Manifest>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetManifestConfirmationList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Manifest manifest = new Manifest();
                    manifest.TransactionID = Convert.ToInt32(rdr["TransactionID"].ToString());
                    manifest.GoodsID = rdr["GoodsID"].ToString();
                    manifest.GoodsDetails = rdr["GoodsDetails"].ToString();
                    manifest.Consigneename = rdr["ConsigneeName"].ToString();
                    manifest.Consignorname = rdr["ConsignorName"].ToString();
                    manifest.TrackingNumber = rdr["TrackingNumber"].ToString();
                    manifests.Add(manifest);
                }
                rdr.Close();
            }

            return manifests;
        }

        public Manifest ConfirmManifest(Manifest manifest)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {

                con.Open();
                string man = "MAN";
                SqlCommand cmd3 = new SqlCommand("Select count(ManifestID) + '12001' from Manifest", con);
                int r = Convert.ToInt32(cmd3.ExecuteScalar());
                r++;
                manifest.ManifestID = man + r.ToString();

                SqlCommand cmd2 = new SqlCommand("ComfirmManifest", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ManifestID", manifest.ManifestID);
                cmd2.ExecuteNonQuery();
                con.Close();
            }

            return manifest;
        }

        public IList<GoodTransactions> GetAllGoodstransactionForManifest()
        {
            List<GoodTransactions> transactions = new List<GoodTransactions>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetStoredTransactionForManifest", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    GoodTransactions transaction = new GoodTransactions();
                    transaction.TransactionID = Convert.ToInt32(rdr["TransactionID"].ToString());
                    transaction.GoodsID = rdr["GoodsID"].ToString();
                    transaction.GoodsDetails = rdr["GoodDetails"].ToString();
                    transaction.PackageType = rdr["PackageType"].ToString();
                    transaction.ShipmentType = rdr["ShipmentType"].ToString();
                    transaction.ConsigneeNamee = rdr["ConsigneeName"].ToString();
                    transaction.Consignorname = rdr["ConsignorName"].ToString();
                    transaction.Weight = Convert.ToInt32(rdr["Weight"].ToString());
                    transaction.Price = Convert.ToDecimal(rdr["Price"].ToString());
                    transaction.DispatchDate = Convert.ToDateTime(rdr["DispatchDate"].ToString());
                    transaction.TrackingNumber = rdr["TrackingNumber"].ToString();
                    transaction.StaffID = rdr["Staff"].ToString();
                    transaction.ConsigneeID = Convert.ToInt32(rdr["ConsigneeID"].ToString());
                    transaction.ConsignorID = Convert.ToInt32(rdr["ConsignorID"].ToString());
                    transactions.Add(transaction);
                }
                rdr.Close();
            }

            return transactions;
        }

        public IList<Manifest> GetAllManifest()
        {
            List<Manifest> manifests = new List<Manifest>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetManifest", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Manifest manifest = new Manifest();
                    manifest.ManifestID = rdr["ManifestID"].ToString();
                    manifest.Fromm = rdr["Fromm"].ToString();
                    manifest.To = rdr["Too"].ToString();
                    manifest.Vehicle = rdr["Vehicle"].ToString();
                    manifest.Driver = rdr["Driver"].ToString();
                    manifests.Add(manifest);
                }
                rdr.Close();
            }

            return manifests;
        }

        public GoodTransactions GetTransactionByID(int id)
        {
            GoodTransactions transactions = new GoodTransactions();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetGoodTransactionID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@TransactionID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    transactions.TransactionID = Convert.ToInt32(rdr["TransactionID"].ToString());
                    transactions.GoodsID = rdr["GoodsID"].ToString();
                    transactions.GoodsDetails = rdr["GoodDetails"].ToString();
                    transactions.ConsigneeID = Convert.ToInt32(rdr["ConsigneeID"].ToString());
                    transactions.ConsigneeNamee = rdr["ConsigneeName"].ToString();
                    transactions.ConsignorID = Convert.ToInt32(rdr["ConsignorID"].ToString());
                    transactions.Consignorname = rdr["ConsignorName"].ToString();
                    transactions.TrackingNumber = rdr["TrackingNumber"].ToString();
                    transactions.Weight =  Convert.ToInt32(rdr["Weight"].ToString());
                    transactions.DispatchDate = Convert.ToDateTime(rdr["DispatchDate"].ToString());
                    transactions.PackageType = rdr["PackageType"].ToString();
                    transactions.ShipmentType = rdr["ShipmentType"].ToString();
                    transactions.Status = rdr["Status"].ToString();
                    transactions.StaffID = rdr["Staff"].ToString();

                }
                rdr.Close();
            }

            return transactions;
        }

        public GoodTransactions Insert(GoodTransactions goods)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {

                con.Open();
                SqlCommand cmd2 = new SqlCommand("AddToManifest", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@TransactionID", goods.TransactionID);
                cmd2.Parameters.AddWithValue("@GoodsID", goods.GoodsID);
                cmd2.Parameters.AddWithValue("@ConsignorID", goods.ConsignorID);
                cmd2.Parameters.AddWithValue("@ConsigneeID", goods.ConsigneeID);
                cmd2.Parameters.AddWithValue("@TrackingNumber", goods.TrackingNumber);
                cmd2.Parameters.AddWithValue("@GoodsDetails", goods.GoodsDetails);
                cmd2.Parameters.AddWithValue("@Staff", goods.StaffID);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("UpdateGoodsStatus", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionID", goods.TransactionID);
                cmd.ExecuteNonQuery();


                
                con.Close();
            }

            return goods;
        }
    }
}