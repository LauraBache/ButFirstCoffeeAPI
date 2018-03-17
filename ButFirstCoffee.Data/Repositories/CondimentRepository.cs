using ButFirstCoffee.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ButFirstCoffee.Data
{
    public class CondimentRepository : ICondimentRepository
    {
        private readonly CoffeeContext _ctx;

        public CondimentRepository(CoffeeContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Condiment> GetCondiments()
        {
            IEnumerable<Condiment> condiments = _ctx.Condiments
                                                .OrderBy(c => c.Description)
                                                .ToList();

            return condiments;
        }
    }
}
