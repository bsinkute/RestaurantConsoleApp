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
            Console.WriteLine("Active Orders:");

            List<Order> activeOrders = _orderService.GetEmployeeOrders(employee.Id);

            if (activeOrders.Any())
            {
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
                    Console.WriteLine("Does the customer want a receipt? (yes/no)");
                    string addAnotherInput = Console.ReadLine().ToLower();
                    bool userWantsReceipt = false;
                    if (addAnotherInput == "yes" || addAnotherInput == "y")
                    {
                        userWantsReceipt = true;
                    }
                    PrintReceipts(orderToClose, userWantsReceipt);
                }
                else
                {
                    Console.WriteLine("Empty order was closed. Receipt will not be printed.");
                }
                
                Console.Write("Press any key to go back to employee menu. ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No active orders to finish.");
                Console.Write("Press any key to go back to employee menu. ");
                Console.ReadKey();
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
