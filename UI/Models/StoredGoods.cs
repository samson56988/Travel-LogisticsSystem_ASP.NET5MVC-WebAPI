using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class StoredGoods
    {
        public string Consigneename { get; set; }

        public string Consignorname { get; set; }

        public string GoodsID { get; set; }

        public string PackageType { get; set; }

        public string ShipmentType { get; set; }

        public int Weight { get; set; }

        public string GoodsDetails { get; set; }

        public DateTime Dispatchdate { get; set; }
    }
}