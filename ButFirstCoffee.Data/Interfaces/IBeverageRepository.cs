using System.Collections.Generic;
using ButFirstCoffee.Domain;

namespace ButFirstCoffee.Data
{
    public interface IBeverageRepository
    {
        IEnumerable<Beverage> GetBeveragesWithCategory(int? categoryID);
    }
}