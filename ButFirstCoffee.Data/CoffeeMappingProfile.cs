using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ButFirstCoffee.Data
{
    public class CoffeeMappingProfile: Profile
    {
        public CoffeeMappingProfile()
        {
            CreateMap<Order, OrderViewModel>
        }
    }
}
