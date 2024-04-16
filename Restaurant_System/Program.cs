using RestaurantSystem.Infrastructure;
using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;
using RestaurantSystem.Services;
using RestaurantSystem.Windows;

namespace RestaurantSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataService<List<Order>> orderDataService = new DataService<List<Order>> { FileName = "Orders.json" };
            IDataService<List<Table>> tableDataService = new DataService<List<Table>> { FileName = "Tables.json" };
            IDataService<List<Employee>> employeeDataService = new DataService<List<Employee>> { FileName = "Employees.json" };

            IOrderService orderService = new OrderService(orderDataService);
            ITableService tableService = new TableService(tableDataService);
            IEmployeeService employeeService = new EmployeeService(employeeDataService);

            TakeOrderWindow takeOrderWindow = new TakeOrderWindow(tableService, orderService);
            AddMenuItemWindow addMenuItemWindow = new AddMenuItemWindow();
            ReviewOrdersWindow reviewOrdersWindow = new ReviewOrdersWindow(tableService, orderService);
            DailyStatisticsWindow dailyStatisticsWindow = new DailyStatisticsWindow();
            EmployeeWindow employeeWindow = new EmployeeWindow(takeOrderWindow, addMenuItemWindow, reviewOrdersWindow, dailyStatisticsWindow);
            MainWindow mainWindow = new MainWindow(employeeWindow, employeeService);
            mainWindow.Load();
        }
    }
}
