using RestaurantSystem.Windows;

namespace RestaurantSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TakeOrderWindow takeOrderWindow = new TakeOrderWindow();
            EmployeeWindow employeeWindow = new EmployeeWindow(takeOrderWindow);
            MainWindow mainWindow = new MainWindow(employeeWindow);
            mainWindow.Load();
        }
    }
}
