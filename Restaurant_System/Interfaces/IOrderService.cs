using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetOrder();
        void SaveOrder(List<Order> order);
    }
}
