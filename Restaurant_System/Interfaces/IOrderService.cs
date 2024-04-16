using RestaurantSystem.Models;

namespace RestaurantSystem.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        void SaveOrders(List<Order> order);
        void AddOrder(Order order);
        List<Order> GetEmployeeOrders(int employeeId);
    }
}
