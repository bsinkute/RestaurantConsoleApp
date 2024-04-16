using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class EmployeeWindow
    {
        private readonly TakeOrderWindow _takeOrderWindow;
        private readonly AddMenuItemWindow _addMenuItemWindow;
        private readonly ReviewOrdersWindow _reviewOrdersWindow;
        private readonly DailyStatisticsWindow _dailyStatisticsWindow;
        public EmployeeWindow(TakeOrderWindow takeOrderWindow, AddMenuItemWindow addMenuItemWindow, ReviewOrdersWindow reviewOrdersWindow, DailyStatisticsWindow dailyStatisticsWindow)
        {
            _takeOrderWindow = takeOrderWindow;
            _addMenuItemWindow = addMenuItemWindow;
            _reviewOrdersWindow = reviewOrdersWindow;
            _dailyStatisticsWindow = dailyStatisticsWindow;
        }
        public void Load(Employee employee)
        {
            while (true)
            {
                DisplayMenu(employee);
                bool isLoadCorect = int.TryParse(Console.ReadLine(), out int loadSelect);
                while (!isLoadCorect || loadSelect < 1 || loadSelect > 5)
                {
                    Console.Write("Please enter a number from 1 to 5: ");
                    isLoadCorect = int.TryParse(Console.ReadLine(), out loadSelect);
                }
                switch (loadSelect)
                {
                    case 1:
                        _takeOrderWindow.Load(employee);
                        break;
                    case 2:
                        _addMenuItemWindow.Load();
                        break;
                    case 3:
                        _reviewOrdersWindow.Load(employee);
                        break;
                    case 4:
                        _dailyStatisticsWindow.Load();
                        break;
                    case 5:
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
            Console.Clear();
            Console.WriteLine($"Welcome {employee.Name}!");
            Console.WriteLine("1. Take order \r\n2. Add new menu item \r\n3. Review exsisting orders \r\n4. Daily statistics \r\n5. Logout");
            Console.Write("Enter number from 1 to 5: ");
        }

    }
}
