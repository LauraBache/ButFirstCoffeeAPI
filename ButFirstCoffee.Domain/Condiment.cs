using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ButFirstCoffee.Domain
{
    public class Condiment: BeverageDecorator
    {
        public int Id { get; set; }
        public string DetailedDescription { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public Beverage Beverage { get; set; }

        public override string GetDescription()
        {
            string decoratedDescription = $"{this.Beverage.GetDescription()}, {this.Description}";
            return decoratedDescription;
        }

        public override decimal GetCost()
        {
            decimal condimentCost = this.Price;

            if (this.Beverage.BeverageSales.Count > 0)
            {
                DateTime currentDate = DateTime.Now;
                List<BeverageSale> currentSales = this.Beverage.BeverageSales.Where(s => s.DateFrom <= currentDate && s.DateTo > currentDate).ToList();

                if (currentSales.Count > 0)
                {
                    foreach (BeverageSale beverageSale in currentSales)
                    {
                        if (beverageSale.Sale.Type == ESaleType.On_Decorated_Beverage)
                        {
                            condimentCost = condimentCost - (this.Price / 100 * beverageSale.Sale.Percent);
                        }
                    }
                }
            }

            decimal cost = this.Beverage.Price + condimentCost;

            return cost;
        }
    }
}
