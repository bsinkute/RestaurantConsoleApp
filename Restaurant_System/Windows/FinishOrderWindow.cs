using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class FinishOrderWindow
    {
        private readonly IOrderService _orderService;

        public FinishOrderWindow(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void Load(Employee employee)
        {
            Console.Clear();
            Console.WriteLine("Active Orders:");

            List<Order> activeOrders = _orderService.GetOrders();

            if (activeOrders.Any())
            {
                foreach (Order order in activeOrders)
                {
                    Console.WriteLine($"Order ID: {order.OrderId} | Table: {order.TableId} | Guests: {order.NumberOfPeople} | Date: {DateTime.Now}");
                }

                Console.WriteLine();
                Console.Write("Enter the Order ID to close (or '0' to cancel): ");
                string input = Console.ReadLine();
                bool isValidNumber = int.TryParse(input, out int orderId);

                if (orderId == 0)
                {
                    Console.WriteLine("Closing operation canceled.");
                    return;
                }

                Order orderToClose = activeOrders.FirstOrDefault(o => o.OrderId == orderId);

                if (orderToClose == null)
                {
                    Console.WriteLine($"Order with ID {orderId} not found.");
                    return;
                }

                _orderService.Checkout(orderToClose);

                Console.ReadLine();
            }
        }
    }
}
