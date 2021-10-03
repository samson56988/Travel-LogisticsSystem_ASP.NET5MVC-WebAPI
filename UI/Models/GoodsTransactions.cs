using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class GoodsTransactions
    {
        public string TransactionID { get; set; }

        public string GoodsID { get; set; }

        public string GoodsDetails { get; set; }

        public string PackageType { get; set; }

        public string ShipmentType { get; set; }

        public int ConsignorID { get; set; }

        public string Consignorname { get; set; }

        public string ConsignorAddress { get; set; }

        public int ConsigneeID { get; set; }

        public string ConsigneeNamee { get; set; }

        public string ConsigneeAddress { get; set; }

        public int Weight { get; set; }

        public decimal Price { get; set; }

        public DateTime DispatchDate { get; set; }

        public string TrackingNumber { get; set; }

        public string Status { get; set; }

        public string StaffID { get; set; }
    }
}