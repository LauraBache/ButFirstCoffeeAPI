using System;
using System.Collections.Generic;
using System.Text;

namespace ButFirstCoffee.Domain
{
    public class BeverageSale
    {
        public int BeverageId { get; set; }
        public Beverage Beverage { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
