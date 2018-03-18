using System.Collections.Generic;
using ButFirstCoffee.Domain;

namespace ButFirstCoffee.Data
{
    public interface ICondimentRepository
    {
        Condiment GetCondiment(int condimentId);
        IEnumerable<Condiment> GetCondiments();
    }
}