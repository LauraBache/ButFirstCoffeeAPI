using ButFirstCoffee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ButFirstCoffee.Data
{
    public class SaleRepository : ISaleRepository
    {
        private readonly CoffeeContext _ctx;

        public SaleRepository(CoffeeContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Sale> GetCurrentSales()
        {
            DateTime currentDate = DateTime.Now;

            IEnumerable<Sale> sales = _ctx.Sales
                                        .Where(s => s.BeverageSales.Any(b => b.DateFrom <= currentDate && b.DateTo > currentDate))
                                        .ToList();

            return sales;
        }
    }
}
