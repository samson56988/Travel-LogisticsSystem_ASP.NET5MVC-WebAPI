using LogisticsAndTravel.BusinessInterface.GoodsTransactionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticsAndTravel.Models;
using System.Data.SqlClient;
using LogisticsAndTravel.Connection;

namespace LogisticsAndTravel.BusinessLogic.GoodsTransactionBL
{
    public class GoodsTransactionRepository : IGoodTransactionServices
    {
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("DeleteTransaction", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@TransactionID", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public IList<GoodTransactions> GetAllGoodstransaction()
        {
            List<GoodTransactions> transactions = new List<GoodTransactions>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetGoodTransaction", con);
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
                    transactions.Add(transaction);
                }
                rdr.Close();
            }

            return transactions;
        }

        public int GoodstransactionByID(int id)
        {
            GoodTransactions transaction = new GoodTransactions();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetGoodTransactionID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@TransactionID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

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

                }
                rdr.Close();
            }

            return id;
        }

        public GoodTransactions InsertNew(GoodTransactions goods)
        {
           
            string GoodsID = "";
            string Goods = "GD";

            string TrackingID = "";
            string Tracking = "TRN";
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {

                con.Open();

                


                SqlCommand cmd3 = new SqlCommand("Select count(GoodsID) + '12001' from GoodsTransaction", con);
                int r = Convert.ToInt32(cmd3.ExecuteScalar());      
                r++;
                GoodsID = Goods + r.ToString();

                SqlCommand cmd4 = new SqlCommand("Select count(TrackingNumber) + '32001' from GoodsTransaction", con);
                int g = Convert.ToInt32(cmd4.ExecuteScalar());
                g++;
                TrackingID = Tracking + g.ToString();


                SqlCommand cmd2 = new SqlCommand("AddGoodTransaction", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@GoodsID", GoodsID);
                cmd2.Parameters.AddWithValue("@GoodsDetails", goods.GoodsDetails);
                cmd2.Parameters.AddWithValue("@PackageType", goods.PackageType);
                cmd2.Parameters.AddWithValue("@ShipmentType", goods.ShipmentType);
                cmd2.Parameters.AddWithValue("@ConsignorID", goods.ConsignorID);
                cmd2.Parameters.AddWithValue("@ConsigneeID", goods.ConsigneeID);
                cmd2.Parameters.AddWithValue("@Price", goods.Price);
                cmd2.Parameters.AddWithValue("@DispatchDate", goods.DispatchDate);
                cmd2.Parameters.AddWithValue("@TrackingNumber", TrackingID);
                cmd2.Parameters.AddWithValue("@Staff", goods.StaffID);
                cmd2.Parameters.AddWithValue("@Weight", goods.Weight);
                cmd2.Parameters.AddWithValue("@Hsncode", goods.HsnCode);
                cmd2.Parameters.AddWithValue("@Grossweight", goods.Grossweight);
                cmd2.Parameters.AddWithValue("@GstPercent", goods.GstPercentage);
                cmd2.Parameters.AddWithValue("@RatePer", goods.Rateper);
                cmd2.Parameters.AddWithValue("@Rate", goods.Rate);
                cmd2.Parameters.AddWithValue("@Branch", goods.branch);
                cmd2.ExecuteNonQuery();

                con.Close();
            }

            return goods;
        }

        public List<ConsigneeID> PopulateConsignee()
        {
            List<ConsigneeID> consignee = new List<ConsigneeID>();

            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {

                using (SqlCommand cmd = new SqlCommand("select * from ConsigneeTbl", con))
                {
                    cmd.Connection = con;

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            consignee.Add(
                                new ConsigneeID
                                {
                                    ID = Convert.ToInt32(sdr["ConsigneeID"].ToString()),
                                    Name = sdr["ConsigneeName"].ToString()
                                }

                                );
                        }
                        con.Close();
                    }


                }

                return consignee;
            }
        }

        public List<ConsignorID> PopulateConsignor()
        {
            List<ConsignorID> consignor = new List<ConsignorID>();

            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {

                using (SqlCommand cmd = new SqlCommand("select * from ConsignorTbl", con))
                {
                    cmd.Connection = con;

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            consignor.Add(
                                new ConsignorID
                                {
                                    ID = Convert.ToInt32(sdr["ConsignorID"].ToString()),
                                    Name = sdr["ConsignorName"].ToString()
                                }

                                );
                        }
                        con.Close();
                    }


                }

                return consignor;
            }
        }
       
        public GoodTransactions Update(GoodTransactions goods)
        {
            throw new NotImplementedException();
        }
    }
    
    
}