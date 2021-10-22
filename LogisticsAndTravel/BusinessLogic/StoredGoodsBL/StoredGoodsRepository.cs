using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticsAndTravel.BusinessInterface.StoredGoodsServices;
using LogisticsAndTravel.Models;
using System.Data.SqlClient;

namespace LogisticsAndTravel.BusinessLogic.StoredGoodsBL
{
    public class StoredGoodsRepository : IStoredGoodsServices
    {
        public IList<StoredGoods> GetAllStoredGoods()
        {
            List<StoredGoods> storedGoods = new List<StoredGoods>();
            using (SqlConnection con = new SqlConnection(Connection.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("getStoredGoods", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StoredGoods stored = new StoredGoods();
                    stored.GoodsID = rdr["GoodsID"].ToString();
                    stored.GoodsDetails = rdr["GoodDetails"].ToString();
                    stored.PackageType = rdr["PackageType"].ToString();
                    stored.ShipmentType = rdr["ShipmentType"].ToString();
                    stored.Consigneename = rdr["ConsigneeName"].ToString();
                    stored.Consignorname = rdr["ConsignorName"].ToString();
                    stored.Weight = Convert.ToInt32(rdr["Weight"].ToString());
                    stored.Dispatchdate = Convert.ToDateTime(rdr["DispatchDate"].ToString());
                    storedGoods.Add(stored);
                }
                rdr.Close();
            }

            return storedGoods;
        }

        public IList<StoredGoods> SearchStoredGoods(string search)
        {
            throw new NotImplementedException();
        }
    }
}