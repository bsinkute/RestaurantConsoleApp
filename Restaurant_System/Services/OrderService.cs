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
        public List<Order> GetOrder()
        {
            List<Order> order = _orderDataService.ReadJson() ?? new List<Order>();
            return order;
        }

        public void SaveOrder(List<Order> order)
        {
            _orderDataService.WriteJson(order);
        }
    }
}
