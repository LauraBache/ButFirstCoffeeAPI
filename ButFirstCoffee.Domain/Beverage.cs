using System;
using System.Collections.Generic;
using System.Linq;

namespace ButFirstCoffee.Domain
{
    public class Beverage : BeverageComponent
    {
        public int Id { get; set; }
        public string DetailedDescription { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public BeverageCategory Category { get; set; }
        public List<BeverageSale> BeverageSales { get; set; }

        public override decimal GetCost()
        {
            decimal cost = this.Price;

            if (BeverageSales.Count > 0)
            {
                DateTime currentDate = DateTime.Now;
                List<BeverageSale> currentSales = this.BeverageSales.Where(s => s.DateFrom <= currentDate && s.DateTo > currentDate).ToList();

                if (currentSales.Count > 0)
                {
                    foreach (BeverageSale beverageSale in currentSales)
                    {
                        cost = cost - (this.Price / 100 * beverageSale.Sale.Percent);
                    }
                }
            }

            return cost;
        }
    }
}
