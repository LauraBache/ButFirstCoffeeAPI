using ButFirstCoffee.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ButFirstCoffee.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CoffeeContext _ctx;

        public OrderRepository(CoffeeContext ctx)
        {
            _ctx = ctx;
        }

        public Order CreateOrder(Order order)
        {
            foreach (OrderItem item in order.Items)
            {
                Beverage beverage = _ctx.Beverages
                                        .Include(b => b.BeverageSales)
                                            .ThenInclude(b => b.Sale)
                                        .Where(b => b.Id == item.BeverageId)
                                        .FirstOrDefault();

                item.Description = beverage.GetDescription();
                item.UnitPrice = beverage.GetCost();
            }

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();

            return order;
        }

        public Order CompleteOrder(Order order)
        {
            order.Completed = true;

            _ctx.Orders.Update(order);
            _ctx.SaveChanges();

            return order;
        }

        public Order GetOrder(int id)
        {
            return _ctx.Orders
                        .Where(o => o.Id == id)
                        .FirstOrDefault();
        }

        public Order GetOrderWithItems(int id)
        {
            return _ctx.Orders
                        .Include(o => o.Items)
                        .Where(o => o.Id == id)
                        .FirstOrDefault();
        }
    }
}
