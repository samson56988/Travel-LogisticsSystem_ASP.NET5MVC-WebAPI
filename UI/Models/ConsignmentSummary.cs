using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ConsignmentSummary
    {
        public int ConsignmentID { get; set; }

        public int ConsignorID { get; set; }

        public string Consignor { get; set; }

        public int ConsigneeID { get; set; }

        public string Consignee { get; set; }

        public DateTime BookingDate { get; set; }

        public int TransactionID { get; set; }

        public string BillityType { get; set; }

        public string Bookingreference { get; set; }

        public string BrookerDetails { get; set; }

        public DateTime BillDate { get; set; }

        public decimal ValueOfGoods { get; set; }

        public string TaxPaidBy { get; set; }

        public string From { get; set; }

        public string Too { get; set; }

        public string PaymentTerms { get; set; }

        public string EwayBillNo { get; set; }

        public DateTime EwayBillDate { get; set; }

        public int Distance { get; set; }

        public decimal Servicecharge { get; set; }

        public decimal Covercharge { get; set; }

        public decimal Packingcharge { get; set; }

        public decimal Price { get; set; }

        public string branch { get; set; }
    }
}