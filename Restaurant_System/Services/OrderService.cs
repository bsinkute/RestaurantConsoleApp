using RestaurantSystem.Infrastructure;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDataService<List<Order>> _orderDataService;
        public OrderService(IDataService<List<Order>> orderDataService)
        {
            _orderDataService = orderDataService;
        }
        public List<Order> GetOrders()
        {
            List<Order> orders = _orderDataService.ReadJson() ?? new List<Order>();
            return orders;
        }

        public void SaveOrders(List<Order> orders)
        {
            _orderDataService.WriteJson(orders);
        }

        public void AddOrder(Order order)
        {
            List<Order> orders = _orderDataService.ReadJson() ?? new List<Order>();
            orders.Add(order);
            _orderDataService.WriteJson(orders);
        }

        public List<Order> GetEmployeeOrders(int employeeId)
        {
            List<Order> orders = _orderDataService.ReadJson() ?? new List<Order>();
            return orders.Where(x => x.EmployeeId == employeeId).ToList();
        }
    }
}
