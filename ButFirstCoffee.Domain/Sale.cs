using System.Collections.Generic;

namespace ButFirstCoffee.Domain
{
    public class Sale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ESaleType Type { get; set; }
        public decimal Percent { get; set; }
        public List<BeverageSale> BeverageSales { get; set; }
    }
}
