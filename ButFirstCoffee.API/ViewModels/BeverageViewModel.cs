using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButFirstCoffee.API
{
    public class BeverageViewModel
    {
        public int BeverageId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
