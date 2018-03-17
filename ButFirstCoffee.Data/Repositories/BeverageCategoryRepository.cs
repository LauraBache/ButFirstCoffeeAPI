using ButFirstCoffee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ButFirstCoffee.Data
{
    public class BeverageCategoryRepository : IBeverageCategoryRepository
    {
        private readonly CoffeeContext _ctx;

        public BeverageCategoryRepository(CoffeeContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<BeverageCategory> GetBeverageCategories()
        {
            IEnumerable<BeverageCategory> categories = _ctx.BeverageCategories
                                                        .OrderBy(c => c.Name)
                                                        .ToList();

            return categories;
        }
    }
}
