using System.Collections.Generic;
using ButFirstCoffee.Domain;

namespace ButFirstCoffee.Data
{
    public interface IBeverageCategoryRepository
    {
        IEnumerable<BeverageCategory> GetBeverageCategories();
    }
}