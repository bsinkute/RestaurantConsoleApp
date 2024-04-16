using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class ReviewOrdersWindow(ITableService tableService, IOrderService orderService)
    {
        private readonly ITableService _tableService = tableService;
        private readonly IOrderService _orderService = orderService;

        public void Load(Employee employee)
        {
            List<Order> activeOrders = _orderService.GetOrders();

            Console.Clear();
            Console.WriteLine("Active Orders:");
            foreach (Order order in activeOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderId} | Table: {order.TableId} | Guests: {order.NumberOfPeople} | Date: {DateTime.Now}");
            }

            Console.Write("Enter the Order ID to review details (or '0' to exit): ");
            string input = Console.ReadLine();
            bool isValidNumber = int.TryParse(input, out int orderId);
        }
    }
}
