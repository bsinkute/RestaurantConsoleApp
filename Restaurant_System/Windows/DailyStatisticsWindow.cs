using RestaurantSystem.Helpers;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class DailyStatisticsWindow
    {
        private readonly IStatisticService _statisticService;
        private readonly IOrderService _orderService;
        private readonly IEmployeeService _employeeService;

        public DailyStatisticsWindow(IStatisticService statisticService, IOrderService orderService, IEmployeeService employeeService)
        {
            _statisticService = statisticService;
            _orderService = orderService;
            _employeeService = employeeService;
        }
        public void Load(Employee employee)
        {
            ConsoleHelper.ShowLoggedInAndClear(employee);
            List<Order> dailyOrders = _orderService.GetDayOrders(DateTime.Now);
            Console.WriteLine("Revenue: ");
            Console.WriteLine($"With VAT: {_statisticService.GetTotalRevenueWithVat(dailyOrders):N} €");
            Console.WriteLine($"Without VAT: {_statisticService.GetTotalRevenueWithoutVat(dailyOrders):N} €");

            Console.WriteLine($"Order when tables were not full: {_statisticService.TimesTablesNotFull(dailyOrders)}/{dailyOrders.Count}");
            
            int totalCustomers = _statisticService.GetTotalCustomers(dailyOrders);
            int totalSeats = _statisticService.GetTotalSeats(dailyOrders);
            Console.WriteLine($"Total customers / seats: {totalCustomers}/{totalSeats}");

            var addedProducts = _statisticService.GetAddedProduct(DateTime.Now);
            Console.WriteLine("Today's Added Menu Items:");
            foreach (var product in addedProducts)
            {
                Console.WriteLine($"- Name: {product.Name}, Price: {product.Price:N} €");
            }
 
            if (addedProducts.Count == 0) 
            {
                Console.WriteLine("No items added today.");
            }

            Dictionary<int, int> employeeOrderCounts = _statisticService.GetEmployeeOrderCounts(dailyOrders);

            foreach (var kvp in employeeOrderCounts)
            {
                string employeeName = _employeeService.GetName(kvp.Key);
                int orderCount = kvp.Value;

                Console.WriteLine($"Employee: {employeeName}, Order Count: {orderCount}");
            }

            ConsoleHelper.GoBack();


        }

    }
}
