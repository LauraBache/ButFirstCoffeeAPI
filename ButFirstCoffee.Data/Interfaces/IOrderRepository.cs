using ButFirstCoffee.Domain;

namespace ButFirstCoffee.Data
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        Order CompleteOrder(Order order);
        Order GetOrder(int id);
        Order GetOrderWithItems(int id);
    }
}