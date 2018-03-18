using ButFirstCoffee.Domain;

namespace ButFirstCoffee.Data
{
    public interface IOrderItemRepository
    {
        OrderItem AddOrderItem(OrderItem item);
        void DeleteOrderItem(OrderItem item);
        OrderItem GetOrderItemWithBeverageAndSale(int itemId);
        OrderItem UpdateOrderItemWithCondiment(OrderItem item, Condiment condiment);
    }
}