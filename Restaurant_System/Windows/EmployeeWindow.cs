using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class EmployeeWindow
    {
        private readonly TakeOrderWindow _takeOrderWindow;
        public EmployeeWindow(TakeOrderWindow takeOrderWindow) 
        { 
            _takeOrderWindow = takeOrderWindow;
        }
        public void Load(Employee employee)
        {
            while (true)
            {
                DisplayMenu(employee);
                bool isLoadCorect = int.TryParse(Console.ReadLine(), out int loadSelect);
                while (!isLoadCorect || loadSelect < 1 || loadSelect > 4)
                {
                    Console.Write("Please enter a number from 1 to 4: ");
                    isLoadCorect = int.TryParse(Console.ReadLine(), out loadSelect);
                }
                switch (loadSelect)
                {
                    case 1:
                        _takeOrderWindow.Load();
                        break;
                    case 2:
                       /* _userLoginService.Login();*/
                        break;
                    case 3:
                       /* _adminLogin.Login();*/
                        break;
                    default:
                        break;
                }
            }
        }

        public void DisplayMenu(Employee employee)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {employee.Name}!");
            Console.WriteLine("1. Take order \r\n2. Review exsisting orders \r\n3. Daily statistics \r\n4. Logout");
            Console.Write("Enter number from 1 to 4: ");
        }

    }
}
