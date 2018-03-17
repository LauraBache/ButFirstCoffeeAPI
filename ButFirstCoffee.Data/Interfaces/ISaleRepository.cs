using System.Collections.Generic;
using ButFirstCoffee.Domain;

namespace ButFirstCoffee.Data
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetCurrentSales();
    }
}