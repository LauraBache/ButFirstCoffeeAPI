using ButFirstCoffee.Domain;

namespace ButFirstCoffee.Data
{
    public interface IOrderItemRepository
    {
        OrderItem AddOrderItem(OrderItem item);
        void DeleteOrderItem(OrderItem item);
        OrderItem UpdateOrderItem(OrderItem item, int condimentId);
    }
}