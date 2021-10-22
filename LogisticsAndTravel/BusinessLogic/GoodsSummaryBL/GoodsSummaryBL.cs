using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticsAndTravel.Models;
using LogisticsAndTravel.BusinessInterface.ConsignmentService;
using System.Data.SqlClient;

namespace LogisticsAndTravel.BusinessLogic.GoodsSummaryBL
{
    public class GoodsSummaryBL : IConsignmentService
    {
        public IList<ConsignmentSummary> GetAllConsigmentSummary()
        {
            List<ConsignmentSummary> consignmentdetails = new List<ConsignmentSummary>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetConsignmentsummary", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ConsignmentSummary consignmentdetail = new ConsignmentSummary();
                    consignmentdetail.ConsignmentID = Convert.ToInt32(rdr["ConsignmentID"].ToString());
                    consignmentdetail.Consignor= rdr["ConsignorName"].ToString();
                    consignmentdetail.Consignee = rdr["ConsigneeName"].ToString();
                    consignmentdetail.From = rdr["Fromm"].ToString();
                    consignmentdetail.Too = rdr["Too"].ToString();
                    consignmentdetail.ValueOfGoods = Convert.ToDecimal(rdr["ValueOfGood"].ToString());
                    consignmentdetail.EwayBillNo = rdr["EwayBillNo"].ToString();
                    consignmentdetails.Add(consignmentdetail);
                }
                rdr.Close();
            }

            return consignmentdetails;
        }

        public ConsignmentSummary GoodstransactionByID(int id)
        {
            ConsignmentSummary consignmentsummary = new ConsignmentSummary();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetGoodTransactionID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@TransactionID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    consignmentsummary.TransactionID = Convert.ToInt32(rdr["TransactionID"].ToString());
                    consignmentsummary.ConsigneeID = Convert.ToInt32(rdr["ConsigneeID"].ToString());
                    consignmentsummary.ConsignorID = Convert.ToInt32(rdr["ConsignorID"].ToString());
                    consignmentsummary.TransactionID = Convert.ToInt32(rdr["TransactionID"].ToString());
                    consignmentsummary.BillDate = Convert.ToDateTime(rdr["DispatchDate"].ToString());
                    consignmentsummary.BookingDate = Convert.ToDateTime(rdr["DispatchDate"].ToString());
                    consignmentsummary.EwayBillDate = Convert.ToDateTime(rdr["DispatchDate"].ToString());
                    consignmentsummary.Price = Convert.ToDecimal(rdr["Price"].ToString());

                }
                rdr.Close();
            }

            return consignmentsummary;
        }

        public ConsignmentSummary InsertNew(ConsignmentSummary consignorsummary)
        {
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("AddConsignmentSummary", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ConsigneeID", consignorsummary.ConsigneeID);
                cmd2.Parameters.AddWithValue("@ConsignorID", consignorsummary.ConsignorID);
                cmd2.Parameters.AddWithValue("@BookingDate", consignorsummary.BookingDate);
                cmd2.Parameters.AddWithValue("@TransactionID", consignorsummary.TransactionID);
                cmd2.Parameters.AddWithValue("@BiltyType", consignorsummary.BillityType);
                cmd2.Parameters.AddWithValue("@BookingReference", consignorsummary.Bookingreference);
                cmd2.Parameters.AddWithValue("@BrokerDetails", consignorsummary.BrookerDetails);
                cmd2.Parameters.AddWithValue("@BillDate", consignorsummary.BillDate);
                cmd2.Parameters.AddWithValue("@ValueOfGoods", consignorsummary.ValueOfGoods);
                cmd2.Parameters.AddWithValue("@TaxPaidBy", consignorsummary.TaxPaidBy);
                cmd2.Parameters.AddWithValue("@Fromm", consignorsummary.From);
                cmd2.Parameters.AddWithValue("@Too", consignorsummary.Too);
                cmd2.Parameters.AddWithValue("@PaymentTerms", consignorsummary.PaymentTerms);
                cmd2.Parameters.AddWithValue("@EwayBillNo", consignorsummary.EwayBillNo);
                cmd2.Parameters.AddWithValue("@EwayBillDate", consignorsummary.EwayBillDate);
                cmd2.Parameters.AddWithValue("@Distance", consignorsummary.Distance);
                cmd2.Parameters.AddWithValue("@Servicecharge", consignorsummary.Servicecharge);
                cmd2.Parameters.AddWithValue("@Covercharge", consignorsummary.Covercharge);
                cmd2.Parameters.AddWithValue("@Packingcharge", consignorsummary.Packingcharge);
                cmd2.Parameters.AddWithValue("@Price", consignorsummary.Price);
                cmd2.Parameters.AddWithValue("@Branch", consignorsummary.Branch);
                cmd2.ExecuteNonQuery();
                con.Close();
            }

            return consignorsummary;
        }
    }

}