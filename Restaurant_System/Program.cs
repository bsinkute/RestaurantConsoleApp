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
            IDataService<List<Employee>> employeeDataService = new DataService<List<Employee>> { FileName = "Employees.json" };
            IEmployeeService employeeService = new EmployeeService(employeeDataService);

            TakeOrderWindow takeOrderWindow = new TakeOrderWindow();
            AddMenuItemWindow addMenuItemWindow = new AddMenuItemWindow();
            ReviewOrdersWindow reviewOrdersWindow = new ReviewOrdersWindow();
            DailyStatisticsWindow dailyStatisticsWindow = new DailyStatisticsWindow();
            EmployeeWindow employeeWindow = new EmployeeWindow(takeOrderWindow, addMenuItemWindow, reviewOrdersWindow, dailyStatisticsWindow);
            MainWindow mainWindow = new MainWindow(employeeWindow, employeeService);
            mainWindow.Load();
        }
    }
}
