using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomerOrderWebApplication.Models
{
    public partial class Order
    {
        public string OrderNo { get; set; }
        public int OrderAmount { get; set; }
        public int? AdvanceAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustCode { get; set; }
        public string AgentCode { get; set; }
        public string OrderDesc { get; set; }

        public virtual Agent AgentCodeNavigation { get; set; }
        public virtual Customer CustCodeNavigation { get; set; }
    }
}
