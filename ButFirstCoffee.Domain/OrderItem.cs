using System;
using System.Collections.Generic;
using System.Text;

namespace ButFirstCoffee.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int BeverageId { get; set; }
        public Beverage Beverage { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
