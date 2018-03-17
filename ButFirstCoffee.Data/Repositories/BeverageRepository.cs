using ButFirstCoffee.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ButFirstCoffee.Data
{
    public class BeverageRepository : IBeverageRepository
    {
        private readonly CoffeeContext _ctx;

        public BeverageRepository(CoffeeContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Beverage> GetBeveragesWithCategory(int? categoryID)
        {
            IEnumerable<Beverage> beverages = new List<Beverage>();

            if (categoryID != null)
            {
                beverages = _ctx.Beverages
                            .Include(b => b.Category)
                            .Where(b => b.Category.Id == categoryID)
                            .OrderBy(b => b.Description)
                            .ToList();
            }
            else
            {
                beverages = _ctx.Beverages
                            .Include(b => b.Category)
                            .OrderBy(b => b.Description)
                            .ToList();
            }

            return beverages;
        }
    }
}
