using System.Collections.Generic;
using ButFirstCoffee.Domain;

namespace ButFirstCoffee.Data
{
    public interface ICondimentRepository
    {
        IEnumerable<Condiment> GetCondiments();
    }
}