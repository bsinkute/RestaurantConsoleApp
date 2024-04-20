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
            List<Order> orders = _orderDataService.ReadJson();
            if(orders == null)
            {
                orders = new List<Order>();
                order.OrderId = 1;
            }
            else
            {
                order.OrderId = orders.Max(o => o.OrderId) + 1;
            }
            orders.Add(order);
            _orderDataService.WriteJson(orders);
        }

        public List<Order> GetEmployeeOrders(int employeeId)
        {
            List<Order> orders = _orderDataService.ReadJson() ?? new List<Order>();
            return orders.Where(x => x.EmployeeId == employeeId && x.Checkout == default).ToList();
        }

        public void AddMenuItemToOrder(int orderId, MenuItem selectedMenuItem, int quantity)
        {
            List<Order> orders = _orderDataService.ReadJson() ?? new List<Order>();
            Order orderToUpdate = orders.FirstOrDefault(o => o.OrderId == orderId);

            if (orderToUpdate == null)
            {
                Console.WriteLine($"Order with ID {orderId} not found.");
                return;
            }

            if (orderToUpdate.Items.Any(item => item.OrderedItem.Id == selectedMenuItem.Id))
            {
                int itemIndex = orderToUpdate.Items.FindIndex(item => item.OrderedItem.Id == selectedMenuItem.Id);
                orderToUpdate.Items[itemIndex].Quantity += quantity;
            }
            else
            {
                OrderItem orderItem = new OrderItem { OrderedItem = selectedMenuItem, Quantity = quantity };
                orderToUpdate.Items.Add(orderItem);
            }

            _orderDataService.WriteJson(orders);
            Console.WriteLine($"{selectedMenuItem.Name} added to Order ID {orderId}.");
        }

        public void Checkout(Order orderToClose)
        {
            if (orderToClose == null)
            {
                throw new ArgumentNullException(nameof(orderToClose), "Order to close cannot be null.");
            }

            orderToClose.Checkout = DateTime.Now;

            UpdateOrder(orderToClose);
        }

        private void UpdateOrder(Order order)
        {
            List<Order> orders = _orderDataService.ReadJson() ?? new List<Order>();
            int orderIndex = orders.FindIndex(x => x.OrderId == order.OrderId);
            if (orderIndex != -1)
            {
                orders[orderIndex] = order;
                _orderDataService.WriteJson(orders);
            }
        }

        public List<Order> GetDayOrders(DateTime date)
        {
            return GetOrders().Where(order => order.Checkout.Date == date.Date)
                .ToList();
        }
    }
}
