using RestaurantSystem.Windows;

namespace RestaurantSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TakeOrderWindow takeOrderWindow = new TakeOrderWindow();
            AddMenuItemWindow addMenuItemWindow = new AddMenuItemWindow();
            ReviewOrdersWindow reviewOrdersWindow = new ReviewOrdersWindow();
            DailyStatisticsWindow dailyStatisticsWindow = new DailyStatisticsWindow();
            EmployeeWindow employeeWindow = new EmployeeWindow(takeOrderWindow, addMenuItemWindow, reviewOrdersWindow, dailyStatisticsWindow);
            MainWindow mainWindow = new MainWindow(employeeWindow);
            mainWindow.Load();
        }
    }
}
