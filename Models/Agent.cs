using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomerOrderWebApplication.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Customer = new HashSet<Customer>();
            Order = new HashSet<Order>();
        }

        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string Area { get; set; }
        public int Phone { get; set; }
        public string AgentCountry { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
