using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticsAndTravel.Models
{
    public class Manifest
    {
        public int ID { get; set; }

        public string ManifestID { get; set; }

        public int TransactionID { get; set; }

        public string GoodsID { get; set; }

        public int ConsigneeID { get; set; }

        public string Consigneename { get; set; }

        public int ConsignorID { get; set; }

        public string Consignorname { get; set; }

        public string TrackingNumber { get; set; }

        public string GoodsDetails { get; set; }

        public string Fromm { get; set; }

        public string To { get; set; }

        public string Staff { get; set; }

        public string Vehicle { get; set; }

        public string Driver { get; set; }
    }
}