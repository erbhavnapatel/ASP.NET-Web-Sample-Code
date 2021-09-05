using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrderWebApplication.Models
{
    public class EntitiesClass
    {
        List<Order> OrderList = new List<Order>()
        {
            new Order(){ OrderNo = "ORD001", OrderAmount = 3000 },
            new Order(){ OrderNo = "ORD002", OrderAmount = 2000 }
        };
    }
}
