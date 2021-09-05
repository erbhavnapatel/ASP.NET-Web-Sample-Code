using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomerOrderWebApplication.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string City { get; set; }
        public string WorkingArea { get; set; }
        public string Country { get; set; }
        public string Grade { get; set; }
        public int? OpeningAmount { get; set; }
        public int? ReceivedAmount { get; set; }
        public int? PaymentAmount { get; set; }
        public int? OutstandingAmount { get; set; }
        public int PhoneNo { get; set; }
        public string AgentCode { get; set; }

        public virtual Agent AgentCodeNavigation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
