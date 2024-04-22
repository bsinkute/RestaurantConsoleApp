using RestaurantSystem.Helpers;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class EmployeeWindow
    {
        private readonly TakeOrderWindow _takeOrderWindow;
        private readonly AddMenuItemWindow _addMenuItemWindow;
        private readonly ReviewOrdersWindow _reviewOrdersWindow;
        private readonly DailyStatisticsWindow _dailyStatisticsWindow;
        private readonly FinishOrderWindow _finishOrderWindow;

        public EmployeeWindow(
            TakeOrderWindow takeOrderWindow, 
            AddMenuItemWindow addMenuItemWindow, 
            ReviewOrdersWindow reviewOrdersWindow, 
            DailyStatisticsWindow dailyStatisticsWindow, 
            FinishOrderWindow finishOrderWindow)
        {
            _takeOrderWindow = takeOrderWindow;
            _addMenuItemWindow = addMenuItemWindow;
            _reviewOrdersWindow = reviewOrdersWindow;
            _dailyStatisticsWindow = dailyStatisticsWindow;
            _finishOrderWindow = finishOrderWindow;
        }
        public void Load(Employee employee)
        {
            while (true)
            {
                DisplayMenu(employee);
                bool isLoadCorect = int.TryParse(Console.ReadLine(), out int loadSelect);
                while (!isLoadCorect || loadSelect < 1 || loadSelect > 6)
                {
                    Console.Write("Please enter a number from 1 to 6: ");
                    isLoadCorect = int.TryParse(Console.ReadLine(), out loadSelect);
                }
                switch (loadSelect)
                {
                    case 1:
                        _takeOrderWindow.Load(employee);
                        break;
                    case 2:
                        _addMenuItemWindow.Load(employee);
                        break;
                    case 3:
                        _reviewOrdersWindow.Load(employee);
                        break;
                    case 4:
                        _finishOrderWindow.Load(employee);
                        break;
                    case 5:
                        _dailyStatisticsWindow.Load(employee);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("You Loged Out.");
                        Console.WriteLine("Press any key.");
                        Console.ReadKey();
                        return;
                    default:
                        break;
                }
            }
        }

        public void DisplayMenu(Employee employee)
        {
            ConsoleHelper.ShowLoggedInAndClear(employee);
            Console.WriteLine("1. Take order \r\n2. Add new menu item \r\n3. Review exsisting orders \r\n4. Finish order \r\n5. Daily statistics \r\n6. Logout");
            Console.Write("Enter number from 1 to 6: ");
        }

    }
}
