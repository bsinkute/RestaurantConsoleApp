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

            MainWindow mainWindow = RegisterServices();

            mainWindow.Load();
        }

        private static MainWindow RegisterServices()
        {
            IDataService<List<Order>> orderDataService = new DataService<List<Order>> { FileName = "Orders.json" };
            IDataService<List<Table>> tableDataService = new DataService<List<Table>> { FileName = "Tables.json" };
            IDataService<List<Employee>> employeeDataService = new DataService<List<Employee>> { FileName = "Employees.json" };
            IDataService<List<Dish>> dishDataService = new DataService<List<Dish>> { FileName = "Dishes.json" };
            IDataService<List<Drink>> drinkDataService = new DataService<List<Drink>> { FileName = "Drinks.json" };
            IDataService<List<string>> receiptDataService = new DataService<List<string>> { FileName = "RestaurantReceipts.json" };

            IOrderService orderService = new OrderService(orderDataService);
            ITableService tableService = new TableService(tableDataService);
            IEmployeeService employeeService = new EmployeeService(employeeDataService);
            IMenuService menuService = new MenuService(dishDataService, drinkDataService);
            IReceiptService receiptService = new ReceiptService(receiptDataService);
            IStatisticService statisticService = new StatisticService(menuService);

            TakeOrderWindow takeOrderWindow = new TakeOrderWindow(tableService, orderService);
            AddMenuItemWindow addMenuItemWindow = new AddMenuItemWindow(menuService);
            ReviewOrdersWindow reviewOrdersWindow = new ReviewOrdersWindow(orderService, menuService);
            DailyStatisticsWindow dailyStatisticsWindow = new DailyStatisticsWindow(statisticService, orderService);
            FinishOrderWindow finishOrderWindow = new FinishOrderWindow(orderService, tableService, receiptService);
            EmployeeWindow employeeWindow = new EmployeeWindow(takeOrderWindow, addMenuItemWindow, reviewOrdersWindow, dailyStatisticsWindow, finishOrderWindow);
            MainWindow mainWindow = new MainWindow(employeeWindow, employeeService);
            return mainWindow;
        }
    }
}
