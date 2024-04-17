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
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IDataService<List<Order>> orderDataService = new DataService<List<Order>> { FileName = "Orders.json" };
            IDataService<List<Table>> tableDataService = new DataService<List<Table>> { FileName = "Tables.json" };
            IDataService<List<Employee>> employeeDataService = new DataService<List<Employee>> { FileName = "Employees.json" };
            IDataService<List<Dish>> dishDataService = new DataService<List<Dish>> { FileName = "Dishes.json"};
            IDataService<List<Drink>> drinkDataService = new DataService<List<Drink>> { FileName = "Drinks.json" };

            IOrderService orderService = new OrderService(orderDataService);
            ITableService tableService = new TableService(tableDataService);
            IEmployeeService employeeService = new EmployeeService(employeeDataService);
            IMenuService menuService = new MenuService(dishDataService, drinkDataService);

            TakeOrderWindow takeOrderWindow = new TakeOrderWindow(tableService, orderService);
            AddMenuItemWindow addMenuItemWindow = new AddMenuItemWindow(menuService);
            ReviewOrdersWindow reviewOrdersWindow = new ReviewOrdersWindow(tableService, orderService, menuService);
            DailyStatisticsWindow dailyStatisticsWindow = new DailyStatisticsWindow();
            FinishOrderWindow finishOrderWindow = new FinishOrderWindow(orderService, tableService);
            EmployeeWindow employeeWindow = new EmployeeWindow(takeOrderWindow, addMenuItemWindow, reviewOrdersWindow, dailyStatisticsWindow, finishOrderWindow);
            MainWindow mainWindow = new MainWindow(employeeWindow, employeeService);

            mainWindow.Load();
        }
    }
}
