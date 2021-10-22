using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Recievers
    {
        public int ConsigneeID { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public int Pincode { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public string ConsignorGst { get; set; }

        public string branch {get; set;}
    }
}