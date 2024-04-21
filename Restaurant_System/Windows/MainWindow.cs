using RestaurantSystem.Interfaces;
using RestaurantSystem.Models;

namespace RestaurantSystem.Windows
{
    public class MainWindow
    {
        private readonly EmployeeWindow _employeeWindow;
        private readonly IEmployeeService _employeeService;

        public MainWindow(EmployeeWindow employeeWindow, IEmployeeService employeeService)
        {
            _employeeWindow = employeeWindow;
            _employeeService = employeeService;
        }

        public void Load()
        {
            while (true)
            {
                DisplayMenu();
                bool isLoadCorect = int.TryParse(Console.ReadLine(), out int loadSelect);
                while (!isLoadCorect || loadSelect < 1 || loadSelect > 2)
                {
                    Console.Write("Please enter a number from 1 to 2: ");
                    isLoadCorect = int.TryParse(Console.ReadLine(), out loadSelect);
                }
                if (loadSelect == 1)
                {
                    EmployeeLogin();
                }
                else break;
            }
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to restaurant system!");
            Console.WriteLine("1. Login \r\n2. Exit");
            Console.Write("Enter number from 1 to 2: ");
        }

        public void EmployeeLogin()
        {
            Console.Clear();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            Employee employee = _employeeService.Authenticate(password);
            while (employee == null)
            {
                Console.Write("Incorrect password. Please try again: ");
                password = Console.ReadLine();
                employee = _employeeService.Authenticate(password);
            }
            _employeeWindow.Load(employee);
        }
    }
}
