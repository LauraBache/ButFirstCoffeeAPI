using ButFirstCoffee.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ButFirstCoffee.Data.Repositories
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
                                        .Where(b => b.Id == item.Beverage.Id)
                                        .FirstOrDefault();

            item.Description = beverage.GetDescription();
            item.UnitPrice = beverage.GetCost();

            _ctx.OrderItems.Add(item);
            _ctx.SaveChanges();

            return item;
        }

        public OrderItem UpdateOrderItem(OrderItem item, int condimentId)
        {
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
