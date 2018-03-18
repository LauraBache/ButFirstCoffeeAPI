using AutoMapper;
using ButFirstCoffee.API.ViewModels;
using ButFirstCoffee.Domain;

namespace ButFirstCoffee.API
{
    public class CoffeeMappingProfile: Profile
    {
        public CoffeeMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ForMember(o => o.OrderItems, ex => ex.MapFrom(o => o.Items))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(i => i.ItemId, ex => ex.MapFrom(i => i.Id))
                .ReverseMap();

            CreateMap<Beverage, BeverageViewModel>()
                .ForMember(b => b.BeverageId, ex => ex.MapFrom(b => b.Id))
                .ReverseMap();

            CreateMap<BeverageCategory, BeverageCategoryViewModel>()
                .ForMember(c => c.CategoryId, ex => ex.MapFrom(c => c.Id))
                .ReverseMap();

            CreateMap<Sale, SaleViewModel>()
                .ReverseMap();

            CreateMap<Condiment, CondimentViewModel>()
                .ForMember(c => c.CondimentId, ex => ex.MapFrom(c => c.Id))
                .ReverseMap();
        }
    }
}
