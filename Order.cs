using System;
using System.Collections.Generic;

namespace EfCoreSample
{
    public class Order
    {
        public long Id { get; set; }
        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}