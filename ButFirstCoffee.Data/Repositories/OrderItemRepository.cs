using ButFirstCoffee.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ButFirstCoffee.Data
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly CoffeeContext _ctx;

        public OrderItemRepository(CoffeeContext ctx)
        {
            _ctx = ctx;
        }

        public OrderItem AddOrderItem(OrderItem item)
        {
            Beverage beverage = _ctx.Beverages
                                        .Include(b => b.BeverageSales)
                                            .ThenInclude(b => b.Sale)
                                        .Where(b => b.Id == item.BeverageId)
                                        .FirstOrDefault();

            item.Description = beverage.GetDescription();
            item.UnitPrice = beverage.GetCost();

            _ctx.OrderItems.Add(item);
            _ctx.SaveChanges();

            return item;
        }

        public OrderItem GetOrderItemWithBeverageAndSale(int itemId)
        {
            return _ctx.OrderItems
                        .Include(i => i.Beverage)
                            .ThenInclude(b => b.BeverageSales)
                                .ThenInclude(b => b.Sale)
                        .Where(i => i.Id == itemId)
                        .FirstOrDefault();
        }

        public OrderItem UpdateOrderItemWithCondiment(OrderItem item, Condiment condiment)
        {
            Beverage itemBeverage = new Beverage
            {
                Description = item.Description,
                Price = item.UnitPrice,
                BeverageSales = item.Beverage.BeverageSales
            };

            condiment.Beverage = itemBeverage;

            item.Description = condiment.GetDescription();
            item.UnitPrice = condiment.GetCost();

            _ctx.OrderItems.Update(item);
            _ctx.SaveChanges();

            return item;
        }

        public void DeleteOrderItem(OrderItem item)
        {
            _ctx.OrderItems.Remove(item);
            _ctx.SaveChanges();
        }
    }
}
