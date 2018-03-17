using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ButFirstCoffee.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; }
        public bool Completed { get; set; }
    }
}
