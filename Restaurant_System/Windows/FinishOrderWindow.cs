using RestaurantSystem.Helpers;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class FinishOrderWindow
    {
        private readonly IOrderService _orderService;
        private readonly ITableService _tableService;
        private readonly IReceiptService _receiptService;

        public FinishOrderWindow(IOrderService orderService, ITableService tableService, IReceiptService receiptService)
        {
            _orderService = orderService;
            _tableService = tableService;
            _receiptService = receiptService;
        }

        public void Load(Employee employee)
        {
            Console.Clear();
            List<Order> activeOrders = _orderService.GetEmployeeOrders(employee.Id);

            if (!activeOrders.Any())
            {
                Console.WriteLine("No active orders to finish.");
                ConsoleHelper.GoBack();
                return;
            }

            Console.WriteLine("Active Orders:");
            foreach (Order order in activeOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderId} | Table: {order.TableId} | Guests: {order.NumberOfPeople} | Date: {order.Checkin}");
            }

            Console.WriteLine();
            Console.Write("Enter the Order ID to close (or '0' to cancel): ");
            string input = Console.ReadLine();
            bool isValidNumber = int.TryParse(input, out int orderId);

            if (orderId == 0)
            {
                ConsoleHelper.GoBack();
                return;
            }

            Order orderToClose = activeOrders.FirstOrDefault(o => o.OrderId == orderId);

            if (orderToClose == null)
            {
                Console.WriteLine($"Order with ID {orderId} not found.");
                ConsoleHelper.GoBack();
                return;
            }

            CloseOrder(orderToClose);
            ConsoleHelper.GoBack();
        }

        private void CloseOrder(Order orderToClose)
        {
            _orderService.Checkout(orderToClose);
            List<Table> tables = _tableService.GetTables();
            int tableIndex = tables.FindIndex(table => table.Id == orderToClose.TableId);
            if (tableIndex != -1)
            {
                tables[tableIndex].FreeUp();
                _tableService.SaveTables(tables);
            }
            if (orderToClose.Items.Count > 0)
            {
                Console.WriteLine($"Order ID {orderToClose.OrderId} successfully closed.");
                Console.Write("Does the customer want a receipt? (yes/no): ");
                bool userWantsReceipt = ConsoleHelper.YesOrNoInput();
                PrintReceipts(orderToClose, userWantsReceipt);
            }
            else
            {
                Console.WriteLine("Empty order was closed. Receipt will not be printed.");
            }
        }

        private void PrintReceipts(Order orderToClose, bool userWantsReceipt)
        {
            if (userWantsReceipt)
            {
                string customerReceipt = _receiptService.GetReceipt(orderToClose, false);
                Console.WriteLine(customerReceipt);
            }
            string restaurantReceipt = _receiptService.GetReceipt(orderToClose, true);
            Console.WriteLine(restaurantReceipt);
            _receiptService.AddReceipt(restaurantReceipt);
        }
    }
}
